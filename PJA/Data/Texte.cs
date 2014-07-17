using System;

namespace PJA{
	[Serializable]
	public class Texte {
		public string message;
		public int index;

		public Texte() {
		}

		public Texte(string msg, int i) {
			message = msg;
			index = i;
		}

		public override string ToString() {
			return "<" + index + ">" + message;
		}
	}
}
