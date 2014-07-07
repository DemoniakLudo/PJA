namespace PJA {
	public class Action {
		public enum TypeAction {
			RIEN = 0,				// Action à définir
			AFF_MSG,				// Action affichant un message
			PRISE_OBJ,				// Action prenant un objet
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
