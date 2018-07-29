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

        protected virtual void OnState(object sender, EventArgs e)
        {
            this.State?.Invoke(sender, e);
        }
    }
}