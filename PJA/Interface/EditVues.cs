using ConvImgCpc;
using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class EditVues: Form {
		private LockBitmap bmpLock;
		private BitmapCPC bitmapCPC;
		private Projet projet;
		private Map curMap = null;
		private Vue selVue = null;
		private DataVue dataVue;
		private int numImage;

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

			dataVue = projet.VueData;
			RefreshListVue();
			numSalle.Maximum = projet.MapData.NbSalles - 1;
			numSalle.Value = 0;
		}

		private void Render() {
			bitmapCPC.Render(bmpLock, bitmapCPC.ModeCPC, 1, 0, 0, false);
			pictureBox.Refresh();
		}

		private void RefreshListVue() {
			listVue.BeginUpdate();
			listVue.Items.Clear();
			foreach (Vue v in dataVue.listVue)
				listVue.Items.Add(v);

			listVue.EndUpdate();
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
			numImage = listImage.SelectedIndex;
		}

		private void numSalle_ValueChanged(object sender, System.EventArgs e) {
			int x = 0, y = 0, n = 0;
			if (projet.MapData.RechercheSalle((int)numSalle.Value, ref x, ref y, ref n))
				curMap = projet.MapData.GetMap(x, y, n);
			else
				curMap = null;

			bpAffecte.Enabled = bpSupprime.Enabled = (curMap != null && curMap.numVue > 0);
			listVue.SelectedIndex = (curMap != null && curMap.numVue > 0) ? curMap.numVue - 1 : -1;
		}

		private void nomVue_TextChanged(object sender, System.EventArgs e) {
			bpAddVue.Enabled = nomVue.Text.Length > 0;
		}

		private void bpAffecte_Click(object sender, System.EventArgs e) {
			curMap.numVue = selVue.numVue;
		}

		private void bpAddVue_Click(object sender, System.EventArgs e) {
			Vue v = new Vue((byte)(1 + dataVue.listVue.Count), nomVue.Text, numImage);
			dataVue.listVue.Add(v);
			RefreshListVue();
		}

		private void bpEdit_Click(object sender, System.EventArgs e) {
			selVue.libelle = nomVue.Text;
			selVue.indexImage = numImage;
		}

		private void bpSupprime_Click(object sender, System.EventArgs e) {
			if (selVue != null && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette vue", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				dataVue.listVue.Remove(selVue);
				RefreshListVue();
			}
		}

		private void listVue_SelectedIndexChanged(object sender, System.EventArgs e) {
			selVue = listVue.SelectedItem as Vue;
			bpAffecte.Enabled = bpEdit.Enabled = bpSupprime.Enabled = selVue != null;
			nomVue.Text = selVue != null ? selVue.libelle : "";
			listImage.SelectedIndex = selVue != null && listImage.Items.Count > selVue.indexImage ? selVue.indexImage : -1;
		}
	}
}
