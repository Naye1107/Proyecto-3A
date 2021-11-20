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
        
        #region Validacion de Campos Llenos

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

            string nombre_foto = "not-found.png";
            var expected = true;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto,nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Validacion de Campos Vacios

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
        public void formatoNombre_camposvaciosOnulos()
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
            var result = controller.formatoNombre(dto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void madreExist_deveriaComprovarQuelcampodelmadrenoestevacio()
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

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.madreExist(dto);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void padreExist_deveriaComprovarQuelcampodelpadrenoestevacio()
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

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.padreExist(dto);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void criadorExist_deveriaComprovarQueElCriadornoestevacio()
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

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.criadorExist(dto);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void insertToDB_CompruebaQueNOseinserteEnLaBD()
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

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        #endregion

        #region Validacion de Campos Obligatorios

        [TestMethod]
        public void CampoPadre_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = string.Empty,
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoMadre_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = string.Empty,
                edad = 10,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoCriador_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 1,
                criador = string.Empty,
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoNombre_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = string.Empty,
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

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoDescripcion_CompruebaQueNOseinserteEnLaBD()
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
                descripcion = string.Empty,
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoEdad_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 0,
                id_raza = 1,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoIdRaza_CompruebaQueNOseinserteEnLaBD()
        {
            //arrange
            var dto = new EjemplarDTO
            {
                nombre = "Solovino II",
                padre = "copito",
                madre = "copito II",
                edad = 10,
                id_raza = 0,
                criador = "Daniel",
                id_variedad = 1,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoIdVariedad_CompruebaQueNOseinserteEnLaBD()
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
                id_variedad = 0,
                id_color = 1,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CampoIdColor_CompruebaQueNOseinserteEnLaBD()
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
                id_color = 0,
                descripcion = "Tierno y esponjoso",
                foto_ejemplar = null,
            };

            string nombre_foto = "not-found.png";
            var expected = false;

            //act
            EjemplaresController controller = new EjemplaresController(dbContext, HostingEnvironment);
            var result = controller.insertToDB(dto, nombre_foto);

            //assert
            Assert.AreEqual(expected, result);
        }

        #endregion
    }
}
