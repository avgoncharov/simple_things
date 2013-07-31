using System;
using System.Drawing;
using System.ServiceModel;
using System.Windows.Forms;
using rdp_srv.rdp_queue_service;

namespace rdp_srv
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			ChackState();
		}

		private void ChackState()
		{
			var srvc = ConnectToService();

			try
			{
				var result = srvc.GetRdpState();

				SetState(result.Free);
			}
			catch
			{
			}
			finally
			{
				CloseConnection(srvc);
			}
		}

		private void SetState(bool free)
		{
			btnFree.Enabled = !free;
			btnFree.BackColor = free ? Color.LightGray : Color.LightGreen;
			btnLock.Enabled = free;
			btnLock.BackColor = free ? Color.DarkRed : Color.LightGray;
		}

		private void btnLock_Click(object sender, EventArgs e)
		{
			var srvc = ConnectToService();

			try
			{
				srvc.LockRdp();

				SetState(false);
			}
			catch
			{
			}
			finally
			{
				CloseConnection(srvc);
			}
		}

		private void btnFree_Click(object sender, EventArgs e)
		{
			var srvc = ConnectToService();
			try
			{
				srvc.FreeRdp();

				SetState(true);
			}
			catch
			{
			}
			finally
			{
				CloseConnection(srvc);
			}
		}


		private static RdpQueueServiceClient ConnectToService()
		{
			var srvc = new RdpQueueServiceClient();

			if (srvc.ChannelFactory.Credentials != null)
			{
				srvc.ChannelFactory.Credentials.Windows.ClientCredential.UserName = "user";
				srvc.ChannelFactory.Credentials.Windows.ClientCredential.Password = "password";
				srvc.ChannelFactory.Credentials.Windows.ClientCredential.Domain = "localhost";
			}

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
