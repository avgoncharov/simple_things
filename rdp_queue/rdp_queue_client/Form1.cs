using System;
using System.Configuration;
using System.Drawing;
using System.ServiceModel;
using System.Threading;
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

			ThreadPool.QueueUserWorkItem(Work);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			//UpdateData();
		}

		private void UpdateData()
		{
			RdpState state;
			
			var srvc = ConnectToService();
			
			try
			{
				state = srvc.GetRdpState();
			}
			catch
			{
				lblServerState.Text = Resources.NoConnection;
				return;
			}
			finally
			{
				CloseConnection(srvc);
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

				if (result == DialogResult.OK || result != DialogResult.OK)
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
			var srvc = ConnectToService();
		
			try
			{
				srvc.Enqueue(ConfigurationManager.AppSettings["me"]);
			}
			finally
			{
				CloseConnection(srvc);
			}

			//UpdateData();
		}

		private void btnGoOutFromQueue_Click(object sender, EventArgs e)
		{
			var srvc = ConnectToService();

			try
			{
				srvc.DeleteFromQueue(ConfigurationManager.AppSettings["me"]);
			}
			finally
			{
				CloseConnection(srvc);
			}

		//	UpdateData();
		}

		private delegate void InvokeDelegate();
		private void UpdateDataThread(object state)
		{
			if(lblServerState.InvokeRequired)
			{
				
				var asr = lblServerState.BeginInvoke(new InvokeDelegate(UpdateData));

				while (!asr.IsCompleted)
				{
					Thread.Sleep(1000);
				}
			}
			else
			{
				UpdateData();
			}
		}

		private void Work(object state)
		{
			while (true)
			{
				try
				{
					UpdateDataThread(true);
				}catch
				{
				}

				Thread.Sleep(3000);
			}
		}

		private static RdpQueueServiceClient ConnectToService()
		{
			var srvc = new RdpQueueServiceClient();
			
			if (String.IsNullOrEmpty(ConfigurationManager.AppSettings["aut"]) || srvc.ChannelFactory.Credentials == null)
				return srvc;
			
			srvc.ChannelFactory.Credentials.Windows.ClientCredential.UserName = ConfigurationManager.AppSettings["userId"];
			srvc.ChannelFactory.Credentials.Windows.ClientCredential.Password = ConfigurationManager.AppSettings["password"];
			srvc.ChannelFactory.Credentials.Windows.ClientCredential.Domain = ConfigurationManager.AppSettings["dns"];

			return srvc;
		}

		private static void CloseConnection(RdpQueueServiceClient srvc)
		{
			if (srvc == null)
				return;

			if (srvc.State == CommunicationState.Faulted)
			{
				srvc.Abort();
			}
			else
			{
				srvc.Close();
			}
		}
	}
}
