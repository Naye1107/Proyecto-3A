using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using kaninos;
using Kaninos.Controllers;
using kaninos.Entities;
using kaninos.Models;
using kaninos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace KaninosTest
{
    [TestClass]
    public class AgregarTest
    {
        [TestMethod]
        public void Agregar_camposLlenos_deveriaRegresarnosAlIndexYGuardarEnLaDB()
        {
            //arrange
            var dto = new EjemplarDTO{
                    nombre = "Solovino II",
                    id_padre = 1,
                    id_madre = 3,
                    edad = 10,
                    id_raza = 1,
                    id_criador = 1,
                    id_variedad = 1,
                    id_color = 1,
                    descripcion = "Travieso y Mordelon",
                    foto_ejemplar = null,
            };
            //act
            //ApplicationDbContext _dbContext = null;
            //IWebHostEnvironment _hosting = null;
            EjemplaresController controller = new EjemplaresController();
            var result = controller.New() as ViewResult;
            var modelo = result.Model;
            
            //assert
            Assert.IsNotNull(modelo);
        }
    }
}
