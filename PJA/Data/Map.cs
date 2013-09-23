using System;
using System.IO;

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

		public bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line.StartsWith("#MAP_TYPE")) {
				typeMap = (TypeCase)int.Parse(line.Substring(10));
				line = rd.ReadLine();
				if (line.StartsWith("#MAP_NUM")) {
					numCase = byte.Parse(line.Substring(9));
					line = rd.ReadLine();
					if (line.StartsWith("#MAP_NORD")) {
						nord = byte.Parse(line.Substring(10));
						line = rd.ReadLine();
						if (line.StartsWith("#MAP_SUD")) {
							sud = byte.Parse(line.Substring(9));
							line = rd.ReadLine();
							if (line.StartsWith("#MAP_EST")) {
								est = byte.Parse(line.Substring(9));
								line = rd.ReadLine();
								if (line.StartsWith("#MAP_OUEST")) {
									ouest = byte.Parse(line.Substring(11));
									line = rd.ReadLine();
									if (line.StartsWith("#MAP_HAUT")) {
										haut = byte.Parse(line.Substring(10));
										line = rd.ReadLine();
										if (line.StartsWith("#MAP_BAS")) {
											bas = byte.Parse(line.Substring(9));
											line = rd.ReadLine();
											if (line.StartsWith("#MAP_NUMVUE")) {
												numVue = byte.Parse(line.Substring(12));
												line = rd.ReadLine();
												if (line.StartsWith("#MAP_VALDEF")) {
													valDef = byte.Parse(line.Substring(12));
													return true;
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
			return false;
		}

		public bool Save(StreamWriter wr) {
			wr.WriteLine("#MAP_TYPE\t" + ((int)typeMap).ToString());
			wr.WriteLine("#MAP_NUM\t" + numCase);
			wr.WriteLine("#MAP_NORD\t" + nord);
			wr.WriteLine("#MAP_SUD\t" + sud);
			wr.WriteLine("#MAP_EST\t" + est);
			wr.WriteLine("#MAP_OUEST\t" + ouest);
			wr.WriteLine("#MAP_HAUT\t" + haut);
			wr.WriteLine("#MAP_BAS\t" + bas);
			wr.WriteLine("#MAP_NUMVUE\t" + numVue);
			wr.WriteLine("#MAP_VALDEF\t" + valDef);
			return true;
		}
	}
}
