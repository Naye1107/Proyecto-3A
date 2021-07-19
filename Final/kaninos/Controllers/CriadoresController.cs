using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kaninos.Data;
using kaninos.Entities;
using kaninos.Models;

namespace Kaninos.Controllers
{
    public class CriadoresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CriadoresController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete()
        {
            return View();
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(CriadorDTO dto)
        {
            var criador = new Criador
            {
                nombre = dto.nombre,
                email = dto.email,
                direccion = dto.direccion,
                facebook = dto.facebook,
                twitter = dto.twitter,
                youtube = dto.youtube,
                logotipo = dto.logotipo,
                fotografia = dto.fotografia,
                is_deleted = false,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Criadores.Add(criador);
            _dbContext.SaveChanges();
            return View();
        }
    }
}