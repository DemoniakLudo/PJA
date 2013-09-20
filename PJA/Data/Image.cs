using System;

namespace PJA {
	[Serializable]
	public class Image {
		public string nom;
		public byte[] data = new byte[0x8000];
		private Palette pal;
		public Palette Pal {
			get { return pal; }
			set { pal = value; }
		}

		public Image() {
		}

		public Image(string n, int[] p, byte[] d) {
			nom = n;
			pal = new Palette(p);
			for (int i = 0; i < data.Length; i++)
				data[i] = d[i];
		}

		public override string ToString() {
			return nom;
		}

		public int GetPalette(int ind) {
			return pal.GetPalette(ind);
		}

		public void SendPalette(int[] p) {
			pal.SendPalette(p);
		}

		public void SetPal(Palette p) {
			pal = p;
		}
	}
}
