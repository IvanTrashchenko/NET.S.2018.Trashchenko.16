using System;

namespace TrafficLightLibrary
{
    public class YellowObserver
    {
        public void Subscribe(EventTrafficLight light) => light.State += this.SwitchToYellow;

        public void Unsubscribe(EventTrafficLight light) => light.State -= this.SwitchToYellow;

        public void SwitchToYellow(object sender, EventArgs e)
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
        }
    }
}
