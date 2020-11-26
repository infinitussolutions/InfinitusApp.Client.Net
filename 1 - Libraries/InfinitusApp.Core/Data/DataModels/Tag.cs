using Naylah.Core.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InfinitusApp.Core.Data.DataModels
{
    public static class TagExtention
    {
        public static Group ToGroup(this Tag tag)
        {
            if (tag == null)
                return new Group();

            return new Group
            {
                CreatedAt = tag.CreatedAt,
                Deleted = tag.Deleted,
                Id = tag.Id,
                Title = tag.Presentation.Title,
                UpdatedAt = tag.UpdatedAt,
                DataItems = tag.DataItems,
                ImageUri = tag.Presentation.ImageUri,
                Version = tag.Version
            };
        }

        public static List<Group> ToGroup(this List<Tag> tags)
        {
            if (tags == null || tags.Count.Equals(0))
                return new List<Group>();

            return tags.Select(tag => new Group
            {
                CreatedAt = tag.CreatedAt,
                Deleted = tag.Deleted,
                Id = tag.Id,
                Title = tag.Presentation.Title,
                UpdatedAt = tag.UpdatedAt,
                DataItems = tag.DataItems,
                ImageUri = tag.Presentation.ImageUri,
                Version = tag.Version
            }).ToList();
        }
    }

    public class Tag : EntityBase
    {
        public Tag()
        {
            Presentation = new TagPresentation();
            DataItems = new List<DataItem>();
            Tags = new List<Tag>();
          //  FinancialRequestOption = new TagFinancialRequestOption();
            SelectedDataItem = new DataItem();
            TagTagRelations = new List<TagTagRelation>();
            TagDataItemRelations = new List<TagDataItemRelation>();
           // NavigationOption = new TagNavigationOption();
        }

        public TagPresentation Presentation { get; set; }
        [Obsolete("", true)]
        public TagFinancialRequestOption FinancialRequestOption { get; set; }

        [Obsolete("", true)]
        public TagNavigationOption NavigationOption { get; set; }
        #region Relations

        public DataStore DataStore { get; set; }
        public string DataStoreId { get; set; }
        public IList<DataItem> DataItems { get; set; }
        public IList<Tag> Tags { get; set; }
        public IList<TagTagRelation> TagTagRelations { get; set; }
        public IList<TagDataItemRelation> TagDataItemRelations { get; set; }
        #endregion

        #region Helpers

        public DataItem SelectedDataItem { get; set; }

        public int Quantity { get; set; }

        public bool NotHasSelectedDataItem { get { return string.IsNullOrEmpty(SelectedDataItem?.Id); } }

        #endregion
    }

    public class TagPresentation
    {
        public TagPresentation()
        {
            Icon = new FontIcon();
        }

        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUri { get; set; }
        public string InternalTitle { get; set; }
        public FontIcon Icon { get; set; }

        #region Helps

        [JsonIgnore]
        public string InternalTitlePresentation
        {
            get
            {
                if (string.IsNullOrEmpty(InternalTitle) || Title.Equals(InternalTitle))
                    return Title;

                return string.Format("{0} ({1})", InternalTitle, Title);
            }
        }

        #endregion
    }

    public class TagFinancialRequestOption
    {
        public TagFinancialRequestType FinancialRequestType { get; set; }

        public int Quantity { get; set; }

        public enum TagFinancialRequestType
        {
            None,
            SelectOptions,
            SelectAdditionally
        }
    }

    public class TagDataItemRelation : EntityBase
    {
        public TagDataItemRelationType RelationType { get; set; }

        public Tag Tag { get; set; }

        public string TagId { get; set; }

        public DataItem DataItem { get; set; }

        public string DataItemId { get; set; }

        public string DataStoreId { get; set; }

        public enum TagDataItemRelationType
        {
            Normal,
            Required
        }
    }

    public class TagTagRelation : EntityBase
    {
        public Tag Tag { get; set; }

        public string TagId { get; set; }

        public Tag ChildTag { get; set; }

        public string ChildTagId { get; set; }

    }

    public class TagNavigationOption
    {
        public TagNavigationOption()
        {
            ItemsOrder = PageOrderType.Alphabetic;
        }

        public PageOrderType ItemsOrder { get; set; }
    }
}
