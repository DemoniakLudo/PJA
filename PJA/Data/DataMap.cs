using System;
using System.IO;

namespace PJA {
	[Serializable]
	public class DataMap {
		public const int TAILLE_X = 32;
		public const int TAILLE_Y = 32;
		public const int TAILLE_Z = 10;
		public const int MAX_LIEU = 220;
		public const int MAX_CASES = 250;
		private Map[] tabMap = new Map[TAILLE_X * TAILLE_Y * TAILLE_Z];
		public byte[] caseLibre = new byte[MAX_CASES];
		public enum Cnx { NULL = 0, HAUT = 1, BAS = 2, NORD = 4, SUD = 8, EST = 16, OUEST = 32 };
		private bool modif;
		public bool Modif { get { return modif; } }
		private int xStart, yStart, nStart;
		private int xGoal, yGoal, nGoal;
		private int niveau = 0;
		public int Niveau {
			get { return niveau; }
			set { niveau = value; }
		}
		private int nbSalles = 0;
		public int NbSalles {
			get {
				GetCaseLibre();
				return nbSalles;
			}
		}
		private int curSalle = 0;
		public int CurSalle { get { return curSalle; } }

		public DataMap() {
			Init();
		}

		private void Init() {
			SetGoal(-1, -1, -1);
			SetStart(-1, -1, -1);
			for (int pos = 0; pos < tabMap.Length; pos++) {
				tabMap[pos] = new Map();
				tabMap[pos].Nord =
				tabMap[pos].Sud =
				tabMap[pos].Est =
				tabMap[pos].Ouest =
				tabMap[pos].Haut =
				tabMap[pos].Bas =
				tabMap[pos].NumCase = 255;
				tabMap[pos].TypeMap = Map.TypeCase.CASE_VIDE;
			}
		}

		public Map GetMap(int x, int y) {
			return tabMap[x + y * TAILLE_Y + niveau * TAILLE_Y * TAILLE_Z];
		}

		public Map GetMap(int x, int y, int n) {
			return tabMap[x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z];
		}

		public Map[] TabMap {
			get {
				modif = true;
				return tabMap;
			}
			set { tabMap = value; }
		}

		private void SetGoal(int x, int y, int n) {
			xGoal = x;
			yGoal = y;
			nGoal = n;
		}

		private void SetStart(int x, int y, int n) {
			xStart = x;
			yStart = y;
			nStart = n;
		}

		private void SetCase(int x, int y, int n, Map.TypeCase valeur, Cnx autoCnx) {
			if (x >= 0 && x < TAILLE_X && y >= 0 && y < TAILLE_X && n >= 0 && n < TAILLE_Z) {
				if (tabMap[x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].TypeMap != valeur) {
					switch (valeur) {
						case Map.TypeCase.CASE_PLEINE:
						case Map.TypeCase.CASE_DEPART:
						case Map.TypeCase.CASE_ARRIVEE:
							Connect(x, y, n, autoCnx, valeur);

							break;

						case Map.TypeCase.CASE_VIDE:
							Deconnect(x, y, n, valeur);
							break;
					}
				}
			}
		}

		private byte GetCaseLibre() {
			nbSalles = 0;
			for (int i = 0; i < MAX_LIEU; i++)
				if (caseLibre[i] != 0)
					nbSalles++;

			for (curSalle = 0; curSalle < MAX_LIEU; curSalle++)
				if (caseLibre[curSalle] == 0)
					return (byte)curSalle;

			return 255;
		}

		private void Connect(int x, int y, int n, Cnx autoCnx, Map.TypeCase valeur) {
			byte c = GetCaseLibre();
			if (c != 255) {
				int pos = x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z;
				tabMap[pos].NumCase = c;
				TabMap[pos].TypeMap = valeur;
				caseLibre[c] = 1;

				// Connecte la salle en Bas
				if (n > 0 && (autoCnx & Cnx.BAS) == Cnx.BAS) {
					if (tabMap[pos - TAILLE_Y * TAILLE_Z].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[pos - TAILLE_Y * TAILLE_Z].Haut = c;
						TabMap[pos].Bas = tabMap[pos - TAILLE_Y * TAILLE_Z].NumCase;
					}
				}

				// Connecte la salle en Haut
				if (n < TAILLE_Z - 1 && (autoCnx & Cnx.HAUT) == Cnx.HAUT) {
					if (tabMap[pos + TAILLE_Y * TAILLE_Z].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[pos + TAILLE_Y * TAILLE_Z].Bas = c;
						TabMap[pos].Haut = tabMap[pos + TAILLE_Y * TAILLE_Z].NumCase;
					}
				}

				// Connecte la salle au Nord
				if (y > 0 && (autoCnx & Cnx.NORD) == Cnx.NORD) {
					if (tabMap[pos - TAILLE_Y].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[pos - TAILLE_Y].Sud = c;
						TabMap[pos].Nord = tabMap[pos - TAILLE_Y].NumCase;
					}
				}

				// Connecte la salle au Sud
				if (y < TAILLE_Y - 1 && (autoCnx & Cnx.SUD) == Cnx.SUD) {
					if (tabMap[pos + TAILLE_Y].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[pos + TAILLE_Y].Nord = c;
						TabMap[pos].Sud = tabMap[pos + TAILLE_Y].NumCase;
					}
				}

				// Connecte la salle à l'Est
				if (x < TAILLE_X - 1 && (autoCnx & Cnx.EST) == Cnx.EST) {
					if (tabMap[pos + 1].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[pos + 1].Ouest = c;
						TabMap[pos].Est = tabMap[pos + 1].NumCase;
					}
				}

				// Connecte la salle à l'Ouest
				if (x > 0 && (autoCnx & Cnx.OUEST) == Cnx.OUEST) {
					if (tabMap[x - 1 + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].TypeMap != Map.TypeCase.CASE_VIDE) {
						TabMap[x - 1 + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].Est = c;
						TabMap[pos].Ouest = tabMap[x - 1 + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].NumCase;
					}
				}
			}
		}

