using Application;
using FluentValidation;
using Implementation.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using ValidationException = FluentValidation.ValidationException;

namespace API.Core
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private IExceptionLogger _logger;
        private IApplicationActor _actor;

        public GlobalExceptionHandlingMiddleware(RequestDelegate next, IExceptionLogger logger, IApplicationActor actor)
        {
            _next = next;
            _logger = logger;
            _actor = actor;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                if (exception is UnauthorizedAccessException)
                {
                    httpContext.Response.StatusCode = 401;
                    return;
                }

                if (exception is ValidationException ex)
                {
                    httpContext.Response.StatusCode = 422;
                    var body = ex.Errors.Select(x => new { Property = x.PropertyName, Error = x.ErrorMessage });

                    await httpContext.Response.WriteAsJsonAsync(body);
                    return;
                }
                if (exception is NotFoundException)
                {
                    httpContext.Response.StatusCode = 404;
                    return;
                }

                var errorId = _logger.Log(exception, _actor);

                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsJsonAsync(new { Message = $"An unexpected error has occured. Please contact our support with this ID - {errorId}." });
            }
         }
    }
}
