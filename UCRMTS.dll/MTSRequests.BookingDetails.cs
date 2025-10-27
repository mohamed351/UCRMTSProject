using System;
using System.Collections.Generic;

namespace UCRMTS.dll
{
    public partial class MTSRequests
    {
        public class BookingDetails
        {
            public string IssuerTax { get; set; }
            public string Type { get => "DEG"; }

            public string UCR  { get; set; }

   

            public string ShipperTaxCode { get; set; }

            public DateTime LoadingTime { get; set; }

            public string PortOfLoadingCode { get; set; }

            public string PortOfDeschargeCode { get; set; }

            public DateTime UnLoadingTime { get; set; }

            public string VesselImo { get; set; }

            public string VesselTitle { get; set; }

            public string TradingCountry { get; set; }

            public string ShippingLineID { get; set; }

            public string ShippingLineCode { get; set; }
            public List<BookingDetailsItems> Details { get; set; } = new List<BookingDetailsItems>();

            public string FinalTradingCountryCode { get; set; }

        }


    }
}
