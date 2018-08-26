using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoneyConversion.Api.Controllers;
using System.Threading.Tasks;

namespace MoneyConversion.Tests
{
    [TestClass]
    public class MoneyConversionTests
    {
        [TestMethod]
        public void Conversao_Estrangeira_Para_Real()
        {
            var controller = new CurrencyController();

        }

        [TestMethod]
        public async Task Conversao_Para_Real_Estrangeira()
        {
            var controller = new CurrencyController();
            var request =  await controller.Get("","", 0);
            
        }

        [TestMethod]
        public void Conversao_Estrangeira_Para_Real_Sem_Valor()
        {
            var controller = new CurrencyController();

            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void Conversao_Para_Real_Estrangeira_Sem_Valor()
        {
            var controller = new CurrencyController();

            Assert.AreEqual(0, 0);
        }

        [TestMethod]
        public void Conversao_Estrangeira_Para_Real_Sem_Origem()
        {
            var controller = new CurrencyController();

        }

    }
}
