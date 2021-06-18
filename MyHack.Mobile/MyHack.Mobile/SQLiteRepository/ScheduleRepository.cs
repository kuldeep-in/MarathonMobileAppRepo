using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MyHack.Mobile.Models;

namespace MyHack.Mobile
{
    public class ScheduleRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public ScheduleRepository(string dbPath)
        {
            try
            {
                conn = new SQLiteAsyncConnection(dbPath);
                conn.CreateTableAsync<PersonalSchedule>().Wait();
            }
            catch (Exception ex)
            { }
        }

        public async Task AddSchedule(string scheduleString)
        {
            try
            {
                await conn.ExecuteAsync("DELETE FROM personalschedule");
                string sqlQuery = $"INSERT INTO personalschedule (Week, Date, Workout) VALUES {scheduleString}";
                await conn.ExecuteAsync(sqlQuery);
                //var result = await conn.InsertAsync(scheduleList);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error:", ex.Message);
            }
        }

        public async Task<List<PersonalSchedule>> GetSchedule()
        {
            List<PersonalSchedule> result = new List<PersonalSchedule>();
            try
            {
                result = await conn.Table<PersonalSchedule>().ToListAsync();
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
