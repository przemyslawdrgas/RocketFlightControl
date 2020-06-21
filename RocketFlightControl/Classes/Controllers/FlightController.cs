using System.Linq;
using RocketFlightControl.Interfaces;
using RocketFlightControl.Models;

namespace RocketFlightControl
{
    public class FlightController
    {
        private FlightControlHandler _flightControlHandler;
        private IArea _surface { get; }

        public FlightController(IArea surface, IFacility facility)
        {
            _flightControlHandler = new FlightControlHandler();
            _surface = surface;
            _surface.Facilities.Add(facility);
        }

        /// <summary>
        /// Returns landing possibility information for area specified coordinates.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public ResponseModel RequestLanding(uint x, uint y)
        {
            ITile tile = _surface.Tiles.Where(t => t.X == x && t.Y == y).FirstOrDefault();

            return _flightControlHandler.GetResponse(_surface, _surface.Facilities.FirstOrDefault(), tile);
        }
    }
}
