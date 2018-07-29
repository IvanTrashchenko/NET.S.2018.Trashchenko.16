using System;

namespace TrafficLightLibrary
{
    public class RedAndYellowObserver
    {
        public void Subscribe(EventTrafficLight light) => light.State += this.SwitchToRedAndYellow;

        public void Unsubscribe(EventTrafficLight light) => light.State -= this.SwitchToRedAndYellow;

        public void SwitchToRedAndYellow(object sender, EventArgs e)
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Red and yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}