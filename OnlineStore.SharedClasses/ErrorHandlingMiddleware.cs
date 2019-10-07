using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.SharedClasses
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;
        private static ILoggerProvider _logger;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ILoggerProvider logger)
        {
            try
            {
                _logger = logger;

                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var statusCode = HttpStatusCode.InternalServerError; // 500 if unexpected

            var message = GetErrorMessage(exception);

            var userMessage = GetUserMessage(exception);

            HttpResponse response = context.Response;
            response.StatusCode = (int)statusCode;
            response.ContentType = "application/json";

            var result = new { Succeeded = false, ErrorMessage = userMessage, Result = string.Empty };

            var newLogger = _logger.CreateLogger("");
            newLogger.LogError(exception, message);

            await response.WriteAsync(JsonConvert.SerializeObject(result));
        }

        private static string GetUserMessage(Exception exception)
        {
            string userMessage = "An error occured while processing the request. Please contact your administrator for details.";

            if (exception.GetType() == typeof(SqlException))
            {
                userMessage = "A database error occured while processing the request. Please contact your administrator for details.";
            }

            return userMessage;
        }

        private static string GetErrorMessage(Exception ex)
        {
            var message = ex.Message;

            if (ex.InnerException != null)
                return GetErrorMessage(ex.InnerException);
            else
                return message;
        }
    }
}
