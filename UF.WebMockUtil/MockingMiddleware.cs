namespace UF.WebMockUtil;
public class MockingMidleware {
    private readonly RequestDelegate _next;

    public MockingMidleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Call the next delegate/middleware in the pipeline.
        await _next(context);
    }
}