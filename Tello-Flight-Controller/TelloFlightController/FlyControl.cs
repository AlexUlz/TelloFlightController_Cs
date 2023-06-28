using System;
using System.Collections.Generic;
using System.Text;

namespace TelloFlightController
{
    /*
   @Luck007, zylex, xela014
   @1.0
   Erstellt eine Liste mit allen auszuführenden Flugmanoevern und führt diese aus
   */
    internal class FlyControl
    {
        List<Flugmanoever> alleManoever = new List<Flugmanoever>();

        public void Add(Flugmanoever flugman)
        {
            alleManoever.Add(flugman);
        }

        public void Execute()
        {
            foreach (Flugmanoever flugman in alleManoever)
            {
                flugman.Fly();
            }
        }
    }
}
