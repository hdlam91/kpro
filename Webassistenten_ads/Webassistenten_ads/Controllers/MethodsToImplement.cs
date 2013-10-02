using System;

namespace Webassistenten_ads
{
	public abstract class MethodsToImplement
	{
		public MethodsToImplement ()
		{
		}

		public abstract void CancelOrder()
		{
			RollBackQuery ();
			ResetFields();
		}

		public abstract void ResetFields();

		public abstract void RollBackQuery();

		public abstract void StoreQuery();

		public abstract void ExecuteQuery();
	}
}

