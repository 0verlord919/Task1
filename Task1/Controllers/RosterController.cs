using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1.Controllers
{
    public class RosterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
