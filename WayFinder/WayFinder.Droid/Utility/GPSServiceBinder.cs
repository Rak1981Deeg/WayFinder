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
    public class GPSServiceBinder : Binder
    {
        public GPSService Service { get { return this.LocService; } }
        protected GPSService LocService;
        public bool IsBound { get; set; }
        public GPSServiceBinder(GPSService service) { this.LocService = service; }
    }
}