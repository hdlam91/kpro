using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webassistenten_ads_api.Models;

namespace Webassistenten_ads_api.Controllers
{
    public class MasterController : Controller
    {

        private BoligEntities1 db = new BoligEntities1();
               //..... DO this for every table.
        AnnonseHarBestilling annonseharbestilling = new AnnonseHarBestilling();
        Modul modul = new Modul();
        Produkt produkt = new Produkt();
        ProduktHarAnnonse produktHarAnnonse = new ProduktHarAnnonse();
        ProduktHarModul productHarModul = new ProduktHarModul();
        Prospekt prospekt = new Prospekt();
        ProspektHarBestilling prospektharbestilling = new ProspektHarBestilling();
        //info into this model, which we can use to put into the tables later on.
        RealEstateAdInfo model = new RealEstateAdInfo();

        //
        // GET: /Master/

        public ActionResult Index()
        {
            return View();
        }

        public void putToDb()
        {
            prospekt.ProspektID = model.RealtorId;
            //DO this for everything.

            //then call for all the tables:
            db.Prospekts.Add(prospekt);

            //finally:
            db.SaveChanges();
            //method

        }

    }
}
