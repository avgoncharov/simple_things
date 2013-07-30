﻿using System;
using System.Windows.Forms;

namespace rdp_srv
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			SetState(true);
		}

		private void SetState(bool free)
		{
			btnFree.Enabled = !free;
			btnLock.Enabled = free;
		}

		private void btnLock_Click(object sender, EventArgs e)
		{
			try
			{
				using (var srvc = new rdp_queue_service.RdpQueueServiceClient())
				{
					srvc.LockRdp();
				}
				SetState(false);
			}
			catch
			{
			}
		}

		private void btnFree_Click(object sender, EventArgs e)
		{
			try
			{
				using (var srvc = new rdp_queue_service.RdpQueueServiceClient())
				{
					srvc.FreeRdp();
				}
				SetState(true);
			}catch
			{
			}
		}
	}
}