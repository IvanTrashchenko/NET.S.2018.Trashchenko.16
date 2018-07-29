using System;

namespace TrafficLightLibrary
{
    public class RedObserver
    {
        public void Subscribe(EventTrafficLight light) => light.State += this.SwitchToRed;

        public void Unsubscribe(EventTrafficLight light) => light.State -= this.SwitchToRed;

        public void SwitchToRed(object sender, EventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write("Red light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}