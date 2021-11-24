using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using kaninos.Data;
using kaninos.Entities;
using kaninos.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Kaninos.Controllers
{
    public class EjemplaresController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hosting;
        public EjemplaresController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hosting = hostEnvironment;
        }
        
        #region cosas que no sirven por ahora
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
            var color =_dbContext.Colores.FirstOrDefault(color => color.id_color == ejemplar.id_color);
            var variedad =_dbContext.Variedades.FirstOrDefault(variedad => variedad.id_variedad == ejemplar.id_variedad);
            var raza =_dbContext.Razas.FirstOrDefault(raza => raza.id_raza == ejemplar.id_raza);

            var dto = new EjemplarDTO
            {
                nombre = ejemplar.nombre,
                edad = ejemplar.edad,
                raza = raza.nombre,
                criador = criador.nombre,
                variedad = variedad.nombre,
                color = color.nombre,
                descripcion = ejemplar.descripcion,
                foto_ejemplar = ejemplar.foto_ejemplar,
            };

            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == id);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == ejemplar.id_criador);
            var padre =_dbContext.Ejemplares.FirstOrDefault(padre => padre.id_ejemplar == ejemplar.id_padre);
            var madre =_dbContext.Ejemplares.FirstOrDefault(madre => madre.id_ejemplar == ejemplar.id_madre);

            var dto = new EjemplarDTO
            {
                id_ejemplar = ejemplar.id_ejemplar,
                nombre = ejemplar.nombre,
                padre = padre.nombre,
                madre = madre.nombre,
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EjemplarDTO dto)
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
                var nombre_foto = UploadPhoto(dto.foto);

                var padre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);
                var madre =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);
                var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.nombre == dto.criador);

                var ejemplar = await _dbContext.Ejemplares.FirstOrDefaultAsync(ejemplar => ejemplar.id_ejemplar == dto.id_ejemplar);
                if(ejemplar == null)
                {
                    return NotFound();
                }

                ejemplar.nombre = dto.nombre;
                ejemplar.id_padre = padre.id_ejemplar;
                ejemplar.id_madre = madre.id_ejemplar;
                ejemplar.edad = dto.edad;
                ejemplar.id_raza = dto.id_raza;
                ejemplar.id_criador = criador.id_criador;
                ejemplar.id_variedad = dto.id_variedad;
                ejemplar.id_color = dto.id_color;
                ejemplar.descripcion = dto.descripcion;
                ejemplar.foto_ejemplar = nombre_foto;
                ejemplar.modified_date = DateTime.Now;

                _dbContext.Ejemplares.Update(ejemplar);
                await _dbContext.SaveChangesAsync();

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

            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var ejemplar =_dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == id);
            var criador =_dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == ejemplar.id_criador);
            var color =_dbContext.Colores.FirstOrDefault(color => color.id_color == ejemplar.id_color);
            var variedad =_dbContext.Variedades.FirstOrDefault(variedad => variedad.id_variedad == ejemplar.id_variedad);
            var raza =_dbContext.Razas.FirstOrDefault(raza => raza.id_raza == ejemplar.id_raza);

            var dto = new EjemplarDTO
            {
                id_ejemplar = ejemplar.id_ejemplar,
                nombre = ejemplar.nombre,
                edad = ejemplar.edad,
                raza = raza.nombre,
                criador = criador.nombre,
                variedad = variedad.nombre,
                color = color.nombre,
                descripcion = ejemplar.descripcion,
                foto_ejemplar = ejemplar.foto_ejemplar,
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(EjemplarDTO dto)
        {
            var ejemplar = _dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.id_ejemplar == dto.id_ejemplar);
            if(ejemplar == null)
            {
                return NotFound();
            }
            
            _dbContext.Ejemplares.Remove(ejemplar);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        #endregion
        
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

            if (padreExist(dto) == null)
            {
                ViewBag.Message0="No encontramos el dato solicitado. Campo: Padre";
            }

            if (madreExist(dto) == null)
            {
                ViewBag.Message1="No encontramos el dato solicitado. Campo: Madre";
            }

            if (criadorExist(dto) == null)
            {
                ViewBag.Message2="No encontramos el dato solicitado. Campo: Criador";
            }
 
            if (!formatoNombre(dto))
            {
                ViewBag.Message3="Caracteres no validos. Campo: Nombre";
            }

            if (!formatoDescripcion(dto))
            {
                ViewBag.Message4="Caracteres no validos. Campo: Descripcion";
            }

            var nombre_foto = "not-found.png";
            if(dto.foto != null)
            {    
                if (IsImage(dto.foto))
                {
                    nombre_foto = UploadPhoto(dto.foto);
                }
                else
                {
                    ViewBag.Message="Formato de archivo incorrecto. Campo: Fotografia";
                    return View();
                }
            }

            if(dto.btn_padre != null)
            {
                var padre = padreExist(dto);
                if (padre != null)
                {
                    ViewBag.Padre = padre.id_ejemplar;

                    ViewBag.Message="Busqueda exitosa";
                }else
                {
                    ViewBag.Message="No encontramos el dato solicitado. Campo: Padre";
                }
            }else if(dto.btn_madre != null)
            {
                var madre = madreExist(dto);
                if (madre != null)
                {
                    ViewBag.Madre = madre.id_ejemplar;

                    ViewBag.Message="Busqueda exitosa";
                }else
                {
                    ViewBag.Message="No encontramos el dato solicitado. Campo: Madre";
                }
            }else if (dto.btn_criador != null)
            {
                var criador = criadorExist(dto);
                if (criador != null)
                {
                    ViewBag.Criador = criador.id_criador;

                    ViewBag.Message="Busqueda exitosa";
                }else
                {
                    ViewBag.Message="No encontramos el dato solicitado. Campo: Criador";
                }
            } else if (dto.btn_reg != null && insertToDB(dto, nombre_foto))
            {
                return RedirectToAction("Index");

                //return View(ejemplar);
            }
            return View();
        }

        #region funciones

        public bool formatoDescripcion(EjemplarDTO dto)
        {
            bool result = false;
            
            try
            {
                if(Regex.IsMatch(dto.descripcion, @"^[a-zA-Z\u00f1\u00d1\u00E0-\u00FC\s]+$"))
                {
                    result = true;
                }
            }
            catch(Exception)
            {
                result = false;
            }

            return result;
        }

        public bool formatoNombre(EjemplarDTO dto)
        {
            bool result = false;

            try
            {
                if(Regex.IsMatch(dto.nombre, @"^[a-zA-Z\u00f1\u00d1\u00E0-\u00FC\s]+$"))
                {
                    result = true;
                }
            }
            catch(Exception)
            {
                result = false;
            }

            return result;
        }

        public Criador criadorExist(EjemplarDTO dto)
        {
            try
            {
                var criador = _dbContext.Criadores.FirstOrDefault(x => x.nombre == dto.criador);
                return criador;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Ejemplar madreExist(EjemplarDTO dto)
        {
            try
            {
                var madre = _dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.madre);
                return madre;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public Ejemplar padreExist(EjemplarDTO dto)
        {
            try
            {
                var padre = _dbContext.Ejemplares.FirstOrDefault(ejemplar => ejemplar.nombre == dto.padre);
                return padre;
            }
            catch(Exception)
            {
                return null;
            }
        }

        public bool insertToDB(EjemplarDTO dto, String nombre_foto)
        {
            bool result = false;
            var padre = padreExist(dto);
            var madre = madreExist(dto);
            var criador = criadorExist(dto);

            if (padre == null || madre == null || criador == null ||dto.nombre == string.Empty || dto.descripcion == string.Empty || dto.edad <= 0 || dto.id_raza <= 0 || dto.id_variedad <= 0 || dto.id_color <= 0)
            {
                return result;
            }

            if (formatoDescripcion(dto) && formatoNombre(dto))
            {
                var ejemplar = new Ejemplar
                {
                    nombre = dto.nombre,
                    id_padre = padre.id_ejemplar,
                    id_madre = madre.id_ejemplar,
                    edad = dto.edad,
                    id_raza = dto.id_raza,
                    id_criador = criador.id_criador,
                    id_variedad = dto.id_variedad,
                    id_color = dto.id_color,
                    descripcion = dto.descripcion,
                    foto_ejemplar = nombre_foto,
                    is_deleted = 0,
                    created_date = DateTime.Now,
                    modified_date = null
                };

                try
                {
                    _dbContext.Ejemplares.Add(ejemplar);
                    _dbContext.SaveChanges();
                    result = true;
                }
                catch (Exception)
                {
                    result = false;
                }
            }
            return result;
        }

        private string UploadPhoto(IFormFile file)
        {
            var fileName = string.Empty;
            fileName = $"{Guid.NewGuid()}_{file.FileName.Trim()}";

            string uploadFolder = Path.Combine(_hosting.WebRootPath, "image/usr");
            var filePath = Path.Combine(uploadFolder, fileName);

            try
            {
                file.CopyTo(new FileStream(filePath, FileMode.Create));
                return fileName;
            }
            catch(Exception)
            {
                return string.Empty;
            }
        }

        private bool IsImage(IFormFile file)
        {
            string[] images = { ".png", ".jpg", ".jpeg", ".gif" };

            var fileName = string.Empty;
            fileName = file.FileName.Trim();

            try
            {
                if (images.Contains(Path.GetExtension(fileName)))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch(Exception)
            {
                return false;
            }
        }
        
        #endregion
    }
}