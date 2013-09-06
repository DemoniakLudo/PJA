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
			Render();
			Valid = true;
		}

		// Changement de la palette
		void ClickColor(object sender, System.EventArgs e) {
			Label colorClick = sender as Label;
			int numCol = colorClick.Tag != null ? (int)colorClick.Tag : 0;
			EditColor ed = new EditColor(numCol, bitmapCPC.Palette[numCol], bitmapCPC.GetPaletteColor(numCol).GetColorARGB);
			ed.ShowDialog(this);
			if (ed.isValide) {
				bitmapCPC.SetPalette(numCol, ed.ValColor);
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
	}
}
