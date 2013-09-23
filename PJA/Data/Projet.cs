using System;

namespace PJA {
	[Serializable]
	public class Projet {
		private int mode;
		public int Mode {
			get { return mode; }
			set {
				if (mode != value) {
					mode = value;
					modif = true;
				}
			}
		}
		private int cx;
		public int Cx {
			get { return cx; }
			set {
				if (cx != value) {
					cx = value;
					modif = true;
				}
			}
		}
		private int cy;
		public int Cy {
			get { return cy; }
			set {
				if (cy != value) {
					cy = value;
					modif = true;
				}
			}
		}
		private DataMap dataMap;
		public DataMap MapData {
			get { return dataMap; }
			set { dataMap = value; }
		}
		private DataImage dataImage;
		public DataImage ImageData {
			get { return dataImage; }
			set { dataImage = value; }
		}
		private bool modif;
		public bool Modif { get { return modif | dataMap.Modif | dataImage.Modif; } }

		public Projet() {
			New();
		}

		//
		// Nouveau projet
		//
		public void New() {
			// Résolution "standard"
			mode = 1;
			cx = 80;
			cy = 25;

			// Réinitialisation variables
			dataMap = new DataMap();
			dataImage = new DataImage();
		}

		public void Init() {
			dataMap.Init();
			dataImage.Init();
		}
	}
}
