using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class ComboBaseCommand
    {
        public string Title { get; set; }

        public Price StartPrice { get; set; }
    }

    public class CreateComboCommand : ComboBaseCommand
    {
        public string ParentId { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Title))
                    msg += "- " + nameof(Title) + " invalid\n";

                if (StartPrice == null || StartPrice.FinalPrice == 0)
                    msg += "- " + nameof(StartPrice) + " invalid\n";

                return msg;
            }
        }
    }

    public class UpdateComboCommand : ComboBaseCommand
    {
        public string Id { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += "- " + nameof(Id) + " invalid\n";

                return msg;
            }
        }
    }

    public class ComboCategoryBaseCommand
    {
        public string Title { get; set; }

        public int? QuantityRequired { get; set; }
    }

    public class CreateComboCategoryCommand : ComboCategoryBaseCommand
    {
        public string ComboId { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Title))
                    msg += "- " + nameof(Title) + " invalid\n";

                if (string.IsNullOrEmpty(ComboId))
                    msg += "- " + nameof(ComboId) + " invalid\n";

                return msg;
            }
        }
    }

    public class UpdateComboCategoryCommand : ComboCategoryBaseCommand
    {
        public string Id { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += "- " + nameof(Id) + " invalid\n";

                return msg;
            }
        }
    }

    public class ComboItemBaseCommand
    {
        public Price ExtraPrice { get; set; }
    }

    public class CreateComboItemCommand : ComboItemBaseCommand
    {
        public string DataItemId { get; set; }

        public string ComboCategoryId { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(DataItemId))
                    msg += "- " + nameof(DataItemId) + " invalid\n";

                if (string.IsNullOrEmpty(ComboCategoryId))
                    msg += "- " + nameof(ComboCategoryId) + " invalid\n";

                return msg;
            }
        }
    }

    public class UpdateComboItemCommand : ComboItemBaseCommand
    {
        public string Id { get; set; }

        public string InvalidMsg
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(Id))
                    msg += "- " + nameof(Id) + " invalid\n";

                return msg;
            }
        }
    }
}