		private void Deconnect(int x, int y, int n, Map.TypeCase valeur) {
			int pos = x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z;
			caseLibre[tabMap[pos].NumCase] = 0;
			TabMap[pos].TypeMap = valeur;

			// Déconnecte la salle en Bas
			if (n > 0)
				TabMap[pos - TAILLE_Y * TAILLE_Z].Haut = 255;

			// Déconnecte la salle en Haut
			if (n < TAILLE_Z)
				TabMap[pos + TAILLE_Y * TAILLE_Z].Bas = 255;

			// Déconnecte la salle au Nord
			if (y > 0)
				TabMap[pos - TAILLE_Y].Sud = 255;

			// Déconnecte la salle au Sud
			if (y < TAILLE_Y - 1)
				TabMap[pos + TAILLE_Y].Nord = 255;

			// Déconnecte la salle à l'Est
			if (x < TAILLE_X - 1)
				TabMap[pos + 1].Ouest = 255;

			// Déconnecte la salle à l'Ouest
			if (x > 0)
				TabMap[pos - 1].Est = 255;
		}

		public void ModifCase(int xPos, int yPos, Map.TypeCase type, Cnx autoCnx) {
			Map m = tabMap[xPos + yPos * TAILLE_Y + niveau * TAILLE_Y * TAILLE_Z];
			switch (type) {
				case Map.TypeCase.CASE_PLEINE:
					// Ajoute une salle
					if (!(xPos == xStart && yPos == yStart && niveau == nStart) && !(xPos == xGoal && yPos == yGoal && niveau == nGoal))
						SetCase(xPos, yPos, niveau, Map.TypeCase.CASE_PLEINE, autoCnx);
					break;

				case Map.TypeCase.CASE_DEPART:
					// Positionne la salle de départ
					if (m.TypeMap != Map.TypeCase.CASE_PLEINE && (xPos != xGoal || yPos != yGoal || niveau != nGoal)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xStart, yStart, nStart, Map.TypeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, niveau, Map.TypeCase.CASE_DEPART, autoCnx);
						SetStart(xPos, yPos, niveau);
					}
					break;

				case Map.TypeCase.CASE_ARRIVEE:
					// Positonne la salle d'arrivée
					if (m.TypeMap != Map.TypeCase.CASE_PLEINE && (xPos != xStart || yPos != yStart || niveau != nStart)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xGoal, yGoal, nGoal, Map.TypeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, niveau, Map.TypeCase.CASE_ARRIVEE, autoCnx);
						SetGoal(xPos, yPos, niveau);
					}
					break;

				case Map.TypeCase.CASE_VIDE:
					// Supprime une salle
					if (xPos == xStart & yPos == yStart && niveau == nStart)
						SetStart(-1, -1, -1);

					if (xPos == xGoal && yPos == yGoal && niveau == nGoal)
						SetGoal(-1, -1, -1);

					SetCase(xPos, yPos, niveau, Map.TypeCase.CASE_VIDE, autoCnx);
					break;
			}
		}

		public bool RechercheSalle(int numSalle, ref int x, ref int y, ref int n) {
			if (numSalle >= 0 && numSalle < DataMap.MAX_LIEU) {
				if (caseLibre[numSalle] > 0) {
					for (n = 0; n < DataMap.TAILLE_Z; n++) {
						for (y = 0; y < DataMap.TAILLE_Y; y++) {
							for (x = 0; x < DataMap.TAILLE_X; x++) {
								Map m = GetMap(x, y, n);
								if (m.NumCase == numSalle && m.TypeMap != Map.TypeCase.CASE_VIDE)
									return true;
							}
						}
					}
				}
			}
			return false;
		}

		public  bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line != null) {
				if (line.StartsWith("#MAP_NB_CASES")) {
					int nb = int.Parse(line.Substring(14));
					Init();
					for (; nb-- > 0; ) {
						line = rd.ReadLine();
						if (line.StartsWith("#MAP_COORD")) {
							int p = line.IndexOf(';');
							if (p > 0) {
								int n = int.Parse(line.Substring(11, p - 11));
								line = line.Substring(p + 1);
								p = line.IndexOf(';');
								if (p > 0) {
									int x = int.Parse(line.Substring(0, p));
									line = line.Substring(p + 1);
									int y = int.Parse(line);
									if (!tabMap[x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].Load(rd))
										return false;
									else
										caseLibre[tabMap[x+ y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].NumCase] = 1;
								}
								else
									return false;
							}
							else
								return false;
						}
						else return false;
					}
					return true;
				}
				else
					return false;
			}
			return false;
		}

		public  bool Save(StreamWriter wr) {
			wr.WriteLine("#MAP_NB_CASES\t" + nbSalles);
			for (int n = 0; n < TAILLE_Z; n++)
				for (int y = 0; y < TAILLE_Y; y++)
					for (int x = 0; x < TAILLE_X; x++)
						if (tabMap[x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].TypeMap != Map.TypeCase.CASE_VIDE) {
							wr.WriteLine("#MAP_COORD\t" + n + ";" + x + ";" + y);
							if (!tabMap[x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z].Save(wr))
								return false;
						}
			return true;
		}
	}
}
