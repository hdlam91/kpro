using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;


namespace Webassistenten_ads_api.Controllers
{
	/// <summary>
	/// Upload API controller.
	/// </summary>
    public class UploadAPIController : ApiController
    {
        public static string folder = "~/hdTest/";

		//TODO: Describe required parameters
		/// <summary>
		/// Accepts a pdf file with an ad, along with the required and optional parameters for ads.<br/>
		/// Parameters go in the HTTP-Post Request (MIME-Multipart).<br/>
		/// Could potentially accept parameters in object form in the future, but does not do that at the moment due to binding issues in Web API.<br/>
		/// </summary>
        [HttpPost]
        public HttpResponseMessage Upload([FromBody]UploadParameters up)
        {
            //initialize
            int ProductId;
            int ModuleId;
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
                ModuleId = int.Parse(System.Web.HttpContext.Current.Request.Params["ModuleId"]);
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Please fill in the required fields, one of them was empty       " + e);
            }


            ///*Non-mandatory fields below:*/;


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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "OpenHouse date needs to be in the format dd.mm.yyyy" + e);
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
                    return Request.CreateResponse(HttpStatusCode.BadRequest, "OpenHouse date needs to be in the format yyyy" + e);
                }
            }

            string FinnCode =System.Web.HttpContext.Current.Request.Params["FinnCode"];
            string ContractNr = System.Web.HttpContext.Current.Request.Params["ContractNr"];
            long P_rom;
            long.TryParse(System.Web.HttpContext.Current.Request.Params["P_rom"], out P_rom);
            long Boa;
            long.TryParse(System.Web.HttpContext.Current.Request.Params["Boa"], out Boa);
            long Bta;
            long.TryParse(System.Web.HttpContext.Current.Request.Params["Bta"], out Bta);
            long Bra;
            long.TryParse(System.Web.HttpContext.Current.Request.Params["Bra"], out Bra);
            int Costs;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["Costs"], out Costs);
            int PurchaseCosts;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["PurchaseCosts"], out PurchaseCosts);
            int CommonCosts;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["CommonCosts"], out CommonCosts);
            int AmountSharedDebt;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["AmountSharedDebt"], out AmountSharedDebt);
            int CommonExpenses;
            int.TryParse(System.Web.HttpContext.Current.Request.Params["CommonExpenses"], out CommonExpenses);
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
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Email is not valid.");
            }

            string AdText = System.Web.HttpContext.Current.Request.Params["AdText"];
            
            
            
            

            //System.Diagnostics.Debug.Write("something"+up.Adress);
            HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;
            if (!Request.Content.IsMimeMultipartContent("form-data"))
            {
                result = Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "Something went wrong, mediatype not supported");
            }
            else
            {
                if (httpRequest.Files.Count == 1)
                {
                    var docfiles = new List<string>();
                    string file = httpRequest.Files[0].ToString();
                    var postedFile = httpRequest.Files[0];
                    var filePath = System.Web.HttpContext.Current.Server.MapPath(folder + postedFile.FileName);

                    

                    FileInfo fileInfo = new FileInfo(filePath);

                    if (fileInfo.Extension != ".pdf")
                    {
                        result = Request.CreateResponse(HttpStatusCode.BadRequest, "Only .pdf files are accepted!");
                    }
                    else
                    {
                        postedFile.SaveAs(filePath);
                        docfiles.Add(filePath);

                        //Db submission logic
                        using (BoligEntities1 db = new BoligEntities1()) {
                        	
							Prospekt p = new Prospekt();
                        	ProspektHarBestilling phb = new ProspektHarBestilling();
							                        
                        	p.Omraade = Location;
                        	p.Postnr = ZipCode.ToString();
                        	p.Poststed = ZipArea;
                        	p.BBOverskrift = Headline;
                        	p.Pris = Price;
                        	p.Adresse = Address;
                        	p.DatoReg = DateTime.Now;
                        	//p.Tomteareal = Area;
                        	//p.Tomtetype = Type;

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
	                        p.Fellesutgifter = CommonExpenses;//WHAAAT?
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
	                        phb.Filnavn = filePath;
	                        phb.ProduktID = (byte)ProductId;

	                        phb.ModulID = ModuleId;
	                        db.ProspektHarBestillings.Add(phb);
                        	db.SaveChanges();
                        	//End of db logic
                        	result = Request.CreateResponse(HttpStatusCode.Created, "Upload was successful!");
						}
                    }
                }
                else
                {
                    result = Request.CreateResponse(HttpStatusCode.BadRequest, "No file could be found!");
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
   	
	/// <summary>
	/// This class contains all the parameters needed for the Upload method.
	/// It's to be used as input for that method if the method can be 
	/// properly configured to accept a class as parameter WITH values intact.
	/// </summary>
	[DataContract]
	[Serializable]
	public class UploadParameters
	{
		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Product ID is required.")]
		public int ProductId { get;  set; }

		[DataMember(IsRequired=true)]
        [Required(ErrorMessage = "Module ID is required.")]
		public int ModuleId { get;  set; } 

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Realtor ID is required.")]
		public int RealtorId {get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Responsible Realtor is required.")]
		public string ResponsibleRealtor { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Area is required.")]
		public string Area { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Type is required.")]
		public int Type { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Price is required.")]
		public int Price { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Location is required.")]
		public string Location { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Headline is required.")]
		public string Headline { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Address is required.")]
		public string Address { get;  set; }

		[DataMember]
		[Required(ErrorMessage = "ZipCode is required.")]
		public int ZipCode { get;  set; }

		[DataMember]
		[Required(ErrorMessage = "ZipArea is required.")]
		public string ZipArea { get;  set; }

		[DataMember]
		[Required(ErrorMessage = "Booking Date is required.")]
		public DateTime BookingDate { get;  set; }
		
		// Non-mandatory fields below:

		[DataMember]
		public int FinnCode { get;  set; }

		[DataMember]
		public int ContractNr { get;  set; }

		[DataMember]
		public float P_Rom { get;  set; }

		[DataMember]
		public float Boa { get;  set; }

		[DataMember]
		public float Bta { get;  set; }

		[DataMember]
		public float Bra { get;  set; }

		[DataMember]
		public int Costs { get;  set; }

		[DataMember]
		public int PurchaseCosts { get;  set; }

		[DataMember]
		public int CommonCosts { get;  set; }

		[DataMember]
		public int AmountSharedDebt { get;  set; }

		[DataMember]
		public int CommonExpenses { get;  set; }

		[DataMember]
		public int PropertyArea { get;  set; }

		[DataMember]
		public int PropertyType { get;  set; }

		[DataMember]
		public DateTime ConstructionYear { get;  set; }

		[DataMember]
		public int Floor { get;  set; }

		[DataMember]
		public int Bedrooms { get;  set; }

		[DataMember]
		public int Rooms { get;  set; }

		[DataMember]
		public DateTime OpenHouseDate { get;  set; }	// Visningdato

		[DataMember]
		public String OpenHouseText { get;  set; }

		[DataMember]
		public String RealEstAgentName { get;  set; }

		[DataMember]
		public String RealEstAgentTitle { get;  set; }

		[DataMember]
		public int RealEstAgentMobile { get;  set; }

		[DataMember]
		public int RealEstAgentPhone { get;  set; }

		[DataMember]
		public String RealEstAgentEmail { get;  set; }

		[DataMember]
		public String AdText { get;  set; }
	}
}
