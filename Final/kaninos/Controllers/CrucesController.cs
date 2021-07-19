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
        public IActionResult New(CruceDTO dto)
        {
            var cruce = new Cruce
            {
                nombre = dto.nombre,
                id_macho = dto.macho,
                id_hembra = dto.hembra,
                fecha_emp = dto.fecha_emp,
                fecha_nac = dto.fecha_nac,
                ejemplares_nac = dto.ejemplares_nac,
                cantidad_machos = dto.cantidad_machos,
                cantidad_hembras = dto.cantidad_hembras,
                num_bajas = dto.num_bajas,
                id_criador = dto.criador,
                is_deleted = false,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Cruces.Add(cruce);
            _dbContext.SaveChanges();
            return View();
        }
    }
}