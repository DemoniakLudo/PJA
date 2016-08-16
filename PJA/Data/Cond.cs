namespace PJA {
	public class Cond {
		public string libelle;
		public int opcode1;
		public int opcode2;

		public Cond() {
		}

		public Cond(string l, int o1, int o2) {
			libelle = l;
			opcode1 = o1;
			opcode2 = o2;
		}

		public override string ToString() {
			return libelle;
		}
	}
}
