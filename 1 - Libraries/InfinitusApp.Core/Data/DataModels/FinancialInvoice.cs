using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialInvoice : Naylah.Core.Entities.EntityBase
    {
        public FinancialInvoice()
        {
            InstallmentPrice = new Price();
            ExternalReference = new ExternalReference();
            ExternalModel = new ExternalModel();
            Status = InvoiceInstallmentmentStatus.Pending;
            AdditionalInfos = new List<AdditionalInfo>();
            FinancialDocument = new FinancialDocument();
        }

        public ExternalReference ExternalReference { get; set; }

        public DateTimeOffset DueDate { get; set; }

        public DateTimeOffset? SettlementDate { get; set; }

        public int InstallmentNumber { get; set; }

        public Price InstallmentPrice { get; set; }

        public string Description { get; set; }

        public InvoiceInstallmentmentStatus Status { get; set; }

        #region Relation

        public FinancialDocument FinancialDocument { get; set; }

        public string FinancialDocumentId { get; set; }

        public string DataStoreId { get; set; }

        public FinancialRequest FinancialRequest { get; set; }
        public string FinancialRequestId { get; set; }

        public IList<AdditionalInfo> AdditionalInfos { get; set; }
        #endregion

        #region Presentation
        public ExternalModel ExternalModel { get; set; }
        public bool IsPaidByExternalModel
        {
            get
            {
                return ExternalModel?.Iugu?.Invoice?.Status?.ToUpper() == "PAID";
            }
        }

        public string InteractionsByExternalModel
        {
            get
            {
                var msg = "";

                if (ExternalModel?.Iugu?.Invoice?.Logs == null)
                    return msg;

                foreach (var item in ExternalModel?.Iugu?.Invoice?.Logs)
                {
                    msg += item.Notes + "\n";
                }

                return msg;
            }
        }

        public string SettlementDatePresentation 
        {
            get
            {
                if (SettlementDate == null)
                    return "Não liquidado";

                return SettlementDate.Value.ToString("dd/MM/yyyy");
            }
        }

        public string CreatedPresentation
        {
            get
            {
                return CreatedAt.Value.ToString("dd/MM/yyyy");
            }
        }

        public string DueDatePresentation
        {
            get
            {
                return DueDate.ToString("dd/MM/yyyy");
            }
        }

        #endregion

    }

    public enum InvoiceInstallmentmentStatus
    {
        None = -1,
        Pending,
        Paid,
        Canceled,
        Refunded
    }
}
