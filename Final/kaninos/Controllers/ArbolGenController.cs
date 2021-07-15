using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Kaninos.Controllers
{
    public class ArbolGenController : Controller
    {
        public ArbolGenController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}