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
			this.imageAffect = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.listImage = new System.Windows.Forms.ListBox();
			this.bpAffecte = new System.Windows.Forms.Button();
			this.bpDelLieu = new System.Windows.Forms.Button();
			this.listLieu = new System.Windows.Forms.ListBox();
			this.bpAddLieu = new System.Windows.Forms.Button();
			this.libelleMap = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bpEditLibelle = new System.Windows.Forms.Button();
			this.bpDelZone = new System.Windows.Forms.Button();
			this.allZones = new System.Windows.Forms.CheckBox();
			this.listZone = new System.Windows.Forms.ListBox();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.bpEditZone = new System.Windows.Forms.Button();
			this.listDetail = new System.Windows.Forms.ListBox();
			this.bpEditTC = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// imageAffect
			// 
			this.imageAffect.Enabled = false;
			this.imageAffect.Location = new System.Drawing.Point(468, 35);
			this.imageAffect.Name = "imageAffect";
			this.imageAffect.ReadOnly = true;
			this.imageAffect.Size = new System.Drawing.Size(244, 20);
			this.imageAffect.TabIndex = 34;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(387, 38);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(84, 13);
			this.label10.TabIndex = 33;
			this.label10.Text = "Image affectée :";
			// 
			// listImage
			// 
			this.listImage.FormattingEnabled = true;
			this.listImage.Location = new System.Drawing.Point(504, 73);
			this.listImage.Name = "listImage";
			this.listImage.Size = new System.Drawing.Size(244, 238);
			this.listImage.TabIndex = 35;
			this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
			// 
			// bpAffecte
			// 
			this.bpAffecte.Enabled = false;
			this.bpAffecte.Image = global::PJA.Properties.Resources.Affecte;
			this.bpAffecte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAffecte.Location = new System.Drawing.Point(390, 73);
			this.bpAffecte.Name = "bpAffecte";
			this.bpAffecte.Size = new System.Drawing.Size(108, 34);
			this.bpAffecte.TabIndex = 37;
			this.bpAffecte.Text = "Affecter vue";
			this.bpAffecte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAffecte.UseVisualStyleBackColor = true;
			this.bpAffecte.Click += new System.EventHandler(this.bpAffecte_Click);
			// 
			// bpDelLieu
			// 
			this.bpDelLieu.Enabled = false;
			this.bpDelLieu.Image = global::PJA.Properties.Resources.Del;
			this.bpDelLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelLieu.Location = new System.Drawing.Point(273, 282);
			this.bpDelLieu.Name = "bpDelLieu";
			this.bpDelLieu.Size = new System.Drawing.Size(108, 34);
			this.bpDelLieu.TabIndex = 36;
			this.bpDelLieu.Text = "Supprimer Lieu";
			this.bpDelLieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelLieu.UseVisualStyleBackColor = true;
			this.bpDelLieu.Click += new System.EventHandler(this.bpDelLieu_Click);
			// 
			// listLieu
			// 
			this.listLieu.FormattingEnabled = true;
			this.listLieu.Location = new System.Drawing.Point(2, 12);
			this.listLieu.Name = "listLieu";
			this.listLieu.Size = new System.Drawing.Size(379, 264);
			this.listLieu.TabIndex = 39;
			this.listLieu.SelectedIndexChanged += new System.EventHandler(this.listLieu_SelectedIndexChanged);
			// 
			// bpAddLieu
			// 
			this.bpAddLieu.Image = global::PJA.Properties.Resources.Add;
			this.bpAddLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddLieu.Location = new System.Drawing.Point(2, 282);
			this.bpAddLieu.Name = "bpAddLieu";
			this.bpAddLieu.Size = new System.Drawing.Size(108, 34);
			this.bpAddLieu.TabIndex = 40;
			this.bpAddLieu.Text = "Ajouter Lieu";
			this.bpAddLieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddLieu.UseVisualStyleBackColor = true;
			this.bpAddLieu.Click += new System.EventHandler(this.bpAddLieu_Click);
			// 
			// libelleMap
			// 
			this.libelleMap.Location = new System.Drawing.Point(436, 9);
			this.libelleMap.Name = "libelleMap";
			this.libelleMap.Size = new System.Drawing.Size(276, 20);
			this.libelleMap.TabIndex = 41;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(387, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(43, 13);
			this.label1.TabIndex = 33;
			this.label1.Text = "Libellé :";
			// 
			// bpEditLibelle
			// 
			this.bpEditLibelle.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditLibelle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditLibelle.Location = new System.Drawing.Point(718, 6);
			this.bpEditLibelle.Name = "bpEditLibelle";
			this.bpEditLibelle.Size = new System.Drawing.Size(108, 34);
			this.bpEditLibelle.TabIndex = 42;
			this.bpEditLibelle.Text = "Modifier libellé";
			this.bpEditLibelle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditLibelle.UseVisualStyleBackColor = true;
			this.bpEditLibelle.Click += new System.EventHandler(this.bpEditLibelle_Click);
			// 
			// bpDelZone
			// 
			this.bpDelZone.Enabled = false;
			this.bpDelZone.Image = global::PJA.Properties.Resources.Del;
			this.bpDelZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelZone.Location = new System.Drawing.Point(776, 593);
			this.bpDelZone.Name = "bpDelZone";
			this.bpDelZone.Size = new System.Drawing.Size(108, 34);
			this.bpDelZone.TabIndex = 48;
			this.bpDelZone.Text = "Supprimer Zone";
			this.bpDelZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelZone.UseVisualStyleBackColor = true;
			this.bpDelZone.Click += new System.EventHandler(this.bpDelZone_Click);
			// 
			// allZones
			// 
			this.allZones.AutoSize = true;
			this.allZones.Location = new System.Drawing.Point(776, 633);
			this.allZones.Name = "allZones";
			this.allZones.Size = new System.Drawing.Size(141, 17);
			this.allZones.TabIndex = 46;
			this.allZones.Text = "Afficher toutes les zones";
			this.allZones.UseVisualStyleBackColor = true;
			this.allZones.CheckedChanged += new System.EventHandler(this.allZones_CheckedChanged);
			// 
			// listZone
			// 
			this.listZone.FormattingEnabled = true;
			this.listZone.Location = new System.Drawing.Point(776, 322);
			this.listZone.Name = "listZone";
			this.listZone.Size = new System.Drawing.Size(141, 225);
			this.listZone.TabIndex = 45;
			this.listZone.SelectedIndexChanged += new System.EventHandler(this.listZone_SelectedIndexChanged);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(2, 322);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(768, 544);
			this.pictureBox.TabIndex = 43;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// bpEditZone
			// 
			this.bpEditZone.Enabled = false;
			this.bpEditZone.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditZone.Location = new System.Drawing.Point(776, 553);
			this.bpEditZone.Name = "bpEditZone";
			this.bpEditZone.Size = new System.Drawing.Size(108, 34);
			this.bpEditZone.TabIndex = 44;
			this.bpEditZone.Text = "Editer Zone";
			this.bpEditZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditZone.UseVisualStyleBackColor = true;
			this.bpEditZone.Click += new System.EventHandler(this.bpEditZone_Click);
			// 
			// listDetail
			// 
			this.listDetail.FormattingEnabled = true;
			this.listDetail.Location = new System.Drawing.Point(923, 322);
			this.listDetail.Name = "listDetail";
			this.listDetail.Size = new System.Drawing.Size(141, 225);
			this.listDetail.TabIndex = 45;
			this.listDetail.SelectedIndexChanged += new System.EventHandler(this.listZone_SelectedIndexChanged);
			// 
			// bpEditTC
			// 
			this.bpEditTC.Enabled = false;
			this.bpEditTC.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditTC.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditTC.Location = new System.Drawing.Point(390, 155);
			this.bpEditTC.Name = "bpEditTC";
			this.bpEditTC.Size = new System.Drawing.Size(100, 62);
			this.bpEditTC.TabIndex = 42;
			this.bpEditTC.Text = "Edition Traitements Conditionnels";
			this.bpEditTC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditTC.UseVisualStyleBackColor = true;
			this.bpEditTC.Click += new System.EventHandler(this.bpEditTC_Click);
			// 
			// EditMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1096, 868);
			this.Controls.Add(this.bpDelZone);
			this.Controls.Add(this.allZones);
			this.Controls.Add(this.listDetail);
			this.Controls.Add(this.listZone);
			this.Controls.Add(this.bpEditZone);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.bpEditTC);
			this.Controls.Add(this.bpEditLibelle);
			this.Controls.Add(this.libelleMap);
			this.Controls.Add(this.bpAddLieu);
			this.Controls.Add(this.listLieu);
			this.Controls.Add(this.bpDelLieu);
			this.Controls.Add(this.bpAffecte);
			this.Controls.Add(this.listImage);
			this.Controls.Add(this.imageAffect);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label10);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EditMap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Text = "EditMap";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditMap_FormClosed);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox imageAffect;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ListBox listImage;
		private System.Windows.Forms.Button bpAffecte;
		private System.Windows.Forms.Button bpDelLieu;
		private System.Windows.Forms.ListBox listLieu;
		private System.Windows.Forms.Button bpAddLieu;
		private System.Windows.Forms.TextBox libelleMap;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bpEditLibelle;
		private System.Windows.Forms.Button bpDelZone;
		private System.Windows.Forms.CheckBox allZones;
		private System.Windows.Forms.ListBox listZone;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Button bpEditZone;
		private System.Windows.Forms.ListBox listDetail;
		private System.Windows.Forms.Button bpEditTC;
	}
}