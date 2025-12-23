using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using validationDemo.Models;

namespace ExceptionDemo.Filters
{
    public class GlobalExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {

            if (context.Exception is StudentNotFoundException)
            {
                context.Result = new ViewResult
                {
                    ViewName = "StudentNotFound"
                };
                context.HttpContext.Items["ErrorMessage"] = context.Exception.Message;
            }

            else
            {
                context.Result = new ViewResult
                {
                    ViewName = "Error"
                };

            }
                context.ExceptionHandled = true;
            }
        }
    }

