using System.IO;

namespace PJA {
	public class Dsk {
		private DskTrack[] trk;
		private string Id;
		private byte NbTracks;
		private byte NbHeads;
		private short DataSize;
		private byte[] fillTmp = new byte[0xCC];

		public Dsk() {
			Id = "MV - CPCEMU Disk-File\r\nDisk-Info\r\n              ";
		}

		public void SetDskInfo(byte nbTrk, byte nbHd, short dSize, bool newTrk) {
			NbTracks = nbTrk;
			NbHeads = nbHd;
			DataSize = dSize;
			if (newTrk) {
				trk = new DskTrack[NbTracks * NbHeads];
				int p = 0;
				for (int t = 0; t < NbTracks; t++)
					for (int h = 0; h < NbHeads; h++) {
						trk[p] = new DskTrack();
						trk[p].Track = (byte)t;
						trk[p].Head = (byte)h;
						p++;
					}
			}
		}

		public void FormatTrack(byte t, byte h, byte or, DskSect[] tabSect, int nbSect) {
			trk[(t * NbHeads) + h].FormatTrack(t, h, or, tabSect, nbSect);
		}

		public void WriteDatas(int t, int h, int s, byte[] data, int pos) {
			trk[(t * NbHeads) + h].WriteDatas(s, data, pos);
		}
/*
		public void Read(string name) {
			FileStream fs = new FileStream(name, FileMode.Open, FileAccess.Read);
			BinaryReader br = new BinaryReader(fs);
			Id = System.Text.Encoding.UTF8.GetString(br.ReadBytes(0x30));
			string s = fillTmp.ToString();
			NbTracks = br.ReadByte();
			NbHeads = br.ReadByte();
			DataSize = br.ReadInt16();
			fillTmp = br.ReadBytes(0xCC);
			SetDskInfo(NbTracks, NbHeads, DataSize, true);
			for (int i = 0; i < NbTracks * NbHeads; i++)
				trk[i].Read(br);

			br.Close();
		}
*/
		public void Save(string name) {
			FileStream fs = new FileStream(name, FileMode.Create, FileAccess.Write);
			BinaryWriter bw = new BinaryWriter(fs);
			for (int i = 0; i < Id.Length; i++)
				bw.Write(Id[i]);
			bw.Write(NbTracks);
			bw.Write(NbHeads);
			bw.Write(DataSize);
			bw.Write(fillTmp, 0, fillTmp.Length);
			for (int i = 0; i < NbTracks * NbHeads; i++)
				trk[i].Save(bw);

			bw.Close();
		}
	}
}