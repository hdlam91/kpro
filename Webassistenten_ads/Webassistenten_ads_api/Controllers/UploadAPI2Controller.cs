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
    public class UploadAPI2Controller : ApiController
    {
        public static string folder = "~/hdTest/";

		/// <summary>
		/// Accepts a pdf file with an ad, along with the required and optional parameters for ads in an UploadParameters object.
		/// </summary>
		/// <returns>An HttpResponseMessage with a status code, and message.</returns>
        [HttpPost]
        public HttpResponseMessage Upload([FromBody]UploadParameters up)
        {

#if DEBUG
			System.Diagnostics.Debug.Print("ProductID: " + up.ProductId + "\n");
			System.Diagnostics.Debug.Print("ModuleID: " + up.ModuleId + "\n");
			System.Diagnostics.Debug.Print("ResponsibleRealtor: " + up.ResponsibleRealtor + "\n");
			System.Diagnostics.Debug.Print("Area: " + up.Area + "\n");
			System.Diagnostics.Debug.Print("Type: " + up.Type + "\n");
			System.Diagnostics.Debug.Print("Price: " + up.Price + "\n");
			System.Diagnostics.Debug.Print("Location: " + up.Location + "\n");
			System.Diagnostics.Debug.Print("Headline: " + up.Headline + "\n");
			System.Diagnostics.Debug.Print("Address: " + up.Address + "\n");
			System.Diagnostics.Debug.Print("ZipCode: " + up.ZipCode + "\n");
			System.Diagnostics.Debug.Print("ZipArea: " + up.ZipArea + "\n");
			System.Diagnostics.Debug.Print("BookingDate: " + up.BookingDate + "\n");
#endif

            //initialize
			int ProductId = up.ProductId;
            int ModuleId = up.ModuleId;
			string ResponsibleRealtor = up.ResponsibleRealtor;
            string Area = up.Area;
            int Type = up.Type;
            int Price = up.Price;
            string Location = up.Location;
            string Headline = up.Headline;
            string Address = up.Address;
            int ZipCode = up.ZipCode;
            string ZipArea = up.ZipArea;
            DateTime BookingDate = up.BookingDate;

            ///*Non-mandatory fields below:*/;

#if DEBUG
			System.Diagnostics.Debug.Print("OpenHouseDate: " + up.OpenHouseDate + "\n");
			System.Diagnostics.Debug.Print("RealEstAgentMobile: " + up.RealEstAgentMobile + "\n");
#endif

			DateTime? OpenHouseDate;
			if (up.OpenHouseDate != default(System.DateTime)) 
			{
				OpenHouseDate = (up.OpenHouseDate);
			}

			DateTime? ConstructionYear;
			if (up.ConstructionYear != default(System.DateTime))
			{
				ConstructionYear = up.ConstructionYear;
			}

            string FinnCode = up.FinnCode;
			string ContractNr = up.ContractNr;
			long P_rom = up.P_Rom;
			long Boa = up.Boa;
			long Bta = up.Bta;
			long Bra = up.Bra;
			int Costs = up.Costs;
			int PurchaseCosts = up.PurchaseCosts;
			int CommonCosts = up.CommonCosts;
			int AmountSharedDebt = up.AmountSharedDebt;
			int CommonExpenses = up.CommonExpenses;
			int PropertyArea = up.PropertyArea;
			string PropertyType = up.PropertyType.ToString();
			int Floor = up.Floor;
			int Bedrooms = up.Bedrooms;
			int Rooms = up.Rooms;
			string OpenHouseText = up.OpenHouseText;
			string RealEstAgentName = up.RealEstAgentName;
			string RealEstAgentTitle = up.RealEstAgentTitle;
			int RealEstAgentMobile = up.RealEstAgentMobile;
			int RealEstAgentPhone = up.RealEstAgentPhone;

			string RealEstAgentEmail;
            if (checkMail(up.RealEstAgentEmail))
            {
                RealEstAgentEmail = up.RealEstAgentEmail;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Email is not valid.");
            }

			string AdText = up.AdText;
            
            
            
            HttpResponseMessage result = null;
            var httpRequest = System.Web.HttpContext.Current.Request;
            if (!Request.Content.IsMimeMultipartContent("UploadParameters"))
            {
                result = Request.CreateResponse(HttpStatusCode.UnsupportedMediaType, "MultipartContent must be of type UploadParameters!");
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
	/// Its purpose is input for that method.
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

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "ZipCode is required.")]
		public int ZipCode { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "ZipArea is required.")]
		public string ZipArea { get;  set; }

		[DataMember(IsRequired=true)]
		[Required(ErrorMessage = "Booking Date is required.")]
		public DateTime BookingDate { get;  set; }
		
		// Non-mandatory fields below:

		[DataMember]
		public string FinnCode { get;  set; }

		[DataMember]
		public string ContractNr { get;  set; }

		[DataMember]
		public long P_Rom { get;  set; }

		[DataMember]
		public long Boa { get;  set; }

		[DataMember]
		public long Bta { get;  set; }

		[DataMember]
		public long Bra { get;  set; }

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
		public string OpenHouseText { get;  set; }

		[DataMember]
		public string RealEstAgentName { get;  set; }

		[DataMember]
		public string RealEstAgentTitle { get;  set; }

		[DataMember]
		public int RealEstAgentMobile { get;  set; }

		[DataMember]
		public int RealEstAgentPhone { get;  set; }

		[DataMember]
		public string RealEstAgentEmail { get;  set; }

		[DataMember]
		public string AdText { get;  set; }
	}
}
