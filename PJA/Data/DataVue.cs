using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataVue {
		private List<Vue> listVue = new List<Vue>();
		public List<Vue> ListVue {
			get {
				modif = true;
				return listVue;
			}
			set { listVue = value; }
		}
		private bool modif;
		public bool Modif { get { return modif; } }

		public void Init() {
		}
	}
}



