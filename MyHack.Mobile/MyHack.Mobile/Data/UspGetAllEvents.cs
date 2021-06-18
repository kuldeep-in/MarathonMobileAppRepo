using System;

namespace MyHack.WebApi.Models
{
    public class UspGetAllEvents
    {
        public long Id { get; set; }
        public long EventId { get; set; }
        public long CategoryId { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string EventBigName { get; set; }
    }
}