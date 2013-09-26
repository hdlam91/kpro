using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webassistenten_ads.Models;

namespace Webassistenten_ads.Controllers
{
    public class RealEstateAdHandlerLogic : AdHandlerLogic
    {

		private bool RequiredInfoSet(RealEstateAdInfo info)
		{
			if (info.RealtorId == -1 || info.RealtorId == -1 || info.ProductId == -1 || info.Type == -1 || Price == -1 || ValidZipCode(info.ZipCode)) {	
				return false;
			} else if (info.ResponsibleRealtor == NULL || info.Area == NULL ||
				info.Location == NULL || info.Headline == NULL || info.Adress == NULL ||
				info.ZipArea == NULL || info.BookingDate == NULL) {	// TODO: Convert to reflection if possible.
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