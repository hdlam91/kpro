using System;
using System.Collections.Generic;
using System.Linq;

namespace Webassistenten_ads_api
{
	public abstract class MethodsToImplement
	{
		public MethodsToImplement ()
		{
		}

		/// <summary>
		/// Will cancel the current order, and rollback any changes made to the database
		/// </summary>
        public abstract void CancelOrder();

		public abstract void ResetFields();

		public abstract void RollBackQuery();

		public abstract void StoreQuery();

        //Template for databaseTest
        public void InitDB()
        {
            BoligEntities1 db = new BoligEntities1();

            IEnumerable<Prospekt> prospects = new List<Prospekt>();
            {
                //TODO: Define Add for Prospekt?
                new Prospekt() { Adresse = "TestAdresse", Annonsetekst = "TestText", Oppdragsnr = "HvorforString?!" };
            };

            db.SaveChanges();
        }

        public IEnumerable<Produkt> GetProducts(byte partnerId)
        {
                BoligEntities1 db = new BoligEntities1();

                var result = from partnerProd in db.PartnerHarProdukts
                             where partnerProd.PartnerID == partnerId
                             select partnerProd.Produkt;

                return result;
        }

        public IEnumerable<Modul> GetProductModules(byte prodId)
        {
            BoligEntities1 db = new BoligEntities1();

            var result = from prodmodul in db.ProduktHarModuls
                         where prodmodul.ProduktID == prodId
                         select prodmodul.Modul;


            return result;
        }

		public IEnumerable<ProduktUtgivelse> GetNextFivePublishables(byte prodId)
		{
			BoligEntities1 db = new BoligEntities1 ();

			var result = from prodUtgivelse in db.ProduktUtgivelses
						 where prodUtgivelse.ProduktID == prodId
						 select prodUtgivelse;

			return result;
		}
	}
}

