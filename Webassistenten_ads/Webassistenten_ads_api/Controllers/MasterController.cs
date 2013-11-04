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
        //AnnonseHarBestilling annonseharbestilling = new AnnonseHarBestilling();
        //Modul modul = new Modul();
        //Produkt produkt = new Produkt();
        //ProduktHarAnnonse produktHarAnnonse = new ProduktHarAnnonse();
        //ProduktHarModul productHarModul = new ProduktHarModul();
        //Prospekt prospekt;// = new Prospekt();
        //ProspektHarBestilling prospektharbestilling = new ProspektHarBestilling();
        ////info into this model, which we can use to put into the tables later on.
        //RealEstateAdInfo model = new RealEstateAdInfo();

        //
        // GET: /Master/
        public static string folder = "~/hdTest/"; // this has to be changed to something according 

        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [System.Web.Mvc.HttpPost]
        public ActionResult Upload(int ProductId, Realtor ResponsibleRealtor, string Area,int Type, 
            int Price, string Location,string Headline, Address Address, int ZipCode, 
            string ZipArea, DateTime BookingDate,
            /*Non-mandatory fields below:*/ DateTime? OpenHouseDate, DateTime? ConstructionYear,
            int FinnCode = 0, int ContractNr = 0,float P_rom = 0, float Boa = 0, float Bta = 0,
            float Bra = 0, int Costs = 0, int PurchaseCosts = 0, int CommonCosts = 0, int AmountSharedDebt = 0,
            int CommonExpenses = 0, int PropertyArea = 0, string PropertyType = "",
            int Floor = 0, int Bedrooms = 0, int Rooms = 0, string OpenHouseText = "",
            string RealEstAgentName ="", string RealEstAgentTitle = "", int RealEstAgentMobile = 0, int RealEstAgentPhone = 0,
            string RealEstAgentEmail = "", string AdText = "")
        {
            System.Diagnostics.Debug.WriteLine(ProductId);
            System.Net.Mail.MailAddress mail = null;
            if (IsValidMail(RealEstAgentEmail))
            {
                mail = new System.Net.Mail.MailAddress(RealEstAgentEmail);
            }
            var file = Request.Files[0];


            

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                
                var path = Path.Combine(Server.MapPath(folder), "");
                if (!Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }
                path = Path.Combine(Server.MapPath(folder), fileName);
                FileInfo fileInfo = new FileInfo(path);

                if (fileInfo.Extension != ".pdf")
                    return RedirectToAction("Fail");
                System.Diagnostics.Debug.WriteLine(path);
                file.SaveAs(path);
                //the file uploaded was in fact a pdf and everything is ok! Now let's do some db stuff
                ProspektHarBestilling prospektHarBestilling = new ProspektHarBestilling();
                Prospekt prospekt = new Prospekt();
                prospektHarBestilling.Filnavn = path;
                prospektHarBestilling.DatoBest = BookingDate;
                prospekt.DatoReg = DateTime.Now;
                

                
                db.ProspektHarBestillings.Add(prospektHarBestilling);
                db.Prospekts.Add(prospekt);
                db.SaveChanges();

                return RedirectToAction("Success");

            }
            else
                return RedirectToAction("Fail");
            

        }

        [System.Web.Mvc.HttpPost]
        public ActionResult AddNewAd(int ProductId)
        {
            
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "AddNewAd", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View(new HD(ProductId));
        }
        public ActionResult ChooseModule(string email, int id)
        {
            HD hd = new HD();
            //hd.checkMail(email);
            hd.checkId(id);
            return View(hd);
        }



        public ActionResult Fail()
        {
            return View();
        }
        public ActionResult Success()
        {
            return View();
        }

        

        public IEnumerable<ProduktUtgivelse> GetNextFivePublishables(byte prodId)
        {
            BoligEntities1 db = new BoligEntities1();

            var result = (from prodUtgivelse in db.ProduktUtgivelses
                          where prodUtgivelse.ProduktID == prodId && prodUtgivelse.BookingFristSlutt > 0 && prodUtgivelse.DatoUtgivelse > System.DateTime.Today
                          select prodUtgivelse);

            result.OrderBy<ProduktUtgivelse, DateTime>(utgivelse => utgivelse.DatoUtgivelse);
            result = result.Take(5);

            return result;
        }



        private bool IsValidMail(string emailaddress)
        {
            if (emailaddress == "")
                return false;
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        


        

       




       

        




    }
}
