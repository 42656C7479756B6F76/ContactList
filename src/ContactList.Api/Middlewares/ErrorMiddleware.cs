using ContactList.Dal.Exceptions;

namespace ContactList.Api.Middlewares;

public class ErrorMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ItemNotFoundException e)
        {
            var error = new { errorMessage = e.Message };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(error);
        }
        catch (DependentItemNotFoundException e)
        {
            var error = new { errorMessage = e.Message };
            context.Response.StatusCode = StatusCodes.Status404NotFound;
            await context.Response.WriteAsJsonAsync(error);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}