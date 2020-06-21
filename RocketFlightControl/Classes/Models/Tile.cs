using RocketFlightControl.Enums;
using RocketFlightControl.Interfaces;

namespace RocketFlightControl.Models
{
    public class Tile : ITile
    {
        public uint X { get; }
        public uint Y { get; }
        public uint Id => X * 10 + Y;
        public TileStatus Status { get; set; } = TileStatus.Empty;

        public Tile(uint x, uint y)
        {
            X = x;
            Y = y;
        }
    }
}
