using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace UCRMTS.dll.DTOS
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class AdditionalStatementNote
    {
        [JsonProperty("subject")]
        public Subject Subject { get; set; }

        [JsonProperty("content")]
        public List<ContentType> Content { get; set; }
    }

    public class AffixedLogisticsSeal
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("conditionCode")]
        public List<ConditionCode> ConditionCode { get; set; }

        [JsonProperty("sealingPartyRoleCode")]
        public SealingPartyRoleCode SealingPartyRoleCode { get; set; }
    }

    public class Carrier
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }
    }

    public class CharacteristicCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class CityName
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ConditionCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Consignee
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }

        [JsonProperty("postalTradeAddress")]
        public PostalTradeAddress PostalTradeAddress { get; set; }
    }

    public class ConsignmentItemQuantity
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ContentType
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class CountryId
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Declarant
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }

        [JsonProperty("postalTradeAddress")]
        public PostalTradeAddress PostalTradeAddress { get; set; }

        [JsonProperty("definedTradeContact")]
        public List<DefinedTradeContact> DefinedTradeContact { get; set; }
    }

    public class DefinedTradeContact
    {
        [JsonProperty("personName")]
        public List<PersonName> PersonName { get; set; }
    }

    public class ExchangedDeclaration
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("declarant")]
        public Declarant Declarant { get; set; }

        [JsonProperty("submissionLogisticsLocation")]
        public SubmissionLogisticsLocation SubmissionLogisticsLocation { get; set; }

        [JsonProperty("additionalStatementNote")]
        public List<AdditionalStatementNote> AdditionalStatementNote { get; set; }

        [JsonProperty("typeCode")]
        public TypeCode TypeCode { get; set; }
    }

    public class ExchangedDocument
    {
        [JsonProperty("issueDateTime")]
        public DateTime IssueDateTime { get; set; }

        [JsonProperty("issuer")]
        public Issuer Issuer { get; set; }

        [JsonProperty("roleCode")]
        public List<RoleCode> RoleCode { get; set; }
    }

    public class RoleCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class ExportTradeCountry
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }
    }

    public class GrossWeight
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("unitCode")]
        public string UnitCode { get; set; }
    }

    public class Id
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class IncludedConsignmentItem
    {
        [JsonProperty("sequenceNumeric")]
        public SequenceNumeric SequenceNumeric { get; set; }

        [JsonProperty("typeCode")]
        public TypeCode TypeCode { get; set; }

        [JsonProperty("grossWeight")]
        public List<GrossWeight> GrossWeight { get; set; }

        [JsonProperty("netWeight")]
        public List<NetWeight> NetWeight { get; set; }

        [JsonProperty("natureIdCargo")]
        public List<NatureIdCargo> NatureIdCargo { get; set; }

        [JsonProperty("physicalLogisticsShippingMarks")]
        public List<PhysicalLogisticsShippingMark> PhysicalLogisticsShippingMarks { get; set; }
    }

    public class PhysicalLogisticsShippingMark
    {
        [JsonProperty("marking")]
        public List<Marking> Marking { get; set; }
    }

    public class Marking
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Issuer
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }
    }

    public class LoadingEvent
    {
        [JsonProperty("scheduledOccurrenceDateTime")]
        public DateTime ScheduledOccurrenceDateTime { get; set; }

        [JsonProperty("occurrenceLogisticsLocation")]
        public OccurrenceLogisticsLocation OccurrenceLogisticsLocation { get; set; }
    }

    public class Name
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class NatureIdCargo
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class NetWeight
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("unitCode")]
        public string UnitCode { get; set; }
    }

    public class OccurrenceLogisticsLocation
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }
    }

    public class OperationalStatusCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class PersonName
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class PostalTradeAddress
    {
        [JsonProperty("streetName")]
        public List<StreetName> StreetName { get; set; }

        [JsonProperty("cityName")]
        public List<CityName> CityName { get; set; }

        [JsonProperty("countryId")]
        public CountryId CountryId { get; set; }
    }

    public class RegistrationTradeCountry
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }
    }

    public class ExchangeDataPiplineDTO
    {
        [JsonProperty("exchangedDocument")]
        public ExchangedDocument ExchangedDocument { get; set; }

        [JsonProperty("exchangedDeclaration")]
        public ExchangedDeclaration ExchangedDeclaration { get; set; }

        [JsonProperty("specifiedConsignment")]
        public List<SpecifiedConsignment> SpecifiedConsignment { get; set; }

        [JsonProperty("specifiedLogisticsTransportMovement")]
        public List<SpecifiedLogisticsTransportMovement> SpecifiedLogisticsTransportMovement { get; set; }
    }

    public class SealingPartyRoleCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class SequenceNumeric
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class SpecifiedConsignment
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("transportContractReferencedDocument")]
        public TransportContractReferencedDocument TransportContractReferencedDocument { get; set; }

        [JsonProperty("grossWeight")]
        public List<GrossWeight> GrossWeight { get; set; }

        [JsonProperty("netWeight")]
        public List<NetWeight> NetWeight { get; set; }

        [JsonProperty("consignmentItemQuantity")]
        public ConsignmentItemQuantity ConsignmentItemQuantity { get; set; }

        [JsonProperty("includedConsignmentItem")]
        public List<IncludedConsignmentItem> IncludedConsignmentItem { get; set; }

        [JsonProperty("utilizedLogisticsTransportEquipment")]
        public List<UtilizedLogisticsTransportEquipment> UtilizedLogisticsTransportEquipment { get; set; }

        [JsonProperty("consignee")]
        public Consignee Consignee { get; set; }

        [JsonProperty("carrier")]
        public Carrier Carrier { get; set; }

        [JsonProperty("exportTradeCountry")]
        public ExportTradeCountry ExportTradeCountry { get; set; }

        [JsonProperty("finalDestinationTradeCountry")]
        public FinalDestinationTradeCountry FinalDestinationTradeCountry { get; set; }
    }

    public class FinalDestinationTradeCountry
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }
    }

    public class SpecifiedLogisticsTransportMovement
    {
        [JsonProperty("loadingEvent")]
        public LoadingEvent LoadingEvent { get; set; }

        [JsonProperty("unloadingEvent")]
        public UnloadingEvent UnloadingEvent { get; set; }

        [JsonProperty("usedLogisticsTransportMeans")]
        public UsedLogisticsTransportMeans UsedLogisticsTransportMeans { get; set; }
    }

    public class StreetName
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class Subject
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class SubmissionLogisticsLocation
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public List<Name> Name { get; set; }
    }

    public class TareWeight
    {
        [JsonProperty("content")]
        public string Content { get; set; }

        [JsonProperty("unitCode")]
        public string UnitCode { get; set; }
    }

    public class TransportContractReferencedDocument
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }
    }

    public class TypeCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class UnloadingEvent
    {
        [JsonProperty("scheduledOccurrenceDateTime")]
        public DateTime ScheduledOccurrenceDateTime { get; set; }

        [JsonProperty("occurrenceLogisticsLocation")]
        public OccurrenceLogisticsLocation OccurrenceLogisticsLocation { get; set; }
    }

    public class UsedCapacityCode
    {
        [JsonProperty("content")]
        public string Content { get; set; }
    }

    public class UsedLogisticsTransportMeans
    {
        [JsonProperty("id")]
        public List<Id> Id { get; set; }

        [JsonProperty("name")]
        public Name Name { get; set; }

        [JsonProperty("registrationTradeCountry")]
        public RegistrationTradeCountry RegistrationTradeCountry { get; set; }
    }

    public class UtilizedLogisticsTransportEquipment
    {
        [JsonProperty("id")]
        public Id Id { get; set; }

        [JsonProperty("grossWeight")]
        public GrossWeight GrossWeight { get; set; }

        [JsonProperty("tareWeight")]
        public TareWeight TareWeight { get; set; }

        [JsonProperty("characteristicCode")]
        public CharacteristicCode CharacteristicCode { get; set; }

        [JsonProperty("usedCapacityCode")]
        public UsedCapacityCode UsedCapacityCode { get; set; }

        [JsonProperty("operationalStatusCode")]
        public OperationalStatusCode OperationalStatusCode { get; set; }

        [JsonProperty("affixedLogisticsSeal")]
        public List<AffixedLogisticsSeal> AffixedLogisticsSeal { get; set; }
    }
}
