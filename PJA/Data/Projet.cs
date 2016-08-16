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
		private DataMap mapData;
		public DataMap MapData {
			get { return mapData; }
			set { mapData = value; }
		}
		private DataImage imageData;
		public DataImage ImageData {
			get { return imageData; }
			set { imageData = value; }
		}
		private DataTexte texteData;
		public DataTexte TexteData {
			get { return texteData; }
			set { texteData = value; }
		}
		private DataVariable variableData;
		public DataVariable VariableData {
			get { return variableData; }
			set { variableData = value; }
		}
		private bool modif;
		public bool Modif { get { return modif | mapData.Modif | imageData.Modif; } }

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
			mapData = new DataMap();
			imageData = new DataImage();
			texteData = new DataTexte();
			variableData = new DataVariable();
		}

		public void Init() {
			mapData.Init();
			imageData.Init();
		}
	}
}
