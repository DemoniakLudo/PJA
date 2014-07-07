using ConvImgCpc;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class EditMap: Form {
		private DataMap dataMap;
		public bool Valid;
		private Projet projet;
		private int numImage = -1;
		private LockBitmap bmpLock;
		private BitmapCpc bitmapCPC;
		private Map curMap = null;
		private Zone newZone = null;
		private bool zoneDown = false;
		private Pen penWhite = new Pen(Color.White, 2);
		private Pen penRed = new Pen(Color.Red, 2);
		private Pen penBlue = new Pen(Color.Blue, 2);
		private Image selImage;

		public EditMap(Projet prj) {
			InitializeComponent();
			projet = prj;
			dataMap = prj.MapData;
			Valid = true;
			foreach (Image img in projet.ImageData.listImg)
				listImage.Items.Add(img);

			int tx = pictureBox.Width = prj.Cx * 8;
			int ty = pictureBox.Height = prj.Cy * 16;
			bitmapCPC = new BitmapCpc(tx, ty, prj.Mode);
			pictureBox.Image = new Bitmap(tx, ty);
			bmpLock = new LockBitmap(pictureBox.Image as Bitmap);

			penWhite.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			typeZone.DataSource = Enum.GetValues(typeof(Zone.TypeZone));
			RefreshListLieu();
		}

		private void RefreshListLieu() {
			listLieu.Items.Clear();
			foreach (Map m in projet.MapData.ListMap) {
				listLieu.Items.Add(m);
				if (curMap != null && curMap == m)
					listLieu.SelectedItem = m;
			}
		}

		private void SetNewImage(int index) {
			listImage.SelectedIndex = index;
			imageAffect.Text = index > -1 ? (listImage.SelectedItem as Image).ToString() : "";
			curMap.IndexImage = index;
			bpDelLieu.Enabled = index > -1;
		}

		private void listImage_SelectedIndexChanged(object sender, EventArgs e) {
			numImage = listImage.SelectedIndex;
			bpAffecte.Enabled = curMap != null && numImage > -1;
			ChangeMap(curMap, listImage.SelectedItem as Image);
		}

		private void bpAffecte_Click(object sender, EventArgs e) {
			SetNewImage(numImage);
		}

		private void bpDelLieu_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes-vous sur(e) de vouloir supprimer ce lieu ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curMap.LstZone.Clear();
				SetNewImage(-1);
			}
		}

		private void bpAddLieu_Click(object sender, EventArgs e) {
			curMap = new Map();
			curMap.Libelle = "Nouveau Lieu" + (projet.MapData.ListMap.Count + 1).ToString();
			projet.MapData.ListMap.Add(curMap);
			RefreshListLieu();
		}

		private void listLieu_SelectedIndexChanged(object sender, EventArgs e) {
			curMap = (Map)listLieu.SelectedItem;
			newZone = null;
			SetNewImage(curMap.IndexImage);
			libelleMap.Text = curMap.Libelle;
			if (curMap.IndexImage > -1)
				SetNewImage(curMap.IndexImage);
		}

		private void bpEditLibelle_Click(object sender, EventArgs e) {
			if (curMap != null) {
				curMap.Libelle = libelleMap.Text;
				RefreshListLieu();
			}
		}

		#region gestion des zones
		private void RenderZone(Zone z, Pen pen) {
			if (z.IsZone) {
				int xd = z.xd;
				int w = z.xa - z.xd;
				if (w < 0) {
					w = -w;
					xd = z.xa;
				}
				int yd = z.yd;
				int h = z.ya - z.yd;
				if (h < 0) {
					h = -h;
					yd = z.ya;
				}
				Graphics.FromImage(pictureBox.Image).DrawRectangle(pen, xd << 3, yd << 1, w << 3, h << 1);
				Graphics.FromImage(pictureBox.Image).DrawRectangle(penWhite, xd << 3, yd << 1, w << 3, h << 1);
			}
		}

		private void RenderAllZones() {
			bitmapCPC.Render(bmpLock, bitmapCPC.ModeCPC, 1, 0, 0, false);
			if (allZones.Checked && curMap != null)
				foreach (Zone z in curMap.LstZone)
					RenderZone(z, penBlue);

			if (newZone != null)
				RenderZone(newZone, penRed);

			pictureBox.Refresh();
		}

		private void RefreshListZone() {
			newZone = null;
			listZone.BeginUpdate();
			listZone.Items.Clear();
			if (curMap != null)
				foreach (Zone z in curMap.LstZone)
					listZone.Items.Add(z);

			listZone.EndUpdate();
		}

		private void ChangeMap(Map m, Image img) {
			curMap = m;
			selImage = img;
			if (selImage != null)
				selImage.GetImage(bitmapCPC.bmpCpc, bitmapCPC.Palette);
			else
				bitmapCPC.ClearBmp();

			RenderAllZones();
			RefreshListZone();
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			int x = e.X >> 3;
			int y = e.Y >> 1;
			if (!zoneDown) {
				newZone = new Zone(x, y);
				zoneDown = true;
				bpDelZone.Enabled = bpEditZone.Enabled = bpAddZone.Enabled = false;
			}
			newZone.xa = x;
			newZone.ya = y;
			RenderAllZones();
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left)
				pictureBox_MouseDown(sender, e);
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
			zoneDown = false;
			bpAddZone.Enabled = newZone.IsZone && curMap != null;
		}

		private void bpAddZone_Click(object sender, EventArgs e) {
			bpAddZone.Enabled = false;
			newZone.typeZone = (Zone.TypeZone)typeZone.SelectedItem;
			curMap.LstZone.Add(newZone);
			RefreshListZone();
			RenderAllZones();
		}

		private void bpDelZone_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette zone", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curMap.LstZone.Remove(newZone);
				RefreshListZone();
				RenderAllZones();
			}
		}

		private void listZone_SelectedIndexChanged(object sender, EventArgs e) {
			newZone = listZone.SelectedItem as Zone;
			typeZone.SelectedItem = newZone.typeZone;
			bpEditZone.Enabled = bpDelZone.Enabled = true;
			RenderAllZones();
		}

		private void allZones_CheckedChanged(object sender, EventArgs e) {
			RenderAllZones();
		}

		private void EditZone(Zone.TypeZone t) {
			newZone.typeZone = t;
			switch (t) {
				case Zone.TypeZone.DEPLACEMENT:
					SelectLieu sl = new SelectLieu(projet);
					sl.ShowDialog();
					newZone.varAction = sl.MapSel;
					break;

				case Zone.TypeZone.ACTION:
				case Zone.TypeZone.RECHERCHE:
					ChoixAction sa = new ChoixAction(projet, newZone);
					sa.ShowDialog();
					break;
			}
			RefreshListZone();
		}

		private void bpEditZone_Click(object sender, EventArgs e) {
			EditZone((Zone.TypeZone)typeZone.SelectedItem);
		}

		private void typeZone_SelectedIndexChanged(object sender, EventArgs e) {
			if (newZone != null) {
				Zone.TypeZone t = (Zone.TypeZone)typeZone.SelectedItem;
				if (newZone.typeZone != t) {
					EditZone(t);
				}
			}
		}
		#endregion

		private void EditMap_FormClosed(object sender, FormClosedEventArgs e) {
			Valid = false;
		}
	}
}
