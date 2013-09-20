using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PJA {
	public partial class PredefPal: Form {
		private List<Palette> lstPal;
		private int[] palette;
		public Palette selPal = null;
		public PredefPal(List<Palette> lst, int[] p) {
			InitializeComponent();
			lstPal = lst;
			palette = p;
			UpdateListe(-1);
		}

		private void UpdateListe(int pos) {
			listPal.BeginUpdate();
			listPal.Items.Clear();
			foreach (Palette pal in lstPal)
				listPal.Items.Add(pal);

			listPal.EndUpdate();
			if (pos != -1)
				listPal.SelectedIndex = pos;
			else
				paletteName.Text = "";
		}

		private void bpAdd_Click(object sender, EventArgs e) {
			if (paletteName.Text.Length > 0) {
				if (lstPal.Find(delegate(Palette p) { return p.Nom == paletteName.Text; }) == null) {
					lstPal.Add(new Palette(paletteName.Text, palette));
					UpdateListe(listPal.Items.Count);
				}
			}
		}

		private void bpSuppr_Click(object sender, EventArgs e) {
			Palette pal = listPal.SelectedItem as Palette;
			if (pal != null && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette palette", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				lstPal.Remove(pal);
				UpdateListe(-1);
			}
		}

		private void bpUse_Click(object sender, EventArgs e) {
			Palette pal = listPal.SelectedItem as Palette;
			if (pal != null) {
				selPal = pal;
				Close();
			}
		}

		private void listPal_DoubleClick(object sender, EventArgs e) {
			bpUse_Click(null, null);
		}
	}
}
