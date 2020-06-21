using RocketFlightControl.Enums;

namespace RocketFlightControl.Interfaces
{
    public interface ITile : IMapItem
    {
        TileStatus Status { get; set; }
    }
}
