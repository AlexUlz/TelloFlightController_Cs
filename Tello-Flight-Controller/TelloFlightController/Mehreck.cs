using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TelloFlightController
{
    /*
   @Luck007, zylex, xela014
   @1.0
   Checkt Ausführbarkeit für das Manoever (isFlying, battery) und enthält Methode fürs spezifische Ausführen des Flugmanoevers
   */
    internal class Mehreck: Flugmanoever
    {
        private bool isFlying = false;
        private Dictionary<string, int> _flyParams;
        Tello tello = null;

        public Mehreck(Tello telloInstance, Dictionary<string, int> flyParams)
        {
            tello = telloInstance;
            _flyParams = flyParams;
        }

        public void Check_isFlying()
        {
            string batteryState = tello.getBattery().Split(" ")[0];
            if (int.Parse(batteryState) < 20)
            {
                Console.WriteLine("Error, low battery. {0}%", batteryState);
                return;
            }

            if (!isFlying)
            {

                Console.WriteLine(tello.takeOff());
                isFlying = true;
            }

        }
        public void Fly()
        {
            Check_isFlying();
            int seitenlaenge = _flyParams.GetValueOrDefault("size");
            int turns = _flyParams.GetValueOrDefault("turns");          

            if (!isFlying)
                return;
            
            for (int i = 0; i < turns; i++)
            {
                Console.WriteLine(tello.forward(seitenlaenge));               
                Console.WriteLine(tello.cw(360 / turns));
            }
        }
    }
}
