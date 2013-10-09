using System;

namespace Webassistenten_ads_api
{
	public abstract class MethodsToImplement
	{
		public MethodsToImplement ()
		{
		}

		/// <summary>
		/// Will cancel the current order, and rollback any changes made to the database
		/// </summary>
        public abstract void CancelOrder();

		public abstract void ResetFields();

		public abstract void RollBackQuery();

		public abstract void StoreQuery();

		public abstract void ExecuteQuery();
	}
}

