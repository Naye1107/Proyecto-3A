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
            var ejemplar =_dbContext.Ejemplares.Select(dto => new EjemplarDTO
                {
                    id_ejemplar = dto.id_ejemplar, 
                    nombre = dto.nombre,
                    edad = dto.edad,
                    id_raza = dto.id_raza,
                    id_criador = dto.id_criador,
                    id_variedad = dto.id_variedad,
                    id_color = dto.id_color,
                    descripcion = dto.descripcion,
                    foto_ejemplar = dto.foto_ejemplar,
                }).ToList();
            return View(ejemplar);
        }

        public IActionResult Details(int id)
        {
            var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == id);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == ejemplar.id_criador);

            var dto = new EjemplarDTO
            {
                nombre = ejemplar.nombre,
                edad = ejemplar.edad,
                id_raza = ejemplar.id_raza,
                criador = criador.nombre,
                id_variedad = ejemplar.id_variedad,
                id_color = ejemplar.id_color,
                descripcion = ejemplar.descripcion,
                foto_ejemplar = ejemplar.foto_ejemplar,
            };

            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == id);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == ejemplar.id_criador);

            var dto = new EjemplarDTO
            {
                nombre = ejemplar.nombre,
                edad = ejemplar.edad,
                id_raza = ejemplar.id_raza,
                criador = criador.nombre,
                id_variedad = ejemplar.id_variedad,
                id_color = ejemplar.id_color,
                descripcion = ejemplar.descripcion,
                foto_ejemplar = ejemplar.foto_ejemplar,
            };

            var raza = _dbContext.Razas.Select(raza => new RazaDTO
            {
                id_raza = raza.id_raza,
                nombre = raza.nombre
            });

            var variedad = _dbContext.Variedades.Select(variedad => new VariedadDTO
            {
                id_variedad = variedad.id_variedad,
                nombre = variedad.nombre
            });

            var color = _dbContext.Colores.Select(color => new ColorDTO
            {
                id_color = color.id_color,
                nombre = color.nombre
            });
            
            ViewBag.Raza = raza;
            ViewBag.Variedad = variedad;
            ViewBag.Color = color;

            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == id);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == ejemplar.id_criador);

            var dto = new EjemplarDTO
            {
                nombre = ejemplar.nombre,
                edad = ejemplar.edad,
                id_raza = ejemplar.id_raza,
                criador = criador.nombre,
                id_variedad = ejemplar.id_variedad,
                id_color = ejemplar.id_color,
                descripcion = ejemplar.descripcion,
                foto_ejemplar = ejemplar.foto_ejemplar,
            };

            return View(dto);
        }

        public IActionResult New()
        {
            var raza = _dbContext.Razas.Select(raza => new RazaDTO
            {
                id_raza = raza.id_raza,
                nombre = raza.nombre
            });

            var variedad = _dbContext.Variedades.Select(variedad => new VariedadDTO
            {
                id_variedad = variedad.id_variedad,
                nombre = variedad.nombre
            });

            var color = _dbContext.Colores.Select(color => new ColorDTO
            {
                id_color = color.id_color,
                nombre = color.nombre
            });
            
            ViewBag.Raza = raza;
            ViewBag.Variedad = variedad;
            ViewBag.Color = color;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(EjemplarDTO dto)
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

                var ejemplar = new Ejemplar
                {
                    nombre = dto.nombre,
                    edad = dto.edad,
                    id_raza = dto.id_raza,
                    id_criador = criador.id_criador,
                    id_variedad = dto.id_variedad,
                    id_color = dto.id_color,
                    descripcion = dto.descripcion,
                    foto_ejemplar = dto.foto_ejemplar,
                    is_deleted = 0,
                    created_date = DateTime.Now,
                    modified_date = null
                };
                _dbContext.Ejemplares.Add(ejemplar);
                _dbContext.SaveChanges();

                return RedirectToAction("Index");
            }

            var raza = _dbContext.Razas.Select(raza => new RazaDTO
            {
                id_raza = raza.id_raza,
                nombre = raza.nombre
            });

            var variedad = _dbContext.Variedades.Select(variedad => new VariedadDTO
            {
                id_variedad = variedad.id_variedad,
                nombre = variedad.nombre
            });

            var color = _dbContext.Colores.Select(color => new ColorDTO
            {
                id_color = color.id_color,
                nombre = color.nombre
            });
            
            ViewBag.Raza = raza;
            ViewBag.Variedad = variedad;
            ViewBag.Color = color;

            return View();
        }
    }
}