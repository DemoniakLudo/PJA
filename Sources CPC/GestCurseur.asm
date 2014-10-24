;
; Gestion affichage et déplacement curseur
;
MovCursor:
        XOR     A
        LD      (FIPR),A
        LD      A,#09                   ; Code touche COPY
        CALL    #BB1E
        JR      NZ,SetCursorFire
        LD      A,#2F                   ; Code touche ESPACE
        CALL    #BB1E
        JR      NZ,SetCursorFire
        LD      A,#4C                   ; Code FIRE Joystick
        CALL    #BB1E
        JR      Z,TestMovCursor
SetCursorFire:
        LD      A,#FF
        LD      (FIPR),A                ; Indique validation activée
TestMovCursor:
        LD      HL,Y1
        LD      A,(Y)
        CP      (HL)                    ; Y1 <> Y ?
        JR      NZ,AffCurseur           ; Si oui, affichage
        LD      HL,X1
        LD      A,(X)
        CP      (HL)                    ; X1 <> X ?
        JP      Z,DeplHaut              ; Sinon, test déplacement
        ;
        ; Déplacement -> Affichage nouveau curseur
        ;
AffCurseur:
        LD      DE,(X)                  ; Anciennes coordonnées = nouvelles
        LD      HL,(Y)
        LD      (X1),DE
        LD      (Y1),HL
        CALL    #BC1D                   ; SCR GET POS
        PUSH    HL
        CALL    #BD19                   ; Attendre VBL
        CALL    CurseurOff              ; Restaurer image ancienne position
        POP     HL
        LD      (DrawFleche1+1),HL
        ;
        ; Sauvegarder la zone écran qui est sous le curseur
        ;
        LD      DE,BuffFleche
        LD      A,15                    ; 15 lignes à sauvegarder
SavScrCurseur2:
        LDI
        LDI
        LDI
        LD      BC,#7FD
        ADD     HL,BC
        JR      NC,SavScrCurseur3
        LD      BC,#C050
        ADD     HL,BC
SavScrCurseur3:
        DEC     A
        JR      NZ,SavScrCurseur2
        ;
        ; Calculer Adresse de zone en fonction du numéro de vue
        ;
        LD      A,(NumVue+1)
        ADD     A,A                     ; Taille pointeur = 2 octets (1 mot)
        LD      L,A
        LD      H,0
        LD      BC,PtrZone              ; Début des zones
        ADD     HL,BC
        LD      E,(HL)
        INC     HL
        LD      D,(HL)
        PUSH    DE
        POP     IX                      ; Adresse de zone dans IX
		ADD     IX,BC
        XOR     A
        LD      (TypeFleche+1),A
        LD      HL,0
        LD      (ExecFct+1),HL
        LD      HL,(X)                  ; Coordonnée X du curseur
        SRL     H
        RR      L
        SRL     L                       ; L = X/4
        ;
        ; Parcourir les zones pour aspect curseur
        ;
        LD      BC,7                    ; Taille d'une zone
BclZone:
        LD      A,(IX+0)
        AND     A                       ; Fin de zone ?
        JR      Z,DrawFleche
        LD      DE,0                    ; Servira à stocker pointeur fct
        LD      A,L                     ; A = X/4
        CP      (IX+1)                  ; XD
        JR      C,NextZone
        CP      (IX+2)                  ; XA
        JR      NC,NextZone
        LD      A,(Y)                   ; A = Y
        CP      (IX+3)                  ; YD
        JR      C,NextZone
        CP      (IX+4)                  ; YA
        JR      NC,NextZone
        LD      A,(IX+0)
        LD      (TypeFleche+1),A        ; Positionne type de curseur
        LD      D,(IX+6)
        LD      E,(IX+5)                ; DE = pointeur de fonction
        EX      DE,HL
        LD      (ExecFct+1),HL
        JR      DrawFleche              ; Inutile de continuer quand 1 zone trouvé
NextZone:
        ADD     IX,BC                   ; Pointer vers zone suivante
        JR      BclZone
        ;
DrawFleche:
        LD      DE,DataCursUtil         ; Curseur mode utilisation
        LD      A,(ModeUtil)
        AND     A
        JR      NZ,DrawFleche1
TypeFleche:
        LD      A,0                     ; Type de flèche
        AND     #03                     ; Garder seulement bits 0 et 1
        ADD     A,A
        LD      C,A
        LD      B,0
        LD      HL,PtrTypeFleche
        ADD     HL,BC
        LD      E,(HL)
        INC     HL
        LD      D,(HL)                  ; DE = buffer type de flèche (bitmap)
