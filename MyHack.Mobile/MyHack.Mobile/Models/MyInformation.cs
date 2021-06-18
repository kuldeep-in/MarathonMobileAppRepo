using SQLite;
using System;
using System.Collections.Generic;

namespace MyHack.Mobile.Models
{
    [Table("myinformation")]
    public class MyInformation
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        
        public string TrainingPlan { get; set; }
        public string TargetEvent { get; set; }
        public DateTime EventDate { get; set; }
    }

    public class MyScheduleInformation
    {
        public List<PersonalSchedule> MyScheduleList { get; set; }
        public string TargetEvent { get; set; }
        public string TrainingPlan { get; set; }
    }
}
