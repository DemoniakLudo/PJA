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
		private List<Map> listMap = new List<Map>();
		public List<Map> ListMap {
			get {
				modif = true;
				return listMap;
			}
			set { listMap = value; }
		}
		private byte[] caseLibre = new byte[256];
		public enum Cnx { NULL = 0, HAUT = 1, BAS = 2, NORD = 4, SUD = 8, EST = 16, OUEST = 32 };
		private bool modif;
		public bool Modif { get { return modif; } }
		private int xStart = -1, yStart = -1, nStart = -1;
		private int xGoal = -1, yGoal = -1, nGoal = -1;
		public int NbSalles { get { return listMap.Count; } }
		private int curSalle = 0;
		public int CurSalle { get { return curSalle; } }

		public DataMap() {
		}

		public void Init() {
			SetGoal(-1, -1, -1);
			SetStart(-1, -1, -1);
			foreach (Map m in listMap) {
				if (m.TypeMap == Map.TypeCase.CASE_DEPART)
					SetStart(m.X, m.Y, m.Z);
				else
					if (m.TypeMap == Map.TypeCase.CASE_ARRIVEE)
						SetGoal(m.X, m.Y, m.Z);
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

		public Map FindMap(int x, int y, int z) {
			return listMap.Find(m => m.X == x && m.Y == y && m.Z == z);
		}

		public Map FindMap(int numSalle) {
			return listMap.Find(m => m.NumCase == numSalle);
		}

		private void SetCase(int x, int y, int n, Map.TypeCase valeur, Cnx autoCnx) {
			if (x >= 0 && x < TAILLE_X && y >= 0 && y < TAILLE_X && n >= 0 && n < TAILLE_Z) {
				Map map = FindMap(x, y, n);
				if (map == null && valeur != Map.TypeCase.CASE_VIDE) {
					map = new Map(x, y, n);
					listMap.Add(map);
				}
				if (map != null && map.TypeMap != valeur) {
					if (valeur != Map.TypeCase.CASE_VIDE)
						Connect(map, autoCnx, valeur);
					else
						Deconnect(map);
				}
			}
		}

		private byte GetCaseLibre() {
			for (int i = 0; i < MAX_CASES; i++)
				caseLibre[i] = 0;

			foreach (Map m in listMap)
				caseLibre[m.NumCase] = 1;

			for (int i = 0; i < MAX_CASES; i++)
				if (caseLibre[i] == 0)
					return (byte)i;

			return 255;
		}

		private void Connect(Map map, Cnx autoCnx, Map.TypeCase valeur) {
			byte c = GetCaseLibre();
			if (c != 255) {
				map.NumCase = c;
				map.TypeMap = valeur;

				// Connecte la salle en Bas
				if ((autoCnx & Cnx.BAS) == Cnx.BAS) {
					Map mb = FindMap(map.X, map.Y, map.Z - 1);
					if (mb != null) {
						mb.Haut = c;
						map.Bas = mb.NumCase;
					}
				}

				// Connecte la salle en Haut
				if ((autoCnx & Cnx.HAUT) == Cnx.HAUT) {
					Map mh = FindMap(map.X, map.Y, map.Z + 1);
					if (mh != null) {
						mh.Bas = c;
						map.Haut = mh.NumCase;
					}
				}

				// Connecte la salle au Nord
				if ((autoCnx & Cnx.NORD) == Cnx.NORD) {
					Map mn = FindMap(map.X, map.Y - 1, map.Z);
					if (mn != null) {
						mn.Sud = c;
						map.Nord = mn.NumCase;
					}
				}

				// Connecte la salle au Sud
				if ((autoCnx & Cnx.SUD) == Cnx.SUD) {
					Map ms = FindMap(map.X, map.Y + 1, map.Z);
					if (ms != null) {
						ms.Nord = c;
						map.Sud = ms.NumCase;
					}
				}

				// Connecte la salle à l'Est
				if ((autoCnx & Cnx.EST) == Cnx.EST) {
					Map me = FindMap(map.X + 1, map.Y, map.Z);
					if (me != null) {
						me.Ouest = c;
						map.Est = me.NumCase;
					}
				}

				// Connecte la salle à l'Ouest
				if ((autoCnx & Cnx.OUEST) == Cnx.OUEST) {
					Map mo = FindMap(map.X - 1, map.Y, map.Z);
					if (mo != null) {
						mo.Est = c;
						map.Ouest = mo.NumCase;
					}
				}
			}
		}

		private void Deconnect(Map map) {
			// Déconnecte la salle en Bas
			Map mb = FindMap(map.X, map.Y, map.Z - 1);
			if (mb != null)
				mb.Haut = 255;

			// Déconnecte la salle en Haut
			Map mh = FindMap(map.X, map.Y, map.Z + 1);
			if (mh != null)
				mh.Bas = 255;

			// Déconnecte la salle au Nord
			Map mn = FindMap(map.X, map.Y - 1, map.Z);
			if (mn != null)
				mn.Sud = 255;

			// Déconnecte la salle au Sud
			Map ms = FindMap(map.X, map.Y + 1, map.Z);
			if (ms != null)
				ms.Nord = 255;

			// Déconnecte la salle à l'Est
			Map me = FindMap(map.X + 1, map.Y, map.Z);
			if (me != null)
				me.Ouest = 255;

			// Déconnecte la salle à l'Ouest
			Map mo = FindMap(map.X - 1, map.Y, map.Z);
			if (mo != null)
				mo.Est = 255;

			listMap.Remove(map);
		}

		public void ModifCase(int xPos, int yPos, int zPos, Map.TypeCase type, Cnx autoCnx) {
			Map map = FindMap(xPos, yPos, zPos);
			switch (type) {
				case Map.TypeCase.CASE_PLEINE:
					// Ajoute une salle
					if (!(xPos == xStart && yPos == yStart && zPos == nStart) && !(xPos == xGoal && yPos == yGoal && zPos == nGoal))
						SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_PLEINE, autoCnx);
					break;

				case Map.TypeCase.CASE_DEPART:
					// Positionne la salle de départ
					if (map == null) {
						// on efface l'ancienne position et on affecte la nouvelle
						SetCase(xStart, yStart, nStart, Map.TypeCase.CASE_VIDE, autoCnx);
						SetCase(xPos, yPos, zPos, Map.TypeCase.CASE_DEPART, autoCnx);
						SetStart(xPos, yPos, zPos);
					}
					break;

				case Map.TypeCase.CASE_ARRIVEE:
					// Positonne la salle d'arrivée
					if (map == null) {
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
	}
}
