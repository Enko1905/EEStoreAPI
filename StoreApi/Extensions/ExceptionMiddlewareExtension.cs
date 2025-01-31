﻿using Entities.ErrorModel;
using Microsoft.AspNetCore.Diagnostics;
using Services.Contracts;
using System.Net;

namespace StoreApi.Extensions
{
    public static class ExceptionMiddlewareExtension
    {
        public static void ConfigureExceptionHandler(this WebApplication app, ILoggerService logger)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    //context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature is not null)
                    {
                        context.Response.StatusCode = contextFeature.Error switch
                        {
                            NotFiniteNumberException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError,

                        };
                        logger.LogError($"something went wrong: {contextFeature.Error}");
                        await context.Response.WriteAsync(new ErrorDetails()
                        {
                            StatusCode = context.Response.StatusCode,
                            Message =  contextFeature.Error.Message

                        }.ToString());

                    }
                });
            });

        }
    }
}
