using System;
using System.Collections.Generic;

namespace PJA {
	[Serializable]
	public class DataImage {
		public List<Image> listImg = new List<Image>();
		public List<Palette> listPal = new List<Palette>();
		private bool modif;
		public bool Modif { get { return modif; } }

		public void Init() {
		}

		public void AddImage(string nom, int[] palette, byte[] data) {
			listImg.Add(new Image(nom, palette, data));
			modif = true;
		}

		public void DeleteImage(Image img) {
			listImg.Remove(img);
		}

		public void Up(Image img) {
			for (int i = 0; i < listImg.Count; i++)
				if (listImg[i] == img) {
					listImg.RemoveAt(i);
					listImg.Insert(i - 1, img);
					break;
				}
		}

		public void Down(Image img) {
			for (int i = 0; i < listImg.Count; i++)
				if (listImg[i] == img) {
					listImg.RemoveAt(i);
					listImg.Insert(i + 1, img);
					break;
				}
		}

		public void Repack() {
			byte[] tmp = new byte[0x8000];
			foreach (Image i in listImg) {
				Array.Copy(i.data, tmp, i.data.Length);
				i.RepackImage(tmp, i.data.Length);
			}
		}
	}
}
