using System.IO;

namespace PJA {
	public class Map: Data {
		public DataMap.typeCase map;			// type de salle
		public byte numCase;		// numéro de salle;
		public byte nord;			// quelle salle connectée au nord
		public byte sud;			// quelle salle connectée au sud
		public byte est;
		public byte ouest;
		public byte haut;
		public byte bas;
		public byte numVue;		// Numéro de vue à charger
		public byte valDef;		// valeur par défaut variable de salle

		public override bool Load(StreamReader rd) {
			string line;
			line = rd.ReadLine();
			if (line.StartsWith("#MAP_TYPE")) {
				map = (DataMap.typeCase)int.Parse(line.Substring(10));
				line = rd.ReadLine();
				if (line.StartsWith("#MAP_NUM")) {
					numCase = byte.Parse(line.Substring(9));
					line = rd.ReadLine();
					if (line.StartsWith("#MAP_NORD")) {
						nord = byte.Parse(line.Substring(10));
						line = rd.ReadLine();
						if (line.StartsWith("#MAP_SUD")) {
							sud= byte.Parse(line.Substring(9));
							line = rd.ReadLine();
							if (line.StartsWith("#MAP_EST")) {
								est= byte.Parse(line.Substring(9));
								line = rd.ReadLine();
								if (line.StartsWith("#MAP_OUEST")) {
									ouest= byte.Parse(line.Substring(11));
									line = rd.ReadLine();
									if (line.StartsWith("#MAP_HAUT")) {
										haut = byte.Parse(line.Substring(10));
										line = rd.ReadLine();
										if (line.StartsWith("#MAP_BAS")) {
											bas= byte.Parse(line.Substring(9));
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

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#MAP_TYPE\t" + ((int)map).ToString());
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
