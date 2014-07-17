namespace PJA {
	public class Action {
		public enum TypeAction {
			RIEN = 0,				// Action non définie
			AFF_MSG,				// Affichage d'un message
			PRISE_OBJ,				// Prise d'un objet
			DEPLACEMENT,			// Déplacement vers une salle
			MODIF_TYPE_ZONE,		// Modification du type de zone
		};
		public TypeAction typeAction;
		public int varAction; // Variable en fonction du type de d'action

		public Action() {
		}

		public override string ToString() {
			return "Action:" + typeAction.ToString();
		}
	}
}
