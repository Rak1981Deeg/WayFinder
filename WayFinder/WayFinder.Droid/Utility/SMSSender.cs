using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Telephony;

namespace WayFinder.Droid
{
    public class SMSSender: ISMSSender
    {
        public void Send(string mobileNo, string message)
        {
            SmsManager.Default.SendTextMessage(mobileNo, null, message, null, null);
        }
        //public void Send2(string mobileNo, string message)
        //{
            //var smsUri = Android.Net.Uri.Parse("smsto:1234567890");
            //var smsIntent = new Intent(Intent.ActionSendto, smsUri);
            //smsIntent.PutExtra("sms_body", "hello from Xamarin.Android");
            //StartActivity(smsIntent);
        //}
    }
}