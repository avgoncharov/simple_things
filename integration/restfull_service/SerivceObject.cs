using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace restfull_service
{
	public abstract class SerivceObject
	{
		public string ToXml()
		{
			return String.Format("<{0}>{1}</{0}>", ObjectXmlName, to_xml());
		}

		protected abstract string to_xml();
				
		protected abstract string ObjectXmlName { get;}		
	}
}