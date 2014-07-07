using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PJA.Interface {
	public partial class SelectTexte: Form {
		public SelectTexte() {
			InitializeComponent();
		}

		private void bpValide_Click(object sender, EventArgs e) {
			Close();
		}

		private void bpAnnule_Click(object sender, EventArgs e) {
			Close();
		}

		private void nouvTexte_TextChanged(object sender, EventArgs e) {
			bpAddTexte.Enabled = bpDelTexte.Enabled = bpEditTexte.Enabled = nouvTexte.Text.Length > 0;
		}
	}
}
