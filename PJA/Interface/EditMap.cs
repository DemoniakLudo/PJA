using System;
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
		private int numImage = -1;
		private Map curMap;
		private EditZones editZones;

		public EditMap(Projet prj) {
			InitializeComponent();
			projet = prj;
			dataMap = prj.MapData;
			grilleX = pictureMap.Width;
			grilleY = pictureMap.Height;
			pictureMap.Image = new Bitmap(grilleX, grilleY);
			gfx = Graphics.FromImage(pictureMap.Image);
			UpdateImage();
			editZones = new EditZones(prj);
			Valid = true;
			foreach (Image img in projet.ImageData.listImg)
				listImage.Items.Add(img);
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

		private void InfoMap(int xPos, int yPos) {
			curMap = dataMap.FindMap(xPos, yPos, niveau);

			// Affiche les informations de la case en cours

			// Numéro de salle
			numCase.Text = salleRech.Text = curMap != null && curMap.TypeMap != Map.TypeCase.CASE_VIDE ? curMap.NumCase.ToString() : "";

			// Informations de déplacements
			nord.Text = curMap != null && curMap.Nord != 255 ? curMap.Nord.ToString() : "";
			sud.Text = curMap != null && curMap.Sud != 255 ? curMap.Sud.ToString() : "";
			est.Text = curMap != null && curMap.Est != 255 ? curMap.Est.ToString() : "";
			ouest.Text = curMap != null && curMap.Ouest != 255 ? curMap.Ouest.ToString() : "";
			haut.Text = curMap != null && curMap.Haut != 255 ? curMap.Haut.ToString() : "";
			bas.Text = curMap != null && curMap.Bas != 255 ? curMap.Bas.ToString() : "";

			// Informations commandes

			// Informations actions

			// Informations objets

			// Informations libellés

			// Informations image
			SetNewImage(curMap != null ? curMap.IndexImage : -1);
			bpAffecte.Enabled = bpDelVue.Enabled = curMap != null && numImage > -1;
		}


		private void pictureMap_MouseDown(object sender, MouseEventArgs e) {
			if (e.X >= 0 && e.Y >= 00 && e.X < grilleX - 1 && e.Y < grilleY - 1) {
				int xPos = e.X / (grilleX / DataMap.TAILLE_X);
				int yPos = e.Y / (grilleY / DataMap.TAILLE_Y);
				// si le bouton gauche est enfoncé, on modifie les cases de la map sous le curseur
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
					ModifCase(xPos, yPos);
				else
					if (e.Button == MouseButtons.Right)
						InfoMap(xPos, yPos);
			}
		}

		private void pictureMap_MouseMove(object sender, MouseEventArgs e) {
			if (e.X >= 0 && e.Y >= 00 && e.X < grilleX - 1 && e.Y < grilleY - 1) {
				int xPos = e.X / (grilleX / DataMap.TAILLE_X);
				int yPos = e.Y / (grilleY / DataMap.TAILLE_Y);
				// si le bouton gauche est enfoncé, on modifie les cases de la map sous le curseur
				if ((e.Button & MouseButtons.Left) == MouseButtons.Left) {
					ModifCase(xPos, yPos);
					if (!infoSurvol.Checked)
						InfoMap(xPos, yPos);
				}
				if (infoSurvol.Checked)
					InfoMap(xPos, yPos);
			}
		}

		[System.Runtime.InteropServices.DllImport("user32.dll", SetLastError = true)]
		private static extern bool SetCursorPos(int X, int Y);

		[System.Runtime.InteropServices.DllImport("user32.dll")]
		private static extern bool ClientToScreen(IntPtr hwnd, ref Point lpPoint);

		private void bpFindSalle_Click(object sender, System.EventArgs e) {
			int numSalle;
			if (int.TryParse(salleRech.Text, out numSalle)) {
				Map m = dataMap.FindMap(numSalle);
				if (m != null) {
					Point pt = new Point();
					ClientToScreen((IntPtr)pictureMap.Handle, ref pt);
					SetCursorPos(((grilleX / DataMap.TAILLE_X) >> 1) + pt.X + (m.X * grilleX / DataMap.TAILLE_X), ((grilleY / DataMap.TAILLE_Y) >> 1) + pt.Y + (m.Y * grilleY / DataMap.TAILLE_Y));
					InfoMap(m.X, m.Y);
				}
				else
					MessageBox.Show("Salle " + numSalle + " non trouvée.");
			}
		}

		private void EditMap_FormClosed(object sender, FormClosedEventArgs e) {
			bpEditZones.Checked = false;
			Valid = false;
		}

		private void SetNewImage(int index) {
			listImage.SelectedIndex = index;
			imageAffect.Text = index > -1 ? (listImage.SelectedItem as Image).ToString() : "";
			if (curMap != null)
				curMap.IndexImage = index;

			bpDelVue.Enabled = index > -1;
		}

		private void listImage_SelectedIndexChanged(object sender, System.EventArgs e) {
			numImage = listImage.SelectedIndex;
			bpAffecte.Enabled = curMap != null && numImage > -1;
			editZones.ChangeMap(curMap, listImage.SelectedItem as Image);
		}

		private void bpAffecte_Click(object sender, System.EventArgs e) {
			SetNewImage(numImage);
		}

		private void bpDelVue_Click(object sender, System.EventArgs e) {
			if (curMap.IndexImage > -1 && MessageBox.Show("Etes-vous sur(e) de vouloir supprimer cette affectation ?", "Attention", MessageBoxButtons.YesNo) == DialogResult.Yes) {
				curMap.LstZone.Clear();
				SetNewImage(-1);
			}
		}

		private void bpEditZones_CheckedChanged(object sender, EventArgs e) {
			editZones.Visible = bpEditZones.Checked;
		}
	}
}


