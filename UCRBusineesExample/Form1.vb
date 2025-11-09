Imports UCRMTS.dll
Imports UCRMTS.dll.MTSRequests

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim form = New UCRVerificationForm("2050024472022040017", "123456789")
        If form.ShowDialog() = DialogResult.OK Then
            MessageBox.Show("Save it in database", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("No Don't save it", "Hello", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If


    End Sub

    Private Async Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim list = New List(Of BookingDetailsItems)
        list.Add(New BookingDetailsItems() With {.CargoDescription = "Seedes", .ContainerType = "DC", .GrossWieght = 3000, .MeasurmentID = "KGM", .NoOfPackages = 2, .Nos = 2})
        Dim obj As BookingDetails = New BookingDetails() With {
            .UCR = "2050024472022040017",
            .IssuerTax = "204829305",
            .FinalTradingCountryCode = "NL",
            .LoadingTime = DateTime.Now.AddDays(1),
            .PortOfLoadingCode = "EGAKI",
            .PortOfDeschargeCode = "TRADI",
            .ShipperTaxCode = "123456789",
            .ShippingLineCode = "KMTC",
            .VesselImo = "9674218",
            .VesselTitle = "BUBBA BOOSH",
            .Details = list,
            .ShippingLineID = "KMTC",
            .TradingCountry = "FR",
            .UnLoadingTime = DateTime.Now.AddDays(2)
        }

        Dim result = Await UCRMTS.dll.MTSRequests.ConfirmOrCancelBooking(obj, BookingStatus.Cancel)


    End Sub

    Private Async Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        Dim list = New List(Of UCRMTS.dll.EmptyContainerDetails)()
        list.Add(New UCRMTS.dll.EmptyContainerDetails() With {
            .ContainerNumber = "MSCU1234567",
            .ContainerType = "22G1",
            .TareWeight = "2200",
            .TareWeightType = "KGM",
            .GrossWeight = "4000",
            .GrossWeightType = "KGM",
            .OperationalStatusCode = "AC",
            .UsedCapacityCode = "3",
            .ContainerSeals = New Generic.List(Of ContainerSeal)() From {
              New ContainerSeal() With {.Serial = "65758897", .ConditionCode = "1", .RoleCode = "CU"}
            }
           })

        Dim emptyContainerRequest = New UCRMTS.dll.EmptyContainerRequest() With {
            .UCR = "2050024472024090010",
            .IssuerID = "204829305",
            .IssuedDatetime = DateTime.Now.AddDays(1),
            .ReciverID = "204829306",
            .ContainerDetails = list,
            .ShippingOrderNumber = "YMEG00081903",
            .TransportContractReferencedDocument = "KMTC90000",
            .POL = "EGALY",
            .POD = "ITVCE",
            .PODEvent = DateTime.Now.AddDays(2),
            .POLEvent = DateTime.Now.AddDays(1),
            .TradingCountryIsoCode = "IT"
        }
        Await AddingEmptyContainer(emptyContainerRequest)
    End Sub
End Class
