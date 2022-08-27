/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 8/27/2022
 * Time: 11:19 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LineWorldsLauncher
{
	partial class FlowLayoutItem
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		public System.Windows.Forms.Label MainTitle;
		public System.Windows.Forms.Label SecondaryLabel;
		
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
			this.MainTitle = new System.Windows.Forms.Label();
			this.SecondaryLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// MainTitle
			// 
			this.MainTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.MainTitle.Location = new System.Drawing.Point(13, 14);
			this.MainTitle.Name = "MainTitle";
			this.MainTitle.Size = new System.Drawing.Size(388, 14);
			this.MainTitle.TabIndex = 1;
			this.MainTitle.Text = "Editor";
			this.MainTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.MainTitle.Click += new System.EventHandler(this.MainTitleClick);
			this.MainTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MainTitleMouseDown);
			// 
			// SecondaryLabel
			// 
			this.SecondaryLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.SecondaryLabel.Location = new System.Drawing.Point(304, 14);
			this.SecondaryLabel.Name = "SecondaryLabel";
			this.SecondaryLabel.Size = new System.Drawing.Size(97, 14);
			this.SecondaryLabel.TabIndex = 2;
			this.SecondaryLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.SecondaryLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.SecondaryLabelMouseDown);
			// 
			// FlowLayoutItem
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
			this.Controls.Add(this.SecondaryLabel);
			this.Controls.Add(this.MainTitle);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.Name = "FlowLayoutItem";
			this.Size = new System.Drawing.Size(414, 42);
			this.Load += new System.EventHandler(this.FlowLayoutItemLoad);
			this.ResumeLayout(false);

		}
	}
}
