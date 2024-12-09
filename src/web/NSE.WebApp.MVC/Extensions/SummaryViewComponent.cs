using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace NSE.WebApp.MVC.Extensions;

public class SummaryViewComponent: ViewComponent
{
    public async Task<IViewComponentResult> InvokeAsync()
    {
        return View();
    }

}
