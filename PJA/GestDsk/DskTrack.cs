using System;
using System.IO;

namespace PJA {
	public class DskTrack {
		public string Id;
		public byte Track;
		public byte Head;
		public short Unused;
		public byte SectSize;
		public byte NbSect;
		public byte Gap3;
		public byte OctRempl;
		public DskSect[] Sect = new DskSect[29];
		public int DataSize;
		public byte[] Data = new byte[8192];

		public DskTrack() {
			Id = "Track-Info\r\n    ";
			for (int i = 0; i < 29; i++)
				Sect[i] = new DskSect(0, 0, 0, 0);
		}

		public void FormatTrack(byte t, byte h, byte or, DskSect[] tabSect, int nbSect) {
			DataSize = 0;
			for (int i = 0; i < nbSect; i++) {
				Sect[i].C = tabSect[i].C;
				Sect[i].H = tabSect[i].H;
				Sect[i].R = tabSect[i].R;
				Sect[i].N = tabSect[i].N;
				Sect[i].Un1 = tabSect[i].Un1;
				Sect[i].Un2 = tabSect[i].Un2;
				DataSize += (short)(tabSect[i].R * 256);
			}
			OctRempl = or;
			NbSect = (byte)tabSect.Length;
			for (int i = 0; i < DataSize; i++)
				Data[i] = or;
		}

		public bool WriteDatas(int sect, byte[] dataSrc, int posSrc) {
			int pos = 0;
			bool sectFound = false;
			for (int i = 0; i < NbSect; i++)
				if (Sect[i].N == sect) {
					sectFound = true;
					break;
				}
				else
					pos += Sect[i].R * 256;

			if (sectFound) {
				Buffer.BlockCopy(dataSrc, posSrc, Data, pos, Math.Min(dataSrc.Length - posSrc, 0x200));
				return true;
			}
			return false;
		}

		public void Save(BinaryWriter bw) {
			for (int i = 0; i < Id.Length; i++)
				bw.Write(Id[i]);
			bw.Write(Track);
			bw.Write(Head);
			bw.Write(Unused);
			bw.Write(SectSize);
			bw.Write(NbSect);
			bw.Write(Gap3);
			bw.Write(OctRempl);
			for (int i = 0; i < 29; i++)
				Sect[i].Save(bw);

			bw.Write(Data, 0, DataSize);
		}

		public void Read(BinaryReader br) {
			Id = System.Text.Encoding.UTF8.GetString(br.ReadBytes(0x10));
			Track = br.ReadByte();
			Head = br.ReadByte();
			Unused = br.ReadInt16();
			SectSize = br.ReadByte();
			NbSect = br.ReadByte();
			Gap3 = br.ReadByte();
			OctRempl = br.ReadByte();
			for (int i = 0; i < 29; i++)
				Sect[i].Read(br);

			DataSize = NbSect * SectSize * 256;
			Data = br.ReadBytes(DataSize);
		}
	}
}
