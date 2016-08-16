BuffFleche          EQU     #C7D0       ; Buffer sauvegarde sprite sous fl�che
                                        ; (45 octets n�cessaires)

SeuilAcceleration   EQU     30          ; Seuil acc�l�ration curseur en nombre
                                        ; de d�placements simultan�s

;
; Structure du secteur de d�finition de la face d'une disquette
;
InfoDisquette_Identite:
        DS      16
InfoDisquette_InfoVue:
        DS      512-16


; ########################
; ## Variables internes ##
; ########################

;
; Variables de taille de fen�tre
;
XD:
        DB      0
YD:
        DB      0
XA:
        DB      0
YA:
        DB      0

;
; Variables gestion curseur
;
FIPR:
        DB      0
X:
        DW      0
Y:
        DW      0
X1:
        DW      0
Y1:
        DW      0

;
; Variables du jeu
;

JoueurPerdu:
        DB      0                       ; Joueur a perdu ?
PerdVie:
        DB      0                       ; Joueur perd une vie ?
NouvelleVue:
        DB      0                       ; Nouvelle vue charg�e ?

Ink1:
        RRCA
        ADD     HL,BC
        ADD     HL,DE

SauveInk:
        RRCA
        ADD     HL,BC
        ADD     HL,DE
