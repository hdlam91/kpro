using System;
using System.Collections.Generic;
using System.Linq;

namespace Webassistenten_ads_api
{
	/// <summary>
	/// Webassistenten authorization class.
	/// This class is intended as a simple placeholder for a more complex future authentication
	/// </summary>
	public class WebAssistentAuth : Authentication
	{
		public int AuthId { get; set; };
		public bool IsValid { get; set; };

		public WebAssistentAuth ()
		{
			IsValid = false;
			AuthId = 0;
		}

		/// <summary>
		/// Method for authenticating via an email adress.
		/// </summary>
		/// <returns>Authentication.</returns>
		/// <param name="email">Email.</param>
		public Authentication EmailAuthenticate(string email) 
		{
			BoligEntities1 db = new BoligEntities1 ();
            Bruker bruker = null;
            try
            {
                bruker = (from b in db.Brukers
                          where b.Epost == email
                          select b).First();
            }
            catch (Exception e)
            {
            }
			if (bruker != null)
			{
				AuthId = bruker.PartnerID;
				IsValid = true;
				return this;
			}
			else
			{
				return this;
			}
		}

		/// <summary>
		/// Method for authenticating via User ID.
		/// </summary>
		/// <returns>Authentication.</returns>
		/// <param name="userId">User identifier.</param>
		public Authentication IdAuthenticate(int userId)
		{
			BoligEntities1 db = new BoligEntities1 ();
            Bruker bruker = null;
            try
            {
			bruker = (from b in db.Brukers
							where b.BrukerID == userId
							select b).First();
            }
            catch (Exception e)
            {
            }
			if (bruker != null)
			{
				AuthId = bruker.PartnerID;
				IsValid = true;
				return this;
			}
			else
			{
				return this;
			}
		}

	}
}

