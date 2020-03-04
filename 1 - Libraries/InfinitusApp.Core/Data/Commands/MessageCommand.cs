using InfinitusApp.Core.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfinitusApp.Core.Data.Commands
{
    public class MessageCommandBase
    {
        public string Subject { get; set; }

        public string Text { get; set; }
    }

    public class CreateMessageCommand : MessageCommandBase
    {
        public string DataStoreId { get; set; }

        public MessageType MessageType { get; set; }

        public string CreateModelValueErrorsMessage
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(DataStoreId))
                    msg += "DataStoreId not Uninformed";

                return msg;
            }
        }
    }

    public class UpdateMessageCommand : MessageCommandBase
    {
        public string Id { get; set; }
    }

    #region MessageContact

    public class MessageContactBaseCommand
    {
        public string Name { get; set; }

        public string EmailAddress { get; set; }

        public string PhoneNumber { get; set; }

        public string Company { get; set; }
    }

    public class CreateMessageContactCommand : MessageContactBaseCommand
    {
        public string DataStoreId { get; set; }

        public string CreateModelValueErrorsMessage
        {
            get
            {
                var msg = "";

                if (string.IsNullOrEmpty(DataStoreId))
                    msg += "DataStoreId not Uninformed";

                return msg;
            }
        }
    }

    public class UpdateMessageContactCommand : MessageContactBaseCommand
    {
        public string Id { get; set; }
    }

    #endregion

    #region MessageContactGroup

    public class MessageContactGroupBase
    {
        public string Name { get; set; }

        public string Description { get; set; }
    }

    public class CreateMessageContactGroupCommand : MessageContactBaseCommand
    {
        public string DataStoreId { get; set; }
    }

    public class UpdateMessageContactGroupCommand : MessageContactBaseCommand
    {
        public string Id { get; set; }
    }

    #endregion

    #region SendMessageToContact

    public class SendMessageBaseCommand
    {
        public SendMessageBaseCommand()
        {
            Message = new Message();
            Application = new ApplicationInfoExtention();
        }

        public Message Message { get; set; }

        public ApplicationInfoExtention Application { get; set; }
    }

    public class SendEmailMessageToContactCommand : SendMessageBaseCommand
    {
        public SendEmailMessageToContactCommand()
        {
            Contacts = new List<MessageContact>();
        }

        public IList<MessageContact> Contacts { get; set; }
    }

    public class ApplicationInfoExtention
    {
        public string LogoUri { get; set; }

        public string Name { get; set; }

        public string AndroidLink { get; set; }

        public string iOSLink { get; set; }

        public string DataStoreId { get; set; }
    }

    #endregion
}
