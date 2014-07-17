using System;
using System.Windows.Forms;

namespace PJA {
	public partial class SelectTexte: Form {
		private Action action;
		private Projet projet;
		public bool Valid = false;

		public SelectTexte(Projet p, Action a) {
			action = a;
			projet = p;
			InitializeComponent();
			MajListeTexte();
			Valid = true;
			bpAnnule.Visible = action != null;
			if (action != null)
				listTexte.SelectedItem = projet.TexteData.GetTexte(action.varAction);
		}

		private void MajListeTexte() {
			listTexte.Items.Clear();
			foreach (Texte t in projet.TexteData.LstTxt)
				listTexte.Items.Add(t);
		}

		private void bpValide_Click(object sender, EventArgs e) {
			if (action != null) {
				Texte t = (Texte)listTexte.SelectedItem;
				action.varAction = t.index;
			}
			Close();
		}

		private void bpAnnule_Click(object sender, EventArgs e) {
			Close();
		}

		private void nouvTexte_TextChanged(object sender, EventArgs e) {
			bpAddTexte.Enabled = nouvTexte.Text.Length > 0;
		}

		private void listTexte_SelectedIndexChanged(object sender, EventArgs e) {
			Texte t = (Texte)listTexte.SelectedItem;
			bpDelTexte.Enabled = bpEditTexte.Enabled = t != null;
			bpAnnule.Enabled = action == null || t != null;
			if (t != null)
				nouvTexte.Text = t.message;
		}

		private void bpAddTexte_Click(object sender, EventArgs e) {
			projet.TexteData.AddTexte(nouvTexte.Text);
			MajListeTexte();
		}

		private void bpEditTexte_Click(object sender, EventArgs e) {
			Texte t = (Texte)listTexte.SelectedItem;
			t.message = nouvTexte.Text;
			MajListeTexte();
		}

		private void bpDelTexte_Click(object sender, EventArgs e) {
			Texte t = (Texte)listTexte.SelectedItem;
			projet.TexteData.LstTxt.Remove(t);
			MajListeTexte();
		}

		private void SelectTexte_FormClosed(object sender, FormClosedEventArgs e) {
			Valid = false;
		}
	}
}
