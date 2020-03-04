using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    #region VariationGrid

    public class VariationGridCommand
    {
        public string Title { get; set; }
    }

    public class VariationGridCreateCommand : VariationGridCommand
    {
        public string DataStoreId { get; set; }

        public bool DefaultInfinitus { get; set; }
    }

    public class VariationGridUpdateCommand : VariationGridCommand
    {
        public string Id { get; set; }
    }

    #endregion

    #region VariationOption

    public class VariationOptionCommand
    {
        public string Title { get; set; }
    }

    public class VariationOptionCreateCommand : VariationOptionCommand
    {
        public string VariationGridId { get; set; }
    }

    public class VariationOptionUpdateCommand : VariationOptionCommand
    {
        public string Id { get; set; }
    }

    #endregion

    #region Variation

    public class VariationCommand
    {
        public Price Price { get; set; }

        public StockInfo StockInfo { get; set; }
    }

    public class VariationCreateCommand : VariationCommand
    {
        public VariationCreateCommand()
        {
            VariationsOptionsId = new List<string>();
        }

        public string DataItemId { get; set; }
        public IList<string> VariationsOptionsId { get; set; }
    }

    public class VariationUpdateCommand : VariationCommand
    {
        public string Id { get; set; }
    }

    #endregion
}
