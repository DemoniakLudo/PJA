namespace PJA {
	partial class PredefPal {
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
			this.listPal = new System.Windows.Forms.ListBox();
			this.paletteName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.bpUse = new System.Windows.Forms.Button();
			this.bpSuppr = new System.Windows.Forms.Button();
			this.bpAdd = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listPal
			// 
			this.listPal.FormattingEnabled = true;
			this.listPal.Location = new System.Drawing.Point(1, 2);
			this.listPal.Name = "listPal";
			this.listPal.Size = new System.Drawing.Size(289, 251);
			this.listPal.TabIndex = 0;
			this.listPal.DoubleClick += new System.EventHandler(this.listPal_DoubleClick);
			// 
			// paletteName
			// 
			this.paletteName.Location = new System.Drawing.Point(44, 259);
			this.paletteName.Name = "paletteName";
			this.paletteName.Size = new System.Drawing.Size(225, 20);
			this.paletteName.TabIndex = 21;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 262);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(32, 13);
			this.label1.TabIndex = 20;
			this.label1.Text = "Nom:";
			// 
			// bpUse
			// 
			this.bpUse.Image = global::PJA.Properties.Resources.Palette;
			this.bpUse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpUse.Location = new System.Drawing.Point(204, 290);
			this.bpUse.Name = "bpUse";
			this.bpUse.Size = new System.Drawing.Size(86, 33);
			this.bpUse.TabIndex = 17;
			this.bpUse.Text = "Utiliser";
			this.bpUse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpUse.UseVisualStyleBackColor = true;
			this.bpUse.Click += new System.EventHandler(this.bpUse_Click);
			// 
			// bpSuppr
			// 
			this.bpSuppr.Image = global::PJA.Properties.Resources.Del;
			this.bpSuppr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpSuppr.Location = new System.Drawing.Point(102, 290);
			this.bpSuppr.Name = "bpSuppr";
			this.bpSuppr.Size = new System.Drawing.Size(86, 33);
			this.bpSuppr.TabIndex = 18;
			this.bpSuppr.Text = "Supprimer";
			this.bpSuppr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpSuppr.UseVisualStyleBackColor = true;
			this.bpSuppr.Click += new System.EventHandler(this.bpSuppr_Click);
			// 
			// bpAdd
			// 
			this.bpAdd.Image = global::PJA.Properties.Resources.Add;
			this.bpAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAdd.Location = new System.Drawing.Point(1, 290);
			this.bpAdd.Name = "bpAdd";
			this.bpAdd.Size = new System.Drawing.Size(86, 33);
			this.bpAdd.TabIndex = 19;
			this.bpAdd.Text = "Ajouter";
			this.bpAdd.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAdd.UseVisualStyleBackColor = true;
			this.bpAdd.Click += new System.EventHandler(this.bpAdd_Click);
			// 
			// PredefPal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(292, 326);
			this.Controls.Add(this.paletteName);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.bpUse);
			this.Controls.Add(this.bpSuppr);
			this.Controls.Add(this.bpAdd);
			this.Controls.Add(this.listPal);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PredefPal";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Palettes prédéfinies";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox listPal;
		private System.Windows.Forms.TextBox paletteName;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button bpUse;
		private System.Windows.Forms.Button bpSuppr;
		private System.Windows.Forms.Button bpAdd;
	}
}