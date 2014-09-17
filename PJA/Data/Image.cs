using Pack;
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
		private int internalSize;
		public int InternalSize {
			get { return internalSize; }
			set { internalSize = value; }
		}

		public Image() {
		}

		public Image(string n, int[] p, byte[] d, int x, int y) {
			nom = n;
			// #### A Améliorer...
			internalSize = (x + 1) * (y + 1) * 8 - 512;
			if (internalSize > 0x3FC0)
				internalSize += 0x1800;

			SetImage(d, p);
		}

		public void SetImage(byte[] img, int[] p) {
			RepackImage(img, img.Length);
			pal = new Palette(p);
		}

		public void RepackImage(byte[] img, int l) {
			if (data[0] == (byte)'P' && data[1] == (byte)'K' && data[2] == (byte)l && data[3] == (byte)(l >> 8))
				PackDepack.Depack(data, 4, img);

			l = PackDepack.Pack(img, internalSize, data, 4);
			data[0] = (byte)'P';
			data[1] = (byte)'K';
			data[2] = (byte)l;
			data[3] = (byte)(l >> 8);
			Array.Resize(ref data, l);
		}

		public void GetImage(byte[] dest, int[] p) {
			int l = data.Length;
			if (data[0] == (byte)'P' && data[1] == (byte)'K' && data[2] == (byte)l && data[3] == (byte)(l >> 8))
				PackDepack.Depack(data, 4, dest);
			else
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
