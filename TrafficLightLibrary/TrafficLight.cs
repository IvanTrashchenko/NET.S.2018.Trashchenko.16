namespace TrafficLightLibrary
{
    /// <summary>
    /// Class of traffic light.
    /// State pattern used.
    /// </summary>
    public class TrafficLight
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TrafficLight"/> class with specific state.
        /// Default - green.
        /// </summary>
        /// <param name="state">State of light of type <see cref="IState"/>.</param>
        public TrafficLight(IState state = null)
        {
            if (state == null)
            {
                state = new GreenState();
            }

            this.State = state;
        }

        /// <summary>
        /// State of light.
        /// </summary>
        public IState State { get; set; }

        /// <summary>
        /// Method for switching state of traffic light.
        /// </summary>
        public void SwitchState()
        {
            this.State.Switch(this);
        }
    }
}