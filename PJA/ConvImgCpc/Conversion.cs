using System;
using System.Drawing;

namespace ConvImgCpc {
	public class Conversion {
		const int K_R = 9798;
		const int K_V = 19235;
		const int K_B = 3735;

		const int SEUIL_LUM_1 = 0x55;
		const int SEUIL_LUM_2 = 0xAA;

		public enum SizeMode { Fit, KeepSmaller, KeepLarger };

		public delegate void DlgCalcDiff(int diff, int decalMasque);
		static private DlgCalcDiff fctCalcDiff = null;
		static private int[] Coul = new int[4096];
		static private int tailleX, tailleY, Tx, MaxCol;
		static private LockBitmap bitmap;
		static private int xPix, yPix;
		static private RvbColor[] tabCol = new RvbColor[16];
		static private int coeffMat;
		static private byte[] tblContrast = new byte[256];
		static private RvbColor[] tabMelange = new RvbColor[65536];

		static int MinMax(int value, int min, int max) {
			return value >= min ? value <= max ? value : max : min;
		}

		static int CalcDist(int r1, int v1, int b1, int r2, int v2, int b2) {
			return (r1 > r2 ? (r1 - r2) * K_R : (r2 - r1) * K_R) + (v1 > v2 ? (v1 - v2) * K_V : (v2 - v1) * K_V) + (b1 > b2 ? (b1 - b2) * K_B : (b2 - b1) * K_B);
		}

		static int CalcDist(int a, int b) {
			return ((a & 0xFF) > (b & 0xFF) ? ((a & 0xFF) - (b & 0xFF)) * K_R : ((b & 0xFF) - (a & 0xFF)) * K_R) + (((a >> 8) & 0xFF) > ((b >> 8) & 0xFF) ? (((a >> 8) & 0xFF) - ((b >> 8) & 0xFF)) * K_V : (((b >> 8) & 0xFF) - ((a >> 8) & 0xFF)) * K_V) + ((a >> 16) > (b >> 16) ? ((a - b) >> 16) * K_B : ((b - a) >> 16) * K_B);
		}

		static int CalcDist(RvbColor c, int r, int v, int b) {
			return (c.r > r ? (c.r - r) * K_R : (r - c.r) * K_R) + (c.v > v ? (c.v - v) * K_V : (v - c.v) * K_V) + (c.b > b ? (c.b - b) * K_B : (b - c.b) * K_B);
		}

		static private void AddPixel(int x, int y, int corr, int decalMasque) {
			int adr = (((y * bitmap.Width) + x) << 2) + decalMasque;
			if (adr < bitmap.Pixels.Length)
				bitmap.Pixels[adr] = (byte)MinMax(bitmap.Pixels[adr] + corr, 0, 255);
		}

