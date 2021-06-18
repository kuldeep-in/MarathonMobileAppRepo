using MyHack.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class CreateWorkOutPlanViewModel : MyHackViewModel
    {
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

        //<RaceCategory> CategoryList1 = new List<RaceCategory>();
        //public IList<RaceCategory> CatList => CategoryList1;

        private IList<RaceCategory> _categoryList;// = new List<RaceCategory>();
        public IList<RaceCategory> CategoryList
        {
            get { return _categoryList; }
            set
            {
                if (CategoryList != value)
                {
                    _categoryList = value;
                    RaisePropertyChanged("CategoryList");
                }
            }
        }

        private IList<WorkOutPlan> _workOutPlanList;
        public IList<WorkOutPlan> WorkOutPlanList
        {
            get { return _workOutPlanList; }
            set
            {
                if (WorkOutPlanList != value)
                {
                    _workOutPlanList = value;
                    RaisePropertyChanged("WorkOutPlanList");
                }
            }
        }

        private IList<RunningEvent> _eventList;
        public IList<RunningEvent> EventList
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


        public CreateWorkOutPlanViewModel()
        {
            CategoryList = new List<RaceCategory>()
                {
                    new RaceCategory { CategoryId = 1, CategoryName = "5K" },
                    new RaceCategory { CategoryId = 2, CategoryName = "10K" },
                    new RaceCategory { CategoryId = 3, CategoryName = "Half Marathon" },
                    new RaceCategory { CategoryId = 4, CategoryName = "Marathon" },
                };
        }
    }

    public class RaceCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        //public override string ToString()
        //{
        //    return this.CategoryName;
        //}
    }

    public class WorkOutPlan
    {
        public long WorkOutPlanId { get; set; }
        public string Name { get; set; }

    }


    public class RunningEvent
    {
        public long Id { get; set; }
        public string Name { get; set; }
    }

}
