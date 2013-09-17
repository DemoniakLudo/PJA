using System.IO;

namespace PJA {
	public class Projet {
		private DataMap dataMap;
		public DataMap MapData {
			get { return dataMap; }
		}
		private DataImage dataImage;
		public DataImage ImageData {
			get { return dataImage; }
		}
		private DataVue dataVue;
		public DataVue VueData {
			get { return dataVue; }
		}
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
			dataVue = new DataVue();
		}

		//
		// Chargement projet
		//
		public bool Load(string name) {
			bool ret = false;
			StreamReader rd = new StreamReader(name);
			string line = rd.ReadLine();
			if (line != null) {
				if (line.StartsWith("#PROJET_MODE")) {
					mode = int.Parse(line.Substring(13));
					line = rd.ReadLine();
					if (line.StartsWith("#PROJET_RESO_X")) {
						cx = int.Parse(line.Substring(15));
						line = rd.ReadLine();
						if (line.StartsWith("#PROJET_RESO_Y")) {
							cy = int.Parse(line.Substring(15));
							ret = dataMap.Load(rd) && dataImage.Load(rd) && dataVue.Load(rd);
						}
					}
				}
			}
			rd.Close();
			return ret;
		}

		//
		// Lecture projet
		//
		public bool Save(string name) {
			StreamWriter wr = new StreamWriter(name);
			wr.WriteLine("#PROJET_MODE\t" + mode);
			wr.WriteLine("#PROJET_RESO_X\t" + cx);
			wr.WriteLine("#PROJET_RESO_Y\t" + cy);
			bool ret = dataMap.Save(wr) && dataImage.Save(wr) && dataVue.Save(wr);
			wr.Close();
			return ret;
		}
	}
}
