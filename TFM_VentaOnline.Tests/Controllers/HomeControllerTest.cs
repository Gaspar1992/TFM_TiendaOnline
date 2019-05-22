using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TFM_VentaOnline;
using TFM_VentaOnline.Controllers;

namespace TFM_VentaOnline.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Disponer
            HomeController controller = new HomeController();

            // Actuar
            ViewResult result = controller.Index() as ViewResult;

            // Declarar
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
