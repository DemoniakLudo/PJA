using System;

namespace PJA {
	[Serializable]
	public class Zone {
		public enum TypeZone { DEPLACEMENT, RECHERCHE, ACTION, ACTION_CACHEE };
		public int xd, yd, xa, ya; // Coordonnées de la zone
		public TypeZone typeZone;

		public bool IsZone { get { return xd != xa && yd != ya; } }

		public Zone() {
		}

		public Zone(int x, int y) {
			xd = x;
			yd = y;
		}

		public override string ToString() {
			return "Zone:" + typeZone.ToString();
		}
	}
}
