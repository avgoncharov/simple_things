using System;

namespace restfull_service
{
	/// <summary>
	/// Клиент.
	/// </summary>
	public class Client: IdentifiedNamedObject
	{
		public Client(int id, string caption)
			: base(id, caption)
		{ }

		protected override string ObjectXmlName
		{
			get { return "client"; }
		}

		public const string CollectionName = "clients";
	}
}