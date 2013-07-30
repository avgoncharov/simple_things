using System;
using System.Configuration;
using System.Drawing;
using System.Windows.Forms;
using rdp_queue_client.Properties;
using rdp_queue_client.rdp_queue_service;

namespace rdp_queue_client
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			UpdateData();
		}

		private void UpdateData()
		{
			RdpState state;

			try
			{
				using (var srvc = new RdpQueueServiceClient())
				{
					state = srvc.GetRdpState();
				}
			}
			catch
			{
				lblServerState.Text = Resources.NoConnection;
				return;
			}
			

			FormState(state);

			lbQueue.Items.Clear();

			var go = state.Free && state.Queue.Count > 0 && state.Queue.Peek() == ConfigurationManager.AppSettings["me"];

			while (state.Queue.Count > 0)
			{
				lbQueue.Items.Add(state.Queue.Dequeue());
			}


			if (go)
			{
				timer1.Enabled = false;
				var result = MessageBox.Show(Resources.ServerIsFree, Resources.GoToSrv);
				
				if(result == DialogResult.OK || result != DialogResult.OK)
					timer1.Enabled = true;

			}

		}

		private void FormState(RdpState state)
		{
			if (state.Free)
			{
				lblServerState.ForeColor = Color.DarkGreen;
				lblServerState.Text = Resources.Free;
			}
			else
			{
				lblServerState.ForeColor = Color.DarkRed;
				lblServerState.Text = Resources.Locked + state.CurrentLocker;
			}

		}

		private void btnEnqueue_Click(object sender, EventArgs e)
		{
			using (var srvc = new RdpQueueServiceClient())
			{
				srvc.Enqueue(ConfigurationManager.AppSettings["me"]);
			}

			UpdateData();
		}

		private void btnGoOutFromQueue_Click(object sender, EventArgs e)
		{
			using (var srvc = new RdpQueueServiceClient())
			{
				srvc.DeleteFromQueue(ConfigurationManager.AppSettings["me"]);
			}

			UpdateData();
		}

		
	}
}
