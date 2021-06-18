using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class UspGetTrainingProgramDetailByTrainingProgramId
    {
        [Key]
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
