using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestUniversidadNull()
        {
            try
            {
                Universidad uni = new Universidad();
                Assert.AreNotEqual(null, uni.Alumnos);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
