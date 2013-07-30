using System.Collections.Generic;
using System.Runtime.Serialization;

namespace rdp_queue_service
{
	/// <summary>
	/// Rdp state.
	/// </summary>
	[DataContract]
	public class RdpState
	{
		/// <summary>
		/// Get/Set the person is occupying rdp now.
		/// </summary>
		[DataMember]
		public string CurrentLocker { get; set; }

		/// <summary>
		/// Get/Set the waiting queue.
		/// </summary>
		[DataMember]
		public Queue<string> Queue { get; set; }
		
		/// <summary>
		/// Get/Set state of rdp.
		/// </summary>
		[DataMember]
		public bool Free { get; set; }
	}
}
