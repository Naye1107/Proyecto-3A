using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using kaninos;
using kaninos.Entities;
using kaninos.Models;
using kaninos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using kaninos.Controllers;

namespace KaninosTest
{
    [TestClass]
    public class LoginTest
    {
        static string connectionString = "Data Source=LAPTOP-AP83LF2M;Initial Catalog=kaninos;Persist Security Info=False;User ID=kaninos_user;Password=12345";
        static DbContextOptions<ApplicationDbContext> options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(connectionString).Options;
        ApplicationDbContext dbContext = new ApplicationDbContext(options);

        public Microsoft.AspNetCore.Hosting.IWebHostEnvironment HostingEnvironment { get; }

        [TestMethod]
        public void Emailexist_Compruebaqueellogin_notedejepasarconloscamposvacíos()
        {
            //arrange
            var dto = new LoginDTO
            {
                email = null,
                pass = null,
            };

            //act
            HomeController controller = new HomeController(dbContext);
            var result = controller.Emailexist(dto);

            //assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void formatoEmail_Compruebaqueellogin_notedejepasarconloscamposvacíos()
        {
            //arrange
            var dto = new LoginDTO
            {
                email = null,
                pass = null,
            };
            var expected = false;

            //act
            HomeController controller = new HomeController(dbContext);
            var result = controller.formatoEmail(dto);

            //assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CorrectPass_Compruebaqueellogin_notedejepasarconloscamposvacíos()
        {
            //arrange
            var dto = new LoginDTO
            {
                email = null,
                pass = null,
            };
            var expected = false;

            //act
            HomeController controller = new HomeController(dbContext);
            var result = controller.CorrectPass(dto);

            //assert
            Assert.AreEqual(expected, result);
        }
        [TestMethod]
        public void Compruebaqueellogin_tedejepasarconloscamposllenos()
        {
            //arrange
            var dto = new LoginDTO
            {
                id_log = 1,
                nombre = "Eduardo",
                email = "eduardo@abc.com",
                pass = "D12444",
            };
            Microsoft.AspNetCore.Mvc.ViewResult rt = new ViewResult();

            //act
            HomeController controller = new HomeController(dbContext);
            var result = (ViewResult)controller.Login(dto);
            dto = (LoginDTO)result.Model;

            //assert
            Assert.AreEqual(rt, result);
        }
           
        [TestMethod]
        public void Compruebaqueellogin_tedejepasarconloscamposincorrectos()
        {
            var dto = new LoginDTO
            {
                id_log = 0,
                nombre = "Eduardo",
                email = "eduardo@abc.com",
                pass = "D12444",
            };
            Microsoft.AspNetCore.Mvc.ViewResult rt = new ViewResult();

            //act
            HomeController controller = new HomeController(dbContext);
            var result = (ViewResult)controller.Login(dto);
            dto = (LoginDTO)result.Model;

            //assert
            Assert.AreEqual(-1, result);
                }

             }
         }
