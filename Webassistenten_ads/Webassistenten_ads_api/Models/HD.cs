using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace Webassistenten_ads_api.Models
{
    public class HD
    {
        public int productId { get; private set; }
        public HD(int productId)
        {
            this.productId = productId;
        }

        public HD()
        {
            
        }

        public IEnumerable<ProduktUtgivelse> GetDate(byte productID)
        {
            MethodsToImplement mti = new MethodsToImplement();
            return mti.GetNextFivePublishables(productID);
            //    foreach (ProduktUtgivelse p in pd)
            //    {
            //        System.Diagnostics.Debug.WriteLine(p.DatoUtgivelse);
            //    }

        }

        public IEnumerable<Produkt> GetProducts(byte partnerID)
        {
            MethodsToImplement mti = new MethodsToImplement();
            return mti.GetProducts(partnerID);
        }


        public IEnumerable<Modul> GetProductModules()
        {
            return new MethodsToImplement().GetProductModules((byte)productId);

        }


        

        //    System.Diagnostics.Debug.WriteLine("get meth");

        //    //putToDb();        
        //    return View();
    }
    
}