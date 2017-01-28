using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Views;
using Android.Runtime;
using Android.Telephony;

namespace WayFinder.GPS
{
    [Activity(Label = "WayFinder.GPS", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        TextView _locationText;
        TextView _addressText;
        TextView _remarksText;

        GPSServiceBinder _binder;
        GPSServiceConnection _gpsServiceConnection;
        Intent _gpsServiceIntent;
        private GPSServiceReciever _receiver;

        public static MainActivity Instance;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Instance = this;
            SetContentView(Resource.Layout.Main);

            _addressText = FindViewById<TextView>(Resource.Id.txtAddress);
            _locationText = FindViewById<TextView>(Resource.Id.txtLocation);
            _remarksText = FindViewById<TextView>(Resource.Id.txtRemarks);

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
            _locationText.Text = intent.GetStringExtra("Location");
            _addressText.Text = intent.GetStringExtra("Address");
            _remarksText.Text = intent.GetStringExtra("Remarks");
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

