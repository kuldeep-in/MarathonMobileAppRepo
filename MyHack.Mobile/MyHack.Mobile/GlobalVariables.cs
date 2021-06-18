using MyHack.Mobile.Data;
using MyHack.Mobile.Models;
using MyHack.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile
{
    public static class GlobalVariables
    {
        public static List<UspGetAllEvents> EventsList = new List<UspGetAllEvents>();
        public static List<UspGetAllTrainingProgram> ProgramList = new List<UspGetAllTrainingProgram>();
        public static MyScheduleInformation MyScheduleInformation = new MyScheduleInformation();
    }
}
