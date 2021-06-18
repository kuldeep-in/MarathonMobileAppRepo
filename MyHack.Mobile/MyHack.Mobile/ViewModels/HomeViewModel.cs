using MyHack.Mobile.Data;
using MyHack.Mobile.Models;
using MyHack.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class HomeViewModel : MyHackViewModel
    {
        private string _targetEvent;
        private string _eventDate;
        public string TargetEvent
        {
            get { return _targetEvent; }
            set
            {
                if (TargetEvent == value) return;

                _targetEvent = value;
                RaisePropertyChanged("TargetEvent");
            }
        }

        public string EventDate
        {
            get { return _eventDate; }
            set
            {
                if (EventDate == value) return;

                _eventDate = value;
                RaisePropertyChanged("EventDate");
            }
        }

        private string _todaysEvent;
        public string TodaysEvent
        {
            get { return _todaysEvent; }
            set
            {
                if (TodaysEvent == value) return;

                _todaysEvent = value;
                RaisePropertyChanged("TodaysEvent");
            }
        }

        public HomeViewModel()
        {
            
        }
    }
}
