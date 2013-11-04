using System;
using System.Collections.Generic;
using System.Linq;

namespace Webassistenten_ads_api
{
	public class WebAssistentAuth : Authentication
	{
		public int authId;
		public bool valid;

		public WebAssistentAuth ()
		{
			valid = false;
			authId = 0;
		}

		public Authentication EmailAuthenticate(string email) 
		{
			BoligEntities1 db = new BoligEntities1 ();

			Bruker bruker = from b in db.Brukers
							where b.Epost == email
							select b.First();

			if (bruker != null)
			{
				authId = bruker.PartnerID;
				valid = true;
				return this;
			}
			else
			{
				return this;
			}
		}
		
		public Authentication IdAuthenticate(int userId)
		{
			BoligEntities1 db = new BoligEntities1 ();

			Bruker bruker = from b in db.Brukers
							where b.BrukerID == userId
							select b.First();

			if (bruker != null)
			{
				authId = bruker.PartnerID;
				valid = true;
				return this;
			}
			else
			{
				return this;
			}
		}

	}
}

