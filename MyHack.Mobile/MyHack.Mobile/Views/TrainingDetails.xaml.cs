using MyHack.Mobile.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyHack.Mobile.Views
{
    public partial class TrainingDetails : ContentPage
    {
        public TrainingDetails(UspGetAllTrainingProgram training)
        {
            //App.TrainingDetailsPageViewModel = new ViewModels.TrainingDetailsPageViewModel();
            //App.TrainingDetailsPageViewModel.TrainingProgramId = training.TrainingProgramId;
            BindingContext = new ViewModels.TrainingDetailsPageViewModel(training.TrainingProgramId);
            InitializeComponent();
        }
    }
}
