namespace ConvImgCpc {
	public class BitmapCPC {
		public byte[] BmpCpc = new byte[0x10000];
		//private byte[] BufTmp = new byte[0x10000];
		public int[] Palette = new int[17];
		static private int[] PaletteStandardCPC = { 1, 24, 20, 6, 26, 0, 2, 7, 10, 12, 14, 16, 18, 22, 1, 14 };
		static private int[] tabMasqueMode0 = { 0xAA, 0x55 };
		static private int[] tabMasqueMode1 = { 0x88, 0x44, 0x22, 0x11 };
		static private int[] tabMasqueMode2 = { 0x80, 0x40, 0x20, 0x10, 0x08, 0x04, 0x02, 0x01 };
		static private int[] tabOctetMode01 = { 0x00, 0x80, 0x08, 0x88, 0x20, 0xA0, 0x28, 0xA8, 0x02, 0x82, 0x0A, 0x8A, 0x22, 0xA2, 0x2A, 0xAA };
		const int MaxColsCpc = 128;
		const int maxLignesCpc = 272;

		public const int LUM0 = 0x00;
		public const int LUM1 = 0x66;
		public const int LUM2 = 0xFF;

		static public RvbColor[] RgbCPC = new RvbColor[27] { 
							new RvbColor( LUM0, LUM0, LUM0),
							new RvbColor( LUM1, LUM0, LUM0),
							new RvbColor( LUM2, LUM0, LUM0),
							new RvbColor( LUM0, LUM0, LUM1),
							new RvbColor( LUM1, LUM0, LUM1),
							new RvbColor( LUM2, LUM0, LUM1),
							new RvbColor( LUM0, LUM0, LUM2),
							new RvbColor( LUM1, LUM0, LUM2),
							new RvbColor( LUM2, LUM0, LUM2),
							new RvbColor( LUM0, LUM1, LUM0),
							new RvbColor( LUM1, LUM1, LUM0),
							new RvbColor( LUM2, LUM1, LUM0),
							new RvbColor( LUM0, LUM1, LUM1),
							new RvbColor( LUM1, LUM1, LUM1),
							new RvbColor( LUM2, LUM1, LUM1),
							new RvbColor( LUM0, LUM1, LUM2),
							new RvbColor( LUM1, LUM1, LUM2),
							new RvbColor( LUM2, LUM1, LUM2),
							new RvbColor( LUM0, LUM2, LUM0),
							new RvbColor( LUM1, LUM2, LUM0),
							new RvbColor( LUM2, LUM2, LUM0),
							new RvbColor( LUM0, LUM2, LUM1),
							new RvbColor( LUM1, LUM2, LUM1),
							new RvbColor( LUM2, LUM2, LUM1),
							new RvbColor( LUM0, LUM2, LUM2),
							new RvbColor( LUM1, LUM2, LUM2),
							new RvbColor( LUM2, LUM2, LUM2 )
							};

		public int NbCol = 80;
		public int TailleX {
			get { return NbCol << 3; }
			set { NbCol = value >> 3; }
		}
		public int NbLig = 200;
		public int TailleY {
			get { return NbLig << 1; }
			set { NbLig = value >> 1; }
		}
		public int ModeCPC = 1;
		public bool cpcPlus = false;


		//public int GetCurMode() { return (ModeCPC); }
		//public int GetNbCol() { return (NbCol); }
		//public int GetNbLig() { return (NbLig); }


		public BitmapCPC(int tx, int ty, int mode) {
			TailleX = tx;
			TailleY = ty;
			ModeCPC = mode;
			for (int i = 0; i < 16; i++)
				Palette[i] = PaletteStandardCPC[i];
		}

		public void SetPalette(int entree, int valeur) {
			Palette[entree] = valeur;
		}

		//public int GetColor(int entree) {
		//	return Palette[entree];
		//}

