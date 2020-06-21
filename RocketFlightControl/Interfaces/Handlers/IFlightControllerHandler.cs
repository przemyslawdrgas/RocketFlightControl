using RocketFlightControl.Models;

namespace RocketFlightControl.Interfaces
{
    internal interface IFlightControllerHandler
    {
        ResponseModel GetResponse(IArea surface, IFacility facility, ITile tile);
    }
}
