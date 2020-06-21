namespace RocketFlightControl.Models
{
    public class LandingPlatform : FacilityBase
    {
        public LandingPlatform(Surface surface, uint width, uint height) : base(surface, 5, 5, width, height) { }
    }
}
