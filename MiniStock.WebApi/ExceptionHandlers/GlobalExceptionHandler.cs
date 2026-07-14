using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FluentValidation;
using MiniStock.Application.Common.Exceptions; // <--- 1. Bunu ekle

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
        
        // <--- 2. Buraya bu bloğu ekle
        else if (exception is ConflictException conflictException)
        {
            httpContext.Response.StatusCode = StatusCodes.Status409Conflict;
            await httpContext.Response.WriteAsJsonAsync(new 
            {
                Status = 409,
                Title = "Conflict (Çatışma) Hatası",
                Message = conflictException.Message
            }, cancellationToken);
            return true;
        }

        return false;
    }
}