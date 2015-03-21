using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
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

            lstServerData.ItemsSource = new ServerDataViewModel().DisplayData(GetServerData());

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private List<ServerData> GetServerData()
        {
            const string uri = "http://crudwithwebapi.azurewebsites.net/api/serverdata";
            var serverData = new List<ServerData>();
            var client = new WebClient();
            client.Headers["Accept"] = "application/json";
            client.DownloadStringAsync(new Uri(uri));
            client.DownloadStringCompleted += (s1, e1) =>
            {
                serverData = new List<ServerData>(JsonConvert.DeserializeObject<ServerData[]>(e1.Result.ToString(CultureInfo.InvariantCulture)));
            };

            return serverData;
        }

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