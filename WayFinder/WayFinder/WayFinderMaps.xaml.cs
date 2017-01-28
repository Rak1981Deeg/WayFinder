using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace WayFinder
{
	public partial class WayFinderMaps : ContentPage
	{
        Geocoder geoCoder;
        public WayFinderMaps ()
		{
			InitializeComponent ();
            geoCoder = new Geocoder();
        }


        async void OnGeocodeButtonClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(inputEntry.Text))
            {
                var address = inputEntry.Text;
                var approximateLocations = await geoCoder.GetPositionsForAddressAsync(address);
                foreach (var position in approximateLocations)
                {
                    geocodedOutputLabel.Text += position.Latitude + ", " + position.Longitude + "\n";
                }
            }
        }

    }
}
