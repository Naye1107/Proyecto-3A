using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using kaninos.Models;
using kaninos.Data;
using kaninos.Entities;



namespace kaninos.Controllers
{

    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger,ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }
   

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Administrador()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDTO dto)
        {
            var login =_dbContext.Logins.FirstOrDefault(login => login.email == dto.email && login.pass == dto.pass);            
            
            ViewBag.Message="Email y Contraseña No Coinciden";
            
            return login == null ? View() : RedirectToAction("Index","Home");
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registro(LoginDTO dto)
        {
            var login = new Login
            {
                nombre = dto.nombre,
                apellido = dto.apellido,
                email = dto.email,
                pass = dto.pass,
                is_deleted = 0,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Logins.Add(login);
            _dbContext.SaveChanges();

            return RedirectToAction("Login");
        }
        
        public IActionResult Noticias()
        {
            return View();
        }

        public IActionResult acercade()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
