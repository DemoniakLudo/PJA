using System.IO;

namespace PJA {
	public abstract class Data {
		public abstract bool Load(StreamReader rd);
		public abstract bool Save(StreamWriter wr);
	}
}
