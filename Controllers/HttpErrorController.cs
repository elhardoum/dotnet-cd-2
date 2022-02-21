using Microsoft.AspNetCore.Mvc;

namespace DotnetCd.Controllers
{
    public class HttpErrorController : Controller
    {
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult _404()
        {
            return View();
        }
    }
}
