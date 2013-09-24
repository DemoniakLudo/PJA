using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PJA {
	class CpcSystem {

		/*
				static void CreeEntete(FILE* fp
									  , string NomFic       // Nom du fichier
									  , short Start          // Adresse de début
									  , short Length         // Longueur
									  , short Entry          // Point d'entrée
									  )
		{
			static char Nom[ 12 ];
			int i, l, CheckSum = 0;
			char * p;

			CpcAmsdos entete = new CpcAmsdos();

			// Convertir le nom du fichie au format "AMSDOS" 8.3
			memset( Nom, ' ', sizeof( Nom ) );
			do
				{
				p = strchr( NomFic, '\\' );
				if ( p )
					NomFic = ++p;
				}
			while( p );
			p = strchr( NomFic, '.' );
			if ( p )
				* p++ = 0;

			l = strlen( NomFic );
			if ( l > 8 )
				l = 8;

			for ( i = 0; i < l; i++ )
				Nom[ i ] = ( char )( NomFic[ i ] & 0xDF );

			if ( p )
				for ( i = 0; i < 3; i++ )
					Nom[ i + 8 ] = ( char )( p[ i ] & 0xDF );

			// Initialisation de l'en-tête avec les valeurs passées en paramètre
			memcpy( Entete.FileName, Nom, 11 );
			byte * pEntete = ( byte * )&Entete;
			entete.Adress = Start;
			entete.Length = entete.RealLength = entete.LogicalLength = Length;
			entete.FileType = 2;
			entete.EntryAdress = Entry;

			// Calcul du checksum
			for ( i = 0; i < 67; i++ )
				CheckSum += * pEntete++;

			Entete.CheckSum = ( WORD )CheckSum;
			fwrite( &Entete, sizeof( Entete ), 1, fp );
		}
		*/

		private int CalcCheckSum(CpcAmsdos str) {
			int checkSum = 0;

			int size = Marshal.SizeOf(str);
			byte[] arr = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);

			Marshal.StructureToPtr(str, ptr, true);
			Marshal.Copy(ptr, arr, 0, size);
			Marshal.FreeHGlobal(ptr);
			for (int i = 0; i < 67; i++)
				checkSum += arr[i];

			return checkSum;
		}
	}



	[StructLayoutAttribute(LayoutKind.Sequential)]
	struct CpcAmsdos {
		//
		// Structure d'une entrée AMSDOS
		//
		public byte UserNumber;				// User
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
		public string FileName;	// Nom + extension
		public byte BlockNum;					// Numéro du premier bloc (disquette)
		public byte LastBlock;					// Numéro du dernier bloc (disquette)
		public byte FileType;					// Type de fichier
		public short Length;					// Longueur
		public short Adress;					// Adresse
		public byte FirstBlock;				// Premier bloc de fichier (disquette)
		public short LogicalLength;			// Longueur logique
		public short EntryAdress;				// Point d'entrée
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x24)]
		public string Unused;
		public short RealLength;				// Longueur réelle
		public byte BigLength;					// Longueur réelle (3 octets)
		public short CheckSum;					// CheckSum Amsdos
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x3B)]
		public string Unused2;
	}
}
