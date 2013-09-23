using System.Drawing;
using System.Windows.Forms;

namespace PJA {
	public partial class EditMap: Form {
		private Graphics gfx;
		private int grilleX;
		private int grilleY;
		private Pen penNoirGras = new Pen(Color.Black, 3);
		private Pen penGris = new Pen(Color.Gray);
		private Pen penVert = new Pen(Color.Green, 3);
		private Pen penRouge = new Pen(Color.Red, 3);
		private Brush brushBlanc = new SolidBrush(Color.White);
		private DataMap dataMap;
		public bool Valid;
		private Projet projet;
		private int niveau = 0; // ####

		public EditMap(Projet prj) {
			InitializeComponent();
			projet = prj;
			dataMap = prj.MapData;
			grilleX = pictureMap.Width;
			grilleY = pictureMap.Height;
			pictureMap.Image = new Bitmap(grilleX, grilleY);
			gfx = Graphics.FromImage(pictureMap.Image);
			UpdateImage();
			Valid = true;
		}

		private void UpdateImage() {
			DessinerGrille();
			DessinerCases();
			pictureMap.Refresh();
			nbSalles.Text = dataMap.NbSalles.ToString();
			curSalle.Text = dataMap.CurSalle.ToString();
			bpEditVues.Enabled = dataMap.NbSalles > 0;
		}


		private void DessinerGrille() {
			gfx.FillRectangle(brushBlanc, pictureMap.ClientRectangle);
			for (int i = 0; i <= grilleX; i += grilleX / DataMap.TAILLE_X)
				gfx.DrawLine(penGris, 0, i, grilleX - 1, i);

			for (int i = 0; i <= grilleY; i += grilleY / DataMap.TAILLE_Y)
				gfx.DrawLine(penGris, i, 0, i, grilleY - 1);
		}

		private void DessineUneCase(Map m, Pen penCase, int xd, int yd, int xa, int ya) {
			gfx.DrawLine(m.Ouest == (byte)Map.TypeCase.CASE_VIDE ? penCase : penGris, xd, yd, xd, ya);
			gfx.DrawLine(m.Sud == (byte)Map.TypeCase.CASE_VIDE ? penCase : penGris, xd, ya, xa, ya);
			gfx.DrawLine(m.Est == (byte)Map.TypeCase.CASE_VIDE ? penCase : penGris, xa, ya, xa, yd);
			gfx.DrawLine(m.Nord == (byte)Map.TypeCase.CASE_VIDE ? penCase : penGris, xa, yd, xd, yd);
			if (m.TypeMap == Map.TypeCase.CASE_DEPART || m.TypeMap == Map.TypeCase.CASE_ARRIVEE)
				gfx.DrawRectangle(penCase, (xd + xa) / 2 - 1, (yd + ya) / 2 - 1, 2, 2);
		}

		private void DessinerCases() {
			int stepX = grilleX / DataMap.TAILLE_X;
			int stepY = grilleY / DataMap.TAILLE_Y;
			foreach (Map m in dataMap.ListMap) {
				Pen p = null;
				switch (m.TypeMap) {
					case Map.TypeCase.CASE_PLEINE:
						p = penNoirGras;
						break;

					case Map.TypeCase.CASE_DEPART:
						p = penVert;
						break;

					case Map.TypeCase.CASE_ARRIVEE:
						p = penRouge;
						break;
				}
				if (p != null)
					DessineUneCase(m, p, stepX * m.X, stepY * m.Y, stepX * (m.X + 1), stepY * (m.Y + 1));
			}
		}

		private void ModifCase(int xPos, int yPos) {
			Map.TypeCase type = Map.TypeCase.ERREUR;
			if (radioSalle.Checked)
				type = Map.TypeCase.CASE_PLEINE;
			else
				if (radioStart.Checked)
					type = Map.TypeCase.CASE_DEPART;
				else
					if (radioEnd.Checked)
						type = Map.TypeCase.CASE_ARRIVEE;
					else
						if (radioGomme.Checked)
							type = Map.TypeCase.CASE_VIDE;

			DataMap.Cnx autoCnx = DataMap.Cnx.NULL;
			if (cnxHaut.Checked)
				autoCnx |= DataMap.Cnx.HAUT;
			if (cnxBas.Checked)
				autoCnx |= DataMap.Cnx.BAS;
			if (cnxNord.Checked)
				autoCnx |= DataMap.Cnx.NORD;
			if (cnxSud.Checked)
				autoCnx |= DataMap.Cnx.SUD;
			if (cnxEst.Checked)
				autoCnx |= DataMap.Cnx.EST;
			if (cnxOuest.Checked)
				autoCnx |= DataMap.Cnx.OUEST;

			dataMap.ModifCase(xPos, yPos, niveau, type, autoCnx);
			UpdateImage();
		}

		private void pictureMap_MouseUp(object sender, MouseEventArgs e) {
			if (e.X >= 0 && e.Y >= 00 && e.X < grilleX - 1 && e.Y < grilleY - 1)
				ModifCase(e.X / (grilleX / DataMap.TAILLE_X), e.Y / (grilleY / DataMap.TAILLE_Y));
		}

		private void pictureMap_MouseMove(object sender, MouseEventArgs e) {
			if (e.X >= 0 && e.Y >= 00 && e.X < grilleX - 1 && e.Y < grilleY - 1) {
				int xPos = e.X / (grilleX / DataMap.TAILLE_X);
				int yPos = e.Y / (grilleY / DataMap.TAILLE_Y);
				Map m = dataMap.FindMap(xPos, yPos, niveau);

				// Affiche les informations de la case en cours

				// Numéro de salle
				numCase.Text = m != null && m.TypeMap != Map.TypeCase.CASE_VIDE ? m.NumCase.ToString() : "";

				// Informations de déplacements
				nord.Text = m != null && m.Nord != 255 ? m.Nord.ToString() : "";
				sud.Text = m != null && m.Sud != 255 ? m.Sud.ToString() : "";
				est.Text = m != null && m.Est != 255 ? m.Est.ToString() : "";
				ouest.Text = m != null && m.Ouest != 255 ? m.Ouest.ToString() : "";
				haut.Text = m != null && m.Haut != 255 ? m.Haut.ToString() : "";
				bas.Text = m != null && m.Bas != 255 ? m.Bas.ToString() : "";

				// Informations commandes

				// Informations actions

				// Informations objets

				// Informations libellés

				// si le bouton gauche est enfoncé, on modifie les cases de la map sous le curseur
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
					ModifCase(xPos, yPos);
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetCursorPos(int X, int Y);

		private void bpFindSalle_Click(object sender, System.EventArgs e) {
			int numSalle;
			if (int.TryParse(salleRech.Text, out numSalle)) {
				Map m = dataMap.FindMap(numSalle);
				if (m != null)
					SetCursorPos(pictureMap.Left + Left - 4 + (m.X * grilleX / DataMap.TAILLE_X), pictureMap.Top + Top + 10 + (m.Y * grilleY / DataMap.TAILLE_Y));
				else
					MessageBox.Show("Salle " + numSalle + " non trouvée.");
			}
		}

		private void bpEditVues_Click(object sender, System.EventArgs e) {
			EditVues dial = new EditVues(projet);
			dial.ShowDialog(this);
		}

		private void EditMap_FormClosed(object sender, FormClosedEventArgs e) {
			Valid = false;
		}
	}
}


