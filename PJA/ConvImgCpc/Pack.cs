namespace ConvImgCpc {
	class PackDepack {
		private const int SEEKBACK = 0x1000;
		private const int MAXSTRING = 256;

		private static int[] matches = new int[MAXSTRING];
		private static int[,] matchtable = new int[MAXSTRING, SEEKBACK];

		/********************************************************* !NAME! **************
		* Nom : Depack
		********************************************************** !PATHS! *************
		* !./V1!\!./V2!\!./V3!\!./V4!\Fonctions
		********************************************************** !1! *****************
		*
		* Fichier     : !./FPTH\/FLE!, ligne : !./LN!
		*
		* Description : Décompacte un buffer d'entrée (BufIn) dans un buffer de sortie
		*               (BufOut)
		*
		* Résultat    : Longueur du buffer décompacté
		*
		* Variables globales modifiées : /
		*
		********************************************************** !0! ****************/
		static public int Depack(byte[] BufIn, int startIn, byte[] BufOut) {
			byte a, DepackBits = 0;
			int Bit, InBytes = startIn, Longueur, Delta, OutBytes = 0;

			for (; ; ) {
				Bit = DepackBits & 1;
				DepackBits >>= 1;
				if (DepackBits == 0) {
					DepackBits = BufIn[InBytes++];
					Bit = DepackBits & 1;
					DepackBits >>= 1;
					DepackBits |= 0x80;
				}
				if (Bit == 0)
					BufOut[OutBytes++] = BufIn[InBytes++];
				else {
					if (BufIn[InBytes] == 0)
						break; /* EOF */

					a = BufIn[InBytes];
					if ((a & 0x80) != 0) {
						Longueur = 3 + ((BufIn[InBytes] >> 4) & 7);
						Delta = (BufIn[InBytes++] & 15) << 8;
						Delta |= BufIn[InBytes++];
						Delta++;
					}
					else
						if ((a & 0x40) != 0) {
							Longueur = 2;
							Delta = BufIn[InBytes++] & 0x3f;
							Delta++;
						}
						else
							if ((a & 0x20) != 0) {
								Longueur = 2 + (BufIn[InBytes++] & 31);
								Delta = BufIn[InBytes++];
								Delta++;
							}
							else
								if ((a & 0x10) != 0) {
									Delta = (BufIn[InBytes++] & 15) << 8;
									Delta |= BufIn[InBytes++];
									Longueur = BufIn[InBytes++] + 1;
									Delta++;
								}
								else {
									if (BufIn[InBytes] == 15) {
										Longueur = Delta = BufIn[InBytes + 1] + 1;
										InBytes += 2;
									}
									else {
										if (BufIn[InBytes] > 1)
											Longueur = Delta = BufIn[InBytes];
										else
											Longueur = Delta = 256;

										InBytes++;
									}
								}
					for (; Longueur-- > 0; ) {
						BufOut[OutBytes] = BufOut[OutBytes - Delta];
						OutBytes++;
					}
				}
			}
			return (OutBytes);
		}

		/********************************************************* !NAME! **************
		* Nom : Pack
		********************************************************** !PATHS! *************
		* !./V1!\!./V2!\!./V3!\!./V4!\Fonctions
		********************************************************** !1! *****************
		*
		* Fichier     : !./FPTH\/FLE!, ligne : !./LN!
		*
		* Description : Compacte le buffer d'entrée (BufIn) dans le buffer de sortie
		*               (BufOut)
		*
		* Résultat    : Longueur du buffer compacté
		*
		* Variables globales modifiées : /
		*
		********************************************************** !0! ****************/
		static public int Pack(byte[] BufIn, int LengthIn, byte[] BufOut) {
			byte[] codebuffer = new byte[24];
			byte bits = 0;
			int count = 0, bitcount = 0, codecount = 0;
			int matchtablestart = 0, matchtableend = 0, oldmatchtablestart;
			int start, end, max, b, c, d, LengthOut = 0;

			for (int i = 0; i < matches.Length; i++)
				matches[i] = 0;

			for (; ; ) {
				for (c = matchtableend; c < count; c++) {
					b = BufIn[c];
					matchtable[b, matches[b]] = c;
					matches[b]++;
				}
				matchtableend = count;

				if (count >= 2) {
					int stlen = 0;
					int stpos = 0;
					int stlen2 = 0;
					int bb = BufIn[count];
					for (c = matches[bb] - 1; c >= 0; c--) {
						start = matchtable[bb, c];
						end = start + MAXSTRING;
						if (end > count)
							end = count;

						max = end - start;
						if (max >= stlen) {
							for (d = 1; d < max; d++)
								if (BufIn[start + d] != BufIn[count + d])
									break;

							if ((d >= 2) && (d > stlen)) {
								stlen = d;
								stpos = count - start;
							}
							if ((d == stlen) && (count - start < stpos))
								stpos = count - start;
						}

						if ((stlen == MAXSTRING) && (stpos == stlen))
							break;
					}
					if (count + 1 < LengthIn) {
						bb = BufIn[count + 1];
						for (c = matches[bb] - 1; c >= 0; c--) {
							start = matchtable[bb, c];
							end = start + MAXSTRING;
							if (end > count + 1)
								end = count + 1;

							max = end - start;
							if (max >= stlen2) {
								for (d = 1; d < max; d++)
									if (BufIn[start + d] != BufIn[count + d + 1])
										break;

								if ((d >= 2) && (d >= stlen2))
									stlen2 = d;
							}
							if (stlen2 == MAXSTRING)
								break;
						}
						if (stlen2 - 1 > stlen)
							stlen = 0;
					}

					if (stlen > 1) {
						if ((stlen == 2) && (stpos >= MAXSTRING)) {
							codebuffer[codecount++] = BufIn[count++];
							bitcount++;
						}
						else {
							if (stpos == stlen) {
								if (stlen == MAXSTRING)
									codebuffer[codecount++] = 0x1;
								else {
									if (stlen <= 14)
										codebuffer[codecount++] = (byte)stlen;
									else {
										codebuffer[codecount++] = 0x0F;
										codebuffer[codecount++] = (byte)(stlen - 1);
									}
								}
							}
							else {
								if ((stlen == 2) && (stpos < 65))
									codebuffer[codecount++] = (byte)(0x40 + stpos - 1);
								else {
									if ((stlen <= 33) && (stpos < 257)) {
										codebuffer[codecount++] = (byte)(0x20 + stlen - 2);
										codebuffer[codecount++] = (byte)(stpos - 1);
									}
									else {
										if ((stlen >= 3) && (stlen <= 10)) {
											codebuffer[codecount++] = (byte)(0x80 + ((stlen - 3) << 4) + ((stpos - 1) >> 8));
											codebuffer[codecount++] = (byte)(stpos - 1);
										}
										else {
											codebuffer[codecount++] = (byte)(0x10 + ((stpos - 1) >> 8));
											codebuffer[codecount++] = (byte)(stpos - 1);
											codebuffer[codecount++] = (byte)(stlen - 1);
										}
									}
								}
							}
							bits = (byte)(bits | (1 << bitcount));
							bitcount++;
							count += stlen;
						}
					}
					else {
						codebuffer[codecount++] = BufIn[count++];
						bitcount++;
					}
				}
				else {
					codebuffer[codecount++] = BufIn[count++];
					bitcount++;
				}
				if (bitcount == 8) {
					BufOut[LengthOut++] = bits;
					System.Array.Copy(codebuffer, 0, BufOut, LengthOut, codecount);
					LengthOut += codecount;
					bitcount = codecount = 0;
					bits = 0;
				}
				if (count >= LengthIn)
					break;

				oldmatchtablestart = matchtablestart;
				matchtablestart = count - SEEKBACK;
				if (matchtablestart < 0)
					matchtablestart = 0;

				for (c = oldmatchtablestart; c < matchtablestart; c++) {
					b = BufIn[c];
					for (d = 0; d < matches[b]; d++)
						if (matchtable[b, d] >= matchtablestart) {
							//memmove(&matchtable[b, 0], &matchtable[b, d], (matches[b] - d) * sizeof(int));
							System.Buffer.BlockCopy(matchtable, ((b * SEEKBACK) + d) * sizeof(int), matchtable, b * SEEKBACK * sizeof(int), (matches[b] - d) * sizeof(int));
							break;
						}

					matches[b] -= d;
				}
			}
			codebuffer[codecount++] = 0;
			bits = (byte)(bits | (1 << bitcount));
			BufOut[LengthOut++] = bits;
			System.Array.Copy(codebuffer, 0, BufOut, LengthOut, codecount);
			LengthOut += codecount;
			return (LengthOut);
		}
	}
}
