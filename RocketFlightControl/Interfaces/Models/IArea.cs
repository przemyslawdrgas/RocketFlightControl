using System.Collections.Generic;

namespace RocketFlightControl.Interfaces
{
    public interface IFacility : IMapItem
    {
        uint Width { get; }
        uint Height { get; }
        List<ITile> Tiles { get; }
    }
}
