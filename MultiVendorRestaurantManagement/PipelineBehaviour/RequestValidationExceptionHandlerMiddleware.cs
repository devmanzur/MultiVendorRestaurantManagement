using System;
using System.Collections;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Common.Invariants;
using Common.Utils;
using CrossCutting;
using CrossCutting.Utils;
using FluentValidation;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using MultiVendorRestaurantManagement.Domain.Base;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace MultiVendorRestaurantManagement.PipelineBehaviour
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class RequestValidationExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex, _env);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception, IWebHostEnvironment env)
        {
            var code = HttpStatusCode.InternalServerError;
            object error;

            switch (exception)
            {
                case ValidationException e:
                    code = HttpStatusCode.UnprocessableEntity;

                    var errors = e.Errors.Select(x =>
                        new
                        {
                            x.PropertyName,
                            x.ErrorMessage
                        });
                    error = Envelope.Error(errors, ApiLocalizedResponseKey.InvalidParameterValue + " multiple errors occurred");
                    break;
                case BusinessRuleValidationException e:
                    code = HttpStatusCode.UnprocessableEntity;
                    error = Envelope.Error(e.Message);
                    break;
                default:
                    error = Envelope.Error(exception.Message);
                    break;
            }

            var result = JsonConvert.SerializeObject(error);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int) code;
            return context.Response.WriteAsync(result);
        }

        public RequestValidationExceptionHandlerMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }
    }
}