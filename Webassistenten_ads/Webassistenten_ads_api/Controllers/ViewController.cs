using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads_api.Controllers
{
    public class ViewController : Controller
    {
        //
        // GET: /View/

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

    }
}
