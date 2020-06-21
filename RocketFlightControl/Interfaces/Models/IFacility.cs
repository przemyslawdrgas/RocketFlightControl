using System.Collections.Generic;

namespace RocketFlightControl.Interfaces
{
    public interface IArea : IFacility
    {
        List<IFacility> Facilities { get; }
    }
}
