using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

using Xamarin.Forms;

namespace WayFinder
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();
            MobileCenter.Start(typeof(Analytics), typeof(Crashes));
            MainPage = new WayFinder.WayFinderMaps();
            //DependencyService.Get<ISMSSender>().Send("918149910989", "Test");
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
