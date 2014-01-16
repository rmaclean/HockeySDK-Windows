﻿using HockeyApp.Model;
using System.Windows;

namespace HockeyApp.ViewModels
{
    public class FeedbackMessageVM: VMBase
    {
        IFeedbackMessage msg;


        public FeedbackMessageVM(IFeedbackMessage msg)
        {
            this.msg = msg;
        }

        public bool IsIncoming { get { return !IsOutgoing; } }
        public bool IsOutgoing { get { return msg.Via.Equals((int)FeedbackMessage.ViaTypes.API); } }

        /*
        static SolidColorBrush Incoming = new SolidColorBrush(Color.FromArgb(255, 120, 120, 0));
        static SolidColorBrush Outgoing = new SolidColorBrush(Color.FromArgb(255, 120, 0, 120));
        public Brush BgColor { get { return IsIncoming ? Incoming : Outgoing; } }
         */

        public Thickness Margin
        {
            get {
                return IsIncoming ? new Thickness(2, 10, 40, 10)
                    : new Thickness(40, 10, 2, 10);
            }
        }

        public string Created
        {
            get { return msg.Created.ToString("dd/MM/yyyy HH:mm"); }
        }
        
        public string Text
        {
            get { return msg.CleanText; }
        }

        
    }
}
