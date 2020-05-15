using System;

namespace PJA {
	class GestDsk {
		private CreateDsk dsk;
		private Projet projet;
		private byte[] allData = new byte[0x8000];
		private string fileName;

		public GestDsk(Projet prj, string f) {
			projet = prj;
			fileName = f;
			dsk = new CreateDsk(projet, 80, 2, 10, 0xC1, true);
		}

		public void WriteImages() {
			byte[] bitmap = new byte[512];
			Buffer.BlockCopy(System.Text.Encoding.UTF8.GetBytes("#<$PJA-BITMAP>$#"), 0, bitmap, 0, 16);
			int t = 10, h = 0, s = 0, vue = 0, posBitmap = 16;
			foreach (Image i in projet.ImageData.listImg) {
				int l = i.data.Length;
				Buffer.BlockCopy(i.Pal.PalColor, 0, allData, 0, 34);
				Buffer.BlockCopy(i.data, 4, allData, 34, l - 4);
				l = l + 30;
				allData[l] = allData[l + 1] = 0;
				bitmap[posBitmap++] = (byte)vue++;
				bitmap[posBitmap++] = (byte)t;
				bitmap[posBitmap++] = (byte)h;
				bitmap[posBitmap++] = (byte)(s + 0xC1);
				bitmap[posBitmap++] = (byte)((l + 511) / 512);
				dsk.SetDataDsk(ref t, ref h, ref s, allData, l);
			}
			dsk.WriteSect(0, 0, 0, bitmap, 0);
			dsk.SaveDsk(fileName);
		}

		public void WriteZones() {
			byte[] ptrZone = new byte[0x200];
			byte[] dataZone = new byte[0x2000];
			int posData = 0, posPtr = 0;
			foreach (Map m in projet.MapData.ListMap) {
				int memoPos = posData + (projet.MapData.ListMap.Count << 1);
				foreach (Zone z in m.LstZone) {
					dataZone[posData++] = (byte)z.typeZone;
					dataZone[posData++] = (byte)z.xd;
					dataZone[posData++] = (byte)z.xa;
					dataZone[posData++] = (byte)(200 - z.ya);
					dataZone[posData++] = (byte)(200 - z.yd);
					dataZone[posData++] = (byte)(z.varAction & 0xFF);
					dataZone[posData++] = (byte)(z.varAction >> 8);
				}
				allData[posData++] = 0;
				ptrZone[posPtr++] = (byte)(memoPos & 0xFF);
				ptrZone[posPtr++] = (byte)(memoPos >> 8);
			}
			Buffer.BlockCopy(ptrZone, 0, allData, 0, posPtr);
			Buffer.BlockCopy(dataZone, 0, allData, posPtr, posData);
			int t = 2, h = 0, s = 0;
			dsk.SetDataDsk(ref t, ref h, ref s, allData, posPtr + posData);
		}
	}
}
