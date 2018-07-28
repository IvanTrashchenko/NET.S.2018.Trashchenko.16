using System;

namespace TrafficLightLibrary
{
    public class GreenState : IState
    {
        public void Switch(TrafficLight trafficLight)
        {
            for (int i = 10; i >= 0; i--)
            {
                if (i > 3)
                {
                    Console.Write("Green light: {0}", i);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
                else
                {
                    Console.Write("Flashing green light: {0}", i);
                    System.Threading.Thread.Sleep(1000);
                    Console.Clear();
                }
            }   
            
            trafficLight.State = new YellowState();
        }
    }
}
