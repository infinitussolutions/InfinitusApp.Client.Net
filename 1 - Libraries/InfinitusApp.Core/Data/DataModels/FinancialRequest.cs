using InfinitusApp.Core.Data.DataModels.Signature;
using InfinitusApp.Core.Data.DataModels.Voucher;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialRequest : Naylah.Core.Entities.EntityBase
    {
        public FinancialRequest()
        {
            FinancialDocuments = new List<FinancialDocument>();
            Items = new List<FinancialRequestItem>();
            TrackingCode = new TrackingCode();
            DiscountInRequest = new Discount();
            ExtraChargeInRequest = new ExtraCharge();
            //  InformationToGeneratedInstallment = new InvoiceInfo();

            //Customer = new Customer();
            FinancialOrigin = new FinancialOrigin();
            SalesmanUser = new Naylah.Core.Entities.Identity.Person();
            InvoicesSimulation = new List<FinancialInvoiceToSimulation>();
            IfIsCanceledInfo = new CanceledInfo();
            ExternalReference = new ExternalReference();
            FinancialInvoices = new List<FinancialInvoice>();
            AdditionalInfos = new List<AdditionalInfo>();
            Bookings = new List<Booking>();
            ExternalModel = new FinancialRequestExternalModel();
            FinancialRequestStatusRelations = new List<FinancialRequestStatusRelation>();
            SignaturePlanConsumptions = new List<SignaturePlanConsumption>();
            VoucherGenerateList = new List<VoucherGenerate>();
            DeliveryInfo = new FinancialRequestDeliveryInfo();
            DeliveryMan = new ApplicationUser();
            TakeAwayInfo = new FinancialRequestTakeAwayInfo();
        }

        public string Observation { get; set; }

        [Obsolete("Use CurrentStatus", true)]
        public FinancialRequestStatus Status { get; set; }

        public FinancialRequestType Type { get; set; }

        public CanceledInfo IfIsCanceledInfo { get; set; }

        public ExternalReference ExternalReference { get; set; }

        public bool IsTest { get; set; }

        public FinancialRequestExternalModel ExternalModel { get; set; }

        public FinancialRequestDeliveryInfo DeliveryInfo { get; set; }

        public FinancialRequestTakeAwayInfo TakeAwayInfo { get; set; }

        #region Extention

        // public InvoiceInfo InformationToGeneratedInstallment { get; set; }

        public TrackingCode TrackingCode { get; set; }

        public Discount DiscountInRequest { get; set; }

        public ExtraCharge ExtraChargeInRequest { get; set; }

        public IList<FinancialInvoiceToSimulation> InvoicesSimulation { get; set; }

        #endregion

        #region Relations

        public Customer Customer { get; set; }

        public string CustomerId { get; set; }

        public string DataStoreId { get; set; }

        public FinancialOrigin FinancialOrigin { get; set; }

        public string FinancialOriginId { get; set; }

        public string SalesmanUserId { get; set; }

        public Naylah.Core.Entities.Identity.Person SalesmanUser { get; set; }

        public List<FinancialDocument> FinancialDocuments { get; set; }

        public List<FinancialRequestItem> Items { get; set; }

        public List<FinancialInvoice> FinancialInvoices { get; set; }

        public List<AdditionalInfo> AdditionalInfos { get; set; }

        public List<Booking> Bookings { get; set; }

        public PaymentCondition PaymentCondition { get; set; }
        public string PaymentConditionId { get; set; }

        public DataItem Provider { get; set; }

        public string ProviderId { get; set; }

        public ApplicationUser DeliveryMan { get; set; }

        public string DeliveryManId { get; set; }

        public ApplicationUser Buyer { get; set; }

        public string BuyerId { get; set; }

        public List<FinancialRequestStatusRelation> FinancialRequestStatusRelations { get; set; }

        public List<SignaturePlanConsumption> SignaturePlanConsumptions { get; set; }

        public List<VoucherGenerate> VoucherGenerateList { get; set; }

        public FinancialRequestCustomerInfo CustomerInfo
        {
            get
            {
                if (Buyer == null && Customer == null)
                    return new FinancialRequestCustomerInfo();

                return new FinancialRequestCustomerInfo
                {
                    FirstName = Buyer?.FirstName ?? Customer?.FirstName,
                    LastName = Buyer?.LastName ?? Customer?.LastName,
                    Address = Buyer?.BillingAddress ?? Customer?.Address,
                    Phone = Buyer?.Phone ?? Customer?.Phone,
                    DocumentNumber = Buyer?.DocumentIdentifier ?? Customer?.IdentityDocument,
                    Email = Buyer?.Email ?? Customer?.Email
                };
            }
        }

        #endregion

        #region Helper

        public StatusFinancialRequest CurrentStatus { get; set; }

        public bool HasId
        {
            get
            {
                return !string.IsNullOrEmpty(Id);
            }
        }

        //[JsonIgnore]
        //public FinancialRequestActions PossibleActions
        //{
        //    get
        //    {
        //        return new FinancialRequestActions
        //        {
        //            Approve = Status == FinancialRequestStatus.Open || Status == FinancialRequestStatus.InProgress,
        //            Progress = Status == FinancialRequestStatus.Open,
        //            Cancel = Status == FinancialRequestStatus.Open || Status == FinancialRequestStatus.InProgress || Status == FinancialRequestStatus.Approved,
        //            Finalize = Status == FinancialRequestStatus.Approved || Status == FinancialRequestStatus.InProgress
        //        };
        //    }
        //}

        [JsonIgnore]
        public bool StatusIsOpen
        {
            get
            {
                return string.IsNullOrEmpty(CurrentStatus?.Id);
                //   return Status == FinancialRequestStatus.Open; 
            }
        }

        [JsonIgnore]
        public bool StatusNotIsOpen { get { return !StatusIsOpen; } }

        [JsonIgnore]
        public string TrackingCodeAndTotal
        {
            get
            {
                if (string.IsNullOrEmpty(TrackingCode?.LetterAndNumberPresentation))
                    return "";

                return TrackingCode.LetterAndNumberPresentation + " | Total do Pedido: " + TotalRequestPresentation;
            }
        }

        //[JsonIgnore]
        //public FinancialRequestCustomerInfo CustomerInfo 
        //{
        //    get
        //    {
        //        if (Buyer == null && Customer == null)
        //            return new FinancialRequestCustomerInfo();

        //        return new FinancialRequestCustomerInfo
        //        {
        //            FirstName = Buyer?.FirstName ?? Customer?.FirstName,
        //            LastName = Buyer?.LastName ?? Customer?.LastName,
        //            Address = Buyer?.BillingAddress ?? Customer?.Address,
        //            Phone = Buyer?.Phone ?? Customer?.Phone,
        //            DocumentNumber = Buyer?.DocumentIdentifier ?? Customer?.IdentityDocument,
        //            Email = Buyer?.Email ?? Customer?.Email
        //        };
        //    }
        //}
        //[JsonIgnore]
        //public string GeneratedFinancialRequestInfo
        //{
        //    get
        //    {
        //        var msg = "👜 Pedido: ";

        //        if (!string.IsNullOrEmpty(FinancialRequest?.TrackingCode?.LetterAndNumberPresentation))
        //        {
        //            msg += FinancialRequest.TrackingCode.LetterAndNumberPresentation;
        //            msg += " | Total: " + FinancialRequest.TotalRequestPresentation;
        //        }

        //        else
        //            msg += " Não gerado (Toque para gerar)";

        //        return msg;
        //    }
        //}

        #region Itens

        public decimal TotalItemsWithDiscount
        {
            get
            {
                return Items.Sum(x => x.TotalItemWithDiscount);
            }
        }

        public string TotalItensPresentation
        {
            get
            {
                return TotalItemsWithDiscount.ToString("C");
            }
        }

        #endregion

        #region Delivery

        [JsonIgnore]
        public string DeliveryPricePresentation => DeliveryInfo.PricePresentation;

        #endregion

        #region Discount

        public decimal Discount
        {
            get
            {
                decimal discount = 0;

                if (DiscountInRequest.DiscountInMoney > 0)
                    discount += DiscountInRequest.DiscountInMoney;

                if (DiscountInRequest.DiscountInPercent > 0)
                    discount += ((DiscountInRequest.DiscountInPercent * TotalItemsWithDiscount) / (decimal)100);

                return discount;
            }
        }

        public string DiscountPresentation
        {
            get
            {
                return Discount.ToString("C2");
            }
        }

        #endregion

        #region Extra Charge

        public decimal TotalRequestExtraCharge
        {
            get
            {
                if (ExtraChargeInRequest == null)
                    return 0;

                var total = ExtraChargeInRequest.InMoney;

                if (ExtraChargeInRequest.InPercent > 0)
                    total += (TotalItemsWithDiscount * ExtraChargeInRequest.InPercent) / 100;

                return total;
            }
        }

        public string ExtraChargePresentation
        {
            get
            {
                if (TotalRequestExtraCharge == 0)
                    return "";

                return TotalRequestExtraCharge.ToString("C");
            }
        }

        #endregion

        #region Discount

        public int TotalDiscountFromVoucher => VoucherGenerateList.Sum(x => x.CreditValue);

        public string TotalDiscountFromVoucherPresentation => TotalDiscountFromVoucher > 0 ? TotalDiscountFromVoucher.ToString("C") : "";

        #endregion

        #region Total

        public decimal TotalRequest => ((TotalItemsWithDiscount + (DeliveryInfo?.Price ?? 0) + TotalRequestExtraCharge) - Discount) - TotalDiscountFromVoucher;

        public string TotalRequestPresentation => TotalRequest.ToString("C");

        public string DateCreatedPresentation => CreatedAt.HasValue ? CreatedAt.Value.ToString("dd/MM/yyyy HH:mm") : "Não Encontrado";

        #endregion

        public FinancialStatusPresentation FinancialStatusPresentation { get; set; }

        public string Presentation
        {
            get
            {
                var msg = "";

                if (!string.IsNullOrEmpty(TrackingCode?.LetterAndNumberPresentation))
                    msg += "🔢 Número: " + TrackingCode.LetterAndNumberPresentation + "\n";

                if (!string.IsNullOrEmpty(TotalRequestPresentation))
                    msg += "💰 Total: " + TotalRequestPresentation;

                return msg;
            }
        }

        //public FinancialStatusPresentation FinancialStatusPresentation
        //{
        //    get
        //    {
        //        try
        //        {
        //            var presentation = new FinancialStatusPresentation
        //            {
        //                IsPaid = true, //FinancialDocuments?.FirstOrDefault()?.FinancialInvoices?.FirstOrDefault()?.Status == InvoiceInstallmentmentStatus.Paid,
        //                NFIssued = (bool)FinancialDocuments?.Any(x => x.DocumentNumber.AccessKey > 0),
        //                //NFGenerated = FinancialDocuments != null && FinancialDocuments.Count > 0,
        //                NFGenerated = false,
        //                IsApproved = false
        //            };

        //            if ((bool)IfIsCanceledInfo?.IsCanceled || Status == FinancialRequestStatus.Canceled)
        //                presentation.Status = FinancialRequestPresentationStatus.Canceled;

        //            else
        //            {
        //                if (presentation.NFIssued)
        //                    presentation.Status = FinancialRequestPresentationStatus.NFIssued;

        //                else if (presentation.NFGenerated)
        //                    presentation.Status = FinancialRequestPresentationStatus.NFGenerated;

        //                //else if (presentation.IsApproved)
        //                //    presentation.Status = FinancialRequestPresentationStatus.Approved;

        //                else
        //                    presentation.Status = FinancialStatusPresentation.FinancialRequestStatusToPresentation(Status);

        //            }

        //            return presentation;
        //        }

        //        catch (Exception e)
        //        {
        //            return null;
        //        }
        //    }
        //}

        #endregion

        #region Validation

        //public static string CheckStatusToChange(FinancialRequestStatus? status)
        //{
        //    var objReturn = "";

        //    if (status == FinancialRequestStatus.InProgress)
        //        objReturn += "Financial Request in progress\n";

        //    if (status == FinancialRequestStatus.Canceled)
        //        objReturn += "Financial Request is canceled\n";

        //    if (status == FinancialRequestStatus.Finalized)
        //        objReturn += "Financial Request is finalized";

        //    return objReturn;
        //}

        #endregion
    }

    public class TrackingCode
    {
        public string Letter { get; set; }

        public int Number { get; set; }

        public string LetterAndNumber 
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Letter) && Number.Equals(0))
                    return msg;

                if (!string.IsNullOrEmpty(Letter))
                    msg += Letter.ToUpper();

                if (Number > 0)
                    msg += Number.ToString();

                return msg;
            }
        }

        public string LetterAndNumberPresentation
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Letter) && Number.Equals(0))
                    return msg;

                if (!string.IsNullOrEmpty(Letter))
                    msg += Letter.ToUpper() + " ";

                if (Number > 0)
                    msg += Number.ToString();

                return "🛒 Pedido: " + msg;
            }
        }
    }

    public class InvoiceInfo
    {
        public InvoiceInfo()
        {
            PayableWith = InvoicePaymentType.Any;
            // InfoForFirstDueDate = new InvoiceDate();
        }

        public int Quantity { get; set; }

        // public InvoiceDate InfoForFirstDueDate { get; set; }

        public bool OnlyWorkingDays { get; set; }

        public InvoicePaymentType PayableWith { get; set; }

        #region Infos

        //public DateTime? FirstDueDate
        //{
        //    get
        //    {
        //        return InfoForFirstDueDate?.FirstDueDate;
        //    }
        //}

        #endregion
    }

    public class InvoiceDate
    {
        public DayForInstallment Day { get; set; }

        public MonthForInstallment Month { get; set; }

        public DateTime? FirstDueDate
        {
            get
            {
                var year = GetMonthForInstallment < DateTime.Now.Month ? DateTime.Now.Year + 1 : DateTime.Now.Year;

                var dueDate = GetDayFromDayForInstallment == 0 ? DateTime.Now.Date.AddDays(1) : new DateTime(year, GetMonthForInstallment, GetDayFromDayForInstallment);

                return dueDate.AddDays(1).AddSeconds(-1);
            }
        }

        public int GetDayFromDayForInstallment
        {
            get
            {
                return DayForInstallmentToInt(Day);
            }
        }

        public int GetMonthForInstallment
        {
            get
            {
                return MonthForInstallmentToInt(Month);
            }
        }

        public static int DayForInstallmentToInt(DayForInstallment dayForInstallment)
        {
            switch (dayForInstallment)
            {
                case DayForInstallment.InCash:
                    return 0;
                case DayForInstallment.EveryDay1:
                    return 1;
                case DayForInstallment.EveryDay3:
                    return 3;
                case DayForInstallment.EveryDay6:
                    return 6;
                case DayForInstallment.EveryDay9:
                    return 9;
                case DayForInstallment.EveryDay12:
                    return 12;
                case DayForInstallment.EveryDay15:
                    return 15;
                case DayForInstallment.EveryDay18:
                    return 18;
                case DayForInstallment.EveryDay21:
                    return 21;
                case DayForInstallment.EveryDay24:
                    return 24;
                case DayForInstallment.EveryDay27:
                    return 27;
                default:
                    return 0;
            }
        }

        public static DayForInstallment IntToDayForInstallment(int day)
        {
            switch (day)
            {
                default: return DayForInstallment.InCash;
                case 1: return DayForInstallment.EveryDay1;
                case 3: return DayForInstallment.EveryDay3;
                case 6: return DayForInstallment.EveryDay6;
                case 9: return DayForInstallment.EveryDay9;
                case 12: return DayForInstallment.EveryDay12;
                case 15: return DayForInstallment.EveryDay15;
                case 18: return DayForInstallment.EveryDay18;
                case 21: return DayForInstallment.EveryDay21;
                case 24: return DayForInstallment.EveryDay24;
                case 27: return DayForInstallment.EveryDay27;
            }
        }

        public static MonthForInstallment IntToMonthForInstallment(int month)
        {
            switch (month)
            {
                default: return MonthForInstallment.CurrentMonth;
                case 1: return MonthForInstallment.StartingInMonth1;
                case 2: return MonthForInstallment.StartingInMonth2;
                case 3: return MonthForInstallment.StartingInMonth3;
                case 4: return MonthForInstallment.StartingInMonth4;
                case 5: return MonthForInstallment.StartingInMonth5;
                case 6: return MonthForInstallment.StartingInMonth6;
                case 7: return MonthForInstallment.StartingInMonth7;
                case 8: return MonthForInstallment.StartingInMonth8;
                case 9: return MonthForInstallment.StartingInMonth9;
                case 10: return MonthForInstallment.StartingInMonth10;
                case 11: return MonthForInstallment.StartingInMonth11;
                case 12: return MonthForInstallment.StartingInMonth12;
            }
        }

        public static int MonthForInstallmentToInt(MonthForInstallment month)
        {
            switch (month)
            {
                case MonthForInstallment.CurrentMonth:
                    return DateTime.Now.Month;
                case MonthForInstallment.StartingInMonth1:
                    return 1;
                case MonthForInstallment.StartingInMonth2:
                    return 2;
                case MonthForInstallment.StartingInMonth3:
                    return 3;
                case MonthForInstallment.StartingInMonth4:
                    return 4;
                case MonthForInstallment.StartingInMonth5:
                    return 5;
                case MonthForInstallment.StartingInMonth6:
                    return 6;
                case MonthForInstallment.StartingInMonth7:
                    return 7;
                case MonthForInstallment.StartingInMonth8:
                    return 8;
                case MonthForInstallment.StartingInMonth9:
                    return 9;
                case MonthForInstallment.StartingInMonth10:
                    return 10;
                case MonthForInstallment.StartingInMonth11:
                    return 11;
                case MonthForInstallment.StartingInMonth12:
                    return 12;
                default:
                    return DateTime.Now.Month;
            }
        }
    }

    public class FinancialInvoiceToSimulation
    {
        public FinancialInvoiceToSimulation()
        {
            InstallmentPrice = new Price();
        }

        public DateTimeOffset DueDate { get; set; }

        public int InstallmentNumber { get; set; }

        public Price InstallmentPrice { get; set; }

        public string Description { get; set; }
    }

    public enum DayForInstallment
    {
        InCash,
        EveryDay1,
        EveryDay3,
        EveryDay6,
        EveryDay9,
        EveryDay12,
        EveryDay15,
        EveryDay18,
        EveryDay21,
        EveryDay24,
        EveryDay27,
    }

    public enum MonthForInstallment
    {
        CurrentMonth,
        StartingInMonth1,
        StartingInMonth2,
        StartingInMonth3,
        StartingInMonth4,
        StartingInMonth5,
        StartingInMonth6,
        StartingInMonth7,
        StartingInMonth8,
        StartingInMonth9,
        StartingInMonth10,
        StartingInMonth11,
        StartingInMonth12,
    }

    public enum InvoicePaymentType
    {
        Any,
        Internal,
        BankSlip,
        CreditCard
    }

    [Obsolete("Use FinancialRequestStatusRelation", true)]
    public enum FinancialRequestStatus
    {
        None,
        Open,
        InProgress,
        Canceled,
        Finalized,
        Approved
    }

    public enum FinancialRequestType
    {
        Undefined,
        SalesOrder,
        ManualInclusion
    }

    public enum FinancialRequestPresentationStatus
    {
        None,
        Budgeted,
        InProgress,
        Canceled,
        Finalized,
        Approved,
        NFGenerated,
        NFIssued,
    }

    public class FinancialStatusPresentation
    {
        public FinancialRequestPresentationStatus Status { get; set; }

        public bool IsPaid { get; set; }

        public bool NFGenerated { get; set; }

        public bool NFIssued { get; set; }

        public bool IsApproved { get; set; }

        [JsonIgnore]
        public string PresentationSimple
        {
            get
            {
                return IsPaid ? "Pago" : "Pendente";
            }
        }

        [JsonIgnore]
        public string Presentation
        {
            get
            {
                var msg = "";

                msg += PresentationSimple;
                //msg += NFGenerated ? "✔ NF Gerada\n" : "✖ NF Gerada\n";
                //msg += NFIssued ? "✔ NF Emitida\n" : "✖ NF Emitida\n";
                //msg += IsApproved ? "✔ Aprovado\n" : "✖ Aprovado";

                return "⚠ Status do pagamento: " + msg;
            }
        }



        //public static FinancialRequestPresentationStatus FinancialRequestStatusToPresentation(FinancialRequestStatus status)
        //{
        //    switch (status)
        //    {
        //        default: return FinancialRequestPresentationStatus.None;
        //        case FinancialRequestStatus.Open: return FinancialRequestPresentationStatus.Budgeted;
        //        case FinancialRequestStatus.InProgress: return FinancialRequestPresentationStatus.InProgress;
        //        case FinancialRequestStatus.Finalized: return FinancialRequestPresentationStatus.Finalized;
        //        case FinancialRequestStatus.Canceled: return FinancialRequestPresentationStatus.Canceled;
        //        case FinancialRequestStatus.Approved: return FinancialRequestPresentationStatus.Approved;
        //    }
        //}
    }

    public class FinancialRequestActions
    {
        public bool Cancel { get; set; }

        public bool Approve { get; set; }

        public bool Progress { get; set; }

        public bool Finalize { get; set; }
    }

    public class FinancialRequestExternalModel
    {
        public FinancialRequestExternalModel()
        {

        }

        public string BoletoUrl { get; set; }
        public string Status { get; set; }
        public string ConfirmDate { get; set; }
        public string PaymentMethod { get; set; }
        public int Instalments { get; set; }

        public bool HasBoleto
        {
            get
            {
                return !string.IsNullOrEmpty(BoletoUrl);
            }
        }

        public bool HasExternalModel
        {
            get
            {
                if (string.IsNullOrEmpty(PaymentMethod) && string.IsNullOrEmpty(Status))
                    return false;

                return true;
            }
        }
    }

    public class FinancialRequestStatusRelation : Naylah.Core.Entities.EntityBase
    {
        public FinancialRequestStatusRelation()
        {

        }

        public string Message { get; set; }

        #region Relations

        public virtual FinancialRequest FinancialRequest { get; set; }

        public virtual string FinancialRequestId { get; set; }

        public virtual StatusFinancialRequest StatusFinancialRequest { get; set; }

        public virtual string StatusFinancialRequestId { get; set; }

        #endregion

        #region Helpers

        public string ActualPresentation => CreatedAt.Value.ToString("dd MMM hh:mm") + " | " + StatusFinancialRequest.Title + " | " + Message;

        #endregion
    }

    public class FinancialRequestDeliveryInfo
    {
        public FinancialRequestDeliveryInfo()
        {
            Address = new AddressComplex();
        }

        public FinancialRequestDeliveryType Type { get; set; }

        public AddressComplex Address { get; set; }

        public decimal Price { get; set; }

        public string TypePresentation
        {
            get
            {
                switch (Type)
                {
                    case FinancialRequestDeliveryType.Humanized: return "Humanizada";
                    case FinancialRequestDeliveryType.InHands: return "Retirar na loja";
                    case FinancialRequestDeliveryType.Normal: return "Normal";
                    default: return "Desconhecido";
                }
            }
        }

        public string PricePresentation
        {
            get
            {
                return Price.ToString("C");
            }
        }

        public enum FinancialRequestDeliveryType
        {
            Unknown,
            InHands,
            Normal,
            Humanized
        }

        public bool IsNormal
        {
            get
            {
                return Type == FinancialRequestDeliveryType.Normal;
            }
        }

        public bool IsInHands
        {
            get
            {
                return Type == FinancialRequestDeliveryType.InHands;
            }
        }
    }

    public static class FinancialRequestExtention
    {
        public static string GetTotalResume(this FinancialRequest toFinancialRequest, HideFinancialRequestInfo hideFinancialRequestInfo = null)
        {
            var msg = "";

            var hide = hideFinancialRequestInfo ?? new HideFinancialRequestInfo();

            if (!hide.TotalItems)
                msg += "🏷 Itens: .............. " + toFinancialRequest.TotalItensPresentation + "\n";

            if (!hide.Voucher && !string.IsNullOrEmpty(toFinancialRequest?.TotalDiscountFromVoucherPresentation))
                msg += "🙌 Voucher: ....... -" + toFinancialRequest.TotalDiscountFromVoucherPresentation + "\n";

            if (!hide.Discount)
            {
                if (toFinancialRequest.DiscountInRequest.DiscountInPercent > 0)
                    msg += "🙌 Desconto (" + toFinancialRequest.DiscountInRequest.DiscountInPercent + "% OFF) : -" + toFinancialRequest.Discount.ToString("C") + "\n";

                else if(toFinancialRequest.DiscountInRequest.DiscountInMoney > 0)
                    msg += "🙌 Desconto: ...... " + toFinancialRequest.Discount.ToString("C") + "\n";

            }
            if (!hide.Delivery)
                msg += toFinancialRequest.DeliveryInfo.Type.GetEmoji() + " Entrega: ......... " + toFinancialRequest.DeliveryInfo.PricePresentation + "\n";

            if (!hide.Total)
                msg += "💰 TOTAL GERAL: " + toFinancialRequest.TotalRequest.ToString("C");

            return msg;
        }

        public class HideFinancialRequestInfo
        {
            public bool TotalItems { get; set; }

            public bool Voucher { get; set; }

            public bool Discount { get; set; }

            public bool Delivery { get; set; }

            public bool Total { get; set; }
        }
    }

    public static class FinancialRequestDeliveryInfoExtention
    {
        public static string GetEmoji(this FinancialRequestDeliveryInfo.FinancialRequestDeliveryType type)
        {
            switch (type)
            {
                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.InHands:
                    return "🤲 ";

                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Humanized:
                    return "🙋‍♀️ ";

                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Normal:
                    return "🏍 ";
            }

            return "";
        }

        public static string GetFontAwesomeIcon(this FinancialRequestDeliveryInfo.FinancialRequestDeliveryType type)
        {
            switch (type)
            {
                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.InHands:
                    return "\uf256";

                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Humanized:
                    return "\uf182";

                case FinancialRequestDeliveryInfo.FinancialRequestDeliveryType.Normal:
                    return "\uf21c";
            }

            return "";
        }
    }

    //public class FinancialRequestCustomerInfo
    //{
    //    public FinancialRequestCustomerInfo()
    //    {
    //        Phone = new PhoneComplex();
    //        Address = new AddressComplex();
    //    }

    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public PhoneComplex Phone { get; set; }
    //    public AddressComplex Address { get; set; }
    //    public string DocumentNumber { get; set; }
    //    public string Email { get; set; }

    //    public string FullName
    //    {
    //        get
    //        {
    //            return string.Format("{0} {1}", FirstName, LastName);
    //        }
    //    }
    //}

    public class FinancialRequestCustomerInfo
    {
        public FinancialRequestCustomerInfo()
        {
            Phone = new PhoneComplex();
            Address = new AddressComplex();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public PhoneComplex Phone { get; set; }
        public AddressComplex Address { get; set; }
        public string DocumentNumber { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return string.Format("{0} {1}", FirstName, LastName);
            }
        }
    }
}
