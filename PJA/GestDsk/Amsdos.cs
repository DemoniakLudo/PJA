using System;
using System.IO;
using System.Runtime.InteropServices;

namespace PJA {
	class Amsdos {
		static StrAmsdos CreeEntete(string nomFic, short start, short length, short entry) {
			StrAmsdos entete = new StrAmsdos();
			string nom = Path.GetFileName(nomFic);
			string ext = Path.GetExtension(nomFic);
			// Supprimer exension du nom
			if (ext != "")
				nom = nom.Substring(0, nom.Length - ext.Length - 1);

			// Convertir le nom du fichier au format "AMSDOS" 8.3
			string result = "";
			for (int i = 0; i < 8; i++)
				result += i < nom.Length ? nom[i] : ' ';

			for (int i = 0; i < 3; i++)
				result += i < ext.Length ? ext[i] : ' ';

			// Initialisation de l'en-tête avec les valeurs passées en paramètre
			entete.Adress = start;
			entete.Length = entete.RealLength = entete.LogicalLength = length;
			entete.FileType = 2;
			entete.EntryAdress = entry;
			entete.FileName = result;
			// Calcul du checksum
			entete.CheckSum = (short)CalcCheckSum(entete);
			return entete;
		}

		static public int CalcCheckSum(byte[] arr) {
			int checkSum = 0;
			for (int i = 0; i < 67; i++) // Checksum = somme des 67 premiers octets
				checkSum += arr[i];

			return checkSum;
		}

		static public int CalcCheckSum(StrAmsdos str) {
			int size = Marshal.SizeOf(str);
			byte[] arr = new byte[size];
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.StructureToPtr(str, ptr, true);
			Marshal.Copy(ptr, arr, 0, size);
			Marshal.FreeHGlobal(ptr);
			return CalcCheckSum(arr);
		}

		static public StrAmsdos GetAmsdos(byte[] arr) {
			StrAmsdos str = new StrAmsdos();
			int size = Marshal.SizeOf(str);
			IntPtr ptr = Marshal.AllocHGlobal(size);
			Marshal.Copy(arr, 0, ptr, size);
			str = (StrAmsdos)Marshal.PtrToStructure(ptr, typeof(StrAmsdos));
			Marshal.FreeHGlobal(ptr);
			return str;
		}

		static public bool CheckAmsdos(byte[] entete) {
			StrAmsdos enteteAms = GetAmsdos(entete);
			return CalcCheckSum(entete) == enteteAms.CheckSum;
		}
	}

	[StructLayoutAttribute(LayoutKind.Sequential, Pack = 1)]
	public struct StrAmsdos {
		//
		// Structure d'une entrée AMSDOS
		//
		public byte UserNumber;				// User
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 15)]
		public string FileName;				// Nom + extension
		public byte BlockNum;				// Numéro du premier bloc (disquette)
		public byte LastBlock;				// Numéro du dernier bloc (disquette)
		public byte FileType;				// Type de fichier
		public short Length;				// Longueur
		public short Adress;				// Adresse
		public byte FirstBlock;				// Premier bloc de fichier (disquette)
		public short LogicalLength;			// Longueur logique
		public short EntryAdress;			// Point d'entrée
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x24)]
		public string Unused;
		public short RealLength;			// Longueur réelle
		public byte BigLength;				// Longueur réelle (3 octets)
		public short CheckSum;				// CheckSum Amsdos
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 0x3B)]
		public string Unused2;
	}
}
