namespace PJA {
	public class Action {
		public enum TypeAction {
			RIEN = 0,				// Action non définie
			AFF_MSG,				// Affichage d'un message
			PRISE_OBJ,				// Prise d'un objet
			DEPLACEMENT,			// Déplacement vers une salle
			MODIF_TYPE_ZONE,		// Modification du type de zone
			AFFECTE_VAR,			// Affectation de variable
			INC_VAR,				// Incrémente variable
			DEC_VAR,				// Décrémente variable
			INPUT_KBD,				// Saisie clavier
			DISP_OBJ,				// Objet disparaît de l'inventaire
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
