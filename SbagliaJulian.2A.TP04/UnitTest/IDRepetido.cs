using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;

namespace UnitTest
{
    [TestClass]
    public class IDRepetido
    {
        [TestMethod]
        [ExpectedException(typeof(TrackingRepetidoException))]
        public void TestMethod1()
        {
            Paquete p1 = new Paquete("adress", "111");
            Paquete p2 = new Paquete("direccion", "111");
            Correo c1 = new Correo();
            c1 += p1;
            c1 += p2;
            Assert.Fail();
        }
    }
}
