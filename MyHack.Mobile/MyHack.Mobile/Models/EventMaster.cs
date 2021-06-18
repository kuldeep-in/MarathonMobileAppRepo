using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace MyHack.Mobile.Models
{

    [Table("allevent")]
    public class AllEvent
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public long EventId { get; set; }
        public long CategoryId { get; set; }
        public string EventName { get; set; }
        public string Category { get; set; }
        public DateTime EventDate { get; set; }
        public string Location { get; set; }
    }
}
