using System;
using System.Collections.Generic;
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
            
             int ProductId=int.Parse(System.Web.HttpContext.Current.Request.Params["ProductId"]);
             string ResponsibleRealtor=System.Web.HttpContext.Current.Request.Params["ResponsibleRealtor"];
             string Area=System.Web.HttpContext.Current.Request.Params["Area"];
             int Type=int.Parse(System.Web.HttpContext.Current.Request.Params["Type"]);
             int Price=int.Parse(System.Web.HttpContext.Current.Request.Params["Price"]);
             string Location=System.Web.HttpContext.Current.Request.Params["Location"];
             string Headline=System.Web.HttpContext.Current.Request.Params["Headline"];
             string Address=System.Web.HttpContext.Current.Request.Params["Address"];
             int ZipCode=int.Parse(System.Web.HttpContext.Current.Request.Params["ZipCode"]);
             string ZipArea=System.Web.HttpContext.Current.Request.Params["ZipArea"];
             string bookingDate = System.Web.HttpContext.Current.Request.Params["BookingDate"];
             //DateTime BookingDate = DateTime.ParseExact(System.Web.HttpContext.Current.Request.Params["BookingDate"], "dd/MM/yyyy", null);
             /*Non-mandatoryfieldsbelow:*/;
             DateTime? OpenHouseDate = DateTime.Parse(System.Web.HttpContext.Current.Request.Params["OpenHouseDate"]);
             DateTime? ConstructionYear = DateTime.Parse(System.Web.HttpContext.Current.Request.Params["ConstructionYear"]);
             int? FinnCode =int.Parse(System.Web.HttpContext.Current.Request.Params["FinnCode"]);
             int? ContractNr =int.Parse(System.Web.HttpContext.Current.Request.Params["ContractNr"]);
             float? P_rom =float.Parse(System.Web.HttpContext.Current.Request.Params["P_rom"]);
             float? Boa =float.Parse(System.Web.HttpContext.Current.Request.Params["Boa"]);
             float? Bta =float.Parse(System.Web.HttpContext.Current.Request.Params["Bta"]);
             float? Bra =float.Parse(System.Web.HttpContext.Current.Request.Params["Bra"]);
             int? Costs =int.Parse(System.Web.HttpContext.Current.Request.Params["Costs"]);
             int? PurchaseCosts=int.Parse(System.Web.HttpContext.Current.Request.Params["PurchaseCosts"]);
             int? CommonCosts=int.Parse(System.Web.HttpContext.Current.Request.Params["CommonCosts"]);
             int? AmountSharedDebt=int.Parse(System.Web.HttpContext.Current.Request.Params["AmountSharedDebt"]);
             int? CommonExpenses=int.Parse(System.Web.HttpContext.Current.Request.Params["CommonExpenses"]);
             int? PropertyArea=int.Parse(System.Web.HttpContext.Current.Request.Params["PropertyArea"]);
             string PropertyType=System.Web.HttpContext.Current.Request.Params["PropertyType"];
             int? Floor =int.Parse(System.Web.HttpContext.Current.Request.Params["Floor"]);
             int? Bedrooms =int.Parse(System.Web.HttpContext.Current.Request.Params["Bedrooms"]);
             int? Rooms =int.Parse(System.Web.HttpContext.Current.Request.Params["Rooms"]);
             string OpenHouseText=System.Web.HttpContext.Current.Request.Params["OpenHouseText"];
             string RealEstAgentName=System.Web.HttpContext.Current.Request.Params["RealEstAgentName"];
             string RealEstAgentTitle=System.Web.HttpContext.Current.Request.Params["RealEstAgentTitle"];
             int? RealEstAgentMobile=int.Parse(System.Web.HttpContext.Current.Request.Params["RealEstAgentMobile"]);
             int? RealEstAgentPhone = int.Parse(System.Web.HttpContext.Current.Request.Params["RealEstAgentPhone"]);
             string RealEstAgentEmail=System.Web.HttpContext.Current.Request.Params["RealEstAgentEmail"];
             string AdText=System.Web.HttpContext.Current.Request.Params["AdText"];
 


            System.Diagnostics.Debug.WriteLine(bookingDate);

            HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;
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

        [HttpGet]
        public HttpResponseMessage GetUpload(int ProductId, string ResponsibleRealtor, string Area, int Type,
            int Price, string Location, string Headline, string Address, int ZipCode,
            string ZipArea, DateTime BookingDate,
            /*Non-mandatory fields below:*/ DateTime? OpenHouseDate, DateTime? ConstructionYear,
            int? FinnCode = 0, int? ContractNr = 0, float? P_rom = 0, float? Boa = 0, float? Bta = 0,
            float? Bra = 0, int? Costs = 0, int? PurchaseCosts = 0, int? CommonCosts = 0, int? AmountSharedDebt = 0,
            int? CommonExpenses = 0, int? PropertyArea = 0, string PropertyType = "",
            int? Floor = 0, int? Bedrooms = 0, int? Rooms = 0, string OpenHouseText = "",
            string RealEstAgentName = "", string RealEstAgentTitle = "", int? RealEstAgentMobile = 0, int? RealEstAgentPhone = 0,
            string RealEstAgentEmail = "", string AdText = "")
        {
            System.Diagnostics.Debug.WriteLine(ProductId + "," + Address);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
