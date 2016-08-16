using System;
using System.Windows.Forms;

namespace PJA {
	public partial class EditTC : Form {
		private Projet proj;
		private Map map;
		private TraitementConditionnel curTC = new TraitementConditionnel();

		public Cond[] tabCond = new Cond[9] {
			new Cond("Toujours", 0x00, 0x18),					// NOP		JR_E
			new Cond("[Variable] == [Constante]", 0xFE,0x28),		// CP_N		JR_Z
			new Cond("[Variable] != [Constante]", 0xFE,0x20),		// CP_N		JR_NZ
			new Cond("[Variable] >= [Constante]", 0xFE,0x30),		// CP_N		JR_NC
			new Cond("[Variable] < [Constante]", 0xFE,0x38),		// CP_N		JR_C
			new Cond("[Variable] | [Constante] == 0", 0xF6,0x28),	// OR_N		JR_Z
			new Cond("[Variable] | [Constante] != 0", 0xF6,0x20),	// OR_N		JR_NZ
			new Cond("[Variable] & [Constante] == 0", 0xE6,0x28),	// AND_N	JR_Z
			new Cond("[Variable] & [Constante] != 0", 0xE6,0x20)	// AND_N	JR_NZ
		};

		public EditTC(Projet p, Map m) {
			map = m;
			proj = p;
			InitializeComponent();
			foreach (Variable v in p.VariableData.LstVar)
				comboVar.Items.Add(v);

			foreach (Cond c in tabCond)
				comboCdt.Items.Add(c.ToString());

			foreach (Action.TypeAction a in Enum.GetValues(typeof(Action.TypeAction)))
				comboAct.Items.Add(a);
		}

		private void bpAdd_Click(object sender, EventArgs e) {

		}

		private void bpEdit_Click(object sender, EventArgs e) {
		}

		private void bpDel_Click(object sender, EventArgs e) {
		}

		private void listTC_SelectedIndexChanged(object sender, EventArgs e) {
		}

		private void ChangeConditions() {
			comboCdt.SelectedItem = null;
			Variable v = (Variable)comboVar.SelectedItem;
			comboCdt.Items.Clear();
			foreach (Cond c in tabCond) {
				string s = v != null ? c.ToString().Replace("[Variable]", v.ToString()) : c.ToString();
				if (textCste.Text != "")
					s = s.Replace("[Constante]", textCste.Text);

				comboCdt.Items.Add(s);
			}
		}
		private void textCste_TextChanged(object sender, EventArgs e) {
			ChangeConditions();
		}

		private void comboVar_SelectedIndexChanged(object sender, EventArgs e) {
			ChangeConditions();
		}

		private void comboAct_SelectedIndexChanged(object sender, EventArgs e) {

		}
	}
}

