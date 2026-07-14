using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;

namespace MiniStock.WebApi.ExceptionHandlers;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        if (exception is ValidationException validationException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            await httpContext.Response.WriteAsJsonAsync(new 
            {
                Status = 400,
                Title = "Validation hatası",
                Errors = validationException.Errors.Select(e => e.ErrorMessage)
            }, cancellationToken);
            return true;
        }

        // Diğer hatalar için (404, 409 vb. ileride eklenecek)
        return false;
    }
}