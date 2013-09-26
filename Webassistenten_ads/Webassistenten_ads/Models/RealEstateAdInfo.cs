using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads.Models
{
    public class RealEstateAdInfo : AdInfo
    {
		// Mandatory fields:

        private int RealtorId { get; set; } // This should possibly be a class/connected to one, since the ID is connected to where to save the ad.

        private int ProductId { get; set; } // Same as RealtorId

        private Realtor ResponsibleRealtor { get; set; }

        private string Area { get; set; } // Should Area be a class?

        private int Type { get; set; } // Should this be a class? Don't know the data type of this

        private int Price { get; set; }

        private string Location { get; set; } // Should Location be a class?

        private string Headline { get; set; }

        private Address Address { get; set; }

        private int ZipCode { get; set; }

        private string ZipArea { get; set; }

        private DateTime BookingDate { get; set; }

        private int FinnCode { get; set; }	// Move to AdInfo?

		// Non-mandatory fields below:

		private int ContractNr { get; set;}

		private float P_rom { get; set; }

		private float Boa { get; set; }

		private float Bta { get; set; }

		private float Bra { get; set; }

		private int Costs { get; set; }

		private int PurchaseCosts { get; set; }

		private int CommonCosts { get; set; }

		private int AmountSharedDebt { get; set; }

		private int CommonExpenses { get; set; }

		private int PropertyArea { get; set; }

		private PropertyType PropertyType { get; set; }

		private DateTime ConstructionYear { get; set; }

		private int Floor { get; set; }

		private int Bedrooms { get; set; }

		private int Rooms { get; set; }

		private DateTime OpenHouseDate { get; set; }	// Visningdato

		private String OpenHouseText { get; set; }	// TODO: Consider better representation than String

		private String RealEstAgentName { get; set; }

		private String RealEstAgentTitle { get; set; }

		private int RealEstAgentMobile { get; set; }

		private int RealEstAgentPhone { get; set; }

		private System.Net.Mail.MailAddress RealEstAgentEmail { get; set; }

		private String AdText { get; set; }	// Is this the best representation for the text?
    }
}