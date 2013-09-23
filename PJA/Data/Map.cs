using System;

namespace PJA {
	[Serializable]
	public class Map {
		public enum TypeCase { CASE_VIDE = 255, CASE_PLEINE = 1, CASE_DEPART, CASE_ARRIVEE, ERREUR };
		private TypeCase typeMap;			// type de salle
		public TypeCase TypeMap {
			get { return typeMap; }
			set { typeMap = value; }
		}
		private byte numCase;		// numéro de salle;
		public byte NumCase {
			get { return numCase; }
			set { numCase = value; }
		}
		private byte nord;			// quelle salle connectée au nord
		public byte Nord {
			get { return nord; }
			set { nord = value; }
		}
		private byte sud;			// quelle salle connectée au sud
		public byte Sud {
			get { return sud; }
			set { sud = value; }
		}
		private byte est;
		public byte Est {
			get { return est; }
			set { est = value; }
		}
		private byte ouest;
		public byte Ouest {
			get { return ouest; }
			set { ouest = value; }
		}
		private byte haut;
		public byte Haut {
			get { return haut; }
			set { haut = value; }
		}
		private byte bas;
		public byte Bas {
			get { return bas; }
			set { bas = value; }
		}
		private byte numVue;		// Numéro de vue à charger
		public byte NumVue {
			get { return numVue; }
			set { numVue = value; }
		}
		private byte valDef;		// valeur par défaut variable de salle
		public byte ValDef {
			get { return valDef; }
			set { valDef = value; }
		}
		private int x;
		public int X {
			get { return x; }
			set { x = value; }
		}
		private int y;
		public int Y {
			get { return y; }
			set { y = value; }
		}
		private int z;
		public int Z {
			get { return z; }
			set { z = value; }
		}

		public Map() {
		}

		public Map(int xx, int yy, int zz) {
			x = xx;
			y = yy;
			z = zz;
			nord = sud = est = ouest = haut = bas = numCase = 255;
			typeMap = TypeCase.CASE_VIDE;
		}
	}
}
