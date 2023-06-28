using System;
using System.Collections.Generic;
using System.Drawing;

namespace TelloFlightController
{
    /*
   @Luck007, zylex, xela014
   @1.0
   Programm Class (Instanz FlyControl & Factory)
   */
    class Program
    {

        static void Main(string[] args)
        {
            /*
            FlyControl: nimmt manöver entgegen und lässt ausführen
            Factory: Nötige Objekte instanzieren
            Flugmanoever: Interface
            Mehreck: convertiert angaben zu einem mehreck kreislauf
            Tello: Entählt Commands für die drohne 

             */

            FlyControl flightController = new FlyControl();
            Factory fn = new Factory();
            
            flightController.Add(fn.createFlugmanME(100, 4));
            flightController.Execute();
        }
    }
}