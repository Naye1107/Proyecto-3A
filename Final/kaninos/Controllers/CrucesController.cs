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
            var cruce =_dbContext.Cruces
                /*.Include(cruce => cruce.Ejemplar)*/
                .Select(cruce => new CruceDTO
                {
                    id = cruce.id,
                    nombre = cruce.nombre,
                    id_macho = cruce.id_macho,
                    id_hembra = cruce.id_hembra,
                    fecha_emp = cruce.fecha_emp,
                    fecha_nac = cruce.fecha_nac,
                    ejemplares_nac = cruce.ejemplares_nac,
                    cantidad_machos = cruce.cantidad_machos,
                    cantidad_hembras = cruce.cantidad_hembras,
                    num_bajas = cruce.num_bajas,
                    id_criador = cruce.id_criador,
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