using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using System.Threading.Tasks;
using System.Linq;

namespace DotnetCd.Controllers
{
    public class MembersController : Controller
    {
        public async Task<IActionResult> Index()
        {
            ViewData["items"] = (await Models.Users.list()).OrderByDescending(o => o.Id).ToList();

            return View();
        }
    }
}
