        ORG     #8000
        RUN     $

BuffCp  EQU     #4000

        LD      A,(IX+0)
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
        RET

        Read    "ReadImages.asm"
        Read    "DepkLZW.asm"
