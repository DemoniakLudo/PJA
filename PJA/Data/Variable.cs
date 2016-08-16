using System;

namespace PJA {
	[Serializable]
	public class Variable {
		public string libelle;
		public int index;
		public int valeur;

		public Variable() {
		}

		public Variable(string l, int i, int v) {
			libelle = l;
			index = i;
			valeur = v;
		}

		public override string ToString() {
			return libelle;
		}
	}
}
