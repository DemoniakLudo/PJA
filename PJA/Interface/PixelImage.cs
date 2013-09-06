using ConvImgCpc;
using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class PixelImage: Form {
		private Bitmap bmp;
		private LockBitmap bmpLock;
		public BitmapCPC bitmapCPC;
		private Label[] colors = new Label[16];
		public bool Valid = false;
		private int zoom;
		private int numCol;

		public PixelImage(BitmapCPC cpc, Size s) {
			InitializeComponent();
			bitmapCPC = cpc;
			bmp = new Bitmap(s.Width, s.Height);
			pictureBox.Image = bmp;
			bmpLock = new LockBitmap(bmp);
			for (int i = 0; i < 16; i++) {
				// Générer les contrôles de "couleurs"
				colors[i] = new Label();
				colors[i].BorderStyle = BorderStyle.FixedSingle;
				colors[i].Location = new Point(4 + i * 48, 550);
				colors[i].Size = new Size(40, 32);
				colors[i].Tag = i;
				colors[i].Click += ClickColor;
				Controls.Add(colors[i]);
			}
			zoomLevel.SelectedIndex = 0;
			Valid = true;
		}

		// Sélection couleur
		void ClickColor(object sender, System.EventArgs e) {
			Label colorClick = sender as Label;
			numCol = colorClick.Tag != null ? (int)colorClick.Tag : 0;
		}

		public void UpdatePalette() {
			for (int i = 0; i < 16; i++) {
				colors[i].BackColor = Color.FromArgb(bitmapCPC.GetPaletteColor(i).GetColorARGB);
				colors[i].Refresh();
			}
		}

		public void Render() {
			bitmapCPC.Render(bmpLock, bitmapCPC.ModeCPC, zoom, false);
			pictureBox.Refresh();
			UpdatePalette();
		}

		private void zoomLevel_SelectedIndexChanged(object sender, System.EventArgs e) {
			zoom = int.Parse(zoomLevel.SelectedItem.ToString());
			Render();
		}

		private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
				int x = e.X / zoom;
				int y = e.Y / zoom;
				bitmapCPC.SetPixelCpc(x, y, numCol);
				Render();
		}

		private void pictureBox_MouseMove(object sender, MouseEventArgs e) {
			if (e.Button == MouseButtons.Left) {
				pictureBox_MouseDown(sender, e);
			}
		}
	}
}
