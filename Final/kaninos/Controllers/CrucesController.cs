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
    public class CrucesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public CrucesController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var cruce =_dbContext.Cruces.Select(c => new CruceDTO
                {
                    id = c.id,
                    nombre = c.nombre,
                    id_macho = c.id_macho,
                    id_hembra = c.id_hembra,
                    fecha_emp = c.fecha_emp,
                    fecha_nac = c.fecha_nac,
                    ejemplares_nac = c.ejemplares_nac,
                    cantidad_machos = c.cantidad_machos,
                    cantidad_hembras = c.cantidad_hembras,
                    num_bajas = c.num_bajas,
                    id_criador = c.id_criador,
                }).ToList();
            return View(cruce);
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
        public IActionResult New(CruceDTO dto)
        {
            var cruce = new Cruce
            {
                nombre = dto.nombre,
                id_macho = dto.id_macho,
                id_hembra = dto.id_hembra,
                fecha_emp = dto.fecha_emp,
                fecha_nac = dto.fecha_nac,
                ejemplares_nac = dto.ejemplares_nac,
                cantidad_machos = dto.cantidad_machos,
                cantidad_hembras = dto.cantidad_hembras,
                num_bajas = dto.num_bajas,
                id_criador = dto.id_criador,
                is_deleted = false,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Cruces.Add(cruce);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}