using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kaninos.Data;
using kaninos.Entities;
using kaninos.Models;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult Details(int id)
        {
            var cruce = _dbContext.Cruces.FirstOrDefault(cruce => cruce.id == id);
            var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_macho);
            var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_hembra);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == cruce.id_criador);
            var dto = new CruceDTO
            {
                nombre = cruce.nombre,
                padre = padre.nombre,
                madre = madre.nombre,
                fecha_emp = cruce.fecha_emp,
                fecha_nac = cruce.fecha_nac,
                ejemplares_nac = cruce.ejemplares_nac,
                cantidad_machos = cruce.cantidad_machos,
                cantidad_hembras = cruce.cantidad_hembras,
                num_bajas = cruce.num_bajas,
                criador = criador.nombre,
            };

            return View(dto);
        }

        public IActionResult Edit(int id )
        {
            var cruce = _dbContext.Cruces.FirstOrDefault(cruce => cruce.id == id);
            var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_macho);
            var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_hembra);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == cruce.id_criador);
            var dto = new CruceDTO
            {
                id = cruce.id,
                nombre = cruce.nombre,
                padre = padre.nombre,
                madre = madre.nombre,
                fecha_emp = cruce.fecha_emp,
                fecha_nac = cruce.fecha_nac,
                ejemplares_nac = cruce.ejemplares_nac,
                cantidad_machos = cruce.cantidad_machos,
                cantidad_hembras = cruce.cantidad_hembras,
                num_bajas = cruce.num_bajas,
                criador = criador.nombre,
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CruceDTO dto)
        {
            if(dto.btn_padre != null)
            {
                var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);            
            
                if (ejemplar != null)
                    {
                        ViewBag.Padre = ejemplar.id_ejemplar;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Ejemplar solicitado";
                    }
            }else if(dto.btn_madre != null)
            {
                var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);            
            
                if (ejemplar != null)
                    {
                        ViewBag.Madre = ejemplar.id_ejemplar;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Criador solicitado";
                    }
            }else if (dto.btn_criador != null)
            {
                var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.nombre == dto.criador);            
            
                if (criador != null)
                    {
                        ViewBag.Criador = criador.id_criador;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Criador solicitado";
                    }
            } else if (dto.btn_reg != null)
            {
                var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);
                var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);
                var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.nombre == dto.criador);

                var cruce = await _dbContext.Cruces.FirstOrDefaultAsync(cruce => cruce.id == dto.id);
                if(cruce == null)
                {
                    return NotFound();
                }
                    cruce.nombre = dto.nombre;
                    cruce.id_macho = padre.id_ejemplar;
                    cruce.id_hembra = madre.id_ejemplar;
                    cruce.fecha_emp = dto.fecha_emp;
                    cruce.fecha_nac = dto.fecha_nac;
                    cruce.ejemplares_nac = dto.ejemplares_nac;
                    cruce.cantidad_machos = dto.cantidad_machos;
                    cruce.cantidad_hembras = dto.cantidad_hembras;
                    cruce.num_bajas = dto.num_bajas;
                    cruce.id_criador = criador.id_criador;
                    cruce.modified_date = DateTime.Now;

                _dbContext.Cruces.Update(cruce);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return View();
        }

        public IActionResult Delete(int id)
        {
            var cruce = _dbContext.Cruces.FirstOrDefault(cruce => cruce.id == id);
            var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_macho);
            var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == cruce.id_hembra);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == cruce.id_criador);
            var dto = new CruceDTO
            {
                id = cruce.id,
                nombre = cruce.nombre,
                padre = padre.nombre,
                madre = madre.nombre,
                fecha_emp = cruce.fecha_emp,
                fecha_nac = cruce.fecha_nac,
                ejemplares_nac = cruce.ejemplares_nac,
                cantidad_machos = cruce.cantidad_machos,
                cantidad_hembras = cruce.cantidad_hembras,
                num_bajas = cruce.num_bajas,
                criador = criador.nombre,
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CruceDTO dto)
        {
            var cruce = _dbContext.Cruces.FirstOrDefault(cruce => cruce.id == dto.id);
            if(cruce == null)
            {
                return NotFound();
            }
            
            _dbContext.Cruces.Remove(cruce);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult New()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(CruceDTO dto)
        {
            if(dto.btn_padre != null)
            {
                var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);            
            
                if (ejemplar != null)
                    {
                        ViewBag.Padre = ejemplar.id_ejemplar;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Ejemplar solicitado";
                    }
            }else if(dto.btn_madre != null)
            {
                var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);            
            
                if (ejemplar != null)
                    {
                        ViewBag.Madre = ejemplar.id_ejemplar;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Criador solicitado";
                    }
            }else if (dto.btn_criador != null)
            {
                var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.nombre == dto.criador);            
            
                if (criador != null)
                    {
                        ViewBag.Criador = criador.id_criador;

                        ViewBag.Message="Busqueda exitosa";
                    }else
                    {
                        ViewBag.Message="No encontramos al Criador solicitado";
                    }
            } else if (dto.btn_reg != null)
            {
                var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);
                var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);
                var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.nombre == dto.criador);

                var cruce = new Cruce
                {
                    nombre = dto.nombre,
                    id_macho = padre.id_ejemplar,
                    id_hembra = madre.id_ejemplar,
                    fecha_emp = dto.fecha_emp,
                    fecha_nac = dto.fecha_nac,
                    ejemplares_nac = dto.ejemplares_nac,
                    cantidad_machos = dto.cantidad_machos,
                    cantidad_hembras = dto.cantidad_hembras,
                    num_bajas = dto.num_bajas,
                    id_criador = criador.id_criador,
                    is_deleted = 0,
                    created_date = DateTime.Now,
                    modified_date = null
                };
                _dbContext.Cruces.Add(cruce);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            return View();
        }
    }
}