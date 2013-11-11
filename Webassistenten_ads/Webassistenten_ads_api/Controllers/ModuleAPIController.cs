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
        [HttpPost]
        [ActionName("Auth")]
        public HttpResponseMessage PostAuth([FromBody] int id)
        {
            id = 1;
            System.Diagnostics.Debug.WriteLine("id: \t "+id);

            var response = new HttpResponseMessage(HttpStatusCode.Created){
                
                Content = null//new StringContent(id.ToString()+"hello!")
                
            };
            if (id != 0)
            {
                response.Headers.Location =
                new Uri(Url.Link("DefaultApi", new { action = "Modules", id = id }));
                System.Diagnostics.Debug.WriteLine("if executed");
                

                return response;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("else executed");
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
               
            

        }


        //template if we want to go back to the old method or try new stuff.
        //[HttpGet]
        //[ActionName("Modules")]
        //public List<Modul> Modules(byte id)
        //{
        //    System.Diagnostics.Debug.WriteLine("Routing complete");
        //    List<Modul> mod = DatabaseConnection.GetProductModules(id).ToList() ;//.AsEnumerable();
            
        //    return mod;
        //}

        //does not work
        //[HttpGet]
        //[ActionName("Modules")]
        //public HttpResponseMessage Modules(byte id)
        //{
        //    System.Diagnostics.Debug.WriteLine("Routing complete");
        //    IEnumerable<Modul> mod = DatabaseConnection.GetProductModules(id).AsEnumerable();
        //    //List<Modul> returnObject = new List<Modul>() ;
            
        //    //foreach (Modul modit in mod)
        //    //{
        //    //    System.Diagnostics.Debug.WriteLine(modit.ModulID);
        //    //}
            


        //    return ControllerContext.Request.CreateResponse(HttpStatusCode.OK, new {mod});

        //}


        [HttpGet]
        [ActionName("Modules")]
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
