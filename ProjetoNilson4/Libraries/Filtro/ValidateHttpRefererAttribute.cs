using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
namespace ProjetoNilson4.Libraries.Filtro
{
    public class ValidateHttpRefererAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            string referer = context.HttpContext.Request.Headers["Referer"].ToString();
            if (string.IsNullOrEmpty(referer))
            {
                context.Result = new ContentResult() { Content = "Acesso negado!!" };
            }
            else 
            {
                Uri uri = new Uri(referer);
                string hostReferer = uri.Host;
                string hostsServidor = context.HttpContext.Request.Host.Host;

                if (hostReferer != hostsServidor)
                {
                    context.Result = new ContentResult() { Content = "Acessso Negado!!" };
                }
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
