using System;

namespace PJA {
	[Serializable]
	public class Image {
		public string nom;
		public byte[] data = new byte[0x8100];
		private Palette pal;
		public Palette Pal {
			get { return pal; }
			set { pal = value; }
		}
		private int internalSize;

		public Image() {
		}

		public Image(string n, int[] p, byte[] d, int x, int y) {
			nom = n;
			SetInternal(x, y);
			SetImage(d, p, x, y);
		}

		private void SetInternal(int x, int y) {
			// #### A Améliorer...
			internalSize = (x + 1) * (y + 1) * 8 - 512;
			if (x * y > 0x800)
				internalSize += 0x1A00;

		}

		public void SetImage(byte[] img, int[] p, int cx, int cy) {
			RepackImage(img, img.Length, cx, cy);
			pal = new Palette(p);
		}

		public void RepackImage(byte[] img, int l, int cx, int cy) {
			if (data[0] == (byte)'P' && data[1] == (byte)'K' && data[2] == (byte)l && data[3] == (byte)(l >> 8))
				PackDepack.Depack(data, 4, img, PackDepack.PackMethode.Standard);

			SetInternal(cx, cy);
			l = PackDepack.Pack(img, internalSize, data, 4, PackDepack.PackMethode.ZX0);
			data[0] = (byte)'Z';
			data[1] = (byte)'0';
			data[2] = (byte)l;
			data[3] = (byte)(l >> 8);
			Array.Resize(ref data, l);
		}

		public void GetImage(byte[] dest, int[] p) {
			int l = data.Length;
			if (data[0] == (byte)'P' && data[1] == (byte)'K' && data[2] == (byte)l && data[3] == (byte)(l >> 8))
				PackDepack.Depack(data, 4, dest, PackDepack.PackMethode.Standard);
			else
			if (data[0] == (byte)'Z' && data[1] == (byte)'0' && data[2] == (byte)l && data[3] == (byte)(l >> 8))
				PackDepack.Depack(data, 4, dest, PackDepack.PackMethode.ZX0);
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
