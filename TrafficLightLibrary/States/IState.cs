namespace TrafficLightLibrary
{
    /// <summary>
    /// Interface of state of traffic light.
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Method fo switching the state of traffic light.
        /// </summary>
        /// <param name="trafficLight">Source traffic light.</param>
        void Switch(TrafficLight trafficLight);
    }
}
