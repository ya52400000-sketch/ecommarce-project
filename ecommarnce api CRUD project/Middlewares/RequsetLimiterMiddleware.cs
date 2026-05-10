namespace ecommarce.API.Middlewares;

public class RequestLimiterMiddleware
{
    private readonly RequestDelegate _Next;
    private static DateTime? _lastRequestTime;
    public RequestLimiterMiddleware(RequestDelegate Next)
    {
        _Next = Next;
    }
    public async Task Invoke(HttpContext context)
    {
        var CurrentTime = DateTime.UtcNow;
        if (_lastRequestTime.HasValue && (CurrentTime - _lastRequestTime.Value)
.TotalSeconds < 5)
        {
            context.Response.StatusCode = 429;
            await context.Response.WriteAsync("wait 5 seconds");
            return;
        }
        _lastRequestTime =  CurrentTime;
        await _Next (context);

    }
}
