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

using System.Collections.Generic;
using System.IO;


namespace Webassistenten_ads_api.Controllers
{
    public class MasterController : ApiController
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

        

        //[System.Web.Mvc.HttpGet]
        //public ActionResult Index()
        //{
        //    MethodsToImplement mti = new MethodsToImplement();
        //    IEnumerable<ProduktUtgivelse> pd = mti.GetNextFivePublishables(2);
        //    foreach (ProduktUtgivelse p in pd)
        //    {
        //        System.Diagnostics.Debug.WriteLine(p.DatoUtgivelse);
        //    }

        //    System.Diagnostics.Debug.WriteLine("get meth");

        //    //putToDb();        
        //    return View();
        //}

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Index()
        {
            System.Diagnostics.Debug.WriteLine("file post");
            HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;

            // Verify that this is an HTML Form file upload request
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                result = Request.CreateResponse(HttpStatusCode.UnsupportedMediaType);
            }
            else
            {
                if (httpRequest.Files.Count == 1)
                {
                    var docfiles = new List<string>();
                    string file = httpRequest.Files[0].ToString();
                    //foreach (string file in httpRequest.Files) {
                    var postedFile = httpRequest.Files[0];
                    var filePath = System.Web.HttpContext.Current.Server.MapPath("~/" + postedFile.FileName);

                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                    FileInfo fileInfo = new FileInfo(filePath);

                    if (fileInfo.Extension != ".pdf")
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest);
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.Created, docfiles);
                    }
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }

            return result;

        }



        //public ActionResult Index(int prodId, int type, int price, int zipCode, string zipArea, string location, string headLine,
        //    int finnCode, int contractNr, float prom, float boa, float bta, float bra, int cost,
        //    int purchaseCost, int commonCost, int amountSharedDebt, int commonExpenses, int propertyArea,
        //    int floor, int bedrooms, int rooms, int mobile, int phone)
        //{
        //    RealEstateAdInfo reai = new RealEstateAdInfo(prodId, type,  price,  zipCode,  zipArea,  location,  headLine, 
        //     finnCode,  contractNr,  prom,  boa,  bta,  bra, cost,
        //    purchaseCost, commonCost, amountSharedDebt,  commonExpenses, propertyArea,
        //    floor, bedrooms, rooms, mobile, phone);

        //    prospekt = new Prospekt();
        //    prospekt.PartnerID = 3;
        //    prospekt.BrukerID = 137;
        //    prospekt.DatoReg = DateTime.Now;
        //    prospekt.StatusID = 3;
        //    prospekt.KommAvgifter = reai.Costs;
        //    prospekt.Fellesgjeld = reai.CommonCosts;
        //    prospekt.Etasje = (byte)reai.Floor;
        //    prospekt.Rom = (byte)reai.Rooms;

        //    prospekt.TEMP_ModulID = 3;

        //    prospekt.BOA = (long)reai.Boa;
        //    prospekt.BTA = (long)reai.Bta;
        //    prospekt.BBOverskrift = reai.Headline;
        //    prospekt.Overskrift1 = reai.Headline;
            
        //    prospekt.Annonsetekst = reai.AdText;
            
        //    prospekt.Pris = reai.Price;
        //    prospekt.Postnr = reai.ZipCode.ToString();
        //    prospekt.Poststed = reai.ZipArea;
            
        //    prospekt.MeglerAdresse = "Hjemme hos HD";
        //    prospekt.KontorTlf = reai.RealEstAgentPhone.ToString();
        //    prospekt.MeglerTlfMobil = reai.RealEstAgentMobile.ToString();
            
        //    prospekt.Kommune = reai.Area;
        //    prospekt.Selger = reai.RealEstAgentName;

        //    System.Diagnostics.Debug.WriteLine("post meth");


        //    db.Prospekts.Add(prospekt);
        //    db.SaveChanges();

        //    return View();

        //}
	
	    


        //public ActionResult Test()
        //{
        //    System.Diagnostics.Debug.WriteLine("get MODIFY");
        //    return View();
        //}



        public IEnumerable<Produkt> GetProducts(byte partnerId)
        {
            BoligEntities1 db = new BoligEntities1();

            var result = from partnerProd in db.PartnerHarProdukts
                         where partnerProd.PartnerID == partnerId
                         select partnerProd.Produkt;

            return result;
        }

       




        public void PutToDb()
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
