using System;

namespace Webassistenten_ads_api
{
	/// <summary>
	/// Authentication.
	/// Implement this interface for any self-made authentication in order to fit in with existing API code.
	/// Only for further development of API.
	/// </summary>
	public interface Authentication
	{
		
		/// <summary>
		/// Method for authenticating via an email adress.
		/// </summary>
		/// <returns>Authentication.</returns>
		/// <param name="email">Email.</param>
		Authentication EmailAuthenticate(string email);

		/// <summary>
		/// Method for authenticating via User ID.
		/// </summary>
		/// <returns>Authentication.</returns>
		/// <param name="userId">User identifier.</param>
		Authentication IdAuthenticate(int userId);

	}
}

