using System.ServiceModel;

namespace rdp_queue_service
{
	/// <summary>
	/// Interface of queue service.
	/// </summary>
	[ServiceContract]
	public interface IRdpQueueService
	{
		/// <summary>
		/// Returns queue-state.
		/// </summary>
		/// <returns>Queue-state.</returns>
		[OperationContract]
		RdpState GetRdpState();

		/// <summary>
		/// Insert email in queue.
		/// </summary>
		/// <param name="email">Enqueued email.</param>
		[OperationContract]
		void Enqueue(string email);

		/// <summary>
		/// Lock rdp.
		/// </summary>
		[OperationContract]
		void LockRdp();

		/// <summary>
		/// Lock rdp.
		/// </summary>
		[OperationContract]
		void FreeRdp();

		/// <summary>
		/// Delete email from queue.
		/// </summary>
		/// <param name="email">Deleted email.</param>
		[OperationContract]
		void DeleteFromQueue(string email);
	}
}
