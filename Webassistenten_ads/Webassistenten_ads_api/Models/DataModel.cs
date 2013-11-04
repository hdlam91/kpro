using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Http;

namespace Webassistenten_ads_api.Models
{
    public class DataModel
    {
        public int productId { get; private set; }
        WebAssistentAuth auth;
        public DataModel(int productId)
        {
            this.productId = productId;
        }

        public DataModel()
        {
            auth = new WebAssistentAuth();
        }

        public void checkMail(string email)
        {
            auth.EmailAuthenticate(email);
        }

        public void checkId(int id)
        {
            auth.IdAuthenticate(id);
        }

        public byte getId()
        {
            return (byte)auth.authId;
        }
        public IEnumerable<ProduktUtgivelse> GetDate()
        {
            MethodsToImplement mti = new MethodsToImplement();
            return mti.GetNextFivePublishables((byte)productId);
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