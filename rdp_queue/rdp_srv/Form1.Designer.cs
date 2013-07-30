namespace rdp_srv
{
	partial class Form1
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnLock = new System.Windows.Forms.Button();
			this.btnFree = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnLock
			// 
			this.btnLock.BackColor = System.Drawing.Color.Maroon;
			this.btnLock.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnLock.ForeColor = System.Drawing.Color.WhiteSmoke;
			this.btnLock.Location = new System.Drawing.Point(12, 12);
			this.btnLock.Name = "btnLock";
			this.btnLock.Size = new System.Drawing.Size(175, 133);
			this.btnLock.TabIndex = 0;
			this.btnLock.Text = "Занял";
			this.btnLock.UseVisualStyleBackColor = false;
			this.btnLock.Click += new System.EventHandler(this.btnLock_Click);
			// 
			// btnFree
			// 
			this.btnFree.BackColor = System.Drawing.Color.LightGreen;
			this.btnFree.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.btnFree.Location = new System.Drawing.Point(231, 12);
			this.btnFree.Name = "btnFree";
			this.btnFree.Size = new System.Drawing.Size(153, 133);
			this.btnFree.TabIndex = 1;
			this.btnFree.Text = "Освободил";
			this.btnFree.UseVisualStyleBackColor = false;
			this.btnFree.Click += new System.EventHandler(this.btnFree_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(405, 165);
			this.Controls.Add(this.btnFree);
			this.Controls.Add(this.btnLock);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Queue";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnLock;
		private System.Windows.Forms.Button btnFree;
	}
}

