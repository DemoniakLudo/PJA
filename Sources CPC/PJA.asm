        ORG     #8000
        RUN     $

BuffCp  EQU     #4000
PtrZone EQU     #2000

        LD      HL,PtrZone
        LD      DE,#200
        LD      BC,#10C0
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
        LD      DE,#C000
        CALL    DepkLZW

        LD      HL,160                  ; Recentrer le curseur
        LD      (X),HL
        LD      A,100
        LD      (Y),A
Bcl
        CALL    CurseurOn
WaitAction

        CALL    MovCursor
        LD      A,(Fipr)
        AND     A
        JR      Z,WaitAction
        CALL    CurseurOff
        LD      A,(TypeFleche+1)
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
