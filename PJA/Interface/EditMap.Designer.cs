namespace PJA {
	partial class EditMap {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.pictureMap = new System.Windows.Forms.PictureBox();
			this.radioSalle = new System.Windows.Forms.RadioButton();
			this.radioStart = new System.Windows.Forms.RadioButton();
			this.radioEnd = new System.Windows.Forms.RadioButton();
			this.radioGomme = new System.Windows.Forms.RadioButton();
			this.numCase = new System.Windows.Forms.TextBox();
			this.nord = new System.Windows.Forms.TextBox();
			this.sud = new System.Windows.Forms.TextBox();
			this.est = new System.Windows.Forms.TextBox();
			this.ouest = new System.Windows.Forms.TextBox();
			this.haut = new System.Windows.Forms.TextBox();
			this.bas = new System.Windows.Forms.TextBox();
			this.cnxNord = new System.Windows.Forms.CheckBox();
			this.cnxSud = new System.Windows.Forms.CheckBox();
			this.cnxEst = new System.Windows.Forms.CheckBox();
			this.cnxOuest = new System.Windows.Forms.CheckBox();
			this.cnxHaut = new System.Windows.Forms.CheckBox();
			this.cnxBas = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.nbSalles = new System.Windows.Forms.TextBox();
			this.curSalle = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.bpFindSalle = new System.Windows.Forms.Button();
			this.salleRech = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureMap)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureMap
			// 
			this.pictureMap.Location = new System.Drawing.Point(35, 21);
			this.pictureMap.Name = "pictureMap";
			this.pictureMap.Size = new System.Drawing.Size(513, 513);
			this.pictureMap.TabIndex = 0;
			this.pictureMap.TabStop = false;
			this.pictureMap.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureMap_MouseMove);
			this.pictureMap.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureMap_MouseUp);
			// 
			// radioSalle
			// 
			this.radioSalle.AutoSize = true;
			this.radioSalle.Location = new System.Drawing.Point(595, 44);
			this.radioSalle.Name = "radioSalle";
			this.radioSalle.Size = new System.Drawing.Size(48, 17);
			this.radioSalle.TabIndex = 1;
			this.radioSalle.TabStop = true;
			this.radioSalle.Text = "Salle";
			this.radioSalle.UseVisualStyleBackColor = true;
			// 
			// radioStart
			// 
			this.radioStart.AutoSize = true;
			this.radioStart.Location = new System.Drawing.Point(595, 67);
			this.radioStart.Name = "radioStart";
			this.radioStart.Size = new System.Drawing.Size(96, 17);
			this.radioStart.TabIndex = 1;
			this.radioStart.TabStop = true;
			this.radioStart.Text = "Salle de départ";
			this.radioStart.UseVisualStyleBackColor = true;
			// 
			// radioEnd
			// 
			this.radioEnd.AutoSize = true;
			this.radioEnd.Location = new System.Drawing.Point(595, 90);
			this.radioEnd.Name = "radioEnd";
			this.radioEnd.Size = new System.Drawing.Size(91, 17);
			this.radioEnd.TabIndex = 1;
			this.radioEnd.TabStop = true;
			this.radioEnd.Text = "Salle d\'arrivée";
			this.radioEnd.UseVisualStyleBackColor = true;
			// 
			// radioGomme
			// 
			this.radioGomme.AutoSize = true;
			this.radioGomme.Location = new System.Drawing.Point(595, 113);
			this.radioGomme.Name = "radioGomme";
			this.radioGomme.Size = new System.Drawing.Size(59, 17);
			this.radioGomme.TabIndex = 1;
			this.radioGomme.TabStop = true;
			this.radioGomme.Text = "Effacer";
			this.radioGomme.UseVisualStyleBackColor = true;
			// 
			// numCase
			// 
			this.numCase.Location = new System.Drawing.Point(671, 186);
			this.numCase.Name = "numCase";
			this.numCase.ReadOnly = true;
			this.numCase.Size = new System.Drawing.Size(48, 20);
			this.numCase.TabIndex = 2;
			// 
			// nord
			// 
			this.nord.Location = new System.Drawing.Point(671, 212);
			this.nord.Name = "nord";
			this.nord.ReadOnly = true;
			this.nord.Size = new System.Drawing.Size(48, 20);
			this.nord.TabIndex = 2;
			// 
			// sud
			// 
			this.sud.Location = new System.Drawing.Point(671, 238);
			this.sud.Name = "sud";
			this.sud.ReadOnly = true;
			this.sud.Size = new System.Drawing.Size(48, 20);
			this.sud.TabIndex = 2;
			// 
			// est
			// 
			this.est.Location = new System.Drawing.Point(671, 264);
			this.est.Name = "est";
			this.est.ReadOnly = true;
			this.est.Size = new System.Drawing.Size(48, 20);
			this.est.TabIndex = 2;
			// 
			// ouest
			// 
			this.ouest.Location = new System.Drawing.Point(671, 290);
			this.ouest.Name = "ouest";
			this.ouest.ReadOnly = true;
			this.ouest.Size = new System.Drawing.Size(48, 20);
			this.ouest.TabIndex = 2;
			// 
			// haut
			// 
			this.haut.Location = new System.Drawing.Point(671, 316);
			this.haut.Name = "haut";
			this.haut.ReadOnly = true;
			this.haut.Size = new System.Drawing.Size(48, 20);
			this.haut.TabIndex = 2;
			// 
			// bas
			// 
			this.bas.Location = new System.Drawing.Point(671, 342);
			this.bas.Name = "bas";
			this.bas.ReadOnly = true;
			this.bas.Size = new System.Drawing.Size(48, 20);
			this.bas.TabIndex = 2;
			// 
			// cnxNord
			// 
			this.cnxNord.AutoSize = true;
			this.cnxNord.Checked = true;
			this.cnxNord.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cnxNord.Location = new System.Drawing.Point(725, 215);
			this.cnxNord.Name = "cnxNord";
			this.cnxNord.Size = new System.Drawing.Size(101, 17);
			this.cnxNord.TabIndex = 3;
			this.cnxNord.Text = "Connexion Auto";
			this.cnxNord.UseVisualStyleBackColor = true;
			// 
			// cnxSud
			// 
			this.cnxSud.AutoSize = true;
			this.cnxSud.Checked = true;
			this.cnxSud.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cnxSud.Location = new System.Drawing.Point(725, 241);
			this.cnxSud.Name = "cnxSud";
			this.cnxSud.Size = new System.Drawing.Size(101, 17);
			this.cnxSud.TabIndex = 3;
			this.cnxSud.Text = "Connexion Auto";
			this.cnxSud.UseVisualStyleBackColor = true;
			// 
			// cnxEst
			// 
			this.cnxEst.AutoSize = true;
			this.cnxEst.Checked = true;
			this.cnxEst.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cnxEst.Location = new System.Drawing.Point(725, 267);
			this.cnxEst.Name = "cnxEst";
			this.cnxEst.Size = new System.Drawing.Size(101, 17);
			this.cnxEst.TabIndex = 3;
			this.cnxEst.Text = "Connexion Auto";
			this.cnxEst.UseVisualStyleBackColor = true;
			// 
			// cnxOuest
			// 
			this.cnxOuest.AutoSize = true;
			this.cnxOuest.Checked = true;
			this.cnxOuest.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cnxOuest.Location = new System.Drawing.Point(725, 293);
			this.cnxOuest.Name = "cnxOuest";
			this.cnxOuest.Size = new System.Drawing.Size(101, 17);
			this.cnxOuest.TabIndex = 3;
			this.cnxOuest.Text = "Connexion Auto";
			this.cnxOuest.UseVisualStyleBackColor = true;
			// 
			// cnxHaut
			// 
			this.cnxHaut.AutoSize = true;
			this.cnxHaut.Location = new System.Drawing.Point(725, 318);
			this.cnxHaut.Name = "cnxHaut";
			this.cnxHaut.Size = new System.Drawing.Size(101, 17);
			this.cnxHaut.TabIndex = 3;
			this.cnxHaut.Text = "Connexion Auto";
			this.cnxHaut.UseVisualStyleBackColor = true;
			// 
			// cnxBas
			// 
			this.cnxBas.AutoSize = true;
			this.cnxBas.Location = new System.Drawing.Point(725, 345);
			this.cnxBas.Name = "cnxBas";
			this.cnxBas.Size = new System.Drawing.Size(101, 17);
			this.cnxBas.TabIndex = 3;
			this.cnxBas.Text = "Connexion Auto";
			this.cnxBas.UseVisualStyleBackColor = true;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(576, 189);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 4;
			this.label1.Text = "Numéro de salle :";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(576, 215);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(36, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Nord :";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(576, 241);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(32, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Sud :";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(576, 267);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(28, 13);
			this.label4.TabIndex = 4;
			this.label4.Text = "Est :";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(576, 293);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(41, 13);
			this.label5.TabIndex = 4;
			this.label5.Text = "Ouest :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(576, 319);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(36, 13);
			this.label6.TabIndex = 4;
			this.label6.Text = "Haut :";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(576, 342);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(31, 13);
			this.label7.TabIndex = 4;
			this.label7.Text = "Bas :";
			// 
			// nbSalles
			// 
			this.nbSalles.Location = new System.Drawing.Point(816, 41);
			this.nbSalles.Name = "nbSalles";
			this.nbSalles.ReadOnly = true;
			this.nbSalles.Size = new System.Drawing.Size(48, 20);
			this.nbSalles.TabIndex = 2;
			// 
			// curSalle
			// 
			this.curSalle.Location = new System.Drawing.Point(816, 67);
			this.curSalle.Name = "curSalle";
			this.curSalle.ReadOnly = true;
			this.curSalle.Size = new System.Drawing.Size(48, 20);
			this.curSalle.TabIndex = 2;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(722, 46);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(94, 13);
			this.label8.TabIndex = 4;
			this.label8.Text = "Nombre de salles :";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(722, 70);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 13);
			this.label9.TabIndex = 4;
			this.label9.Text = "Salle en cours :";
			// 
			// bpFindSalle
			// 
			this.bpFindSalle.Location = new System.Drawing.Point(717, 107);
			this.bpFindSalle.Name = "bpFindSalle";
			this.bpFindSalle.Size = new System.Drawing.Size(99, 23);
			this.bpFindSalle.TabIndex = 5;
			this.bpFindSalle.Text = "Rechercher salle";
			this.bpFindSalle.UseVisualStyleBackColor = true;
			this.bpFindSalle.Click += new System.EventHandler(this.bpFindSalle_Click);
			// 
			// salleRech
			// 
			this.salleRech.Location = new System.Drawing.Point(822, 109);
			this.salleRech.Name = "salleRech";
			this.salleRech.Size = new System.Drawing.Size(42, 20);
			this.salleRech.TabIndex = 6;
			// 
			// EditMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(876, 637);
			this.Controls.Add(this.salleRech);
			this.Controls.Add(this.bpFindSalle);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cnxBas);
			this.Controls.Add(this.cnxHaut);
			this.Controls.Add(this.cnxOuest);
			this.Controls.Add(this.cnxEst);
			this.Controls.Add(this.cnxSud);
			this.Controls.Add(this.cnxNord);
			this.Controls.Add(this.bas);
			this.Controls.Add(this.haut);
			this.Controls.Add(this.ouest);
			this.Controls.Add(this.est);
			this.Controls.Add(this.curSalle);
			this.Controls.Add(this.sud);
			this.Controls.Add(this.nbSalles);
			this.Controls.Add(this.nord);
			this.Controls.Add(this.numCase);
			this.Controls.Add(this.radioGomme);
			this.Controls.Add(this.radioEnd);
			this.Controls.Add(this.radioStart);
			this.Controls.Add(this.radioSalle);
			this.Controls.Add(this.pictureMap);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditMap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "EditMap";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditMap_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureMap)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureMap;
		private System.Windows.Forms.RadioButton radioSalle;
		private System.Windows.Forms.RadioButton radioStart;
		private System.Windows.Forms.RadioButton radioEnd;
		private System.Windows.Forms.RadioButton radioGomme;
		private System.Windows.Forms.TextBox numCase;
		private System.Windows.Forms.TextBox nord;
		private System.Windows.Forms.TextBox sud;
		private System.Windows.Forms.TextBox est;
		private System.Windows.Forms.TextBox ouest;
		private System.Windows.Forms.TextBox haut;
		private System.Windows.Forms.TextBox bas;
		private System.Windows.Forms.CheckBox cnxNord;
		private System.Windows.Forms.CheckBox cnxSud;
		private System.Windows.Forms.CheckBox cnxEst;
		private System.Windows.Forms.CheckBox cnxOuest;
		private System.Windows.Forms.CheckBox cnxHaut;
		private System.Windows.Forms.CheckBox cnxBas;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox nbSalles;
		private System.Windows.Forms.TextBox curSalle;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Button bpFindSalle;
		private System.Windows.Forms.TextBox salleRech;
	}
}