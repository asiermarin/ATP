namespace NCacheExample.Controllers.ControllerResponses
{
    using System.Net;
    using Microsoft.AspNetCore.Mvc;
    using NCacheExample.Models;

    public class ErrorResponse : BaseResponse
    {
        public ErrorResponse(HttpStatusCode status, string reason)
            : base((int)status, status.ToString())
        {
            Reason = reason;
        }

        public string Reason { get; set; }

        public static ErrorResponse FromServiceError(CrudResult crudResult) =>
            new ErrorResponse(crudResult.IsError ? HttpStatusCode.BadRequest : HttpStatusCode.InternalServerError, "");

        public ObjectResult ToObjectResult() =>
            new ObjectResult(this)
            {
                StatusCode = StatusCode
            };
    }
}
