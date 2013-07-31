using System;
using System.Collections.Generic;
using System.IO;
using System.ServiceModel;
using System.Text;
using System.Threading;

namespace rdp_queue_service
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
	public class RdpQueueService : IRdpQueueService
	{
		#region IRdpQueueService
		public RdpState GetRdpState()
		{
			_lockObj.EnterReadLock();
			try
			{
				var current = GetCurrentLocker();

				return new RdpState
					{
						CurrentLocker = current,
						Queue = RestoreQueueFromFile(),
						Free = String.IsNullOrEmpty(current),
					};
			}
			catch (Exception ex)
			{
				File.WriteAllText("log.log", ex.Message);
				throw;
			}
			finally
			{
				_lockObj.ExitReadLock();
			}
		}

		public void Enqueue(string email)
		{
			_lockObj.EnterWriteLock();
			try
			{
				var queue = RestoreQueueFromFile();
				queue.Enqueue(email);

				SaveQueueToFile(queue);
			}
			finally
			{
				_lockObj.ExitWriteLock();
			}
		}

		public void DeleteFromQueue(string email)
		{
			_lockObj.EnterWriteLock();
			try
			{
				var queue = RestoreQueueFromFile();

				var newQueue = new Queue<string>();
				var deletedFirst = false;

				while (queue.Count > 0)
				{
					var i = queue.Dequeue();

					if (i == email && !deletedFirst)
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
			finally
			{
				_lockObj.ExitWriteLock();
			}
		}


		public void LockRdp()
		{
			_lockObj.EnterWriteLock();
			try
			{
				Dequeue();
			}
			finally
			{
				_lockObj.ExitWriteLock();
			}
		}

		public void FreeRdp()
		{
			_lockObj.EnterWriteLock();
			try
			{
				SetCurrentLocker(String.Empty);
			}
			finally
			{
				_lockObj.ExitWriteLock();
			}
		}
		#endregion

		#region Private
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

		private static void SaveQueueToFile(Queue<string> queue)
		{
			var strB = new StringBuilder();

			while (queue.Count > 0)
				strB.AppendLine(queue.Dequeue());

			File.WriteAllText("q_state.txt", strB.ToString());
		}

		private static void Dequeue()
		{
			var queue = RestoreQueueFromFile();
			var current = queue.Dequeue();

			SetCurrentLocker(current);

			SaveQueueToFile(queue);
		}
		#endregion

		private ReaderWriterLockSlim _lockObj = new ReaderWriterLockSlim();
	}
}
