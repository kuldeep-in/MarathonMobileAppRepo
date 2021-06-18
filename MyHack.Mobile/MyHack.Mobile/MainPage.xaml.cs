using MyHack.Mobile.Data;
using MyHack.Mobile.Helper;
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
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            //BindingContext = model;

            BindingContext = App.MainPageViewModel;
            InitializeComponent();
        }

        //async Task GetAllEvents()//(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        var eventcollection = await manager.GetAllEvents();
        //        foreach (UspGetAllEvents eventobj in eventcollection)
        //        {
        //            events.Add(eventobj);
        //        }
        //    }
        //    catch (Exception ex)
        //    { }
        //}
        protected override void OnAppearing()
        {
            App.MainPageViewModel.TargetEvent = App.MyInfo == null ? "" : App.MyInfo.TargetEvent;
            App.MainPageViewModel.EventDate = App.MyInfo == null ? "" : App.MyInfo.EventDate.ToString("dd MMMM yyyy");
        }

    }
}
