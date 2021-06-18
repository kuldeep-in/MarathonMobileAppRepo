using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.Data
{
    public class UspGetAllTrainingProgram
    {
        public long TrainingProgramId { get; set; }
        public long CategoryId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Level { get; set; }
        public int NumberOfDays { get; set; }
    }
}
