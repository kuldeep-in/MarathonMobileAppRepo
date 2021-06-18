using MyHack.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.ViewModels
{
    public class TrainingDetailsPageViewModel : MyHackViewModel
    {
        List<UspGetTrainingProgramDetailByTrainingProgramId> Details = new List<UspGetTrainingProgramDetailByTrainingProgramId>();
        readonly MyHackDataManager manager = new MyHackDataManager();

        private ObservableCollection<UspGetTrainingProgramDetailByTrainingProgramId> _detailsList;
        public ObservableCollection<UspGetTrainingProgramDetailByTrainingProgramId> DetailsList
        {
            get { return _detailsList; }
            set
            {
                if (DetailsList != value)
                {
                    _detailsList = value;
                    RaisePropertyChanged("DetailsList");
                }
            }
        }

        private long _trainingProgramId;
        public long TrainingProgramId
        {
            get { return _trainingProgramId; }
            set
            {
                if (TrainingProgramId == value) return;

                _trainingProgramId = value;
                //RaisePropertyChanged("TrainingProgramId");
            }
        }

        public TrainingDetailsPageViewModel(long id)
        {
            Task.Run(async () =>
            {
                try
                {
                    var result = await manager.GetTrainingProgramDetailByTrainingProgramId(id);
                    foreach (UspGetTrainingProgramDetailByTrainingProgramId item in result)
                    {
                        Details.Add(item);
                    }
                }
                catch (Exception ex)
                {
                }
                finally
                {
                    DetailsList = new ObservableCollection<UspGetTrainingProgramDetailByTrainingProgramId>(Details);
                }
            });
        }
    }
}
