using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfull_service
{
	public class PlacementKind: IdentifiedNamedObject
	{
		public PlacementKind(int id, string caption)
			: base(id, caption)
		{ }

		protected override string ObjectXmlName
		{
			get { return "placementkind"; }
		}

		public const string CollectionName = "placementkinds";
	}
}