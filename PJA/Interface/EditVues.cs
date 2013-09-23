﻿using ConvImgCpc;
using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class EditVues: Form {
		private LockBitmap bmpLock;
		private BitmapCPC bitmapCPC;
		private Projet projet;
		private Map curMap = null;
		private int numImage;
		private Zone newZone = new Zone(0, 0);
		private bool zoneDown = false;
		private Pen penWhite = new Pen(Color.White, 2);
		private Pen penRed = new Pen(Color.Red, 2);
		private Pen penBlue = new Pen(Color.Blue, 2);

		public EditVues(Projet prj) {
			InitializeComponent();
			projet = prj;
			int tx = pictureBox.Width = projet.Cx * 8;
			int ty = pictureBox.Height = projet.Cy * 16;
			bitmapCPC = new BitmapCPC(tx, ty, projet.Mode);
			pictureBox.Image = new Bitmap(tx, ty);
			bmpLock = new LockBitmap(pictureBox.Image as Bitmap);
			foreach (Image img in projet.ImageData.listImg)
				listImage.Items.Add(img);

			numSalle.Maximum = projet.MapData.NbSalles - 1;
			numSalle.Value = 0;
			penWhite.DashStyle = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			typeZone.DataSource = System.Enum.GetValues(typeof(Zone.TypeZone));
			Render();
		}

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

		private void Render() {
			bitmapCPC.Render(bmpLock, bitmapCPC.ModeCPC, 1, 0, 0, false);
			if (allZones.Checked && curMap != null)
				foreach (Zone z in curMap.LstZone)
					RenderZone(z, penBlue);

			if (newZone != null)
				RenderZone(newZone, penRed);

			pictureBox.Refresh();
		}

		private void RefreshListZone() {
			listZone.BeginUpdate();
			listZone.Items.Clear();
			if (curMap != null)
				foreach (Zone z in curMap.LstZone)
					listZone.Items.Add(z);

			listZone.EndUpdate();
		}

		private void SetNewImage(int index) {
			listImage.SelectedIndex = index;
			imageAffect.Text = index > -1 ? (listImage.SelectedItem as Image).ToString() : "";
			if (curMap != null)
				curMap.IndexImage = index;

			bpDelVue.Enabled = index > -1;
		}

		private void listImage_SelectedIndexChanged(object sender, System.EventArgs e) {
			Image selImage = listImage.SelectedItem as Image;
			if (selImage != null) {
				selImage.SendPalette(bitmapCPC.Palette);
				System.Array.Copy(selImage.data, bitmapCPC.BmpCpc, selImage.data.Length);
			}
			else
				System.Array.Clear(bitmapCPC.BmpCpc, 0, bitmapCPC.BmpCpc.Length);

			Render();
			RefreshListZone();
			numImage = listImage.SelectedIndex;
			bpAffecte.Enabled = numImage > -1;
		}

		private void numSalle_ValueChanged(object sender, System.EventArgs e) {
			curMap = projet.MapData.FindMap((int)numSalle.Value);
			SetNewImage(curMap != null ? curMap.IndexImage : -1);
			bpAffecte.Enabled = numImage > -1;
		}

		private void bpAffecte_Click(object sender, System.EventArgs e) {
			SetNewImage(numImage);
		}

		private void bpDelVue_Click(object sender, System.EventArgs e) {
			if (curMap.IndexImage > -1 && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette affectation ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curMap.LstZone.Clear();
				SetNewImage(-1);
			}
		}

		private void bpAddZone_Click(object sender, System.EventArgs e) {
			bpAddZone.Enabled = false;
			newZone.typeZone = (Zone.TypeZone)typeZone.SelectedItem;
			curMap.LstZone.Add(newZone);
			newZone = new Zone(0, 0);
			Render();
			RefreshListZone();
		}

		private void bpDelZone_Click(object sender, System.EventArgs e) {
			if (MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette zone", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curMap.LstZone.Remove(newZone);
				RefreshListZone();
				newZone = new Zone(0, 0);
				Render();
			}
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
			if (newZone != null) {
				int x = e.X >> 3;
				int y = e.Y >> 1;
				if (!zoneDown) {
					newZone = new Zone(x, y);
					zoneDown = true;
					bpDelZone.Enabled = bpAddZone.Enabled = false;
				}
				newZone.xa = x;
				newZone.ya = y;
				Render();
			}
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
				pictureBox_MouseDown(sender, e);
		}

		private void pictureBox_MouseUp(object sender, MouseEventArgs e) {
			zoneDown = false;
			bpAddZone.Enabled = newZone.IsZone;
		}

		private void listZone_SelectedIndexChanged(object sender, System.EventArgs e) {
			newZone = listZone.SelectedItem as Zone;
			typeZone.SelectedItem = newZone.typeZone;
			bpDelZone.Enabled = true;
			Render();
		}

		private void allZones_CheckedChanged(object sender, System.EventArgs e) {
			Render();
		}
	}
}
