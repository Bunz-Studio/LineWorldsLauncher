﻿/*
 * Created by SharpDevelop.
 * User: Bunzhi
 * Date: 24/08/2022
 * Time: 22:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class EditorListItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label editorTitleLabel;
		private System.Windows.Forms.Label editorPathLabel;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.editorTitleLabel = new System.Windows.Forms.Label();
			this.editorPathLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// editorTitleLabel
			// 
			this.editorTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.editorTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
			this.editorTitleLabel.Location = new System.Drawing.Point(12, 15);
			this.editorTitleLabel.Name = "editorTitleLabel";
			this.editorTitleLabel.Size = new System.Drawing.Size(494, 23);
			this.editorTitleLabel.TabIndex = 0;
			this.editorTitleLabel.Text = "EditorName";
			// 
			// editorPathLabel
			// 
			this.editorPathLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.editorPathLabel.Location = new System.Drawing.Point(14, 39);
			this.editorPathLabel.Name = "editorPathLabel";
			this.editorPathLabel.Size = new System.Drawing.Size(492, 23);
			this.editorPathLabel.TabIndex = 1;
			this.editorPathLabel.Text = "C:/ProjectPath/";
			// 
			// EditorListItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.Controls.Add(this.editorPathLabel);
			this.Controls.Add(this.editorTitleLabel);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "EditorListItem";
			this.Size = new System.Drawing.Size(526, 69);
			this.ResumeLayout(false);

		}
	}
}
