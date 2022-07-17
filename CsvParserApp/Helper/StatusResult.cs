using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace CsvParserApp.Helper
{
    public class StatusResult
    {
        public static ActionResult Result(HttpStatusCode statusCode, string reason) => new ContentResult
        {
            StatusCode = (int)statusCode,
            Content = $"Status Code: {(int)statusCode} {statusCode}: {reason}",
            ContentType = "text/plain",
        };
    }
}