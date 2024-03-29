﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Webassistenten_ads_api.Repository;

namespace Webassistenten_ads_api.Controllers
{
	/// <summary>
	/// Upload API controller, which will take an ad in pdf-form and its associated data.
	/// </summary>
    public class UploadAPIController : ApiController
    {
        public static string folder =  Constants.FOLDER;

		//TODO: Describe required parameters
		/// <summary>
		/// Accepts a pdf file with an ad, along with the required and optional parameters for ads.<br/>
		/// Parameters go in the HTTP-Post Request (MIME-Multipart form-data).<br/>
		/// Accepts the same parameters as UploadAPIController2, but this one actually works.
		/// </summary>
        [HttpPost]
        public HttpResponseMessage Upload(/*[FromBody]UploadParameters up*/)
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
            int PartnerId;
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
                PartnerId = int.Parse(System.Web.HttpContext.Current.Request.Params["PartnerId"]);
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

                            p.PartnerID = (byte)PartnerId;
                            p.StatusID = 0;
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
   	
	
	
}
