using System;
using System.Linq;
using System.ServiceModel;

namespace rdp_queue_srv
{
	internal class Program
	{
		private static void Main()
		{
			using (var host = new ServiceHost(typeof (rdp_queue_service.RdpQueueService)))
			{
				host.Open();

				Console.WriteLine("The service is ready at {0}", host.BaseAddresses.First());
				Console.WriteLine("Press <Enter> to stop the service.");
				Console.ReadLine();
				
				host.Close();
			}
		}
	}
}
