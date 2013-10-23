using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webassistenten_ads_api.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

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
        Prospekt prospekt;// = new Prospekt();
        ProspektHarBestilling prospektharbestilling = new ProspektHarBestilling();
        //info into this model, which we can use to put into the tables later on.
        RealEstateAdInfo model = new RealEstateAdInfo();

        //
        // GET: /Master/

        public ActionResult Index()
        {
            return PutToDb();
            //return View();
        }

        public ActionResult PutToDb()
        {
            prospekt = new Prospekt();
            //prospekt.ProspektID = 1101433;
            prospekt.PartnerID = 3;
            prospekt.BrukerID = 137;
            prospekt.DatoReg = new DateTime(2013, 10,23);
            prospekt.StatusID = 3;
            prospekt.Oppdragsnr = "No entity add";
            prospekt.TEMP_ModulID = 3;
            prospekt.BBOverskrift = "HDTEST";
            prospekt.Overskrift1 = "HDTEST";
            prospekt.InndelingID = 3;
            prospekt.BoligtypeID = 3;
            prospekt.Annonsetekst = "HD sin annonse";
            prospekt.Adresse = "HD hjem";
            prospekt.Pris = 133713371337;
            prospekt.Postnr = "1337";
            prospekt.Poststed = "HD poststed";
            prospekt.Megler = "HD";
            prospekt.MeglerEmail = "HD@HD.com";
            prospekt.MeglerTittel = "Master of the meggler";
            prospekt.MeglerAdresse = "Hjemme hos HD";
            prospekt.KontorTlf = "13371337";
            prospekt.Tomtetype = "Eier tomt";
            prospekt.Kommune = "Trondheim";
            prospekt.Selger = "Kpro 15";
            prospekt.Meglerfirma = "Kpro AS";
            prospekt.Orgnr = "1337";



           


            //db.Entry(prospekt).State = EntityState.Modified;
            //DO this for everything.
            //db.Entry(prospekt).State = EntityState.Added;
            //then call for all the tables:
            db.Prospekts.Add(prospekt);
            
            //finally:
            db.SaveChanges();
            //method
            return View();

        }


        //public Prospekt GetProspekt(long id)
        //{
        //    prospekt = db.Prospekts.Find(id);
        //    //if (prospekt == null)
        //    //{
        //    //    throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
        //    //}

        //    return prospekt;
        //}




    }
}
