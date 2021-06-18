using MyHack.WebApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MyHack.Mobile.Data
{
    public class MyHackDataManager
    {
        const string Url = "http://myhackwebapi.azurewebsites.net/api/";
        private string authorizationKey;

        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<IEnumerable<UspGetAllEvents>> GetAllEvents()
        {
            // TODO: use GET to retrieve books
            HttpClient client = GetClient();
            string result = "";
            try
            {
                string eventurl = Url + "event";
                result = await client.GetStringAsync(eventurl);
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.DeserializeObject<IEnumerable<UspGetAllEvents>>(result);
        }

        public async Task<IEnumerable<UspGetAllTrainingProgram>> GetAllTrainingProgram()
        {
            // TODO: use GET to retrieve books
            HttpClient client = GetClient();
            string result = "";
            try
            {
                string eventurl = Url + "TrainingProgram";
                result = await client.GetStringAsync(eventurl);
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.DeserializeObject<IEnumerable<UspGetAllTrainingProgram>>(result);
        }

        public async Task<IEnumerable<UspGetTrainingProgramDetailByTrainingProgramId>> GetTrainingProgramDetailByTrainingProgramId(long programId)
        {
            // TODO: use GET to retrieve books
            HttpClient client = GetClient();
            string result = "";
            try
            {
                string eventurl = Url + "TrainingProgram/" + programId.ToString();
                result = await client.GetStringAsync(eventurl);
            }
            catch (Exception ex)
            {
            }
            return JsonConvert.DeserializeObject<IEnumerable<UspGetTrainingProgramDetailByTrainingProgramId>>(result);
        }
    }
}