		public RvbColor GetPaletteColor(int col) {
			if (cpcPlus)
				return new RvbColor((byte)(((Palette[col] & 0xF0) >> 4) * 17), (byte)(((Palette[col] & 0xF00) >> 8) * 17), (byte)((Palette[col] & 0x0F) * 17));

			return RgbCPC[Palette[col] < 27 ? Palette[col] : 0];
		}

		public void SetPixelCpc(int x, int y, int col) {
			int AdrCPC = (y >> 4) * NbCol + (y & 14) * 0x400;
			if (y * NbCol > 0x7CFF)
				AdrCPC += 0x3800;

			AdrCPC += x >> 3;
			byte octet = BmpCpc[AdrCPC];
			switch (ModeCPC) {
				case 0:
					octet = (byte)(octet & ~tabMasqueMode0[(x >> 2) & 1]);
					octet = (byte)(octet | (tabOctetMode01[col & 15] >> ((x >> 2) & 1)));
					break;

				case 1:
				case 3:
					octet = (byte)(octet & ~tabMasqueMode1[(x >> 1) & 3]);
					octet = (byte)(octet | (tabOctetMode01[col & 3] >> ((x >> 1) & 3)));
					break;
				case 2:
					if ((col & 1) == 1)
						octet = (byte)(octet | tabMasqueMode2[x & 7]);
					else
						octet = (byte)(octet & ~tabMasqueMode2[x & 7]);

					break;
			}
			BmpCpc[AdrCPC] = octet;
		}

		public int GetPixelCpc(int x, int y) {
			int AdrCPC = (y >> 4) * NbCol + (y & 14) * 0x400;
			if (y * NbCol > 0x7CFF)
				AdrCPC += 0x3800;

			AdrCPC += x >> 3;
			byte octet = BmpCpc[AdrCPC];
			switch (ModeCPC) {
				case 0:
					octet = (byte)((octet & tabMasqueMode0[(x >> 2) & 1]) << ((x >> 2) & 1));
					break;

				case 1:
				case 3:
					octet = (byte)((octet & tabMasqueMode1[(x >> 1) & 3]) << ((x >> 1) & 3));
					break;

				case 2:
					octet = (byte)((octet & tabMasqueMode2[x & 7]) << (x & 7));
					break;
			}
			int Tx = 4 >> (ModeCPC == 3 ? 1 : ModeCPC);
			for (int i = 0; i < Tx; i++)
				if (octet == tabOctetMode01[i])
					return i;

			return 0;
		}

		public int GetPalCPC(int c) {
			if (cpcPlus) {
				byte b = (byte)((c & 0x0F) * 17);
				byte r = (byte)(((c & 0xF0) >> 4) * 17);
				byte v = (byte)(((c & 0xF00) >> 8) * 17);
				return (int)(r + (v << 8) + (b << 16) + 0xFF000000);
			}
			if (c < 0 || c > 26)
				c = 0;

			return RgbCPC[c].GetColor;
		}

