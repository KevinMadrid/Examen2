using Examen2.DomainService;
using Examen2.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExamen2
{
    [TestClass]
    public class UnitTestCIudad
    {
        [TestMethod]
        public void PruebaParaValidarQueExisteCiudad()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudad = null;
            var ciudadanoCiudad= new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadDomainService = new CiudadDomainService();
            var resultado = ciudadDomainService.GetCiudadDomainService(ciudad);

            // Assert
            Assert.AreEqual("La Ciudad no Existe", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarQueExisteCiudad2()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudad = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadDomainService = new CiudadDomainService();
            var resultado = ciudadDomainService.PutCiudadDomainService(id,ciudad);

            // Assert
            Assert.AreEqual("No existe la Ciudad", resultado);

        }
        [TestMethod]
        public void PruebaParaValidarQueExisteCiudad3()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudad = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadDomainService = new CiudadDomainService();
            var resultado = ciudadDomainService.DeleteCiudadDomainService(ciudad);

            // Assert
            Assert.AreEqual("La Ciudad no Existe", resultado);
        }

    }
}
