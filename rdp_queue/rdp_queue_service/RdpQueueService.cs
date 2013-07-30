using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace rdp_queue_service
{
	// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
	public class RdpQueueService : IRdpQueueService
	{
		public RdpState GetRdpState()
		{
			var current = GetCurrentLocker();

			return new RdpState
			       	{
			       		CurrentLocker = current,
			       		Queue = RestoreQueueFromFile(),
			       		Free = String.IsNullOrEmpty(current),
			       	};
		}

		private static string GetCurrentLocker()
		{
			return File.ReadAllText("current.txt");
		}

		private static void SetCurrentLocker(string locker)
		{
			File.WriteAllText("current.txt", locker);
		}

		private static Queue<string> RestoreQueueFromFile()
		{
			var lines = File.ReadLines("q_state.txt");

			var result = new Queue<string>();

			foreach (var line in lines)
			{
				if (!String.IsNullOrEmpty(line))
					result.Enqueue(line);
			}

			return result;
		}

		public void Enqueue(string email)
		{
			var queue = RestoreQueueFromFile();
			queue.Enqueue(email);
			
			SaveQueueToFile(queue);

		}

		private static void SaveQueueToFile(Queue<string> queue)
		{
			var strB = new StringBuilder();

			while (queue.Count > 0)
				strB.AppendLine(queue.Dequeue());

			File.WriteAllText("q_state.txt", strB.ToString());
		}

		public void Dequeue()
		{
			var queue = RestoreQueueFromFile();
			var current = queue.Dequeue();

			SetCurrentLocker(current);

			SaveQueueToFile(queue);
		}

		public void DeleteFromQueue(string email)
		{
			var queue = RestoreQueueFromFile();

			var newQueue = new Queue<string>();
			var deletedFirst = false;
			
			while(queue.Count >0)
			{
				var i = queue.Dequeue();
				
				if(i == email && !deletedFirst)
				{
					deletedFirst = true;
				}
				else
				{
					newQueue.Enqueue(i);
				}
			}

			SaveQueueToFile(newQueue);
		}


		public void LockRdp()
		{
			Dequeue();
		}

		public void FreeRdp()
		{
			SetCurrentLocker(String.Empty);
		}
	}
}
