using MyHack.Mobile.Data;
using MyHack.Mobile.Views;
using MyHack.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyHack.Mobile
{
    public partial class TrainingPage : ContentPage
    {
        public bool IsBusy = true;

        public TrainingPage()
        {
            //BindingContext = trainings;
            BindingContext = App.TrainingPageViewModel;
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            App.TrainingPageViewModel.TrainingPlan = App.MyInfo == null ? "" : App.MyInfo.TrainingPlan;
        }

        async void OnItemTapped(object sender, ItemTappedEventArgs e)
        {

            UspGetAllTrainingProgram training = (UspGetAllTrainingProgram)e.Item;
            //await DisplayAlert(training.Name, training.TrainingProgramId.ToString(), "ok");
            await this.Navigation.PushAsync(new TrainingDetails(training));
        }
    }
}
