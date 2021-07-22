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
    public class EjemplaresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public EjemplaresController(ApplicationDbContext dbContext)
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
        public IActionResult New(EjemplarDTO dto)
        {
            var ejemplar = new Ejemplar
            {
                nombre = dto.nombre,
                edad = dto.edad,
                id_raza = dto.id_raza,
                id_criador = dto.id_criador,
                id_variedad = dto.id_variedad,
                id_color = dto.id_color,
                descripcion = dto.descripcion,
                foto_ejemplar = dto.foto_ejemplar,
                is_deleted = false,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Ejemplares.Add(ejemplar);
            _dbContext.SaveChanges();
            
            return RedirectToAction("Index");
        }
    }
}