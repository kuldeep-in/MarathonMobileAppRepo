using MyHack.Mobile.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class MyScheduleViewModel : MyHackViewModel
    {
        private ObservableCollection<PersonalSchedule> _myScheduleList;
        public ObservableCollection<PersonalSchedule> MyScheduleList
        {
            get { return _myScheduleList; }
            set
            {
                if (MyScheduleList != value)
                {
                    _myScheduleList = value;
                    RaisePropertyChanged("MyScheduleList");
                }
            }
        }

        private string _trainingPlan;
        public string TrainingPlan
        {
            get { return _trainingPlan; }
            set
            {
                if (TrainingPlan == value) return;

                _trainingPlan = value;
                RaisePropertyChanged("TrainingPlan");
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

        private bool _refreshRequired;
        public bool RefreshRequired
        {
            get { return _refreshRequired; }
            set
            {
                if (RefreshRequired == value) return;

                _refreshRequired = value;
            }
        }

        private string _remainingDays;
        public string RemainingDays
        {
            get { return _remainingDays; }
            set
            {
                if (RemainingDays == value) return;

                _remainingDays = value;
                RaisePropertyChanged("RemainingDays");
            }
        }

        public int Img { get; set; }
        public MyScheduleViewModel()
        {
            RefreshRequired = true;
        }

        public async Task LoadData()
        {
            Img = 1;
            if (RefreshRequired == true)
            {
                MyInformation info = await App.InformationRepository.GetInformation();
                GlobalVariables.MyScheduleInformation.TargetEvent = (info == null) ? "" : info.TargetEvent;
                GlobalVariables.MyScheduleInformation.TrainingPlan = (info == null) ? "" : info.TrainingPlan;
                GlobalVariables.MyScheduleInformation.MyScheduleList = new List<PersonalSchedule>();
                GlobalVariables.MyScheduleInformation.MyScheduleList = await App.ScheduleRepo.GetSchedule();
                MyScheduleList = new ObservableCollection<PersonalSchedule>(GlobalVariables.MyScheduleInformation.MyScheduleList);
                PersonalSchedule todays = GlobalVariables.MyScheduleInformation.MyScheduleList.FirstOrDefault(x => x.Date == DateTime.Now.ToString("MMMM dd, yyyy"));
                TodaysEvent = "No Workout";
                if (todays != null)
                {
                    TodaysEvent = "Today's Workout: " + todays.Workout;
                }
                App.HomeViewModel.TodaysEvent = this.TodaysEvent;

                TargetEvent = (info == null) ? "" : info.TargetEvent;
                TrainingPlan = (info == null) ? "" : info.TrainingPlan;
                RefreshRequired = false;
            }
        }
    }
}
