using System.IO;

namespace PJA {
	public class Image: Data {
		public string nom;
		public byte[] data = new byte[0x8000];
		private Palette pal;

		public Image(string n, int[] p, byte[] d) {
			nom = n;
			pal = new Palette(p);
			for (int i = 0; i < data.Length; i++)
				data[i] = d[i];
		}

		public Image(StreamReader rd) {
			pal = new Palette();
			Load(rd);
		}

		public override string ToString() {
			return nom;
		}

		public int GetPalette(int ind) {
			return pal.GetPalette(ind);
		}

		public void SetPal(Palette p) {
			pal = p;
		}

		public void SetPalette(int ind, int val) {
			pal.SetPalette(ind, val);
		}

		public override bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line.StartsWith("#IMAGE_NAME")) {
				nom = line.Substring(12);
				line = rd.ReadLine();
				if (line.StartsWith("#IMAGE_DATA")) {
					byte[] tmp = System.Convert.FromBase64String(line.Substring(12));
					for (int i = 0; i < tmp.Length; i++)
						data[i] = tmp[i];

					return pal.Load(rd);
				}
			}
			return false;
		}

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#IMAGE_NAME\t" + nom);
			wr.WriteLine("#IMAGE_DATA\t" + System.Convert.ToBase64String(data));
			return pal.Save(wr);
		}
	}
}
