namespace PJA {
	partial class Main {
		/// <summary>
		/// Variable nécessaire au concepteur.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Nettoyage des ressources utilisées.
		/// </summary>
		/// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Code généré par le Concepteur Windows Form

		/// <summary>
		/// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
		/// le contenu de cette méthode avec l'éditeur de code.
		/// </summary>
		private void InitializeComponent() {
			this.bpEditMap = new System.Windows.Forms.Button();
			this.bpEditImg = new System.Windows.Forms.Button();
			this.nbCols = new System.Windows.Forms.NumericUpDown();
			this.nbLignes = new System.Windows.Forms.NumericUpDown();
			this.bpLoad = new System.Windows.Forms.Button();
			this.bpSave = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.mode = new System.Windows.Forms.ComboBox();
			this.bpNew = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.nbCols)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.nbLignes)).BeginInit();
			this.SuspendLayout();
			// 
			// bpEditMap
			// 
			this.bpEditMap.Location = new System.Drawing.Point(384, 137);
			this.bpEditMap.Name = "bpEditMap";
			this.bpEditMap.Size = new System.Drawing.Size(75, 40);
			this.bpEditMap.TabIndex = 0;
			this.bpEditMap.Text = "Editeur de carte";
			this.bpEditMap.UseVisualStyleBackColor = true;
			this.bpEditMap.Click += new System.EventHandler(this.EditMapClick);
			// 
			// bpEditImg
			// 
			this.bpEditImg.Location = new System.Drawing.Point(384, 183);
			this.bpEditImg.Name = "bpEditImg";
			this.bpEditImg.Size = new System.Drawing.Size(75, 40);
			this.bpEditImg.TabIndex = 1;
			this.bpEditImg.Text = "Editeur d\'images";
			this.bpEditImg.UseVisualStyleBackColor = true;
			this.bpEditImg.Click += new System.EventHandler(this.EditImgClick);
			// 
			// nbCols
			// 
			this.nbCols.Location = new System.Drawing.Point(162, 149);
			this.nbCols.Maximum = new decimal(new int[] {
            96,
            0,
            0,
            0});
			this.nbCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.nbCols.Name = "nbCols";
			this.nbCols.Size = new System.Drawing.Size(61, 20);
			this.nbCols.TabIndex = 2;
			this.nbCols.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
			this.nbCols.ValueChanged += new System.EventHandler(this.nbCols_ValueChanged);
			// 
			// nbLignes
			// 
			this.nbLignes.Location = new System.Drawing.Point(162, 175);
			this.nbLignes.Maximum = new decimal(new int[] {
            35,
            0,
            0,
            0});
			this.nbLignes.Name = "nbLignes";
			this.nbLignes.Size = new System.Drawing.Size(61, 20);
			this.nbLignes.TabIndex = 2;
			this.nbLignes.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
			this.nbLignes.ValueChanged += new System.EventHandler(this.nbLignes_ValueChanged);
			// 
			// bpLoad
			// 
			this.bpLoad.Location = new System.Drawing.Point(12, 41);
			this.bpLoad.Name = "bpLoad";
			this.bpLoad.Size = new System.Drawing.Size(101, 23);
			this.bpLoad.TabIndex = 3;
			this.bpLoad.Text = "Charger projet";
			this.bpLoad.UseVisualStyleBackColor = true;
			this.bpLoad.Click += new System.EventHandler(this.bpLoad_Click);
			// 
			// bpSave
			// 
			this.bpSave.Location = new System.Drawing.Point(12, 70);
			this.bpSave.Name = "bpSave";
			this.bpSave.Size = new System.Drawing.Size(101, 23);
			this.bpSave.TabIndex = 3;
			this.bpSave.Text = "Sauver projet";
			this.bpSave.UseVisualStyleBackColor = true;
			this.bpSave.Click += new System.EventHandler(this.bpSave_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(88, 151);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 13);
			this.label1.TabIndex = 8;
			this.label1.Text = "Nb Colonnes";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(101, 177);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(55, 13);
			this.label2.TabIndex = 9;
			this.label2.Text = "Nb Lignes";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(122, 204);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(34, 13);
			this.label3.TabIndex = 10;
			this.label3.Text = "Mode";
			// 
			// mode
			// 
			this.mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.mode.FormattingEnabled = true;
			this.mode.Items.AddRange(new object[] {
            "0",
            "1",
            "2"});
			this.mode.Location = new System.Drawing.Point(162, 201);
			this.mode.Name = "mode";
			this.mode.Size = new System.Drawing.Size(44, 21);
			this.mode.TabIndex = 11;
			this.mode.SelectedIndexChanged += new System.EventHandler(this.mode_SelectedIndexChanged);
			// 
			// bpNew
			// 
			this.bpNew.Location = new System.Drawing.Point(12, 12);
			this.bpNew.Name = "bpNew";
			this.bpNew.Size = new System.Drawing.Size(101, 23);
			this.bpNew.TabIndex = 3;
			this.bpNew.Text = "Nouveau projet";
			this.bpNew.UseVisualStyleBackColor = true;
			this.bpNew.Click += new System.EventHandler(this.bpNew_Click);
			// 
			// Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(532, 398);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.mode);
			this.Controls.Add(this.bpNew);
			this.Controls.Add(this.bpSave);
			this.Controls.Add(this.bpLoad);
			this.Controls.Add(this.nbLignes);
			this.Controls.Add(this.nbCols);
			this.Controls.Add(this.bpEditImg);
			this.Controls.Add(this.bpEditMap);
			this.Name = "Main";
			this.Text = "Menu principal";
			((System.ComponentModel.ISupportInitialize)(this.nbCols)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.nbLignes)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bpEditMap;
		private System.Windows.Forms.Button bpEditImg;
		private System.Windows.Forms.NumericUpDown nbCols;
		private System.Windows.Forms.NumericUpDown nbLignes;
		private System.Windows.Forms.Button bpLoad;
		private System.Windows.Forms.Button bpSave;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox mode;
		private System.Windows.Forms.Button bpNew;
	}
}

