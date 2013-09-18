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
			this.bpEdit = new System.Windows.Forms.Button();
			this.bpSuppr = new System.Windows.Forms.Button();
			this.bpAdd = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.vScrollBar = new System.Windows.Forms.VScrollBar();
			this.hScrollBar = new System.Windows.Forms.HScrollBar();
			this.label3 = new System.Windows.Forms.Label();
			this.zoomLevel = new System.Windows.Forms.ComboBox();
			this.bpEditMode = new System.Windows.Forms.CheckBox();
			this.cpcPlus = new System.Windows.Forms.CheckBox();
			this.reducPal1 = new System.Windows.Forms.CheckBox();
			this.reducPal2 = new System.Windows.Forms.CheckBox();
			this.newReduc = new System.Windows.Forms.CheckBox();
			this.tramage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctTrame)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sat)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lumi)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.contrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// lockAllPal
			// 
			this.lockAllPal.AutoSize = true;
			this.lockAllPal.Location = new System.Drawing.Point(791, 600);
			this.lockAllPal.Name = "lockAllPal";
			this.lockAllPal.Size = new System.Drawing.Size(93, 17);
			this.lockAllPal.TabIndex = 1;
			this.lockAllPal.Text = "Tout vérouiller";
			this.lockAllPal.UseVisualStyleBackColor = true;
			this.lockAllPal.CheckedChanged += new System.EventHandler(this.lockAllPal_CheckedChanged);
			// 
			// bpImport
			// 
			this.bpImport.Location = new System.Drawing.Point(795, 0);
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
			this.radioFit.Location = new System.Drawing.Point(796, 29);
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
			this.radioKeepSmaller.Location = new System.Drawing.Point(796, 52);
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
			this.radioKeepLarger.Location = new System.Drawing.Point(796, 75);
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
			this.tramage.Location = new System.Drawing.Point(795, 111);
			this.tramage.Name = "tramage";
			this.tramage.Size = new System.Drawing.Size(197, 103);
			this.tramage.TabIndex = 12;
			this.tramage.TabStop = false;
			this.tramage.Text = "Tramage";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(177, 22);
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
            "Aucun",
            "Méthode 1",
            "Méthode 2",
            "Méthode 3"});
			this.methode.Location = new System.Drawing.Point(43, 19);
			this.methode.Name = "methode";
			this.methode.Size = new System.Drawing.Size(72, 21);
			this.methode.TabIndex = 8;
			this.methode.SelectedIndexChanged += new System.EventHandler(this.methode_SelectedIndexChanged);
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(6, 76);
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
			this.matrice.Location = new System.Drawing.Point(57, 46);
			this.matrice.Name = "matrice";
			this.matrice.Size = new System.Drawing.Size(97, 21);
			this.matrice.TabIndex = 8;
			this.matrice.SelectedIndexChanged += new System.EventHandler(this.matrice_SelectedIndexChanged);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(9, 49);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(42, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "Matrice";
			// 
			// pctTrame
			// 
			this.pctTrame.Location = new System.Drawing.Point(119, 20);
			this.pctTrame.Maximum = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.pctTrame.Name = "pctTrame";
			this.pctTrame.Size = new System.Drawing.Size(50, 20);
			this.pctTrame.TabIndex = 9;
			this.pctTrame.ValueChanged += new System.EventHandler(this.pctTrame_ValueChanged);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 22);
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
			this.renderMode.Location = new System.Drawing.Point(90, 73);
			this.renderMode.Name = "renderMode";
			this.renderMode.Size = new System.Drawing.Size(97, 21);
			this.renderMode.TabIndex = 10;
			this.renderMode.SelectedIndexChanged += new System.EventHandler(this.renderMode_SelectedIndexChanged);
			// 
			// listImage
			// 
			this.listImage.FormattingEnabled = true;
			this.listImage.Location = new System.Drawing.Point(795, 218);
			this.listImage.Name = "listImage";
			this.listImage.Size = new System.Drawing.Size(231, 212);
			this.listImage.TabIndex = 13;
			this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(793, 439);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Nom:";
			// 
			// imageName
			// 
			this.imageName.Location = new System.Drawing.Point(829, 436);
			this.imageName.Name = "imageName";
			this.imageName.Size = new System.Drawing.Size(215, 20);
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
			// bpRazSat
			// 
			this.bpRazSat.Location = new System.Drawing.Point(1000, 682);
			this.bpRazSat.Name = "bpRazSat";
			this.bpRazSat.Size = new System.Drawing.Size(35, 23);
			this.bpRazSat.TabIndex = 21;
			this.bpRazSat.Text = "Raz";
			this.bpRazSat.UseVisualStyleBackColor = true;
			this.bpRazSat.Click += new System.EventHandler(this.bpRazSat_Click);
			// 
			// bpRazLumi
			// 
			this.bpRazLumi.Location = new System.Drawing.Point(1000, 646);
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
			this.label9.Location = new System.Drawing.Point(14, 682);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(55, 13);
			this.label9.TabIndex = 19;
			this.label9.Text = "Saturation";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(12, 646);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(57, 13);
			this.label8.TabIndex = 20;
			this.label8.Text = "Luminosité";
			// 
			// sat
			// 
			this.sat.Location = new System.Drawing.Point(66, 672);
			this.sat.Maximum = 200;
			this.sat.Name = "sat";
			this.sat.Size = new System.Drawing.Size(928, 42);
			this.sat.TabIndex = 17;
			this.sat.Value = 100;
			this.sat.ValueChanged += new System.EventHandler(this.sat_ValueChanged);
			// 
			// lumi
			// 
			this.lumi.Location = new System.Drawing.Point(66, 634);
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
			this.contrast.Location = new System.Drawing.Point(66, 716);
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
			this.label2.Location = new System.Drawing.Point(14, 726);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(52, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Contraste";
			// 
			// bpRazContrast
			// 
			this.bpRazContrast.Location = new System.Drawing.Point(1000, 726);
			this.bpRazContrast.Name = "bpRazContrast";
			this.bpRazContrast.Size = new System.Drawing.Size(35, 23);
			this.bpRazContrast.TabIndex = 21;
			this.bpRazContrast.Text = "Raz";
			this.bpRazContrast.UseVisualStyleBackColor = true;
			this.bpRazContrast.Click += new System.EventHandler(this.bpRazContrast_Click);
			// 
			// bpDn
			// 
			this.bpDn.Location = new System.Drawing.Point(1032, 407);
			this.bpDn.Name = "bpDn";
			this.bpDn.Size = new System.Drawing.Size(24, 23);
			this.bpDn.TabIndex = 25;
			this.bpDn.Text = "v";
			this.bpDn.UseVisualStyleBackColor = true;
			this.bpDn.Click += new System.EventHandler(this.bpDn_Click);
			// 
			// bpUp
			// 
			this.bpUp.Location = new System.Drawing.Point(1032, 232);
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
			// bpEdit
			// 
			this.bpEdit.Image = global::PJA.Properties.Resources.Edit;
			this.bpEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEdit.Location = new System.Drawing.Point(878, 460);
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
			this.bpSuppr.Location = new System.Drawing.Point(970, 460);
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
			this.bpAdd.Location = new System.Drawing.Point(798, 460);
			this.bpAdd.Name = "bpAdd";
			this.bpAdd.Size = new System.Drawing.Size(74, 33);
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
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			// 
			// vScrollBar
			// 
			this.vScrollBar.LargeChange = 32;
			this.vScrollBar.Location = new System.Drawing.Point(771, 0);
			this.vScrollBar.Name = "vScrollBar";
			this.vScrollBar.Size = new System.Drawing.Size(16, 544);
			this.vScrollBar.SmallChange = 8;
			this.vScrollBar.TabIndex = 31;
			this.vScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar_Scroll);
			// 
			// hScrollBar
			// 
			this.hScrollBar.LargeChange = 32;
			this.hScrollBar.Location = new System.Drawing.Point(0, 547);
			this.hScrollBar.Name = "hScrollBar";
			this.hScrollBar.Size = new System.Drawing.Size(768, 16);
			this.hScrollBar.SmallChange = 8;
			this.hScrollBar.TabIndex = 30;
			this.hScrollBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar_Scroll);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(952, 504);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(40, 13);
			this.label3.TabIndex = 33;
			this.label3.Text = "Zoom :";
			// 
			// zoomLevel
			// 
			this.zoomLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.zoomLevel.FormattingEnabled = true;
			this.zoomLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
			this.zoomLevel.Location = new System.Drawing.Point(1000, 500);
			this.zoomLevel.Name = "zoomLevel";
			this.zoomLevel.Size = new System.Drawing.Size(56, 21);
			this.zoomLevel.TabIndex = 32;
			this.zoomLevel.SelectedIndexChanged += new System.EventHandler(this.zoomLevel_SelectedIndexChanged);
			// 
			// bpEditMode
			// 
			this.bpEditMode.AutoSize = true;
			this.bpEditMode.Location = new System.Drawing.Point(797, 500);
			this.bpEditMode.Name = "bpEditMode";
			this.bpEditMode.Size = new System.Drawing.Size(87, 17);
			this.bpEditMode.TabIndex = 34;
			this.bpEditMode.Text = "Mode edition";
			this.bpEditMode.UseVisualStyleBackColor = true;
			this.bpEditMode.CheckedChanged += new System.EventHandler(this.bpEditMode_CheckedChanged);
			// 
			// cpcPlus
			// 
			this.cpcPlus.AutoSize = true;
			this.cpcPlus.Location = new System.Drawing.Point(792, 579);
			this.cpcPlus.Name = "cpcPlus";
			this.cpcPlus.Size = new System.Drawing.Size(70, 17);
			this.cpcPlus.TabIndex = 35;
			this.cpcPlus.Text = "CPC Plus";
			this.cpcPlus.UseVisualStyleBackColor = true;
			this.cpcPlus.CheckedChanged += new System.EventHandler(this.cpcPlus_CheckedChanged);
			// 
			// reducPal1
			// 
			this.reducPal1.AutoSize = true;
			this.reducPal1.Enabled = false;
			this.reducPal1.Location = new System.Drawing.Point(792, 528);
			this.reducPal1.Name = "reducPal1";
			this.reducPal1.Size = new System.Drawing.Size(74, 17);
			this.reducPal1.TabIndex = 36;
			this.reducPal1.Text = "reducPal1";
			this.reducPal1.UseVisualStyleBackColor = true;
			this.reducPal1.CheckedChanged += new System.EventHandler(this.reducPal1_CheckedChanged);
			// 
			// reducPal2
			// 
			this.reducPal2.AutoSize = true;
			this.reducPal2.Enabled = false;
			this.reducPal2.Location = new System.Drawing.Point(792, 545);
			this.reducPal2.Name = "reducPal2";
			this.reducPal2.Size = new System.Drawing.Size(74, 17);
			this.reducPal2.TabIndex = 37;
			this.reducPal2.Text = "reducPal2";
			this.reducPal2.UseVisualStyleBackColor = true;
			this.reducPal2.CheckedChanged += new System.EventHandler(this.reducPal2_CheckedChanged);
			// 
			// newReduc
			// 
			this.newReduc.AutoSize = true;
			this.newReduc.Enabled = false;
			this.newReduc.Location = new System.Drawing.Point(792, 562);
			this.newReduc.Name = "newReduc";
			this.newReduc.Size = new System.Drawing.Size(78, 17);
			this.newReduc.TabIndex = 38;
			this.newReduc.Text = "newReduc";
			this.newReduc.UseVisualStyleBackColor = true;
			this.newReduc.CheckedChanged += new System.EventHandler(this.newReduc_CheckedChanged);
			// 
			// EditImages
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 758);
			this.Controls.Add(this.newReduc);
			this.Controls.Add(this.reducPal2);
			this.Controls.Add(this.reducPal1);
			this.Controls.Add(this.cpcPlus);
			this.Controls.Add(this.bpEditMode);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.zoomLevel);
			this.Controls.Add(this.vScrollBar);
			this.Controls.Add(this.hScrollBar);
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
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "Editeur d\'images";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditImages_FormClosed);
			this.tramage.ResumeLayout(false);
			this.tramage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.pctTrame)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sat)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lumi)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.contrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
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
		private System.Windows.Forms.VScrollBar vScrollBar;
		private System.Windows.Forms.HScrollBar hScrollBar;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox zoomLevel;
		private System.Windows.Forms.CheckBox bpEditMode;
		private System.Windows.Forms.CheckBox cpcPlus;
		private System.Windows.Forms.CheckBox reducPal1;
		private System.Windows.Forms.CheckBox reducPal2;
		private System.Windows.Forms.CheckBox newReduc;

	}
}