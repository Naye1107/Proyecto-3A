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
using Microsoft.EntityFrameworkCore;

namespace KaninosTest
{
    [TestClass]
    public class AgregarTest
    {
        static string connectionString = "Data Source=LAPTOP-AP83LF2M;Initial Catalog=kaninos;Persist Security Info=False;User ID=kaninos_user;Password=12345";
        static DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString).Options;
        ApplicationDbContext dbContext = new ApplicationDbContext(options);

        public Microsoft.AspNetCore.Hosting.IWebHostEnvironment HostingEnvironment { get;}
        
        [TestMethod]
        public void Agregar_camposLlenos_deveriaRegresarnosAlIndex()
        {
            //arrange
            var dto = new EjemplarDTO{
                nombre = "S",
                id_padre = 1,
                id_madre = 3,
                edad = 10,
                id_raza = 1,
                id_criador = 1,
                id_variedad = 1,
                id_color = 1,
                descripcion = "T",
                foto_ejemplar = null,
            };

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.New(dto) as ViewResult;
            
            //assert
            var model = result.Model;
            Assert.IsNull(model);
        }
    }
}
