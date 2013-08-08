using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace rstfl_client
{
	class Program
	{
		static void Main(string[] args)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost/rstfl/getusers");//getuserbyid?id=3
			request.Method = "POST";
			request.ContentLength = 0;
			request.ContentType = "text/text";
			//request.ContentType = "application/json";
			//request.ContentLength = DATA.Length;
			//using (Stream webStream = request.GetRequestStream())
			//using (StreamWriter requestWriter = new StreamWriter(webStream, System.Text.Encoding.ASCII))
			//{
			//        requestWriter.Write(DATA);
			//}

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
