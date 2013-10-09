using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webassistenten_ads_api.Models;

namespace Webassistenten_ads_api.Controllers
{
    public class RealEstateAdHandlerLogic : AdHandlerLogic
    {

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

    }
}