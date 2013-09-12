using System.IO;

namespace PJA {
	public abstract class BaseData {
		public abstract bool Load(StreamReader rd);
		public abstract bool Save(StreamWriter wr);
	}
}
