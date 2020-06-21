using RocketFlightControl.Enums;

namespace RocketFlightControl.Models
{
    public class ResponseModel
    {
        public string Message { get; }
        public ResponseCode Code { get; }

        public ResponseModel(string message, ResponseCode responseCode)
        {
            Message = message;
            Code = responseCode;
        }
    }
}
