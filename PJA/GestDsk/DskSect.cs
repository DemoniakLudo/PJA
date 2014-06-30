using System.IO;

namespace PJA {
	public class DskSect {
		public byte C;
		public byte H;
		public byte R;
		public byte N;
		public short Un1;
		public short Un2;

		public DskSect(int sC, int sH, int sR, int sN) {
			SetValues(sC, sH, sR, sN);
		}

		public void SetValues(int sC, int sH, int sR, int sN) {
			C = (byte)sC;
			H = (byte)sH;
			R = (byte)sR;
			N = (byte)sN;
		}

		public void Save(BinaryWriter bw) {
			bw.Write(C);
			bw.Write(H);
			bw.Write(R);
			bw.Write(N);
			bw.Write(Un1);
			bw.Write(Un2);
		}

		public void Read(BinaryReader br) {
			C = br.ReadByte();
			H = br.ReadByte();
			R = br.ReadByte();
			N = br.ReadByte();
			Un1 = br.ReadInt16();
			Un2 = br.ReadInt16();
		}
	}
}
