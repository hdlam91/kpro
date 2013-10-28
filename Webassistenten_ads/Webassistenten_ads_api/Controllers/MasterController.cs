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
using System.Web.Http;
using System.ComponentModel.DataAnnotations;

using System.IO;


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


        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {

            return View();

        }


        [System.Web.Mvc.HttpPost]
        public ActionResult Upload(string t)
        {
            var file = Request.Files[0];


            

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);
                

                var path = Path.Combine(Server.MapPath("~/hdTest/"), "");
                if (!Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path = Path.Combine(Server.MapPath("~/hdTest/"), fileName);
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Extension != ".pdf")
                    return RedirectToAction("Fail");
                System.Diagnostics.Debug.WriteLine(path);
                file.SaveAs(path);
                System.Diagnostics.Debug.WriteLine(t);
                return RedirectToAction("Success");

            }
            else
                return RedirectToAction("Fail");
            

        }

        public ActionResult Test() {
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "Test", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View();
        }

        public ActionResult Fail()
        {

            return View();
        }
        public ActionResult Success()
        {

            return View();
        }

        
	
	    


        


        

       




       

        




    }
}
