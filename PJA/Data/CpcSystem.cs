using System;
using System.Collections.Generic;
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


	}

	class CpcAmsdos {
		//
		// Structure d'une entrée AMSDOS
		//
		public byte UserNumber;				// User
		public char[] FileName = new char[15];	// Nom + extension
		public byte BlockNum;					// Numéro du premier bloc (disquette)
		public byte LastBlock;					// Numéro du dernier bloc (disquette)
		public byte FileType;					// Type de fichier
		public short Length;					// Longueur
		public short Adress;					// Adresse
		public byte FirstBlock;				// Premier bloc de fichier (disquette)
		public short LogicalLength;			// Longueur logique
		public short EntryAdress;				// Point d'entrée
		public byte[] Unused = new byte[0x24];
		public short RealLength;				// Longueur réelle
		public byte BigLength;					// Longueur réelle (3 octets)
		public short CheckSum;					// CheckSum Amsdos
		public byte[] Unused2 = new byte[0x3B];
	}
}
