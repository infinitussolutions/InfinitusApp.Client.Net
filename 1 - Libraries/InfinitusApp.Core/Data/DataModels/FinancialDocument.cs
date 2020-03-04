using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialDocument : Naylah.Core.Entities.EntityBase
    {
        public FinancialDocument()
        {
            FinancialInvoices = new List<FinancialInvoice>();
            Type = FinancialDocumentType.Undefined;
            IfIsCanceledInfo = new CanceledInfo();
            DocumentNumber = new DocumentNumber();

            FinancialType = new FinancialType();
            FinancialOrigin = new FinancialOrigin();
            FinancialRequest = new FinancialRequest();
            FinancialTeller = new FinancialTeller();
        }

        public string Note { get; set; }

        public DocumentNumber DocumentNumber { get; set; }

        public FinancialDocumentType Type { get; set; }

        public CanceledInfo IfIsCanceledInfo { get; set; }

        #region Relations

        public FinancialOrigin FinancialOrigin { get; set; }

        public string FinancialOriginId { get; set; }

        public FinancialType FinancialType { get; set; }

        public string FinancialTypeId { get; set; }

        public FinancialRequest FinancialRequest { get; set; }

        public string FinancialRequestId { get; set; }

        public FinancialTeller FinancialTeller { get; set; }

        public string FinancialTellerId { get; set; }

        public string DataStoreId { get; set; }

        public IList<FinancialInvoice> FinancialInvoices { get; set; }

        #endregion

        #region Infos

        //public InstallmentsInfoPayment InstallmmentsInfoPayment
        //{
        //    get
        //    {
        //        var paidInstallments = FinancialInvoices.Where(x => x.Status == InvoiceInstallmentmentStatus.Paid).ToList();

        //        var allIntallmentWerePaid =
        //            FinancialRequest.InformationToGeneratedInstallment.Quantity == 0 || FinancialRequest.InformationToGeneratedInstallment.Quantity == 1 ?
        //            paidInstallments.Count > 0 :
        //            paidInstallments.Count == FinancialRequest.InformationToGeneratedInstallment.Quantity;


        //        return new InstallmentsInfoPayment
        //        {
        //            AllInstallmentWerePaid = allIntallmentWerePaid,
        //            QuantityPaidInstallment = paidInstallments.Count,
        //            PaymentMessage = paidInstallments.Count + " parcelas pagas de " + FinancialRequest.InformationToGeneratedInstallment.Quantity
        //        };
        //    }
        //}

        public decimal Total
        {
            get
            {
                return FinancialRequest.TotalRequest;
            }
        }

        #endregion
    }

    public class DocumentNumber
    {
        public int Number { get; set; }

        public string Serie { get; set; }

        public int AccessKey { get; set; }

        public string NumberAndSeriePresentation
        {
            get
            {
                return Number + " - " + Serie;
            }
        }
    }

    public enum FinancialDocumentType
    {
        Undefined,
        Manual,
        Nfe
    }

    public class InstallmentsInfoPayment
    {
        public int QuantityPaidInstallment { get; set; }

        public bool AllInstallmentWerePaid { get; set; }

        public string PaymentMessage { get; set; }
    }
}
