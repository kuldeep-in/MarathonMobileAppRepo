using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyHack.WebApi.Models
{
    public class RawData
    {
        [Key]
        public long RawDataId { get; set; }
        public string Tag { get; set; }
        public DateTime EventDate { get; set; }
        public string EventName { get; set; }
        public string Triathlon { get; set; }
        public string Ultra { get; set; }
        public string FullMarathon { get; set; }
        public string HalfMarathon { get; set; }
        public string TenK { get; set; }
        public string FiveK { get; set; }
        public string City { get; set; }
        public string State { get; set; }

    }

    public class RawTempData
    {
        [Key]
        public long RawDataId { get; set; }
        public string EventName { get; set; }
    }
}