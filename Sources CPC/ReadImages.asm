;
; Lecture image depuis disquette
; Entrée 
; - A = numéro d'image (0 à n-1)
;
ReadImage:
        LD      (NumVue+1),A
        LD      A,3
        LD      (RetryRead+1),A
;
ReadImage2:
;
; Vérifie identité disquette correcte
;
TestIdentite:
        LD      HL,InfoDisquette_Identite
        LD      DE,InfoDisquette_CheckIdentite
        LD      B,12
TestBitmapFace1:
        LD      A,(DE)
        CP      (HL)
        JR      NZ,ReadBitmap
        INC     DE
        INC     HL
        DJNZ    TestBitmapFace1
NumVue:
        LD      A,0                     ; Numéro d'image à lire
;
; Recherche les données de la vue dans la bitmap
;
        LD      HL,InfoDisquette_InfoVue
        LD      B,100
FindInfoImage:
        CP      (HL)
        INC     HL
        JR      Z,ReadImageData2
        INC     HL
        INC     HL
        INC     HL
        INC     HL
        DJNZ    FindInfoImage
        JR      ReadBitmap
;
; Lecture image en fonction des données de la bitmap
;
ReadImageData2:
        LD      D,(HL)                  ; Piste début
        INC     HL
        LD      E,(HL)                  ; Numéro tête
        INC     HL
        LD      C,(HL)                  ; Secteur début
        INC     HL
        LD      B,(HL)                  ; Nombre de secteurs
        LD      HL,BuffCp               ; Buffer de lecture
        JP      ReadSectors

;
; Lecture bitmap
;
ReadBitmap:
        LD      HL,InfoDisquette_Identite
        LD      D,H
        LD      E,L
        INC     DE
        LD      BC,#1FF
        LD      (HL),B                  ; Efface les données pour relecture
        LDIR
        LD      HL,InfoDisquette_Identite
        LD      DE,0
        LD      C,#C1
        CALL    LectSect
RetryRead:
        LD      A,3
        SUB     1
        RET     C
        LD      (RetryRead+1),A
        JR      ReadImage2




