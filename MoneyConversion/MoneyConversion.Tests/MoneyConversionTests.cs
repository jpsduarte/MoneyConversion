using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyConversion.Api.Controllers;
using System.Threading.Tasks;

namespace MoneyConversion.Tests
{
    [TestClass]
    public class MoneyConversionTests
    {
        [TestMethod]
        public async Task Conversao_Estrangeira_Para_Real()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            OkObjectResult result = (OkObjectResult)await controller.Get("USDARS", "USDBRL", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(200, result.StatusCode);

        }

        [TestMethod]
        public async Task Conversao_Para_Real_Estrangeira()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            OkObjectResult result = (OkObjectResult)await controller.Get("USDBRL", "USDARS", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(200, result.StatusCode);
        }

        [TestMethod]
        public async Task Conversao_Estrangeira_Para_Real_Sem_Valor()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            OkObjectResult result = (OkObjectResult)await controller.Get("USDBRL", "USDARS", 0);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(200, result.StatusCode);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public async Task Conversao_Real_Para_Estrangeira_Sem_Valor()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            OkObjectResult result = (OkObjectResult)await controller.Get("USDBRL", "USDARS", 0);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(200, result.StatusCode);

            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public async Task Conversao_Estrangeira_Para_Real_Sem_Origem()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("", "USDBRL", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("from is missing", result.Value);

        }

        [TestMethod]
        public async Task Conversao_Real_Para_Estrangeira_Sem_Origem()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("", "USDARS", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("from is missing", result.Value);
        }

        [TestMethod]
        public async Task Conversao_Estrangeira_Para_Real_Sem_Destino()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("USDARS", "", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("to is missing", result.Value);

        }

        [TestMethod]
        public async Task Conversao_Real_Para_Estrangeira_Sem_Destino()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("USDBRL", "", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("to is missing", result.Value);
        }

        [TestMethod]
        public async Task Conversao_Com_Origem_Invalida()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("USDLALALA", "USDBRL", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("source currency not found", result.Value);
        }

        [TestMethod]
        public async Task Conversao_Com_Destino_Invalido()
        {
            // Arrange
            var controller = new CurrencyController();

            // Act
            BadRequestObjectResult result = (BadRequestObjectResult)await controller.Get("USDBRL", "USDLALALA", 10);

            // Assert
            Assert.IsNotNull(result);
            Assert.IsNotNull(result.Value);
            Assert.AreEqual(400, result.StatusCode);
            Assert.AreEqual("destination currency not found", result.Value);
        }
    }
}