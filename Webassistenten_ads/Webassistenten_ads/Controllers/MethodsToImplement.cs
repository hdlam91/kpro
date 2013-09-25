using System;

namespace Webassistenten_ads
{
	public class MethodsToImplement
	{
		public MethodsToImplement ()
		{
		}

		public abstract void CancelOrder()
		{
			RollBackQuery ();
		}

		public abstract void RollBackQuery();

		public abstract void StoreQuery();
	}
}

