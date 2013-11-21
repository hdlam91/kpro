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
using Webassistenten_ads_api.Repository;
using System.IO;


namespace Webassistenten_ads_api.Controllers
{
    public class MasterController : Controller
    {

        
        // GET: /Master/
        public static string folder = Constants.FOLDER;

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
        /// Accepts a HttpPost with an ad pdf, and the information that belongs to it.
        /// </summary>
        /// <param name="ProductId">Required</param>
        /// <param name="ModuleId">Required</param>
        /// <param name="ResponsibleRealtor">Required</param>
        /// <param name="Area">Required</param>
        /// <param name="Type">Required</param>
        /// <param name="Price">Required</param>
        /// <param name="Location">Required</param>
        /// <param name="Headline">Required</param>
        /// <param name="Address">Required</param>
        /// <param name="ZipCode">Required</param>
        /// <param name="ZipArea">Required</param>
        /// <param name="BookingDate">Required</param>
        /// <param name="OpenHouseDate">Optional</param>
        /// <param name="ConstructionYear">Optional</param>
        /// <param name="FinnCode">Optional</param>
        /// <param name="ContractNr">Optional</param>
        /// <param name="P_rom">Optional</param>
        /// <param name="Boa">Optional</param>
        /// <param name="Bta">Optional</param>
        /// <param name="Bra">Optional</param>
        /// <param name="Costs">Optional</param>
        /// <param name="PurchaseCosts">Optional</param>
        /// <param name="CommonCosts">Optional</param>
        /// <param name="AmountSharedDebt">Optional</param>
        /// <param name="CommonExpenses">Optional</param>
        /// <param name="PropertyArea">Optional</param>
        /// <param name="PropertyType">Optional</param>
        /// <param name="Floor">Optional</param>
        /// <param name="Bedrooms">Optional</param>
        /// <param name="Rooms">Optional</param>
        /// <param name="OpenHouseText">Optional</param>
        /// <param name="RealEstAgentName">Optional</param>
        /// <param name="RealEstAgentTitle">Optional</param>
        /// <param name="RealEstAgentMobile">Optional</param>
        /// <param name="RealEstAgentPhone">Optional</param>
        /// <param name="RealEstAgentEmail">Optional</param>
        /// <param name="AdText">Optional</param>
        /// <returns>Redirects</returns>
        [System.Web.Mvc.HttpPost]
        public ActionResult Upload(int ProductId, int ModuleId, string ResponsibleRealtor, string Area,int Type, 
            int Price, string Location,string Headline, string Address, int ZipCode, 
            string ZipArea, DateTime BookingDate,
            /*Non-mandatory fields below:*/ DateTime? OpenHouseDate, DateTime? ConstructionYear,
            string FinnCode = "", string ContractNr = "",long P_rom = 0, long Boa = 0, long Bta = 0,
            long Bra = 0, int Costs = 0, int PurchaseCosts = 0, int CommonCosts = 0, int AmountSharedDebt = 0,
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
                file.SaveAs(path);
                //the file uploaded was in fact a pdf and everything is ok! Now let's do some db stuff
                using (BoligEntities1 db = new BoligEntities1())
                {

                    Prospekt p = new Prospekt();
                    ProspektHarBestilling phb = new ProspektHarBestilling();

                    p.Omraade = Location;
                    p.Postnr = ZipCode.ToString();
                    p.Poststed = ZipArea;
                    p.BBOverskrift = Headline;
                    p.Pris = Price;
                    p.Adresse = Address;
                    p.DatoReg = DateTime.Now;
                    p.Omraade = Area;
                    p.BoligtypeID = (byte)Type;

                    p.FinnKode = FinnCode;
                    p.Oppdragsnr = ContractNr;
                    p.PROM = P_rom;
                    p.BOA = Boa;
                    p.BTA = Bta;
                    p.BRUA = Bra; //antas at BRA skal være brua?
                    p.Omkostninger = Costs;
                    p.Kjopsomkostninger = PurchaseCosts;
                    p.FellesInnskudd = AmountSharedDebt;//felleskostnad, finnes ikke i db.
                    p.Fellesgjeld = AmountSharedDebt;
                    p.Fellesutgifter = CommonExpenses;
                    p.Tomteareal = PropertyArea;
                    p.Tomtetype = PropertyType;
                    p.Byggeaar = ConstructionYear.ToString();
                    p.Etasje = (byte)Floor;
                    p.Soverom = (short)Bedrooms;
                    p.Rom = (short)Rooms;
                    p.VisningFra = OpenHouseDate;
                    p.Visning = OpenHouseText;
                    p.Megler = ResponsibleRealtor;
                    p.MeglerTittel = RealEstAgentTitle;
                    p.MeglerTlfMobil = RealEstAgentMobile.ToString();
                    p.MeglerTlf = RealEstAgentPhone.ToString();
                    p.MeglerEmail = RealEstAgentEmail;
                    p.Annonsetekst = AdText;


                    db.Prospekts.Add(p);
                    db.SaveChanges();//this ensures that we get a prospektId to be used in prospektharbestilling
                    phb.ProspektID = p.ProspektID;
                    phb.DatoBest = BookingDate;
                    phb.Filnavn = path;
                    phb.ProduktID = (byte)ProductId;

                    phb.ModulID = ModuleId;
                    db.ProspektHarBestillings.Add(phb);
                    db.SaveChanges();
                }
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
        public ActionResult ChooseProduct(string email, int id)
        {
            DataModel dm = new DataModel();
            //if (IsValidMail(email))
            //{
            //    dm.checkMail(email);
            //}
            //else
            //{
                dm.checkId(id);
            //}
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
        /// Everything went right with inserting data/file
        /// </summary>
        /// <returns>SuccessView</returns>
        public ActionResult Success()
        {
            return View();
        }

        //Checks the that a mail is legal
        private bool IsValidMail(string emailaddress)
        {
            if (string.IsNullOrEmpty(emailaddress))
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