DrawFleche1:
        LD      HL,0                    ; HL = adresse écrand d'affichage
        ;
        ; Afficher le curseur (15 lignes de 3 colonnes = 45 octets)
        ;
AfficheCurseur:
        LD      A,(X)                   ; Faire ( X AND 3 ) * 45
        AND     3
        LD      B,A
        ADD     A,A                     ; * 2
        ADD     A,A                     ; * 4
        ADD     A,A                     ; * 8
        ADD     A,A                     ; * 16
        LD      C,A
        ADD     A,A                     ; * 32
        ADD     A,C                     ; * 48
        SUB     B
        SUB     B
        SUB     B                       ; * 45
        LD      C,A                     ; C = ( X AND 3 ) * 45
        LD      B,0
        EX      DE,HL
        ADD     HL,BC
        EX      DE,HL
        LD      B,15                    ; 15 lignes à afficher
AfficheCurseur2:
        PUSH    BC
        LD      B,3                     ; 3 colonnes à afficher
AfficheCurseur3:
        LD      A,(DE)
        LD      C,A
        RRCA
        RRCA
        RRCA
        RRCA
        OR      C                       ; Bits 0-3 | Bits 4-7 dans tous les bits
        CPL
        AND     (HL)
        OR      C
        LD      (HL),A
        INC     HL
        INC     DE
        DJNZ    AfficheCurseur3         ; Boucle pour les 3 colonnes
        LD      BC,#7FD
        ADD     HL,BC
        JR      NC,AfficheCurseur4
        LD      BC,#C050
        ADD     HL,BC
AfficheCurseur4:
        POP     BC
        DJNZ    AfficheCurseur2         ; Boucle pour les 15 lignes
DeplHaut:
        LD      A,0
        LD      (OldDeplHaut+1),A
DeplBas:
        LD      A,0
        LD      (OldDeplBas+1),A
DeplGauche:
        LD      A,0
        LD      (OldDeplGauche+1),A
DeplDroite:
        LD      A,0
        LD      (OldDeplDroite+1),A
        XOR     A                       ; Code flèche HAUT
        CALL    #BB1E
        CALL    NZ,HAUT
        LD      A,#48                   ; Code UP Joystick
        CALL    #BB1E
        CALL    NZ,HAUT

        LD      A,#02                   ; Code flèche BAS
        CALL    #BB1E
        CALL    NZ,BAS
        LD      A,#49                   ; Code DOWN Joystick
        CALL    #BB1E
        CALL    NZ,BAS

        LD      A,#01                   ; Code flèche DROITE
        CALL    #BB1E
        CALL    NZ,DROITE
        LD      A,#4B                   ; Code RIGHT Joystick
        CALL    #BB1E
        CALL    NZ,DROITE

        LD      A,#08                   ; Code flèche GAUCHE
        CALL    #BB1E
        CALL    NZ,GAUCHE
        LD      A,#4A                   ; Code LEFT Joystick
        CALL    #BB1E
        CALL    NZ,GAUCHE

        LD      HL,DeplBas+1
OldDeplBas:
        LD      A,0
        CP      (HL)                    ; Déplacement dans le même sens ?
        JR      NZ,IncDeplBas
        LD      A,1                     ; Passe la vitesse de déplacement à 1
        LD      (VitDeplBas+1),A
        LD      (HL),A
        JR      TstDeplHaut
IncDeplBas:
        CP      SeuilAcceleration       ; Atteint le seuil ?
        JR      C,TstDeplHaut           ; Sinon, test direction suivante
        LD      A,SeuilAcceleration
        LD      (HL),A
        DEC     A                       ; Si > Seul -> = Seuil
        LD      (OldDeplBas+1),A
        LD      A,2                     ; Passe la vitesse de déplacement à 2
        LD      (VitDeplBas+1),A

TstDeplHaut:
        LD      HL,DeplHaut+1
OldDeplHaut:
        LD      A,0
        CP      (HL)                    ; Déplacement dans le même sens ?
        JR      NZ,IncDeplHaut
        LD      A,1                     ; Passe la vitesse de déplacement à 1
        LD      (VitDeplHaut+1),A
        LD      (HL),A
        JR      TstDeplGauche
IncDeplHaut:
        CP      SeuilAcceleration       ; Atteint le seuil ?
        JR      C,TstDeplGauche         ; Sinon, test direction suivante
        LD      A,SeuilAcceleration
        LD      (HL),A
        DEC     A                       ; Si > Seul -> = Seuil
        LD      (OldDeplHaut+1),A
        LD      A,2                     ; Passe la vitesse de déplacement à 2
        LD      (VitDeplHaut+1),A

