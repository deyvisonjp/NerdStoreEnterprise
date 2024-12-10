
using System.Net;

namespace NSE.WebApp.MVC.Extensions;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        } catch (CustomHttpRequestException ex) 
        {
            HandleRequestExceptionAsync(context, ex);
        }
    }

    private void HandleRequestExceptionAsync(HttpContext httpContext, CustomHttpRequestException ex)
    {
        if (ex.StatusCode == HttpStatusCode.Unauthorized)
        {
            //Redireciona para a paágina em que estava antes de dar não autorizado e fazer o login
            httpContext.Response.Redirect($"/login?ReturnUrl={httpContext.Request.Path}");
            return;
        }
        httpContext.Response.StatusCode = (int)ex.StatusCode;
    }
}
