namespace ConvImgCpc {
	class Pack {
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
	}
}