		public LockBitmap Render(LockBitmap bmp, int Mode, bool GetPalMode) {
			int i, p0, p1, p2, p3;

			bmp.LockBits();
			if (GetPalMode)
				InitDatas(out Mode);

			for (int y = 0; y < NbLig << 1; y += 2) {
				int AdrCPC = (y >> 4) * NbCol + (y & 14) * 0x400;
				if (y * NbCol > 0x7CFF)
					AdrCPC += 0x3800;

				int xBitmap = 0;
				for (int x = 0; x < NbCol; x++) {
					byte Octet = BmpCpc[AdrCPC + x];
					switch (Mode) {
						case 0:
							p0 = (Octet >> 7) + ((Octet & 0x20) >> 3) + ((Octet & 0x08) >> 2) + ((Octet & 0x02) << 2);
							p1 = ((Octet & 0x40) >> 6) + ((Octet & 0x10) >> 2) + ((Octet & 0x04) >> 1) + ((Octet & 0x01) << 3);
							bmp.SetPixel(xBitmap, y, GetPalCPC(Palette[p0]));
							bmp.SetPixel(xBitmap + 4, y, GetPalCPC(Palette[p1]));
							xBitmap += 8;
							break;

						case 1:
						case 3:
							p0 = ((Octet >> 7) & 1) + ((Octet >> 2) & 2);
							p1 = ((Octet >> 6) & 1) + ((Octet >> 1) & 2);
							p2 = ((Octet >> 5) & 1) + ((Octet >> 0) & 2);
							p3 = ((Octet >> 4) & 1) + ((Octet << 1) & 2);
							bmp.SetPixel(xBitmap, y, GetPalCPC(Palette[p0]));
							bmp.SetPixel(xBitmap + 2, y, GetPalCPC(Palette[p1]));
							bmp.SetPixel(xBitmap + 4, y, GetPalCPC(Palette[p2]));
							bmp.SetPixel(xBitmap + 6, y, GetPalCPC(Palette[p3]));
							xBitmap += 8;
							break;

						case 2:
							for (i = 8; i-- > 0; )
								bmp.SetPixel(xBitmap++, y, GetPalCPC(Palette[(Octet >> i) & 1]));
							break;
					}
				}
			}
			LisseBitmap(bmp, NbCol << 3, NbLig << 1);
			bmp.UnlockBits();
			return bmp;
		}

		private void LisseBitmap(LockBitmap bmp, int tailleX, int tailleY) {
			int Tx = 4 >> (ModeCPC == 3 ? 1 : ModeCPC);
			for (int y = 0; y < tailleY; y += 2)
				for (int x = 0; x < tailleX; x += Tx) {
					bmp.CopyPixel(x, y, x, y, Tx);
					bmp.CopyPixel(x, y, x, y + 1, Tx);
				}
		}
		/*
				private void DepactOCP() {
					int PosIn = 0, PosOut = 0;
					int LgOut, CntBlock = 0;

					BmpCpc.CopyTo(BufTmp, 0x8000);
					while (PosOut < 0x4000) {
						if (BufTmp[PosIn] == 'M' && BufTmp[PosIn + 1] == 'J' && BufTmp[PosIn + 2] == 'H') {
							PosIn += 3;
							LgOut = BufTmp[PosIn++];
							LgOut += (BufTmp[PosIn++] << 8);
							CntBlock = 0;
							while (CntBlock < LgOut) {
								if (BufTmp[PosIn] == 'M' && BufTmp[PosIn + 1] == 'J' && BufTmp[PosIn + 2] == 'H')
									break;

								byte a = BufTmp[PosIn++];
								if (a == 1) { // MARKER_OCP
									int c = BufTmp[PosIn++];
									a = BufTmp[PosIn++];
									if (c == 0)
										c = 0x100;

									for (int i = 0; i < c && CntBlock < LgOut; i++) {
										BmpCpc[PosOut++] = a;
										CntBlock++;
									}
								}
								else {
									BmpCpc[PosOut++] = a;
									CntBlock++;
								}
							}
						}
						else
							PosOut = 0x4000;
					}
				}

				private void DepactPK() {
					byte[] Palette = new byte[0x100];

					// Valeurs par défaut
					Plus = false;
					NbCol = 80;
					NbLig = 200;

					//
					//PKSL -> 320x200 STD
					//PKS3 -> 320x200 Mode 3
					//PKSP -> 320x200 PLUS
					//PKVL -> Overscan STD
					//PKVP -> Overscan PLUS
					//

					Plus = (BmpCpc[3] == 'P') || (BmpCpc[2] == 'O');
					bool Overscan = (BmpCpc[2] == 'V') || (BmpCpc[3] == 'V');
					bool Std = (BmpCpc[2] == 'S' && BmpCpc[3] == 'L');
					if (Std)
						for (int i = 0; i < 17; i++)
							Palette[i] = BmpCpc[i + 4];

					Depack(&BmpCpc[Std ? 21 : 4], BufTmp);
					memcpy(BmpCpc, BufTmp, sizeof(BufTmp));
					ConvertScreenColBuff(BmpCpc);
					if (Overscan) {
						NbCol = MaxColsCpc;
						NbLig = maxLignesCpc;
						SetPalette(BmpCpc, 0x600, Plus);
					}
					else {
						if (Std)
							SetPalette(Palette, 0, Plus);
						else
							SetPalette(BmpCpc, 0x17D0, Plus);
					}
				}

				public bool CreateImageFile(string Nom) {
					bool Ret = false;
					byte[] Entete = new byte[0x80];
					FileStream fs = new FileStream(Nom, FileMode.Open, FileAccess.Read);
					BinaryReader br = new BinaryReader(fs);
					br.Read(Entete, 0, 0x80);
					if (FileCPC.CheckAmsdos(Entete)) {
						br.Read(BmpCpc, 0, 0x8000);
						if (!strncmp((char*)BmpCpc, "MJH", 3))
							DepactOCP(BmpCpc);
						else
							if (!strncmp((char*)BmpCpc, "PKV", 3) || !strncmp((char*)BmpCpc, "PKS", 3) || !strncmp((char*)BmpCpc, "PKO", 3)) {
								DepactPK(BmpCpc);
								GetPalMode = 0;
								memcpy(p, Palette, sizeof(Palette));
							}

						memcpy(Palette, p, sizeof(Palette));
						if (GetPalMode) {
							if (InitDatas(Mode))
								memcpy(p, Palette, sizeof(Palette));
						}

						Ret = true;
					}
					br.Close();
					return (Ret);
				}
		*/

