﻿using ConvImgCpc;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace PJA {
	public partial class EditImages : Form {
		private Bitmap bmp, image;
		private LockBitmap bmpLock;
		public BitmapCpc bitmapCpc;
		private Label[] colors = new Label[16];
		private CheckBox[] lockColors = new CheckBox[16];
		public int[] lockState = new int[16];
		private DataImage dataImage;
		private int zoom = 1;
		private int numCol = 0;
		private int offsetX = 0, offsetY = 0;
		private Projet projet;
		public bool Valid = false;
		//private OcpPal Pal = new OcpPal();
		//static private char[] CpcVGA = new char[27] { 'T', 'D', 'U', '\\', 'X', ']', 'L', 'E', 'M', 'V', 'F', 'W', '^', '@', '_', 'N', 'G', 'O', 'R', 'B', 'S', 'Z', 'Y', '[', 'J', 'C', 'K' };
		private OpenFileDialog dlgLoadPal = new OpenFileDialog();
		private OpenFileDialog dlgImportImage = new OpenFileDialog();
		private Param param;
		private bool lockParam = false;

		public EditImages(Projet prj, Param p) {
			InitializeComponent();
			param = p;
			for (int i = 0; i < 16; i++) {
				// Générer les contrôles de "couleurs"
				colors[i] = new Label();
				colors[i].BorderStyle = BorderStyle.FixedSingle;
				colors[i].Location = new Point(4 + i * 48, 584);
				colors[i].Size = new Size(40, 32);
				colors[i].Tag = i;
				colors[i].Click += ClickColor;
				Controls.Add(colors[i]);
				// Générer les contrôles de "bloquage couleur"
				lockColors[i] = new CheckBox();
				lockColors[i].Location = new Point(16 + i * 48, 616);
				lockColors[i].Size = new Size(20, 20);
				lockColors[i].Tag = i;
				lockColors[i].Click += ClickLock;
				Controls.Add(lockColors[i]);
			}
			dataImage = prj.ImageData;
			MajProjet(prj, true);
			projet = prj;

			methode.SelectedIndex = param.methode;
			matrice.SelectedIndex = param.matrice - 2;
			pctTrame.Value = param.pct;
			lockState = param.lockState;
			lumi.Value = param.pctLumi;
			sat.Value = param.pctSat;
			contrast.Value = param.pctContrast;
			cpcPlus.Checked = param.cpcPlus;
			newMethode.Checked = param.newMethode;
			reducPal1.Checked = param.reductPal1;
			reducPal2.Checked = param.reductPal2;
			newReduc.Checked = param.newReduct;
			sortPal.Checked = param.sortPal;
			renderMode.SelectedIndex = param.pixMode;

			radioFit.Checked = param.sizeMode == Param.SizeMode.Fit;
			radioKeepLarger.Checked = param.sizeMode == Param.SizeMode.KeepLarger;
			radioKeepSmaller.Checked = param.sizeMode == Param.SizeMode.KeepSmaller;

			zoomLevel.SelectedIndex = 0;
			bpEditMode_CheckedChanged(null, null);
			UpdateListe(-1);
			Valid = true;
			dlgImportImage.Filter = "Images (*.scr, *.bin, *.bmp, *.gif, *.png, *.jpg)|*.scr;*.bin;*.bmp;*.gif;*.png;*.jpg|Tous les fichiers (*.*)|*.*";
			dlgLoadPal.Filter = "Fichier palette (*.pal)|*.pal";
		}

		public void MajProjet(Projet prj, bool newCpc) {
			int tx = pictureBox.Width = prj.Cx * 8;
			int ty = pictureBox.Height = prj.Cy * 16;
			if (newCpc)
				bitmapCpc = new BitmapCpc(tx, ty, prj.Mode);
			bmp = new Bitmap(tx, ty);
			pictureBox.Image = bmp;
			bmpLock = new LockBitmap(bmp);
			vScrollBar.Height = ty;
			vScrollBar.Left = tx + 3;
			hScrollBar.Width = tx;
			hScrollBar.Top = ty + 3;
			if (autoRecalc.Checked)
				bpRecalc_Click(this, null);
			else
				Render();
		}

		// Click sur un "lock"
		void ClickLock(object sender, EventArgs e) {
			CheckBox colorLock = sender as CheckBox;
			lockState[(int)colorLock.Tag] = colorLock.Checked ? 1 : 0;
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		// Changement de la palette
		void ClickColor(object sender, EventArgs e) {
			Label colorClick = sender as Label;
			numCol = colorClick.Tag != null ? (int)colorClick.Tag : 0;
			if (!bpEditMode.Checked) {
				EditColor ed = new EditColor(numCol, bitmapCpc.Palette[numCol], bitmapCpc.GetPaletteColor(numCol).GetColorArgb, cpcPlus.Checked);
				ed.ShowDialog(this);
				if (ed.isValide) {
					bitmapCpc.SetPalette(numCol, ed.ValColor);
					if (autoRecalc.Checked)
						bpRecalc_Click(sender, e);
					else
						Render();
				}
			}
		}

		public void UpdatePalette() {
			for (int i = 0; i < 16; i++) {
				colors[i].BackColor = Color.FromArgb(bitmapCpc.GetPaletteColor(i).GetColorArgb);
				colors[i].Refresh();
			}
		}

		private void Render() {
			bitmapCpc.cpcPlus = cpcPlus.Checked;
			for (int y = 0; y < bitmapCpc.TailleY; y += 2) {
				int mode = (bitmapCpc.ModeCPC >= 3 ? (y & 2) == 0 ? bitmapCpc.ModeCPC - 2 : bitmapCpc.ModeCPC - 3 : bitmapCpc.ModeCPC);
				bitmapCpc.Render(bmpLock, y, mode, zoom, offsetX, offsetY);
			}
			pictureBox.Refresh();
			UpdatePalette();
			pictureBox.Refresh();
			UpdatePalette();
		}

		private void lockAllPal_CheckedChanged(object sender, EventArgs e) {
			for (int i = 0; i < 16; i++) {
				lockColors[i].Checked = lockAllPal.Checked;
				lockState[i] = lockAllPal.Checked ? 1 : 0;
			}
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void UpdateListe(int pos) {
			listImage.BeginUpdate();
			listImage.Items.Clear();
			foreach (Image img in dataImage.listImg)
				listImage.Items.Add(img);

			listImage.EndUpdate();
			if (pos != -1)
				listImage.SelectedIndex = pos;
			else
				imageName.Text = "";
		}

		private void bpImport_Click(object sender, EventArgs e) {
			DialogResult result = dlgImportImage.ShowDialog();
			if (result == DialogResult.OK) {
				dlgImportImage.InitialDirectory = dlgImportImage.FileName.Substring(0, dlgImportImage.FileName.LastIndexOf("\\"));
				try {
					image = new Bitmap(dlgImportImage.FileName);
				}
				catch {
					bitmapCpc.CreateImageFile(dlgImportImage.FileName);
					cpcPlus.Checked = bitmapCpc.cpcPlus;
					projet.Cx = bitmapCpc.TailleX >> 3;
					projet.Cy = bitmapCpc.TailleY >> 4;
					projet.Mode = bitmapCpc.ModeCPC;
					MajProjet(projet, false);
				}
				bpRecalc_Click(sender, e);
				imageName.Text = dlgImportImage.SafeFileName;
			}
		}

		private void bpAdd_Click(object sender, EventArgs e) {
			if (imageName.Text.Length > 0) {
				dataImage.AddImage(imageName.Text, bitmapCpc.Palette, bitmapCpc.bmpCpc, projet.Cx, projet.Cy);
				UpdateListe(listImage.Items.Count);
			}
		}

		private void bpEdit_Click(object sender, EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && imageName.Text.Length > 0) {
				img.nom = imageName.Text;
				UpdateListe(listImage.SelectedIndex);
			}
		}

		private void bpSuppr_Click(object sender, EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette image", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				dataImage.DeleteImage(img);
				UpdateListe(-1);
			}
		}

		private void bpRazLumi_Click(object sender, EventArgs e) {
			lumi.Value = 100;
		}

		private void bpRazSat_Click(object sender, EventArgs e) {
			sat.Value = 100;
		}

		private void bpRazContrast_Click(object sender, EventArgs e) {
			contrast.Value = 100;
		}

		// Recalculer l'image CPC résultante
		private void bpRecalc_Click(object sender, EventArgs e) {
			if (sender != null && image != null) {
				bpRecalc.Enabled = false;
				long t0 = Environment.TickCount;
				param.lockState = lockState;
				Conversion.Convert(image, bitmapCpc, param);
				long t1 = Environment.TickCount;
				lblTps.Text = (t1 - t0).ToString() + " ms";
				Render();
				bpRecalc.Enabled = true;
			}
		}

		private void listImage_SelectedIndexChanged(object sender, EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null) {
				imageName.Text = img.nom;
				img.GetImage(bitmapCpc.bmpCpc, bitmapCpc.Palette);
				Render();
			}
		}

		private void ChangeParam(object sender, EventArgs e) {
			if (!lockParam) {
				param.sizeMode = radioKeepLarger.Checked ? Param.SizeMode.KeepLarger : radioKeepSmaller.Checked ? Param.SizeMode.KeepSmaller : Param.SizeMode.Fit;
				param.pct = (int)pctTrame.Value;
				param.methode = methode.SelectedIndex;
				param.matrice = matrice.SelectedIndex + 2;
				param.pixMode = renderMode.SelectedIndex;
				param.pctLumi = (int)lumi.Value;
				param.pctSat = nb.Checked ? 0 : (int)sat.Value;
				param.pctContrast = (int)contrast.Value;
				param.sortPal = sortPal.Checked;
				param.newMethode = newMethode.Checked;
				reducPal1.Enabled = reducPal2.Enabled = param.cpcPlus = cpcPlus.Checked;
				newReduc.Enabled = reducPal1.Checked || reducPal2.Checked;
				newReduc.Enabled = reducPal1.Checked || reducPal2.Checked;
				param.reductPal1 = reducPal1.Checked;
				param.reductPal2 = reducPal2.Checked;
				param.newReduct = newReduc.Checked;
				bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
			}
		}

		private void bpUp_Click(object sender, EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && listImage.SelectedIndex > 0) {
				dataImage.Up(img);
				UpdateListe(listImage.SelectedIndex - 1);
			}
		}

		private void bpDn_Click(object sender, EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && listImage.SelectedIndex < listImage.Items.Count - 1) {
				dataImage.Down(img);
				UpdateListe(listImage.SelectedIndex + 1);
			}
		}

		private void bpLoadPal_Click(object sender, EventArgs e) {
			DialogResult result = dlgLoadPal.ShowDialog();
			if (result == DialogResult.OK) {
				dlgLoadPal.InitialDirectory = dlgLoadPal.FileName.Substring(0, dlgLoadPal.FileName.LastIndexOf("\\"));
				Palette palTmp = new Palette();
				StreamReader rd = new StreamReader(dlgLoadPal.FileName);
				if (palTmp.Load(rd)) {
					for (int i = 0; i < 16; i++)
						bitmapCpc.SetPalette(i, palTmp.GetPalette(i));

					string strNbp = rd.ReadLine();
					if (strNbp != null && strNbp.StartsWith("#NB_PAL_PREDEF")) {
						int nbP = int.Parse(strNbp.Substring(14));
						dataImage.listPal.Clear();
						for (; nbP-- > 0; )
							dataImage.listPal.Add(new Palette(rd));
					}
					UpdatePalette();
					Image img = listImage.SelectedItem as Image;
					if (img != null) {
						img.SetPal(palTmp);
						if (autoRecalc.Checked)
							bpRecalc_Click(sender, e);
						else
							Render();
					}
				}
				rd.Close();
			}
		}

		private void bpSavePal_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichier palette PJA (*.pal)|*.pal";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				StreamWriter wr = new StreamWriter(dlg.FileName);
				Palette palTmp = new Palette(bitmapCpc.Palette);
				palTmp.Save(wr);
				wr.WriteLine("#NB_PAL_PREDEF\t" + dataImage.listPal.Count);
				foreach (Palette p in dataImage.listPal)
					p.Save(wr);
				wr.Close();
			}
		}

		private void bpPredefPal_Click(object sender, EventArgs e) {
			PredefPal pPal = new PredefPal(dataImage.listPal, bitmapCpc.Palette);
			pPal.ShowDialog();
			if (pPal.selPal != null) {
				for (int i = 0; i < 16; i++)
					bitmapCpc.SetPalette(i, pPal.selPal.GetPalette(i));

				if (autoRecalc.Checked)
					bpRecalc_Click(sender, e);
				else
					Render();
			}
		}

		private void bpEditMode_CheckedChanged(object sender, EventArgs e) {
			zoomLevel.Enabled = bpEditMode.Checked;
			if (!bpEditMode.Checked)
				zoomLevel.SelectedIndex = 0;
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			if (bpEditMode.Checked) {
				bitmapCpc.SetPixelCpc(offsetX + (e.X / zoom), offsetY + (e.Y / zoom), numCol, bitmapCpc.ModeCPC);
				Render();
			}
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left)
				pictureBox_MouseDown(sender, e);
		}

		private void vScrollBar_Scroll(object sender, ScrollEventArgs e) {
			offsetY = (vScrollBar.Value >> 1) << 1;
			Render();
		}

		private void hScrollBar_Scroll(object sender, ScrollEventArgs e) {
			offsetX = (hScrollBar.Value >> 3) << 3;
			Render();
		}

		private void zoomLevel_SelectedIndexChanged(object sender, EventArgs e) {
			zoom = int.Parse(zoomLevel.SelectedItem.ToString());
			vScrollBar.Enabled = hScrollBar.Enabled = zoom > 1;
			hScrollBar.Maximum = hScrollBar.LargeChange + bmp.Width - (bmp.Width / zoom);
			vScrollBar.Maximum = vScrollBar.LargeChange + bmp.Height - (bmp.Height / zoom);
			hScrollBar.Value = offsetX = (bmp.Width - bmp.Width / zoom) / 2;
			vScrollBar.Value = offsetY = (bmp.Height - bmp.Height / zoom) / 2;
			Render();
		}

		private void bpLoadParam_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Paramètres ConvImagesCpc (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Open);
				try {
					lockParam = true;
					param = (Param)new XmlSerializer(typeof(Param)).Deserialize(file);
					// Initialisation paramètres...
					methode.SelectedIndex = param.methode;
					matrice.SelectedIndex = param.matrice - 2;
					pctTrame.Value = param.pct;
					lockState = param.lockState;
					lumi.Value = param.pctLumi;
					sat.Value = param.pctSat;
					contrast.Value = param.pctContrast;
					cpcPlus.Checked = param.cpcPlus;
					newMethode.Checked = param.newMethode;
					reducPal1.Checked = param.reductPal1;
					reducPal2.Checked = param.reductPal2;
					newReduc.Checked = param.newReduct;
					sortPal.Checked = param.sortPal;
					renderMode.SelectedIndex = param.pixMode;
					radioFit.Checked = param.sizeMode == Param.SizeMode.Fit;
					radioKeepLarger.Checked = param.sizeMode == Param.SizeMode.KeepLarger;
					radioKeepSmaller.Checked = param.sizeMode == Param.SizeMode.KeepSmaller;
					lockParam = false;
				}
				catch (Exception ex) {
				}
				file.Close();
			}
		}

		private void bpSaveParam_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Paramètres ConvImagesCpc (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Param)).Serialize(file, param);
				}
				catch (Exception ex) {
				}
				file.Close();
			}
		}

		private void EditImages_FormClosed(object sender, FormClosedEventArgs e) {
			Valid = false;
		}

		/*
		private bool SauvePalette(string NomFic, int Mode, int[] Palette, bool CpcPlus) {
			int i;

			Pal.Mode = (byte)Mode;
			if (CpcPlus) {
				for (i = 0; i < 16; i++) {
					Pal.Palette[i, 0] = CpcVGA[26 - ((Palette[i] >> 4) & 0x0F)];
					Pal.Palette[i, 1] = CpcVGA[26 - (Palette[i] & 0x0F)];
					Pal.Palette[i, 2] = CpcVGA[26 - ((Palette[i] >> 8) & 0x0F)];
				}
				Pal.Border[0] = Pal.Palette[0, 0];
				Pal.Border[1] = Pal.Palette[0, 1];
				Pal.Border[2] = Pal.Palette[0, 2];
			}
			else {
				for (i = 0; i < 16; i++)
					for (int j = 0; j < 12; j++)
						Pal.Palette[i, j] = CpcVGA[Palette[i]];

				for (i = 0; i < 12; i++)
					Pal.Border[i] = Pal.Palette[0, i];

			}
			FILE* fp = fopen(NomFic, "wb");
			if (fp) {
				CreeEntete(fp, NomFic, 0x8809, sizeof(Pal), 0x8809);
				fwrite(&Pal, sizeof(Pal), 1, fp);
				fclose(fp);
				return (TRUE);
			}
			return (FALSE);
		}


		private bool LirePalette(string NomFic, int[] Palette, bool CpcPlus) {
			FILE* fp = fopen(NomFic, "rb");
			if (fp) {
				fread(&Entete, sizeof(Entete), 1, fp);
				fread(&Pal, sizeof(Pal), 1, fp);
				fclose(fp);
				if (CheckAmsdos((byte*)&Entete) && Pal.Mode < 3) {
					if (CpcPlus) {
						for (int i = 0; i < 16; i++) {
							int r = 0, v = 0, b = 0;
							for (int k = 26; k--; ) {
								if (Pal.Palette[i,0] == CpcVGA[k])
									r = (26 - k) << 4;

								if (Pal.Palette[i,1] == CpcVGA[k])
									b = 26 - k;

								if (Pal.Palette[i,2] == CpcVGA[k])
									v = (26 - k) << 8;
							}
							Palette[i] = r + v + b;
						}
					}
					else {
						for (int i = 0; i < 16; i++)
							for (int j = 0; j < 27; j++)
								if (Pal.Palette[i,0] == CpcVGA[j])
									Palette[i] = j;

					}
					return true;
				}
			}
			return false;
		}
		*/

	}
	/*
	//
	// Structure palette (comme OCP art studio)
	//
	public class OcpPal {
		public byte Mode;
		public byte AnimFlag;
		public byte AnimDelay;
		public char[,] Palette = new char[16, 12];
		public char[] Border = new char[12];
		public byte[] ExcludedInk = new byte[16];
		public byte[] ProtectedInk = new byte[16];
	}*/
}
