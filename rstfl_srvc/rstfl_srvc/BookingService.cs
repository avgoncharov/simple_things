using System;
using System.Linq;
using System.Text;
using System.Web;

namespace rstfl_srvc
{
	public class BookingService : IHttpHandler
	{
		/// <summary>
		/// You will need to configure this handler in the web.config file of your 
		/// web and register it with IIS before being able to use it. For more information
		/// see the following link: http://go.microsoft.com/?linkid=8101007
		/// </summary>
		#region IHttpHandler Members

		public bool IsReusable
		{
			// Return false in case your Managed Handler cannot be reused for another request.
			// Usually this would be false in case you have some state information preserved per request.
			get { return true; }
		}

		public void ProcessRequest(HttpContext context)
		{
			var method = ExctractMethodName(context.Request.Url);

			var users = new[]
			            	{
			            		new User("1", "Goncharov Andrey", new DateTime(1983, 6, 8)),
			            		new User("2", "Fedotov Sergey", new DateTime(1978, 9, 12)),
			            		new User("3", "Malishev Grigory", new DateTime(1982, 10, 21)),
			            	};

			switch (method)
			{
				case "hello":
					context.Response.Write("hello");
					break;

				case "returnname":
					var name = context.Request.Params["name"];
					context.Response.Write(String.Format("<user><name>{0}</name></user>", name));
					break;

				case "getuserbyid":
					var id = context.Request.Params["id"];
					var usr = users.FirstOrDefault(i => i.Id == id);

					if (usr == null)
					{
						context.Response.Write(String.Format("User wasn't found by id: {0},", id));
						return;
					}

					context.Response.Write(usr.ToXml());

					break;

				case "getusers":
					var strB = new StringBuilder();

					strB.AppendLine("<users>");

					foreach (var user in users)
						strB.AppendLine(user.ToXml());


					strB.AppendLine("</users>");

					context.Response.Write(strB.ToString());
					break;
			}
		}

		private static string ExctractMethodName(Uri uri)
		{
			var segments = uri.Segments;

			return segments.Length < 3 ? String.Empty : segments[2].ToLower();
		}

		#endregion

		#region user
		private class User
		{
			public User(string id, string fullName, DateTime date)
			{
				Id = id;
				FullName = fullName;
				DateOfBirthday = date;
			}

			public string Id { get; private set; }
			public string FullName { get; private set; }
			public DateTime DateOfBirthday { get; private set; }

			public string ToXml()
			{
				return String.Format(
					"<user><id>{0}</id><name>{1}</name><date>{2:yyyy-MM-dd}</date></user>",
					Id,
					FullName,
					DateOfBirthday);
			}
		}
		#endregion
	}
}
