using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataVariable {
		public List<Variable> LstVar = new List<Variable>();
		public int indexVar = 0;

		public DataVariable() {
		}

		public void AddVariable(string msg, int val) {
			LstVar.Add(new Variable(msg, indexVar++,val));
		}

		public Variable GetTexte(int index) {
			foreach (Variable t in LstVar)
				if (t.index == index)
					return t;

			return null;
		}
	}
}
