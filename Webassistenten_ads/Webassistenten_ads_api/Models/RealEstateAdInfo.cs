using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads_api.Models
{
	[Serializable]
    public class RealEstateAdInfo : AdInfo
    {

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
		                        string zipArea, string location, string headLine, string adress, DateTime bookingDate,
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

        public int RealtorId {get; private set; }

        public int ProductId { get; private set; }

        public String ResponsibleRealtor { get; private set; }

        public string Area { get; private set; }

        public int Type { get; private set; }

        public int Price { get; private set; }

        public string Location { get; private set; }

        public string Headline { get; private set; }

        public string Adress { get; private set; }

        public int ZipCode { get; private set; }

        public string ZipArea { get; private set; }

        public DateTime BookingDate { get; private set; }

        // Non-mandatory fields below:

        public int? FinnCode { get; private set; }

        public int? ContractNr { get; private set;}

        public float? PRom { get; private set; }	// TODO: Translate acronyms to English 

        public float? Boa { get; private set; }

        public float? Bta { get; private set; }

        public float? Bra { get; private set; }

        public int? Costs { get; private set; }

        public int? PurchaseCosts { get; private set; }

        public int? CommonCosts { get; private set; }

        public int? AmountSharedDebt { get; private set; }

        public int? CommonExpenses { get; private set; }

        public int? PropertyArea { get; private set; }

        public int? PropertyType { get; private set; }

        public DateTime? ConstructionYear { get; private set; }

        public int? Floor { get; private set; }

        public int? Bedrooms { get; private set; }

        public int? Rooms { get; private set; }

        public DateTime? OpenHouseDate { get; private set; }	// Visningdato

        public String OpenHouseText { get; private set; }	// TODO: Consider better representation than String

        public String RealEstAgentName { get; private set; }

        public String RealEstAgentTitle { get; private set; }

        public int? RealEstAgentMobile { get; private set; }

        public int? RealEstAgentPhone { get; private set; }

        public String RealEstAgentEmail { get; private set; }

        public String AdText { get; private set; }	// Is this the best representation for the text?



        

    }
}