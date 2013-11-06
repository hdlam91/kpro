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

        /// <summary>
        /// Index method for login/identifying
        /// </summary>
        /// <returns>IndexView</returns>
        [System.Web.Mvc.HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ProductId"></param>
        /// <param name="ResponsibleRealtor"></param>
        /// <param name="Area"></param>
        /// <param name="Type"></param>
        /// <param name="Price"></param>
        /// <param name="Location"></param>
        /// <param name="Headline"></param>
        /// <param name="Address"></param>
        /// <param name="ZipCode"></param>
        /// <param name="ZipArea"></param>
        /// <param name="BookingDate"></param>
        /// <param name="OpenHouseDate"></param>
        /// <param name="ConstructionYear"></param>
        /// <param name="FinnCode"></param>
        /// <param name="ContractNr"></param>
        /// <param name="P_rom"></param>
        /// <param name="Boa"></param>
        /// <param name="Bta"></param>
        /// <param name="Bra"></param>
        /// <param name="Costs"></param>
        /// <param name="PurchaseCosts"></param>
        /// <param name="CommonCosts"></param>
        /// <param name="AmountSharedDebt"></param>
        /// <param name="CommonExpenses"></param>
        /// <param name="PropertyArea"></param>
        /// <param name="PropertyType"></param>
        /// <param name="Floor"></param>
        /// <param name="Bedrooms"></param>
        /// <param name="Rooms"></param>
        /// <param name="OpenHouseText"></param>
        /// <param name="RealEstAgentName"></param>
        /// <param name="RealEstAgentTitle"></param>
        /// <param name="RealEstAgentMobile"></param>
        /// <param name="RealEstAgentPhone"></param>
        /// <param name="RealEstAgentEmail"></param>
        /// <param name="AdText"></param>
        /// <returns>Redirects</returns>
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
        /// <summary>
        /// Passes the datamodel to the view.
        /// </summary>
        /// <param name="ProductId"></param>
        /// <returns>AddNewAdView</returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult AddNewAd(int ProductId)
        {
            
            string apiUri = Url.HttpRouteUrl("DefaultApi", new { controller = "AddNewAd", });
            ViewBag.ApiUrl = new Uri(Request.Url, apiUri).AbsoluteUri.ToString();

            return View(new DataModel(ProductId));
        }

        /// <summary>
        /// Shows the correct modules for this given partnerID
        /// </summary>
        /// <param name="email"></param>
        /// <param name="id"></param>
        /// <returns>ChooseModuleView</returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult ChooseModule(string email, int id)
        {
            DataModel dm = new DataModel();
            if (IsValidMail(email))
            {
                dm.checkMail(email);
            }
            else
            {
                dm.checkId(id);
            }
            return View(dm);
        }


        /// <summary>
        /// Something missing or wrong with the datainput
        /// </summary>
        /// <returns>FailView</returns>
        public ActionResult Fail()
        {
            return View();
        }
        /// <summary>
        /// everything went right with inserting data/file
        /// </summary>
        /// <returns>SuccessView</returns>
        public ActionResult Success()
        {
            return View();
        }

        //checks the that a mail is legal
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
