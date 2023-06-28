using System;
using System.Collections.Generic;
using System.Text;

namespace TelloFlightController
{
    /*
   @Luck007, zylex, xela014
   @1.0
   Erstellt eine Tello Klasseninstanz und enthält Methoden zur Erstellung von Flugmanoevern (Aktuell nur Mehrecke)
   */

    internal class Factory
    {
        private Tello _telloInstance;

        public Factory()
        {
            _telloInstance = new Tello();
        }
        public Mehreck createFlugmanME(int size, int turns)
        {
            Dictionary<string, int> flyParams = new Dictionary<string, int>() { { "size", size }, { "turns", turns} }; //example

            return new Mehreck(_telloInstance, flyParams);
        }
    }
}
