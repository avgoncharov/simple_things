using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfull_service
{
	public abstract class IdentifiedNamedObject: IdentifiedObject
	{
		protected IdentifiedNamedObject(int id, string caption)
			: base(id)
		{
			Caption = caption;
		}

		public string Caption { get; private set; }

		protected override string to_xml()
		{
			return base.to_xml() + String.Format("<caption>{0}</caption>", Caption);
		}
	}
}