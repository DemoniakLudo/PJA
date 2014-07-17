using System;
using System.Collections.Generic;

namespace PJA{
	[Serializable]
	public class DataTexte {
		public List<Texte> LstTxt = new List<Texte>();
		public int indexTxt = 0;

		public DataTexte() {
		}

		public void AddTexte(string msg) {
			LstTxt.Add(new Texte(msg, indexTxt++));
		}

		public Texte GetTexte(int index) {
			foreach (Texte t in LstTxt)
				if (t.index == index)
					return t;

			return null;
		}
	}
}
