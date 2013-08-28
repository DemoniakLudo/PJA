﻿using ConvImgCpc;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PJA {
	public partial class EditImages: Form {
		private Bitmap bmp, image;
		private LockBitmap bmpLock;
		public BitmapCPC bitmapCPC;
		private Label[] colors = new Label[16];
		private CheckBox[] lockColors = new CheckBox[16];
		public int[] lockState = new int[16];
		private DataImage dataImage;
		public bool Valid = false;
		//private OcpPal Pal = new OcpPal();
		//static private char[] CpcVGA = new char[27] { 'T', 'D', 'U', '\\', 'X', ']', 'L', 'E', 'M', 'V', 'F', 'W', '^', '@', '_', 'N', 'G', 'O', 'R', 'B', 'S', 'Z', 'Y', '[', 'J', 'C', 'K' };
		private OpenFileDialog dlgLoadPal = new OpenFileDialog();
		private OpenFileDialog dlgImportImage = new OpenFileDialog();

		public EditImages(Projet projet) {
			InitializeComponent();
			dataImage = projet.ImageData;
			int tx = pictureBox.Width = projet.Cx * 8;
			int ty = pictureBox.Height = projet.Cy * 16;
			bmp = new Bitmap(tx, ty);
			pictureBox.Image = bmp;
			bmpLock = new LockBitmap(bmp);
			bitmapCPC = new BitmapCPC(tx, ty, projet.Mode);
			for (int i = 0; i < 16; i++) {
				// Générer les contrôles de "couleurs"
				colors[i] = new Label();
				colors[i].BorderStyle = BorderStyle.FixedSingle;
				colors[i].Location = new Point(4 + i * 48, 550);
				colors[i].Size = new Size(40, 32);
				colors[i].Tag = i;
				colors[i].Click += ClickColor;
				Controls.Add(colors[i]);
				// Générer les contrôles de "bloquage couleur"
				lockColors[i] = new CheckBox();
				lockColors[i].Location = new Point(16 + i * 48, 586);
				lockColors[i].Size = new Size(20, 20);
				lockColors[i].Tag = i;
				lockColors[i].Click += ClickLock;
				Controls.Add(lockColors[i]);
			}
			radioFit.Checked = true;
			methode.SelectedIndex = 0;
			matrice.SelectedIndex = 0;
			renderMode.SelectedIndex = 0;
			Render();
			UpdateListe(-1);
			Valid = true;
			dlgImportImage.Filter = "Images (*.bmp, *.gif, *.png, *.jpg)|*.bmp;*.gif;*.png;*.jpg";
			dlgLoadPal.Filter = "Fichier palette (*.pal)|*.pal";
		}

		// Click sur un "lock"
		void ClickLock(object sender, System.EventArgs e) {
			CheckBox colorLock = sender as CheckBox;
			lockState[(int)colorLock.Tag] = colorLock.Checked ? 1 : 0;
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		// Changement de la palette
		void ClickColor(object sender, System.EventArgs e) {
			Label colorClick = sender as Label;
			int numCol = colorClick.Tag != null ? (int)colorClick.Tag : 0;
			EditColor ed = new EditColor(numCol, bitmapCPC.Palette[numCol], bitmapCPC.GetPaletteColor(numCol).GetColorARGB);
			ed.ShowDialog(this);
			if (ed.isValide) {
				bitmapCPC.SetPalette(numCol, ed.ValColor);
				if (autoRecalc.Checked)
					bpRecalc_Click(sender, e);
				else
					Render();
			}
		}

		public void UpdatePalette() {
			for (int i = 0; i < 16; i++) {
				colors[i].BackColor = Color.FromArgb(bitmapCPC.GetPaletteColor(i).GetColorARGB);
				colors[i].Refresh();
			}
		}

		public void Render() {
			bitmapCPC.Render(bmpLock, bitmapCPC.ModeCPC, false);
			pictureBox.Refresh();
			UpdatePalette();
		}

		private void lockAllPal_CheckedChanged(object sender, System.EventArgs e) {
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

		private void bpImport_Click(object sender, System.EventArgs e) {
			DialogResult result = dlgImportImage.ShowDialog();
			if (result == DialogResult.OK) {
				dlgImportImage.InitialDirectory = dlgImportImage.FileName.Substring(0, dlgImportImage.FileName.LastIndexOf("\\"));
				image = new Bitmap(dlgImportImage.FileName);
				bpRecalc_Click(sender, e);
				imageName.Text = dlgImportImage.SafeFileName;
			}
		}

		private void bpAdd_Click(object sender, System.EventArgs e) {
			if (imageName.Text.Length > 0) {
				dataImage.AddImage(imageName.Text, bitmapCPC.Palette, bitmapCPC.BmpCpc);
				UpdateListe(listImage.Items.Count);
			}
		}

		private void bpEdit_Click(object sender, System.EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && imageName.Text.Length > 0) {
				dataImage.RenameImage(img, imageName.Text);
				UpdateListe(listImage.SelectedIndex);
			}
		}

		private void bpSuppr_Click(object sender, System.EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette image", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				dataImage.DeleteImage(img);
				UpdateListe(-1);
			}
		}

		private void bpRazLumi_Click(object sender, System.EventArgs e) {
			lumi.Value = 100;
		}

		private void bpRazSat_Click(object sender, System.EventArgs e) {
			sat.Value = 100;
		}

		private void bpRazContrast_Click(object sender, System.EventArgs e) {
			contrast.Value = 100;
		}

		// Recalculer l'image CPC résultante
		private void bpRecalc_Click(object sender, System.EventArgs e) {
			if (sender != null && image != null) {
				bpRecalc.Enabled = false;
				long t0 = System.Environment.TickCount;
				Conversion.Convert(image,
									bitmapCPC,
									radioKeepLarger.Checked ? Conversion.SizeMode.KeepLarger : radioKeepSmaller.Checked ? Conversion.SizeMode.KeepSmaller : Conversion.SizeMode.Fit,
									methode.SelectedIndex,
									matrice.SelectedIndex + 2,
									(int)pctTrame.Value,
									lockState,
									(int)lumi.Value,
									(int)sat.Value,
									(int)contrast.Value,
									false,
									newMethode.Checked,
									nb.Checked,
									false,
									false,
									false,
									sortPal.Checked,
									renderMode.SelectedIndex);
				long t1 = System.Environment.TickCount;
				lblTps.Text = (t1 - t0).ToString() + " ms";
				Render();
				bpRecalc.Enabled = true;
			}
		}

		private void listImage_SelectedIndexChanged(object sender, System.EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null) {
				imageName.Text = img.nom;
				for (int i = 0; i < 16; i++)
					bitmapCPC.SetPalette(i, img.GetPalette(i));

				for (int i = 0; i < 0x4000; i++)
					bitmapCPC.BmpCpc[i] = img.data[i];

				Render();
			}
		}

		private void radioFit_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void radioKeepSmaller_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void radioKeepLarger_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void pctTrame_ValueChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void methode_SelectedIndexChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void matrice_SelectedIndexChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void renderMode_SelectedIndexChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void lumi_ValueChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void sat_ValueChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void contrast_ValueChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void sortPal_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void newMethode_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}

		private void nb_CheckedChanged(object sender, System.EventArgs e) {
			bpRecalc_Click(autoRecalc.Checked ? sender : null, e);
		}
		private void bpUp_Click(object sender, System.EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && listImage.SelectedIndex > 0) {
				dataImage.Up(img);
				UpdateListe(listImage.SelectedIndex - 1);
			}
		}

		private void bpDn_Click(object sender, System.EventArgs e) {
			Image img = listImage.SelectedItem as Image;
			if (img != null && listImage.SelectedIndex < listImage.Items.Count - 1) {
				dataImage.Down(img);
				UpdateListe(listImage.SelectedIndex + 1);
			}
		}

		private void bpLoadPal_Click(object sender, System.EventArgs e) {
			DialogResult result = dlgLoadPal.ShowDialog();
			if (result == DialogResult.OK) {
				dlgLoadPal.InitialDirectory = dlgLoadPal.FileName.Substring(0, dlgLoadPal.FileName.LastIndexOf("\\"));
				Palette palTmp = new Palette();
				StreamReader rd = new StreamReader(dlgLoadPal.FileName);
				if (palTmp.Load(rd)) {
					for (int i = 0; i < 16; i++)
						bitmapCPC.SetPalette(i, palTmp.GetPalette(i));

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

		private void bpSavePal_Click(object sender, System.EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Fichier palette PJA (*.pal)|*.pal";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				StreamWriter wr = new StreamWriter(dlg.FileName);
				Palette palTmp = new Palette(bitmapCPC.Palette);
				palTmp.Save(wr);
				wr.WriteLine("#NB_PAL_PREDEF\t" + dataImage.listPal.Count);
				foreach (Palette p in dataImage.listPal)
					p.Save(wr);
				wr.Close();
			}
		}

		private void bpPredefPal_Click(object sender, System.EventArgs e) {
			PredefPal pPal = new PredefPal(dataImage.listPal, bitmapCPC.Palette);
			pPal.ShowDialog();
			if (pPal.selPal != null) {
				for (int i = 0; i < 16; i++)
					bitmapCPC.SetPalette(i, pPal.selPal.GetPalette(i));

				if (autoRecalc.Checked)
					bpRecalc_Click(sender, e);
				else
					Render();
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