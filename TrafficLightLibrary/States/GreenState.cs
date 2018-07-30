using System;

namespace TrafficLightLibrary
{
    public class GreenState : IState
    {
        public void Switch(TrafficLight trafficLight)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write(i > 3 ? "Green light: {0}" : "Flashing green light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            trafficLight.State = new YellowState();
        }  
    }
}
