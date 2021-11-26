using kaninos.Data;
using kaninos.Entities;
using kaninos.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace kaninos.Controllers
{


    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(/*ILogger<HomeController> logger,*/ ApplicationDbContext dbContext)
        {
            //_logger = logger;
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
          var existecorreo =
                _dbContext.Logins.Where(Q => Q.email == dto.email).FirstOrDefault();

            if (existecorreo == null)
            {
                _dbContext.Logins.Add(login);
                _dbContext.SaveChanges();
            }
            else {
                dto.id_log = -1;
            }

            _dbContext.Logins.Add(login);
            _dbContext.SaveChanges();

            return RedirectToAction("Login","Home",dto);
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
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDTO dto)
        {
            if (!formatoEmail(dto))
            {
                ViewBag.Message = "Por favor, ingrese un correo valido";
                dto.id_log = 0;
            }

            if (Emailexist(dto) == null)
            {
                ViewBag.Message = "Este Correo No Esta Registrado, Ingrese Un Correo Existente";
                dto.id_log = 0;
            }

            if (CorrectPass(dto))
            {
                return RedirectToAction("Administrador", "Home");

            }
            else
            {
                ViewBag.Message = "Correo y Contraseña No Coinciden.";
                dto.id_log = 0;
            }

            return View(dto);
        }
        #endregion

        #region funciones
        public bool formatoEmail(LoginDTO dto)
        {
            bool result = false;

            try
            {
                if (Regex.IsMatch(dto.email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
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
            var email = Emailexist(dto);

            if (email == null || dto.email == String.Empty)
            {
                return result;
            }

            if (formatoEmail(dto))
            {
                try
                {
                    if (email.pass == dto.pass)
                    {
                        result = true;
                    }
                }
                catch (Exception)
                {
                    result = false;
                }
            }

            return result;
        }
        #endregion

    }
}
