using System;
using System.Collections.Generic;
using System.Text;

namespace WayFinder
{
    public interface IWayFinderAuth
    {
        void LoginByGoogle(bool allowCancel);
    }
}
