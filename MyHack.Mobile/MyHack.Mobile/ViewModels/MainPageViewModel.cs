using MyHack.Mobile.Data;
using MyHack.Mobile.Models;
using MyHack.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class MainPageViewModel : MyHackViewModel
    {
        List<MainPageModel> AllEventList = new List<MainPageModel>();
        readonly MyHackDataManager manager = new MyHackDataManager();

        private ObservableCollection<MainPageModel> _eventList;
        public ObservableCollection<MainPageModel> EventList
        {
            get { return _eventList; }
            set
            {
                if (EventList != value)
                {
                    _eventList = value;
                    RaisePropertyChanged("EventList");
                }
            }
        }

        private string _targetEvent;
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

        private string _eventDate;
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

        public MainPageViewModel()
        {
            //TargetEvent = App.MyInfo == null ? "" : App.MyInfo.TargetEvent;
            //EventDate = App.MyInfo == null ? "" : App.MyInfo.EventDate.ToString("dd MMMM yyyy");
            string eventString = "";
            Task.Run(async () =>
            {
                try
                {
                    var eventcollection = await manager.GetAllEvents();
                    foreach (UspGetAllEvents eventobj in eventcollection)
                    {
                        GlobalVariables.EventsList.Add(eventobj);
                        eventString = eventString + $"({eventobj.EventId}, {eventobj.CategoryId}, '{eventobj.Name.Replace('\'', ' ')}', '{eventobj.Category}', '{eventobj.EventDate}', '{eventobj.Location}'),";
                        if (!AllEventList.Any(x => x.Name == eventobj.Name))
                        {
                            AllEventList.Add(new MainPageModel
                            {
                                Category = eventobj.Category,
                                EventId = eventobj.EventId,
                                Name = eventobj.Name,
                                EventDate = eventobj.EventDate.ToString("dd MMMM yyyy"),
                                Location = eventobj.Location
                            });
                        }
                    }
                    EventList = new ObservableCollection<MainPageModel>(AllEventList);

                    eventString = eventString.Remove(eventString.Length - 1);
                    await App.EventRepo.AddEvent(eventString);

                }
                catch (Exception ex)
                {
                }
            });

        }

        public class MainPageModel
        {
            public long EventId { get; set; }
            public string Category { get; set; }
            public string Name { get; set; }
            public string Location { get; set; }
            public string EventDate { get; set; }
        }
    }
}
