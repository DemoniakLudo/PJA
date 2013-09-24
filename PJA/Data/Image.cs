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
			SetImage(d, p);
		}

		public void SetImage(byte[] img, int[] p) {
			Array.Copy(img, data, data.Length);
			pal = new Palette(p);
		}

		public void GetImage(byte[] dest, int[] p) {
			Array.Copy(data, dest, data.Length);
			pal.SendPalette(p);
		}

		public override string ToString() {
			return nom;
		}

		public void SetPal(Palette p) {
			pal = p;
		}
	}
}
