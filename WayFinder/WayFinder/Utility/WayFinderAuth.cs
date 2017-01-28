using System;
using System.Collections.Generic;
using System.Text;

namespace WayFinder.Utility
{
    //https://gist.github.com/suchithm/03d6247559c772481217
    public partial class WayFinderAuth
    {
        //GoogleInfo googleInfo;
        //ProgressDialog progress;
        //const string googUesrInfoAccessleUrl = "https://www.googleapis.com/oauth2/v1/userinfo?access_token={0}";
        //async Task<bool> fnGetProfileInfoFromGoogle(string access_token)
        //{
        //    progress = ProgressDialog.Show(this, "", "Please wait...");
        //    bool isValid = false;
        //    //Google API REST request
        //    string userInfo = await fnDownloadString(string.Format(googUesrInfoAccessleUrl, access_token));
        //    if (userInfo != "Exception")
        //    {
        //        //step 4: Deserialize the JSON response to get data in class object
        //        googleInfo = JsonConvert.DeserializeObject<GoogleInfo>(userInfo);
        //        isValid = true;
        //    }
        //    else
        //    {
        //        if (progress != null)
        //        {
        //            progress.Dismiss();
        //            progress = null;
        //        }
        //        isValid = false;
        //        oast.MakeText(this, "Connection failed! Please try again", ToastLength.Short).Show();
        //    }
        //    if (progress != null)
        //    {
        //        rogress.Dismiss();
        //        progress = null;
        //    }
        //    return isValid;
        //}

        //async Task<string> fnDownloadString(string strUri)
        //{
        //    var webclient = new WebClient();
        //    string strResultData;
        //    try
        //    {
        //        strResultData = await webclient.DownloadStringTaskAsync(new Uri(strUri));
        //        Console.WriteLine(strResultData);
        //    }
        //    catch
        //    {
        //        strResultData = "Exception";
        //        RunOnUiThread(() =>
        //      Toast.MakeText(this, "Unable to connect to server!!!", ToastLength.Short).Show());
        //    }
        //    finally
        //    {
        //        if (webclient != null)
        //        {
        //            webclient.Dispose();
        //            webclient = null;
        //        }
        //    }
        //    return strResultData;
        //}
    }
}
