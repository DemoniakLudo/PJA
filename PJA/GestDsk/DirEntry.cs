namespace PJA {
	public class DirEntry {
		public byte User;
		public byte[] Nom = new byte[8];
		public byte[] Ext = new byte[3];
		public byte NumPage;
		public short Unused;
		public byte NbPages;
		public byte[] Blocks = new byte[16];
	}
}
