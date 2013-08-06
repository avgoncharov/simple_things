using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace lg_hk
{
	public class Logger
	{
		#region public
		/// <summary>
		/// Write error msg to log file.
		/// </summary>
		/// <param name="point">Point of sending.</param>
		/// <param name="msg">Error msg.</param>
		public void WriteErr(string point, string msg)
		{
			WriteToQueue(point, msg, "ERR");
		}

		/// <summary>
		/// Write error to log file by exception.
		/// </summary>
		/// <param name="point">Point of sending.</param>
		/// <param name="ex">Exception for writing.</param>
		public void WriteErr(string point, Exception ex)
		{
			var strB = new StringBuilder();

			WriteErr(strB, ex);

			WriteErr(point, strB.ToString());
		}

		private static void WriteErr(StringBuilder strB, Exception ex)
		{
			strB.AppendLine(ex.Message);
			strB.AppendLine("st_trace: " + ex.StackTrace);

			if (ex.InnerException != null)
				WriteErr(strB, ex.InnerException);
		}

		/// <summary>
		/// Write info to log file.
		/// </summary>
		/// <param name="point">Point of sending.</param>
		/// <param name="info">Info for writing.</param>
		public void WriteInfo(string point, string info)
		{
			WriteToQueue(point, info, "INFO");
		}

		public void Flush()
		{
			WriteMsgs(false);
		}

		#endregion

		#region private

		private void WriteToQueue(string point, string msg, string msg_type)
		{
			var str = String.Format("[UTC: {0:yyyy-MM-dd T HH:mm:ss}] p: {1}; t: {2}; msg: {3}", DateTime.UtcNow, point, msg_type, msg);

			_lock_obj.EnterWriteLock();
			try
			{
				_msg_queue.Enqueue(str);
			}
			finally
			{
				_lock_obj.ExitWriteLock();
			}

			WriteMsgs(true);
		}

		private void WriteMsgs(bool common)
		{
			_lock_obj.EnterWriteLock();
			
			try
			{
				if (common && _msg_queue.Count < 10)
					return;
				
				var msg = new StringBuilder();
				while (_msg_queue.Count > 0)
					msg.AppendLine(_msg_queue.Dequeue());

				if (File.Exists(LG_FILE_PATH))
				{
					if (File.ReadAllBytes(LG_FILE_PATH).Length > MAX_SIZE)
						File.Delete(LG_FILE_PATH);
				}

				File.AppendAllText(LG_FILE_PATH, msg.ToString());
			}
			catch
			{
			}
			finally
			{
				_lock_obj.ExitWriteLock();
			}
		}

		private readonly Queue<string> _msg_queue = new Queue<string>();
		private ReaderWriterLockSlim _lock_obj = new ReaderWriterLockSlim();
		private const string LG_FILE_PATH = "lg_hk.log";
		private const int MAX_SIZE = 2 * 1024 * 1024;

		#endregion
	}
}
