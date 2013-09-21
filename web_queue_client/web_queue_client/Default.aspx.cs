using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Web;
using System.IO;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using web_queue_client.queue_srv;

namespace web_queue_client
{
	public partial class WebForm1 : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
				Update(Session["index"] == null ? 0 : Convert.ToInt32(Session["index"]));
		}

		protected void Push(Object sender, EventArgs eventArgs)
		{
			var index = users.SelectedIndex;
			var user = users.Items[index].Text;

			var srvc = ConnectToService();

			try
			{
				srvc.Enqueue(user);
			}
			catch (Exception ex)
			{
				//_lg.WriteErr("btnEnqueue_Click", ex);
			}
			finally
			{
				CloseConnection(srvc);
			}

			Update(index);
			Session["index"] = index;
		}

		protected void UserChange(Object sender, EventArgs eventArgs)
		{
			var index = users.SelectedIndex;
			Update(index);
			Session["index"] = index;
		}

		protected void Pop(Object sender, EventArgs eventArgs)
		{
			var index = users.SelectedIndex;
			var user = users.Items[index].Text;

			var srvc = ConnectToService();

			try
			{
				srvc.DeleteFromQueue(user);
			}
			catch (Exception ex)
			{
				//_lg.WriteErr("btnGoOutFromQueue_Click", ex);
			}
			finally
			{
				CloseConnection(srvc);
			}

			Update(index);
			Session["index"] = index;
		}

		private void Update(int selectedIndex)
		{
			users.SelectedIndex = selectedIndex;

			RdpState state;

			var srvc = ConnectToService();

			try
			{
				state = srvc.GetRdpState();
			}
			catch (Exception ex)
			{
				//_lg.WriteErr("UpdateData", ex);
				//lblServerState.Text = Resources.NoConnection;
				return;
			}
			finally
			{
				CloseConnection(srvc);
			}


			FormState(state);

			if (state.Queue.Count == 0)
			{
				var row = new HtmlTableRow();
				queue.Rows.Add(row);

				var c1 = new HtmlTableCell { InnerText = "Очередь пуста." };
				row.Cells.Add(c1);
				return;

			}

			for (int i = 0; state.Queue.Count > 0; ++i)
			{
				var row = new HtmlTableRow();
				queue.Rows.Add(row);

				var c1 = new HtmlTableCell { InnerText = (1 + i).ToString() };
				row.Cells.Add(c1);

				var c2 = new HtmlTableCell { InnerText = state.Queue.Dequeue() };
				row.Cells.Add(c2);
			}
		}

		private void FormState(RdpState state)
		{
			if(state.Free)
			{
				locked.InnerText = String.Empty;

				free.InnerText = "Свободен.";
			}
			else
			{
				locked.InnerText = state.CurrentLocker + " на сервере.";
				free.InnerText = String.Empty;
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