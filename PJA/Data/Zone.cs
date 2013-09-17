using System.IO;

namespace PJA {
	class Zone: BaseData {
		public enum TypeZone { DEP_NORD, DEP_SUD, DEP_EST, DEP_OUEST, DEP_HAUT, DEP_BAS, RECHERCHE, ACTION, ACTION_CACHEE };
		public int xd, yd, xa, ya; // Coordonnées de la zone
		public TypeZone typeZone;

		public Zone() {
		}

		public Zone(StreamReader rd) {
			Load(rd);
		}

		public override bool Load(StreamReader rd) {
			throw new System.NotImplementedException();
		}

		public override bool Save(StreamWriter wr) {
			throw new System.NotImplementedException();
		}
	}
}
