using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace kaninos.Controllers
{
    public class AdministradorController : Controller
    {
        public AdministradorController()
        {
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Criadores()
        {
            return View();
        }
        public IActionResult Cruces()
        {
            return View();
        }
        public IActionResult Ejemplares()
        {
            return View();
        }
        public IActionResult ArbolGen()
        {
            return View();
        }
    }
}