namespace PJA {
	partial class ChoixAction {
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
			this.typeAction = new System.Windows.Forms.ComboBox();
			this.bpValide = new System.Windows.Forms.Button();
			this.listAction = new System.Windows.Forms.ListBox();
			this.bpEditAction = new System.Windows.Forms.Button();
			this.bpAddAction = new System.Windows.Forms.Button();
			this.bpDelAction = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// typeAction
			// 
			this.typeAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.typeAction.FormattingEnabled = true;
			this.typeAction.Location = new System.Drawing.Point(293, 2);
			this.typeAction.Name = "typeAction";
			this.typeAction.Size = new System.Drawing.Size(121, 21);
			this.typeAction.TabIndex = 0;
			this.typeAction.SelectedIndexChanged += new System.EventHandler(this.typeAction_SelectedIndexChanged);
			// 
			// bpValide
			// 
			this.bpValide.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpValide.Location = new System.Drawing.Point(-1, 297);
			this.bpValide.Name = "bpValide";
			this.bpValide.Size = new System.Drawing.Size(75, 35);
			this.bpValide.TabIndex = 3;
			this.bpValide.Text = "Terminer";
			this.bpValide.UseVisualStyleBackColor = true;
			this.bpValide.Click += new System.EventHandler(this.bpValide_Click);
			// 
			// listAction
			// 
			this.listAction.FormattingEnabled = true;
			this.listAction.Location = new System.Drawing.Point(-1, 2);
			this.listAction.Name = "listAction";
			this.listAction.Size = new System.Drawing.Size(267, 225);
			this.listAction.TabIndex = 4;
			this.listAction.SelectedIndexChanged += new System.EventHandler(this.listAction_SelectedIndexChanged);
			// 
			// bpEditAction
			// 
			this.bpEditAction.Enabled = false;
			this.bpEditAction.Image = global::PJA.Properties.Resources.Edit;
			this.bpEditAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpEditAction.Location = new System.Drawing.Point(293, 69);
			this.bpEditAction.Name = "bpEditAction";
			this.bpEditAction.Size = new System.Drawing.Size(113, 34);
			this.bpEditAction.TabIndex = 45;
			this.bpEditAction.Text = "Editer Action";
			this.bpEditAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpEditAction.UseVisualStyleBackColor = true;
			this.bpEditAction.Click += new System.EventHandler(this.bpEditAction_Click);
			// 
			// bpAddAction
			// 
			this.bpAddAction.Image = global::PJA.Properties.Resources.Add;
			this.bpAddAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpAddAction.Location = new System.Drawing.Point(293, 29);
			this.bpAddAction.Name = "bpAddAction";
			this.bpAddAction.Size = new System.Drawing.Size(113, 34);
			this.bpAddAction.TabIndex = 44;
			this.bpAddAction.Text = "Ajouter Action";
			this.bpAddAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpAddAction.UseVisualStyleBackColor = true;
			this.bpAddAction.Click += new System.EventHandler(this.bpAddAction_Click);
			// 
			// bpDelAction
			// 
			this.bpDelAction.Enabled = false;
			this.bpDelAction.Image = global::PJA.Properties.Resources.Del;
			this.bpDelAction.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.bpDelAction.Location = new System.Drawing.Point(293, 109);
			this.bpDelAction.Name = "bpDelAction";
			this.bpDelAction.Size = new System.Drawing.Size(113, 34);
			this.bpDelAction.TabIndex = 43;
			this.bpDelAction.Text = "Supprimer Action";
			this.bpDelAction.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.bpDelAction.UseVisualStyleBackColor = true;
			this.bpDelAction.Click += new System.EventHandler(this.bpDelAction_Click);
			// 
			// ChoixAction
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(717, 333);
			this.ControlBox = false;
			this.Controls.Add(this.bpEditAction);
			this.Controls.Add(this.bpAddAction);
			this.Controls.Add(this.bpDelAction);
			this.Controls.Add(this.listAction);
			this.Controls.Add(this.bpValide);
			this.Controls.Add(this.typeAction);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "ChoixAction";
			this.Text = "ChoixAction";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox typeAction;
		private System.Windows.Forms.Button bpValide;
		private System.Windows.Forms.ListBox listAction;
		private System.Windows.Forms.Button bpEditAction;
		private System.Windows.Forms.Button bpAddAction;
		private System.Windows.Forms.Button bpDelAction;
	}
}