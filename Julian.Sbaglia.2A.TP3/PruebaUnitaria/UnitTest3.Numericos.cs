using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClasesAbstractas;
using Clases_Instanciables;

namespace PruebaUnitaria
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void TestCantidadDeAlumnos()
        {
            try
            {
                Universidad uni = new Universidad();
                Alumno a1 = new Alumno(10, "Nombre", "Apellido", "12345678",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                Alumno a2 = new Alumno(20, "Nombre", "Apellido", "87654321",
                    Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);
                uni += a1;
                uni += a2;
                Assert.AreEqual(2, uni.Alumnos.Count);
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
