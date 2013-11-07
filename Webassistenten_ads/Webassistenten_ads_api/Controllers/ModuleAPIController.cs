using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Web.Http;
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
       


        //[HttpGet]
        //[ActionName("Modules")]
        //public IEnumerable<Modul> Modules(byte id)
        //{
        //    System.Diagnostics.Debug.WriteLine("Routing complete");
        //    IEnumerable<Modul> mod = DatabaseConnection.GetProductModules(id);//.AsEnumerable();
        //    foreach (Modul modit in mod)
        //    {
        //        System.Diagnostics.Debug.WriteLine(modit.ModulID);
        //    }
        //    return mod;
        //}

        [HttpGet]
        [ActionName("Modules")]
        public HttpResponseMessage Modules(byte id)
        {
            System.Diagnostics.Debug.WriteLine("Routing complete");
            IEnumerable<Modul> mod = DatabaseConnection.GetProductModules(id);//.AsEnumerable();
            List<Modul> newMod = new List<Modul>();
            foreach (Modul modit in mod)
            {
                newMod.Add(modit);

            }

            return Request.CreateResponse(HttpStatusCode.OK, newMod);
        }

        



        
       
        
    }
}
