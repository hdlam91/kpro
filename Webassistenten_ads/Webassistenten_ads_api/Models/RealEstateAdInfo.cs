using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads_api.Models
{
    public class RealEstateAdInfo : AdInfo
    {
		/// <summary>
		/// Initializes a new instance of the <see cref="Webassistenten_ads.Models.RealEstateAdInfo"/> class, with all non-nullable mumbers set to -1
		/// to mark them as not set to a proper value.
		/// </summary>
		public RealEstateAdInfo()
		{
			// Setting ints to -1 to indicate they're not set 
			RealtorId = -1;
			ProductId = -1;
			Type = -1;
			Price = -1;
			ZipCode = -1;
			FinnCode = -1;
			ContractNr = -1;
            P_rom = (float)-1.0;
            Boa = (float)-1.0;
            Bta = (float)-1.0;
			Bra = (float)-1.0;
			Costs = -1;
			PurchaseCosts = -1;
			CommonCosts = -1;
			AmountSharedDebt = -1;
			CommonExpenses = -1;
			PropertyArea = -1;
			Floor = -1;
			Bedrooms = -1;
			Rooms = -1;
			RealEstAgentMobile = -1;
			RealEstAgentPhone = -1;
		}

        public RealEstateAdInfo(int prodId, int type, int price, int zipCode, int finnCode, int cont)
        {
            ProductId = prodId;
            Type = type;
            Price = -1;
            ZipCode = -1;
            FinnCode = -1;
            ContractNr = -1;
            P_rom = (float)-1.0;
            Boa = (float)-1.0;
            Bta = (float)-1.0;
            Bra = (float)-1.0;
            Costs = -1;
            PurchaseCosts = -1;
            CommonCosts = -1;
            AmountSharedDebt = -1;
            CommonExpenses = -1;
            PropertyArea = -1;
            Floor = -1;
            Bedrooms = -1;
            Rooms = -1;
            RealEstAgentMobile = -1;
            RealEstAgentPhone = -1;
        }


		// Mandatory fields:

        public int RealtorId {get; private set; } // This should possibly be a class/connected to one, since the ID is connected to where to save the ad.

        public int ProductId { get; private set; } // Same as RealtorId

        public Realtor ResponsibleRealtor { get; private set; }

        public string Area { get; private set; } // Should Area be a class?

        public int Type { get; private set; } // Should this be a class? Don't know the data type of this

        public int Price { get; private set; }

        public string Location { get; private set; } // Should Location be a class?

        public string Headline { get; private set; }

        public Address Address { get; private set; }

        public int ZipCode { get; private set; }

        public string ZipArea { get; private set; }

        public DateTime BookingDate { get; private set; }

		// Non-mandatory fields below:

        public int FinnCode { get; private set; }	// Move to AdInfo?

		public int ContractNr { get; private set;}

		public float P_rom { get; private set; }	// TODO: Translate acronyms to English 

		public float Boa { get; private set; }

		public float Bta { get; private set; }

		public float Bra { get; private set; }

		public int Costs { get; private set; }

		public int PurchaseCosts { get; private set; }

		public int CommonCosts { get; private set; }

		public int AmountSharedDebt { get; private set; }

		public int CommonExpenses { get; private set; }

		public int PropertyArea { get; private set; }

		public PropertyType PropertyType { get; private set; }

		public DateTime ConstructionYear { get; private set; }

		public int Floor { get; private set; }

		public int Bedrooms { get; private set; }

		public int Rooms { get; private set; }

		public DateTime OpenHouseDate { get; private set; }	// Visningdato

		public String OpenHouseText { get; private set; }	// TODO: Consider better representation than String

		public String RealEstAgentName { get; private set; }

		public String RealEstAgentTitle { get; private set; }

		public int RealEstAgentMobile { get; private set; }

		public int RealEstAgentPhone { get; private set; }

		public System.Net.Mail.MailAddress RealEstAgentEmail { get; private set; }

		public String AdText { get; private set; }	// Is this the best representation for the text?



        

    }
}