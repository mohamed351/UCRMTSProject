using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UCRMTS.dll
{
    public class EmptyContainerRequest
    {

        /// <summary>
        /// UCR That Verified in UCR
        /// </summary>
        public string UCR { get; set; }

        /// <summary>
        /// Date time of sending Empty Container
        /// </summary>
        public DateTime IssuedDatetime { get; set; }

        /// <summary>
        /// Type Code if ShipingLine or Freight forwarding
        /// </summary>
        public string TypeCode { get => "DEG"; }
        /// <summary>
        /// Tax ID for Company that make request
        /// </summary>
        public string IssuerID { get; set; }

        /// <summary>
        /// Tax ID for shipper
        /// </summary>
        public string ReciverID { get; set; }

        public string POL { get; set; }

        public string POD { get; set; }


        public DateTime POLEvent { get; set; }

        public DateTime PODEvent { get; set; }


        public string TransportContractReferencedDocument { get; set; }

        /// <summary>
        /// ShippingOrder Internal Number
        /// </summary>
        public string ShippingOrderNumber { get; set; }


        public string TradingCountryIsoCode { get; set; }


        public List<EmptyContainerDetails> ContainerDetails { get; set; } = new List<EmptyContainerDetails>();


    }

    public class EmptyContainerDetails
    {
        public string ContainerNumber { get; set; }

        public string ContainerType { get; set; }


        public string TareWeight { get; set; }

        public string TareWeightType { get; set; }

        public string GrossWeight { get; set; }

        public string GrossWeightType { get; set; }

        public string UsedCapacityCode { get; set; }

        public string OperationalStatusCode { get; set; }

        public List<ContainerSeal> ContainerSeals { get; set; } = new List<ContainerSeal>();




    }
    public class ContainerSeal
    {
        public string Serial { get; set; }

        public string ConditionCode { get; set; }

        public string RoleCode { get; set; }

    }
}
