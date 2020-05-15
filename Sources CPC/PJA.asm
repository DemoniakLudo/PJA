        ORG     #8000
        RUN     $

BuffCp  EQU     #200
PtrZone EQU     #9000

        LD      HL,PtrZone              ; Pointeur des "zones"
        LD      DE,#200                 ; Piste 2 tête 0
        LD      BC,#08C1                ; Secteur #C1, 8 secteurs à lire
        CALL    ReadSectors

        XOR     A
BclLect:
        LD      (NumVue+1),A
        CALL    ReadImage               ; Lecture Vue
        RET     C
	LD	HL,BuffCp+#22
	LD	DE,#4000
        CALL    DepkLZW                 ; Décompacter vue en #4000
        LD      HL,BuffCp
        XOR     A
SetPal:
        INC     HL
        LD     B,(HL)
        Ld     C,B
        INC     HL
        PUSH    AF
        PUSH    HL
        CALL    #BC32
        POP     HL
        POP     AF
        INC     A
        CP      16
        JR      NZ,SetPal
        LD      C,(HL)
        INC     HL
        LD      B,C
        INC     HL
        CALL    #BC38

        LD      BC,#BC0C
        OUT    (C),C
        LD     BC,#BD10
        OUT    (C),C                    ; Afficher mémoire en #4000
        LD     HL,#4000
        LD     DE,#C000
        LD     BC,#3FD0
        LDIR                            ; Copie #4000 vers #C000
        LD     BC,#BD30
        OUT    (C),C                    ; Afficher mémoire en #C0000

        LD      HL,160                  ; Recentrer le curseur
        LD      (X),HL
        LD      A,100
        LD      (Y),A
Bcl
        LD      HL,0
        LD      (DrawFleche1+1),HL
        LD      (X1),HL                ; Forcer affichage
WaitAction

        CALL    MovCursor
        LD      A,(Fipr)
        AND     A
        JR      Z,WaitAction
        LD      A,(TypeFleche+1)
        AND     A
        JR      Z,WaitAction
        PUSH    AF
        CALL    CurseurOff
		POP     AF
        CP      2
        JR      NZ,Bcl
        LD      A,(ExecFct+1)
        JR      BclLect
        RET

        Read    "GestCurseur.asm"
        Read    "BitmapCurseur.asm"
        Read    "Structures.asm"
        Read    "ReadImages.asm"
        Read    "ReadFdc.asm"
        Read    "DepkLZW.asm"
