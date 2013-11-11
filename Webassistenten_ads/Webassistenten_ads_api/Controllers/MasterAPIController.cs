using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Webassistenten_ads_api.Models;

namespace Webassistenten_ads_api.Controllers
{
    public class MasterAPIController : ApiController
    {
        public static string folder = "~/hdTest/";

        [HttpPost]
        public HttpResponseMessage Upload([FromBody] RealEstateAdInfo value)
        {
            System.Diagnostics.Debug.WriteLine("yaaaay metoden ble kjørt");
            System.Diagnostics.Debug.WriteLine(value.Location);
            HttpResponseMessage result = null;
            //var httpRequest = System.Web.HttpContext.Current.Request;
            //if (!Request.Content.IsMimeMultipartContent("form-data"))
            //{
            //    result = Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "something went wrong, mediatype not supported");
            //}
            //else
            //{
            //    if (httpRequest.Files.Count == 1)
            //    {
            //        var docfiles = new List<string>();
            //        string file = httpRequest.Files[0].ToString();
            //        var postedFile = httpRequest.Files[0];
            //        var filePath = System.Web.HttpContext.Current.Server.MapPath(folder + postedFile.FileName);

            //        postedFile.SaveAs(filePath);
            //        docfiles.Add(filePath);

            //        FileInfo fileInfo = new FileInfo(filePath);

            //        if (fileInfo.Extension != ".pdf")
            //        {
            //            result = Request.CreateResponse(HttpStatusCode.BadRequest, "upload a pdf file!");
            //        }
            //        else
            //        {
            //            result = Request.CreateResponse(HttpStatusCode.Created, "upload went went well");
            //        }
            //    }
            //    else
            //    {
            //        result = Request.CreateResponse(HttpStatusCode.BadRequest, "a file could not be found");
            //    }
            //}
            result = Request.CreateResponse(HttpStatusCode.Accepted, value.Location);
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
