using System;
using System.Collections.Generic;
using System.Text;

namespace TelloFlightController
{
    /*
   @Luck007, zylex, xela014
   @1.0
   Interface für die Klasse Mehreck
   */
    internal interface Flugmanoever
    {
        void Check_isFlying();
        void Fly();
    }
}
