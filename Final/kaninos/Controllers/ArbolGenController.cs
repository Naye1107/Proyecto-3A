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
    public class ArbolGenController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        public ArbolGenController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var arbol_gen =_dbContext.ArbolGen.Select(dto => new EjemplarDTO
                {
                    ejemplar = dto.ejemplar,
                    id_padre = dto.id_padre,
                    id_madre = dto.id_madre
                }).ToList();

            return View(arbol_gen);
        }
    }
}