namespace PJA {
	partial class SelectLieu {
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
			this.listLieu = new System.Windows.Forms.ListBox();
			this.bpValide = new System.Windows.Forms.Button();
			this.bpAnnule = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listLieu
			// 
			this.listLieu.FormattingEnabled = true;
			this.listLieu.Location = new System.Drawing.Point(1, 1);
			this.listLieu.Name = "listLieu";
			this.listLieu.Size = new System.Drawing.Size(333, 329);
			this.listLieu.TabIndex = 0;
			this.listLieu.SelectedIndexChanged += new System.EventHandler(this.listLieu_SelectedIndexChanged);
			// 
			// bpValide
			// 
			this.bpValide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpValide.Location = new System.Drawing.Point(1, 336);
			this.bpValide.Name = "bpValide";
			this.bpValide.Size = new System.Drawing.Size(75, 35);
			this.bpValide.TabIndex = 1;
			this.bpValide.Text = "Valider";
			this.bpValide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpValide.UseVisualStyleBackColor = true;
			this.bpValide.Click += new System.EventHandler(this.bpValide_Click);
			// 
			// bpAnnule
			// 
			this.bpAnnule.Image = global::PJA.Properties.Resources.Del;
			this.bpAnnule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAnnule.Location = new System.Drawing.Point(259, 338);
			this.bpAnnule.Name = "bpAnnule";
			this.bpAnnule.Size = new System.Drawing.Size(75, 33);
			this.bpAnnule.TabIndex = 1;
			this.bpAnnule.Text = "Annuler";
			this.bpAnnule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAnnule.UseVisualStyleBackColor = true;
			this.bpAnnule.Click += new System.EventHandler(this.bpAnnule_Click);
			// 
			// SelectLieu
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(335, 373);
			this.ControlBox = false;
			this.Controls.Add(this.bpAnnule);
			this.Controls.Add(this.bpValide);
			this.Controls.Add(this.listLieu);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectLieu";
			this.Text = "SelectLieu";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listLieu;
		private System.Windows.Forms.Button bpValide;
		private System.Windows.Forms.Button bpAnnule;
	}
}