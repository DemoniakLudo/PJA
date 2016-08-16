namespace PJA {
	partial class AjouteZone {
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
			this.label1 = new System.Windows.Forms.Label();
			this.bpValide = new System.Windows.Forms.Button();
			this.bpAnnule = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// typeZone
			// 
			this.typeZone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeZone.FormattingEnabled = true;
			this.typeZone.Location = new System.Drawing.Point(96, 6);
			this.typeZone.Name = "typeZone";
			this.typeZone.Size = new System.Drawing.Size(117, 21);
			this.typeZone.TabIndex = 48;
			this.typeZone.SelectedIndexChanged += new System.EventHandler(this.typeZone_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(78, 13);
			this.label1.TabIndex = 49;
			this.label1.Text = "Type de zone :";
			// 
			// bpValide
			// 
			this.bpValide.Location = new System.Drawing.Point(12, 50);
			this.bpValide.Name = "bpValide";
			this.bpValide.Size = new System.Drawing.Size(75, 23);
			this.bpValide.TabIndex = 50;
			this.bpValide.Text = "Valider";
			this.bpValide.UseVisualStyleBackColor = true;
			this.bpValide.Click += new System.EventHandler(this.bpValide_Click);
			// 
			// bpAnnule
			// 
			this.bpAnnule.Location = new System.Drawing.Point(132, 50);
			this.bpAnnule.Name = "bpAnnule";
			this.bpAnnule.Size = new System.Drawing.Size(75, 23);
			this.bpAnnule.TabIndex = 51;
			this.bpAnnule.Text = "Annuler";
			this.bpAnnule.UseVisualStyleBackColor = true;
			this.bpAnnule.Click += new System.EventHandler(this.bpAnnule_Click);
			// 
			// AjouteZone
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(219, 83);
			this.Controls.Add(this.bpAnnule);
			this.Controls.Add(this.bpValide);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.typeZone);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "AjouteZone";
			this.Text = "AjouteZone";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox typeZone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bpValide;
		private System.Windows.Forms.Button bpAnnule;
	}
}