using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Microsoft.Azure.Mobile;
using Android.Content;
using Xamarin.Forms;

namespace WayFinder.Droid
{
	[Activity (Label = "WayFinder", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{

        public static MainActivity Instance;
        GPSServiceBinder _binder;
        GPSServiceConnection _gpsServiceConnection;
        Intent _gpsServiceIntent;
        private GPSServiceReciever _receiver;

        protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

            Instance = this;

            //SetContentView(Resource.Layout.Main);

            global::Xamarin.Forms.Forms.Init (this, bundle);
            global::Xamarin.FormsMaps.Init(this, bundle);

            MobileCenter.Configure("fd4a605d-c4ae-44e0-a9e3-b090900fe133");

            var width = Resources.DisplayMetrics.WidthPixels;
            var height = Resources.DisplayMetrics.HeightPixels;
            var density = Resources.DisplayMetrics.Density;

            App.ScreenWidth = (width - 0.5f) / density;
            App.ScreenHeight = (height - 0.5f) / density;

            #region send sms
            //var sendSMS = FindViewById<Button>(Resource.Id.sendSMS);

            //sendSMS.Click += (sender, e) => {
            //    SmsManager.Default.SendTextMessage("1234567890", null, "hello from Xamarin.Android", null, null);
            //};

            //var sendSMSIntent = FindViewById<Button>(Resource.Id.sendSMSIntent);

            //sendSMSIntent.Click += (sender, e) => {
            //    var smsUri = Android.Net.Uri.Parse("smsto:1234567890");
            //    var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            //    smsIntent.PutExtra("sms_body", "hello from Xamarin.Android");
            //    StartActivity(smsIntent);
            //};
            #endregion


            RegisterService();
            LoadApplication (new WayFinder.App ());
		}


        protected override void OnResume()
        {
            base.OnResume();
            RegisterBroadcastReceiver();
        }

        protected override void OnPause()
        {
            base.OnPause();
            UnRegisterBroadcastReceiver();
        }

        private void RegisterService()
        {
            _gpsServiceConnection = new GPSServiceConnection(_binder);
            _gpsServiceIntent = new Intent(Android.App.Application.Context, typeof(GPSService));
            BindService(_gpsServiceIntent, _gpsServiceConnection, Bind.AutoCreate);
        }
        private void RegisterBroadcastReceiver()
        {
            IntentFilter filter = new IntentFilter(GPSServiceReciever.LOCATION_UPDATED);
            filter.AddCategory(Intent.CategoryDefault);
            _receiver = new GPSServiceReciever();
            RegisterReceiver(_receiver, filter);
        }

        private void UnRegisterBroadcastReceiver()
        {
            UnregisterReceiver(_receiver);
        }

        public void UpdateUI(Intent intent)
        {
            MessagingCenter.Send(intent, intent.Action);
            //_locationText.Text = intent.GetStringExtra("Location");
            //_addressText.Text = intent.GetStringExtra("Address");
            //_remarksText.Text = intent.GetStringExtra("Remarks");
        }

        [BroadcastReceiver]
        internal class GPSServiceReciever : BroadcastReceiver
        {
            public static readonly string LOCATION_UPDATED = "LOCATION_UPDATED";
            public override void OnReceive(Context context, Intent intent)
            {
                if (intent.Action.Equals(LOCATION_UPDATED))
                {
                    MainActivity.Instance.UpdateUI(intent);
                }

            }
        }
    }
}

