using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API
{
    public static class HttpErrors
    {

        public static BadRequestObjectResult BadRequest(string? message = null, object? data = null)
        {
            return new BadRequestObjectResult(GetErrorAPIResponse(HttpStatusCode.BadRequest, message, data));
        }

        public static NotFoundObjectResult NotFound(string? message = null, object? data = null)
        {
            return new NotFoundObjectResult(GetErrorAPIResponse(HttpStatusCode.NotFound, message, data));
        }

        private static APIResponse GetErrorAPIResponse(HttpStatusCode status, string? message, object? data)
        {
            APIResponse response = new()
            {
                StatusCode = status,
                Success = false,
                Data = data
            };

            if (!string.IsNullOrWhiteSpace(message))
            {
                response.Messages.Add(message);
            }
            return response;
        }
    }
}
