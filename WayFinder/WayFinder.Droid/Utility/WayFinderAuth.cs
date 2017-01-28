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
using Xamarin.Auth;


namespace WayFinder.Droid.Utility
{
    public partial class WayFinderAuth: IWayFinderAuth
    {
        //LoginByGoogle in Xamrin.Android
        //Step 2.OAuth2Authenticator request
        public void LoginByGoogle(bool allowCancel)
        {
            //var auth = new OAuth2Authenticator(clientId: "847549521106-35dvaoe5jafmc5tuk2ll5054********.apps.googleusercontent.com",
            //scope: "https://www.googleapis.com/auth/userinfo.email",
            //authorizeUrl: new Uri("https://accounts.google.com/o/oauth2/auth"),
            //redirectUrl: new Uri("https://www.googleapis.com/plus/v1/people/me"),
            //getUsernameAsync: null);
            //auth.AllowCancel = allowCancel;

            //auth.Completed += async (sender, e) =>
            //{
            //    if (!e.IsAuthenticated)
            //    {
            //        Toast.MakeText(this, "Fail to authenticate!", ToastLength.Short).Show();
            //        return;
            //    }
            //    string access_token;
            //    e.Account.Properties.TryGetValue("access_token", out access_token);
            //    //step:3 Google API Request to get Profile Information
            //    if (await fnGetProfileInfoFromGoogle(access_token))
            //    {
            //        Toast.MakeText(this, "Authentcated successfully", ToastLength.Short).Show();
            //    }
            //};
            //var intent = auth.GetUI(this);
            //StartActivity(intent);
        }
    }
}