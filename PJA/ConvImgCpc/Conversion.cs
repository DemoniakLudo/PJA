using System;
using System.Drawing;

namespace ConvImgCpc {
	public class Conversion {
		const int K_R = 9798;
		const int K_V = 19235;
		const int K_B = 3735;

		const int SEUIL_LUM_1 = 0x55;
		const int SEUIL_LUM_2 = 0xAA;

		public delegate void DlgCalcDiff(int diff, int decalMasque);
		static DlgCalcDiff fctCalcDiff = CalcDiffNone;

		static int[] Coul = new int[4096];
		static int[] corr = new int[12];
		static int tailleX, tailleY, Tx, MaxCol;
		static LockBitmap bitmap;
		static int xPix, yPix;
		static private RvbColor[] tabCol = new RvbColor[27];
		static private int k;
		public enum SizeMode { Fit, KeepSmaller, KeepLarger };

		static int MinMax(int value, int min, int max) {
			if (value <= max) {
				if (value >= min)
					return value;
				else
					return min;
			}
			else
				return max;
		}

		//
		// Retourne la couleur CPC la plus proche du pixel passé en paramètre
		//
		static private RvbColor RechercheProche(RvbColor p, bool cpcPlus, bool newMethode) {
			RvbColor choix = new RvbColor(0);
			if (cpcPlus) {
				choix.b = (byte)((p.b >> 4) * 17);
				choix.v = (byte)((p.v >> 4) * 17);
				choix.r = (byte)((p.r >> 4) * 17);
			}
			else {
				if (newMethode) {
					int OldDist1 = 0x7FFFFFFF;
					for (int i = 0; i < 27; i++) {
						RvbColor s = BitmapCPC.RgbCPC[i];
						int Dist1 = Math.Abs(s.r - p.r) * K_R + Math.Abs(s.v - p.v) * K_V + Math.Abs(s.b - p.b) * K_B;
						if (Dist1 < OldDist1) {
							OldDist1 = Dist1;
							choix = s;
							if (Dist1 == 0)
								break;
						}
					}
				}
				else {
					choix.r = (byte)(p.r > SEUIL_LUM_2 ? BitmapCPC.LUM2 : p.r > SEUIL_LUM_1 ? BitmapCPC.LUM1 : BitmapCPC.LUM0);
					choix.v = (byte)(p.v > SEUIL_LUM_2 ? BitmapCPC.LUM2 : p.v > SEUIL_LUM_1 ? BitmapCPC.LUM1 : BitmapCPC.LUM0);
					choix.b = (byte)(p.b > SEUIL_LUM_2 ? BitmapCPC.LUM2 : p.b > SEUIL_LUM_1 ? BitmapCPC.LUM1 : BitmapCPC.LUM0);
				}
			}
			return choix;
		}

		static void CalcDiffNone(int diff, int decalMasque) {
		}

		static void CalcDiffMethode1Mat2(int diff, int decalMasque) {
			corr[0] = (diff * 70) / k;
			corr[1] = (diff * 30) / k;
			corr[2] = (diff * 50) / k;
			corr[3] = (diff * 10) / k;
			AddPixelCorMat2(decalMasque);
		}

		static void CalcDiffMethode2Mat2(int diff, int decalMasque) {
			corr[0] = (diff * 40) / k;
			corr[1] = (diff * 20) / k;
			corr[2] = (diff * 10) / k;
			corr[3] = (diff * 5) / k;
			AddPixelCorMat2(decalMasque);
		}

		static void CalcDiffMethode3Mat2(int diff, int decalMasque) {
			corr[0] = corr[1] = (diff * 30) / k;
			corr[2] = (diff * 20) / k;
			corr[3] = 0;
			AddPixelCorMat2(decalMasque);
		}

		static void CalcDiffMethode1Mat3(int diff, int decalMasque) {
			corr[0] = corr[4] = (diff * 70) / k;
			corr[1] = corr[9] = corr[3] = corr[5] = (diff * 50) / k;
			corr[2] = corr[6] = corr[8] = corr[10] = (diff * 30) / k;
			corr[7] = corr[11] = (diff * 10) / k;
			AddPixelCorMat3(decalMasque);
		}

		static void CalcDiffMethode2Mat3(int diff, int decalMasque) {
			corr[0] = corr[4] = (diff * 80) / k;
			corr[1] = corr[3] = corr[5] = (diff * 40) / k;
			corr[2] = corr[6] = (diff * 20) / k;
			corr[7] = corr[8] = corr[9] = corr[10] = corr[11] = 0;
			AddPixelCorMat3(decalMasque);
		}

