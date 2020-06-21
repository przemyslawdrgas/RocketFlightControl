using System;
using System.Collections.Generic;
using System.Linq;
using RocketFlightControl.Interfaces;

namespace RocketFlightControl.Models
{
    public abstract class FacilityBase : IFacility
    {
        public uint X { get; }
        public uint Y { get; }
        public uint Width { get; }
        public uint Height { get; }
        public List<ITile> Tiles { get; }

        internal FacilityBase(Surface surface, uint x, uint y, uint width, uint height)
        {
            Tiles = SetTiles(surface, x, y, width, height);
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public virtual List<ITile> SetTiles(Surface surface, uint x, uint y, uint width, uint height)
        {
            uint right = x + width;
            uint bottom = y + height;

            var tiles = surface.Tiles.Where(t => (t.X >= x) && (t.X < x + width) && (t.Y >= y) && (t.Y < y + height)).ToList();

            if (tiles.Count != width * height)
                throw new ArgumentException("Facility cannot be constructed outside of the control area.");
            return tiles;
        }
    }
}
