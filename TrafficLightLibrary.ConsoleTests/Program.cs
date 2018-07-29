using System;

namespace TrafficLightLibrary.ConsoleTests
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // cyclic state switching

            TrafficLight trafficLight = new TrafficLight();

            ConsoleKeyInfo temp;
            do
            {
                Console.Clear();
                trafficLight.SwitchState();
                Console.WriteLine("Press " + "<enter> to exit " + "any other button to switch to next state;");
                temp = Console.ReadKey();
            }
            while (temp.Key != ConsoleKey.Enter);

            // only subscribed states swithcing

            EventTrafficLight trafficLight2 = new EventTrafficLight();

            GreenObserver firstObserver = new GreenObserver();
            YellowObserver secondObserver = new YellowObserver();

            firstObserver.Subscribe(trafficLight2);
            secondObserver.Subscribe(trafficLight2);

            Console.Clear();
            trafficLight2.SwitchState();
            temp = Console.ReadKey();
        }
    }
}