		static void CalcDiffMethode3Mat3(int diff, int decalMasque) {
			corr[0] = (diff * 40) / k;
			corr[1] = corr[4] = (diff * 30) / k;
			corr[2] = corr[6] = (diff * 10) / k;
			corr[3] = corr[5] = (diff * 20) / k;
			corr[7] = corr[8] = corr[9] = corr[10] = corr[11] = 0;
			AddPixelCorMat3(decalMasque);
		}

		static private void AddPixel(int x, int y, int corr, int decalMasque) {
			if (x < tailleX && y < tailleY && x >= 0) {
				int adr = 4 * ((y * bitmap.Width) + x) + decalMasque;
				bitmap.Pixels[adr] = (byte)MinMax(bitmap.Pixels[adr] + corr, 0, 255);
			}
		}

		//
		// Ajoute le tramage à un pixel donné
		//
		static private void AddPixelCorMat2(int decalMasque) {
			AddPixel(xPix + Tx, yPix, corr[0], decalMasque);

			AddPixel(xPix - Tx, yPix + 2, corr[1], decalMasque);
			AddPixel(xPix, yPix + 2, corr[2], decalMasque);
			AddPixel(xPix + Tx, yPix + 2, corr[3], decalMasque);
		}

		static private void AddPixelCorMat3(int decalMasque) {
			AddPixel(xPix + Tx, yPix, corr[0], decalMasque);
			AddPixel(xPix + 2 * Tx, yPix, corr[1], decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 2, corr[2], decalMasque);
			AddPixel(xPix - Tx, yPix + 2, corr[3], decalMasque);
			AddPixel(xPix, yPix + 2, corr[4], decalMasque);
			AddPixel(xPix + Tx, yPix + 2, corr[5], decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 2, corr[6], decalMasque);

			AddPixel(xPix - 2 * Tx, yPix + 4, corr[7], decalMasque);
			AddPixel(xPix - Tx, yPix + 4, corr[8], decalMasque);
			AddPixel(xPix, yPix + 4, corr[9], decalMasque);
			AddPixel(xPix + Tx, yPix + 4, corr[10], decalMasque);
			AddPixel(xPix + 2 * Tx, yPix + 4, corr[11], decalMasque);
		}

		//
		// Passe 1 : Réduit la palette aux x couleurs de la palette du CPC.
		// Effectue également un traitement de l'erreur (tramage) si demandé.
		//
		static private void ConvertPasse1(int xdest, int ydest, int Methode, int Matrice, int Pct, bool cpcPlus, bool newMethode, bool Nb) {
			if (cpcPlus)
				Pct <<= 2;

			fctCalcDiff = CalcDiffNone;
			if (Pct > 0)
				switch (Matrice) {
					case 2:
						switch (Methode) {
							case 1:
								fctCalcDiff = CalcDiffMethode1Mat2;
								k = 16000 / Pct;
								break;

							case 2:
								fctCalcDiff = CalcDiffMethode2Mat2;
								k = 7500 / Pct;
								break;

							case 3:
								fctCalcDiff = CalcDiffMethode3Mat2;
								k = 8000 / Pct;
								break;
						}
						break;
					case 3:
						switch (Methode) {
							case 1:
								fctCalcDiff = CalcDiffMethode1Mat3;
								k = 48000 / Pct;
								break;

							case 2:
								fctCalcDiff = CalcDiffMethode2Mat3;
								k = 32000 / Pct;
								break;

							case 3:
								fctCalcDiff = CalcDiffMethode3Mat3;
								k = 16000 / Pct;
								break;
						}
						break;
				}

			for (xPix = 0; xPix < xdest; xPix++)
				for (yPix = 0; yPix < ydest; yPix++) {
					// Lecture de la couleur du point au coordonnées (x,y)
					RvbColor p1 = bitmap.GetPixelColor(xPix, yPix);

					// Recherche le point dans la couleur cpc la plus proche
					RvbColor p2 = RechercheProche(p1, cpcPlus, newMethode);

					// Modifie composante Rouge
					fctCalcDiff(p1.r - p2.r, 0);

					// Modifie composante Verte
					fctCalcDiff(p1.v - p2.v, 1);

					// Modifie composante Bleue
					fctCalcDiff(p1.b - p2.b, 2);

					// Convertir en noir & blanc ?
					if (Nb) {
						int l = (K_R * p1.r + K_V * p1.v + K_B * p1.b) >> 15;
						p2.r = p2.v = p2.b = (byte)l;
					}
					bitmap.SetPixel(xPix, yPix, p2.GetColor);
				}
		}

