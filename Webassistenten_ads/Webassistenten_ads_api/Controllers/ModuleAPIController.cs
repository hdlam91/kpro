using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
using System.Web;

using Webassistenten_ads_api.Models;

namespace Webassistenten_ads_api.Controllers
{
    
    public class ModuleAPIController : ApiController
    {

        [HttpGet]
        [ActionName("Modules")]
		/// <summary>
		/// This method will retrieve the available modules for a selected product.
		/// </summary>
		/// <param name="id">Product Identifier.</param>
		/// <returns>A HttpResponseMessage with a status code, and the modules for the specified Product ID.<br/>
		/// The Modules are in the form {id, name, dimensions, date available}.</returns>
        public HttpResponseMessage Modules(byte id)
        {
            //id = produktID, somekind of authentication has to be done here.
            IEnumerable<Modul> mod = DatabaseConnection.GetProductModules(id);
            List<ProduktUtgivelse> dt = DatabaseConnection.GetNextFivePublishables(id).ToList();
            var modulId = new List<int>();
            var modulNavn = new List<string>();
            var dimensjoner = new List<string>();
            var datoTilgjengelig = new List<string>();


            foreach (Modul modit in mod)
            {
                modulId.Add(modit.ModulID);
                modulNavn.Add(modit.Modulnavn);
                dimensjoner.Add(modit.Bredde + "x" + modit.Høyde);
                

            }
            foreach(ProduktUtgivelse puit in dt)
            {
                datoTilgjengelig.Add(puit.DatoUtgivelse.Day + "." + puit.DatoUtgivelse.Month + "." + puit.DatoUtgivelse.Year);
            }


            return ControllerContext.Request
        .CreateResponse(HttpStatusCode.OK, new { modulId, modulNavn, dimensjoner, datoTilgjengelig });

        }  
    }
}
