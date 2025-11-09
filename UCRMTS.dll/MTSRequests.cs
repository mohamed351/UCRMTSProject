using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using UCRMTS.dll.DTOS;
using static UCRMTS.dll.MTSRequests;
using static UCRMTS.dll.Scops;

namespace UCRMTS.dll
{
    public partial class MTSRequests
    {

        public static async Task<ExchangeDataPiplineDTO> UCRVerification(string ucr, string shipperId)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.UCRVerifiy);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/{ucr}";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("shipperId", shipperId);
               var response =  await http.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                  return   JsonConvert.DeserializeObject<ExchangeDataPiplineDTO>(result);
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new UCRException(result,response.StatusCode);
                }
             

            }



        }
       
        public  static async Task<ExchangeDataPiplineDTO> ConfirmOrCancelBooking(BookingDetails details , BookingStatus bookingStatus)
        {

     

            var currentObject = new ExchangeDataPiplineDTO()
            {
                ExchangedDocument = new ExchangedDocument()
                {
                    IssueDateTime = DateTime.Now,
                    Issuer = new Issuer()
                    {
                        Id = new List<Id>() { new Id() { Content = details.IssuerTax } }
                    },
                    RoleCode = new List<RoleCode>()
                      {
                          new RoleCode() {Content = details.Type}
                      }

                },
                ExchangedDeclaration = new ExchangedDeclaration()
                {
                    Id = new List<Id>()
                    {
                         new Id(){ Content = details.UCR}
                      },
                    TypeCode = new DTOS.TypeCode()
                    {
                        Content =  ((int)bookingStatus).ToString(),

                    },
                    Declarant = new Declarant()
                    {
                        Id = new List<Id>()
                     {
                         new Id(){ Content =details.ShipperTaxCode},
                     }
                    }


                },
                SpecifiedLogisticsTransportMovement = new List<SpecifiedLogisticsTransportMovement>()
               {
                   new SpecifiedLogisticsTransportMovement()
                   {
                       LoadingEvent = new LoadingEvent()
                       {
                           ScheduledOccurrenceDateTime = details.LoadingTime,
                           OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                           {
                               Id= new List<Id>()
                               {
                                  new Id() { Content = details.PortOfLoadingCode}
                               }
                           },

                       },
                       UnloadingEvent = new UnloadingEvent()
                       {
                             ScheduledOccurrenceDateTime =details.LoadingTime,
                           OccurrenceLogisticsLocation= new OccurrenceLogisticsLocation()
                           {
                               Id= new List<Id>()
                               {
                                   new Id(){Content = details.PortOfDeschargeCode}
                               }
                           }
                       },
                      UsedLogisticsTransportMeans = new UsedLogisticsTransportMeans()
                      {
                          Id = new List<Id>()
                          {
                              new Id(){ Content = details.VesselImo}
                          },
                          Name = new Name()
                          {
                              Content =details.VesselTitle,
                          },
                          RegistrationTradeCountry = new RegistrationTradeCountry()
                          {
                              Id= new List<Id>(){
                                  new Id() {Content = details.TradingCountry}
                              }
                          }

                      },





                   }
               },
                SpecifiedConsignment = new List<SpecifiedConsignment>()
               {
                   new SpecifiedConsignment()
                   {
                       Id= new List<Id>()
                       {
                          new Id(){Content = details.UCR}
                       },
                       Carrier = new Carrier()
                       {
                           Id = new List<Id>()
                           {
                                new Id() {Content = details.ShippingLineID}
                           },
                           Name = new List<Name>()
                           {
                               new Name() {Content = details.ShippingLineCode}
                           }
                       },
                       ConsignmentItemQuantity = new ConsignmentItemQuantity()
                       {
                           Content = details.Details.Sum(a=> a.NoOfPackages).ToString()
                       },
                       GrossWeight =    details.Details.Select(a=> new GrossWeight() {Content = a.GrossWieght.ToString() , UnitCode =a.MeasurmentID}).ToList(),
                       IncludedConsignmentItem = details.Details.Select((line,index) => new IncludedConsignmentItem()
                       {
                           SequenceNumeric = new SequenceNumeric()
                           {
                               Content   =(index+1) .ToString()
                           },
                           NatureIdCargo = new List<NatureIdCargo>()
                           {
                               new NatureIdCargo() {Content=line.CargoDescription}
                           },
                           PhysicalLogisticsShippingMarks = new List<PhysicalLogisticsShippingMark>()
                           {
                               new PhysicalLogisticsShippingMark()
                               {
                                   Marking =new List<Marking>()
                                   {
                                       new Marking()
                                       {
                                           Content = $"{line.Nos} X {line.ContainerType} "
                                       }
                                   }
                               }
                           },



                       }).ToList(),

                      FinalDestinationTradeCountry =  new FinalDestinationTradeCountry() { Id = new List<Id>(){ new Id() { Content = details.FinalTradingCountryCode } }

,


                   },


               },




}
            };
            if( await AddingConsignments(currentObject)){
                return currentObject;
            }
            else
            {
                return null;
            }

        }
        public static async Task<bool> AddingEmptyContainer(EmptyContainerRequest details)
        {
            var currentObject = new ExchangeDataPiplineDTO()
            {
                ExchangedDocument = new ExchangedDocument()
                {
                    IssueDateTime = DateTime.Now,
                    Issuer = new Issuer()
                    {
                        Id = new List<Id>() { new Id() { Content = details.IssuerID } }
                    },
                    RoleCode = new List<RoleCode>()
                      {
                          new RoleCode() {Content = details.TypeCode}
                      }

                },
                ExchangedDeclaration = new ExchangedDeclaration()
                {
                    Id = new List<Id>()
                    {
                         new Id(){ Content = details.UCR}
                      },
                    TypeCode = new DTOS.TypeCode()
                    {
                        Content = "13"

                    },
                    Declarant = new Declarant()
                    {
                        Id = new List<Id>()
                     {
                         new Id(){ Content =details.ReciverID},
                     }
                    }


                },
                SpecifiedLogisticsTransportMovement = new List<SpecifiedLogisticsTransportMovement>()
                {
                    
                    new SpecifiedLogisticsTransportMovement()
                    {
                        LoadingEvent = new LoadingEvent()
                        {
                             OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                             {
                                 Id = new List<Id>()
                                 {
                                       new Id() { Content = details.POL}
                                 },
                                 Name = new List<Name>()
                                 {
                                     new Name() {Content =details.POL}
                                 }
                             },
                                ScheduledOccurrenceDateTime= details.POLEvent
                        } ,
                        UnloadingEvent = new UnloadingEvent()
                        {
                             OccurrenceLogisticsLocation = new OccurrenceLogisticsLocation()
                             {
                                 Id = new List<Id>()
                                 {
                                     new Id() {Content = details.POD}
                                 },
                                 Name =new List<Name>()
                                 {
                                     new Name() {Content =details.POD}
                                 }
                             },
                             ScheduledOccurrenceDateTime= details.POLEvent
                        },
                        UsedLogisticsTransportMeans = new UsedLogisticsTransportMeans()
                        {
                             Id = new List<Id>()
                             {
                                  new Id(){ Content = details.TradingCountryIsoCode}
                             },
                             Name = new Name()
                             {
                                  Content = details.TradingCountryIsoCode
                             },
                             RegistrationTradeCountry = new RegistrationTradeCountry()
                             {
                                 Id = new List<Id>()
                                 {
                                    new Id(){ Content = details.TradingCountryIsoCode}
                                 },
                                 Name = new List<Name>()
                                 {
                                      new Name(){ Content = details.TradingCountryIsoCode}
                                 }
                             }
                             
                            

                        }
                    }
                },
                SpecifiedConsignment = new List<SpecifiedConsignment>()
                {
                    new SpecifiedConsignment()
                    {
                        Id = new List<Id>()
                        {
                             new Id() { Content = details.UCR}
                        }
                        ,
                        TransportContractReferencedDocument = new TransportContractReferencedDocument()
                        {
                            Id = new List<Id>()
                            {
                                new Id() {Content = details.ShippingOrderNumber}
                            }
                        },
                       
                        UtilizedLogisticsTransportEquipment = details.ContainerDetails.Select(a=> new UtilizedLogisticsTransportEquipment()
                        {
                            Id = new Id()
                            {
                                Content = a.ContainerNumber,

                            },
                            UsedCapacityCode =new UsedCapacityCode()
                            {
                                     Content = a.UsedCapacityCode
                            },
                            OperationalStatusCode = new OperationalStatusCode()
                            {
                                Content =a.OperationalStatusCode
                            },
                              GrossWeight = new GrossWeight()
                              {
                                  Content = a.GrossWeight,
                                  UnitCode = a.GrossWeightType


                              } , 
                              AffixedLogisticsSeal = a.ContainerSeals.Select(b=> new AffixedLogisticsSeal()
                              {
                                    Id = new List<Id>()
                                    {
                                        new Id(){ Content = b.Serial.ToString()}
                                    },
                                    ConditionCode = new List<ConditionCode>()
                                    {
                                        new ConditionCode() { Content = b.ConditionCode}
                                    },
                                     SealingPartyRoleCode = new SealingPartyRoleCode()
                                     {
                                          Content =  b.RoleCode
                                     }
                              }).ToList(),
                             TareWeight = new TareWeight()
                             {
                                 Content = a.TareWeight,
                                 UnitCode = a.TareWeightType
                             },
                             CharacteristicCode = new CharacteristicCode()
                             {
                                 Content = a.ContainerType
                             }

                        }).ToList()


                    },


                },



            };

           return await AddingConsignments(currentObject);
        }

        public static async Task<bool> AddingConsignments(ExchangeDataPiplineDTO exchangeDataPipline)
        {
            Authication authication = new Authication();
            var authResult = await authication.SignIn(AuthicationType.WaypointSubmit);
            string url = $"{ConfigurationManager.AppSettings["MTS_URL"]}/api/v1/consignments/waypoints";
            using (var http = new HttpClient())
            {

                http.DefaultRequestHeaders.Add("Authorization", $"Bearer {authResult.AccessToken}");
                http.DefaultRequestHeaders.Add("Accept", "application/json");
                http.DefaultRequestHeaders.Add("Idempotency-Key", Guid.NewGuid().ToString());
                http.DefaultRequestHeaders.Add("requestId", Guid.NewGuid().ToString());
                var requestBody = JsonConvert.SerializeObject(exchangeDataPipline, new JsonSerializerSettings
                {
                    ContractResolver = new IgnoreNullAndEmptyResolver(),
                    Formatting = Formatting.Indented
                });
                var content = new StringContent(requestBody, Encoding.UTF8, "application/json");
                var response = await http.PostAsync(url, content);
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsStringAsync();
                    return true;
                }
                else
                {
                    var result = await response.Content.ReadAsStringAsync();
                    throw new HttpRequestException(result);
                }


            }
        }
        //public async Task<bool> 


    }
}
