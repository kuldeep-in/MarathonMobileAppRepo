using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace MyHack.Mobile
{
    public class Page1 : TabbedPage

    {
        public Page1()
        {
            this.Title = "My Run";

            //ToolbarItems.Add(new ToolbarItem("Search", "icon.png", () =>
            //{
            //    //logic code goes here
            //}));

            var page1 = new NavigationPage(new MainPage());
            page1.Title = "Events";

            var page2 = new NavigationPage(new TrainingPage());
            page2.Title = "Training";

            var page3 = new NavigationPage(new MySchedulePage());
            page3.Title = "My Schedule";

            Children.Add(page3);
            Children.Add(page1);
            Children.Add(page2);
        }
    }

}