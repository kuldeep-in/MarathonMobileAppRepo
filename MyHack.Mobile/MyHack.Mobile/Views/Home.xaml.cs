using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyHack.Mobile.Views
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            BindingContext = App.HomeViewModel;
            InitializeComponent();
        }

        private void SettingsClicked(object sender, EventArgs e)
        {
            ToolbarItem tbi = (ToolbarItem)sender;
            this.DisplayAlert("Selected!", tbi.Text, "OK");

        }

        async Task GetAllEvents()//(object sender, EventArgs e)
        {
            try
            {
                App.MyInfo = await App.InformationRepository.GetInformation();
            }
            catch (Exception ex)
            { }
        }

        void OnScheduleTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushAsync(new MySchedulePage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void OnCreateTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushAsync(new CreateWorkoutPlan());
                //Navigation.PushAsync(new CreateSchedule());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void OnEventTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushAsync(new MainPage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void OnPlanTapped(object sender, EventArgs args)
        {
            try
            {
                Navigation.PushAsync(new TrainingPage());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
