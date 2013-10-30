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
        public HD()
        {

        }

        public IEnumerable<ProduktUtgivelse> GetDate()
        {
            MethodsToImplement mti = new MethodsToImplement();
            return mti.GetNextFivePublishables(2);
            //    foreach (ProduktUtgivelse p in pd)
            //    {
            //        System.Diagnostics.Debug.WriteLine(p.DatoUtgivelse);
            //    }

        }

        

        //    System.Diagnostics.Debug.WriteLine("get meth");

        //    //putToDb();        
        //    return View();
    }
    
}