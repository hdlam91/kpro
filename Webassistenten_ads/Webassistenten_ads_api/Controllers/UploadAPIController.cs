using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Webassistenten_ads_api.Controllers
{
    public class UploadAPIController : ApiController
    {
        public static string folder = "~/hdTest/";

        [HttpPost]
        public HttpResponseMessage Upload()
        {
            //initialize
            int ProductId;
            string ResponsibleRealtor;
            string Area;
            int Type;
            int Price;
            string Location;
            string Headline;
            string Address;
            int ZipCode;
            string ZipArea;
            DateTime BookingDate;
            try
            {
                ProductId = int.Parse(System.Web.HttpContext.Current.Request.Params["ProductId"]);
                ResponsibleRealtor = checkString(System.Web.HttpContext.Current.Request.Params["ResponsibleRealtor"]);
                Area = checkString(System.Web.HttpContext.Current.Request.Params["Area"]);
                Type = int.Parse(System.Web.HttpContext.Current.Request.Params["Type"]);
                Price = int.Parse(System.Web.HttpContext.Current.Request.Params["Price"]);
                Location = checkString(System.Web.HttpContext.Current.Request.Params["Location"]);
                Headline = checkString(System.Web.HttpContext.Current.Request.Params["Headline"]);
                Address = checkString(System.Web.HttpContext.Current.Request.Params["Address"]);
                ZipCode = int.Parse(System.Web.HttpContext.Current.Request.Params["ZipCode"]);
                ZipArea = checkString(System.Web.HttpContext.Current.Request.Params["ZipArea"]);
                BookingDate = DateTime.ParseExact(System.Web.HttpContext.Current.Request.Params["BookingDate"], "dd.mm.yyyy", new CultureInfo("nb-NO"), DateTimeStyles.None);// 01.06.2009 04:37:
            }
            catch (FormatException a)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "BookingDate needs to be in the format dd.mm.yyyy" + a);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "please fill in the required fields, one of them was empty       " + e);
            }

            
            ///*Non-mandatoryfieldsbelow:*/;
             
            
            DateTime? OpenHouseDate = null;
            DateTime? ConstructionYear = null;
            if (!string.IsNullOrEmpty((System.Web.HttpContext.Current.Request.Params["OpenHouseDate"])))
            {
                try
                {
                    OpenHouseDate = DateTime.ParseExact(System.Web.HttpContext.Current.Request.Params["OpenHouseDate"], "dd.mm.yyyy", new CultureInfo("nb-NO"), DateTimeStyles.None);
                }
                catch (Exception e)
                {
                    Request.CreateResponse(HttpStatusCode.BadRequest, "OpenHouse date needs to be in the format dd.mm.yyyy" + e);
                }
            }
            if (!string.IsNullOrEmpty((System.Web.HttpContext.Current.Request.Params["ConstructionYear"])))
            {
                try
                {
                    ConstructionYear = DateTime.ParseExact(System.Web.HttpContext.Current.Request.Params["ConstructionYear"], "yyyy", new CultureInfo("nb-NO"), DateTimeStyles.None);                    
                }
                catch (Exception e)
                {
                    Request.CreateResponse(HttpStatusCode.BadRequest, "OpenHouse date needs to be in the format yyyy" + e);
                }
            }

            int FinnCode;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["FinnCode"], out FinnCode);
            int ContractNr;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["ContractNr"], out ContractNr);
            float P_rom; 
            float.TryParse(System.Web.HttpContext.Current.Request.Params["P_rom"], out P_rom);
            float Boa;
            float.TryParse(System.Web.HttpContext.Current.Request.Params["Boa"], out Boa);
            float Bta;
            float.TryParse(System.Web.HttpContext.Current.Request.Params["Bta"], out Bta);
            float Bra;
            float.TryParse(System.Web.HttpContext.Current.Request.Params["Bra"], out Bra);
            int Costs;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["Costs"], out Costs);
            int PurchaseCosts;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["PurchaseCosts"], out PurchaseCosts);
            int CommonCosts;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["CommonCosts"], out CommonCosts);
            int AmountSharedDebt;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["AmountSharedDebt"], out AmountSharedDebt);
            int CommonExpenses;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["CommonExpenses"],out CommonExpenses);
            int PropertyArea;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["PropertyArea"], out PropertyArea);
            string PropertyType = System.Web.HttpContext.Current.Request.Params["PropertyType"];
            int Floor;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["Floor"], out Floor);
            int Bedrooms;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["Bedrooms"], out Bedrooms);
            int Rooms;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["Rooms"], out Rooms);
            string OpenHouseText = System.Web.HttpContext.Current.Request.Params["OpenHouseText"];
            string RealEstAgentName = System.Web.HttpContext.Current.Request.Params["RealEstAgentName"];
            string RealEstAgentTitle = System.Web.HttpContext.Current.Request.Params["RealEstAgentTitle"];
            int RealEstAgentMobile;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["RealEstAgentMobile"], out RealEstAgentMobile);
            int RealEstAgentPhone; 
            int.TryParse(System.Web.HttpContext.Current.Request.Params["RealEstAgentPhone"], out RealEstAgentPhone);
            
            string RealEstAgentEmail;
            if (checkMail(System.Web.HttpContext.Current.Request.Params["RealEstAgentEmail"]))
            {
                RealEstAgentEmail = System.Web.HttpContext.Current.Request.Params["RealEstAgentEmail"];
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "email is not valid.");
            }

            string AdText = System.Web.HttpContext.Current.Request.Params["AdText"];
 


            System.Diagnostics.Debug.Write(FinnCode.ToString());
            HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                result = Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "something went wrong, mediatype not supported");
            }
            else
            {
                if (httpRequest.Files.Count == 1)
                {
                    var docfiles = new List<string>();
                    string file = httpRequest.Files[0].ToString();
                    var postedFile = httpRequest.Files[0];
                    var filePath = System.Web.HttpContext.Current.Server.MapPath(folder + postedFile.FileName);

                    postedFile.SaveAs(filePath);
                    docfiles.Add(filePath);

                    FileInfo fileInfo = new FileInfo(filePath);

                    if (fileInfo.Extension != ".pdf")
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest, "upload a pdf file!");
                    }
                    else
                    {
                        result = Request.CreateResponse(HttpStatusCode.Created, "upload went went well");
                    }
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, "a file could not be found");
                }
            }
            return result;
        }

        //[HttpGet]
        //public HttpResponseMessage GetUpload(int ProductId, string ResponsibleRealtor, string Area, int Type,
        //    int Price, string Location, string Headline, string Address, int ZipCode,
        //    string ZipArea, DateTime BookingDate,
        //    /*Non-mandatory fields below:*/ DateTime? OpenHouseDate, DateTime? ConstructionYear,
        //    int FinnCode = 0, int ContractNr = 0, float? P_rom = 0, float? Boa = 0, float? Bta = 0,
        //    float? Bra = 0, int Costs = 0, int PurchaseCosts = 0, int CommonCosts = 0, int AmountSharedDebt = 0,
        //    int CommonExpenses = 0, int PropertyArea = 0, string PropertyType = "",
        //    int Floor = 0, int Bedrooms = 0, int Rooms = 0, string OpenHouseText = "",
        //    string RealEstAgentName = "", string RealEstAgentTitle = "", int RealEstAgentMobile = 0, int RealEstAgentPhone = 0,
        //    string RealEstAgentEmail = "", string AdText = "")
        //{
        //    System.Diagnostics.Debug.WriteLine(ProductId + "," + Address);
        //    return Request.CreateResponse(HttpStatusCode.OK);
        //}

        private string checkString(string input) 
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new System.ArgumentException("Parameter cannot be null");
            }
            else
                return input;
        }

        private Boolean checkMail(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }
            try
            {
                System.Net.Mail.MailAddress m = new System.Net.Mail.MailAddress(input);
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
