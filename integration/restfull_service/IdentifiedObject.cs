using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfull_service
{
	public abstract class IdentifiedObject : SerivceObject
	{
		protected IdentifiedObject(int id)
		{
			Id = id;
		}

		public int Id { get; private set; }

		protected override string to_xml()
		{
			return String.Format("<id>{0}</id>", Id);
		}
	}
}