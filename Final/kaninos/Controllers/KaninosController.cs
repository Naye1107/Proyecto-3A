using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kaninos.Controllers
{
    public class KaninosController : Controller
    {
        public KaninosController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}