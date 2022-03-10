using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PopupManageAndRedirect.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopupManageAndRedirect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult ReturnForm()
        {
            StringBuilder html = new StringBuilder();
            html.AppendLine("<script type='text/javascript'>");
                html.AppendLine("function popup(){");
                //html.AppendLine("var popupWindow=window.open('https://www.microsoft.com/es-mx/','microsoft');");
                //html.AppendLine("var mainWindow=popupWindow.opener;");
                //html.AppendLine("console.log(popupWindow);");
                //html.AppendLine("console.log(mainWindow);");
                //html.AppendLine("popupWindow.blur();");
                //html.AppendLine("mainWindow.focus();");
                html.AppendLine("setTimeout(function(){");
                                html.AppendLine("window.location.replace('https://www.google.com/maps');");
                html.AppendLine("},3000);");
                html.AppendLine("}");
            html.AppendLine("</script>");
            html.AppendLine("<html>");
                html.AppendLine("<body onload='popup()'>");
                    html.AppendLine("Nueva pagina");
                html.AppendLine("</body>");
            html.AppendLine("</html>");


            return new ContentResult()
            {
                Content = html.ToString(),
                ContentType = "text/html"
            };
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
