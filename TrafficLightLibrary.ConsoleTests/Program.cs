using System;

namespace TrafficLightLibrary.ConsoleTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // TrafficLight trafficLight = new TrafficLight();
            EventTrafficLight trafficLight = new EventTrafficLight();

            ConsoleKeyInfo temp;
            do
            {
                Console.Clear();
                trafficLight.SwitchState();
                Console.WriteLine("Press " + "<enter> to exit " + "any other button to switch to next state;");
                temp = Console.ReadKey();
            }
            while (temp.Key != ConsoleKey.Enter);
        }
    }
}
