﻿using System;
using System.IO;

namespace PJA {
	[Serializable]
	public class Palette {
		private byte[] palColor = new byte[34];
		public byte[] PalColor {
			get { return palColor; }
			set { palColor = value; }
		}
		private string nom = "";
		public string Nom {
			get { return nom; }
			set { nom = value; }
		}

		public Palette() {
		}

		public Palette(int[] p) {
			InitPal(p);
		}

		public Palette(string n, int[] p) {
			nom = n;
			InitPal(p);
		}

		public Palette(StreamReader rd) {
			Load(rd);
		}

		private void InitPal(int[] p) {
			for (int i = 0; i < 17; i++)
				SetPalette(i, p[i]);
		}

		public int GetPalette(int ind) {
			return ind < 17 ? (palColor[2 * ind] << 8) + palColor[2 * ind + 1] : 0;
		}

		public void SendPalette(int[] pal) {
			for (int i = 0; i < 17; i++)
				pal[i] = GetPalette(i);
		}

		public void SetPalette(int ind, int val) {
			palColor[2 * ind] = (byte)(val >> 8);
			palColor[2 * ind + 1] = (byte)val;
		}

		public bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line.StartsWith("#PALETTE_NAME")) {
				nom = line.Substring(14);
				line = rd.ReadLine();
			}
			if (line.StartsWith("#PALETTE_VALUE") || line.StartsWith("#IMAGE_PALETTE")) {
				byte[] tmp = Convert.FromBase64String(line.Substring(15));
				for (int i = 0; i < 34; i++)
					palColor[i] = tmp[i];

				return true;
			}
			return false;
		}

		public bool Save(StreamWriter wr) {
			wr.WriteLine("#PALETTE_NAME\t" + nom);
			wr.WriteLine("#PALETTE_VALUE\t" + System.Convert.ToBase64String(palColor));
			return true;
		}

		public override string ToString() {
			return nom;
		}
	}
}
