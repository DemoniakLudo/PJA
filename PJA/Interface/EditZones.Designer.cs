namespace PJA {
	partial class EditZones {
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
			this.typeZone = new System.Windows.Forms.ComboBox();
			this.allZones = new System.Windows.Forms.CheckBox();
			this.listZone = new System.Windows.Forms.ListBox();
			this.bpDelZone = new System.Windows.Forms.Button();
			this.bpAddZone = new System.Windows.Forms.Button();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// typeZone
			// 
			this.typeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeZone.FormattingEnabled = true;
			this.typeZone.Location = new System.Drawing.Point(648, 313);
			this.typeZone.Name = "typeZone";
			this.typeZone.Size = new System.Drawing.Size(117, 21);
			this.typeZone.TabIndex = 35;
			// 
			// allZones
			// 
			this.allZones.AutoSize = true;
			this.allZones.Location = new System.Drawing.Point(648, 385);
			this.allZones.Name = "allZones";
			this.allZones.Size = new System.Drawing.Size(141, 17);
			this.allZones.TabIndex = 34;
			this.allZones.Text = "Afficher toutes les zones";
			this.allZones.UseVisualStyleBackColor = true;
			this.allZones.CheckedChanged += new System.EventHandler(this.allZones_CheckedChanged);
			// 
			// listZone
			// 
			this.listZone.FormattingEnabled = true;
			this.listZone.Location = new System.Drawing.Point(648, 2);
			this.listZone.Name = "listZone";
			this.listZone.Size = new System.Drawing.Size(141, 225);
			this.listZone.TabIndex = 33;
			this.listZone.SelectedIndexChanged += new System.EventHandler(this.listZone_SelectedIndexChanged);
			// 
			// bpDelZone
			// 
			this.bpDelZone.Enabled = false;
			this.bpDelZone.Image = global::PJA.Properties.Resources.Del;
			this.bpDelZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelZone.Location = new System.Drawing.Point(648, 233);
			this.bpDelZone.Name = "bpDelZone";
			this.bpDelZone.Size = new System.Drawing.Size(108, 34);
			this.bpDelZone.TabIndex = 36;
			this.bpDelZone.Text = "Supprimer Zone";
			this.bpDelZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelZone.UseVisualStyleBackColor = true;
			this.bpDelZone.Click += new System.EventHandler(this.bpDelZone_Click);
			// 
			// bpAddZone
			// 
			this.bpAddZone.Enabled = false;
			this.bpAddZone.Image = global::PJA.Properties.Resources.Add;
			this.bpAddZone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddZone.Location = new System.Drawing.Point(648, 273);
			this.bpAddZone.Name = "bpAddZone";
			this.bpAddZone.Size = new System.Drawing.Size(108, 34);
			this.bpAddZone.TabIndex = 32;
			this.bpAddZone.Text = "Ajouter Zone";
			this.bpAddZone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddZone.UseVisualStyleBackColor = true;
			this.bpAddZone.Click += new System.EventHandler(this.bpAddZone_Click);
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(2, 2);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(640, 400);
			this.pictureBox.TabIndex = 18;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.pictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseUp);
			// 
			// EditZones
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(795, 415);
			this.Controls.Add(this.bpDelZone);
			this.Controls.Add(this.typeZone);
			this.Controls.Add(this.allZones);
			this.Controls.Add(this.listZone);
			this.Controls.Add(this.bpAddZone);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditZones";
			this.Text = "EditZones";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bpDelZone;
		private System.Windows.Forms.ComboBox typeZone;
		private System.Windows.Forms.CheckBox allZones;
		private System.Windows.Forms.ListBox listZone;
		private System.Windows.Forms.Button bpAddZone;
		private System.Windows.Forms.PictureBox pictureBox;
	}
}