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
		}


		private void DessinerGrille() {
			gfx.FillRectangle(brushBlanc, pictureMap.ClientRectangle);
			for (int i = 0; i <= grilleX; i += grilleX / DataMap.TAILLE_X)
				gfx.DrawLine(penGris, 0, i, grilleX - 1, i);

			for (int i = 0; i <= grilleY; i += grilleY / DataMap.TAILLE_Y)
				gfx.DrawLine(penGris, i, 0, i, grilleY - 1);
		}

		private void DessineUneCase(Map m, Pen penCase, int xd, int yd, int xa, int ya) {
			gfx.DrawLine(m.ouest == (byte)DataMap.typeCase.CASE_VIDE ? penCase : penGris, xd, yd, xd, ya);
			gfx.DrawLine(m.sud == (byte)DataMap.typeCase.CASE_VIDE ? penCase : penGris, xd, ya, xa, ya);
			gfx.DrawLine(m.est == (byte)DataMap.typeCase.CASE_VIDE ? penCase : penGris, xa, ya, xa, yd);
			gfx.DrawLine(m.nord == (byte)DataMap.typeCase.CASE_VIDE ? penCase : penGris, xa, yd, xd, yd);
			if (m.map == DataMap.typeCase.CASE_DEPART || m.map == DataMap.typeCase.CASE_ARRIVEE)
				gfx.DrawRectangle(penCase, (xd + xa) / 2 - 1, (yd + ya) / 2 - 1, 2, 2);
		}

		private void DessinerCases() {
			int stepX = grilleX / DataMap.TAILLE_X;
			int stepY = grilleY / DataMap.TAILLE_Y;
			for (int i = 0; i < DataMap.TAILLE_X; i++)
				for (int j = 0; j < DataMap.TAILLE_Y; j++) {
					Map m = dataMap.GetMap(i, j);
					DataMap.typeCase t = (DataMap.typeCase)m.map;
					Pen p = null;
					switch (t) {
						case DataMap.typeCase.CASE_PLEINE:
							p = penNoirGras;
							break;

						case DataMap.typeCase.CASE_DEPART:
							p = penVert;
							break;

						case DataMap.typeCase.CASE_ARRIVEE:
							p = penRouge;
							break;
					}
					if (p != null)
						DessineUneCase(m, p, stepX * i, stepY * j, stepX * i + stepX, stepY * j + stepY);
				}
		}

		private void ModifCase(int xPos, int yPos) {
			DataMap.typeCase type = DataMap.typeCase.ERREUR;
			if (radioSalle.Checked)
				type = DataMap.typeCase.CASE_PLEINE;
			else
				if (radioStart.Checked)
					type = DataMap.typeCase.CASE_DEPART;
				else
					if (radioEnd.Checked)
						type = DataMap.typeCase.CASE_ARRIVEE;
					else
						if (radioGomme.Checked)
							type = DataMap.typeCase.CASE_VIDE;

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

			dataMap.ModifCase(xPos, yPos, type, autoCnx);
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
				Map m = dataMap.GetMap(xPos, yPos);

				// Affiche les informations de la case en cours

				// Numéro de salle
				numCase.Text = m.map != DataMap.typeCase.CASE_VIDE ? m.numCase.ToString() : "";

				// Informations de déplacements
				nord.Text = m.nord != 255 ? m.nord.ToString() : "";
				sud.Text = m.sud != 255 ? m.sud.ToString() : "";
				est.Text = m.est != 255 ? m.est.ToString() : "";
				ouest.Text = m.ouest != 255 ? m.ouest.ToString() : "";
				haut.Text = m.haut != 255 ? m.haut.ToString() : "";
				bas.Text = m.bas != 255 ? m.bas.ToString() : "";

				// Informations commandes

				// Informations actions

				// Informations objets

				// Informations libellés

				// si le bouton gauche est enfoncé, on modifie les cases de la map sous le curseur
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
					ModifCase(xPos, yPos);
			}
		}

		private void EditMap_FormClosed(object sender, FormClosedEventArgs e) {
			Valid = false;
		}

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		public static extern bool SetCursorPos(int X, int Y);

		private void bpFindSalle_Click(object sender, System.EventArgs e) {
			int numSalle;
			if (int.TryParse(salleRech.Text, out numSalle)) {
				int x = 0, y = 0, n = 0;
				if (dataMap.RechercheSalle(numSalle, ref x, ref y, ref n)) {
					int stepX = pictureMap.Left + Left - 4 + (x * grilleX / DataMap.TAILLE_X);
					int stepY = pictureMap.Top + Top + 10 + (y * grilleY / DataMap.TAILLE_Y);
					SetCursorPos(stepX, stepY);
				}
				else
					MessageBox.Show("Salle " + numSalle + " non trouvée.");
			}
		}

		private void bpEditVues_Click(object sender, System.EventArgs e) {
			EditVues dial = new EditVues(projet);
			dial.ShowDialog(this);
		}
	}
}


