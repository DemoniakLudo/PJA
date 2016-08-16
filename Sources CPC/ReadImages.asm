;
; Lecture image depuis disquette
; Entr�e 
; - A = num�ro d'image (0 � n-1)
;
ReadImage:
        LD      (NumVue+1),A
        LD      A,3
        LD      (RetryRead+1),A
;
ReadImage2:
;
; V�rifie identit� disquette correcte
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
        LD      A,0                     ; Num�ro d'image � lire
;
; Recherche les donn�es de la vue dans la bitmap
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
; Lecture image en fonction des donn�es de la bitmap
;
ReadImageData2:
        LD      D,(HL)                  ; Piste d�but
        INC     HL
        LD      E,(HL)                  ; Num�ro t�te
        INC     HL
        LD      C,(HL)                  ; Secteur d�but
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
        LD      (HL),B                  ; Efface les donn�es pour relecture
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




