namespace CachingSimpleExample.Controllers.ControllerResponses
{
    public class BaseResponse
    {
        public BaseResponse(int status, string message)
        {
            StatusCode = status;
            StatusMessage = message;
        }

        public int StatusCode { get; set; }

        public string StatusMessage { get; set; }
    }
}
