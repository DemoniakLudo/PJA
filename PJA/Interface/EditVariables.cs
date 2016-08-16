using System;
using System.Windows.Forms;

namespace PJA {
	public partial class EditVariables : Form {
		private Variable selVar = null;
		private DataVariable dataVariable;
		public bool Valid = false;

		public EditVariables(Projet p) {
			InitializeComponent();
			dataVariable = p.VariableData;
			RefreshListVar();
			Valid = true;
		}

		private void RefreshListVar() {
			listVariables.Items.Clear();
			foreach (Variable v in dataVariable.LstVar) {
				ListViewItem i = new ListViewItem(new string[3] { v.index.ToString(), v.libelle, v.valeur.ToString() });
				i.Tag = v;
				listVariables.Items.Add(i);
			}
			selVar = null;
			SetBps();
		}

		private void SetBps() {
			bpAdd.Enabled = textLibelle.Text != "";
			bpEdit.Enabled = bpDel.Enabled = selVar != null && textLibelle.Text != "";
		}

		private void textLibelle_TextChanged(object sender, EventArgs e) {
			SetBps();
		}

		private void listVariables_SelectedIndexChanged(object sender, EventArgs e) {
			if (listVariables.SelectedItems.Count == 1) {
				ListViewItem i = listVariables.SelectedItems[0];
				selVar = (Variable)i.Tag;
				textLibelle.Text = selVar != null ? selVar.libelle : "";
				textValeur.Text = selVar != null ? selVar.valeur.ToString() : "";
			}
		}

		private void bpAdd_Click(object sender, EventArgs e) {
			if (textLibelle.Text != "") {
				if (dataVariable.LstVar.Find(v => v.libelle == textLibelle.Text) == null) {
					int val = 0;
					int.TryParse(textValeur.Text, out val);
					dataVariable.AddVariable(textLibelle.Text, val);
					RefreshListVar();
				}
				else
					MessageBox.Show("La variable " + textLibelle.Text + " existe déjà.");
			}
		}

		private void bpEdit_Click(object sender, EventArgs e) {
			if (selVar != null && textLibelle.Text != "") {
				if (dataVariable.LstVar.Find(v => v.libelle == textLibelle.Text && v.index != selVar.index) == null) {
					int val = 0;
					int.TryParse(textValeur.Text, out val);
					selVar.libelle = textLibelle.Text;
					selVar.valeur = val;
					RefreshListVar();
				}
				else
					MessageBox.Show("La variable " + textLibelle.Text + " existe déjà.");
			}
		}

		private void bpDel_Click(object sender, EventArgs e) {
			if (selVar != null && MessageBox.Show("Voulez-vous vraiment supprimer la variable " + textLibelle.Text + " ?", null, MessageBoxButtons.YesNo) == DialogResult.Yes) {
				dataVariable.LstVar.Remove(selVar);
				RefreshListVar();
			}
		}

		private void EditVariables_FormClosing(object sender, FormClosingEventArgs e) {
			Valid = false;
		}
	}
}
