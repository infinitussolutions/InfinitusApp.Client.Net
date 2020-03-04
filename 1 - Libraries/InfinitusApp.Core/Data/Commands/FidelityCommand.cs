using InfinitusApp.Core.Data.DataModels;
using InfinitusApp.Core.Data.DataModels.Fidelity;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class FidelityCommand
    {
    }

    public class FidelityPlanBase
    {
        public FidelityPlanBase()
        {
            Benefit = new FidelityPlanBenefit();
            Config = new FidelityPlanConfig();
        }

        public FidelityPlanBenefit Benefit { get; set; }

        public FidelityPlanConfig Config { get; set; }
    }

    public class CreateFidelityPlanCommand : FidelityPlanBase
    {
        public string DataStoreId { get; set; }

        public string DataItemId { get; set; }

        public string EntryIsInvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(DataStoreId))
                    msg += nameof(DataStoreId) + " is null or empty\n";

                if (string.IsNullOrEmpty(Benefit?.Description))
                    msg += "Description is null or empty\n";

                if (Benefit.NecessaryPoint <= 0)
                    msg += "NecessaryPoint is invalid\n";

                if (Config.ExpenseForOnePoint <= 0)
                    msg += "ExpenseForOnePoint is invalid\n";

                return msg;
            }
        }
    }

    public class UpdateFidelityPlanCommand : FidelityPlanBase
    {
        public string Id { get; set; }

        public string EntryIsInvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += nameof(Id) + " is null or empty\n";

                return msg;
            }
        }
    }

    public class CreateFidelityCardCommand
    {
        public string ApplicationUserId { get; set; }

        public string FidelityPlanId { get; set; }

        public string DataStoreId { get; set; }

        public string EntryIsInvalidMsg
        {
            get
            {

                var msg = "";

                if (string.IsNullOrEmpty(DataStoreId))
                    msg += nameof(DataStoreId) + " is null or empty\n";

                if (string.IsNullOrEmpty(ApplicationUserId))
                    msg += nameof(ApplicationUserId) + " is null or empty\n";

                if (string.IsNullOrEmpty(FidelityPlanId))
                    msg += nameof(FidelityPlanId) + " is null or empty\n";

                return msg;
            }
        }
    }

    public class CreateFidelityExpenseCommand
    {
        public CreateFidelityExpenseCommand()
        {
            Expense = new Expense();
        }

        /// <summary>
        /// ApplicationUser or Platform User Id
        /// </summary>
        public string ResponsibleUserId { get; set; }

        public string Description { get; set; }

        public string FidelityCardId { get; set; }

        public string DataStoreId { get; set; }

        public Expense Expense { get; set; }

        public string EntryIsInvalidMsg
        {
            get
            {

                var msg = "";

                if (string.IsNullOrEmpty(DataStoreId))
                    msg += nameof(DataStoreId) + " is null or empty\n";

                if (string.IsNullOrEmpty(FidelityCardId))
                    msg += nameof(FidelityCardId) + " is null or empty\n";

                if (Expense?.InputInfo?.Total <= 0 && Expense?.OutPutInfo?.Total <= 0)
                    msg += "Total value is not valid\n";

                return msg;
            }
        }
    }
}
