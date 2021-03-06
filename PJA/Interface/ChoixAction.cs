﻿using System;
using System.Windows.Forms;

namespace PJA {
	public partial class ChoixAction: Form {
		private Projet projet;
		private Action actSel = new Action();
		public Action ActSel { get { return actSel; } }
		private Zone curZone;

		public ChoixAction(Projet prj, Zone z) {
			InitializeComponent();
			projet = prj;
			curZone = z;
			typeAction.DataSource = Enum.GetValues(typeof(Action.TypeAction));
			AfficheActions();
		}

		private void AfficheActions() {
			listAction.Items.Clear();
			foreach (Action a in curZone.lstAction)
				listAction.Items.Add(a);
		}

		private void EditAction(Action.TypeAction t) {
			switch (t) {
				case Action.TypeAction.RIEN:
					break;

				case Action.TypeAction.AFF_MSG:
					SelectTexte st = new SelectTexte(projet, actSel);
					st.ShowDialog();
					break;

				case Action.TypeAction.PRISE_OBJ:
					break;

				case Action.TypeAction.DEPLACEMENT:
					break;

				case Action.TypeAction.MODIF_TYPE_ZONE:
					break;
			}
			actSel.typeAction = t;
			AfficheActions();
		}

		private void typeAction_SelectedIndexChanged(object sender, EventArgs e) {
			Action.TypeAction t = (Action.TypeAction)typeAction.SelectedItem;
			if (t != actSel.typeAction)
				EditAction(t);
		}

		private void bpAddAction_Click(object sender, EventArgs e) {
			actSel.typeAction = (Action.TypeAction)typeAction.SelectedItem;
			switch (actSel.typeAction) {
				case Action.TypeAction.RIEN:
					break;

				case Action.TypeAction.AFF_MSG:
					SelectTexte st = new SelectTexte(projet, actSel);
					st.ShowDialog();
					break;

				case Action.TypeAction.PRISE_OBJ:
					break;

				case Action.TypeAction.DEPLACEMENT:
					break;

				case Action.TypeAction.MODIF_TYPE_ZONE:
					break;
			}
			curZone.lstAction.Add(actSel);
			AfficheActions();
		}

		private void bpEditAction_Click(object sender, EventArgs e) {
			EditAction((Action.TypeAction)typeAction.SelectedItem);
		}

		private void bpDelAction_Click(object sender, EventArgs e) {
			if (MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette action", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curZone.lstAction.Remove(actSel);
				AfficheActions();
			}
		}

		private void bpValide_Click(object sender, EventArgs e) {
			Close();
		}

		private void listAction_SelectedIndexChanged(object sender, EventArgs e) {
			actSel = (Action)listAction.SelectedItem;
			if (actSel != null) {
				typeAction.SelectedItem = actSel.typeAction;
				bpEditAction.Enabled = bpDelAction.Enabled = true;
			}
		}
	}
}
