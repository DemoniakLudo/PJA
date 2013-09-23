using System;
using System.Collections.Generic;
using System.IO;

namespace PJA {
	[Serializable]
	public class DataVue {
		private List<Vue> listVue = new List<Vue>();
		public List<Vue> ListVue {
			get { return listVue; }
			set { listVue = value; }
		}

		public bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line != null && line.StartsWith("#VUE_NB")) {
				listVue.Clear();
				int nb = int.Parse(line.Substring(8));
				for (; nb-- > 0; )
					listVue.Add(new Vue(rd));

				return true;
			}
			return false;
		}

		public bool Save(StreamWriter wr) {
			wr.WriteLine("#VUE_NB\t" + listVue.Count);
			foreach (Vue v in listVue)
				if (!v.Save(wr))
					return false;

			return true;
		}
	}
}



