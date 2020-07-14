using InfinitusApp.Core.Data.Commands;
using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using static InfinitusApp.Core.Data.Enums.DataItemEnums;

namespace InfinitusApp.Core.Data.DataModels
{
    public class DataItem : Naylah.Core.Entities.EntityBase
    {
        public DataItem()
        {
            Children = new List<DataItem>();
            Medias = new List<DataItemMedia>();
            //SocialMediaUrls = new List<SocialMediaUrl>();
            MediaImageData = new MediaImageData();

            Description = new DataItemDescriptionInfo();
            Price = new DataItemPriceInfo();
            Location = new DataItemLocationInfo();

            Product = new DataItemProductInfo();
            Vehicle = new DataItemVehicleInfo();
            Event = new DataItemEventInfo();
            Company = new DataItemCompanyInfo();
            Person = new DataItemPersonInfo();
            Speaker = new DataItemSpeakerInfo();
            Sponsor = new DataItemSponsorInfo();

            Property = new DataItemPropertyInfo();
            PropertyTenancy = new DataItemProperyTenancyInfo();
            Pet = new DataItemPetInfo();

            Publications = new List<Publication>();
            TargetUserGroups = new List<ApplicationUserGroup>();
            SubGroupRecommendations = new List<SubGroupRecommendation>();
            ApplicationUserInteractionRatings = new List<ApplicationUserInteractionRating>();
            IdentificationCode = new DataItemIdentificationInfo();

            Phones = new List<Phone>();
            Addresses = new List<Address>();
            Appointments = new List<Appointment>();
            AppointmentRelations = new List<AppointmentRelation>();
            CollaboratorUserLevels = new List<CollaboratorUserLevel>();

            AgendaInfo = new DataItemAgendaInfo();
            Helper = new DataItemHelper();
            Contact = new ContactInfo();
            Inscription = new DataItemInscriptionInfo();

            PaymentInfo = new PaymentInfo();
            DeliveryInfo = new DeliveryInfo();

            // ApplicationUser = new ApplicationUser();
            DataItemUsers = new List<DataItemUser>();
            DeliveryFees = new List<DeliveryFee>();

            DistanceFromActualLocation = new DistanceFrom();
            Tags = new List<Tag>();
            Availability = new Availability();
            Variations = new List<Variation>();
            Indications = new List<Indication>();
            //BookingConfiguration = new BookingConfiguration();
            Bookings = new List<Booking>();
            TagRelations = new List<TagDataItemRelation>();
            SocialMedia = new SocialMedia();
            Visibility = new VisibilityInfo();
            PaymentConditionRelations = new List<PaymentConditionRelation>();
            SignaturePlanApplicationUsers = new List<SignaturePlanApplicationUser>();
        }

        public string Referency { get; set; }

        [Obsolete("Use Visibility.Visible")]
        public bool Visible { get; set; }

        [Obsolete("Use Visibility.PausedByUser")]
        public bool Paused { get; set; }

        [Obsolete("Use Visibility.ShowInFeed")]
        public bool ShowInFeed { get; set; }

        public string Type { get; set; }

        public string ExternalReference { get; set; }

        public decimal YieldPerPerson { get; set; }

        [JsonIgnore]
        public int RecommendedQuantity { get; set; }

        [JsonIgnore]
        public decimal TotalPrice { get; set; }

        public DataItemDescriptionInfo Description { get; set; }

        public DataItemPriceInfo Price { get; set; }

        public DataItemLocationInfo Location { get; set; }

        public DataItemProductInfo Product { get; set; }

        public DataItemVehicleInfo Vehicle { get; set; }

        public DataItemEventInfo Event { get; set; }

        public DataItemCompanyInfo Company { get; set; }

        public DataItemPetInfo Pet { get; set; }

        public DataItemSponsorInfo Sponsor { get; set; }

        public DataItemSpeakerInfo Speaker { get; set; }

        public DataItemPropertyInfo Property { get; set; }

        public DataItemProperyTenancyInfo PropertyTenancy { get; set; }

        public DataItemPersonInfo Person { get; set; }

        public DataItemIdentificationInfo IdentificationCode { get; set; }

        public DataItemInscriptionInfo Inscription { get; set; }

        public IList<DataItemUser> DataItemUsers { get; set; }

        public IList<Variation> Variations { get; set; }

        public IList<TagDataItemRelation> TagRelations { get; set; }

        public IList<PaymentConditionRelation> PaymentConditionRelations { get; set; }

        public IList<SignaturePlanApplicationUser> SignaturePlanApplicationUsers { get; set; }

        public IList<Indication> Indications { get; set; }

        public IList<Booking> Bookings { get; set; }

        public BookingConfiguration BookingConfiguration { get; set; }

        public string BookingConfigurationId { get; set; }

        public OpeningHours OpeningHours { get; set; }

        public DateTimeOffset LastActivityFromUser { get; set; }

        public bool ActiveInLastMonthByUser { get; set; }

        [JsonIgnore]
        public bool HasVariations
        {
            get
            {
                return Variations != null && Variations.Count > 0;
            }
        }

        [JsonIgnore]
        public int TotalVariations
        {
            get
            {
                if (!HasVariations)
                    return 0;

                return Variations.Count(x => !x.Deleted);
            }
        }

        [JsonIgnore]
        public string TotalVariationsPricePresentation
        {
            get
            {
                if (!HasVariations)
                    return "";

                var prices = Variations?.Where(x => x?.Price?.FinalPrice > 0 && !x.Deleted)?.OrderBy(x => x?.Price?.FinalPrice)?.ToList();

                if (prices?.Count == 0)
                    return "";

                var cheaper = prices?.FirstOrDefault()?.Price?.FinalPricePresentation;
                var expensive = prices?.LastOrDefault()?.Price?.FinalPricePresentation;

                if (cheaper.Equals(expensive))
                    return expensive;

                return cheaper + " - " + expensive;
            }
        }

        [JsonIgnore]
        public decimal TotalPriceValue
        {
            get
            {
                if (Price?.FinalPrice == null)
                    return 0;

                if (Price.DiscountPercent == null)
                    return Price.FinalPrice.Value * Quantity;

                return (Price.FinalPrice.Value - ((Price.DiscountPercent.Value / 100) * Price.FinalPrice.Value)) * Quantity;
            }
        }

        public string PricePresentation
        {
            get
            {
                if (!string.IsNullOrEmpty(TotalVariationsPricePresentation))
                    return TotalVariationsPricePresentation;

                if (!Price.InitialPrice.HasValue || !Price.PriceVisible || Price.InitialPrice.Value == 0)
                    return "";

                return Price.InitialPrice.Value.ToString("C");
            }
        }

        public MediaImageData MediaImageData { get; set; }

        public IList<DataItemMedia> Medias { get; set; }

        public SocialMedia SocialMedia { get; set; }

        public IList<DataItem> Children { get; set; }

        public DataItem Parent { get; set; }

        public string ParentId { get; set; }

        public string DataStoreId { get; set; }

        public IList<Publication> Publications { get; set; }

