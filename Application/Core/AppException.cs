using Application.Activities;
using Microsoft.AspNetCore.Http;

namespace Application.Core;

public class AppException
{
    public AppException(int statusCode, string message, string details = null)
    {
        StatusCode = statusCode;
        Message = message;
        Detail = details;
    }

    public string Detail { get; set; }

    public string Message { get; set; }

    public int StatusCode { get; set; }

}