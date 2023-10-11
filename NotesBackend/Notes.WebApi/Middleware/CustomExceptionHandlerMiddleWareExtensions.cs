namespace Notes.WebApi.Middleware;

public class CustomExceptionHandlerMiddleWareExtensions
{
    public static IApplicationBuilder UseCustomExceptionHandler(IApplicationBuilder builder)
    {
        return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
    }
}