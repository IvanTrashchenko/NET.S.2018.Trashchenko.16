using System;

namespace TrafficLightLibrary
{
    /// <summary>
    /// Class of traffic light.
    /// Events used.
    /// </summary>
    public class EventTrafficLight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EventTrafficLight"/> class with specific state.
        /// Default - green.
        /// </summary>
        /// <param name="state">State of light of type <see cref="Action"/>.</param>
        public EventTrafficLight(Action state = null)
        {
            if (state == null)
            {
                this.State += this.SwitchToGreen;
            }

            this.State += state;
        }

        /// <summary>
        /// State of light.
        /// </summary>
        public event Action State = delegate { };

        /// <summary>
        /// Method for switching state of traffic light.
        /// </summary>
        public void SwitchState()
        {
            this.OnState();
        }

        #region Switching methods

        public void SwitchToGreen()
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

            this.State = this.SwitchToYellow;
        }

        public void SwitchToRed()
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write("Red light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToRedAndYellow;
        }

        public void SwitchToRedAndYellow()
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Red and yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToGreen;
        }

        public void SwitchToYellow()
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToRed;
        }

        #endregion

        protected virtual void OnState()
        {
            this.State?.Invoke();
        }
    }
}