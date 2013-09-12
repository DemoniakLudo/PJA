using System.IO;

namespace PJA {
	public class DataMap: BaseData {
		public const int TAILLE_X = 32;
		public const int TAILLE_Y = 32;
		public const int TAILLE_Z = 10;
		public const int MAX_LIEU = 220;
		public const int MAX_CASES = 250;
		private Map[, ,] tabMap = new Map[TAILLE_X, TAILLE_Y, TAILLE_Z];
		public byte[] caseLibre = new byte[MAX_CASES];
		public enum typeCase { CASE_VIDE = 255, CASE_PLEINE = 1, CASE_DEPART, CASE_ARRIVEE, ERREUR };
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
		public int NbSalles { get { return nbSalles; } }
		private int curSalle = 0;
		public int CurSalle { get { return curSalle; } }

		public DataMap() {
			Init();
		}

		private void Init() {
			SetGoal(-1, -1, -1);
			SetStart(-1, -1, -1);
			for (int x = 0; x < TAILLE_X; x++)
				for (int y = 0; y < TAILLE_Y; y++)
					for (int z = 0; z < TAILLE_Z; z++) {
						tabMap[x, y, z] = new Map();
						tabMap[x, y, z].nord =
						tabMap[x, y, z].sud =
						tabMap[x, y, z].est =
						tabMap[x, y, z].ouest =
						tabMap[x, y, z].haut =
						tabMap[x, y, z].bas =
						tabMap[x, y, z].numCase = 255;
						tabMap[x, y, z].map = typeCase.CASE_VIDE;
					}
		}

		public Map GetMap(int x, int y) {
			return tabMap[x, y, niveau];
		}

		public Map GetMap(int x, int y, int n) {
			return tabMap[x, y, n];
		}

