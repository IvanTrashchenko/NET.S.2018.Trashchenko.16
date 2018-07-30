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
        /// Initializes a new instance of the <see cref="TrafficLight"/> class with specific state.
        /// Default - green.
        /// </summary>
        /// <param name="state">State of light of type <see cref="EventHandler"/>.</param>
        public EventTrafficLight(EventHandler state = null)
        {
            if (state == null)
            {
                state = this.SwitchToGreen;
            }

            this.State += state;
        }

        /// <summary>
        /// State of light.
        /// </summary>
        public event EventHandler State = delegate { };

        /// <summary>
        /// Method for switching state of traffic light.
        /// </summary>
        public void SwitchState()
        {
            this.OnState(this, EventArgs.Empty);
        }

        #region Switching methods

        public void SwitchToGreen(object sender, EventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write(i > 3 ? "Green light: {0}" : "Flashing green light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToYellow;
        }

        public void SwitchToRed(object sender, EventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                Console.Write("Red light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToRedAndYellow;
        }

        public void SwitchToRedAndYellow(object sender, EventArgs e)
        {
            for (int i = 3; i >= 0; i--)
            {
                Console.Write("Red and yellow light: {0}", i);
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }

            this.State = this.SwitchToGreen;
        }

        public void SwitchToYellow(object sender, EventArgs e)
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

        protected virtual void OnState(object sender, EventArgs e)
        {
            this.State?.Invoke(sender, e);
        }
    }
}