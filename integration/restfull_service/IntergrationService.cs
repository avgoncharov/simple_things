using System;
using System.Text;
using System.Web;

namespace restfull_service
{
	public class IntergrationService : IHttpHandler
	{
		/// <summary>
		/// You will need to configure this handler in the Web.config file of your 
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
			var cmd_name = ExtractMethodName(context.Request.Url).ToLower();

			switch (cmd_name)
			{
 				case "getclients":
					return_clients(context.Response);					
					break;

				case "getsites":
					//return_sites(context.Response);
					break;

				case "getsections":
					//return_sections(context.Response);
					break;

				case "getplacements":
					//return_placements(context.Response);
					break;

				case "getplacementkinds":
					//return_placement_kinds(context.Response);
					break;

				case "getmediaplans":
					//return_mediaplans(context.Response);
					break;

				case "getplacementsstatistic":
					//return_placements_statistic(context.Response);
					break;

				case "getkpis":
					//return_kpis(context.Response);
					break;

				case "getinternalvoting":
					//return_internal_voting(context.Response);
					break;

				case "getquestions":
					//return_questions(context.Response);
					break;

				case "getexternalvoting":
					//return_external_voting(context.Response);
					break;
					
				default:
					context.Response.Write("undefiend method.");
					break;
			}
			
		}

		private void return_clients(HttpResponse response)
		{			
			var result = new StringBuilder("<root>");
			result.AppendLine();
			result.AppendFormat("<{0}>", Client.CollectionName);
			result.AppendLine();

			var x = new[] { new Client(1, "C1"), new Client(2, "C2"), new Client(3, "C3") };
			foreach (var itr in x)		
				result.AppendLine(itr.ToXml());

			result.AppendFormat("</{0}>", Client.CollectionName);
			result.AppendLine();
			result.AppendLine("</root>");

			response.Write(result.ToString());
		}

		#endregion

		#region private
		private static string ExtractMethodName(Uri uri)
		{
			var ss = uri.Segments;

			if (ss.Length < 3)
				return String.Empty;

			return ss[2];
		}

		#endregion
	}
}
