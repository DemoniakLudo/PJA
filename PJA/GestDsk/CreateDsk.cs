namespace PJA {
	class CreateDsk {
		private Dsk dsk = new Dsk();
		private DskSect[] tabSect = new DskSect[10];
		private Projet projet;
		private byte nbTracks;
		private byte nbHeads;
		private byte nbSects;
		private byte firstSect;

		public CreateDsk(Projet prj, int t, int h, int nbs, int s) {
			projet = prj;
			nbTracks = (byte)t;
			nbHeads = (byte)h;
			nbSects = (byte)nbs;
			firstSect = (byte)s;
		}

		public void Test() {
			FormatDsk(true);
			int t = 0;
			int h = 0;
			int s = 0;
			byte[] data = projet.ImageData.listImg[0].data;
			SetDataDsk(ref t, ref h, ref s, data, data.Length);
			SaveDsk("test.dsk");
		}

		private void SetSecteur(ref DskSect sect, int C, int H, int R, int N) {
			if (sect == null)
				sect = new DskSect(C, H, R, N);
			else
				sect.SetValues(C, H, R, N);
		}

		public void FormatDsk(bool entrelac) {
			int inc = entrelac ? 1 : 2;
			dsk.SetDskInfo(nbTracks, nbHeads, (short)(0x100 + (0x200 * nbSects)), true);
			for (int t = 0; t < nbTracks; t++) {
				for (int h = 0; h < nbHeads; h++) {
					int p1 = 0;
					int p2 = entrelac ? 5 : 1;
					for (int s = 0; s < nbSects; ) {
						SetSecteur(ref tabSect[s++], t, h, firstSect + p1, 2);
						if (s < nbSects)
							SetSecteur(ref tabSect[s++], t, h, firstSect + p2, 2);

						p1 += inc;
						p2 += inc;
					}
					dsk.FormatTrack((byte)t, (byte)h, 0xE5, tabSect, nbSects);
				}
			}
		}

		public void SetDataDsk(ref int strtTrk, ref int strtHd, ref int strtSect, byte[] data, int longueur) {
			int pos = 0;
			for (int l = 0; l < longueur; l += 0x200) {
				WriteSect(strtTrk, strtHd, strtSect, data, pos);
				pos += 0x200;
				if (++strtSect == nbSects) {
					strtSect = 0;
					if (nbHeads > 1) {
						if (++strtHd == nbHeads) {
							strtTrk++;
							strtHd = 0;
						}
					}
					else
						strtTrk++;
				}
			}
		}

		public void WriteSect(int trk, int hd, int sct, byte[] data, int pos) {
			dsk.WriteDatas(trk, hd, firstSect + sct, data, pos);
		}


		public void SaveDsk(string name) {
			dsk.Save(name);
		}
	}
}
