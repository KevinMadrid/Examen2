using Examen2.DomainService;
using Examen2.Modelos;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestExamen2
{
    [TestClass]
    public class UnitTestCiudadano
    {
        [TestMethod]
        public void PruebaParaValidarQueSeEncuentraUnCiudadano()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudadano = null;
            var ciudadanoCiudad= new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadanoDomainService = new CiudadanoDomainService();
            var resultado = ciudadanoDomainService.GetCiudadanoDomainService(id, ciudadano);

            // Assert
            Assert.AreEqual("El Ciudadano no Existe", resultado);
        }

        [TestMethod]
        public void PruebaParaValidarQueExisteCiudad()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudad = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadanoDomainService = new CiudadanoDomainService();
            var resultado = ciudadanoDomainService.PostCiudadanoDomainService(ciudadanoCiudad);

            // Assert
            Assert.AreEqual("La Ciudad no existe", resultado);

        }
        [TestMethod]
        public void PruebaParaValidarQueSeEncuentraUnCiudadano2()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudadano = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadanoDomainService = new CiudadanoDomainService();
            var resultado = ciudadanoDomainService.PutCiudadanoDomainService(id,ciudadanoCiudad);

            // Assert
            Assert.AreEqual("No existe el Ciudadano", resultado);
        }

        [TestMethod]
        public void Prueba2ParaValidarQueExisteCiudad()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudad = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadanoDomainService = new CiudadanoDomainService();
            var resultado = ciudadanoDomainService.PutCiudadanoDomainService(id, ciudadanoCiudad);

            // Assert
            Assert.AreEqual("La Ciudad no existe", resultado);

        }
        [TestMethod]
        public void PruebaParaValidarQueSeEncuentraUnCiudadano3()
        {
            // Arrange
            var ciudadano = new Ciudadano();
            var ciudad = new Ciudad();
            var id = new int();
            ciudadano = null;
            var ciudadanoCiudad = new CiudadanoCiudad(ciudadano, ciudad);
            // Act
            var ciudadanoDomainService = new CiudadanoDomainService();
            var resultado = ciudadanoDomainService.DeleteCiudadanoDomainService(ciudadano);

            // Assert
            Assert.AreEqual("No se Encuentra el Ciudadano", resultado);

        }

    }
}