        public IList<ApplicationUserGroup> TargetUserGroups { get; set; }

        public ApplicationUser ApplicationUser { get; set; }

        public string ApplicationUserId { get; set; }

        public Group GroupType { get; set; }

        public string GroupTypeId { get; set; }

        public SubGroup SubGroupType { get; set; }

        public string SubGroupTypeId { get; set; }

        public IList<SubGroupRecommendation> SubGroupRecommendations { get; set; }

        public IList<ApplicationUserInteractionRating> ApplicationUserInteractionRatings { get; set; }

        public IList<Phone> Phones { get; set; }

        public IList<Address> Addresses { get; set; }

        public DataItemAgendaInfo AgendaInfo { get; set; }

        public IList<Appointment> Appointments { get; set; }

        public IList<AppointmentRelation> AppointmentRelations { get; set; }

        public IList<CollaboratorUserLevel> CollaboratorUserLevels { get; set; }

        public Schedule Schedule { get; set; }

        public string ScheduleId { get; set; }

        public ContactInfo Contact { get; set; }

        public PaymentInfo PaymentInfo { get; set; }

        public DeliveryInfo DeliveryInfo { get; set; }

        public VisibilityInfo Visibility { get; set; }

        public IList<DeliveryFee> DeliveryFees { get; set; }

        public IList<Tag> Tags { get; set; }

        public Availability Availability { get; set; }

        #region Helpers Props

        public DataItemHelper Helper { get; set; }

        public string FirstPhonePresentation { get; set; }

        public string FirstAddressPresentation { get; set; }

        public Location FirstLocation { get; set; }

        public string DateOfEventWithTitle { get; set; }

        public bool HasMediaImages { get; set; }

        public bool IsPropertyTenancy { get; set; }

        #endregion

        [JsonIgnore]
        public int Quantity { get; set; } = 1;


        [JsonIgnore]
        public bool HasType
        {
            get
            {
                return !string.IsNullOrEmpty(Type);
            }
        }

        [JsonIgnore]
        public bool HasPhone
        {
            get
            {
                return Helper?.Auxiliary?.FirstPhone != null && !string.IsNullOrEmpty(Helper.Auxiliary.FirstPhone.Number);
            }
        }

        [JsonIgnore]
        public bool IsCompany
        {
            get
            {
                return HasType && Type.Equals("Company");
            }
        }

        [JsonIgnore]
        public bool IsDepartment
        {
            get
            {
                return HasType && Type.Equals("Department");
            }
        }

        [JsonIgnore]
        public bool IsCompanyOrDepartment
        {
            get
            {
                return IsCompany || IsDepartment;
            }
        }

        [JsonIgnore]
        public bool NotIsDepartment
        {
            get
            {
                return !IsDepartment;
            }
        }

        [JsonIgnore]
        public bool NotIsCompanyOrDepartment
        {
            get
            {
                return !IsCompanyOrDepartment;
            }
        }

        [JsonIgnore]
        public bool IsEvent
        {
            get
            {
                return !string.IsNullOrEmpty(Type) && Type.Equals("Event");
            }
        }

        [JsonIgnore]
        public bool IsProduct
        {
            get
            {
                return Type.Equals("Product");
            }
        }

        [JsonIgnore]
        public bool IsPerson
        {
            get
            {
                return Type.Equals("Person");
            }
        }

        [JsonIgnore]
        public bool IsInscription
        {
            get
            {
                if (string.IsNullOrEmpty(Type))
                    return false;

                return Type.Equals("Inscription");
            }
        }

        [JsonIgnore]
        public bool IsPet
        {
            get
            {
                if (string.IsNullOrEmpty(Type))
                    return false;

                return Type.ToUpper().Equals("PET");
            }
        }

        [JsonIgnore]
        public string IsVisibleAdminMessage
        {
            get
            {
                return Visibility.Visible ?
                    "Aprovado! Este item já esta visivel para os usuários, e você já pode incluir seus itens." :
                    "Pendente de Aprovação Este Item esta em processo de aprovação por um administrador, após aprovado você podera enviar suas imagens e incluir seus itens.";
            }
        }

        [JsonIgnore]
        public string CreatedAtPresentation
        {
            get
            {
                if (!CreatedAt.HasValue)
                    return "";

                return CreatedAt.Value.ToPresentation();
            }
        }

        [JsonIgnore]
        public OpeningHours CurrentOpeningHours
        {
            get
            {
                if (!string.IsNullOrEmpty(Parent?.Id) && Parent.OpeningHours.HasConfiguration)
                    return Parent.OpeningHours;

                return OpeningHours;
            }
        }

        [JsonIgnore]
        public bool HasOperating
        {
            get
            {
                return CurrentOpeningHours.HasConfiguration;

                //if (Parent != null && Parent.Schedule != null && !Parent.Schedule.Deleted && Parent.Schedule.Schedules.Count > 0)
                //{
                //    Schedule = Parent.Schedule;
                //    return true;
                //}

                //if (Schedule != null && !Schedule.Deleted && Schedule.Schedules.Count > 0)
                //    return true;

                //return false;
            }
        }

        [JsonIgnore]
        public bool InOperating
        {
            get
            {
                if (!HasOperating)
                    return Availability.DaysAvailable.AvailableDaysOfWeak.HasToday;

                return CurrentOpeningHours.CurrentDayIsOpen;

                //var schedulesConfig = new List<ScheduleConfig>();

                //if (!string.IsNullOrEmpty(Parent?.Id) && Parent.Schedule?.Schedules?.Count > 0)
                //    schedulesConfig = Parent.Schedule.Schedules.ToList();

                //else
                //    schedulesConfig = Schedule.Schedules.ToList();

                //var operationToday = schedulesConfig.Where(x => x.DayOfWeek == DateTime.Today.DayOfWeek).FirstOrDefault();

                //if (operationToday == null)
                //    return false;

                //var actualTimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                //return actualTimeSpan > operationToday.Start && actualTimeSpan < operationToday.End;
            }
        }
        [JsonIgnore]
        public bool ShowAddress
        {
            get
            {
                if (string.IsNullOrEmpty(FirstAddressPresentation) || Company.IsCPF)
                    return false;

                return true;

            }
        }

        [JsonIgnore]
        public bool NotOperating
        {
            get
            {
                return !InOperating;
            }
        }

