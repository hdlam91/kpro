using System;

namespace Webassistenten_ads_api
{
	public class PropertyType
	{

		/// <summary>
		/// Initializes a new instance of the <see cref="Webassistenten_ads.PropertyType"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public PropertyType (int id)
		{
			Id = id;
		}

		private int Id { get; set; }
	}
}

