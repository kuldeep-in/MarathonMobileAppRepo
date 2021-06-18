using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MyHack.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            GetData();
            
        }

        public static void GetData()
        {
            var dataList = new List<RawData>();

            string url = "http://indiarunning.com/marathon-calendar.html";
            System.Net.WebClient webClient = new System.Net.WebClient();
            webClient.Encoding = System.Text.Encoding.UTF8;
            string result = webClient.DownloadString(url);

            var _doc = new HtmlDocument();
            _doc.LoadHtml(result);

            var tab2 = _doc.DocumentNode.SelectNodes("//div//table//div//div//div//table");

            foreach (HtmlNode tab in tab2.Where(x => x.InnerHtml.Length > 1000))
            {
                foreach (HtmlNode row in tab.SelectNodes("tbody[1]//tr"))
                {
                    var nodes = row.SelectNodes("td");
                    if (nodes.Count == 12 && nodes[0].InnerText == "" && nodes[1].InnerText != "Date" &&
                        (nodes[5].InnerText == "Full"
                        || nodes[6].InnerText == "Half"
                        || nodes[7].InnerText == "10K"
                        || nodes[8].InnerText == "5K"))
                    {
                        dataList.Add(new RawData
                        {
                            Tag = nodes[0].InnerText,
                            EventDate = Convert.ToDateTime(nodes[1].InnerText),
                            EventName = nodes[2].InnerText,
                            Triathlon = nodes[3].InnerText,
                            Ultra = nodes[4].InnerText,
                            FullMarathon = nodes[5].InnerText,
                            HalfMarathon = nodes[6].InnerText,
                            TenK = nodes[7].InnerText,
                            FiveK = nodes[8].InnerText,
                            City = nodes[10].InnerText,
                            State = nodes[11].InnerText,
                        });
                    }
                }
            }
            dataList = dataList.OrderBy(x => x.EventDate).ToList();
            LoadData(dataList);
        }

        public static void LoadData(List<RawData> dataList)
        {

            string url = "http://myhackwebapi.azurewebsites.net/api/rawdata";

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            var jsonString = JsonConvert.SerializeObject(dataList);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
            client.PostAsync(url, content);
            Thread.Sleep(10000);
        }

        public class RawData
        {
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
    }
}