        [JsonIgnore]
        public string OperatingPresentation
        {
            get
            {
                try
                {
                    var msg = "";

                    //if (!HasOperating)
                    //{
                    //    return msg;
                    //    //if (!Availability.DaysAvailable.AvailableDaysOfWeak.HasToday)
                    //    //{
                    //    //    var nextDay = Availability.DaysAvailable.Days.FirstOrDefault(x => x > DateTime.Now.DayOfWeek).ToPresentation();
                    //    //    msg += Description.Title + ", disponível na próxima " + nextDay + ".";
                    //    //    return msg;
                    //    //}
                    //}

                    if (!CurrentOpeningHours.HasConfiguration)
                        return msg;

                    if (CurrentOpeningHours.CurrentDayIsOpen)
                        return string.Format("Aberto, fecha as {0}", CurrentOpeningHours.CurrentDay.EndPresentation);

                    return string.Format("Fechado, abre {0} ás {1}", WorkingDay.GetDayPresentation((int)CurrentOpeningHours.NextOpenDay.DayOfWeek), CurrentOpeningHours.NextOpenDay.StartPresentation);

                    //var schedulesConfig = Schedule.Schedules;

                    //var operationToday = schedulesConfig.Where(x => x.DayOfWeek == DateTime.Today.DayOfWeek).FirstOrDefault();

                    //if (operationToday == null)
                    //{
                    //    var schedule = schedulesConfig.FirstOrDefault(x => x.DayOfWeek > DateTime.Now.DayOfWeek);
                    //    return "Fechado hoje, abre " + schedule.DayOfWeek.ToPresentation() + " ás " + new DateTime(schedule.Start.Ticks).ToString("HH:mm tt");

                    //    //for (int i = 1; i < 7; i++)
                    //    //{
                    //    //    var thisDayOfWeek = DateTime.Today.AddDays(i).DayOfWeek;
                    //    //    var schedule = .FirstOrDefault();

                    //    //    if (schedule != null)
                    //    //        return "Fechado hoje, abre " + schedule.DayOfWeek.ToPresentation() + " ás " + new DateTime(schedule.Start.Ticks).ToString("HH:mm tt");
                    //    //}
                    //}

                    //var actualTimeSpan = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                    //if (actualTimeSpan > operationToday.Start && actualTimeSpan < operationToday.End)
                    //    return "Aberto agora, fecha às " + new DateTime(operationToday.End.Ticks).ToString("HH:mm tt");

                    //if (actualTimeSpan < operationToday.Start)
                    //    return "Fechado agora, abre às " + new DateTime(operationToday.Start.Ticks).ToString("HH:mm tt");

                    //if (actualTimeSpan > operationToday.End)
                    //    return "Fechado agora, fechou a " + new DateTime((actualTimeSpan - operationToday.End).Ticks).ToString("HH:mm") + " atrás";

                    //return msg;
                }

                catch (Exception)
                {
                    return string.Empty;
                }
            }
        }

        [JsonIgnore]
        public string OperatingTimePresentation
        {
            get
            {
                if (string.IsNullOrEmpty(OperatingPresentation))
                    return "";

                var a = OperatingPresentation.Split(',');

                return a.LastOrDefault();
            }
        }

        [JsonIgnore]
        public bool IsAdmin { get; set; }

        [JsonIgnore]
        public bool AdminMessageVisible
        {
            get
            {
                if (!IsAdmin || IsPet || IsInscription)
                    return false;

                return true;
            }
        }

