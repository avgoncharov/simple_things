using System;
using System.IO;
using System.Net;

namespace restfull_client
{
	class Program
	{
		static void Main(string[] args)
		{
			var request = WebRequest.Create("http://localhost/rstfl/getclients") as HttpWebRequest;//getuserbyid?id=3
			
			if (request == null)
			{
				Console.WriteLine("Cann't connect.");
				Console.ReadKey();
				return;
			}

			request.Method = "POST";
			request.ContentLength = 0;
			request.ContentType = "text/text";
			
			try
			{
				WebResponse webResponse = request.GetResponse();
				using (Stream webStream = webResponse.GetResponseStream())
				{
					if (webStream != null)
					{
						using (StreamReader responseReader = new StreamReader(webStream))
						{
							string response = responseReader.ReadToEnd();
							Console.Out.WriteLine(response);
						}
					}
				}
			}
			catch (Exception e)
			{
				Console.Out.WriteLine("-----------------");
				Console.Out.WriteLine(e.Message);
			}

			Console.ReadKey();
		}
	}
}
