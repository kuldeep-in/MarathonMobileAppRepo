using MyHack.Mobile.Models;
using MyHack.Mobile.ViewModels;
using MyHack.Mobile.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MyHack.Mobile
{
    public partial class App : Application
    {
        public static ScheduleRepository ScheduleRepo { get; private set; }
        public static EventRepository EventRepo { get; private set; }
        public static InfoRepository InformationRepository { get; private set; }
        public static MyInformation MyInfo { get; set; }


        public static MyScheduleViewModel MyScheduleViewModel { get; private set; }
        public static MainPageViewModel MainPageViewModel { get; private set; }
        public static TrainingPageViewModel TrainingPageViewModel { get; private set; }
        public static HomeViewModel HomeViewModel { get; private set; }
        public static CreateWorkOutPlanViewModel CreateWorkOutPlanViewModel { get; private set; }
        //public static TrainingDetailsPageViewModel TrainingDetailsPageViewModel { get; set; }

        static App()
        {
            MyScheduleViewModel = new MyScheduleViewModel();
            MainPageViewModel = new MainPageViewModel();
            TrainingPageViewModel = new TrainingPageViewModel();
            CreateWorkOutPlanViewModel = new CreateWorkOutPlanViewModel();
            HomeViewModel = new HomeViewModel();
            MyInfo = new MyInformation();
            //TrainingDetailsPageViewModel = new TrainingDetailsPageViewModel();
        }

        public App(string dbPath)
        {
            InitializeComponent();
            ScheduleRepo = new ScheduleRepository(dbPath);
            InformationRepository = new InfoRepository(dbPath);
            EventRepo = new EventRepository(dbPath);

            MainPage = new NavigationPage(new Home());
            //MainPage = new NavigationPage(new MainPage());
            //MainPage = new MyHack.Mobile.MainPage();
        }

        protected override async void OnStart()
        {
            MyInfo = await App.InformationRepository.GetInformation();
            if (MyInfo != null)
            {
                var daysdiff = Convert.ToInt32((MyInfo.EventDate - DateTime.Now).TotalDays);
                HomeViewModel.TargetEvent = MyInfo == null ? "No event selected" : MyInfo.TargetEvent;
                HomeViewModel.EventDate = MyInfo == null ? "" : MyInfo.EventDate.ToString("dd MMMM yyyy (") + daysdiff.ToString() + " days to go)";

                CreateWorkOutPlanViewModel.TargetEvent = MyInfo == null ? "No event selected" : MyInfo.TargetEvent;
                CreateWorkOutPlanViewModel.TrainingPlan = MyInfo == null ? "" : MyInfo.TrainingPlan;

                TrainingPageViewModel.TrainingPlan = MyInfo == null ? "" : MyInfo.TrainingPlan;

                MyScheduleViewModel.RemainingDays = daysdiff.ToString() + " days to go";
            }
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
