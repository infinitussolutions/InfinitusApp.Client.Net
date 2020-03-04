using GalaSoft.MvvmLight;
using System;

namespace InfinitusApp.Core.Data.DataModels
{
    public class ChatMessage : ObservableObject
    {
        private string _text;

        public string Text
        {
            get { return _text; }
            set { Set(ref _text, value); }
        }

        private DateTime _date;

        public DateTime Date
        {
            get { return _date; }
            set { Set(ref _date, value); }
        }

        //public string DateDisplay => Date.Humanize();

        private bool _isIncoming;

        public bool IsIncoming
        {
            get { return _isIncoming; }
            set { Set(ref _isIncoming, value); }
        }

        private bool _sentBySelfUser;

        public bool SentBySelfUser
        {
            get { return _sentBySelfUser; }
            set { Set(ref _sentBySelfUser, value); }
        }
    }
}