TstDeplGauche:
        LD      HL,DeplGauche+1
OldDeplGauche:
        LD      A,0
        CP      (HL)                    ; Déplacement dans le même sens ?
        JR      NZ,IncDeplGauche
        LD      A,1                     ; Passe la vitesse de déplacement à 1
        LD      (VitDeplGauche+1),A
        LD      (HL),A
        JR      TstDeplDroite
IncDeplGauche:
        CP      SeuilAcceleration       ; Atteint le seuil ?
        JR      C,TstDeplDroite         ; Sinon, test direction suivante
        LD      A,SeuilAcceleration
        LD      (HL),A
        DEC     A                       ; Si > Seul -> = Seuil
        LD      (OldDeplGauche+1),A
        LD      A,2                     ; Passe la vitesse de déplacement à 2
        LD      (VitDeplGauche+1),A

TstDeplDroite:
        LD      HL,DeplDroite+1
OldDeplDroite:
        LD      A,0
        CP      (HL)                    ; Déplacement dans le même sens ?
        JR      NZ,IncDeplDroite
        LD      A,1                     ; Passe la vitesse de déplacement à 1
        LD      (VitDeplDroite+1),A
        LD      (HL),A
        RET
IncDeplDroite:
        CP      SeuilAcceleration       ; Atteint le seuil ?
        RET     C                       ; Sinon, fini !
        LD      A,SeuilAcceleration
        LD      (HL),A
        DEC     A                       ; Si > Seul -> = Seuil
        LD      (OldDeplDroite+1),A
        LD      A,2                     ; Passe la vitesse de déplacement à 2
        LD      (VitDeplDroite+1),A
        RET

HAUT:
        LD      A,(Y)
        CP      196                     ; Y >= 196 ?
        RET     NC
VitDeplHaut:
        ADD     A,1
        LD      (Y),A
        LD      A,(DeplHaut+1)
        INC     A                       ; Incrémente le nombre de déplacements
        LD      (DeplHaut+1),A          ; en haut
        RET
BAS:
        LD      A,(Y)
        CP      16                      ; Y < 16 ?
        RET     C
VitDeplBas:
        SUB     1
        LD      (Y),A
        LD      A,(DeplBas+1)
        INC     A                       ; Incrémente le nombre de déplacements
        LD      (DeplBas+1),A           ; en bas
        RET
GAUCHE:
        LD      HL,(X)                  ; Position X
        LD      A,H
        AND     A
        JR      NZ,VitDeplGauche
        LD      A,L
        CP      2                       ; X < 2 ?
        RET     C
VitDeplGauche:
        LD      C,1
        LD      B,0
        SBC     HL,BC
        LD      (X),HL
        LD      A,(DeplGauche+1)
        INC     A                       ; Incrémente le nombre de déplacements
        LD      (DeplGauche+1),A        ; à gauche
        RET
DROITE:
        LD      HL,(X)                  ; Position X
        LD      A,H
        AND     A
        JR      Z,VitDeplDroite
        LD      A,L
        CP      55                      ; X >= 311 ?
        RET     NC
VitDeplDroite:
        LD      C,1
        LD      B,0
        ADD     HL,BC
        LD      (X),HL
        LD      A,(DeplDroite+1)
        INC     A                       ; Incrémente le nombre de déplacements
        LD      (DeplDroite+1),A        ; à droite
        RET

;
; Restaurer la zone écran qui était sous le curseur
;
CurseurOff:
        LD      HL,(DrawFleche1+1)
        LD      A,H
        OR      L
        RET     Z
        LD      DE,BuffFleche
        LD      A,15                    ; 15 lignes à restaurer
CurseurOff2:
        EX      DE,HL
        LDI
        LDI
        LDI
        EX      DE,HL
        LD      BC,#7FD
        ADD     HL,BC
        JR      NC,CurseurOff3
        LD      BC,#C050
        ADD     HL,BC
CurseurOff3:
        DEC     A
        JR      NZ,CurseurOff2
        RET

ExecFct:
	DW	0
ModeUtil:
	DB	0
;
; Pointeurs vers les bitmaps définissant les différents types de curseur
;
PtrTypeFleche:
        DW      DataCursFleche          ; Flèche (standard)
        DW      DataCursLoupe           ; Loupe (mode recherche sur zone trouvée)
        DW      DataCursDepl            ; Déplacement (mode recherche->issue)
        DW      DataCursUtil            ; Mode utilisation
