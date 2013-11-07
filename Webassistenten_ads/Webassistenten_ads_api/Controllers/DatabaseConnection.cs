using System;
using System.Collections.Generic;
using System.Linq;

namespace Webassistenten_ads_api
{
	public static class DatabaseConnection
	{
		
		/// <summary>
		/// Gets the available products for the given Partner ID
		/// </summary>
		/// <returns>The products.</returns>
		/// <param name="partnerId">Partner identifier.</param>
        public static IEnumerable<Produkt> GetProducts(byte partnerId)
        {
                BoligEntities1 db = new BoligEntities1();

                var result = from partnerProd in db.PartnerHarProdukts
                             where partnerProd.PartnerID == partnerId
                             select partnerProd.Produkt;

                return result;
        }

		/// <summary>
		/// Gets the available product modules for the given product.
		/// </summary>
		/// <returns>The product modules.</returns>
		/// <param name="prodId">Product identifier.</param>
        public static IEnumerable<Modul> GetProductModules(byte prodId)
        {
            BoligEntities1 db = new BoligEntities1();
            var result = from prodmodul in db.ProduktHarModuls
                         where prodmodul.ProduktID == prodId
                         select prodmodul.Modul;


            return result;
        }

		/// <summary>
		/// Gets the next five publishable dates for the given product id.
		/// </summary>
		/// <returns>The next five publishables.</returns>
		/// <param name="prodId">Product identifier.</param>
        public static IEnumerable<ProduktUtgivelse> GetNextFivePublishables(byte prodId)
        {
            BoligEntities1 db = new BoligEntities1();

            var result = (from prodUtgivelse in db.ProduktUtgivelses
                          where prodUtgivelse.ProduktID == prodId && prodUtgivelse.BookingFristSlutt > 0 && prodUtgivelse.DatoUtgivelse > System.DateTime.Today
                          select prodUtgivelse);

            result.OrderBy<ProduktUtgivelse, DateTime>(utgivelse => utgivelse.DatoUtgivelse);
            result = result.Take(5);

            return result;
        }
	}
}

