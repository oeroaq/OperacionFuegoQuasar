using Microsoft.VisualStudio.TestTools.UnitTesting;
using OperacionFuegoQuasar.Controllers;
using OperacionFuegoQuasar.Model;
using OperacionFuegoQuasar.Repositories;
using OperacionFuegoQuasar.Repositories.Implementations;
using OperacionFuegoQuasar.Services;
using OperacionFuegoQuasar.Services.Implementations;
using OperacionFuegoQuasar.Transversal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OperacionFuegoQuasar.Controllers.Tests
{
    [TestClass()]
    public class TopSecretControllerTests
    {
        private ISatelliteRepository repository;
        private ISatelliteService service;
        private Context context;
        private TopSecretController controller;

        [TestInitialize]
        public void SetUp()
        {
            context = new Context();
            repository = new SatelliteRepository(context);
            service = new SatelliteService(repository);
            controller = new TopSecretController(service);
        }

        [TestMethod("topsecret fail")]
        public void PostTestFail()
        {
            try
            {
                var result = Task.Run(async () => await controller.Post(Data.input)).Result;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message == "Información no correcta");
            }
            

        }
        [TestMethod("topsecret")]
        public void PostTest()
        {
            var result = Task.Run(async () => await controller.Post(Data.input)).Result;

        }

        [TestMethod("topsecret_split/{satellite_name} con un solo elemento")]
        public void PostTest1()
        {
            try
            {
                var respult = Task.Run(async () => await controller.Post(Data.input)).Result;
            }
            catch (Exception ex)
            {
                Assert.Equals(ex.Message, "No hay suficiente información");
            }
        }

        [TestMethod("topsecret_split/{satellite_name}")]
        public void PostTest2()
        {
            Assert.Fail();
        }

        [TestMethod("topsecret_split")]
        public void GetTest()
        {
            Assert.Fail();
        }
    }
}