namespace rdp_queue_client
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
			this.components = new System.ComponentModel.Container();
			this.lbQueue = new System.Windows.Forms.ListBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.btnEnqueue = new System.Windows.Forms.Button();
			this.lblServerState = new System.Windows.Forms.Label();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.btnGoOutFromQueue = new System.Windows.Forms.Button();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// lbQueue
			// 
			this.lbQueue.FormattingEnabled = true;
			this.lbQueue.Location = new System.Drawing.Point(3, 16);
			this.lbQueue.Name = "lbQueue";
			this.lbQueue.Size = new System.Drawing.Size(219, 173);
			this.lbQueue.TabIndex = 0;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.btnGoOutFromQueue);
			this.groupBox1.Controls.Add(this.lbQueue);
			this.groupBox1.Controls.Add(this.btnEnqueue);
			this.groupBox1.Location = new System.Drawing.Point(12, 43);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(350, 201);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Очередь";
			// 
			// btnEnqueue
			// 
			this.btnEnqueue.Location = new System.Drawing.Point(227, 16);
			this.btnEnqueue.Name = "btnEnqueue";
			this.btnEnqueue.Size = new System.Drawing.Size(117, 80);
			this.btnEnqueue.TabIndex = 2;
			this.btnEnqueue.Text = "Встать в очередь";
			this.btnEnqueue.UseVisualStyleBackColor = true;
			this.btnEnqueue.Click += new System.EventHandler(this.btnEnqueue_Click);
			// 
			// lblServerState
			// 
			this.lblServerState.AutoSize = true;
			this.lblServerState.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lblServerState.Location = new System.Drawing.Point(12, 9);
			this.lblServerState.Name = "lblServerState";
			this.lblServerState.Size = new System.Drawing.Size(80, 16);
			this.lblServerState.TabIndex = 3;
			this.lblServerState.Text = "Server state";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 3000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// btnGoOutFromQueue
			// 
			this.btnGoOutFromQueue.Location = new System.Drawing.Point(227, 107);
			this.btnGoOutFromQueue.Name = "btnGoOutFromQueue";
			this.btnGoOutFromQueue.Size = new System.Drawing.Size(117, 82);
			this.btnGoOutFromQueue.TabIndex = 4;
			this.btnGoOutFromQueue.Text = "Покинуть очередь";
			this.btnGoOutFromQueue.UseVisualStyleBackColor = true;
			this.btnGoOutFromQueue.Click += new System.EventHandler(this.btnGoOutFromQueue_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(374, 256);
			this.Controls.Add(this.lblServerState);
			this.Controls.Add(this.groupBox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Rdp queue client";
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox lbQueue;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnEnqueue;
		private System.Windows.Forms.Label lblServerState;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button btnGoOutFromQueue;
	}
}

