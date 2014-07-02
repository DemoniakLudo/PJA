;
; Entrée :
; - HL = Buffer (fichier compacté)
; - DE = Destination
; Sortie :
; - AF, BC, DE, HL modifiés
;
DepkLzw:
        XOR     A
        LD      (BclLzw+1),A            ; DepackBits = 0
;
TstBitLzw:
        LD      A,(HL)                  ; DepackBits = InBuf[ InBytes++ ]
        INC     HL
        RRA                             ; Rotation rapide calcul seulement flag C
        SET     7,A                     ; Positionne bit 7 en gardant flag C
        LD      (BclLzw+1),A
        JR      C,TstCodeLzw
CopByteLzw:
        LDI                             ; OutBuf[ OutBytes++ ] = InBuf[ InBytes++ ]
;
BclLzw:
        LD      A,0
        RR      A                       ; Rotation avec calcul Flags C et Z
        LD      (BclLzw+1),A
        JR      NC,CopByteLzw
        JR      Z,TstBitLzw

TstCodeLzw:
;
;       a = InBuf[ InBytes ];
;
        LD      A,(HL)
        AND     A
;
; Plus d'octets à traiter
; = fini
;
        RET     Z

        INC     HL
        LD      B,A                     ; B = InBuf[ InBytes ]
        RLCA                            ; A & 0x80 ?
        JR      NC,TstLzw40
;
;       Longueur = 3 + ( ( InBuf[ InBytes ] >> 4 ) & 7 );
;       Delta = ( InBuf[ InBytes++ ] & 15 ) << 8;
;       Delta |= InBuf[ InBytes++ ];
;       Delta++;
;
        RLCA
        RLCA
        RLCA
        AND     7
        ADD     A,3
        LD      C,A                     ; C = Longueur
        LD      A,B                     ; B = InBuf[InBytes]
        AND     #0F
        LD      B,A                     ; B = poids fort Delta
        LD      A,C                     ; A = Length
        LD      C,(HL)                  ; C = poids faible Delta
        PUSH    HL
        LD      H,D
        LD      L,E
        SCF                             ; Repositionner flag C
        SBC     HL,BC                   ; HL=HL-(BC+1)
        LD      B,0
        LD      C,A
        LDIR
        POP     HL
        INC     HL
        JR      BclLzw
;
TstLzw40:
        RLCA                            ; A & 0x40 ?
        JR      NC,TstLzw20
;
;       Longueur = 2;
;       Delta = InBuf[ InBytes++ ] & 0x3f;
;       Delta++;
;
        LD      C,B
        RES     6,C
        LD      B,0                     ; BC = Delta + 1 car flag C = 1
        PUSH    HL
        LD      H,D
        LD      L,E
        SBC     HL,BC
        LDI
        LDI
        POP     HL
        JR      BclLzw
;
TstLzw20:
        RLCA                            ; A & 0x20 ?
        JR      NC,TstLzw10
;
;       Longueur = 2 + ( InBuf[ InBytes++ ] & 31 );
;       Delta = InBuf[ InBytes++ ];
;       Delta++;
;
        LD      A,B
        ADD     A,#E2                   ; = ( A AND #1F ) + 2, et positionne carry
        LD      C,(HL)                  ; C = Delta
        LD      B,0
        PUSH    HL
        LD      H,D
        LD      L,E
        SBC     HL,BC
        LD      C,A                     ; C = Longueur
        LDIR
        POP     HL
        INC     HL
        JR      BclLzw

;
TstLzw10:
        RLCA                            ; A & 0x10 ?
        JR      NC,CodeLzw0F
;
;       Delta = ( InBuf[ InBytes++ ] & 15 ) << 8;
;       Delta |= InBuf[ InBytes++ ];
;       Longueur = InBuf[ InBytes++ ] + 1;
;       Delta++;
;
        RES     4,B                     ; B = Delta(high)
        LD      C,(HL)                  ; C = Delta(low)
        INC     HL
        LD      A,(HL)                  ; A = Longueur - 1
        PUSH    HL
        LD      H,D
        LD      L,E
        SBC     HL,BC                   ; Flag C=1 -> hl=hl-(bc+1)
        LD      B,0
        LD      C,A
        INC     BC                      ; BC = Longueur
        LDIR
        POP     HL
        INC     HL
        JR      BclLzw
;
CodeLzw0F:
        LD      C,(HL)
        PUSH    HL
        LD      H,D
        LD      L,E
        CP      #F0
        JR      NZ,CodeLzw02
;
;       Longueur = Delta = InBuf[ InBytes + 1 ] + 1;
;       InBytes += 2;
;
        XOR     A
        LD      B,A
        INC     BC
        SBC     HL,BC
        LDIR
        POP     HL
        INC     HL
        JP      BclLzw
;
CodeLzw02:
        CP      #20
        JR      C,CodeLzw01
;
;       Longueur = Delta = InBuf[ InBytes ];
;
        LD      C,B
        XOR     A
        LD      B,A
        SBC     HL,BC
        LDIR
        POP     HL
        JP      BclLzw
;
;       Longueur = Delta = 256;
;
CodeLzw01:                              ; Ici, B = 1
        XOR     A                       ; Carry à zéro
        LD      C,A
        DEC     H
        LDIR
        POP     HL
        JP      BclLzw
