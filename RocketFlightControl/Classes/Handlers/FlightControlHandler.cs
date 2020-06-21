using RocketFlightControl.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using RocketFlightControl.Interfaces;
using RocketFlightControl.Enums;
using RocketFlightControl.Models;

namespace RocketFlightControl
{
    internal class FlightControlHandler : IFlightControllerHandler
    {
        public ResponseModel GetResponse(IArea surface, IFacility facility, ITile tile)
        {
            ResponseCode code;

            if (tile == null)
                throw new ArgumentException("Unable to provide information for out of control area coordinates.");
            else if (!TileBelongsToFacility(facility, tile))
                code = ResponseCode.OutOfPlatform;
            else if (tile.Status == TileStatus.Occupied || CheckNeighbouringTiles(surface, tile) == TileStatus.Occupied)
                code = ResponseCode.Clash;
            else
            {
                code = ResponseCode.OkForLanding;
                tile.Status = TileStatus.Occupied;
            }

            string message = GetMessage(code);
            return new ResponseModel(message, code);
        }

        private string GetMessage(ResponseCode code)
        {
            string message = string.Empty;

            switch (code)
            {
                case ResponseCode.Clash:
                    message = MessageResources.Clash;
                    break;
                case ResponseCode.OkForLanding:
                    message = MessageResources.Ok;
                    break;
                case ResponseCode.OutOfPlatform:
                    message = MessageResources.Out;
                    break;
            }

            return message;
        }

        private TileStatus CheckNeighbouringTiles(IArea surface, ITile tile)
        {
            uint left = tile.X - 1 >= 0 ? tile.X - 1 : 0;
            uint right = tile.X + 1 >= 0 ? tile.X + 1 : 0;
            uint top = tile.Y - 1 >= 0 ? tile.Y - 1 : 0;
            uint bottom = tile.Y + 1 >= 0 ? tile.Y + 1 : 0;

            List<ITile> neighbours = surface.Tiles.Where(t => (t.X >= left) && (t.X <= right) && (t.Y >= top) && (t.Y <= bottom) && (t != tile)).ToList();
            bool isAnyOccupied = neighbours.Any(t => t.Status == TileStatus.Occupied);

            return isAnyOccupied ? TileStatus.Occupied : TileStatus.Empty;
        }

        private bool TileBelongsToFacility(IFacility facility, ITile tile)
        {
            bool isFacilityTile = facility == null ? false : facility.Tiles.Any(t => t == tile);

            return isFacilityTile;
        }
    }
}