		//
		// Calcule le nombre de couleurs utilisées dans l'image, et
		// remplit un tableau avec ces couleurs
		//
		static int CalcNbCoul(int Mode, bool CpcPlus, bool ReductPal1, bool ReductPal2, bool ModeReduct) {
			int i, NbCol = 0;

			for (i = 0; i < Coul.Length; i++)
				Coul[i] = 0;

			if (CpcPlus) {
				for (int y = 0; y < tailleY; y += 2)
					for (int x = 0; x < tailleX; x += Tx) {
						RvbColor c = bitmap.GetPixelColor(x, y);
						i = ((c.b >> 4) << 0) + ((c.r >> 4) << 4) + ((c.v >> 4) << 8);
						Coul[i]++;
					}
				for (i = 0; i < 4096; i++)
					if (Coul[i] > 0)
						NbCol++;

				//
				// Réduction du nombre de couleurs pour éviter les couleurs
				// trop proches
				//
				if (Mode < 3) {
					// Masquer 1 bit par composante
					for (i = 0; i < 4096; i++) {
						int c1 = (i & 0xC00) * 0xFFF / 0xC00;
						int c2 = (i & 0xC0) * 0xFF / 0xC0;
						int c3 = (i & 0x0C) * 0x0F / 0x0C;
						if (((i & 1) == 1 && ReductPal1)
						   || ((i & 1) == 0 && ReductPal2)
						   ) {
							int t = Coul[i];
							Coul[i] = 0;
							if (ModeReduct)
								Coul[(c1 & 0xF00) + (c2 & 0xF0) + (c3 & 0x0F)] += t;
							else
								Coul[(c1 & 0xC00) + (c2 & 0xC0) + (c3 & 0x0C)] += t;
						}
					}
					NbCol = 0;
					for (i = 0; i < 4096; i++)
						if (Coul[i] > 0)
							NbCol++;
				}
			}
			else {
				//
				// Cas CPC "OLD"
				//
				for (int y = 0; y < tailleY; y += 2)
					for (int x = 0; x < tailleX; x += Tx) {
						int c = bitmap.GetPixel(x, y);
						for (i = 0; i < 27; i++)
							if (c == BitmapCPC.RgbCPC[i].GetColor)
								Coul[i]++;
					}
				for (i = 0; i < 27; i++)
					if (Coul[i] > 0)
						NbCol++;
			}
			return (NbCol);
		}

