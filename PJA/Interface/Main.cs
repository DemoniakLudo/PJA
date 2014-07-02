using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;

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

		private void SetEtatBp(bool etat) {
			bpEditMap.Enabled = bpEditImg.Enabled = bpLoad.Enabled = bpNew.Enabled = bpSave.Enabled = bpRepack.Enabled = etat;
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
			if (editImages != null)
				editImages.MajProjet(projet, true);
		}

		private void nbLignes_ValueChanged(object sender, EventArgs e) {
			nbCols.Value = Math.Min(nbCols.Value, (int)(maxLiCo / nbLignes.Value));
			projet.Cx = (int)nbCols.Value;
			projet.Cy = (int)nbLignes.Value;
			if (editImages != null)
				editImages.MajProjet(projet, true);
		}

		private void nbCols_ValueChanged(object sender, EventArgs e) {
			nbLignes.Value = Math.Min(nbLignes.Value, (int)(maxLiCo / nbCols.Value));
			projet.Cy = (int)nbLignes.Value;
			projet.Cx = (int)nbCols.Value;
			if (editImages != null)
				editImages.MajProjet(projet, true);
		}

		private void bpNew_Click(object sender, EventArgs e) {
			projet.New();
			mode.SelectedIndex = projet.Mode;
			nbCols.Value = projet.Cx;
			nbLignes.Value = projet.Cy;
			if (editImages != null)
				editImages.MajProjet(projet, true);
		}

		static private void ShowException(Exception ex) {
			string msg = "";
			while (ex != null) {
				msg += ex.Message + "\n";
				ex = ex.InnerException;
			}
			MessageBox.Show(msg);
		}

		private void bpLoad_Click(object sender, EventArgs e) {
			SetEtatBp(false);
			OpenFileDialog dlg = new OpenFileDialog();
			dlg.Filter = "Projet PJA (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Open);
				try {
					projet = (Projet)new XmlSerializer(typeof(Projet)).Deserialize(file);
					nomProjet.Text = dlg.SafeFileName;
					mode.SelectedIndex = projet.Mode;
					int y = projet.Cy;
					nbCols.Value = projet.Cx;
					nbLignes.Value = y;
					projet.Init();
				}
				catch (Exception ex) {
					ShowException(ex);
				}
				file.Close();
			}
			SetEtatBp(true);
		}

		private void bpSave_Click(object sender, EventArgs e) {
			SetEtatBp(false);
			SaveFileDialog dlg = new SaveFileDialog();
			dlg.Filter = "Projet PJA (*.xml)|*.xml";
			DialogResult result = dlg.ShowDialog();
			if (result == DialogResult.OK) {
				FileStream file = File.Open(dlg.FileName, FileMode.Create);
				try {
					new XmlSerializer(typeof(Projet)).Serialize(file, projet);
					nomProjet.Text = Path.GetFileName(dlg.FileName);
				}
				catch (Exception ex) {
					ShowException(ex);
				}
				file.Close();
			}
			SetEtatBp(true);
		}

		private void bpRepack_Click(object sender, EventArgs e) {
			SetEtatBp(false);
			projet.ImageData.Repack();
			SetEtatBp(true);
		}

		private void button1_Click(object sender, EventArgs e) {
			GestDsk d = new GestDsk(projet);
			d.WriteZones();
			d.WriteImages();
		}
	}
}
