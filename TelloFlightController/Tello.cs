using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TelloFlightController
{
    /*
    @Luck007, zylex, xela014
    @1.0
    Schickt Strings gemeäß des Tello SDKs an die Drohne
    */
    class Tello
    {
        private string _IP = "192.168.10.1";
        private const string _PORT = "8889";
        private bool _IS_SDK_MODE_ACTIVE = false;

        private UdpClient client = new UdpClient(int.Parse(_PORT));  
        public string IP { get { return _IP; } }
        public string Port { get { return _PORT; } }

        private void isSDK()
        {
            if (!_IS_SDK_MODE_ACTIVE)
            {
                _IS_SDK_MODE_ACTIVE = true;
                Command();
            } 
        }
        private string Command()
        {
            isSDK();
            return SendMsg("command");
        }
        
        //Control Commands
        public string takeOff()
        {
            isSDK();
            return SendMsg("takeoff");

        }  
        public string land()
        {
            isSDK();
            return SendMsg("land");
        } 
        public string stop()
        {
            isSDK();
            return SendMsg("stop");
        } 
        public string up(int x)
        {
            isSDK();
            return SendMsg($"up {x}");
        } 
        public string down(int x)
        {
            isSDK();
            return SendMsg($"down {x}");
        } 
        public string left(int x)
        {
            isSDK();
            return SendMsg($"left {x}");
        } 
        public string right(int x)
        {
            isSDK();
            return SendMsg($"right {x}");
        } 
        public string forward(int x)
        {
            isSDK();
            return SendMsg($"forward {x}");
        } 
        public string back(int x)
        {
            isSDK();
            return SendMsg($"back {x}");
        }
        public string cw(int x)
        {
            isSDK();
            return SendMsg($"cw {x}");
        } 
        public string ccw(int x)
        {
            isSDK();
            return SendMsg($"ccw {x}");
        } 
        public string flip(string x)
        {
            isSDK();
            return SendMsg($"flip {x}");
        } 

        public string go(int x, int y, int z, int speed)
        {
            isSDK();
            return SendMsg($"go {x} {y} {z} {speed}");
        } 
        public string goMid(int x, int y, int z, int speed, string mid)
        {
            isSDK();
            return SendMsg($"go {x} {y} {z} {speed} {mid}");
        } 

        public string curve(int x1, int y1, int z1, int x2, int y2, int z2, int speed)
        {
            isSDK();
            return SendMsg($"curve {x1} {y1} {z1} {x2} {y2} {z2} {speed}");
        } 
        public string curveMid(int x1, int y1, int z1, int x2, int y2, int z2, int speed, string mid)
        {
            isSDK();
            return SendMsg($"curve {x1} {y1} {z1} {x2} {y2} {z2} {speed} {mid}");
        }

        public string jump(int x, int y, int z, int speed, int yaw, int mid1, string mid2)
        {
            isSDK();
            return SendMsg($"jump {x} {y} {z} {speed} {yaw} {mid1} {mid2}");
        }

        //Properties
        public string Speed { get; set; } = string.Empty; //Herr Nagler meinte static

        //Set Commands
        public string setRc(int a, int b, int c, int d)
        {
            isSDK();
            return SendMsg($"rc {a} {b} {c} {d}");
        }
        public string setWifi(string ssid, string pass)
        {
            isSDK();
            return SendMsg($"wifi {ssid} {pass}");
        }
        public string setMon()
        {
            isSDK();
            return SendMsg("mon");
        }
        public string setMoff()
        {
            isSDK();
            return SendMsg("moff");
        }
        public string setMdirection(int x)
        {
            isSDK();
            return SendMsg($"mdirection {x}");
        }
        public string setAp(string ssid, string pass)
        {
            isSDK();
            return SendMsg($"ap {ssid} {pass}");
        }

        //Read(Get-) Commands

        public string getSpeed()
        {
            isSDK();
            return SendMsg("speed?");
        }

        public string getBattery()
        {
            isSDK();
            return SendMsg("battery?");
        }
        public string getTime()
        {
            isSDK();
            return SendMsg("time?");
        }
        public string getWifi()
        {
            isSDK();
            return SendMsg("wifi?");
        }
        public string getSDK()
        {
            isSDK();
            return SendMsg("sdk?");
        }
        public string getSN()
        {
            isSDK();
            return SendMsg("sn?");
        }

        /*
        @arams: string - message    
        Schickt einen String per UDP Protokoll an die Drohne (Ip / Port)
        */
        private string SendMsg(string msg)
        {
           
            IPAddress ipAddress = IPAddress.Parse(_IP);
            int port = int.Parse(_PORT);
           
            byte[] bytesToSend = Encoding.ASCII.GetBytes(msg);

            try
            {              
                client.Send(bytesToSend, bytesToSend.Length, new IPEndPoint(ipAddress, port));
                Console.WriteLine("Message sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }

            return Listener();
        }

        /*
        @return: string - response 
        Bekommt einen String von der Drohne zurück
        */
        private string Listener()
        {
            string ans = "error";

            try
            {
                IPEndPoint sender = new IPEndPoint(IPAddress.Any, 0);
                byte[] bytesReceived = client.Receive(ref sender);
                string message = Encoding.ASCII.GetString(bytesReceived);

                ans = ($"{message} from {sender.Address}:{sender.Port}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error receiving message: {ex.Message}");
            }

            return ans;
        }
    }
}
