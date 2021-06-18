using MyHack.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class TrainingPageViewModel : MyHackViewModel
    {
        List<UspGetAllTrainingProgram> AllTrainingProgram = new List<UspGetAllTrainingProgram>();
        readonly MyHackDataManager manager = new MyHackDataManager();

        private ObservableCollection<UspGetAllTrainingProgram> _trainingList;
        public ObservableCollection<UspGetAllTrainingProgram> TrainingList
        {
            get { return _trainingList; }
            set
            {
                if (TrainingList != value)
                {
                    _trainingList = value;
                    RaisePropertyChanged("TrainingList");
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

        public TrainingPageViewModel()
        {
            Task.Run(async () =>
            {
                try
                {
                    var trainingcollection = await manager.GetAllTrainingProgram();
                    foreach (UspGetAllTrainingProgram trainingobject in trainingcollection)
                    {
                        AllTrainingProgram.Add(trainingobject);
                    }
                    GlobalVariables.ProgramList = AllTrainingProgram.ToList();
                    TrainingList = new ObservableCollection<UspGetAllTrainingProgram>(AllTrainingProgram);
                }
                catch (Exception ex)
                {
                }
                //finally
                //{
                //    TrainingList = new ObservableCollection<UspGetAllTrainingProgram>(AllTrainingProgram);
                //    TrainingPlan = App.MyInfo == null ? "" : App.MyInfo.TrainingPlan;
                //    App.CreateWorkOutPlanViewModel.TrainingPlan = App.MyInfo == null ? "" : App.MyInfo.TrainingPlan;
                //}
            });
        }
    }
}
