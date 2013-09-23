using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataMap {
		public const int TAILLE_X = 32;
		public const int TAILLE_Y = 32;
		public const int TAILLE_Z = 10;
		public const int MAX_LIEU = 220;
		public const int MAX_CASES = 250;
		private List<Map> tabMap = new List<Map>();
		public List<Map> TabMap {
			get {
				modif = true;
				return tabMap;
			}
			set { tabMap = value; }
		}
		private byte[] caseLibre = new byte[256];
		public enum Cnx { NULL = 0, HAUT = 1, BAS = 2, NORD = 4, SUD = 8, EST = 16, OUEST = 32 };
		private bool modif;
		public bool Modif { get { return modif; } }
		private int xStart, yStart, nStart;
		private int xGoal, yGoal, nGoal;
		public int NbSalles { get { return tabMap.Count; } }
		private int curSalle = 0;
		public int CurSalle { get { return curSalle; } }

		public DataMap() {
			Init();
		}

		private void Init() {
			SetGoal(-1, -1, -1);
			SetStart(-1, -1, -1);
		}

		public Map FindMap(int x, int y, int z, bool add) {
			Map map = tabMap.Find(m => m.X == x && m.Y == y && m.Z == z);
			if (map == null && add) {
				map = new Map(x, y, z);
				tabMap.Add(map);
			}
			return map;
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
				Map map = FindMap(x, y, n, valeur != Map.TypeCase.CASE_VIDE);
				if (map != null && map.TypeMap != valeur) {
					switch (valeur) {
						case Map.TypeCase.CASE_PLEINE:
						case Map.TypeCase.CASE_DEPART:
						case Map.TypeCase.CASE_ARRIVEE:
							Connect(map, x, y, n, autoCnx, valeur);
							break;

						case Map.TypeCase.CASE_VIDE:
							Deconnect(map, x, y, n);
							tabMap.Remove(map);
							break;
					}
				}
			}
		}

		private byte GetCaseLibre() {
			for (int i = 0; i < MAX_CASES; i++)
				caseLibre[i] = 0;

			foreach (Map m in tabMap)
				caseLibre[m.NumCase] = 1;

			for (int i = 0; i < MAX_CASES; i++)
				if (caseLibre[i] == 0)
					return (byte)i;

			return 255;
		}

		private void Connect(Map map, int x, int y, int n, Cnx autoCnx, Map.TypeCase valeur) {
			byte c = GetCaseLibre();
			if (c != 255) {
				int pos = x + y * TAILLE_Y + n * TAILLE_Y * TAILLE_Z;
				map.NumCase = c;
				map.TypeMap = valeur;

				// Connecte la salle en Bas
				if (n > 0 && (autoCnx & Cnx.BAS) == Cnx.BAS) {
					Map mb = FindMap(x, y, n - 1, false);
					if (mb != null && mb.TypeMap != Map.TypeCase.CASE_VIDE) {
						mb.Haut = c;
						map.Bas = mb.NumCase;
					}
				}

				// Connecte la salle en Haut
				if (n < TAILLE_Z - 1 && (autoCnx & Cnx.HAUT) == Cnx.HAUT) {
					Map mh = FindMap(x, y, n + 1, false);
					if (mh != null && mh.TypeMap != Map.TypeCase.CASE_VIDE) {
						mh.Bas = c;
						map.Haut = mh.NumCase;
					}
				}

				// Connecte la salle au Nord
				if (y > 0 && (autoCnx & Cnx.NORD) == Cnx.NORD) {
					Map mn = FindMap(x, y - 1, n, false);
					if (mn != null && mn.TypeMap != Map.TypeCase.CASE_VIDE) {
						mn.Sud = c;
						map.Nord = mn.NumCase;
					}
				}

				// Connecte la salle au Sud
				if (y < TAILLE_Y - 1 && (autoCnx & Cnx.SUD) == Cnx.SUD) {
					Map ms = FindMap(x, y + 1, n, false);
					if (ms != null && ms.TypeMap != Map.TypeCase.CASE_VIDE) {
						ms.Nord = c;
						map.Sud = ms.NumCase;
					}
				}

				// Connecte la salle à l'Est
				if (x < TAILLE_X - 1 && (autoCnx & Cnx.EST) == Cnx.EST) {
					Map me = FindMap(x + 1, y, n, false);
					if (me != null && me.TypeMap != Map.TypeCase.CASE_VIDE) {
						me.Ouest = c;
						map.Est = me.NumCase;
					}
				}

				// Connecte la salle à l'Ouest
				if (x > 0 && (autoCnx & Cnx.OUEST) == Cnx.OUEST) {
					Map mo = FindMap(x - 1, y, n, false);
					if (mo != null && mo.TypeMap != Map.TypeCase.CASE_VIDE) {
						mo.Est = c;
						map.Ouest = mo.NumCase;
					}
				}
			}
		}

		private void Deconnect(Map map, int x, int y, int n) {
			// Déconnecte la salle en Bas
			Map mb = FindMap(x, y, n - 1, false);
			if (mb != null)
				mb.Haut = 255;

			// Déconnecte la salle en Haut
			Map mh = FindMap(x, y, n + 1, false);
			if (mh != null)
				mh.Bas = 255;

			// Déconnecte la salle au Nord
			Map mn = FindMap(x, y - 1, n, false);
			if (mn != null)
				mn.Sud = 255;

			// Déconnecte la salle au Sud
			Map ms = FindMap(x, y + 1, n, false);
			if (ms != null)
				ms.Nord = 255;

			// Déconnecte la salle à l'Est
			Map me = FindMap(x + 1, y, n, false);
			if (me != null)
				me.Ouest = 255;

			// Déconnecte la salle à l'Ouest
			Map mo = FindMap(x - 1, y, n, false);
			if (mo != null)
				mo.Est = 255;
		}

		public void ModifCase(int xPos, int yPos, int zPos, Map.TypeCase type, Cnx autoCnx) {
			Map map = FindMap(xPos, yPos, zPos, false);
			switch (type) {
				case Map.TypeCase.CASE_PLEINE:
					// Ajoute une salle
					if (!(xPos == xStart && yPos == yStart && zPos == nStart) && !(xPos == xGoal && yPos == yGoal && zPos == nGoal))
						SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_PLEINE, autoCnx);
					break;

				case Map.TypeCase.CASE_DEPART:
					// Positionne la salle de départ
					if ((map == null || map.TypeMap != Map.TypeCase.CASE_PLEINE) && (xPos != xGoal || yPos != yGoal || zPos != nGoal)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xStart, yStart, nStart, Map.TypeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_DEPART, autoCnx);
						SetStart(xPos, yPos, zPos);
					}
					break;

				case Map.TypeCase.CASE_ARRIVEE:
					// Positonne la salle d'arrivée
					if ((map == null || map.TypeMap != Map.TypeCase.CASE_PLEINE) && (xPos != xStart || yPos != yStart || zPos != nStart)) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xGoal, yGoal, nGoal, Map.TypeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_ARRIVEE, autoCnx);
						SetGoal(xPos, yPos, zPos);
					}
					break;

				case Map.TypeCase.CASE_VIDE:
					// Supprime une salle
					if (xPos == xStart & yPos == yStart && zPos == nStart)
						SetStart(-1, -1, -1);

					if (xPos == xGoal && yPos == yGoal && zPos == nGoal)
						SetGoal(-1, -1, -1);

					SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_VIDE, autoCnx);
					break;
			}
		}

		public Map RechercheSalle(int numSalle, ref int x, ref int y, ref int n) {
			Map map = tabMap.Find(m => m.NumCase == numSalle && m.TypeMap != Map.TypeCase.CASE_VIDE);
			if (map != null) {
				x = map.X;
				y = map.Y;
				n = map.Z;
			}
			return map;
		}
	}
}