		private bool InitDatas(out int Mode) {
			bool Ret = false;
			// Valeurs par défaut
			Mode = 1;
			cpcPlus = false;
			NbCol = 80;
			NbLig = 200;

			/*
			Si sauvegardé avec ConvImgCpc, alors la palette se trouve
			dans l'image...
			*/
			if (BmpCpc[0x7D0] == 0x3A && BmpCpc[0x7D1] == 0xD0 && BmpCpc[0x7D2] == 0xD7 && BmpCpc[0x7D3] == 0xCD) {
				// CPC OLD, écran standard
				SetPalette(BmpCpc, 0x17D0, cpcPlus);
				Mode = ModeCPC;
				Ret = true;
			}
			else
				// CPC +, écran standard
				if (BmpCpc[0x7D0] == 0xF3 && BmpCpc[0x7D1] == 0x01 && BmpCpc[0x7D2] == 0x11 && BmpCpc[0x7D3] == 0xBC) {
					cpcPlus = true;
					NbCol = 80;
					NbLig = 200;
					SetPalette(BmpCpc, 0x17D0, cpcPlus);
					Mode = ModeCPC;
					Ret = true;
				}
				else
					// CPC OLD, écran overscan
					if (BmpCpc[0x611] == 0x21 && BmpCpc[0x612] == 0x47 && BmpCpc[0x613] == 0x08 && BmpCpc[0x614] == 0xCD) {
						cpcPlus = false;
						NbCol = MaxColsCpc;
						NbLig = maxLignesCpc;
						SetPalette(BmpCpc, 0x600, cpcPlus);
						Mode = ModeCPC;
						Ret = true;
					}
					else
						// CPC +, écran overscan
						if (BmpCpc[0x621] == 0xF3 && BmpCpc[0x622] == 0x01 && BmpCpc[0x623] == 0x11 && BmpCpc[0x624] == 0xBC) {
							cpcPlus = true;
							NbCol = MaxColsCpc;
							NbLig = maxLignesCpc;
							SetPalette(BmpCpc, 0x600, cpcPlus);
							Mode = ModeCPC;
							Ret = true;
						}
			return (Ret);
		}

		private void SetPalette(byte[] PalStart, int startAdr, bool Plus) {
			ModeCPC = PalStart[startAdr] & 0x03;
			for (int i = 0; i < 16; i++)
				Palette[i] = Plus ? PalStart[startAdr + 1 + i << 1] + PalStart[startAdr + 2 + i << 1] << 8 : PalStart[i + 1];
		}
	}
}
