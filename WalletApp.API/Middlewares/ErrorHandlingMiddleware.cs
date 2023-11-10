﻿using System.Net;
using System.Text.Json;
using WalletApp.Application.Models;

namespace WalletApp.API.Middlewares;

public class ErrorHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IWebHostEnvironment env)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            await HandleException(error, context, env.IsDevelopment());
        }
    }

    private async Task HandleException(Exception error, HttpContext context, bool isDevelopment)
    {
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = GetCode(error);

        var errorMessage = GetErrorMessage(error, isDevelopment, context.Response.StatusCode);
        var errorModel = new ErrorModel { Message = errorMessage };
        var responseModel = new ResponseModel<string>(errorModel);
        var responseBody = JsonSerializer.Serialize(responseModel);
   

        await context.Response.WriteAsync(responseBody);
    }

    private static int GetCode(Exception error)
    {
        return error switch
        {
            KeyNotFoundException => (int)HttpStatusCode.NotFound,
            InvalidOperationException => (int)HttpStatusCode.BadRequest,
            _ => (int)HttpStatusCode.InternalServerError
        };
    }

    private static string GetErrorMessage(Exception ex, bool isDevelopment, int httpStatusCode)
    {
        string errorMessage;

        if (isDevelopment)
            errorMessage = ex.ToString();
        else if (httpStatusCode >= (int)HttpStatusCode.InternalServerError)
            errorMessage = "Something wrong Happened";
        else
            errorMessage = ex.Message;

        return errorMessage;
    }
}