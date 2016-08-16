namespace PJA {
	partial class EditVariables {
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
			this.listVariables = new System.Windows.Forms.ListView();
			this.colIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colLibelle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colValeur = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.textLibelle = new System.Windows.Forms.TextBox();
			this.textValeur = new System.Windows.Forms.TextBox();
			this.bpAdd = new System.Windows.Forms.Button();
			this.bpDel = new System.Windows.Forms.Button();
			this.bpEdit = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// listVariables
			// 
			this.listVariables.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colIndex,
            this.colLibelle,
            this.colValeur});
			this.listVariables.FullRowSelect = true;
			this.listVariables.GridLines = true;
			this.listVariables.Location = new System.Drawing.Point(0, 2);
			this.listVariables.MultiSelect = false;
			this.listVariables.Name = "listVariables";
			this.listVariables.Size = new System.Drawing.Size(399, 202);
			this.listVariables.TabIndex = 0;
			this.listVariables.UseCompatibleStateImageBehavior = false;
			this.listVariables.View = System.Windows.Forms.View.Details;
			this.listVariables.SelectedIndexChanged += new System.EventHandler(this.listVariables_SelectedIndexChanged);
			// 
			// colIndex
			// 
			this.colIndex.Text = "Index";
			// 
			// colLibelle
			// 
			this.colLibelle.Text = "Libellé";
			this.colLibelle.Width = 247;
			// 
			// colValeur
			// 
			this.colValeur.Text = "Valeur";
			// 
			// textLibelle
			// 
			this.textLibelle.Location = new System.Drawing.Point(74, 217);
			this.textLibelle.Name = "textLibelle";
			this.textLibelle.Size = new System.Drawing.Size(232, 20);
			this.textLibelle.TabIndex = 1;
			this.textLibelle.TextChanged += new System.EventHandler(this.textLibelle_TextChanged);
			// 
			// textValeur
			// 
			this.textValeur.Location = new System.Drawing.Point(312, 217);
			this.textValeur.Name = "textValeur";
			this.textValeur.Size = new System.Drawing.Size(53, 20);
			this.textValeur.TabIndex = 1;
			// 
			// bpAdd
			// 
			this.bpAdd.Enabled = false;
			this.bpAdd.Image = global::PJA.Properties.Resources.Add;
			this.bpAdd.Location = new System.Drawing.Point(0, 210);
			this.bpAdd.Name = "bpAdd";
			this.bpAdd.Size = new System.Drawing.Size(32, 32);
			this.bpAdd.TabIndex = 2;
			this.bpAdd.UseVisualStyleBackColor = true;
			this.bpAdd.Click += new System.EventHandler(this.bpAdd_Click);
			// 
			// bpDel
			// 
			this.bpDel.Enabled = false;
			this.bpDel.Image = global::PJA.Properties.Resources.Del;
			this.bpDel.Location = new System.Drawing.Point(367, 210);
			this.bpDel.Name = "bpDel";
			this.bpDel.Size = new System.Drawing.Size(32, 32);
			this.bpDel.TabIndex = 2;
			this.bpDel.UseVisualStyleBackColor = true;
			this.bpDel.Click += new System.EventHandler(this.bpDel_Click);
			// 
			// bpEdit
			// 
			this.bpEdit.Enabled = false;
			this.bpEdit.Image = global::PJA.Properties.Resources.Edit;
			this.bpEdit.Location = new System.Drawing.Point(38, 210);
			this.bpEdit.Name = "bpEdit";
			this.bpEdit.Size = new System.Drawing.Size(32, 32);
			this.bpEdit.TabIndex = 2;
			this.bpEdit.UseVisualStyleBackColor = true;
			this.bpEdit.Click += new System.EventHandler(this.bpEdit_Click);
			// 
			// EditVariables
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(399, 241);
			this.Controls.Add(this.bpEdit);
			this.Controls.Add(this.bpDel);
			this.Controls.Add(this.bpAdd);
			this.Controls.Add(this.textValeur);
			this.Controls.Add(this.textLibelle);
			this.Controls.Add(this.listVariables);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditVariables";
			this.Text = "EditVariables";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditVariables_FormClosing);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listVariables;
		private System.Windows.Forms.ColumnHeader colIndex;
		private System.Windows.Forms.ColumnHeader colLibelle;
		private System.Windows.Forms.ColumnHeader colValeur;
		private System.Windows.Forms.TextBox textLibelle;
		private System.Windows.Forms.TextBox textValeur;
		private System.Windows.Forms.Button bpAdd;
		private System.Windows.Forms.Button bpDel;
		private System.Windows.Forms.Button bpEdit;
	}
}