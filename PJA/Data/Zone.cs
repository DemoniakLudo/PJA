using System.IO;

namespace PJA {
	public class Zone: BaseData {
		public enum TypeZone { DEP_NORD, DEP_SUD, DEP_EST, DEP_OUEST, DEP_HAUT, DEP_BAS, RECHERCHE, ACTION, ACTION_CACHEE };
		public int xd, yd, xa, ya; // Coordonnées de la zone
		public TypeZone typeZone;

		public bool IsZone { get { return xd != xa && yd != ya; } }

		public Zone(int x, int y) {
			xd = x;
			yd = y;
		}

		public Zone(StreamReader rd) {
			Load(rd);
		}

		public override bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line.StartsWith("#ZONE_TYPE")) {
				typeZone = (TypeZone)int.Parse(line.Substring(11));
				line = rd.ReadLine();
				if (line.StartsWith("#ZONE_XD")) {
					xd = int.Parse(line.Substring(9));
					line = rd.ReadLine();
					if (line.StartsWith("#ZONE_YD")) {
						yd = int.Parse(line.Substring(9));
						line = rd.ReadLine();
						if (line.StartsWith("#ZONE_XA")) {
							xa = int.Parse(line.Substring(9));
							line = rd.ReadLine();
							if (line.StartsWith("#ZONE_YA")) {
								ya = int.Parse(line.Substring(9));
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#ZONE_TYPE\t" + ((int)typeZone).ToString());
			wr.WriteLine("#ZONE_XD\t" + xd);
			wr.WriteLine("#ZONE_YD\t" + yd);
			wr.WriteLine("#ZONE_XA\t" + xa);
			wr.WriteLine("#ZONE_YA\t" + ya);
			return true;
		}

		public override string ToString() {
			return "Zone type " + typeZone.ToString();
		}
	}
}
