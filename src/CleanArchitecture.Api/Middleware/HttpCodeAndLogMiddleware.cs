using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Application.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Newtonsoft.Json;

namespace CleanArchitecture.Api.Middleware
{
    public static class HttpCodeAndLogMiddlewareExtensions
    {
        public static IApplicationBuilder UseHttpCodeAndLogMiddleware(this IApplicationBuilder builder)
        {
            IApplicationBuilder applicationBuilder = builder.UseMiddleware<HttpCodeAndLogMiddleware>();
            return applicationBuilder;
        }
    }

    public class HttpCodeAndLogMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<HttpCodeAndLogMiddleware> _logger;

        public HttpCodeAndLogMiddleware(RequestDelegate next, ILogger<HttpCodeAndLogMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            if (httpContext is null)
            {
                return;
            }

            try
            {
                httpContext.Request.EnableBuffering();
                await _next(httpContext);
            }
            catch (Exception exception)
            {

                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch (exception)
                {
                    case ApiException e:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.BadRequest, LogLevel.Error, "BadRequest Exception!");
                        break;
                    case NotFoundException e:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.NotFound, LogLevel.Error, "NotFound Exception!");
                        break;
                    case ValidationException e:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.UnprocessableEntity;
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.UnprocessableEntity, LogLevel.Error, "Validation Exception!");
                        break;
                    case AuthenticationException e:
                        httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.Unauthorized, LogLevel.Error, "Authentication Exception!");
                        break;
                    default:
                        await WriteAndLogResponseAsync(exception, httpContext, HttpStatusCode.InternalServerError, LogLevel.Error, "Server error!");
                        break;
                }
            }
        }

        private async Task WriteAndLogResponseAsync(Exception exception,
            HttpContext httpContext,
            HttpStatusCode httpStatusCode,
            LogLevel logLevel, string alternateMessage)
        {

            string requestBody = string.Empty;

            if (httpContext.Request.Body.CanSeek)
            {
                httpContext.Request.Body.Seek(0, System.IO.SeekOrigin.Begin);
                using (var streamReader = new StreamReader(httpContext.Request.Body))
                {
                    requestBody = JsonConvert.SerializeObject(streamReader.ReadToEndAsync());
                }
            }

            StringValues authorization;

            httpContext.Request.Headers.TryGetValue("Authorization", out authorization);

            var customDetails = new StringBuilder();

            customDetails
                .AppendFormat("\n Service Url            :").Append(httpContext.Request.Path.ToString())
                .AppendFormat("\n Request Method         :").Append(httpContext.Request?.Method.ToString())
                .AppendFormat("\n Request Body           :").Append(requestBody)
                .AppendFormat("\n Authorization          :").Append(authorization)
                .AppendFormat("\n Content-Type           :").Append(httpContext.Request.Headers["Content-Type"].ToString())
                .AppendFormat("\n Cookie                 :").Append(httpContext.Request.Headers["Cookie"].ToString())
                .AppendFormat("\n Host                   :").Append(httpContext.Request.Headers["Host"].ToString())
                .AppendFormat("\n Origin                 :").Append(httpContext.Request.Headers["Origin"].ToString())
                .AppendFormat("\n User-Agent             :").Append(httpContext.Request.Headers["User-Agent"].ToString())
                .AppendFormat("\n Error Msg         :").Append(exception.Message);


            _logger.Log(logLevel, exception, customDetails.ToString());

            if (httpContext.Response.HasStarted)
            {
                _logger.LogError("The response has already been started, the http status code middleware will not be executed.");
                return;
            }

            string responseMessage = JsonConvert.SerializeObject(
                new
                {
                    Message = string.IsNullOrWhiteSpace(exception.Message) ? alternateMessage : exception.ToString()
                });

            httpContext.Response.Clear();
            httpContext.Response.ContentType = System.Net.Mime.MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)httpStatusCode;
            await httpContext.Response.WriteAsync(responseMessage, Encoding.UTF8);
        }
    }
}
