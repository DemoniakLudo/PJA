﻿namespace PJA {
	partial class PixelImage {
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
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.zoomLevel = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox
			// 
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(768, 544);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			// 
			// zoomLevel
			// 
			this.zoomLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.zoomLevel.FormattingEnabled = true;
			this.zoomLevel.Items.AddRange(new object[] {
            "1",
            "2",
            "4",
            "8"});
			this.zoomLevel.Location = new System.Drawing.Point(858, 72);
			this.zoomLevel.Name = "zoomLevel";
			this.zoomLevel.Size = new System.Drawing.Size(121, 21);
			this.zoomLevel.TabIndex = 1;
			this.zoomLevel.SelectedIndexChanged += new System.EventHandler(this.zoomLevel_SelectedIndexChanged);
			// 
			// PixelImage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1056, 758);
			this.Controls.Add(this.zoomLevel);
			this.Controls.Add(this.pictureBox);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PixelImage";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Editeur d\'images";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ComboBox zoomLevel;

	}
}