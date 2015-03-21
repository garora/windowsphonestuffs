using System.Collections.Generic;
using ConsumeWebAPI.Model;
using Microsoft.Phone.Controls;
using RestSharp;

namespace ConsumeWebAPI
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            GetServerData();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void GetServerData()
        {
            const string url = "http://crudwithwebapi.azurewebsites.net";
            var client = new RestClient(url);
            var request = new RestRequest("api/serverdata", Method.GET) { RequestFormat = DataFormat.Json };

            client.ExecuteAsync<List<ServerData>>(request, response =>
            {
                LstServerData.ItemsSource = response.Data;
            });

        }


        //private async void GetServerData_HTTPClient(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        using (HttpClient client = new HttpClient())
        //        {
        //            client.BaseAddress = new Uri("http://crudwithwebapi.azurewebsites.net");

        //            var url = "api/serverdata";

        //            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        //            HttpResponseMessage response = await client.GetAsync(url);

        //            if (response.IsSuccessStatusCode)
        //            {
        //                var data = response.Content.ReadAsStringAsync();
        //                var lstData = JsonConvert.DeserializeObject<List<ServerData>>(data.Result.ToString());

        //                LstServerData.ItemsSource = lstData;

        //            }

        //            }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }

        //}

    }
}