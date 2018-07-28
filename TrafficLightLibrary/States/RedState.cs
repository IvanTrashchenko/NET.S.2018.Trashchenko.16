using System;

namespace TrafficLightLibrary
{
    public class RedState : IState
    {
        public void Switch(TrafficLight trafficLight)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write("Red light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            trafficLight.State = new RedAndYellowState();
        }
    }
}
