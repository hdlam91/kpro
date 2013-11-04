using System;

namespace Webassistenten_ads_api
{
	public interface Authentication
	{
		int authId;
		bool valid;

		Authentication EmailAuthenticate(string email);

		Authentication IdAuthenticate(int userId);

	}
}