		public Map[, ,] TabMap {
			get {
				modif = true;
				return tabMap;
			}
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

		private void SetCase(int x, int y, int n, typeCase valeur, Cnx autoCnx) {
			if (x >= 0 && x < TAILLE_X && y >= 0 && y < TAILLE_X && n >= 0 && n < TAILLE_Z) {
				if (tabMap[x, y, n].map != valeur) {
					switch (valeur) {
						case typeCase.CASE_PLEINE:
						case typeCase.CASE_DEPART:
						case typeCase.CASE_ARRIVEE:
							Connect(x, y, n, autoCnx, valeur);

							break;

						case typeCase.CASE_VIDE:
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

		private void Connect(int x, int y, int n, Cnx autoCnx, typeCase valeur) {
			byte c = GetCaseLibre();
			if (c != 255) {
				tabMap[x, y, n].numCase = c;
				TabMap[x, y, n].map = valeur;
				caseLibre[c] = 1;

				// Connecte la salle en bas
				if (n > 0 && (autoCnx & Cnx.BAS) == Cnx.BAS) {
					if (tabMap[x, y, n - 1].map != typeCase.CASE_VIDE) {
						TabMap[x, y, n - 1].haut = c;
						TabMap[x, y, n].bas = tabMap[x, y, n - 1].numCase;
					}
				}

				// Connecte la salle en haut
				if (n < TAILLE_Z - 1 && (autoCnx & Cnx.HAUT) == Cnx.HAUT) {
					if (tabMap[x, y, n + 1].map != typeCase.CASE_VIDE) {
						TabMap[x, y, n + 1].bas = c;
						TabMap[x, y, n].haut = tabMap[x, y, n + 1].numCase;
					}
				}

				// Connecte la salle au nord
				if (y > 0 && (autoCnx & Cnx.NORD) == Cnx.NORD) {
					if (tabMap[x, y - 1, n].map != typeCase.CASE_VIDE) {
						TabMap[x, y - 1, n].sud = c;
						TabMap[x, y, n].nord = tabMap[x, y - 1, n].numCase;
					}
				}

				// Connecte la salle au sud
				if (y < TAILLE_Y - 1 && (autoCnx & Cnx.SUD) == Cnx.SUD) {
					if (tabMap[x, y + 1, n].map != typeCase.CASE_VIDE) {
						TabMap[x, y + 1, n].nord = c;
						TabMap[x, y, n].sud = tabMap[x, y + 1, n].numCase;
					}
				}

				// Connecte la salle à l'est
				if (x < TAILLE_X - 1 && (autoCnx & Cnx.EST) == Cnx.EST) {
					if (tabMap[x + 1, y, n].map != typeCase.CASE_VIDE) {
						TabMap[x + 1, y, n].ouest = c;
						TabMap[x, y, n].est = tabMap[x + 1, y, n].numCase;
					}
				}

				// Connecte la salle à l'ouest
				if (x > 0 && (autoCnx & Cnx.OUEST) == Cnx.OUEST) {
					if (tabMap[x - 1, y, n].map != typeCase.CASE_VIDE) {
						TabMap[x - 1, y, n].est = c;
						TabMap[x, y, n].ouest = tabMap[x - 1, y, n].numCase;
					}
				}
			}
		}

		private void Deconnect(int x, int y, int n, typeCase valeur) {
			caseLibre[tabMap[x, y, n].numCase] = 0;
			TabMap[x, y, n].map = valeur;

			// Déconnecte la salle en bas
			if (n > 0)
				TabMap[x, y, n - 1].haut = 255;

			// Déconnecte la salle en haut
			if (n < TAILLE_Z)
				TabMap[x, y, n + 1].bas = 255;

			// Déconnecte la salle au nord
			if (y > 0)
				TabMap[x, y - 1, n].sud = 255;

			// Déconnecte la salle au sud
			if (y < TAILLE_Y - 1)
				TabMap[x, y + 1, n].nord = 255;

			// Déconnecte la salle à l'est
			if (x < TAILLE_X - 1)
				TabMap[x + 1, y, n].ouest = 255;

			// Déconnecte la salle à l'ouest
			if (x > 0)
				TabMap[x - 1, y, n].est = 255;
		}

		public void ModifCase(int xPos, int yPos, typeCase type, Cnx autoCnx) {
			Map m = tabMap[xPos, yPos, niveau];
			switch (type) {
				case typeCase.CASE_PLEINE:
					// Ajoute une salle
					if (!(xPos == xStart && yPos == yStart && niveau == nStart) && !(xPos == xGoal && yPos == yGoal && niveau == nGoal))
						SetCase(xPos, yPos, niveau, typeCase.CASE_PLEINE, autoCnx);
					break;

				case typeCase.CASE_DEPART:
					// Positionne la salle de départ
					if (m.map != typeCase.CASE_PLEINE && (xPos != xGoal || yPos != yGoal || niveau != nGoal)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xStart, yStart, nStart, typeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, niveau, typeCase.CASE_DEPART, autoCnx);
						SetStart(xPos, yPos, niveau);
					}
					break;

				case typeCase.CASE_ARRIVEE:
					// Positonne la salle d'arrivée
					if (m.map != typeCase.CASE_PLEINE && (xPos != xStart || yPos != yStart || niveau != nStart)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xGoal, yGoal, nGoal, typeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, niveau, typeCase.CASE_ARRIVEE, autoCnx);
						SetGoal(xPos, yPos, niveau);
					}
					break;

				case typeCase.CASE_VIDE:
					// Supprime une salle
					if (xPos == xStart & yPos == yStart && niveau == nStart)
						SetStart(-1, -1, -1);

					if (xPos == xGoal && yPos == yGoal && niveau == nGoal)
						SetGoal(-1, -1, -1);

					SetCase(xPos, yPos, niveau, typeCase.CASE_VIDE, autoCnx);
					break;
			}
		}

		public override bool Load(StreamReader rd) {
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
									if (!tabMap[x, y, n].Load(rd))
										return false;
									else
										caseLibre[tabMap[x, y, n].numCase] = 1;
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

		public override bool Save(StreamWriter wr) {
			// Compter le nombre de cases utilisées
			GetCaseLibre();
			wr.WriteLine("#MAP_NB_CASES\t" + nbSalles);
			for (int n = 0; n < TAILLE_Z; n++)
				for (int y = 0; y < TAILLE_Y; y++)
					for (int x = 0; x < TAILLE_X; x++)
						if (tabMap[x, y, n].map != typeCase.CASE_VIDE) {
							wr.WriteLine("#MAP_COORD\t" + n + ";" + x + ";" + y);
							if (!tabMap[x, y, n].Save(wr))
								return false;
						}
			return true;
		}
	}
}
