using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using MyHack.Mobile.Models;

namespace MyHack.Mobile
{
    public class EventRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public EventRepository(string dbPath)
        {
            try
            {
                conn = new SQLiteAsyncConnection(dbPath);
                conn.CreateTableAsync<AllEvent>().Wait();
            }
            catch (Exception ex)
            { }
        }

        public async Task AddEvent(string eventString)
        {
            try
            {
                await conn.ExecuteAsync("DELETE FROM allevent");
                string sqlQuery = $"INSERT INTO allevent (EventId, CategoryId, EventName, Category, EventDate, Location) VALUES {eventString}";
                await conn.ExecuteAsync(sqlQuery);
                //var result = await conn.InsertAsync(scheduleList);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error:", ex.Message);
            }
        }

        public async Task<List<AllEvent>> GetEvent()
        {
            List<AllEvent> result = new List<AllEvent>();
            try
            {
                result = await conn.Table<AllEvent>().ToListAsync();
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
