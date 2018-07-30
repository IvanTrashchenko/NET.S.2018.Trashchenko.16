using System;

namespace TrafficLightLibrary
{
    public class GreenObserver
    {
        public void Subscribe(EventTrafficLight light) => light.State += this.SwitchToGreen;

        public void Unsubscribe(EventTrafficLight light) => light.State -= this.SwitchToGreen;

        public void SwitchToGreen(object sender, EventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                if (i > 3)
                {
                    Console.Write("Green light: {0}", i);
                }
                else
                {
                    Console.Write("Flashing green light: {0}", i);
                }
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }   
        }
    }
}
