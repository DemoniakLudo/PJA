using System;
using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class Main: Form {
		private Projet projet = new Projet();
		private EditImages editImages;
		private EditMap editMap;
		//private const int maxLiCo = 2048;
		private const int maxLiCo = 4096;

		public Main() {
			InitializeComponent();
			bpNew_Click(null, null);
		}

		private void EditMapClick(object sender, EventArgs e) {
			Point p = editMap != null ? editMap.Location : new Point(0, 0);
			if (editMap == null || !editMap.Valid) // si pas déjà visible
				editMap = new EditMap(projet);

			editMap.Location = p;
			editMap.Show();
		}

		private void EditImgClick(object sender, EventArgs e) {
			Point p = editImages != null ? editImages.Location : new Point(0, 0);
			if (editImages == null || !editImages.Valid) // si pas déja visible
				editImages = new EditImages(projet);

			editImages.Location = p;
			editImages.Show();
		}

		private void mode_SelectedIndexChanged(object sender, EventArgs e) {
			projet.Mode = mode.SelectedIndex;
		}

		private void nbLignes_ValueChanged(object sender, EventArgs e) {
			nbCols.Value = Math.Min(nbCols.Value, (int)(maxLiCo / nbLignes.Value));
			projet.Cx = (int)nbCols.Value;
			projet.Cy = (int)nbLignes.Value;
		}

		private void nbCols_ValueChanged(object sender, EventArgs e) {
			nbLignes.Value = Math.Min(nbLignes.Value, (int)(maxLiCo / nbCols.Value));
			projet.Cy = (int)nbLignes.Value;
			projet.Cx = (int)nbCols.Value;
		}

		private void bpNew_Click(object sender, EventArgs e) {
			projet.New();
			mode.SelectedIndex = projet.Mode;
			nbCols.Value = projet.Cx;
			nbLignes.Value = projet.Cy;
		}

		private void bpLoad_Click(object sender, EventArgs e) {
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Projet PJA (*.pja)|*.pja";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				if (!projet.Load(dlg.FileName))
					MessageBox.Show("Erreur de lecture...");
			}
		}

		private void bpSave_Click(object sender, EventArgs e) {
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Projet PJA (*.pja)|*.pja";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				if (!projet.Save(dlg.FileName))
					MessageBox.Show("Erreur de sauvegarde...");
			}
		}
	}
}
