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


    }
}