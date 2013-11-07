using System;
using System.Collections.Generic;
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

        [System.Web.Mvc.HttpPost]
        public HttpResponseMessage Upload(int ProductId, string ResponsibleRealtor, string Area, int Type,
            int Price, string Location, string Headline, string Address, int ZipCode,
            string ZipArea, DateTime BookingDate,
            /*Non-mandatory fields below:*/ DateTime? OpenHouseDate, DateTime? ConstructionYear,
            int FinnCode = 0, int ContractNr = 0, float P_rom = 0, float Boa = 0, float Bta = 0,
            float Bra = 0, int Costs = 0, int PurchaseCosts = 0, int CommonCosts = 0, int AmountSharedDebt = 0,
            int CommonExpenses = 0, int PropertyArea = 0, string PropertyType = "",
            int Floor = 0, int Bedrooms = 0, int Rooms = 0, string OpenHouseText = "",
            string RealEstAgentName = "", string RealEstAgentTitle = "", int RealEstAgentMobile = 0, int RealEstAgentPhone = 0,
            string RealEstAgentEmail = "", string AdText = "")
        {
            
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
                    var filePath = System.Web.HttpContext.Current.Server.MapPath(folder + postedFile.FileName);

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

        








    }
}

