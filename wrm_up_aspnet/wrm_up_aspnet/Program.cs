using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading;

namespace wrm_up_aspnet
{
	class Program
	{
		static void Main()
		{
			read_ini();

			ThreadPool.QueueUserWorkItem(work, null);

			while(Console.ReadLine()!= "q")
			{
			}
		}


		private static void work(object state)
		{
			var buf = Console.ForegroundColor;
			var timeout = Convert.ToInt32(_dictionary["timeout"])*1000;

			while (true)
			{
				Console.WriteLine("[utc: {0:yyyy-MM-dd T HH:mm:ss}] request was sent.", DateTime.UtcNow);

				try
				{
					Console.ForegroundColor = ConsoleColor.Green;

					Console.WriteLine("[utc: {0:yyyy-MM-dd T HH:mm:ss}] response {1} was received.", DateTime.UtcNow, get_data(_dictionary["uri"]));
					
					Console.ForegroundColor = buf;
				} 
				catch(Exception ex)
				{
					Console.ForegroundColor = ConsoleColor.Red;

					Console.WriteLine("[utc: {0:yyyy-MM-dd T HH:mm:ss}] response was faild.", DateTime.UtcNow);
					Console.WriteLine("\t\terr msg: {0}", ex.Message);
				}

				Console.WriteLine("Next iteration will be started at utc {0:yyyy-MM-dd T HH:mm:ss}.", DateTime.UtcNow.AddMilliseconds(timeout));
				Console.WriteLine("To quit press key 'q'");

				Thread.Sleep(timeout);
			}
		}

		private static string get_data(string uri)
		{
			var request = WebRequest.Create(uri);
		
			request.Credentials = CredentialCache.DefaultCredentials;
		
			var response = request.GetResponse();

			var result = ((HttpWebResponse) response).StatusDescription;
			
			using(var dataStream = response.GetResponseStream())
			{
				if (dataStream == null)
					return "'response stream is null'";

				using (var reader = new StreamReader(dataStream))
				{
					var responseFromServer = reader.ReadToEnd();
				}
			}

			return result;
		}

		private static void read_ini()
		{
			var text = File.ReadAllText("wrm_up_aspnet.ini").Trim();
			var lines = text.Split(new []{'\n'}, StringSplitOptions.RemoveEmptyEntries);

			foreach (var line in lines)
			{
				var pair = line.Split('-');
				_dictionary.Add(pair[0].Trim(), pair[1].Trim());
			}
		}

		private static readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();
	}
}
