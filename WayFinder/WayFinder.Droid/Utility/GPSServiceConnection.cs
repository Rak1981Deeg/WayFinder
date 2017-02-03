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

namespace WayFinder.Droid
{
    public class GPSServiceConnection : Java.Lang.Object, IServiceConnection
    {

        GPSServiceBinder _binder;

        public event Action Connected;
        public GPSServiceConnection(GPSServiceBinder binder)
        {
            if (binder != null)
                this._binder = binder;
        }

        public void OnServiceConnected(ComponentName name, IBinder service)
        {
            GPSServiceBinder serviceBinder = (GPSServiceBinder)service;

            if (serviceBinder != null)
            {
                this._binder = serviceBinder;
                this._binder.IsBound = true;
                serviceBinder.Service.StartLocationUpdates();
                if (Connected != null)
                    Connected.Invoke();
            }
        }
        public void OnServiceDisconnected(ComponentName name) { this._binder.IsBound = false; }
    }
}