using MyHack.Mobile.Data;
using MyHack.Mobile.Models;
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
    public partial class CreateSchedule : ContentPage
    {
        readonly MyHackDataManager manager = new MyHackDataManager();
        readonly IList<UspGetTrainingProgramDetailByTrainingProgramId> scheduleList = new ObservableCollection<UspGetTrainingProgramDetailByTrainingProgramId>();
        List<PersonalSchedule> MyScheduleList = new List<PersonalSchedule>();

        Picker picker0 = new Picker
        {
            Title = "Select a Category",
            Margin = new Thickness(0, 15, 0, 0)
        };
        Picker picker1 = new Picker
        {
            Title = "Select an Event",
            Margin = new Thickness(0, 15, 0, 0)
        };
        Picker picker2 = new Picker
        {
            Title = "Select Training plan",
            Margin = new Thickness(0, 15, 0, 0)
        };
        Dictionary<long, string> dictionary0 = new Dictionary<long, string>();
        Dictionary<long, string> dictionary1 = new Dictionary<long, string>();
        Dictionary<long, string> dictionary2 = new Dictionary<long, string>();
        long picker0Key = 0;
        long picker1Key = 0;
        long picker2Key = 0;

        public CreateSchedule()
        {
            this.Title = "Create";

            dictionary0.Add(1, "5K");
            dictionary0.Add(2, "10K");
            dictionary0.Add(3, "Half");
            dictionary0.Add(4, "Full");

            foreach (string item in dictionary0.Values)
            {
                picker0.Items.Add(item);
            }

            foreach (UspGetAllTrainingProgram item in GlobalVariables.ProgramList)
            {
                dictionary2.Add(item.TrainingProgramId, item.Name);
            }

            picker1.Items.Add("-- Select --");

            picker0.SelectedIndexChanged += Picker0_SelectedIndexChanged;
            picker1.SelectedIndexChanged += Picker1_SelectedIndexChanged;
            picker2.SelectedIndexChanged += Picker2_SelectedIndexChanged;

            Button createButton = new Button
            {
                Text = "Create Your Plan",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center
            };
            createButton.Clicked += CreateButton_Clicked;

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    //header,
                    picker0,
                    picker1,
                    picker2 ,
                    createButton
                }
            };
        }

        private void Picker0_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                picker0Key = dictionary0.FirstOrDefault(x => x.Value == picker0.Items[picker0.SelectedIndex]).Key;
                picker1.SelectedIndex = -1;
                picker1.Items.Clear();
                picker1.Items.Add("-- Select --");
                picker1.SelectedIndex = 0;
                if (picker0.SelectedIndex >= 0)
                {
                    dictionary1.Clear();
                    foreach (UspGetAllEvents item in GlobalVariables.EventsList.Where(x => x.CategoryId == picker0Key))
                    {
                        dictionary1.Add(item.EventId, item.EventDate.ToString("MMMM dd") + ": " + item.Name);
                    }

                    foreach (string item in dictionary1.Values)
                    {
                        picker1.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }

        private void Picker1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (picker1.SelectedIndex != -1)
                {
                    picker1Key = dictionary1.FirstOrDefault(x => x.Value == picker1.Items[picker1.SelectedIndex]).Key;
                    picker2.SelectedIndex = -1;
                    picker2.Items.Clear();
                    picker2.Items.Add("-- Select --");
                    picker2.SelectedIndex = 0;
                    if (picker1.SelectedIndex < 1)
                    {
                        foreach (string item in dictionary2.Values)
                        {
                            picker2.Items.Add(item);
                        }
                    }
                    else
                    {
                        //long catid = GlobalVariables.EventsList.FirstOrDefault(x => x.EventId == picker1Key).CategoryId;
                        foreach (UspGetAllTrainingProgram item in GlobalVariables.ProgramList.Where(x => x.CategoryId == picker0Key))
                        {
                            picker2.Items.Add(item.Name);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void Picker2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (picker2.SelectedIndex != -1)
            {
                picker2Key = dictionary2.FirstOrDefault(x => x.Value == picker2.Items[picker2.SelectedIndex]).Key;
            }
        }

        private async void CreateButton_Clicked(object sender, EventArgs e)
        {
            //long programId = GlobalVariables.ProgramList.FirstOrDefault(x => x. == picker1Key).CategoryId;
            DateTime startDate = DateTime.Now;
            string scheduleString = "";
            long numberofDays = 0;
            if (picker2.SelectedIndex < 1)
            {
                await DisplayAlert("Message", "Please select a training plan", "Ok");
            }
            else
            {
                var result = await manager.GetTrainingProgramDetailByTrainingProgramId(picker2Key);
                foreach (UspGetTrainingProgramDetailByTrainingProgramId item in result)
                {
                    scheduleList.Add(item);
                    numberofDays = numberofDays + 7;
                }
                if (picker1.SelectedIndex > 0)
                {
                    startDate = GlobalVariables.EventsList.FirstOrDefault(x => x.EventId == picker1Key).EventDate.AddDays(-(numberofDays) + 1);
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

                UspGetAllEvents selectedEvent = GlobalVariables.EventsList.FirstOrDefault(x => x.EventId == picker1Key);
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
    }
}