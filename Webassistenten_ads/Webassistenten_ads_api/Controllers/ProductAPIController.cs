using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webassistenten_ads_api.Controllers
{
    public class ProductAPIController : ApiController
    {

        //FERDIG?
        [HttpGet]
        [ActionName("Products")]
        public HttpResponseMessage Products(byte id)
        {
            //id = partnerid, need some kind of auth here.
            //System.Diagnostics.Debug.WriteLine("products");
            IEnumerable<Produkt> prods = DatabaseConnection.GetProducts(id);
            List<int> produktID = new List<int>();
            List<string> produktNavn = new List<string>();
            foreach (Produkt prodit in prods)
            {
                produktID.Add(prodit.ProduktID);
                produktNavn.Add(prodit.Produktnavn);

            }
            return Request
        .CreateResponse(HttpStatusCode.OK, new {produktID, produktNavn });
        }

    }
}
