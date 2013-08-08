using System;
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

			switch (method)
			{
				case "hello":
					context.Response.Write("hello");
					break;

				case "returnname":
					var name = context.Request.Params["name"];
					context.Response.Write(name);
					break;
			}
		}

		private static string ExctractMethodName(Uri uri)
		{
			var segments = uri.Segments;
			
			return segments.Length < 2 ? String.Empty : segments[1].ToLower();
		}

		#endregion
	}
}
