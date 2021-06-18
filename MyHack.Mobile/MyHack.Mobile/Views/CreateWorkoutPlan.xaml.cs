using MyHack.Mobile.Data;
using MyHack.Mobile.Models;
using MyHack.Mobile.ViewModels;
using MyHack.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace MyHack.Mobile.Views
{
    public partial class CreateWorkoutPlan : ContentPage
    {
        readonly MyHackDataManager manager = new MyHackDataManager();
        readonly IList<UspGetTrainingProgramDetailByTrainingProgramId> scheduleList = new ObservableCollection<UspGetTrainingProgramDetailByTrainingProgramId>();

        public CreateWorkoutPlan()
        {
            BindingContext = App.CreateWorkOutPlanViewModel;
            InitializeComponent();
        }

        private void Picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RaceCategory selected1 = picker1.SelectedItem as RaceCategory;
                long id1 = selected1.CategoryId;
                List<WorkOutPlan> planList = new List<WorkOutPlan>();
                foreach (UspGetAllTrainingProgram item in GlobalVariables.ProgramList.Where(x => x.CategoryId == id1))
                {
                    planList.Add(new WorkOutPlan { WorkOutPlanId = item.TrainingProgramId, Name = item.Name });
                }
                App.CreateWorkOutPlanViewModel.WorkOutPlanList = planList;

                List<RunningEvent> eventList = new List<RunningEvent>();
                foreach (UspGetAllEvents item in GlobalVariables.EventsList.Where(x => x.CategoryId == id1))
                {
                    eventList.Add(new RunningEvent { Id = item.EventId, Name = item.EventDate.ToString("MMMM dd") + ": " + item.Name });
                }

                App.CreateWorkOutPlanViewModel.EventList = eventList;
            }
            catch (Exception ex)
            {
            }

        }

        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var ewew = picker1.SelectedItem;
            }
            catch (Exception ex)
            {
            }

        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            //long programId = GlobalVariables.ProgramList.FirstOrDefault(x => x. == picker1Key).CategoryId;
            try
            {
                DateTime startDate = DateTime.Now;
                string scheduleString = "";
                long numberofDays = 0;

                WorkOutPlan selected2 = picker2.SelectedItem as WorkOutPlan;
                long id2 = selected2.WorkOutPlanId;

                RunningEvent selected3 = picker3.SelectedItem as RunningEvent;
                long id3 = selected3.Id;

                if (picker2.SelectedIndex < 0)
                {
                    await DisplayAlert("Message", "Please select a training plan", "Ok");
                }
                else
                {
                    var result = await manager.GetTrainingProgramDetailByTrainingProgramId(id2);
                    foreach (UspGetTrainingProgramDetailByTrainingProgramId item in result)
                    {
                        scheduleList.Add(item);
                        numberofDays = numberofDays + 7;
                    }
                    if (picker1.SelectedIndex > 0)
                    {
                        startDate = GlobalVariables.EventsList.FirstOrDefault(x => x.EventId == id3).EventDate.AddDays(-(numberofDays) + 1);
                    }
                    GlobalVariables.MyScheduleInformation.MyScheduleList = new List<PersonalSchedule>();
                    foreach (UspGetTrainingProgramDetailByTrainingProgramId item in scheduleList.OrderBy(x => x.Week))
                    {
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day1}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day1 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day2}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day2 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day3}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day3 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day4}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day4 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day5}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day5 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day6}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day6 });
                        startDate = startDate.AddDays(1);
                        scheduleString = scheduleString + $"('{item.Week.ToString()}', '{startDate.ToString("MMMM dd, yyyy")}', '{item.Day7}'),";
                        GlobalVariables.MyScheduleInformation.MyScheduleList.Add(new PersonalSchedule { Id = 0, Week = item.Week.ToString(), Date = startDate.ToString("MMMM dd, yyyy"), Workout = item.Day7 });
                        startDate = startDate.AddDays(1);
                    }
                    scheduleString = scheduleString.Remove(scheduleString.Length - 1);
                    await App.ScheduleRepo.AddSchedule(scheduleString);

                    UspGetAllEvents selectedEvent = GlobalVariables.EventsList.FirstOrDefault(x => x.EventId == id3);
                    await App.InformationRepository.AddInformation(picker2.Items[picker2.SelectedIndex], selectedEvent.Name, selectedEvent.EventDate);
                    //await App.InformationRepository.AddInformation(picker2.Items[picker2.SelectedIndex], picker1.Items[picker1.SelectedIndex]);

                    GlobalVariables.MyScheduleInformation.TargetEvent = picker1.Items[picker1.SelectedIndex];
                    GlobalVariables.MyScheduleInformation.TrainingPlan = picker2.Items[picker2.SelectedIndex];

                    App.MyScheduleViewModel.MyScheduleList = new ObservableCollection<PersonalSchedule>(GlobalVariables.MyScheduleInformation.MyScheduleList);

                    App.MyInfo = new MyInformation();
                    App.MyInfo.TargetEvent = selectedEvent.Name;
                    App.MyInfo.EventDate = selectedEvent.EventDate;
                    App.MyInfo.TrainingPlan = GlobalVariables.MyScheduleInformation.TrainingPlan;
                    var daysdiff = Convert.ToInt32((App.MyInfo.EventDate - DateTime.Now).TotalDays);
                    App.HomeViewModel.TargetEvent = App.MyInfo.TargetEvent;
                    App.HomeViewModel.EventDate = App.MyInfo.EventDate.ToString("dd MMMM yyyy (") + daysdiff.ToString() + " days to go)";
                    App.MyScheduleViewModel.RemainingDays = daysdiff.ToString() + " days to go";

                    await DisplayAlert("Message", "Success", "Ok");
                    await Navigation.PopAsync();
                }
            }
            catch (Exception ex)
            {
            }
        }

    }
}
