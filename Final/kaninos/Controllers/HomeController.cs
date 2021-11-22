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
using System.Text.RegularExpressions;

namespace kaninos.Controllers
{


    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
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
            var login = _dbContext.Logins.FirstOrDefault(login => login.email == dto.email && login.pass == dto.pass);

            ViewBag.Message = "Email y Contraseña No Coinciden";

            return login == null ? View() : RedirectToAction("Administrador", "Home");
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

        #region Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(LoginDTO dto)
        {
            var email = _dbContext.Logins.Select(email => new LoginDTO
            {
                email = email.email,
            });

            var pass = _dbContext.Logins.Select(pass => new LoginDTO
            {
                pass = pass.pass,
            });

            ViewBag.email = email;
            ViewBag.pass = pass;


            if (email(dto) == null)
            {
                ViewBag.Message0 = "Por favor, ingrese un correo valido";
            }

            if (email(dto) == null)
            {
                ViewBag.Message1 = "Por favor, ingrese una contraseña valida";
            }
            return View();

        }
        #endregion

        #region funciones
        //Login
        public bool emailvacio(LoginDTO dto)
        {
            bool result = false;

            try
            {
                if (Regex.IsMatch(dto.email, @"^[a-zA-Z\u00f1\u00d1\u00E0-\u00FC\s]+$"))
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }

        public Login Emailexist(LoginDTO dto)
        {
            try
            {
                var email = _dbContext.Logins.FirstOrDefault(x => x.email == dto.email);
                return email;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public bool CorrectPass(LoginDTO dto)
        {
            bool result = false;

            try
            {
                if (Emailexist(dto).pass==dto.pass)
                {
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }

            return result;
        }
        //finlogin
        #endregion
      
    }
}