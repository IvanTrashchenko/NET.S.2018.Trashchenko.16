using System;

namespace TrafficLightLibrary
{
    public class RedAndYellowState : IState
    {
        public void Switch(TrafficLight trafficLight)
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Red and yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            trafficLight.State = new GreenState();
        }
    }
}
