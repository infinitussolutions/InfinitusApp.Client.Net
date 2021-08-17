using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public class VariationGrid : EntityBase
    {
        public VariationGrid()
        {
            Options = new List<VariationOption>();
        }

        public string Title { get; set; }

        public bool DefaultInfinitus { get; set; }

        public string DataItemType { get; set; }

        #region Relations

        public DataStore DataStore { get; set; }

        public string DataStoreId { get; set; }

        public List<VariationOption> Options { get; set; }

        #endregion
    }

    public class VariationOption : EntityBase
    {
        public VariationOption()
        {

        }

        public string Title { get; set; }

        #region Relations

        public VariationGrid VariationGrid { get; set; }

        public string VariationGridId { get; set; }

        #endregion

        #region Helps

        [JsonIgnore]
        public bool Available { get; set; }

        #endregion
    }

    public class Variation : EntityBase
    {
        public Variation()
        {
            VariationsOptions = new List<VariationOption>();
            Price = new Price();
            StockInfo = new StockInfo();
            FinancialRequestItems = new List<FinancialRequestItem>();
        }

        public Price Price { get; set; }

        public StockInfo StockInfo { get; set; }

        #region Relations

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public List<VariationOption> VariationsOptions { get; set; }

        public List<FinancialRequestItem> FinancialRequestItems { get; set; }
        #endregion

        #region Helps

        [JsonIgnore]
        public string TitlePresentation
        {
            get
            {
                if (VariationsOptions?.Count == 0)
                    return string.Empty;

                var title = string.Empty;

                foreach (var i in VariationsOptions.OrderBy(x => x.VariationGridId))
                {
                    title += string.Format("{0} - ", i.Title);
                }

                return title.Remove(title.Length - 2, 2);
            }
            
        }

        [JsonIgnore]
        public string TitleWithDataItemPresentation
        {
            get
            {
                if (DataItem == null)
                    return TitlePresentation;

                return string.Format("{0} {1}", DataItem.Description.Title, TitlePresentation);
            }
        }

        #endregion

    }


}
