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

namespace Kaninos.Controllers
{
    public class CriadoresController : Controller
    {
        private string UploadPhoto(IFormFile file)
        {
            if(file == null)
            {
                return "not-found.png";
            }

            var fileName = string.Empty;
            string uploadFolder = Path.Combine(_hosting.WebRootPath, "image");
                fileName = $"{Guid.NewGuid()}_{file.FileName.Trim()}";
                var filePath = Path.Combine(uploadFolder, fileName);

                file.CopyTo(new FileStream(filePath, FileMode.Create));
                return fileName;
        }
    
        private readonly ApplicationDbContext _dbContext;
        private readonly IWebHostEnvironment _hosting;
        public CriadoresController(ApplicationDbContext dbContext, IWebHostEnvironment hostEnvironment)
        {
            _dbContext = dbContext;
            _hosting = hostEnvironment;
        }

        public IActionResult Index()
        {
            var criador =_dbContext.Criadores.Select(c => new CriadorDTO
                {
                    id_criador = c.id_criador,
                    nombre = c.nombre,
                    email = c.email,
                    direccion = c.direccion,
                    facebook = c.facebook == null ? "N/A" : c.facebook,
                    twitter = c.twitter == null ? "N/A" : c.twitter,
                    youtube = c.youtube == null ? "N/A" : c.youtube,
                    logotipo = c.logotipo,
                    fotografia = c.fotografia,
                }).ToList();
            return View(criador);
        }

        public IActionResult Details(int id)
        {
            var criador = _dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == id);
            var dto = new CriadorDTO
            {
                nombre = criador.nombre,
                email = criador.email,
                direccion= criador.direccion,
                facebook = criador.facebook ?? "N/A",
                twitter = criador.twitter ?? "N/A",
                youtube = criador.youtube ?? "N/A",
                logotipo = criador.logotipo,
                fotografia = criador.fotografia
            };

            return View(dto);
        }

        public IActionResult Edit(int id)
        {
            var criador = _dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == id);
            var dto = new CriadorDTO
            {
                nombre = criador.nombre,
                email = criador.email,
                direccion= criador.direccion,
                facebook = criador.facebook,
                twitter = criador.twitter,
                youtube = criador.youtube,
                logotipo = criador.logotipo,
                fotografia = criador.fotografia
            };

            return View(dto);
        }

        public IActionResult Delete(int id)
        {
            var criador = _dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == id);
            var dto = new CriadorDTO
            {
                id_criador = criador.id_criador,
                nombre = criador.nombre,
                email = criador.email,
                direccion= criador.direccion,
                facebook = criador.facebook ?? "N/A",
                twitter = criador.twitter ?? "N/A",
                youtube = criador.youtube ?? "N/A",
                logotipo = criador.logotipo,
                fotografia = criador.fotografia
            };

            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CriadorDTO dto)
        {
            var criador = _dbContext.Criadores.FirstOrDefault(criador => criador.id_criador == dto.id_criador);
            if(criador == null)
            {
                return NotFound();
            }
            
            _dbContext.Criadores.Remove(criador);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
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
                is_deleted = 0,
                created_date = DateTime.Now,
                modified_date = null
            };
            _dbContext.Criadores.Add(criador);
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        
        [HttpPost]    
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CriadorDTO dto )
        {
            var fileName = UploadPhoto(dto.foto);
            var criador = await _dbContext.Criadores.FirstOrDefaultAsync(criador => criador.id_criador == id);
            if(criador == null)
            {
                return NotFound();
            }
                criador.nombre = dto.nombre;
                criador.email = dto.email;
                criador.direccion = dto.direccion;
                criador.facebook = dto.facebook;
                criador.twitter = dto.twitter;
                criador.youtube = dto.youtube;
                criador.logotipo = dto.logotipo;
                criador.fotografia = fileName;
                criador.modified_date = DateTime.Now;
                
                _dbContext.Criadores.Update(criador);
                await _dbContext.SaveChangesAsync();

                return RedirectToAction("Index");
        }
    }
}