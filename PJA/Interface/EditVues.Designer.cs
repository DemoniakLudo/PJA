namespace PJA {
	partial class EditVues {
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
			this.label1 = new System.Windows.Forms.Label();
			this.numSalle = new System.Windows.Forms.NumericUpDown();
			this.listImage = new System.Windows.Forms.ListBox();
			this.label2 = new System.Windows.Forms.Label();
			this.nomVue = new System.Windows.Forms.TextBox();
			this.listVue = new System.Windows.Forms.ListBox();
			this.bpEditVue = new System.Windows.Forms.Button();
			this.bpAddVue = new System.Windows.Forms.Button();
			this.bpDelVue = new System.Windows.Forms.Button();
			this.bpAffecte = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.bpAddZone = new System.Windows.Forms.Button();
			this.listZone = new System.Windows.Forms.ListBox();
			this.allZones = new System.Windows.Forms.CheckBox();
			this.typeZone = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.bpDelZone = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.numSalle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 12);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(89, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Numéro de salle :";
			// 
			// numSalle
			// 
			this.numSalle.Location = new System.Drawing.Point(107, 10);
			this.numSalle.Name = "numSalle";
			this.numSalle.Size = new System.Drawing.Size(58, 20);
			this.numSalle.TabIndex = 2;
			this.numSalle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.numSalle.ValueChanged += new System.EventHandler(this.numSalle_ValueChanged);
			// 
			// listImage
			// 
			this.listImage.FormattingEnabled = true;
			this.listImage.Location = new System.Drawing.Point(397, 12);
			this.listImage.Name = "listImage";
			this.listImage.Size = new System.Drawing.Size(244, 212);
			this.listImage.TabIndex = 14;
			this.listImage.SelectedIndexChanged += new System.EventHandler(this.listImage_SelectedIndexChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 55);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(82, 13);
			this.label2.TabIndex = 19;
			this.label2.Text = "Nom de la vue :";
			// 
			// nomVue
			// 
			this.nomVue.Location = new System.Drawing.Point(107, 52);
			this.nomVue.Name = "nomVue";
			this.nomVue.Size = new System.Drawing.Size(284, 20);
			this.nomVue.TabIndex = 20;
			this.nomVue.TextChanged += new System.EventHandler(this.nomVue_TextChanged);
			// 
			// listVue
			// 
			this.listVue.FormattingEnabled = true;
			this.listVue.Location = new System.Drawing.Point(224, 77);
			this.listVue.Name = "listVue";
			this.listVue.Size = new System.Drawing.Size(167, 147);
			this.listVue.TabIndex = 22;
			this.listVue.SelectedIndexChanged += new System.EventHandler(this.listVue_SelectedIndexChanged);
			// 
			// bpEditVue
			// 
			this.bpEditVue.Enabled = false;
			this.bpEditVue.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditVue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditVue.Location = new System.Drawing.Point(15, 128);
			this.bpEditVue.Name = "bpEditVue";
			this.bpEditVue.Size = new System.Drawing.Size(108, 34);
			this.bpEditVue.TabIndex = 24;
			this.bpEditVue.Text = "Modifier vue";
			this.bpEditVue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditVue.UseVisualStyleBackColor = true;
			this.bpEditVue.Click += new System.EventHandler(this.bpEditVue_Click);
			// 
			// bpAddVue
			// 
			this.bpAddVue.Enabled = false;
			this.bpAddVue.Image = global::PJA.Properties.Resources.Add;
			this.bpAddVue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddVue.Location = new System.Drawing.Point(15, 88);
			this.bpAddVue.Name = "bpAddVue";
			this.bpAddVue.Size = new System.Drawing.Size(108, 34);
			this.bpAddVue.TabIndex = 23;
			this.bpAddVue.Text = "Ajouter vue";
			this.bpAddVue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddVue.UseVisualStyleBackColor = true;
			this.bpAddVue.Click += new System.EventHandler(this.bpAddVue_Click);
			// 
			// bpDelVue
			// 
			this.bpDelVue.Enabled = false;
			this.bpDelVue.Image = global::PJA.Properties.Resources.Del;
			this.bpDelVue.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelVue.Location = new System.Drawing.Point(15, 168);
			this.bpDelVue.Name = "bpDelVue";
			this.bpDelVue.Size = new System.Drawing.Size(108, 34);
			this.bpDelVue.TabIndex = 21;
			this.bpDelVue.Text = "Supprimer vue";
			this.bpDelVue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelVue.UseVisualStyleBackColor = true;
			this.bpDelVue.Click += new System.EventHandler(this.bpDelVue_Click);
			// 
			// bpAffecte
			// 
			this.bpAffecte.Enabled = false;
			this.bpAffecte.Image = global::PJA.Properties.Resources.Affecte;
			this.bpAffecte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAffecte.Location = new System.Drawing.Point(171, 1);
			this.bpAffecte.Name = "bpAffecte";
			this.bpAffecte.Size = new System.Drawing.Size(108, 34);
			this.bpAffecte.TabIndex = 21;
			this.bpAffecte.Text = "Affecter vue";
			this.bpAffecte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAffecte.UseVisualStyleBackColor = true;
			this.bpAffecte.Click += new System.EventHandler(this.bpAffecte_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(1, 230);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(640, 400);
			this.pictureBox.TabIndex = 18;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// bpAddZone
			// 
			this.bpAddZone.Enabled = false;
			this.bpAddZone.Image = global::PJA.Properties.Resources.Add;
			this.bpAddZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddZone.Location = new System.Drawing.Point(842, 291);
			this.bpAddZone.Name = "bpAddZone";
			this.bpAddZone.Size = new System.Drawing.Size(108, 34);
			this.bpAddZone.TabIndex = 25;
			this.bpAddZone.Text = "Ajouter Zone";
			this.bpAddZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddZone.UseVisualStyleBackColor = true;
			this.bpAddZone.Click += new System.EventHandler(this.bpAddZone_Click);
			// 
			// listZone
			// 
			this.listZone.FormattingEnabled = true;
			this.listZone.Location = new System.Drawing.Point(657, 1);
			this.listZone.Name = "listZone";
			this.listZone.Size = new System.Drawing.Size(293, 264);
			this.listZone.TabIndex = 26;
			this.listZone.SelectedIndexChanged += new System.EventHandler(this.listZone_SelectedIndexChanged);
			// 
			// allZones
			// 
			this.allZones.AutoSize = true;
			this.allZones.Location = new System.Drawing.Point(657, 271);
			this.allZones.Name = "allZones";
			this.allZones.Size = new System.Drawing.Size(141, 17);
			this.allZones.TabIndex = 27;
			this.allZones.Text = "Afficher toutes les zones";
			this.allZones.UseVisualStyleBackColor = true;
			this.allZones.CheckedChanged += new System.EventHandler(this.allZones_CheckedChanged);
			// 
			// typeZone
			// 
			this.typeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeZone.FormattingEnabled = true;
			this.typeZone.Location = new System.Drawing.Point(721, 299);
			this.typeZone.Name = "typeZone";
			this.typeZone.Size = new System.Drawing.Size(117, 21);
			this.typeZone.TabIndex = 28;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(645, 302);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(74, 13);
			this.label3.TabIndex = 29;
			this.label3.Text = "type de zone :";
			// 
			// bpDelZone
			// 
			this.bpDelZone.Enabled = false;
			this.bpDelZone.Image = global::PJA.Properties.Resources.Del;
			this.bpDelZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelZone.Location = new System.Drawing.Point(842, 331);
			this.bpDelZone.Name = "bpDelZone";
			this.bpDelZone.Size = new System.Drawing.Size(108, 34);
			this.bpDelZone.TabIndex = 30;
			this.bpDelZone.Text = "Supprimer Zone";
			this.bpDelZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelZone.UseVisualStyleBackColor = true;
			this.bpDelZone.Click += new System.EventHandler(this.bpDelZone_Click);
			// 
			// EditVues
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(951, 632);
			this.Controls.Add(this.bpDelZone);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.typeZone);
			this.Controls.Add(this.allZones);
			this.Controls.Add(this.listZone);
			this.Controls.Add(this.bpAddZone);
			this.Controls.Add(this.bpEditVue);
			this.Controls.Add(this.bpAddVue);
			this.Controls.Add(this.listVue);
			this.Controls.Add(this.bpDelVue);
			this.Controls.Add(this.bpAffecte);
			this.Controls.Add(this.nomVue);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.pictureBox);
			this.Controls.Add(this.listImage);
			this.Controls.Add(this.numSalle);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditVues";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "EditVues";
			((System.ComponentModel.ISupportInitialize)(this.numSalle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numSalle;
		private System.Windows.Forms.ListBox listImage;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox nomVue;
		private System.Windows.Forms.Button bpAffecte;
		private System.Windows.Forms.Button bpDelVue;
		private System.Windows.Forms.ListBox listVue;
		private System.Windows.Forms.Button bpAddVue;
		private System.Windows.Forms.Button bpEditVue;
		private System.Windows.Forms.Button bpAddZone;
		private System.Windows.Forms.ListBox listZone;
		private System.Windows.Forms.CheckBox allZones;
		private System.Windows.Forms.ComboBox typeZone;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button bpDelZone;

	}
}