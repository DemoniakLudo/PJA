using System.IO;

namespace PJA {
	public class Palette: BaseData {
		public byte[] palette = new byte[34];
		public string nom = "";

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
			return ind < 17 ? (palette[2 * ind] << 8) + palette[2 * ind + 1] : 0;
		}

		public void SetPalette(int ind, int val) {
			palette[2 * ind] = (byte)(val >> 8);
			palette[2 * ind + 1] = (byte)val;
		}

		public override bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line.StartsWith("#PALETTE_NAME")) {
				nom = line.Substring(14);
				line = rd.ReadLine();
			}
			if (line.StartsWith("#PALETTE_VALUE") || line.StartsWith("#IMAGE_PALETTE")) {
				byte[] tmp = System.Convert.FromBase64String(line.Substring(15));
				for (int i = 0; i < 34; i++)
					palette[i] = tmp[i];

				return true;
			}
			return false;
		}

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#PALETTE_NAME\t" + nom);
			wr.WriteLine("#PALETTE_VALUE\t" + System.Convert.ToBase64String(palette));
			return true;
		}

		public override string ToString() {
			return nom;
		}
	}
}
