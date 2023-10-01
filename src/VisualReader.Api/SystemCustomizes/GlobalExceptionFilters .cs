using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;
using VisualReader.Application.Constants;
using VisualReader.Application.Models.Errors;

namespace VisualReader.Api.SystemCustomizes
{
    public class GlobalExceptionFilters : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var exception = context.Exception;
            context.ExceptionHandled = true;
            string traceId = Activity.Current.Context.TraceId.ToString();
            switch (exception)
            {
                case EntityValidationException validation:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, Message = validation.Message, ErrorCode = validation.ErrorCode, DetailCode = validation.DetailCode, Failures = validation.Failures, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;

                case EntityNotFoundException notFoundValidation:
                    context.Result = new NotFoundObjectResult(new { IsSuccess = false, Message = notFoundValidation.Message, ErrorCode = notFoundValidation.ErrorCode, DetailCode = notFoundValidation.DetailCode, TraceId = traceId, Payload = notFoundValidation.Payload });
                    context.ExceptionHandled = true;
                    break;

                case ErrorResponseMessage baseException:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, Message = baseException.Message, ErrorCode = baseException.ErrorCode, DetailCode = baseException.DetailCode, TraceId = traceId });
                    context.ExceptionHandled = true;
                    break;

                default:
                    context.Result = new BadRequestObjectResult(new { IsSuccess = false, ErrorCode = ExceptionErrorCode.ERROR_GENERIC_COMMON_EXCEPTION, TraceId = traceId });
                    break;
            }
        }
    }
}