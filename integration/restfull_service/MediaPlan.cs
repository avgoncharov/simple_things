using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfull_service
{
	public class MediaPlan : SerivceObject
	{
		public enum MediaType
		{
			Context = 1,
			Media = 2,
		}

		public MediaPlan(
			MediaType mType,
			int extNum,
			string mpSvnUrl,
			string targeting,
			PlacementKind pk,
			double clientDiscount,
			int clientId,
			Client client,
			double priceCost,
			double discountCost,
			int clickPrediction,
			int cpcPrediction,
			double clientBonus,
			double agentComis,
			double nds,
			DateTime beginDate,
			DateTime endDate)
		{ }

		public MediaType MType { get; private set; }
		public int ExtNum { get; private set; }
		public string MpSvnUrl { get; private set; }
		public string Targeting { get; private set; }
		public PlacementKind Pk { get; private set; }
		public double ClientDiscount { get; private set; }
		public int ClientId { get; private set; }
		public Client Client { get; private set; }
		public double PriceCost { get; private set; }
		public double DiscountCost { get; private set; }
		public int ClickPrediction { get; private set; }
		public int CpcPrediction { get; private set; }
		public double ClientBonus { get; private set; }
		public double AgentComis { get; private set; }
		public double Nds { get; private set; }
		public DateTime BeginDate { get; private set; }
		public DateTime EndDate { get; private set; }

		protected override string to_xml()
		{
			return String.Format(
				"<mptype>{0}</mptype><extnum>{1}</extnum><mpsvnurl><2></mpsvnurl><targeting>{3}</targeting>{4}<clientdiscount>{5}</clientdiscount><clientid>{6}</clientid>{7}<pricecost>{8}</pricecost><discountcost>{9}</discountcost><clickprediction>{10}</clickprediction><cpcprediction>{11}</cpcprediction><clientbonus>{12}</clientbonus><agentcomis>{13}</agentcomis><nds>{14}</nds><begindate>{15:yyyy-MM-ddTHH:mm:ss}</begindate><enddate>{16:yyyy-MM-ddTHH:mm:ss}</enddate>",
				Convert.ToInt32(MType),
				ExtNum,
				MpSvnUrl,
				Targeting,
				Pk.ToXml(),
				ClientDiscount,
				ClientId,
				Client.ToXml(),
				PriceCost,
				DiscountCost,
				ClickPrediction,
				CpcPrediction,
				ClientBonus,
				AgentComis,
				Nds,
				BeginDate,
				EndDate);
		}

		protected override string ObjectXmlName
		{
			get { return "mplan"; }
		}



		public const string CollectionName = "clients";
	}
}