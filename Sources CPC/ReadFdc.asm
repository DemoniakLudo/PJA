;
; Lecture de plusieurs secteurs
; Entrée
; - B = nombre de secteurs
; - C = premier secteur
; - D = première piste
; - E = numéro tête
; - HL = buffer de lecture
;
ReadSectors:
        PUSH    BC
        PUSH    HL
        CALL    LectSect
        POP     HL
        POP     BC
        INC     H
        INC     H
        INC     C
        LD      A,C
        CP      #CA
        JR      C,ReadNextSector
        LD      C,#C0
        INC     E
        LD      A,E
        CP      2
        JR      C,ReadNextSector
        LD      E,0
        INC     D
ReadNextSector:
        DJNZ    ReadSectors
        XOR     A                       ; Indique lecture ok
        RET

; D = track
; E = head
; C = sect
; HL = address
LectSect:
        LD      A,E
        ADD     A,A
        ADD     A,A
        LD      (Drive+1),A
        LD      (AdrLect+1),HL
        LD      A,C
        LD      (sect1+1),A
        LD      (sect2+1),A
        LD      BC,#FA7E
        LD      A,1
        OUT     (C),A
        INC     B
WaitReady:
        LD      A,4
        CALL    OutDisc
Drive:
        LD      A,0
        CALL    OutDisc
        CALL    InDisc
        LD      A,(ZoneInfoFDC)
        AND     #20
        JR      Z,WaitReady
        CALL    ReadSect
        LD      BC,#FA7E
        OUT     (C),C
        RET

ReadSect:
        LD      BC,#FB7E
        LD      A,#0F
        CALL    OutDisc
        LD      A,(Drive+1)
        CALL    OutDisc
        LD      A,D
        CALL    OutDisc
tete:
        IN      A,(C)
        JP      P,tete
teteok:
        LD      A,8
        CALL    OutDisc
        CALL    InDisc
        LD      A,(ZoneInfoFDC)
        BIT     5,A
        JR      Z,teteok
        LD      A,#46
        CALL    OutDisc
        LD      A,(Drive+1)
        CALL    OutDisc
        LD      A,D
        CALL    OutDisc
        LD      A,E
        CALL    OutDisc
sect1:
        LD      A,#C1
        CALL    OutDisc
        LD      A,2
        CALL    OutDisc
sect2:
        LD      A,#C8
        CALL    OutDisc
        LD      A,#2A
        CALL    OutDisc
        LD      A,#FF
        CALL    OutDisc
        DI
AdrLect:
        LD      HL,0
Rd:
        IN      A,(C)
        JP      P,Rd
        AND     #20
        JR      Z,InDisc
        INC     C
        INI
        INC     B
        DEC     C
        JR      Rd

OutDisc:
        EX      AF,AF'
OutD1:
        IN      A,(C)
        ADD     A,A
        JR      NC,OutD1
        ADD     A,A
        RET     C
        EX      AF,AF'
        INC     C
        OUT     (C),A
        DEC     C
        LD      A,10
OutD2:
        DEC     A
        JR      NZ,OutD2
        RET

InDisc:
        EI
        LD      HL,ZoneInfoFDC
InD1:
        IN      A,(C)
        ADD     A,A
        JR      NC,InD1
        ADD     A,A
        RET     NC
        INC     C
        INI
        INC     B
        DEC     C
        JR      InD1

ZoneInfoFDC:
        DS      7
InfoDisquette_CheckIdentite:
        DB     "#<$PJA-BITMAP>$#"
