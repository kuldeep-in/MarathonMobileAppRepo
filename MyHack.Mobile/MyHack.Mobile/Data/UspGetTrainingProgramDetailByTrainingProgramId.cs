using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.Data
{
    public class UspGetTrainingProgramDetailByTrainingProgramId
    {
        public long TrainingProgramDetailId { get; set; }
        public string Name { get; set; }
        public long TrainingProgramId { get; set; }
        public int Week { get; set; }
        public string Day1 { get; set; }
        public string Day2 { get; set; }
        public string Day3 { get; set; }
        public string Day4 { get; set; }
        public string Day5 { get; set; }
        public string Day6 { get; set; }
        public string Day7 { get; set; }
    }
}
