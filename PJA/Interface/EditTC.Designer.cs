namespace PJA {
	partial class EditTC {
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
			this.listTC = new System.Windows.Forms.ListView();
			this.colVar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colCdt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colCste = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.colAction = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.bpEdit = new System.Windows.Forms.Button();
			this.bpDel = new System.Windows.Forms.Button();
			this.bpAdd = new System.Windows.Forms.Button();
			this.comboVar = new System.Windows.Forms.ComboBox();
			this.comboCdt = new System.Windows.Forms.ComboBox();
			this.comboAct = new System.Windows.Forms.ComboBox();
			this.textCste = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// listTC
			// 
			this.listTC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colVar,
            this.colCdt,
            this.colCste,
            this.colAction});
			this.listTC.FullRowSelect = true;
			this.listTC.GridLines = true;
			this.listTC.Location = new System.Drawing.Point(2, 2);
			this.listTC.MultiSelect = false;
			this.listTC.Name = "listTC";
			this.listTC.Size = new System.Drawing.Size(570, 281);
			this.listTC.TabIndex = 0;
			this.listTC.UseCompatibleStateImageBehavior = false;
			this.listTC.View = System.Windows.Forms.View.Details;
			this.listTC.SelectedIndexChanged += new System.EventHandler(this.listTC_SelectedIndexChanged);
			// 
			// colVar
			// 
			this.colVar.Text = "Variable";
			// 
			// colCdt
			// 
			this.colCdt.Text = "Condition";
			this.colCdt.Width = 167;
			// 
			// colCste
			// 
			this.colCste.Text = "Valeur";
			// 
			// colAction
			// 
			this.colAction.Text = "Action";
			this.colAction.Width = 242;
			// 
			// bpEdit
			// 
			this.bpEdit.Enabled = false;
			this.bpEdit.Image = global::PJA.Properties.Resources.Edit;
			this.bpEdit.Location = new System.Drawing.Point(12, 332);
			this.bpEdit.Name = "bpEdit";
			this.bpEdit.Size = new System.Drawing.Size(32, 32);
			this.bpEdit.TabIndex = 3;
			this.bpEdit.UseVisualStyleBackColor = true;
			this.bpEdit.Click += new System.EventHandler(this.bpEdit_Click);
			// 
			// bpDel
			// 
			this.bpDel.Enabled = false;
			this.bpDel.Image = global::PJA.Properties.Resources.Del;
			this.bpDel.Location = new System.Drawing.Point(12, 370);
			this.bpDel.Name = "bpDel";
			this.bpDel.Size = new System.Drawing.Size(32, 32);
			this.bpDel.TabIndex = 4;
			this.bpDel.UseVisualStyleBackColor = true;
			this.bpDel.Click += new System.EventHandler(this.bpDel_Click);
			// 
			// bpAdd
			// 
			this.bpAdd.Enabled = false;
			this.bpAdd.Image = global::PJA.Properties.Resources.Add;
			this.bpAdd.Location = new System.Drawing.Point(12, 294);
			this.bpAdd.Name = "bpAdd";
			this.bpAdd.Size = new System.Drawing.Size(32, 32);
			this.bpAdd.TabIndex = 5;
			this.bpAdd.UseVisualStyleBackColor = true;
			this.bpAdd.Click += new System.EventHandler(this.bpAdd_Click);
			// 
			// comboVar
			// 
			this.comboVar.FormattingEnabled = true;
			this.comboVar.Location = new System.Drawing.Point(144, 294);
			this.comboVar.Name = "comboVar";
			this.comboVar.Size = new System.Drawing.Size(254, 21);
			this.comboVar.TabIndex = 6;
			this.comboVar.SelectedIndexChanged += new System.EventHandler(this.comboVar_SelectedIndexChanged);
			// 
			// comboCdt
			// 
			this.comboCdt.FormattingEnabled = true;
			this.comboCdt.Location = new System.Drawing.Point(144, 350);
			this.comboCdt.Name = "comboCdt";
			this.comboCdt.Size = new System.Drawing.Size(254, 21);
			this.comboCdt.TabIndex = 6;
			// 
			// comboAct
			// 
			this.comboAct.FormattingEnabled = true;
			this.comboAct.Location = new System.Drawing.Point(144, 377);
			this.comboAct.Name = "comboAct";
			this.comboAct.Size = new System.Drawing.Size(254, 21);
			this.comboAct.TabIndex = 6;
			this.comboAct.SelectedIndexChanged += new System.EventHandler(this.comboAct_SelectedIndexChanged);
			// 
			// textCste
			// 
			this.textCste.Location = new System.Drawing.Point(144, 324);
			this.textCste.Name = "textCste";
			this.textCste.Size = new System.Drawing.Size(100, 20);
			this.textCste.TabIndex = 7;
			this.textCste.TextChanged += new System.EventHandler(this.textCste_TextChanged);
			// 
			// EditTC
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 421);
			this.Controls.Add(this.textCste);
			this.Controls.Add(this.comboAct);
			this.Controls.Add(this.comboCdt);
			this.Controls.Add(this.comboVar);
			this.Controls.Add(this.bpEdit);
			this.Controls.Add(this.bpDel);
			this.Controls.Add(this.bpAdd);
			this.Controls.Add(this.listTC);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "EditTC";
			this.Text = "Edition Traitement Conditionnel";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView listTC;
		private System.Windows.Forms.ColumnHeader colVar;
		private System.Windows.Forms.ColumnHeader colCdt;
		private System.Windows.Forms.ColumnHeader colCste;
		private System.Windows.Forms.ColumnHeader colAction;
		private System.Windows.Forms.Button bpEdit;
		private System.Windows.Forms.Button bpDel;
		private System.Windows.Forms.Button bpAdd;
		private System.Windows.Forms.ComboBox comboVar;
		private System.Windows.Forms.ComboBox comboCdt;
		private System.Windows.Forms.ComboBox comboAct;
		private System.Windows.Forms.TextBox textCste;
	}
}