namespace PJA.Interface {
	partial class SelectTexte {
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
			this.listTexte = new System.Windows.Forms.ListBox();
			this.nouvTexte = new System.Windows.Forms.TextBox();
			this.bpAnnule = new System.Windows.Forms.Button();
			this.bpValide = new System.Windows.Forms.Button();
			this.bpAddTexte = new System.Windows.Forms.Button();
			this.bpDelTexte = new System.Windows.Forms.Button();
			this.bpEditTexte = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listTexte
			// 
			this.listTexte.FormattingEnabled = true;
			this.listTexte.Location = new System.Drawing.Point(4, 7);
			this.listTexte.Name = "listTexte";
			this.listTexte.Size = new System.Drawing.Size(581, 251);
			this.listTexte.TabIndex = 0;
			// 
			// nouvTexte
			// 
			this.nouvTexte.Location = new System.Drawing.Point(4, 264);
			this.nouvTexte.Multiline = true;
			this.nouvTexte.Name = "nouvTexte";
			this.nouvTexte.Size = new System.Drawing.Size(581, 113);
			this.nouvTexte.TabIndex = 1;
			this.nouvTexte.TextChanged += new System.EventHandler(this.nouvTexte_TextChanged);
			// 
			// bpAnnule
			// 
			this.bpAnnule.Image = global::PJA.Properties.Resources.Del;
			this.bpAnnule.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAnnule.Location = new System.Drawing.Point(510, 444);
			this.bpAnnule.Name = "bpAnnule";
			this.bpAnnule.Size = new System.Drawing.Size(75, 33);
			this.bpAnnule.TabIndex = 2;
			this.bpAnnule.Text = "Annuler";
			this.bpAnnule.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAnnule.UseVisualStyleBackColor = true;
			this.bpAnnule.Click += new System.EventHandler(this.bpAnnule_Click);
			// 
			// bpValide
			// 
			this.bpValide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpValide.Location = new System.Drawing.Point(4, 442);
			this.bpValide.Name = "bpValide";
			this.bpValide.Size = new System.Drawing.Size(75, 35);
			this.bpValide.TabIndex = 3;
			this.bpValide.Text = "Valider";
			this.bpValide.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpValide.UseVisualStyleBackColor = true;
			this.bpValide.Click += new System.EventHandler(this.bpValide_Click);
			// 
			// bpAddTexte
			// 
			this.bpAddTexte.Enabled = false;
			this.bpAddTexte.Image = global::PJA.Properties.Resources.Add;
			this.bpAddTexte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddTexte.Location = new System.Drawing.Point(4, 383);
			this.bpAddTexte.Name = "bpAddTexte";
			this.bpAddTexte.Size = new System.Drawing.Size(108, 34);
			this.bpAddTexte.TabIndex = 42;
			this.bpAddTexte.Text = "Ajouter Texte";
			this.bpAddTexte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddTexte.UseVisualStyleBackColor = true;
			// 
			// bpDelTexte
			// 
			this.bpDelTexte.Enabled = false;
			this.bpDelTexte.Image = global::PJA.Properties.Resources.Del;
			this.bpDelTexte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelTexte.Location = new System.Drawing.Point(472, 383);
			this.bpDelTexte.Name = "bpDelTexte";
			this.bpDelTexte.Size = new System.Drawing.Size(113, 34);
			this.bpDelTexte.TabIndex = 41;
			this.bpDelTexte.Text = "Supprimer Texte";
			this.bpDelTexte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelTexte.UseVisualStyleBackColor = true;
			// 
			// bpEditTexte
			// 
			this.bpEditTexte.Enabled = false;
			this.bpEditTexte.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditTexte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditTexte.Location = new System.Drawing.Point(240, 383);
			this.bpEditTexte.Name = "bpEditTexte";
			this.bpEditTexte.Size = new System.Drawing.Size(108, 34);
			this.bpEditTexte.TabIndex = 42;
			this.bpEditTexte.Text = "Editer Texte";
			this.bpEditTexte.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditTexte.UseVisualStyleBackColor = true;
			// 
			// SelectTexte
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(588, 478);
			this.ControlBox = false;
			this.Controls.Add(this.bpEditTexte);
			this.Controls.Add(this.bpAddTexte);
			this.Controls.Add(this.bpDelTexte);
			this.Controls.Add(this.bpAnnule);
			this.Controls.Add(this.bpValide);
			this.Controls.Add(this.nouvTexte);
			this.Controls.Add(this.listTexte);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "SelectTexte";
			this.Text = "SelectTexte";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listTexte;
		private System.Windows.Forms.TextBox nouvTexte;
		private System.Windows.Forms.Button bpAnnule;
		private System.Windows.Forms.Button bpValide;
		private System.Windows.Forms.Button bpAddTexte;
		private System.Windows.Forms.Button bpDelTexte;
		private System.Windows.Forms.Button bpEditTexte;
	}
}