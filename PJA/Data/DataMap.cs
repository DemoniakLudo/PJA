using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataMap {
		private List<Map> listMap = new List<Map>();
		public List<Map> ListMap {
			get {
				modif = true;
				return listMap;
			}
			set { listMap = value; }
		}
		private bool modif;
		public bool Modif { get { return modif; } }
		public int NbSalles { get { return listMap.Count; } }
		private int curSalle = 0;
		public int CurSalle { get { return curSalle; } }

		public DataMap() {
		}

		public void Init() {
		}
	}
}
