using System;
using System.Threading.Tasks;
using SQLite;
using MyHack.Mobile.Models;

namespace MyHack.Mobile
{
    public class InfoRepository
    {
        private readonly SQLiteAsyncConnection conn;

        public string StatusMessage { get; set; }

        public InfoRepository(string dbPath)
        {
            try
            {
                conn = new SQLiteAsyncConnection(dbPath);
                conn.CreateTableAsync<MyInformation>().Wait();
            }
            catch (Exception ex)
            { }
        }

        public async Task AddInformation(string trainingPlan, string trainingEvent, DateTime eventDate)
        {
            try
            {
                await conn.ExecuteAsync("Delete FROM myinformation");
                var result = await conn.InsertAsync(new MyInformation { TrainingPlan = trainingPlan, TargetEvent = trainingEvent, EventDate = eventDate });
                StatusMessage = string.Format("{0} record(s) added)", result);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error:", ex.Message);
            }
        }

        public async Task<MyInformation> GetInformation()
        {
            MyInformation result = new MyInformation();
            try
            {
                result = await conn.Table<MyInformation>().FirstOrDefaultAsync();
            }
            catch (Exception ex)
            { }
            return result;
        }
    }
}