        [JsonIgnore]
        public string ParentPresentation
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Parent?.Description?.Title))
                    return msg;

                return "Em: " + Parent.Description.Title;
            }
        }


        [JsonIgnore]
        public bool HasParent
        {
            get
            {
                return Parent != null;
            }
        }

        [JsonIgnore]
        public bool AcceptAnyCard
        {
            get
            {
                return (PaymentInfo != null) && PaymentInfo.AcceptsCreditCard || PaymentInfo.AcceptsDebitCard || PaymentInfo.AcceptTicketFood;
            }
        }

        [JsonIgnore]
        public bool IsEdit
        {
            get
            {
                return !string.IsNullOrEmpty(Id);
            }
        }

        [JsonIgnore]
        public IList<Booking> GetDaysAvailableForBook
        {
            get
            {
                try
                {
                    var list = new List<Booking>();

                    var firstDateConfig = BookingConfiguration.FirstDateToStart;
                    var lastDateConfig = BookingConfiguration.LastDateToStart;
                    var startDateTime = firstDateConfig.AddHours(BookingConfiguration.HourToCheckIn.HourSelected);
                    var finishiDateTime = lastDateConfig.AddHours(BookingConfiguration.HourToCheckIn.HourSelected);

                    do
                    {
                        var bookingAvailable = new Booking
                        {
                            CheckInDate = startDateTime
                        };
                        bookingAvailable.CheckOutDate = bookingAvailable.CheckInDate.AddMinutes(BookingConfiguration.DurationInMinutesToCheckOut);

                        if (!Bookings.Any(x => (bookingAvailable.CheckInDate.Ticks > x.CheckInDate.Ticks && bookingAvailable.CheckInDate.Ticks < x.CheckOutDate.Ticks) || (bookingAvailable.CheckOutDate.Ticks > x.CheckInDate.Ticks && bookingAvailable.CheckOutDate.Ticks < x.CheckOutDate.Ticks)))
                            list.Add(bookingAvailable);

                        startDateTime = bookingAvailable.CheckOutDate;

                    } while (!startDateTime.Equals(finishiDateTime));

                    return list;
                }

                catch (Exception e)
                {
                    return null;
                }
            }
        }

        [JsonIgnore]
        public bool ShowPanelBlock { get; set; }

        //[JsonIgnore]
        //public double DistanceFromActualLocation { get; set; } = 0;

        [JsonIgnore]
        public DistanceFrom DistanceFromActualLocation { get; set; }

        [JsonIgnore]
        public string InfoCompleteRegistration
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Description?.Title))
                    msg += "- Título não informado.\n";

                if (string.IsNullOrEmpty(MediaImageData?.WideImageUri))
                    msg += "- Logomarca não enviado.\n";

                if (string.IsNullOrEmpty(GroupTypeId))
                    msg += "- Grupo não informado.\n";

                if (Type.Equals("Company"))
                {
                    if (string.IsNullOrEmpty(Company?.DocumentNumber))
                        msg += "- CNPJ/CPF não informado.\n";

                    //if (string.IsNullOrEmpty(ScheduleId))
                    //    msg += "- Horário de funcionamento não informado.\n";

                    if (!OpeningHours.HasConfiguration)
                        msg += "- Horário de funcionamento não informado.\n";
                }

                if (string.IsNullOrEmpty(msg))
                {
                    msg += Visibility.Visible ? "Aprovado" : "Aguardando aprovação";
                    msg += !Visibility.PausedByUser ? " | Ativo" : " | Pausado";
                }

                return msg;
            }
        }

        [JsonIgnore]
        public int InfoCompleteRegistrationPercent
        {
            get
            {
                var percent = 0;

                if (!string.IsNullOrEmpty(Description?.Title))
                    percent += 15;

                if (!string.IsNullOrEmpty(MediaImageData?.WideImageUri))
                    percent += 15;

                if (!string.IsNullOrEmpty(GroupTypeId))
                    percent += 15;

                if (Type.Equals("Company"))
                {
                    if (!string.IsNullOrEmpty(Company?.DocumentNumber))
                        percent += 15;

                    //if (string.IsNullOrEmpty(ScheduleId))
                    //    msg += "- Horário de funcionamento não informado.\n";

                    if (OpeningHours.HasConfiguration)
                        percent += 15;
                }

                return percent;
            }

        }

        #region Delivery

        [JsonIgnore]
        public bool HasDeliveryFees => DeliveryFees?.Count > 0;

        [JsonIgnore]
        public bool DeliveryNotReceiveByActualLocation => HasDeliveryFees && (DistanceFromActualLocation.InKilometer > DeliveryFees?.OrderBy(y => y?.Kilometer)?.LastOrDefault().Kilometer);

        [JsonIgnore]
        public decimal? DeliveryPriceByDistanceByActualLocation => DeliveryFees?.OrderBy(y => y?.Kilometer)?.FirstOrDefault(y => Math.Round(y.Kilometer) >= Math.Round(DistanceFromActualLocation.InKilometer))?.Price?.FinalPrice;

        [JsonIgnore]
        public string DeliveryPriceByDistanceByActualLocationPresentation => DeliveryPriceByDistanceByActualLocation.HasValue ? (DeliveryPriceByDistanceByActualLocation > 0 ? DeliveryPriceByDistanceByActualLocation.Value.ToString("C") : "Grátis") : "";

        [JsonIgnore]
        public List<DeliveryOptionsToPresentation> DeliveryOptions
        {
            get
            {
                var l = new List<DeliveryOptionsToPresentation>();

                if (DeliveryPriceByDistanceByActualLocation.HasValue)
                {
                    l.Add(new DeliveryOptionsToPresentation
                    {
                        Identity = "Entrega para sua localização atual ",
                        Price = DeliveryPriceByDistanceByActualLocation.Value
                    });
                }

                if (DeliveryInfo.InHands)
                {
                    l.Add(new DeliveryOptionsToPresentation
                    {
                        Identity = "Retirar no local ",
                        Price = 0
                    });
                }

                return l;
            }
        }

        #endregion

        [JsonIgnore]
        public bool CompleteRegistrationVisible { get { return IsAdmin && !string.IsNullOrEmpty(InfoCompleteRegistration); } }

        public static DataItem ConvertAppUserToPerson(ApplicationUser user, string dataStoreId)
        {
            return new DataItem
            {
                Type = DataItemType.Person.ToString(),
                ApplicationUserId = user.Id,
                DataStoreId = dataStoreId,
                Visibility = new VisibilityInfo
                {
                    ShowInFeed = false,
                    Visible = false
                },
                ShowInFeed = false,
                Visible = false,
                MediaImageData = new MediaImageData
                {
                    WideImageUri = user.ImageUri
                },

                Description = new DataItemDescriptionInfo
                {
                    Title = user.FullName,
                },

                Contact = new ContactInfo
                {
                    Email = user.Email
                },

                Person = new DataItemPersonInfo
                {
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                }
            };
        }
    }

    public class DistanceFrom
    {
        public double InMeter { get; set; }

        public double InKilometer { get { return InMeter / 1000; } }

        public string Presentation
        {
            get
            {
                var msgReturn = "";

                if (InMeter.Equals(0))
                    return "";

                if (InKilometer.Equals(0))
                    msgReturn += "Próximo";

                else
                {
                    if (InKilometer < 1)
                        msgReturn += Convert.ToString(Math.Round(InKilometer * 1000, 0)) + " Mtrs";

                    else
                        msgReturn += Convert.ToString(Math.Round(InKilometer, 0)) + " Km";
                }

                return msgReturn;
            }
        }
    }

    public class DataItemDescriptionInfo
    {
        public string Title { get; set; }

        public string SubTitle { get; set; }

        public string Body { get; set; }

        public string Characteristics { get; set; }

        public string TitleAndSubtitleAndDescription
        {
            get
            {
                if (string.IsNullOrEmpty(Title))
                    return "";

                var textReturn = Title;

                if (!string.IsNullOrEmpty(SubTitle))
                    textReturn += " (" + SubTitle + "), " + Body;

                return textReturn;
            }
        }
    }

    public class DataItemProductInfo
    {
        public string Mark { get; set; }

        public string MarkLine { get; set; }

        public string Unity { get; set; }

        public string Group { get; set; }

        public string SubGroup { get; set; }

        public int Quantity { get; set; }

        public decimal CostValue { get; set; }
    }

    public class DataItemVehicleInfo
    {
        public enum FuelTypes
        {
            None,
            Gasoline,
            Alcool,
            Diesel,
            Flex
        }

        public enum GearBoxTypes
        {
            None,
            Manual,
            Automatic
        }

        public string Frame { get; set; }

        public string Plate { get; set; }

        public string Renavam { get; set; }

        public string YearManufacture { get; set; }

        public string YearModel { get; set; }

        public string Brand { get; set; }

        public string Family { get; set; }

        public string Model { get; set; }

        public string ModelReference { get; set; }

        public string Color { get; set; }

        public FuelTypes? FuelType { get; set; }

        public int? Odometer { get; set; }

        public string NumberOfDors { get; set; }

        public GearBoxTypes? GearBoxType { get; set; }
    }

    public class DataItemEventInfo
    {
        public DataItemEventInfo()
        {
            InvitedUsersEmails = new List<string>();
        }

        public System.DateTime? EventDateTime { get; set; }

        public System.DateTime? EventEndDateTime { get; set; }

        public List<string> InvitedUsersEmails { get; set; }

        public int ExpectedNumberPeople { get; set; }

        public bool IsPrivate { get; set; }

        #region Helpers Props

        public int DayNumber { get; set; }

        public string AbbreviateMonth
        {
            get
            {
                var month = EventDateTime.HasValue ? DateTimeFormatInfo.CurrentInfo.GetAbbreviatedMonthName(EventDateTime.Value.Month) : "DDD";
                return month.ToUpper();
            }
        }

        public string StartAndFinishEventPresentation { get; set; }

        #endregion
    }

    public class DataItemLocationInfo
    {
        public DataItemLocationInfo()
        {
            LocationAsAddress = new AddressComplex();
        }

        public string LocationAsText { get; set; }

        public AddressComplex LocationAsAddress { get; set; }
    }

    public class DataItemPropertyInfo : DataItemLocationInfo
    {
        public DataItemPropertyInfo()
        {
            Capacity = new CapacityInfo();
        }

        public CapacityInfo Capacity { get; set; }

        public bool HasParking { get; set; }
    }

    public class DataItemProperyTenancyInfo : DataItemPropertyInfo
    {
        public DataItemProperyTenancyInfo()
        {
            WeekConfigurationTimeOperating = new List<WeekConfigurationTimeOperating>();
            DateTimePeriodsNotAvailable = new List<DateTimePeriodNotAvailable>();
        }

        public List<WeekConfigurationTimeOperating> WeekConfigurationTimeOperating { get; set; }

        public List<DateTimePeriodNotAvailable> DateTimePeriodsNotAvailable { get; set; }
    }

    public class WeekConfigurationTimeOperating
    {
        public DayOfWeek DayOfWeek { get; set; }

        public TimeSpan StartIn { get; set; }

        public TimeSpan EndIn { get; set; }
    }

    public class DateTimePeriodNotAvailable
    {
        public DateTimeOffset InitialDateTime { get; set; }

        public DateTimeOffset FinalDateTime { get; set; }

        public string Motive { get; set; }
    }

    public class CapacityInfo
    {
        public CapacityInfo()
        {
            Area = new AreaInfo();
        }

        public int PersonCapacity { get; set; }

        public AreaInfo Area { get; set; }

        public string PersonCapacityPresentation
        {
            get
            {
                if (PersonCapacity == 0)
                    return "";

                return "Capacidade de Pessoas: " + PersonCapacity.ToString();
            }
        }
    }

    public class AreaInfo
    {
        public AreaInfo()
        {
            AreaType = AreaTypes.Undefined;
        }

        public decimal Value { get; set; }

        public AreaTypes AreaType { get; set; }

        public enum AreaTypes
        {
            Undefined,
            Linear,
            Square,
            Cubic
        }
    }

    public class DataItemPriceInfo
    {
        public decimal? InitialPrice { get; set; }

        public decimal? PurchasePrice { get; set; }

        public decimal? DiscountPercent { get; set; } = 0;

        public decimal? FinalPrice { get; set; }

        public bool PriceVisible { get; set; } = true;

        public decimal? ExtraPrice { get; set; }

        [JsonIgnore]
        public bool ShowPrice
        {
            get
            {
                return FinalPrice.HasValue && PriceVisible;
            }
        }

        [JsonIgnore]
        public string DiscountInfoPresentation
        {
            get
            {
                if (!DiscountPercent.HasValue || DiscountPercent.Value.Equals(0))
                    return "";

                else
                    return " " + DiscountPercent.Value + "% " + "\n OFF ";
            }
        }
        [JsonIgnore]
        public string PricePresentation
        {
            get
            {
                if (!InitialPrice.HasValue)
                    return string.Empty;

                return InitialPrice.Value.ToString("C");
            }
        }

        [JsonIgnore]
        public string FinalPricePresentation
        {
            get
            {
                if (!FinalPrice.HasValue)
                    return string.Empty;

                return FinalPrice.Value.ToString("C");
            }
        }
    }

    public class ExtraPrice
    {
        public decimal Price { get; set; }

        public string Description { get; set; }
    }

    public class DataItemCompanyInfo
    {
        public DataItemCompanyInfo()
        {
            Phone = new PhoneComplex();
        }

        public PhoneComplex Phone { get; set; }

        public string Email { get; set; }

        public string VideoUri { get; set; }

        public string WebSiteUri { get; set; }

        public string DocumentNumber { get; set; }

        public bool IsCPF
        {
            get
            {
                if (string.IsNullOrEmpty(DocumentNumber))
                    return false;

                return DocumentNumber.Replace(".", "").Replace("-", "").Length.Equals(11);
            }
        }

        public bool IsCNPJ
        {
            get
            {
                if (string.IsNullOrEmpty(DocumentNumber))
                    return false;

                return DocumentNumber
                    .Replace(".", "")
                    .Replace("-", "")
                    .Replace("/", "")
                    .Length.Equals(14);
            }
        }
    }

    public class DataItemPersonInfo
    {
        public DataItemPersonInfo()
        {
            DocumentIdentity = new DocumentIdentityInfo();
            GenderType = GenderTypes.Unknown;
            WorkInfo = new WorkInfo();
            BankAccount = new BankAccount();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { get { return GetFullName(); } }

        public string ImageUri { get; set; }

        public GenderTypes GenderType { get; set; }

        public WorkInfo WorkInfo { get; set; }
        public DocumentIdentityInfo DocumentIdentity { get; set; }
        public BankAccount BankAccount { get; set; }

        public enum GenderTypes
        {
            Unknown,
            Male,
            Female
        }

        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }

    public class WorkInfo
    {
        public WorkInfo()
        {
            WeekConfigurationTimeOperating = new List<WeekConfigurationTimeOperating>();
            DateTimePeriodsNotAvailable = new List<DateTimePeriodNotAvailable>();
            AtWorkType = AtWorkTypes.Undefined;
        }

        public List<WeekConfigurationTimeOperating> WeekConfigurationTimeOperating { get; set; }

        public List<DateTimePeriodNotAvailable> DateTimePeriodsNotAvailable { get; set; }

        public AtWorkTypes AtWorkType { get; set; }

        public enum AtWorkTypes
        {
            Undefined,
            Speaker,
            Sponsor,
            Teacher,
            DeliveryMan,
            Salesman,
            Gamer,
            Programmer,
            Manager,
            Director,
            Administrator,
            Representative,
        }
    }

    public class DataItemInscriptionInfo
    {
        public DataItemInscriptionInfo()
        {

        }

        public DateTimeOffset? Start { get; set; }
        public DateTimeOffset? End { get; set; }
        public int Capacity { get; set; }

        #region Helps
        public TimeSpan Duration
        {
            get
            {
                if (Start == null || End == null)
                    return new TimeSpan();

                else
                    return (TimeSpan)(End - Start);
            }
        }
        #endregion
    }

    public class DocumentIdentityInfo
    {
        public string Cpf { get; set; }
        //public DocumentIdentityInfo()
        //{
        //    DocumentType = DocumentIdentityTypes.Undefined;
        //}

        //public enum DocumentIdentityTypes
        //{
        //    Undefined,
        //    Rg,
        //    Cpf,
        //}

        //public string Data { get; set; }

        //public DocumentIdentityTypes DocumentType { get; set; }
    }

    public class ContactInfo
    {
        public string Email { get; set; }
        //public ContactInfo()
        //{
        //    ContactType = ContactTypes.Undefined;
        //}

        //public string Value { get; set; }

        //public ContactTypes ContactType { get; set; }

        //public enum ContactTypes
        //{
        //    Undefined,
        //    Phone,
        //    Email,
        //    WebSite,
        //    Blog
        //}
    }

    public static class DataItemExtensions
    {
        public enum DataItemPreDefinedTypes
        {
            Generic,
            Company,
            Department,
            Product,
            Vehicle,
            Service,
            Event,
            Book,
            ImageGroup,
            Document,
            Speaker,
            Sponsor,
            Property,
            Curriculum,
            Pet,
            Person,
            PropertyTenancy,
            Eat,
            Inscription
        }

        public static DataItemPreDefinedTypes GetDataItemTypeByDataItem(this DataItem dtItem)
        {
            switch (dtItem.Type)
            {
                case "Company": return DataItemPreDefinedTypes.Company;
                case "Department": return DataItemPreDefinedTypes.Department;
                case "Event": return DataItemPreDefinedTypes.Event;
                case "Product": return DataItemPreDefinedTypes.Product;
                case "Vehicle": return DataItemPreDefinedTypes.Vehicle;
                case "Service": return DataItemPreDefinedTypes.Service;
                case "Speaker": return DataItemPreDefinedTypes.Speaker;
                case "Property": return DataItemPreDefinedTypes.Property;
                case "Sponsor": return DataItemPreDefinedTypes.Sponsor;
                case "Pet": return DataItemPreDefinedTypes.Pet;
                case "Person": return DataItemPreDefinedTypes.Person;
                case "PropertyTenancy": return DataItemPreDefinedTypes.PropertyTenancy;
                case "Eat": return DataItemPreDefinedTypes.Eat;
                case "Inscription": return DataItemPreDefinedTypes.Inscription;

                default: return DataItemPreDefinedTypes.Generic;
            }
        }
    }

    public class VisibilityInfo
    {
        public VisibilityInfo()
        {

        }

        public bool Visible { get; set; }

        public bool ShowInFeed { get; set; }

        public bool PausedByUser { get; set; }

        public string LastObservation { get; set; }

        public bool IsVisible
        {
            get
            {
                return Visible && !PausedByUser;
            }
        }

        public bool IsVisibleInFeed
        {
            get
            {
                return IsVisible && ShowInFeed;
            }
        }
    }

    public class DataItemIdentificationInfo
    {
        public DataItemIdentificationInfo()
        {
            Code = new IdentificationCode();
            OldCode = new IdentificationCode();
            ExternalReference = new IdentificationCode();
            BarCode = new IdentificationCode();
            GlobalTradeItemNumber = new IdentificationCode();
            MercosulCommonNomenclatureCode = new IdentificationCode();
        }

        public IdentificationCode Code { get; set; }

        public IdentificationCode OldCode { get; set; }

        public IdentificationCode ExternalReference { get; set; }
        public IdentificationCode BarCode { get; set; }
        /// <summary>
        /// GTIN (Número Global do Item Comercial)
        /// <para>Se trata de um padrão criado e administrado pela GS1.</para>
        /// <para>É ele que aparece abaixo dos códigos de barras, amplamente utilizados no varejo físico para identificação de produtos. </para>
        /// Sua forma mais comum é de 13 dígitos, podendo também ser formado por 8, 12 ou 14 dígitos.
        /// </summary>
        public IdentificationCode GlobalTradeItemNumber { get; set; }
        /// <summary>
        /// NCM (Nomenclatura Comum ao Mercosul)
        /// <para>O SH é um padrão internacional para categorizar todas as mercadorias comercializadas no mundo, portanto tendo como base essa codificação foi criado na América Latina o NCM.</para>
        /// <para>O NCM é composto por 8 números.</para>
        /// <para>Os 6 primeiros dígitos do NCM são importados do sistema SH</para>
        /// <para>Os 2 últimos dígitos do NCM foram criados sob as necessidades do Mercosul.</para>
        /// <para>O código é amplamente usado para fiscalizações, estatísticas e inúmeros estudos de nossas entidades governamentais. É imprescindível a correta classificação para tributar de forma correta e não sofrer penalidades.</para>
        /// </summary>
        public IdentificationCode MercosulCommonNomenclatureCode { get; set; }


        public enum DataItemCodeType
        {
            Unknown,
            Code,
            OldCode,
            ExternalReference,
            BarCode,
            GTIN,
            NCM
        }
    }

    public class PaymentInfo
    {
        public bool InTest { get; set; }
        public ExternalReferenceType ExternalType { get; set; }
        [Obsolete("Use PaymentCondition")]
        public bool AcceptsCreditCard { get; set; } = true;
        [Obsolete("Use PaymentCondition")]
        public bool AcceptsDebitCard { get; set; }
        [Obsolete("Use PaymentCondition")]
        public bool AcceptTicketFood { get; set; }
        [Obsolete("Use PaymentCondition")]
        public bool AcceptMealTicket { get; set; }
        [Obsolete("Use PaymentCondition")]
        public bool AcceptMoney { get; set; } = true;
        [Obsolete("Use PaymentCondition")]
        public bool AcceptBankSlip { get; set; }

        public bool IsAnyCheckMarked { get { return AcceptsCreditCard || AcceptsDebitCard || AcceptTicketFood || AcceptMealTicket || AcceptMoney || AcceptBankSlip; } }

        [JsonIgnore]
        public bool AcceptSomeMethod
        {
            get
            {
                return MethodsList?.Count > 0;
            }
        }

        [JsonIgnore]
        public List<string> MethodsList
        {
            get
            {
                var methodsList = new List<string>();

                if (AcceptMoney)
                    methodsList.Add("Dinheiro");

                if (AcceptsCreditCard)
                    methodsList.Add("Cartão de Crédito");

                if (AcceptsDebitCard)
                    methodsList.Add("Cartão de Débito");

                if (AcceptTicketFood)
                    methodsList.Add("Ticket Alimentação");

                if (AcceptMealTicket)
                    methodsList.Add("Ticket Refeição");

                if (AcceptBankSlip)
                    methodsList.Add("Boleto");

                return methodsList;
            }
        }

        [JsonIgnore]
        public string MethodsAcceptPresentation
        {
            get
            {

                var message = "";

                if (AcceptMoney)
                    message += "Dinheiro | ";

                if (AcceptsCreditCard)
                    message += "Cartão de Crédito | ";

                if (AcceptsDebitCard)
                    message += "Cartão de Débito | ";

                if (AcceptTicketFood)
                    message += "Ticket Alimentação | ";

                if (AcceptMealTicket)
                    message += "Ticket Refeição | ";

                if (AcceptBankSlip)
                    message += "Boleto | ";

                return message;
            }
        }
    }

    public class DeliveryInfo
    {
        public bool MakesDelivery { get; set; } = true;

        public bool InHands { get; set; } = true;

        public double MaxKm { get; set; }


    }

    #region Agenda

    public class DataItemAgendaInfo
    {
        public DataItemAgendaInfo()
        {
            AgendaConfig = new DataItemAgendaConfig();
            AppointmentConfig = new DataItemAppointmentConfig();
        }

        public DataItemAgendaConfig AgendaConfig { get; set; }
        public DataItemAppointmentConfig AppointmentConfig { get; set; }
    }

    public class DataItemAppointmentConfig
    {
        public DataItemAppointmentConfig()
        {
            ReturnConfig = new DataItemAgendaReturnConfig();
        }

        /// <summary>
        /// Time Spent in minutes
        /// </summary>
        public int TimeSpent { get; set; }

        public DataItemAgendaReturnConfig ReturnConfig { get; set; }
    }

    public class DataItemAgendaConfig
    {
        public DataItemAgendaConfig()
        {
            Capacity = new DataItemAgendaCapacity();
            StaffUserIdList = new List<string>();
        }

        /// <summary>
        /// Use Microsoft Values
        /// <para>https://support.microsoft.com/en-us/help/973627/microsoft-time-zone-index-values</para>
        /// </summary>


        public DataItemAgendaCapacity Capacity { get; set; }
        public IList<string> StaffUserIdList { get; set; }

    }

    public class DataItemAgendaCapacity
    {
        public bool IgnoreCapacity { get; set; }
        public int CapacityBySchedule { get; set; } = 1;
    }

    public class DataItemAgendaReturnConfig
    {
        public DataItemAgendaReturnConfig()
        {

        }

        public int MaximumDaysForReturn { get; set; }

        #region Helps

        public bool AllowReturn { get; }

        #endregion
    }

    #endregion

    #region Helper

    public class DataItemHelper
    {
        public DataItemHelper()
        {
            Auxiliary = new DataItemAuxiliaryHelper();
            Presentation = new DataItemPresentationHelper();
        }

        public DataItemAuxiliaryHelper Auxiliary { get; set; }

        public DataItemPresentationHelper Presentation { get; set; }
    }

    public class DataItemAuxiliaryHelper
    {
        public DataItemAuxiliaryHelper()
        {
            //FirstLocation = new Location();
            FirstPhone = new Phone();
            //FirstAddress = new Address();
            Type = new DataItemAuxiliaryType();
            Actions = new DataItemAuxiliaryActions();
        }

        [Obsolete("Use location address", true)]
        public Location FirstLocation { get; set; }

        public Phone FirstPhone { get; set; }

        [Obsolete("Use location address", true)]
        public Address FirstAddress { get; set; }

        public double ActualRatting { get; set; }

        public int RattingCount { get; set; }

        public int InscriptionCount { get; set; }
        //public bool HasMediaImages { get; set; }

        //public bool HasDescription { get; set; }

        //public bool HasAditionalInfo { get; set; }

        //public bool HasValueInType { get; set; }

        public DataItemAuxiliaryType Type { get; set; }

        public DataItemAuxiliaryActions Actions { get; set; }

        public bool DataItemMediaDataHaveAnyContent { get; set; }

        public string RatingCountPresentation
        {
            get
            {
                if (RattingCount == 0)
                    return "";

                return "Média entre " + RattingCount + " opniões";
            }
        }

        public string RatingCountSimplePresentation
        {
            get
            {
                if (RattingCount == 0)
                    return "";

                var ratting = RattingCount > 999 ? "+999" : RattingCount.ToString();

                return ActualRatting + " (" + ratting + ")";
            }
        }

        public bool HasRating
        {
            get
            {
                return ActualRatting > 0;
            }
        }

    }

    public class DataItemAuxiliaryType
    {
        public DataItemType TypeEnum { get; set; }

        public bool IsCompany { get; set; }

        public bool IsDepartment { get; set; }

        public bool IsProduct { get; set; }

        public bool IsVehicle { get; set; }

        public bool IsService { get; set; }

        public bool IsEvent { get; set; }

        public bool IsBook { get; set; }

        public bool IsImageGroup { get; set; }

        public bool IsDocument { get; set; }

        public bool IsSpeaker { get; set; }

        public bool IsSponsor { get; set; }

        public bool IsProperty { get; set; }

        public bool IsCurriculum { get; set; }

        public bool IsPet { get; set; }

        public bool IsPerson { get; set; }

        public bool IsPropertyTenancy { get; set; }

        public bool IsInscription { get; set; }

    }

    public class DataItemAuxiliaryActions
    {
        public bool Lead { get; set; }

        public bool SalesOrder { get; set; }

        public bool Appointment { get; set; }

        public bool Like { get; set; }

        public bool EventRegistration { get; set; }

        public bool Inscription { get; set; }

        public bool Booking { get; set; }
    }

    public class DataItemPresentationHelper
    {
        public string FirstPhonePresentation { get; set; }

        public string FirstAddressPresentation { get; set; }

        public string DateOfEventWithTitle { get; set; }

        public string TitleAndPrice { get; set; }

    }

    #endregion

    #region RODRIGO REFAZER

    public class DataItemSponsorInfo
    {
        public DataItemSponsorInfo()
        {
            Phone = new PhoneComplex();
        }

        public PhoneComplex Phone { get; set; }

        public string Email { get; set; }

        public string VideoUri { get; set; }

        public string WebSiteUri { get; set; }
    }

    public class DataItemSpeakerInfo
    {
        public DataItemSpeakerInfo()
        {
            Phone = new PhoneComplex();
        }

        public PhoneComplex Phone { get; set; }

        public string Email { get; set; }

        public string VideoUri { get; set; }

        public string WebSiteUri { get; set; }

        public string LinkedinUri { get; set; }
    }

    public class DataItemPetInfo
    {
        public enum SexOptions
        {
            unknown,
            male,
            female
        }

        public string ChipCode { get; set; }
        public string PetId { get; set; }
        public string RGA { get; set; }
        public decimal? Weight { get; set; }
        public DateTimeOffset? DateOfBirth { get; set; }
        public SexOptions Sex { get; set; }
        public string Color { get; set; }
        public string Race { get; set; }
        public string Specie { get; set; }
        public IList<VaccinationCard> VaccinationCard { get; set; }

        public DataItemPetInfo()
        {
            VaccinationCard = new List<VaccinationCard>();
        }

    }

    public class DataItemInteractions
    {
        public DataItemInteractions()
        {
            InteractionDate = System.DateTime.Now;
            User = new ApplicationUser();
            DataItemInteracted = new DataItem();
            PublicationInteracted = new Publication();

        }

        public virtual string Id { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual DataItem DataItemInteracted { get; set; }
        public virtual Publication PublicationInteracted { get; set; }
        public Interaction InteractionPerfomed { get; set; }

        public System.DateTime? InteractionDate { get; set; }

        public enum Interaction
        {
            none,
            like,
            dislike
        }
    }

    #endregion

    public static class DataItemExtend
    {
        public static Publication ToPublication(this DataItem dtItem, bool showMessageBlockIfNotOperating = false)
        {
            try
            {
                //var dbVM = GetService<DashboardViewModel>();

                var objReturn = new Publication
                {
                    DataItem = dtItem,
                    DataItemId = dtItem.Id,
                    Id = dtItem.Id,
                    MediaImageData = dtItem.MediaImageData,
                    ShowOnFeed = dtItem.Visibility.ShowInFeed,
                    DataStoreId = dtItem.DataStoreId,
                    Deleted = dtItem.Deleted,
                    Description = dtItem.Description,
                    UpdatedAt = dtItem.UpdatedAt,
                    Version = dtItem.Version,
                    TargetType = PublicationTargetType.AllUsers,
                    CreatedAt = dtItem.UpdatedAt ?? dtItem?.CreatedAt.Value,

                    //IsAdmin = (!string.IsNullOrEmpty(dtItem?.ApplicationUserId) && !string.IsNullOrEmpty(dbVM?.CurrentApplicationUser?.Id)) && dtItem.ApplicationUserId.Equals(dbVM?.CurrentApplicationUser?.Id) || dtItem?.CollaboratorUserLevels?.Count > 0 && dtItem.CollaboratorUserLevels.Any(x => x.Identity.Equals(dbVM?.CurrentApplicationUser?.Email)) || dtItem.Parent != null && dtItem.Parent.CollaboratorUserLevels.Count > 0 && dtItem.Parent.CollaboratorUserLevels.Any(x => x.Identity.Equals(dbVM?.CurrentApplicationUser?.Email)),
                    ShowMessageBlockIfNotOperating = dtItem.NotOperating && showMessageBlockIfNotOperating
                };

                if (objReturn.DataItem.DeliveryFees.Count > 0)
                {
                    var priceDelivery = objReturn.DataItem.DeliveryFees.OrderBy(y => y.Kilometer).FirstOrDefault(y => Math.Round(y.Kilometer) >= Math.Round(objReturn.DataItem.DistanceFromActualLocation.InKilometer))?.Price?.FinalPrice;

                    if (priceDelivery != null)
                        objReturn.DeliveryInfo += "Entrega: " + (priceDelivery > 0 ? priceDelivery.Value.ToString("C") : "Gratis");
                }

                return objReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static List<Publication> ToPublication(this List<DataItem> dtItemList, bool showMessageBlockIfNotOperating = false)
        {
            try
            {
                //var dbVM = GetService<DashboardViewModel>();

                List<Publication> objReturn = dtItemList.Select(dtItem => new Publication
                {
                    DataItem = dtItem,
                    DataItemId = dtItem.Id,
                    Id = dtItem.Id,
                    MediaImageData = dtItem.MediaImageData,
                    ShowOnFeed = dtItem.Visibility.ShowInFeed,
                    DataStoreId = dtItem.DataStoreId,
                    Deleted = dtItem.Deleted,
                    Description = dtItem.Description,
                    UpdatedAt = dtItem.UpdatedAt,
                    Version = dtItem.Version,
                    TargetType = PublicationTargetType.AllUsers,
                    CreatedAt = dtItem.UpdatedAt ?? dtItem?.CreatedAt.Value,
                    //Distance = dtItem.DistanceFromActualLocation.InKilometer, //dtItem.DistanceFromActualLocation != 0 ? dtItem.DistanceFromActualLocation : 0, // dbVM?.CurrentAddress?.Location != null && dtItem?.FirstLocation != null ? UnitConverters.CoordinatesToKilometers(dbVM.CurrentAddress.Location.Latitude, dbVM.CurrentAddress.Location.Longitude, dtItem.FirstLocation.Latitude, dtItem.FirstLocation.Longitude) : 0,
                    //Distance = dbVM?.CurrentAddress?.Location != null && dtItem?.FirstLocation != null ? Xamarin.Essentials.Location.CalculateDistance(new Xamarin.Essentials.Location(dbVM.CurrentAddress.Location.Latitude, dbVM.CurrentAddress.Location.Longitude), new Xamarin.Essentials.Location(dtItem.FirstLocation.Latitude, dtItem.FirstLocation.Longitude), DistanceUnits.Kilometers) : 0,
                    //IsAdmin = (!string.IsNullOrEmpty(dtItem?.ApplicationUserId) && !string.IsNullOrEmpty(dbVM?.CurrentApplicationUser?.Id)) && dtItem.ApplicationUserId.Equals(dbVM?.CurrentApplicationUser?.Id) || dtItem?.CollaboratorUserLevels?.Count > 0 && dtItem.CollaboratorUserLevels.Any(x => x.Identity.Equals(dbVM?.CurrentApplicationUser?.Email)) || dtItem.Parent != null && dtItem.Parent.CollaboratorUserLevels.Count > 0 && dtItem.Parent.CollaboratorUserLevels.Any(x => x.Identity.Equals(dbVM?.CurrentApplicationUser?.Email)),
                    ShowMessageBlockIfNotOperating = dtItem.NotOperating && showMessageBlockIfNotOperating,
                }).ToList();

                objReturn.Select(x =>
                {
                    if (x.DataItem == null)
                        return x;

                    if (x.DataItem.DeliveryFees.Count > 0)
                    {
                        var priceDelivery = x.DataItem.DeliveryFees.OrderBy(y => y.Kilometer).FirstOrDefault(y => Math.Round(y.Kilometer) >= Math.Round(x.DataItem.DistanceFromActualLocation.InKilometer))?.Price?.FinalPrice;

                        if (priceDelivery != null)
                            x.DeliveryInfo += "Entrega: " + (priceDelivery > 0 ? priceDelivery.Value.ToString("C") : "Gratis");
                    }

                    return x;
                }).ToList();

                return objReturn;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public static FinancialRequestItem ToFinancialRequestItem(this DataItem dt, Tag tag = null)
        {
            var objReturn = new FinancialRequestItem();

            if (dt == null)
                return objReturn;

            objReturn = new FinancialRequestItem
            {
                //DataItem = dt,
                //DataItemId = dt.Id,
                Description = tag == null ? dt.Description?.Title : tag.Presentation.Title + ": " + dt.Description.Title,
                Price = new Price
                {
                    InitialPrice = dt.Price.InitialPrice ?? 0,
                    Discount = new Discount
                    {
                        DiscountInPercent = dt.Price.DiscountPercent ?? 0
                    }
                },

                Quantity = dt.RecommendedQuantity > 0 ? dt.RecommendedQuantity : dt.Quantity,
                MediaImageData = dt.MediaImageData,
                TagId = tag?.Id,
                IsEditableQuantity = !dt.Type.Equals("Person") && !dt.Type.Equals("Speaker") && dt.Price.InitialPrice.HasValue && dt.Price.InitialPrice > 0,
                FromItem = new FinancialRequestItemFrom
                {
                    Id = dt.Id,
                    Type = FinancialRequestItemParentType.DataItem
                }
            };

            //if (!dt.Type.Equals("Person") && !x.Type.Equals("Speaker") && dt.Price.InitialPrice.HasValue && x.Price.InitialPrice > 0)
            //    objReturn.IsEditableQuantity = false;

            return objReturn;
        }

        public static List<FinancialRequestItem> ToFinancialRequestItem(this List<DataItem> dtList, Tag tag = null)
        {
            var objReturn = new List<FinancialRequestItem>();

            if (dtList == null)
                return objReturn;

            objReturn = dtList.Select(x => new FinancialRequestItem
            {
                //DataItemId = x.Id,
                Description = tag == null ? x.Description?.Title : tag.Presentation.Title + ": " + x.Description.Title,
                Price = new Price
                {
                    InitialPrice = x.Price.InitialPrice ?? 0,
                    Discount = new Discount
                    {
                        DiscountInPercent = x.Price.DiscountPercent ?? 0
                    }
                },

                Quantity = x.RecommendedQuantity > 0 ? x.RecommendedQuantity : x.Quantity,
                MediaImageData = x.MediaImageData,
                TagId = tag?.Id,
                IsEditableQuantity = !x.Type.Equals("Person") && !x.Type.Equals("Speaker") && x.Price.InitialPrice.HasValue && x.Price.InitialPrice > 0,
                FromItem = new FinancialRequestItemFrom
                {
                    Id = x.Id,
                    Type = FinancialRequestItemParentType.DataItem
                }
            }).ToList();

            return objReturn;
        }
    }

    public class DeliveryOptionsToPresentation
    {
        public string Identity { get; set; }

        public decimal Price { get; set; }

        public string Presentation => Identity + " " + Price.ToString("C");
    }
}