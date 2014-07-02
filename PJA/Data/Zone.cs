using System;

namespace PJA {
	[Serializable]
	public class Zone {
		public enum TypeZone {
			RIEN = 0,				// Zone définie mais ne modifiant pas le curseur => type de zone qui peut être modifiée ultérieurement
			RECHERCHE,				// Zone définissant un curseur de type "loupe"
			DEPLACEMENT,			// Zone définissant un curseur de type "bonhomme", et dirigeant vers un autre lieu
			ACTION,					// Zone définissant un curseur de type "main"
			ACTION_CACHEE			// ????
		};
		public int xd, yd, xa, ya; // Coordonnées de la zone
		public TypeZone typeZone;
		public int varAction; // Variable en fonction du type de zone (si deplacement=index lieu...)

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
