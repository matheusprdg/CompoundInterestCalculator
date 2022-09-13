using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text;
using System.Text.Json;

namespace CompoundInterestCalculator.CrossCutting.ErrorHandler;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            if (error is ValidationException validationException)
            {
                var validationErrorMessage = this.GetValidationErrorMessage(validationException);

                await this.WriteErrorAsync(context, validationErrorMessage);
            }
            else
            {
                await this.WriteErrorAsync(context, error?.Message);
            }
        }
    }

    private async Task WriteErrorAsync(HttpContext context, string message)
    {
        var response = context.Response;
        response.ContentType = "application/json";
        response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var result = JsonSerializer.Serialize(new { message = message });
        await response.WriteAsync(result, Encoding.UTF8);
    }

    private string GetValidationErrorMessage(ValidationException ex)
    {
        var mensagens = ex.Errors.Select(f => f.ErrorMessage);

        if (mensagens.Any() && mensagens.Count() == 1)
            return mensagens.First();

        return string.Join(" ", mensagens);
    }
}
