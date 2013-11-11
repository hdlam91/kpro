using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads_api.Models
{
	[Serializable]
    public class RealEstateAdInfo
    {
        public RealEstateAdInfo()
        {

        }

		/// <summary>
		/// Initializes a new instance of the <see cref="Webassistenten_ads_api.Models.RealEstateAdInfo"/> class.
		/// This class contains the data for submission of Real Estate Ads, both mandatory and optional.
		/// </summary>
		/// <param name="realtorId">Realtor identifier. Mandatory</param>
		/// <param name="prodId">Prod identifier.Mandatory</param>
		/// <param name="responsibleRealtor">Responsible realtor. Mandatory</param>
		/// <param name="type">Type. Mandatory</param>
		/// <param name="price">Price. Mandatory</param>
		/// <param name="zipCode">Zip code. Mandatory</param>
		/// <param name="zipArea">Zip area. Mandatory</param>
		/// <param name="location">Location. Mandatory</param>
		/// <param name="headLine">Head line. Mandatory</param>
		/// <param name="adress">Adress. Mandatory</param>
		/// <param name="bookingDate">Booking date. Mandatory</param>
		/// <param name="finnCode">Finn code. </param>
		/// <param name="contractNr">Contract nr.</param>
		/// <param name="prom">Prom.</param>
		/// <param name="boa">Boa.</param>
		/// <param name="bta">Bta.</param>
		/// <param name="bra">Bra.</param>
		/// <param name="cost">Cost.</param>
		/// <param name="purchaseCost">Purchase cost.</param>
		/// <param name="commonCost">Common cost.</param>
		/// <param name="amountSharedDebt">Amount shared debt.</param>
		/// <param name="commonExpenses">Common expenses.</param>
		/// <param name="propertyArea">Property area.</param>
		/// <param name="floor">Floor.</param>
		/// <param name="bedrooms">Bedrooms.</param>
		/// <param name="rooms">Rooms.</param>
		/// <param name="realEstAgentMobile">Real estate agent mobile.</param>
		/// <param name="realEstAgentPhone">Real estate agent phone.</param>
		public RealEstateAdInfo(int realtorId, int prodId, string responsibleRealtor, int type, int price, int zipCode, 
		                        string zipArea, string location, string headLine, string adress,// DateTime bookingDate,
		                        //Mandatories end, optionals start
		                        int? finnCode = null, int? contractNr = null, float? prom = null, float? boa = null, float? bta = null, float? bra = null,
		                        int? cost = null, int? purchaseCost = null, int? commonCost = null, int? amountSharedDebt  = null, int? commonExpenses = null,
		                        int? propertyArea = null, int? floor = null, int? bedrooms = null, int? rooms = null, int? realEstAgentMobile = null, int? realEstAgentPhone = null
            )
        {
			RealtorId = realtorId;
            ProductId = prodId;
			ResponsibleRealtor = responsibleRealtor;
            Type = type;
            Price = price;
            ZipCode = zipCode;
            ZipArea = zipArea;
            Location = location;
            Headline = headLine;
			Adress = adress;
            FinnCode = finnCode;
            ContractNr = contractNr;
            PRom = (float)prom;
            Boa = (float)boa;
            Bta = (float)bta;
            Bra = (float)bra;
            Costs = cost;
            PurchaseCosts = purchaseCost;
            CommonCosts = commonCost;
            AmountSharedDebt = amountSharedDebt;
            CommonExpenses = commonExpenses;
            PropertyArea = propertyArea;
            Floor = floor;
            Bedrooms = bedrooms;
            Rooms = rooms;
            RealEstAgentMobile = realEstAgentMobile;
            RealEstAgentPhone = realEstAgentPhone;
            
        }

        // Mandatory fields:

        public int RealtorId {get;  set; }

        public int ProductId { get;  set; }

        public String ResponsibleRealtor { get;  set; }

        public string Area { get;  set; }

        public int Type { get;  set; }

        public int Price { get;  set; }

        public string Location { get;  set; }

        public string Headline { get;  set; }

        public string Adress { get;  set; }

        public int ZipCode { get;  set; }

        public string ZipArea { get;  set; }

        public DateTime BookingDate { get;  set; }

        // Non-mandatory fields below:

        public int? FinnCode { get;  set; }

        public int? ContractNr { get;  set;}

        public float? PRom { get;  set; }	// TODO: Translate acronyms to English 

        public float? Boa { get;  set; }

        public float? Bta { get;  set; }

        public float? Bra { get;  set; }

        public int? Costs { get;  set; }

        public int? PurchaseCosts { get;  set; }

        public int? CommonCosts { get;  set; }

        public int? AmountSharedDebt { get;  set; }

        public int? CommonExpenses { get;  set; }

        public int? PropertyArea { get;  set; }

        public int? PropertyType { get;  set; }

        public DateTime? ConstructionYear { get;  set; }

        public int? Floor { get;  set; }

        public int? Bedrooms { get;  set; }

        public int? Rooms { get;  set; }

        public DateTime? OpenHouseDate { get;  set; }	// Visningdato

        public String OpenHouseText { get;  set; }	// TODO: Consider better representation than String

        public String RealEstAgentName { get;  set; }

        public String RealEstAgentTitle { get;  set; }

        public int? RealEstAgentMobile { get;  set; }

        public int? RealEstAgentPhone { get;  set; }

        public String RealEstAgentEmail { get;  set; }

        public String AdText { get;  set; }	// Is this the best representation for the text?



        

    }
}