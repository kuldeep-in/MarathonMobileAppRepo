using SQLite;

namespace MyHack.Mobile.Models
{
    [Table("personalschedule")]
    public class PersonalSchedule
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Week { get; set; }
        public string Date { get; set; }
        public string Workout { get; set; }
    }
}
