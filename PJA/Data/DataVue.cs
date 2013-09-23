using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataVue {
		private List<Vue> listVue = new List<Vue>();
		public List<Vue> ListVue {
			get { return listVue; }
			set { listVue = value; }
		}
	}
}



