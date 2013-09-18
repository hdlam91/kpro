using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Webassistenten_ads.Models
{
    public class RealEstateAdInfo : AdInfo
    {
        private int RealtorId { get; set; } //This should possibly be a class/connected to one, since the ID is connected to where to save the ad.

        private int ProductId { get; set; } //Same as RealtorId

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

        private int FinnCode { get; set; }


    }
}