using Confluent.Kafka;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using ToyShop.Services.Monitoring.Coontracts;
using static ToyShop.Services.Monitoring.Models.MonitoringModels;

namespace ToyShop.Server.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IMonitoringProducerService monitoringProducer;

        public ExceptionHandlingMiddleware(RequestDelegate next, IMonitoringProducerService monitoringProducer)
        {
            _next = next;
            this.monitoringProducer = monitoringProducer;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await this._next(httpContext);
            }
            catch (Exception e)
            {
                await monitoringProducer
                        .ProduceAsync(new AlertModel(DateTime.Now.ToString(), e.Message));

                await this.HandleExceptionAsync(e, httpContext);
            }
        }

        private async Task HandleExceptionAsync(Exception exception, HttpContext httpContext)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new
            {
#if DEBUG
                Message = exception.Message,
#else
                Message = "An unhandled error has occurred on the server.",
#endif     
            };

            var json = JsonConvert.SerializeObject(response);
            await httpContext.Response.WriteAsync(json);
        }
    }
}
