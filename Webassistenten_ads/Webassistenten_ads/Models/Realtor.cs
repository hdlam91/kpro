using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webassistenten_ads.Models
{
    public class Realtor
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Webassistenten_ads.Models.Realtor"/> class.
		/// </summary>
		/// <param name="id">Identifier.</param>
		public Realtor(int id)
		{
			Id = id;
		}

		private int Id { get; set; }
    }
}