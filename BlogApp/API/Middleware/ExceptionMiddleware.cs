using API.Middleware;
using API.Middleware.ExceptionEntity;
using Application.Exceptions;
using Newtonsoft.Json;
using System.Net;

namespace API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        public Task HandleExceptionAsync(HttpContext context, Exception exception)
        {   
            // default exception type
            context.Response.ContentType = "application/json";
            var StatusCode = HttpStatusCode.InternalServerError;

            var result = JsonConvert.SerializeObject(new ErrorModel()
            {
                ErrorType = "Failure",
                ErrorMessage = exception.Message
            });

            switch (exception)
            {
                case (BadRequestException badRequestException):
                    StatusCode = HttpStatusCode.BadRequest;
                    break;
                case (NotFoundException notFoundException):
                    StatusCode = HttpStatusCode.NotFound;
                    break;
                case (ValidationException validationException):
                    StatusCode = HttpStatusCode.BadRequest;
                    result = JsonConvert.SerializeObject(validationException.Errors);
                    break;
                default:
                    break;
            }

            context.Response.StatusCode = (int)StatusCode;
            return context.Response.WriteAsync(result);
        }
    }
}



//private readonly RequestDelegate _next;
//public ExceptionMiddleware(RequestDelegate next)
//{
//    _next = next;
//}
//public async Task InvokeAsync(HttpContext httpContext)
//{
//    try
//    {
//        await _next(httpContext);
//    }
//    catch (Exception ex)
//    {
//        await HandleExceptionAsync(httpContext, ex);
//    }
//}
//private Task HandleExceptionAsync(HttpContext context, Exception exception)
//{
//    context.Response.ContentType = "application/json";

//    HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
//    string result = JsonConvert.SerializeObject(
//        new ErrorDeatils
//        {
//            ErrorMessage = exception.Message,
//            ErrorType = "Failure"
//        }
//     );

//    switch (exception)
//    {
//        case BadRequestException badRequestException:
//            statusCode = HttpStatusCode.BadRequest;
//            break;
//        case ValidationException validationException:
//            statusCode = HttpStatusCode.BadRequest;
//            result = JsonConvert.SerializeObject(validationException.Errors);
//            break;
//        case NotFoundException notFoundException:
//            statusCode = HttpStatusCode.NotFound;
//            break;
//        default:
//            break;
//    }

//    context.Response.StatusCode = (int)statusCode;
//    return context.Response.WriteAsync(result);
//}
//    }

//    public class ErrorDeatils
//{
//    public string ErrorType { get; set; }
//    public string ErrorMessage { get; set; }
//}






