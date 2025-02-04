using Comunication.Response;
using Exceptions;
using Exceptions.ExceptionBase;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if(context.Exception is ExceptionBase)
                HandleProjectException(context);
            else
                ThrowUnknowException(context);
  
        }

        private void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ErroOnValidationException)
            {
                var exception = context.Exception as ErroOnValidationException;

                context.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(new ResponseErrorJson(exception.ErroMensages));
            }
        }

        private void ThrowUnknowException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            context.Result = new ObjectResult(new ResponseErrorJson(MessagesException.UNKOWN_ERROR));
        }
    }
}
