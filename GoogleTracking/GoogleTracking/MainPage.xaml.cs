using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GoogleTracking
{

    public partial class MainPage : ContentPage
    {
        private string latitude;
        private string longitude;
        private string link;

        public MainPage()
        {
            InitializeComponent();
        }

        private async Task Locate_Clicked(object sender, EventArgs e)
        {
            //Get latitude and longitude
            var locator = CrossGeolocator.Current;
            locator.DesiredAccuracy = 50;

            var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

            latitude = position.Latitude.ToString();
            longitude = position.Longitude.ToString();

            //Display latitude and longitude
            labelLatitude.Text = latitude;
            labelLongitude.Text = longitude;
            link = String.Format("https://maps.google.com/?q={0},{1}", latitude, longitude);

            //Display google link at label
            labelLink.Text = link;
        }

        private void Open_Clicked(object sender, EventArgs e)
        {
            //Open google map
            if (!String.IsNullOrWhiteSpace(latitude) && !String.IsNullOrWhiteSpace(longitude))
                Device.OpenUri(new Uri(link));

        }
    }
}