		static private RvbColor GetRgbCol(int Col, bool CpcPlus, bool nb) {
			if (nb) {
				if (CpcPlus) {
					int v = ((((Col & 0xF0) >> 4) * 17) + (((Col & 0xF00) >> 8) * 17) + ((Col & 0x0F) * 17)) / 3;
					return new RvbColor((byte)(v * 17), (byte)(v * 17), (byte)(v * 17));
				}
				RvbColor c = BitmapCPC.RgbCPC[Col];
				int l = (K_R * c.r + K_V * c.v + K_B * c.b) >> 15;
				return new RvbColor((byte)l, (byte)l, (byte)l);
			}
			else {
				if (CpcPlus)
					return new RvbColor((byte)(((Col & 0xF0) >> 4) * 17), (byte)(((Col & 0xF00) >> 8) * 17), (byte)((Col & 0x0F) * 17));

				return BitmapCPC.RgbCPC[Col];
			}
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

		static void SetPixCol0(BitmapCPC dest, int[] CChoix, bool CpcPlus, bool nb) {
			for (int y = 0; y < tailleY; y += 2)
				for (int x = 0; x < tailleX; x += Tx) {
					int oldDist = 0x7FFFFFFF;
					int pix = bitmap.GetPixel(x, y);
					int r = pix & 0xFF;
					int v = (pix >> 8) & 0xFF;
					int b = (pix >> 16) & 0xFF;
					int choix = dest.GetPixelCpc(x, y);
					for (int i = 0; i < MaxCol; i++) {
						int Dist = Math.Abs(tabCol[i].r - r) * K_R + Math.Abs(tabCol[i].v - v) * K_V + Math.Abs(tabCol[i].b - b) * K_B;
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

		static void SetPixCol1(BitmapCPC dest, int[] CChoix, bool CpcPlus, bool nb) {
			for (int y = 0; y < tailleY; y += 2)
				for (int x = 0; x < tailleX; x += Tx) {
					int oldDist = 0x7FFFFFFF;
					int choix = dest.GetPixelCpc(x, y);
					int pix0 = bitmap.GetPixel(x, y);
					int pix1 = bitmap.GetPixel(x, y + 1);
					int totR = ((pix0 & 0xFF) + (pix1 & 0xFF)) >> 1;
					int totV = ((pix0 & 0xFF00) + (pix1 & 0xFF00)) >> 9;
					int totB = ((pix0 & 0xFF0000) + (pix1 & 0xFF0000)) >> 17;
					for (int i = 0; i < MaxCol; i++) {
						int Dist = Math.Abs(tabCol[i].r - totR) * K_R + Math.Abs(tabCol[i].v - totV) * K_V + Math.Abs(tabCol[i].b - totB) * K_B;
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

		static void SetPixCol2(BitmapCPC dest, int[] CChoix, bool CpcPlus, bool nb) {
			for (int y = 0; y < tailleY; y += 4) {
				int ynorm = y + 2 < tailleY ? y + 2 : y + 1;
				for (int x = 0; x < tailleX; x += Tx * 2) {
					int xnorm = x + Tx < tailleX ? x + Tx : x + 1;
					int OldDist = 0x7FFFFFFF;
					int choix0 = dest.GetPixelCpc(x, y);
					int choix1 = dest.GetPixelCpc(xnorm, ynorm);
					int pix0 = bitmap.GetPixel(x, y);
					int pix2 = bitmap.GetPixel(x, ynorm);
					int pix3 = bitmap.GetPixel(xnorm, y);
					int pix1 = bitmap.GetPixel(xnorm, ynorm);
					int totR = ((pix0 & 0xFF) + (pix1 & 0xFF) + (pix2 & 0xFF) + (pix3 & 0xFF)) >> 1;
					int totV = ((pix0 & 0xFF00) + (pix1 & 0xFF00) + (pix2 & 0xFF00) + (pix3 & 0xFF00)) >> 9;
					int totB = ((pix0 & 0xFF0000) + (pix1 & 0xFF0000) + (pix2 & 0xFF0000) + (pix3 & 0xFF0000)) >> 17;
					for (int i1 = 0; i1 < MaxCol; i1++) {
						for (int i2 = 0; i2 < MaxCol; i2++) {
							int sr = tabCol[i1].r + tabCol[i2].r;
							int sv = tabCol[i1].v + tabCol[i2].v;
							int sb = tabCol[i1].b + tabCol[i2].b;
							int Dist = Math.Abs(sr - totR) * K_R + Math.Abs(sv - totV) * K_V + Math.Abs(sb - totB) * K_B;
							if (Dist < OldDist) {
								choix0 = i1;
								choix1 = i2;
								OldDist = Dist;
								if (Dist == 0)
									i1 = i2 = MaxCol;
							}
						}
					}
					dest.SetPixelCpc(x, y, choix0);
					dest.SetPixelCpc(xnorm, ynorm, choix1);
				}
			}
		}

		static void SetPixCol3(BitmapCPC dest, int[] CChoix, bool CpcPlus, bool nb) {
			for (int y = 0; y < tailleY; y += 4) {
				int ynorm = y + 2 < tailleY ? y + 2 : y + 1;
				for (int x = 0; x < tailleX; x += Tx * 2) {
					int xnorm = x + Tx < tailleX ? x + Tx : x + 1;
					int OldDist = 0x7FFFFFFF;
					int choix0 = dest.GetPixelCpc(x, y);
					int choix2 = dest.GetPixelCpc(x, ynorm);
					int choix3 = dest.GetPixelCpc(xnorm, y);
					int choix1 = dest.GetPixelCpc(xnorm, ynorm);
					int pix0 = bitmap.GetPixel(x, y);
					int pix2 = bitmap.GetPixel(x, ynorm);
					int pix3 = bitmap.GetPixel(xnorm, y);
					int pix1 = bitmap.GetPixel(xnorm, ynorm);
					int totR = ((pix0 & 0xFF) + (pix1 & 0xFF) + (pix2 & 0xFF) + (pix3 & 0xFF));
					int totV = ((pix0 & 0xFF00) + (pix1 & 0xFF00) + (pix2 & 0xFF00) + (pix3 & 0xFF00)) >> 8;
					int totB = ((pix0 & 0xFF0000) + (pix1 & 0xFF0000) + (pix2 & 0xFF0000) + (pix3 & 0xFF0000)) >> 16;
					for (int i1 = 0; i1 < MaxCol; i1++) {
						for (int i2 = 0; i2 < MaxCol; i2++) {
							for (int i3 = 0; i3 < MaxCol; i3++) {
								for (int i4 = 0; i4 < MaxCol; i4++) {
									int sr = tabCol[i1].r + tabCol[i2].r + tabCol[i3].r + tabCol[i4].r;
									int sv = tabCol[i1].v + tabCol[i2].v + tabCol[i3].v + tabCol[i4].v;
									int sb = tabCol[i1].b + tabCol[i2].b + tabCol[i3].b + tabCol[i4].b;
									int Dist = Math.Abs(sr - totR) * K_R + Math.Abs(sv - totV) * K_V + Math.Abs(sb - totB) * K_B;
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
							}
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
		static void Passe2(BitmapCPC dest, int[] CChoix, bool CpcPlus, int PixMode, bool nb) {
			for (int i = 0; i < MaxCol; i++)
				tabCol[i] = GetRgbCol(CChoix[i], CpcPlus, nb);

			switch (PixMode) {
				case 1:
					SetPixCol1(dest, CChoix, CpcPlus, nb);
					break;

				case 2:
					SetPixCol2(dest, CChoix, CpcPlus, nb);
					break;

				case 3:
					SetPixCol3(dest, CChoix, CpcPlus, nb);
					break;

				default:
					SetPixCol0(dest, CChoix, CpcPlus, nb);
					break;
			}
		}

		static private void TraiteLumiSatCtrst(int pctLumi, int pctSat, int contrast) {
			float lumi = pctLumi / 100.0F;
			float satur = pctSat / 100.0F;
			byte[] contrast_lookup = new byte[256];
			double c = contrast / 100.0;
			for (int i = 0; i < 256; i++) {
				double newValue = (double)i;
				newValue /= 255.0;
				newValue -= 0.5;
				newValue *= c;
				newValue += 0.5;
				newValue *= 255;
				contrast_lookup[i] = (byte)MinMax((int)newValue, 0, 255);
			}
			for (int y = 0; y < bitmap.Height; y++) {
				for (int x = 0; x < bitmap.Width; x++) {
					int color = bitmap.GetPixel(x, y);
					float r = contrast_lookup[color & 255];
					float v = contrast_lookup[(color >> 8) & 255];
					float b = contrast_lookup[(color >> 16) & 255];
					if ((color & 0xFFFFFF) > 0) {
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
						else
							hue = 0;

						hue *= 255f / 360f;
						float sat = satur * (dif / max) * 255f;
						float bri = lumi * max;
						r = bri;
						v = bri;
						b = bri;
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
												else {
													r = 0;
													v = 0;
													b = 0;
												}
						}
					}
					color = MinMax((int)r, 0, 255) +
							(MinMax((int)v, 0, 255) << 8) +
							(MinMax((int)b, 0, 255) << 16);
					bitmap.SetPixel(x, y, color);
				}
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
									bool nb,
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
						g.DrawImage(source, (tailleX - newW) / 2, 0, newW, tailleY);
					}
					else {
						int newH = (int)(tailleY / ratio);
						g.DrawImage(source, 0, (tailleY - newH) / 2, tailleX, newH);
					}
					bitmap = new LockBitmap(tmp);
					break;

				case SizeMode.KeepLarger:
					if (ratio < 1) {
						int newY = (int)(tailleY / ratio);
						g.DrawImage(source, 0, (tailleY - newY) / 2, tailleX, newY);
					}
					else {
						int newX = (int)(tailleX * ratio);
						g.DrawImage(source, (tailleX - newX) / 2, 0, newX, tailleY);
					}
					bitmap = new LockBitmap(tmp);
					break;

				case SizeMode.Fit:
					bitmap = new LockBitmap(new Bitmap(source, tailleX, tailleY));
					break;
			}
			bitmap.LockBits();
			if (pctLumi != 100 || pctSat != 100 || pctContrast != 100)
				TraiteLumiSatCtrst(pctLumi, pctSat, pctContrast);

			ConvertPasse1(tailleX, tailleY, methode, matrice, pct, cpcPlus, newMethode, nb);
			int nbCol = CalcNbCoul(dest.ModeCPC, cpcPlus, reductPal1, reductPal1, newReduct);
			RechercheCMax(CChoix, lockState, cpcPlus, sortPal);
			Passe2(dest, CChoix, cpcPlus, pixMode, nb);
			for (int i = 0; i < 16; i++)
				dest.SetPalette(i, CChoix[i]);
		}
	}
}
