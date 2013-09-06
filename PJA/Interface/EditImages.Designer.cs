namespace PJA {
	partial class EditImages {
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
			this.lockAllPal = new System.Windows.Forms.CheckBox();
			this.bpImport = new System.Windows.Forms.Button();
			this.radioFit = new System.Windows.Forms.RadioButton();
			this.radioKeepSmaller = new System.Windows.Forms.RadioButton();
			this.radioKeepLarger = new System.Windows.Forms.RadioButton();
			this.tramage = new System.Windows.Forms.GroupBox();
			this.label6 = new System.Windows.Forms.Label();
			this.methode = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.matrice = new System.Windows.Forms.ComboBox();
			this.label5 = new System.Windows.Forms.Label();
			this.pctTrame = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.renderMode = new System.Windows.Forms.ComboBox();
			this.listImage = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.imageName = new System.Windows.Forms.TextBox();
			this.bpRecalc = new System.Windows.Forms.Button();
			this.bpEdit = new System.Windows.Forms.Button();
			this.bpSuppr = new System.Windows.Forms.Button();
			this.bpAdd = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.bpRazSat = new System.Windows.Forms.Button();
			this.bpRazLumi = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.sat = new System.Windows.Forms.TrackBar();
			this.lumi = new System.Windows.Forms.TrackBar();
			this.autoRecalc = new System.Windows.Forms.CheckBox();
			this.sortPal = new System.Windows.Forms.CheckBox();
			this.contrast = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.bpRazContrast = new System.Windows.Forms.Button();
			this.bpDn = new System.Windows.Forms.Button();
			this.bpUp = new System.Windows.Forms.Button();
			this.bpSavePal = new System.Windows.Forms.Button();
			this.bpLoadPal = new System.Windows.Forms.Button();
			this.newMethode = new System.Windows.Forms.CheckBox();
			this.nb = new System.Windows.Forms.CheckBox();
			this.bpPredefPal = new System.Windows.Forms.Button();
			this.lblTps = new System.Windows.Forms.Label();
			this.bpPixel = new System.Windows.Forms.Button();
			this.tramage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctTrame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lumi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contrast)).BeginInit();
			this.SuspendLayout();
			// 
			// lockAllPal
			// 
			this.lockAllPal.AutoSize = true;
			this.lockAllPal.Location = new System.Drawing.Point(784, 600);
			this.lockAllPal.Name = "lockAllPal";
			this.lockAllPal.Size = new System.Drawing.Size(93, 17);
			this.lockAllPal.TabIndex = 1;
			this.lockAllPal.Text = "Tout vérouiller";
			this.lockAllPal.UseVisualStyleBackColor = true;
			this.lockAllPal.CheckedChanged += new System.EventHandler(this.lockAllPal_CheckedChanged);
			// 
			// bpImport
			// 
			this.bpImport.Location = new System.Drawing.Point(784, 0);
			this.bpImport.Name = "bpImport";
			this.bpImport.Size = new System.Drawing.Size(93, 23);
			this.bpImport.TabIndex = 2;
			this.bpImport.Text = "Importer image";
			this.bpImport.UseVisualStyleBackColor = true;
			this.bpImport.Click += new System.EventHandler(this.bpImport_Click);
			// 
			// radioFit
			// 
			this.radioFit.AutoSize = true;
			this.radioFit.Location = new System.Drawing.Point(784, 29);
			this.radioFit.Name = "radioFit";
			this.radioFit.Size = new System.Drawing.Size(36, 17);
			this.radioFit.TabIndex = 3;
			this.radioFit.TabStop = true;
			this.radioFit.Text = "Fit";
			this.radioFit.UseVisualStyleBackColor = true;
			this.radioFit.CheckedChanged += new System.EventHandler(this.radioFit_CheckedChanged);
			// 
			// radioKeepSmaller
			// 
			this.radioKeepSmaller.AutoSize = true;
			this.radioKeepSmaller.Location = new System.Drawing.Point(784, 52);
			this.radioKeepSmaller.Name = "radioKeepSmaller";
			this.radioKeepSmaller.Size = new System.Drawing.Size(84, 17);
			this.radioKeepSmaller.TabIndex = 3;
			this.radioKeepSmaller.TabStop = true;
			this.radioKeepSmaller.Text = "KeepSmaller";
			this.radioKeepSmaller.UseVisualStyleBackColor = true;
			this.radioKeepSmaller.CheckedChanged += new System.EventHandler(this.radioKeepSmaller_CheckedChanged);
			// 
			// radioKeepLarger
			// 
			this.radioKeepLarger.AutoSize = true;
			this.radioKeepLarger.Location = new System.Drawing.Point(784, 75);
			this.radioKeepLarger.Name = "radioKeepLarger";
			this.radioKeepLarger.Size = new System.Drawing.Size(80, 17);
			this.radioKeepLarger.TabIndex = 3;
			this.radioKeepLarger.TabStop = true;
			this.radioKeepLarger.Text = "KeepLarger";
			this.radioKeepLarger.UseVisualStyleBackColor = true;
			this.radioKeepLarger.CheckedChanged += new System.EventHandler(this.radioKeepLarger_CheckedChanged);
			// 
			// tramage
			// 
			this.tramage.Controls.Add(this.label6);
			this.tramage.Controls.Add(this.methode);
			this.tramage.Controls.Add(this.label7);
			this.tramage.Controls.Add(this.matrice);
			this.tramage.Controls.Add(this.label5);
			this.tramage.Controls.Add(this.pctTrame);
			this.tramage.Controls.Add(this.label4);
			this.tramage.Controls.Add(this.renderMode);
			this.tramage.Location = new System.Drawing.Point(784, 111);
			this.tramage.Name = "tramage";
			this.tramage.Size = new System.Drawing.Size(203, 129);
			this.tramage.TabIndex = 12;
			this.tramage.TabStop = false;
			this.tramage.Text = "Tramage";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(173, 48);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(15, 13);
			this.label6.TabIndex = 12;
			this.label6.Text = "%";
			// 
			// methode
			// 
			this.methode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.methode.FormattingEnabled = true;
			this.methode.Items.AddRange(new object[] {
            "Pas de tramage",
            "Méthode 1",
            "Méthode 2",
            "Méthode 3"});
			this.methode.Location = new System.Drawing.Point(92, 19);
			this.methode.Name = "methode";
			this.methode.Size = new System.Drawing.Size(97, 21);
			this.methode.TabIndex = 8;
			this.methode.SelectedIndexChanged += new System.EventHandler(this.methode_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(9, 104);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(83, 13);
			this.label7.TabIndex = 12;
			this.label7.Text = "Niveau Forçage";
			// 
			// matrice
			// 
			this.matrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.matrice.FormattingEnabled = true;
			this.matrice.Items.AddRange(new object[] {
            "Matrice 2x2",
            "Matrice 3x3"});
			this.matrice.Location = new System.Drawing.Point(92, 72);
			this.matrice.Name = "matrice";
			this.matrice.Size = new System.Drawing.Size(97, 21);
			this.matrice.TabIndex = 8;
			this.matrice.SelectedIndexChanged += new System.EventHandler(this.matrice_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(50, 75);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Matrice";
			// 
			// pctTrame
			// 
			this.pctTrame.Location = new System.Drawing.Point(92, 46);
			this.pctTrame.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.pctTrame.Name = "pctTrame";
			this.pctTrame.Size = new System.Drawing.Size(70, 20);
			this.pctTrame.TabIndex = 9;
			this.pctTrame.ValueChanged += new System.EventHandler(this.pctTrame_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(50, 22);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 12;
			this.label4.Text = "Type";
			// 
			// renderMode
			// 
			this.renderMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.renderMode.FormattingEnabled = true;
			this.renderMode.Items.AddRange(new object[] {
            "Aucun",
            "Niveau 1",
            "Niveau 2",
            "Niveau 3"});
			this.renderMode.Location = new System.Drawing.Point(92, 101);
			this.renderMode.Name = "renderMode";
			this.renderMode.Size = new System.Drawing.Size(97, 21);
			this.renderMode.TabIndex = 10;
			this.renderMode.SelectedIndexChanged += new System.EventHandler(this.renderMode_SelectedIndexChanged);
			// 
			// listImage
			// 
			this.listImage.FormattingEnabled = true;
			this.listImage.Location = new System.Drawing.Point(784, 246);
			this.listImage.Name = "listImage";
			this.listImage.Size = new System.Drawing.Size(242, 212);
			this.listImage.TabIndex = 13;
			this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(781, 467);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Nom:";
			// 
			// imageName
			// 
			this.imageName.Location = new System.Drawing.Point(819, 464);
			this.imageName.Name = "imageName";
			this.imageName.Size = new System.Drawing.Size(225, 20);
			this.imageName.TabIndex = 16;
			// 
			// bpRecalc
			// 
			this.bpRecalc.Location = new System.Drawing.Point(894, 0);
			this.bpRecalc.Name = "bpRecalc";
			this.bpRecalc.Size = new System.Drawing.Size(93, 23);
			this.bpRecalc.TabIndex = 2;
			this.bpRecalc.Text = "Recalculer";
			this.bpRecalc.UseVisualStyleBackColor = true;
			this.bpRecalc.Click += new System.EventHandler(this.bpRecalc_Click);
			// 
			// bpEdit
			// 
			this.bpEdit.Image = global::PJA.Properties.Resources.Edit;
			this.bpEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEdit.Location = new System.Drawing.Point(868, 495);
			this.bpEdit.Name = "bpEdit";
			this.bpEdit.Size = new System.Drawing.Size(86, 33);
			this.bpEdit.TabIndex = 14;
			this.bpEdit.Text = "Renommer";
			this.bpEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEdit.UseVisualStyleBackColor = true;
			this.bpEdit.Click += new System.EventHandler(this.bpEdit_Click);
			// 
			// bpSuppr
			// 
			this.bpSuppr.Image = global::PJA.Properties.Resources.Del;
			this.bpSuppr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpSuppr.Location = new System.Drawing.Point(960, 495);
			this.bpSuppr.Name = "bpSuppr";
			this.bpSuppr.Size = new System.Drawing.Size(86, 33);
			this.bpSuppr.TabIndex = 14;
			this.bpSuppr.Text = "Supprimer";
			this.bpSuppr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpSuppr.UseVisualStyleBackColor = true;
			this.bpSuppr.Click += new System.EventHandler(this.bpSuppr_Click);
			// 
			// bpAdd
			// 
			this.bpAdd.Image = global::PJA.Properties.Resources.Add;
			this.bpAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAdd.Location = new System.Drawing.Point(776, 495);
			this.bpAdd.Name = "bpAdd";
			this.bpAdd.Size = new System.Drawing.Size(86, 33);
			this.bpAdd.TabIndex = 14;
			this.bpAdd.Text = "Ajouter";
			this.bpAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAdd.UseVisualStyleBackColor = true;
			this.bpAdd.Click += new System.EventHandler(this.bpAdd_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(768, 544);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			// 
			// bpRazSat
			// 
			this.bpRazSat.Location = new System.Drawing.Point(1000, 670);
			this.bpRazSat.Name = "bpRazSat";
			this.bpRazSat.Size = new System.Drawing.Size(35, 23);
			this.bpRazSat.TabIndex = 21;
			this.bpRazSat.Text = "Raz";
			this.bpRazSat.UseVisualStyleBackColor = true;
			this.bpRazSat.Click += new System.EventHandler(this.bpRazSat_Click);
			// 
			// bpRazLumi
			// 
			this.bpRazLumi.Location = new System.Drawing.Point(1000, 634);
			this.bpRazLumi.Name = "bpRazLumi";
			this.bpRazLumi.Size = new System.Drawing.Size(35, 23);
			this.bpRazLumi.TabIndex = 22;
			this.bpRazLumi.Text = "Raz";
			this.bpRazLumi.UseVisualStyleBackColor = true;
			this.bpRazLumi.Click += new System.EventHandler(this.bpRazLumi_Click);
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(14, 670);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(55, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "Saturation";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 634);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Luminosité";
			// 
			// sat
			// 
			this.sat.Location = new System.Drawing.Point(66, 660);
			this.sat.Maximum = 200;
			this.sat.Name = "sat";
			this.sat.Size = new System.Drawing.Size(928, 42);
			this.sat.TabIndex = 17;
			this.sat.Value = 100;
			this.sat.ValueChanged += new System.EventHandler(this.sat_ValueChanged);
			// 
			// lumi
			// 
			this.lumi.Location = new System.Drawing.Point(66, 622);
			this.lumi.Maximum = 200;
			this.lumi.Name = "lumi";
			this.lumi.Size = new System.Drawing.Size(928, 42);
			this.lumi.TabIndex = 18;
			this.lumi.Value = 100;
			this.lumi.ValueChanged += new System.EventHandler(this.lumi_ValueChanged);
			// 
			// autoRecalc
			// 
			this.autoRecalc.AutoSize = true;
			this.autoRecalc.Location = new System.Drawing.Point(894, 30);
			this.autoRecalc.Name = "autoRecalc";
			this.autoRecalc.Size = new System.Drawing.Size(162, 17);
			this.autoRecalc.TabIndex = 23;
			this.autoRecalc.Text = "Recalculer Automatiquement";
			this.autoRecalc.UseVisualStyleBackColor = true;
			// 
			// sortPal
			// 
			this.sortPal.AutoSize = true;
			this.sortPal.Location = new System.Drawing.Point(894, 600);
			this.sortPal.Name = "sortPal";
			this.sortPal.Size = new System.Drawing.Size(47, 17);
			this.sortPal.TabIndex = 24;
			this.sortPal.Text = "Trier";
			this.sortPal.UseVisualStyleBackColor = true;
			this.sortPal.CheckedChanged += new System.EventHandler(this.sortPal_CheckedChanged);
			// 
			// contrast
			// 
			this.contrast.Location = new System.Drawing.Point(66, 704);
			this.contrast.Maximum = 200;
			this.contrast.Name = "contrast";
			this.contrast.Size = new System.Drawing.Size(928, 42);
			this.contrast.TabIndex = 17;
			this.contrast.Value = 100;
			this.contrast.ValueChanged += new System.EventHandler(this.contrast_ValueChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(14, 714);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Contraste";
			// 
			// bpRazContrast
			// 
			this.bpRazContrast.Location = new System.Drawing.Point(1000, 714);
			this.bpRazContrast.Name = "bpRazContrast";
			this.bpRazContrast.Size = new System.Drawing.Size(35, 23);
			this.bpRazContrast.TabIndex = 21;
			this.bpRazContrast.Text = "Raz";
			this.bpRazContrast.UseVisualStyleBackColor = true;
			this.bpRazContrast.Click += new System.EventHandler(this.bpRazContrast_Click);
			// 
			// bpDn
			// 
			this.bpDn.Location = new System.Drawing.Point(1032, 435);
			this.bpDn.Name = "bpDn";
			this.bpDn.Size = new System.Drawing.Size(24, 23);
			this.bpDn.TabIndex = 25;
			this.bpDn.Text = "v";
			this.bpDn.UseVisualStyleBackColor = true;
			this.bpDn.Click += new System.EventHandler(this.bpDn_Click);
			// 
			// bpUp
			// 
			this.bpUp.Location = new System.Drawing.Point(1032, 260);
			this.bpUp.Name = "bpUp";
			this.bpUp.Size = new System.Drawing.Size(24, 23);
			this.bpUp.TabIndex = 25;
			this.bpUp.Text = "^";
			this.bpUp.UseVisualStyleBackColor = true;
			this.bpUp.Click += new System.EventHandler(this.bpUp_Click);
			// 
			// bpSavePal
			// 
			this.bpSavePal.Location = new System.Drawing.Point(947, 575);
			this.bpSavePal.Name = "bpSavePal";
			this.bpSavePal.Size = new System.Drawing.Size(109, 21);
			this.bpSavePal.TabIndex = 26;
			this.bpSavePal.Text = "Sauver palette";
			this.bpSavePal.UseVisualStyleBackColor = true;
			this.bpSavePal.Click += new System.EventHandler(this.bpSavePal_Click);
			// 
			// bpLoadPal
			// 
			this.bpLoadPal.Location = new System.Drawing.Point(947, 548);
			this.bpLoadPal.Name = "bpLoadPal";
			this.bpLoadPal.Size = new System.Drawing.Size(109, 21);
			this.bpLoadPal.TabIndex = 26;
			this.bpLoadPal.Text = "Lire palette";
			this.bpLoadPal.UseVisualStyleBackColor = true;
			this.bpLoadPal.Click += new System.EventHandler(this.bpLoadPal_Click);
			// 
			// newMethode
			// 
			this.newMethode.AutoSize = true;
			this.newMethode.Location = new System.Drawing.Point(894, 53);
			this.newMethode.Name = "newMethode";
			this.newMethode.Size = new System.Drawing.Size(88, 17);
			this.newMethode.TabIndex = 27;
			this.newMethode.Text = "newMethode";
			this.newMethode.UseVisualStyleBackColor = true;
			this.newMethode.CheckedChanged += new System.EventHandler(this.newMethode_CheckedChanged);
			// 
			// nb
			// 
			this.nb.AutoSize = true;
			this.nb.Location = new System.Drawing.Point(894, 75);
			this.nb.Name = "nb";
			this.nb.Size = new System.Drawing.Size(81, 17);
			this.nb.TabIndex = 27;
			this.nb.Text = "noir && blanc";
			this.nb.UseVisualStyleBackColor = true;
			this.nb.CheckedChanged += new System.EventHandler(this.nb_CheckedChanged);
			// 
			// bpPredefPal
			// 
			this.bpPredefPal.Location = new System.Drawing.Point(947, 602);
			this.bpPredefPal.Name = "bpPredefPal";
			this.bpPredefPal.Size = new System.Drawing.Size(109, 21);
			this.bpPredefPal.TabIndex = 26;
			this.bpPredefPal.Text = "Palette prédéfinie";
			this.bpPredefPal.UseVisualStyleBackColor = true;
			this.bpPredefPal.Click += new System.EventHandler(this.bpPredefPal_Click);
			// 
			// lblTps
			// 
			this.lblTps.AutoSize = true;
			this.lblTps.Location = new System.Drawing.Point(997, 9);
			this.lblTps.Name = "lblTps";
			this.lblTps.Size = new System.Drawing.Size(29, 13);
			this.lblTps.TabIndex = 28;
			this.lblTps.Text = "0 ms";
			// 
			// bpPixel
			// 
			this.bpPixel.Location = new System.Drawing.Point(776, 534);
			this.bpPixel.Name = "bpPixel";
			this.bpPixel.Size = new System.Drawing.Size(86, 35);
			this.bpPixel.TabIndex = 29;
			this.bpPixel.Text = "Editer";
			this.bpPixel.UseVisualStyleBackColor = true;
			this.bpPixel.Click += new System.EventHandler(this.bpPixel_Click);
			// 
			// EditImages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 758);
			this.Controls.Add(this.bpPixel);
			this.Controls.Add(this.lblTps);
			this.Controls.Add(this.nb);
			this.Controls.Add(this.newMethode);
			this.Controls.Add(this.bpLoadPal);
			this.Controls.Add(this.bpPredefPal);
			this.Controls.Add(this.bpSavePal);
			this.Controls.Add(this.bpUp);
			this.Controls.Add(this.bpDn);
			this.Controls.Add(this.sortPal);
			this.Controls.Add(this.autoRecalc);
			this.Controls.Add(this.bpRazContrast);
			this.Controls.Add(this.bpRazSat);
			this.Controls.Add(this.bpRazLumi);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label9);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.contrast);
			this.Controls.Add(this.sat);
			this.Controls.Add(this.lumi);
			this.Controls.Add(this.imageName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bpEdit);
			this.Controls.Add(this.bpSuppr);
			this.Controls.Add(this.bpAdd);
			this.Controls.Add(this.listImage);
			this.Controls.Add(this.tramage);
			this.Controls.Add(this.radioKeepLarger);
			this.Controls.Add(this.radioKeepSmaller);
			this.Controls.Add(this.radioFit);
			this.Controls.Add(this.bpRecalc);
			this.Controls.Add(this.bpImport);
			this.Controls.Add(this.lockAllPal);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditImages";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Editeur d\'images";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditImages_FormClosed);
			this.tramage.ResumeLayout(false);
			this.tramage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctTrame)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lumi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contrast)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.CheckBox lockAllPal;
		private System.Windows.Forms.Button bpImport;
		private System.Windows.Forms.RadioButton radioFit;
		private System.Windows.Forms.RadioButton radioKeepSmaller;
		private System.Windows.Forms.RadioButton radioKeepLarger;
		private System.Windows.Forms.GroupBox tramage;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ComboBox methode;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox matrice;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.NumericUpDown pctTrame;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox renderMode;
		private System.Windows.Forms.ListBox listImage;
		private System.Windows.Forms.Button bpAdd;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox imageName;
		private System.Windows.Forms.Button bpRecalc;
		private System.Windows.Forms.Button bpSuppr;
		private System.Windows.Forms.Button bpEdit;
		private System.Windows.Forms.Button bpRazSat;
		private System.Windows.Forms.Button bpRazLumi;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TrackBar sat;
		private System.Windows.Forms.TrackBar lumi;
		private System.Windows.Forms.CheckBox autoRecalc;
		private System.Windows.Forms.CheckBox sortPal;
		private System.Windows.Forms.TrackBar contrast;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button bpRazContrast;
		private System.Windows.Forms.Button bpDn;
		private System.Windows.Forms.Button bpUp;
		private System.Windows.Forms.Button bpSavePal;
		private System.Windows.Forms.Button bpLoadPal;
		private System.Windows.Forms.CheckBox newMethode;
		private System.Windows.Forms.CheckBox nb;
		private System.Windows.Forms.Button bpPredefPal;
		private System.Windows.Forms.Label lblTps;
		private System.Windows.Forms.Button bpPixel;

	}
}