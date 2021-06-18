using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class UspGetAllTrainingProgram
    {
        [Key]
        public long TrainingProgramId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int NumberOfDays { get; set; }
    }
}
