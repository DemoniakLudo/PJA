using System;
using System.Collections.Generic;

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
		private byte valDef;		// valeur par défaut variable de salle
		public byte ValDef {
			get { return valDef; }
			set { valDef = value; }
		}
		private string libelle = "";
		public string Libelle {
			get { return libelle; }
			set { libelle = value; }
		}
		private int indexImage; // numéro d'image à charger (anciennement 'vue')
		public int IndexImage {
			get { return indexImage; }
			set { indexImage = value; }
		}
		private List<Zone> lstZone = new List<Zone>();
		public List<Zone> LstZone {
			get { return lstZone; }
			set { lstZone = value; }
		}

		public Map() {
			Init();
		}

		private void Init() {
			indexImage = -1;
			typeMap = TypeCase.CASE_VIDE;
		}

		public override string ToString() {
			return libelle;
		}
	}
}
