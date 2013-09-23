using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class Vue {
		private byte numVue; // Numéro de vue
		public byte NumVue {
			get { return numVue; }
			set { numVue = value; }
		}
		private string libelle = "";
		public string Libelle {
			get { return libelle; }
			set { libelle = value; }
		}
		private int indexImage; // numéro d'image
		public int IndexImage {
			get { return indexImage; }
			set { indexImage = value; }
		}
		private List<Zone> lstZone = new List<Zone>();
		public List<Zone> LstZone {
			get { return lstZone; }
			set { lstZone = value; }
		}

		public Vue() {
		}

		public Vue(byte num, string lbl, int img) {
			numVue = num;
			libelle = lbl;
			indexImage = img;
		}

		public override string ToString() {
			return libelle;
		}
	}
}
