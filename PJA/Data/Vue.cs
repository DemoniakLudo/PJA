using System.Collections.Generic;
using System.IO;

namespace PJA {
	class Vue: BaseData {
		private int indexImage;
		private List<Zone> lstZone = new List<Zone>();

		public override bool Load(StreamReader rd) {
			string line = rd.ReadLine();
			if (line != null) {
				if (line.StartsWith("#VUE_IMG")) {
					indexImage = int.Parse(line.Substring(9));
					line = rd.ReadLine();
					if (line.StartsWith("#VUE_NB_ZONES")) {
						int nbz = int.Parse(line.Substring(14));
						for (; nbz-- > 0; )
							lstZone.Add(new Zone(rd));

						return true;
					}
				}
			}
			return false;
		}

		public override bool Save(StreamWriter wr) {
			wr.WriteLine("#VUE_IMG\t" + indexImage);
			wr.WriteLine("#VUE_NB_ZONES\t" + lstZone.Count);
			foreach (Zone z in lstZone)
				if (!z.Save(wr))
					return false;

			return true;
		}
	}
}
