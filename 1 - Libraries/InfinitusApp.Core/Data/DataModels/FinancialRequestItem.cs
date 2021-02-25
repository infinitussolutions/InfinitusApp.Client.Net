using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfinitusApp.Core.Data.DataModels
{
    public class FinancialRequestItem : Naylah.Core.Entities.EntityBase
    {
        public FinancialRequestItem()
        {
            Price = new Price();
            MediaImageData = new MediaImageData();

            //DataItem = new DataItem();
            FinancialRequest = new FinancialRequest();
            //Variation = new Variation();

            IsEditableQuantity = !FinancialRequest?.CurrentStatus?.Config?.IsClosed ?? true; // FinancialRequest.Status == FinancialRequestStatus.Open;
            CanRemoveItem = !FinancialRequest?.CurrentStatus?.Config?.IsClosed ?? true;
            ExternalCode = new IdentificationCode();
        }

        public string Description { get; set; }
        public string SubTitle { get; set; }
        public int Quantity { get; set; }
        public string Unity { get; set; }

        public Price Price { get; set; }

        public MediaImageData MediaImageData { get; set; }

        public FinancialRequestItemFrom FromItem { get; set; }

        public IdentificationCode ExternalCode { get; set; }

        #region Relations

        //public string DataItemId { get; set; }

        //public DataItem DataItem { get; set; }

        public string FinancialRequestId { get; set; }

        public FinancialRequest FinancialRequest { get; set; }

        //public string VariationId { get; set; }

        //public Variation Variation { get; set; }

        #endregion

        public bool IsEditableQuantity { get; set; }

        public bool CanRemoveItem { get; set; }

        public decimal TotalDiscount
        {
            get
            {
                return Quantity * Price.TotalDiscount;
            }
        }

        public decimal TotalItem
        {
            get
            {
                return Quantity * Price.InitialPrice;
            }
        }

        public decimal TotalItemWithDiscount
        {
            get
            {
                return TotalItem - TotalDiscount;
            }
        }

        public string TotalItemWithDiscountPresentation
        {
            get
            {
                return TotalItemWithDiscount.ToString("C");
            }
        }

        //public bool Edited { get; set; }

        #region Helper

        public string TagId { get; set; }

        public decimal FinalPrice { get { return (Price.FinalPrice * Quantity); } }

        public string FinalPricePresentation
        {
            get
            {
                return FinalPrice.ToString("C");
            }
        }

        public static External.Iugu.Item[] ToIuguItem(List<FinancialRequestItem> itens)
        {
            return itens.Select(x => new External.Iugu.Item
            {
                Quantity = x.Quantity,
                Description = x.Description,
                CreatedAt = DateTimeOffset.Now.ToString(),
                //Price = decimal.ToInt32(x.Price.FinalPrice * 100).ToString(),
                PriceCents = decimal.ToInt32(x.Price.FinalPrice * 100),

            }).ToArray();
        }

        //public static List<FinancialRequestItem> FromDataItem(List<DataItem> itens)
        //{
        //    var list = new List<FinancialRequestItem>();

        //    foreach (var i in itens)
        //    {
        //        if (i.Variations?.Count > 0)
        //        {
        //            list.AddRange(i.Variations.Select(x => new FinancialRequestItem
        //            {
        //                //VariationId = x.Id,
        //                Price = x.Price,
        //                Description = x.TitleWithDataItemPresentation,
        //                Quantity = 1,
        //                //DataItem = i,
        //                //Variation = x
        //            }));
        //        }

        //        else
        //        {
        //            list.Add(new FinancialRequestItem
        //            {
        //                //DataItemId = i.Id,
        //                MediaImageData = i.MediaImageData,
        //                Description = i.Description.Title,
        //                Quantity = 1,
        //                //DataItem = i,
        //                Price = new Price
        //                {
        //                    InitialPrice = i.Price.InitialPrice ?? 0,
        //                    Discount = new Discount
        //                    {
        //                        DiscountInPercent = i.Price.DiscountPercent ?? 0,

        //                    }
        //                }
        //            });
        //        }
        //    }

        //    return list;
        //}

        public string TitleWithSubTitle 
        {
            get
            {
                return string.IsNullOrEmpty(SubTitle) ? Description : string.Format("{0}({1})", Description, SubTitle);
            }
        }
        #endregion
    }

    public class FinancialRequestItemFrom
    {
        public string Id { get; set; }

        public FinancialRequestItemParentType Type { get; set; }
    }

    public static class FinancialRequestItemExtention
    {
        public static FinancialRequestItem ToFinancialRequestItem(this DataItem dataItem, int quantity)
        {
            return new FinancialRequestItem
            {
                FromItem = new FinancialRequestItemFrom
                {
                    Id = dataItem.Id,
                    Type = FinancialRequestItemParentType.DataItem
                },
                Quantity = quantity,
                Unity = dataItem.Product?.Unity,
                SubTitle = dataItem.Description.SubTitle,
                Price = new Price
                {
                    InitialPrice = dataItem.Price.FinalPrice ?? 0
                },
                Description = dataItem.Description.Title,
                CanRemoveItem = true,
                IsEditableQuantity = true,
                MediaImageData = dataItem.MediaImageData,
                ExternalCode = dataItem.IdentificationCode?.ExternalReference ?? new IdentificationCode()
            };
        }

        public static FinancialRequestItem ToFinancialRequestItem(this Variation variation, int quantity = 1)
        {
            return new FinancialRequestItem
            {
                FromItem = new FinancialRequestItemFrom
                {
                    Id = variation.Id,
                    Type = FinancialRequestItemParentType.Variation
                },
                Quantity = quantity,
                Unity = variation.DataItem?.Product?.Unity,
                SubTitle = variation.DataItem?.Description?.SubTitle,
                Price = new Price
                {
                    InitialPrice = variation.Price.FinalPrice
                },
                Description = variation.TitleWithDataItemPresentation,
                CanRemoveItem = true,
                IsEditableQuantity = true,
                MediaImageData = new MediaImageData
                {

                },
                ExternalCode = variation.DataItem?.IdentificationCode?.ExternalReference ?? new IdentificationCode()
            };
        }

        public static FinancialRequestItem ToFinancialRequestItem(this Booking booking, int quantity)
        {
            return new FinancialRequestItem
            {
                FromItem = new FinancialRequestItemFrom
                {
                    Id = booking.Id,
                    Type = FinancialRequestItemParentType.Booking
                },
                Quantity = quantity,
                Unity = booking.DataItem?.Product?.Unity,
                SubTitle = booking.DataItem?.Description?.SubTitle,
                Price = new Price
                {
                    InitialPrice = booking.Price.FinalPrice
                },
                Description = booking?.DataItem?.Description?.Title + " " + booking.PeriodPresentation,
                CanRemoveItem = true,
                IsEditableQuantity = false,
                MediaImageData = booking?.DataItem?.MediaImageData ?? new MediaImageData
                {

                },
                ExternalCode = booking?.DataItem?.IdentificationCode?.ExternalReference ?? new IdentificationCode()
            };
        }
    }

    public enum FinancialRequestItemParentType
    {
        Undefined,
        DataItem,
        Variation,
        Booking
    }
}
