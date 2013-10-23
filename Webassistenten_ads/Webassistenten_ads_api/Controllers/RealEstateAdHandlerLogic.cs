using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webassistenten_ads_api.Models;

namespace Webassistenten_ads_api.Controllers
{
    public class RealEstateAdHandlerLogic : AdHandlerLogic
    {

		// NOT VALID ANYMORE
		private bool RequiredInfoSet(RealEstateAdInfo info)
		{
			if (info.RealtorId == -1 || info.ProductId == -1 || info.Type == -1 || info.Price == -1 || ValidZipCode(info.ZipCode)) {	
				return false;
			} else if (info.ResponsibleRealtor == null || info.Area == null ||
				info.Location == null || info.Headline == null || info.Address == null ||
				info.ZipArea == null || info.BookingDate == null) {	// TODO: Convert to reflection if possible.
				return false;
			} else {
				return true;
			}
		}

		private bool ValidZipCode(int zip)
		{
			if (zip > 999 && zip < 10000) {
				return true;
			} else {
				return false;
			}
		}

		public bool RequiredProspektInfoSet(ProspektHarBestilling prospektBest, Prospekt prospekt)
		{
			// TODO: Find corresponding db-tables/model properties for "Sted" and "Stedsnavn" which are required according to spec.
			if (prospekt.Pris != null || prospekt.Postnr != null || ValidZipCode(Int32.Parse(prospekt.Postnr)) || prospekt.Megler != null || prospekt.Omraade != null || prospekt.BoligtypeID != null || prospekt.Pris != null 
			    //TODO: Find "sted" and "stedsnavn" and check for null
			    )  {	// Checking required fields in Prospekt object	
				return false;
			} else if (prospektBest.ProspektID != prospekt.ProspektID ||	// IDs need to match, or something is terribly wrong
			           prospektBest.ProduktID != 0 || prospektBest.DatoBest != null) {	// Checking required fields in ProspektHarBestilling object
				return false;
			} else {
				return true;
			}
		}

    }
}