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

        [HttpGet]
        [ActionName("Products")]
		/// <summary>
		/// This method will retrieve all the available products for a given Partner ID.
		/// </summary>
		/// <param name="id">Identifier.</param>
		/// <returns>A HttpResponseMessage with a Status Code, and a list of products in the form {id, name}.</returns>
        public HttpResponseMessage Products(byte id)
        {
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
