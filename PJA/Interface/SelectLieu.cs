using System;
using System.Windows.Forms;

namespace PJA {
	public partial class SelectLieu: Form {
		private int mapSel = -1;
		public int MapSel { get { return mapSel; } }

		public SelectLieu(Projet prj, int indexSel) {
			InitializeComponent();
			foreach (Map m in prj.MapData.ListMap)
				listLieu.Items.Add(m);

			listLieu.SelectedIndex = indexSel;
		}

		private void listLieu_SelectedIndexChanged(object sender, EventArgs e) {
			mapSel = listLieu.SelectedIndex;
		}

		private void bpAnnule_Click(object sender, EventArgs e) {
			mapSel = -1;
			Close();
		}

		private void bpValide_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
