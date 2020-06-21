using RocketFlightControl.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RocketFlightControl.Models
{
    public class Surface : IArea
    {
        public uint X => 0;
        public uint Y => 0;
        public uint Width => Tiles.Max(t => t.X);
        public uint Height => Tiles.Max(t => t.Y);
        public List<ITile> Tiles { get; }
        public List<IFacility> Facilities { get; internal set; } = new List<IFacility>();

        public Surface(List<ITile> tiles)
        {
            Tiles = tiles;
        }

        public Surface() : this(100, 100) { }

        private Surface(uint width, uint height)
        {
            Tiles = CreateSurfaceTiles(width, height);
        }

        private List<ITile> CreateSurfaceTiles(uint width, uint height)
        {
            List<ITile> tiles = new List<ITile>();

            for (uint x = 1; x <= width; x++)
                for (uint y = 1; y <= height; y++)
                    tiles.Add(new Tile(x, y));

            return tiles;
        }
    }
}
