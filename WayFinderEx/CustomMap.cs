using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Maps;

namespace WayFinderEx
{
    public class CustomMap : Map
    {
        public CustomMap()
        {
            //MessagingCenter.Subscribe<Map>(this, "LOCATION_UPDATED", message =>
            //{

            //});
        }
        public CustomCircle Circle { get; set; }
    }
}
