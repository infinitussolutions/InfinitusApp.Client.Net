using Naylah.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class SolutionApp : EntityBase
    {
        public SolutionApp()
        {

        }

        public string Name { get; set; }

        public string QuickDescription { get; set; }

        public string FullDescription { get; set; }

        public string Owner { get; set; }

        public string ExtensionReference { get; set; }

        public bool ShowInMarketplace { get; set; }

        public string Categories { get; set; }

        public int? StorePriority { get; set; }

        public bool IsMenuApp { get; set; }
    }

    public static class SolutionAppExtensions
    {
        public const string AlbumSolutionIdentifier = "7C7832B0-64C4-4E77-A637-6A02F237F607";
        public const string BookSolutionIdentifier = "B4E149EF-3E53-4DC4-BE24-71D6DCBC160C";
        public const string EatSolutionIdentifier = "6DCC9DCE-A9E0-45AA-8613-4D91BF48535A";
        public const string CurriculumSolutionIdentifier = "09270618-21C3-4835-9B7A-FE9EAF4BF466";
        public const string EventSolutionIdentifier = "4FCB6E12-2871-48ED-AD70-541D4973C6ED";
        public const string DocumentSolutionIdentifier = "6EEBC2FE-4A02-4AB9-A966-AB7C80888F84";
        public const string SponsorSolutionIdentifier = "724D982D-E38F-4EBD-ABA3-5867E5D9FB5F";
        public const string IndentifierPerson = "952B2293-50B3-4855-A29F-6867057CBF85";
        public const string IdentifierProduct = "651F394F-F5D6-451F-BCBC-288390894627";
        public const string IdentifierService = "BB47A0E1-B0B4-4138-8312-93161969E4A6";
        public const string IdentifierVehicle = "46BA4D8C-55D9-4FA5-9EC0-2F19D601033F";
        public const string IndentifierImmobile = "AAFD32EB-DAB6-4146-8012-32E2CD47883F";
        public const string PatnerSolutionIdentifier = "4600D14A-0BF7-4BBC-84EE-A73145B7538E";
        public const string AgendaSolutionIdentifier = "EB25299F-04DD-42E8-AB0B-B47394827096";
        public const string WhatsAppSolutionIdentifier = "D367293D-91FA-4BEC-B5F7-6A4C7B8CFD40";
        public const string PublicationSolutionIdentifier = "ABF7EE38-506F-4199-9845-7B82379CCA74";
        public const string NotificationSolutionIdentifier = "B37B45A3-A33A-4E1C-9935-6A90879CD121";
        public const string SalesOrderSolutionIdentifier = "17C87E70-A730-4DDB-9A74-3CCB36322DA7";
        public const string FollowersChatIdentifier = "81F7D8F6-36DD-4C0E-A224-054697B79CD2";
        public const string PetIdentifier = "C64FAD6D-2817-4C81-AF67-C765310131C0";
        public const string WebPageIdentifier = "B7056BF3-CB64-4EB2-839E-75BE9CCE5FA6";
        public const string MCommerceIdentifier = "B7056BF3-CB64-4EB2-839E-75BE9CCE5FA6";
        public const string IdentifierCustomAppMenu = "8DD2B98E-B454-4D04-816D-969646719E0A";
        public const string IdentifierPhoneAppMenu = "791FD539-ED30-4A44-8F01-B0B5519AA0FE";
        public const string IdentifierLocationAppMenu = "F86C8C7D-FF49-41DD-8F1A-639B5DD4E978";
        public const string IdentifierEditProfileAppMenu = "7C8EB828-33E3-42CD-A9EC-EE2F9CEE09EB";
        public const string IdentifierAboutCompanyAppMenu = "D85C08B0-7494-4672-B1E1-5A20923D9394";
        //public const string PropertyTenancyAppMenu = "BBEC06F2-DAD5-44D0-9F47-90F371CF047F";
        public const string TicketAppMenu = "3724FD44-A215-4068-8855-E7D66EDE4FC4";
        public const string SalesOrderWhatsApp = "654135A3-A56E-4126-ACCC-3CF66961358E";
        public const string DataItemCreatePartner = "73EC8769-D32F-4A51-9027-D62CED772533";
        public const string DataItemCreateEvent = "2A51F5C1-5359-4DA1-9E96-880E3DE55326";
        public const string Rating = "F534A1F0-5AD6-4AC7-95FA-F883BD29602E";
        public const string FakeIdNotification = "FakeIdNotification:)";
        public const string DataItemCreatePerson = "00C1396C-A2EC-4E68-84C7-1776995D4F89";
        public const string DataItemCreateInscription = "C008872F-6B4F-42CC-B18D-B454CECAB19C";
        public const string Inscription = "DEAD9F06-CF4E-4D75-AEC7-EB89626C27E8";
        public const string InvitedApp = "13DB749C-5E9C-4229-A96C-6CF689E91917";
        public const string IdentifierPdfReader = "E42E373D-572A-4E38-AEFC-75290EC98C86";
        public const string IdentifierTextPage = "EC095531-8DB3-4F66-8BC8-E24942E018A7";
        public const string Favorite = "BA601296-B382-4B74-9A95-2E3C8BDB661B";
        public const string DataItemCreatePet = "0F39B844-3716-4296-9A66-1E784EEAAFCA";
        public const string Leads = "DA89398E-0C1F-4081-9597-76AAA76586D7";
        public const string LeadsWhatsApp = "C1A9335A-83D9-48A3-A3A1-6165509271E7";
        public const string Booking = "ED6E7A28-7FA7-4E2C-A117-1B6BFFE09D71";
        public const string Company = "4600D14A-0BF7-4BBC-84EE-A73145B7538E";
        public const string SignaturePlan = "89EE6DDD-93C5-4E50-A7D8-6C66EA85A1C0";
        public const string FidelityCard = "45538054-D44E-4C9B-ACE5-226F3448FA24";
        public const string PaymentWithCreditCart = "E7CB723D-FDF5-4164-AA81-605196C372A6";
        public const string PaymentWithBankSlip = "2402C9B7-18AE-49D9-BADF-7841419101A6";
        public const string Voucher = "A0781F2A-E191-4D28-A111-1774A785203D";
        public const string Combo = "063E678F-55F3-441D-8C2A-44EBA30CE48B";
        public const string Variation = "9D4C1236-F2FF-4E05-A74B-D9E39169A7AC";
    }
}
