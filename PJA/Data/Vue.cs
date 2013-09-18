using System.Collections.Generic;
using System.IO;

namespace PJA {
	public class Vue: BaseData {
		public byte numVue; // Numéro de vue
		public string libelle = "";
		public int indexImage; // numéro d'image
		public List<Zone> lstZone = new List<Zone>();

		public Vue(byte num, string lbl , int img) {
			numVue = num;
			libelle = lbl;
			indexImage = img;
		}

		public Vue(StreamReader rd) {
			Load(rd);
		}

		public override bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line != null) {
				if (line.StartsWith("#VUE_NUMBER")) {
					numVue = byte.Parse(line.Substring(12));
					line = rd.ReadLine();
					if (line.StartsWith("#VUE_LIBELLE")) {
						libelle = line.Substring(13);
						line = rd.ReadLine();
						if (line.StartsWith("#VUE_IMG")) {
							indexImage = int.Parse(line.Substring(9));
							line = rd.ReadLine();
							if (line.StartsWith("#VUE_NB_ZONES")) {
								int nbz = int.Parse(line.Substring(14));
								for (; nbz-- > 0; )
									lstZone.Add(new Zone(rd));

								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#VUE_NUMBER\t" + numVue);
			wr.WriteLine("#VUE_LIBELLE\t" + libelle);
			wr.WriteLine("#VUE_IMG\t" + indexImage);
			wr.WriteLine("#VUE_NB_ZONES\t" + lstZone.Count);
			foreach (Zone z in lstZone)
				if (!z.Save(wr))
					return false;

			return true;
		}

		public override string ToString() {
			return libelle;
		}
	}
}
