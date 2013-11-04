using System;

namespace Webassistenten_ads_api
{
	public interface Authentication
	{
		

		Authentication EmailAuthenticate(string email);

		Authentication IdAuthenticate(int userId);

	}
}

