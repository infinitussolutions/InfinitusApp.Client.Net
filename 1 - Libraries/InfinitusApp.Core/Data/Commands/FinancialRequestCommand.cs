
using InfinitusApp.Core.Data.Commands.ExternalDependence.Ebanx;
using InfinitusApp.Core.Data.Commands.ExternalDependence.Iugu;
using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Data.DataModels.Voucher;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfinitusApp.Core.Data.Commands
{
    public class FinancialRequestCommand
    {
        public string Observation { get; set; }

        public FinancialRequestType? Type { get; set; }

        public string FinancialOriginId { get; set; }

        public Discount DiscountInRequest { get; set; }

        public ExtraCharge ExtraChargeInRequest { get; set; }

        public bool IsSimulate { get; set; }

        public ExternalReference ExternalReference { get; set; }

        public bool? IsTest { get; set; }

        public string PaymentConditionId { get; set; }

        public FinancialRequestDeliveryInfo DeliveryInfo { get; set; }

        public FinancialRequestTakeAwayInfo TakeAwayInfo { get; set; }

        public string DeliveryManId { get; set; }
    }

    public class CreateFinancialRequestCommand : FinancialRequestCommand
    {
        public string DataStoreId { get; set; }

        public string CustomerId { get; set; }

        public string BuyerId { get; set; }

        public IList<CreateFinancialRequestItemCommand> Items { get; set; }

        public VoucherGenerate VouchersGenerate { get; set; }

        /// <summary>
        /// Is platform User
        /// </summary>

        public string SalesmanUserId { get; set; }

        public string ProviderId { get; set; }

        public string PaymentMethodPresentation { get; set; }

        public EbanxDirectPaymentCommand EbanxCommand { get; set; }

        public IuguInvoiceCommand IuguCommand { get; set; }
    }

    public class UpdateFinancialRequestCommand : FinancialRequestCommand
    {
        public string Id { get; set; }

        [Obsolete("Use financialRequest status", true)]
        public FinancialRequestStatus? Status { get; set; }

        public IList<UpdateFinancialRequestItemCommand> Items { get; set; }

        public CanceledInfo IfIsCanceledInfo { get; set; }
    }

    public class FinancialRequestItemCommand
    {
        public FinancialRequestItemCommand()
        {
            Price = new Price();
            MediaImageData = new MediaImageData();
            ExternalCode = new IdentificationCode();
        }

        public string Description { get; set; }

        public int Quantity { get; set; }

        public Price Price { get; set; }

        public MediaImageData MediaImageData { get; set; }

        public string DataItemId { get; set; }

        public string VariationId { get; set; }

        public string FinancialRequestId { get; set; }

        public bool Deleted { get; set; }

        public IdentificationCode ExternalCode { get; set; }
    }

    public class CreateFinancialRequestItemCommand : FinancialRequestItemCommand
    {
        public CreateFinancialRequestItemCommand()
        {
            FromItem = new FinancialRequestItemFrom();
        }

        public FinancialRequestItemFrom FromItem { get; set; }

        public static IList<CreateFinancialRequestItemCommand> ConvertFromFinancialRequestItem(List<FinancialRequestItem> financialRequestItemList)
        {
            var objReturn = new List<CreateFinancialRequestItemCommand>();

            objReturn = financialRequestItemList.Select(x => new CreateFinancialRequestItemCommand
            {
                //DataItemId = x.DataItemId,
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity,
                MediaImageData = x.MediaImageData,
                FinancialRequestId = x.FinancialRequestId,
                FromItem = x.FromItem,
                //VariationId = x.VariationId,
                Deleted = x.Deleted
            }).ToList();

            return objReturn;
        }
    }

    public class UpdateFinancialRequestItemCommand : FinancialRequestItemCommand
    {
        public string Id { get; set; }

        public static IList<UpdateFinancialRequestItemCommand> ConvertFromFinancialRequestItem(List<FinancialRequestItem> financialRequestItemList)
        {
            var objReturn = new List<UpdateFinancialRequestItemCommand>();

            objReturn = financialRequestItemList.Select(x => new UpdateFinancialRequestItemCommand
            {
                //DataItemId = x.DataItemId,
                Description = x.Description,
                Price = x.Price,
                Quantity = x.Quantity,
                MediaImageData = x.MediaImageData,
                Id = x.Id,
                FinancialRequestId = x.FinancialRequestId,
                //VariationId = x.VariationId,
                Deleted = x.Deleted
            }).ToList();

            return objReturn;
        }
    }

    public class SimulatedFinancialRequestCommand
    {
        public InvoiceInfo InformationToGeneratedInstallment { get; set; }

        public IList<CreateFinancialRequestItemCommand> Items { get; set; }
    }
}
