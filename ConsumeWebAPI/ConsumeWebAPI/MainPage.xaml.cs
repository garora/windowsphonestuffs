using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConsumeWebAPI.Model;
using Microsoft.Phone.Controls;
using Newtonsoft.Json;

namespace ConsumeWebAPI
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            var data = GetServerData();
            LstServerData.ItemsSource = new ServerDataViewModel().DisplayData(data.Result);

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }
        private async Task<List<ServerData>> GetServerData()
        {
            var serverData = new List<ServerData>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://crudwithwebapi.azurewebsites.net");

                const string url = "api/serverdata/1";

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.GetAsync(url);

                if (!response.IsSuccessStatusCode) return serverData;

                var data = response.Content.ReadAsStringAsync();
                serverData = JsonConvert.DeserializeObject<List<ServerData>>(data.Result);
            }

            return serverData;
        }
        //private List<ServerData> GetServerData()
        //{
        //    const string uri = "http://crudwithwebapi.azurewebsites.net/api/serverdata";
        //    var serverData = new List<ServerData>();
        //    var client = new WebClient();
        //    client.Headers["Accept"] = "application/json";
        //    client.DownloadStringAsync(new Uri(uri));
        //    client.DownloadStringCompleted += (s1, e1) =>
        //    {
        //        serverData =
        //            JsonConvert.DeserializeObject<List<ServerData>>(e1.Result.ToString(CultureInfo.InvariantCulture));
        //    };

        //    return serverData;
        //}

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}