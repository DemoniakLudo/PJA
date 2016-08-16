using System;
using System.Windows.Forms;

namespace PJA {
	public partial class AjouteZone: Form {
		private bool status = false;
		public bool Status { get { return status; } }
		public Zone.TypeZone TypeZone { get { return (Zone.TypeZone)typeZone.SelectedItem; } }

		public AjouteZone(Zone.TypeZone sel) {
			InitializeComponent();
			typeZone.DataSource = Enum.GetValues(typeof(Zone.TypeZone));
			typeZone.SelectedItem = sel;
		}

		private void typeZone_SelectedIndexChanged(object sender, EventArgs e) {

		}

		private void bpValide_Click(object sender, EventArgs e) {
			status = true;
			Close();
		}

		private void bpAnnule_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
