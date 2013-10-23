using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Webassistenten_ads_api.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

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


        public ActionResult Test()
        {
            //return PutToDb();
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "test", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }

        public HttpResponseMessage DeleteProspekt(long id)
        {
            Prospekt prospekt = db.Prospekts.Find(id);
            

            db.Prospekts.Remove(prospekt);

            db.SaveChanges();
            HttpResponseMessage hrm = new HttpResponseMessage();

            return hrm;
            
        }


        public HttpResponseMessage PutProspekt(long id, Prospekt prospekt)
        {
            prospekt = db.Prospekts.Find(id);
            prospekt.BBOverskrift = "Modified";
            db.Entry(prospekt).State = EntityState.Modified;
            db.SaveChanges();
            HttpResponseMessage hrm = new HttpResponseMessage();
            
            return hrm;
        }

        public ActionResult PutToDb()
        {
            prospekt = new Prospekt();
            prospekt.PartnerID = 3;
            prospekt.BrukerID = 137;
            prospekt.DatoReg = new DateTime(2013, 10,23);
            prospekt.StatusID = 3;
            prospekt.Oppdragsnr = "No entity add";
            prospekt.TEMP_ModulID = 3;
            prospekt.BBOverskrift = "HDTEST";
            prospekt.Overskrift1 = "TestModell";
            prospekt.InndelingID = 3;
            prospekt.BoligtypeID = 3;
            prospekt.Annonsetekst = "HD sin annonse";
            prospekt.Adresse = "HD hjem";
            prospekt.Pris = 133713371337;
            prospekt.Postnr = "1337";
            prospekt.Poststed = "HD poststed";
            prospekt.Megler = "Erlend";
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
            //then call for all the tables:
            //db.Entry(prospekt).State = EntityState.Added;
            //db.Prospekts.Add(prospekt);
            System.Diagnostics.Debug.WriteLine(db.Entry(prospekt).Entity.Megler);
            //var result = (db.Prospekts.Where(p => (p.Overskrift1 == "TestModell")).Select(p => p));
            //var resultProcessed = (DbQuery<Prospekt>)result;
            //Prospekt prospekt1 = resultProcessed.First();
            System.Diagnostics.Debug.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA!");
            //System.Diagnostics.Debug.WriteLine(prospekt1.Megler);
            
            //finally:
            //db.SaveChanges();
            //method
            return View();

        }

        //Getters for db
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
