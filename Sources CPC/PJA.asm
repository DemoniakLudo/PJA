        ORG     #8000
        RUN     $

BuffCp  EQU     #200
PtrZone EQU     #9000

        LD      HL,PtrZone
        LD      DE,#200
        LD      BC,#08C1
        CALL    ReadSectors

        XOR     A
BclLect:
        LD      (NumVue+1),A
        CALL    ReadImage
        RET     C
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
        PUSH    HL
        CALL    #BC38
        POP     HL

        LD      DE,#4000
        CALL    DepkLZW
        LD      BC,#BC0C
        OUT    (C),C
        LD     BC,#BD10
        OUT    (C),C
        LD     HL,#4000
        LD     DE,#C000
        LD     BC,#3FD0
        LDIR
        LD     BC,#BD30
        OUT    (C),C

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