		static void CalcDiffMethode1Mat2(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff * 7) / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, (diff * 5) / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 2, diff / coeffMat, decalMasque);
		}

		static void CalcDiffMethode2Mat2(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff << 3) / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff << 2) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, (diff << 1) / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 2, diff / coeffMat, decalMasque);
		}

		static void CalcDiffMethode3Mat2(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff << 1) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, (diff << 1) / coeffMat, decalMasque);
		}

		static void CalcDiffMethode1Mat3(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff * 7) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix, (diff * 5) / coeffMat, decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 2, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff * 5) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, (diff * 7) / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 2, (diff * 5) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 2, (diff * 3) / coeffMat, decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 4, diff / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 4, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 4, (diff * 5) / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 4, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 4, diff / coeffMat, decalMasque);
		}

		static void CalcDiffMethode2Mat3(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff << 2) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix, (diff << 1) / coeffMat, decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 2, diff / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff << 1) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, diff / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 2, (diff << 1) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 2, diff / coeffMat, decalMasque);
		}

		static void CalcDiffMethode3Mat3(int diff, int decalMasque) {
			AddPixel(xPix + Tx, yPix, (diff << 2) / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix, (diff * 3) / coeffMat, decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 2, diff / coeffMat, decalMasque);
			AddPixel(xPix - Tx, yPix + 2, (diff << 1) / coeffMat, decalMasque);
			AddPixel(xPix, yPix + 2, (diff * 3) / coeffMat, decalMasque);
			AddPixel(xPix + Tx, yPix + 2, diff / coeffMat, decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 2, (diff << 1) / coeffMat, decalMasque);
		}

		// Modification luminosité / saturation
		static private void SetLumiSat(float lumi, float satur, ref float r, ref float v, ref float b) {
			float min = Math.Min(r, Math.Min(v, b));
			float max = Math.Max(r, Math.Max(v, b));
			float dif = max - min;
			float hue = 0;
			if (max > min) {
				if (v == max) {
					hue = (b - r) / dif * 60f + 120f;
				}
				else
					if (b == max) {
						hue = (r - v) / dif * 60f + 240f;
					}
					else
						if (b > v) {
							hue = (v - b) / dif * 60f + 360f;
						}
						else {
							hue = (v - b) / dif * 60f;
						}
				if (hue < 0)
					hue = hue + 360f;
			}
			hue *= 255f / 360f;
			float sat = satur * (dif / max) * 255f;
			float bri = lumi * max;
			r = v = b = bri;
			if (sat != 0) {
				max = bri;
				dif = bri * sat / 255f;
				min = bri - dif;
				float h = hue * 360f / 255f;
				if (h < 60f) {
					r = max;
					v = h * dif / 60f + min;
					b = min;
				}
				else
					if (h < 120f) {
						r = -(h - 120f) * dif / 60f + min;
						v = max;
						b = min;
					}
					else
						if (h < 180f) {
							r = min;
							v = max;
							b = (h - 120f) * dif / 60f + min;
						}
						else
							if (h < 240f) {
								r = min;
								v = -(h - 240f) * dif / 60f + min;
								b = max;
							}
							else
								if (h < 300f) {
									r = (h - 240f) * dif / 60f + min;
									v = min;
									b = max;
								}
								else
									if (h <= 360f) {
										r = max;
										v = min;
										b = -(h - 360f) * dif / 60 + min;
									}
									else
										r = v = b = 0;
			}
		}

		//
		// Passe 1 : Réduit la palette aux x couleurs de la palette du CPC.
		// Effectue également un traitement de l'erreur (tramage) si demandé.
		// Calcule le nombre de couleurs utilisées dans l'image, et
		// remplit un tableau avec ces couleurs
		//
		static private int ConvertPasse1(int xdest, int ydest, int Methode, int Matrice, int Pct, bool cpcPlus, bool newMethode, int Mode, bool CpcPlus, bool ReductPal1, bool ReductPal2, bool ModeReduct, int pctLumi, int pctSat, int pctContrast) {
			if (cpcPlus)
				Pct <<= 2;

			for (int i = 0; i < Coul.Length; i++)
				Coul[i] = 0;

			float lumi = pctLumi / 100.0F;
			float satur = pctSat / 100.0F;
			double c = pctContrast / 100.0;
			for (int i = 0; i < 256; i++) {
				double contrast = ((((i / 255.0) - 0.5) * c) + 0.5) * 255;
				tblContrast[i] = (byte)MinMax((int)contrast, 0, 255);
			}
			fctCalcDiff = null;
			if (Pct > 0)
				switch (Matrice) {
					case 2:
						switch (Methode) {
							case 1:
								fctCalcDiff = CalcDiffMethode1Mat2;
								coeffMat = 1600 / Pct;
								break;

							case 2:
								fctCalcDiff = CalcDiffMethode2Mat2;
								coeffMat = 1500 / Pct;
								break;

							case 3:
								fctCalcDiff = CalcDiffMethode3Mat2;
								coeffMat = 800 / Pct;
								break;
						}
						break;
					case 3:
						switch (Methode) {
							case 1:
								fctCalcDiff = CalcDiffMethode1Mat3;
								coeffMat = 4800 / Pct;
								break;

							case 2:
								fctCalcDiff = CalcDiffMethode2Mat3;
								coeffMat = 1600 / Pct;
								break;

							case 3:
								fctCalcDiff = CalcDiffMethode3Mat3;
								coeffMat = 1600 / Pct;
								break;
						}
						break;
				}

			RvbColor choix;
			for (xPix = 0; xPix < xdest; xPix += Tx)
				for (yPix = 0; yPix < ydest; yPix += 2) {
					// Lecture de la couleur du point au coordonnées (x,y)
					RvbColor p = bitmap.GetPixelColor(xPix, yPix);
					if (p.r != 0 && p.v != 0 && p.b != 0) {
						float r = tblContrast[p.r];
						float v = tblContrast[p.v];
						float b = tblContrast[p.b];
						if (pctLumi != 100 || pctSat != 100)
							SetLumiSat(lumi, satur, ref r, ref v, ref b);

						p.r = (byte)MinMax((int)r, 0, 255);
						p.v = (byte)MinMax((int)v, 0, 255);
						p.b = (byte)MinMax((int)b, 0, 255);
					}

					// Recherche le point dans la couleur cpc la plus proche
					int indexChoix = 0;
					if (cpcPlus) {
						choix = new RvbColor((byte)((p.r >> 4) * 17), (byte)((p.v >> 4) * 17), (byte)((p.b >> 4) * 17));
						indexChoix = ((choix.v << 4) & 0xF00) + ((choix.r) & 0xF0) + ((choix.b) >> 4);
					}
					else {
						if (!newMethode)
							indexChoix = (p.r > SEUIL_LUM_2 ? 2 : p.r > SEUIL_LUM_1 ? 1 : 0) + (p.b > SEUIL_LUM_2 ? 6 : p.b > SEUIL_LUM_1 ? 3 : 0) + (p.v > SEUIL_LUM_2 ? 18 : p.v > SEUIL_LUM_1 ? 9 : 0);
						else {
							int OldDist1 = 0x7FFFFFFF;
							for (int i = 0; i < 27; i++) {
								RvbColor s = BitmapCPC.RgbCPC[i];
								int Dist1 = CalcDist(s.r, s.v, s.b, p.r, p.v, p.b);
								if (Dist1 < OldDist1) {
									OldDist1 = Dist1;
									indexChoix = i;
									if (Dist1 == 0)
										break;
								}
							}
						}
						choix = BitmapCPC.RgbCPC[indexChoix];
					}
					Coul[indexChoix]++;

					if (fctCalcDiff != null) {
						// Modifie composante Rouge
						fctCalcDiff(p.r - choix.r, 0);

						// Modifie composante Verte
						fctCalcDiff(p.v - choix.v, 1);

						// Modifie composante Bleue
						fctCalcDiff(p.b - choix.b, 2);
					}
					bitmap.SetPixel(xPix, yPix, choix.GetColor);
				}
			if (CpcPlus) {
				//
				// Réduction du nombre de couleurs pour éviter les couleurs
				// trop proches
				//
				if (Mode < 3) {
					// Masquer 1 bit par composante
					for (int i = 0; i < Coul.Length; i++) {
						if (((i & 1) == 1 && ReductPal1) || ((i & 1) == 0 && ReductPal2)) {
							int c1 = (i & 0xC00) * 0xFFF / 0xC00;
							int c2 = (i & 0xC0) * 0xFF / 0xC0;
							int c3 = (i & 0x0C) * 0x0F / 0x0C;
							int t = Coul[i];
							Coul[i] = 0;
							if (ModeReduct)
								Coul[(c1 & 0xF00) + (c2 & 0xF0) + (c3 & 0x0F)] += t;
							else
								Coul[(c1 & 0xC00) + (c2 & 0xC0) + (c3 & 0x0C)] += t;
						}
					}
				}
			}
			int NbCol = 0;
			for (int i = 0; i < Coul.Length; i++)
				if (Coul[i] > 0)
					NbCol++;

			return NbCol;
		}

		//
		// Recherche les x couleurs les plus utilisées parmis les n possibles (remplit le tableau CChoix)
		//
		static void RechercheCMax(int[] CChoix, int[] Bloque, bool CpcPlus, bool sortPal) {
			int x, FindMax = CpcPlus ? 4096 : 27;

			for (x = 0; x < MaxCol; x++)
				if (Bloque[x] > 0)
					Coul[CChoix[x]] = 0;

			for (x = 0; x < MaxCol; x++) {
				int valMax = 0;
				if (Bloque[x] == 0) {
					for (int i = 0; i < FindMax; i++) {
						if (valMax < Coul[i]) {
							valMax = Coul[i];
							CChoix[x] = i;
						}
					}
					Coul[CChoix[x]] = 0;
				}
			}

			if (sortPal)
				for (x = 0; x < MaxCol - 1; x++)
					for (int y = x + 1; y < MaxCol; y++)
						if (Bloque[x] == 0 && Bloque[y] == 0 && CChoix[x] > CChoix[y]) {
							int tmp = CChoix[x];
							CChoix[x] = CChoix[y];
							CChoix[y] = tmp;
						}
		}

		static void SetPixCol0(BitmapCPC dest) {
			for (int y = 0; y < tailleY; y += 2)
				for (int x = 0; x < tailleX; x += Tx) {
					int oldDist = 0x7FFFFFFF;
					int p = bitmap.GetPixel(x, y);
					int choix = 0;
					for (int i = 0; i < MaxCol; i++) {
						int Dist = CalcDist(p, tabCol[i].GetColor);
						if (Dist < oldDist) {
							choix = i;
							oldDist = Dist;
							if (Dist == 0)
								break;
						}
					}
					dest.SetPixelCpc(x, y, choix);
				}
		}

		static void SetPixCol1(BitmapCPC dest) {
			int choix = 0;
			for (int y = 0; y < tailleY; y += 2)
				for (int x = 0; x < tailleX; x += Tx) {
					int oldDist = 0x7FFFFFFF;
					int totR = 0, totV = 0, totB = 0;
					bitmap.GetPixel(x, y, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(x, y + 1, ref totR, ref totV, ref totB);
					totR >>= 1;
					totV >>= 1;
					totB >>= 1;
					for (int i = 0; i < MaxCol; i++) {
						int Dist = CalcDist(tabCol[i], totR, totV, totB);
						if (Dist < oldDist) {
							choix = i;
							oldDist = Dist;
							if (Dist == 0)
								break;
						}
					}
					dest.SetPixelCpc(x, y, choix);
				}
		}

		static void SetPixCol2(BitmapCPC dest) {
			int choix0 = 0, choix1 = 0;
			for (int y = 0; y < tailleY; y += 4) {
				int ynorm = y + 2 < tailleY ? y + 2 : y + 1;
				for (int x = 0; x < tailleX; x += Tx << 1) {
					int xnorm = x + Tx < tailleX ? x + Tx : x + 1;
					int OldDist = 0x7FFFFFFF;
					int totR = 0, totV = 0, totB = 0;
					bitmap.GetPixel(x, y, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(x, ynorm, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(xnorm, y, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(xnorm, ynorm, ref totR, ref totV, ref totB);
					totR >>= 1;
					totV >>= 1;
					totB >>= 1;
					for (int i1 = 0; i1 < MaxCol; i1++)
						for (int i2 = 0; i2 < MaxCol; i2++) {
							int sr = tabCol[i1].r + tabCol[i2].r;
							int sv = tabCol[i1].v + tabCol[i2].v;
							int sb = tabCol[i1].b + tabCol[i2].b;
							int Dist = CalcDist(sr, sv, sb, totR, totV, totB);
							if (Dist < OldDist) {
								choix0 = i1;
								choix1 = i2;
								OldDist = Dist;
								if (Dist == 0)
									i1 = i2 = MaxCol;
							}
						}
					dest.SetPixelCpc(x, y, choix0);
					dest.SetPixelCpc(xnorm, y, choix1);
					dest.SetPixelCpc(x, ynorm, choix1);
					dest.SetPixelCpc(xnorm, ynorm, choix0);
				}
			}
		}

		static void SetPixCol3(BitmapCPC dest) {
			int pos = 0;
			for (int i1 = 0; i1 < MaxCol; i1++)
				for (int i2 = 0; i2 < MaxCol; i2++)
					for (int i3 = 0; i3 < MaxCol; i3++)
						for (int i4 = 0; i4 < MaxCol; i4++) {
							int sr = tabCol[i1].r + tabCol[i2].r + tabCol[i3].r + tabCol[i4].r;
							int sv = tabCol[i1].v + tabCol[i2].v + tabCol[i3].v + tabCol[i4].v;
							int sb = tabCol[i1].b + tabCol[i2].b + tabCol[i3].b + tabCol[i4].b;
							tabMelange[pos++] = new RvbColor((byte)(sr >> 2), (byte)(sv >> 2), (byte)(sb >> 2));
						}
			int choix0 = 0, choix2 = 0, choix3 = 0, choix1 = 0;
			for (int y = 0; y < tailleY; y += 4) {
				int ynorm = y + 2 < tailleY ? y + 2 : y + 1;
				for (int x = 0; x < tailleX; x += Tx << 1) {
					int xnorm = x + Tx < tailleX ? x + Tx : x + 1;
					int OldDist = 0x7FFFFFFF;
					int totR = 0, totV = 0, totB = 0;
					bitmap.GetPixel(x, y, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(x, ynorm, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(xnorm, y, ref totR, ref totV, ref totB);
					bitmap.AddGetPixel(xnorm, ynorm, ref totR, ref totV, ref totB);
					totR >>= 2;
					totV >>= 2;
					totB >>= 2;
					pos = 0;
					for (int i1 = 0; i1 < MaxCol; i1++)
						for (int i2 = 0; i2 < MaxCol; i2++)
							for (int i3 = 0; i3 < MaxCol; i3++)
								for (int i4 = 0; i4 < MaxCol; i4++) {
									int Dist = CalcDist(tabMelange[pos++], totR, totV, totB);
									if (Dist < OldDist) {
										choix0 = i1;
										choix1 = i2;
										choix2 = i3;
										choix3 = i4;
										OldDist = Dist;
										if (Dist == 0)
											i1 = i2 = i3 = i4 = MaxCol;
									}
								}
					dest.SetPixelCpc(x, y, choix0);
					dest.SetPixelCpc(x, ynorm, choix2);
					dest.SetPixelCpc(xnorm, y, choix3);
					dest.SetPixelCpc(xnorm, ynorm, choix1);
				}
			}
		}

		//
		// Passe 2 : réduit l'image à MaxCol couleurs.
		//
		static void Passe2(BitmapCPC dest, int[] CChoix, bool CpcPlus, int PixMode) {
			for (int i = 0; i < MaxCol; i++)
				tabCol[i] = CpcPlus ? new RvbColor((byte)(((CChoix[i] & 0xF0) >> 4) * 17), (byte)(((CChoix[i] & 0xF00) >> 8) * 17), (byte)((CChoix[i] & 0x0F) * 17)) : BitmapCPC.RgbCPC[CChoix[i] < 27 ? CChoix[i] : 0];

			switch (PixMode) {
				case 1:
					SetPixCol1(dest);
					break;

				case 2:
					SetPixCol2(dest);
					break;

				case 3:
					SetPixCol3(dest);
					break;

				default:
					SetPixCol0(dest);
					break;
			}
		}

		static public void Convert(Bitmap source,
									BitmapCPC dest,
									SizeMode sizeMode,
									int methode,
									int matrice,
									int pct,
									int[] lockState,
									int pctLumi,
									int pctSat,
									int pctContrast,
									bool cpcPlus,
									bool newMethode,
									bool reductPal1,
									bool reductPal2,
									bool newReduct,
									bool sortPal,
									int pixMode) {
			int[] CChoix = new int[16];
			Tx = 4 >> (dest.ModeCPC == 3 ? 1 : dest.ModeCPC);
			MaxCol = 1 << Tx;
			for (int i = 0; i < 16; i++)
				CChoix[i] = dest.Palette[i];

			tailleX = dest.TailleX;
			tailleY = dest.TailleY;
			double ratio = source.Width * tailleY / (double)(source.Height * tailleX);
			Bitmap tmp = new Bitmap(tailleX, tailleY);
			Graphics g = Graphics.FromImage(tmp);
			switch (sizeMode) {
				case SizeMode.KeepSmaller:
					if (ratio < 1) {
						int newW = (int)(tailleX * ratio);
						g.DrawImage(source, (tailleX - newW) >> 1, 0, newW, tailleY);
					}
					else {
						int newH = (int)(tailleY / ratio);
						g.DrawImage(source, 0, (tailleY - newH) >> 1, tailleX, newH);
					}
					bitmap = new LockBitmap(tmp);
					break;

				case SizeMode.KeepLarger:
					if (ratio < 1) {
						int newY = (int)(tailleY / ratio);
						g.DrawImage(source, 0, (tailleY - newY) >> 1, tailleX, newY);
					}
					else {
						int newX = (int)(tailleX * ratio);
						g.DrawImage(source, (tailleX - newX) >> 1, 0, newX, tailleY);
					}
					bitmap = new LockBitmap(tmp);
					break;

				case SizeMode.Fit:
					bitmap = new LockBitmap(new Bitmap(source, tailleX, tailleY));
					break;
			}
			bitmap.LockBits();
			int nbCol = ConvertPasse1(tailleX, tailleY, methode, matrice, pct, cpcPlus, newMethode, dest.ModeCPC, cpcPlus, reductPal1, reductPal2, newReduct, pctLumi, pctSat, pctContrast);
			RechercheCMax(CChoix, lockState, cpcPlus, sortPal);
			Passe2(dest, CChoix, cpcPlus, pixMode);
			for (int i = 0; i < 16; i++)
				dest.SetPalette(i, CChoix[i]);
		}
	}
}
