using System;
using System.Collections.Generic;
using System.Text;

namespace WayFinder
{
    public interface ISMSSender
    {
        void Send(string mobileNo, string message);
        //void Send2(string mobileNo, string message);
    }
}
