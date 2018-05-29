using InterviewDemo.Core.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace InterviewDemo.Mobile
{
    public class DataAccess
    {


        private static readonly Lazy<DataAccess> lazy = new Lazy<DataAccess>(() => new DataAccess());
        public static DataAccess Instance { get { return lazy.Value; } }


        private HttpClient client = new HttpClient();
        private string bearerToken = null;
        private DateTime aliveTime;


        private DataAccess()
        {

        }

        private async Task GetToken()
        {
            string action = @"api/v1/authorize";
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.BaseURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                TokenRequest token = new TokenRequest() {
                    Username = "asheley",
                    Password = "Password01!",
                };


                var rawData = JsonConvert.SerializeObject(token);
                var httpContent = new StringContent(rawData, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(action, httpContent);


                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //employees = 
                    var returnToken = Newtonsoft.Json.JsonConvert.DeserializeObject<TokenResponse>(content);

                    bearerToken = returnToken.token;
                    aliveTime = DateTime.Now.AddMinutes(returnToken.alive - 1);
                }

                return;
            }
        }

        public async Task<ObservableCollection<Employee>> GetData()
        {
            if (string.IsNullOrEmpty(bearerToken) || DateTime.Now >= aliveTime)
            {
                await GetToken();
            }

            ObservableCollection<Employee> returnData = new ObservableCollection<Employee>();

            string action = @"api/v1/employees";
            using (client = new HttpClient())
            {
                client.BaseAddress = new Uri(Settings.BaseURL);

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + bearerToken);

                var response = await client.GetAsync(action);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    //employees = 
                    returnData = new ObservableCollection<Employee>(Newtonsoft.Json.JsonConvert.DeserializeObject<List<Employee>>(content));
                }

                return returnData;
            }


           
        }



    }
}
