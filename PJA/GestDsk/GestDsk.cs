using System;

namespace PJA {
	class GestDsk {
		private CreateDsk dsk;
		private Projet projet;
		private byte[] allData = new byte[0x8000];

		public GestDsk(Projet prj) {
			projet = prj;
			dsk = new CreateDsk(projet, 80, 2, 10, 0xC0);
			dsk.FormatDsk(true);
		}

		public void WriteImages() {
			byte[] bitmap = new byte[512];
			string check = "#<$PJA-BITMAP>$#";
			Buffer.BlockCopy(System.Text.Encoding.UTF8.GetBytes(check), 0, bitmap, 0, 16);
			int t = 10;
			int h = 0;
			int s = 0;
			int vue = 0;
			int posBitmap = 16;
			foreach (Image i in projet.ImageData.listImg) {
				int l = i.data.Length;
				Buffer.BlockCopy(i.Pal.PalColor, 0, allData, 0, 34);
				Buffer.BlockCopy(i.data, 4, allData, 34, l - 4);
				l = l + 30;
				int nbs = (l + 511) / 512;
				BitmapImage bmi = new BitmapImage(vue++, t, h, s + 0xC0, nbs);
				dsk.SetDataDsk(ref t, ref h, ref s, allData, l);
				Buffer.BlockCopy(bmi.ConvByte(), 0, bitmap, posBitmap, 5);
				posBitmap += 5;
			}
			dsk.WriteSect(0, 0, 0, bitmap, 0);
			dsk.SaveDsk("test.dsk");
		}

		public void WriteZones() {
			byte[] ptrZone = new byte[0x200];
			byte[] dataZone = new byte[0x1000];
			int posData = 0, memoPos = 0, posPtr = 0;
			foreach (Map m in projet.MapData.ListMap) {
				memoPos = posData;
				foreach (Zone z in m.LstZone) {
					dataZone[posData++] = (byte)z.typeZone;
					dataZone[posData++] = (byte)z.xd;
					dataZone[posData++] = (byte)z.xa;
					dataZone[posData++] = (byte)z.yd;
					dataZone[posData++] = (byte)z.ya;
					dataZone[posData++] = (byte)(z.varAction & 0xFF);
					dataZone[posData++] = (byte)(z.varAction >> 8);
				}
				allData[posData++] = 0;
				ptrZone[posPtr++] = (byte)(memoPos & 0xFF);
				ptrZone[posPtr++] = (byte)(memoPos >> 8);
			}
			Buffer.BlockCopy(ptrZone, 0, allData, 0, posPtr);
			Buffer.BlockCopy(dataZone, 0, allData, posPtr, posData);
		}
	}

	class BitmapImage {
		private byte numVue;
		private byte startHead;
		private byte startTrack;
		private byte startSect;
		private byte nbSects;

		public BitmapImage(int v, int t, int h, int s, int nbs) {
			numVue = (byte)v;
			startHead = (byte)t;
			startTrack = (byte)h;
			startSect = (byte)s;
			nbSects = (byte)nbs;
		}

		public byte[] ConvByte() {
			byte[] ret = new byte[5];
			ret[0] = numVue;
			ret[1] = startHead;
			ret[2] = startTrack;
			ret[3] = startSect;
			ret[4] = nbSects;
			return ret;
		}
	}
}
