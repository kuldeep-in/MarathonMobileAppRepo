using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class TrainingProgram
    {
        [Key]
        public int TrainingProgramId { get; set; }
    }
}
