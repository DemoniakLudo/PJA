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
			this.typeZone = new System.Windows.Forms.ComboBox();
			this.allZones = new System.Windows.Forms.CheckBox();
			this.listZone = new System.Windows.Forms.ListBox();
			this.bpAddZone = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
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
			// listMap
			// 
			this.listLieu.FormattingEnabled = true;
			this.listLieu.Location = new System.Drawing.Point(2, 12);
			this.listLieu.Name = "listMap";
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
			this.bpDelZone.Location = new System.Drawing.Point(648, 553);
			this.bpDelZone.Name = "bpDelZone";
			this.bpDelZone.Size = new System.Drawing.Size(108, 34);
			this.bpDelZone.TabIndex = 48;
			this.bpDelZone.Text = "Supprimer Zone";
			this.bpDelZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelZone.UseVisualStyleBackColor = true;
			this.bpDelZone.Click += new System.EventHandler(this.bpDelZone_Click);
			// 
			// typeZone
			// 
			this.typeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeZone.FormattingEnabled = true;
			this.typeZone.Location = new System.Drawing.Point(648, 633);
			this.typeZone.Name = "typeZone";
			this.typeZone.Size = new System.Drawing.Size(117, 21);
			this.typeZone.TabIndex = 47;
			this.typeZone.SelectedIndexChanged += new System.EventHandler(this.typeZone_SelectedIndexChanged);
			// 
			// allZones
			// 
			this.allZones.AutoSize = true;
			this.allZones.Location = new System.Drawing.Point(648, 705);
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
			this.listZone.Location = new System.Drawing.Point(648, 322);
			this.listZone.Name = "listZone";
			this.listZone.Size = new System.Drawing.Size(141, 225);
			this.listZone.TabIndex = 45;
			this.listZone.SelectedIndexChanged += new System.EventHandler(this.listZone_SelectedIndexChanged);
			// 
			// bpAddZone
			// 
			this.bpAddZone.Enabled = false;
			this.bpAddZone.Image = global::PJA.Properties.Resources.Add;
			this.bpAddZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddZone.Location = new System.Drawing.Point(648, 593);
			this.bpAddZone.Name = "bpAddZone";
			this.bpAddZone.Size = new System.Drawing.Size(108, 34);
			this.bpAddZone.TabIndex = 44;
			this.bpAddZone.Text = "Ajouter Zone";
			this.bpAddZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddZone.UseVisualStyleBackColor = true;
			this.bpAddZone.Click += new System.EventHandler(this.bpAddZone_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(2, 322);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(640, 400);
			this.pictureBox.TabIndex = 43;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// EditMap
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(831, 725);
			this.Controls.Add(this.bpDelZone);
			this.Controls.Add(this.typeZone);
			this.Controls.Add(this.allZones);
			this.Controls.Add(this.listZone);
			this.Controls.Add(this.bpAddZone);
			this.Controls.Add(this.pictureBox);
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
		private System.Windows.Forms.ComboBox typeZone;
		private System.Windows.Forms.CheckBox allZones;
		private System.Windows.Forms.ListBox listZone;
		private System.Windows.Forms.Button bpAddZone;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}