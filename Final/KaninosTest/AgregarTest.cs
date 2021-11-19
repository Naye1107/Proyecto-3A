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
        
        #region validacion de datos llenos

        [TestMethod]
        public void formatoDescripcion_deveriaComprovarQueLaDescripcionCumplaConElFormatoyDevolverUnBool()
        {
            //arrange
            var dto = new EjemplarDTO{
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };
            var expected = true;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.formatoDescripcion(dto);
            
            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void formatoNombre_deveriaComprovarQueElNombreCumplaConElFormatoyDevolverUnBool()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };
            var expected = true;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.formatoNombre(dto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void criadorExist_deveriaComprovarQueElCriadorExistayDevolverUnObjetoDeTipoCriador()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.criadorExist(dto);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void madreExist_deveriaComprovarQueLaMadreExistayDevolverUnObjetoDeTipoEjemplar()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.madreExist(dto);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void padreExist_deveriaComprovarQueElPadreExistayDevolverUnObjetoDeTipoEjemplar()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.padreExist(dto);

            //assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void insertToDB_deveriaComprovarQueSeInserteEnLaBDyDevolverUnBool()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            var padre = new Ejemplar
            {
                id_ejemplar = 1
            };

            var madre = new Ejemplar
            {
                id_ejemplar = 3
            };

            var criador = new Criador
            {
                id_criador = 1
            };

            string nombre_foto = "not-found.png";
            var expected = true;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto,padre,madre,criador,nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void formatoDescripcion_camposvaciosOnulos()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = string.Empty,
                padre = string.Empty,
                madre = string.Empty,
                edad = 0,
                id_raza = 0,
                criador = string.Empty,
                id_variedad = 0,
                id_color = 0,
                descripcion = string.Empty,
                foto_ejemplar = null,
            };
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.formatoDescripcion(dto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void formatoDescripcion_camposmediollenos()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Raul",
                madre = "Yessica",
                edad = 2,
                id_raza = 6,
                criador = string.Empty,
                id_variedad = 0,
                id_color = 0,
                descripcion = string.Empty,
                foto_ejemplar = null,
            };
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.formatoDescripcion(dto);

            //assert
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
