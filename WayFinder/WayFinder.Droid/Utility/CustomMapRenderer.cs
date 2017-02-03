//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//using Android.App;
//using Android.Content;
//using Android.OS;
//using Android.Runtime;
//using Android.Views;
//using Android.Widget;
using Xamarin.Forms.Maps.Android;
using WayFinder.Droid;
using WayFinderEx;
using Xamarin.Forms;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;


[assembly: ExportRenderer(typeof(CustomMap), typeof(CustomMapRenderer))]
namespace WayFinder.Droid
{
    public class CustomMapRenderer : MapRenderer, IOnMapReadyCallback
    {
        GoogleMap map;
        CustomCircle circle;

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Xamarin.Forms.Maps.Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                // Unsubscribe
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMap)e.NewElement;
                circle = formsMap.Circle;

                ((MapView)Control).GetMapAsync(this);
            }
        }

        public void OnMapReady(GoogleMap googleMap)
        {
            //map = googleMap;

            //var circleOptions = new CircleOptions();
            //circleOptions.InvokeCenter(new LatLng(circle.Position.Latitude, circle.Position.Longitude));
            //circleOptions.InvokeRadius(circle.Radius);
            //circleOptions.InvokeFillColor(0X66FF0000);
            //circleOptions.InvokeStrokeColor(0X66FF0000);
            //circleOptions.InvokeStrokeWidth(0);
            //map.AddCircle(circleOptions);
        }
    }
}