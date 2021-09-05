using System.Net;

namespace TokenEntity.ReturnMessage
{
    public record MediatrResult(HttpStatusCode StatusCode, string Message, string ResultType);
    public record MediatrResult<T>(HttpStatusCode StatusCode, string Message, T Item, string ResultType);
}