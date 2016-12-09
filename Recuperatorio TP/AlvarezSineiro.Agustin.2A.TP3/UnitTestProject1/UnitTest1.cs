using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntidadesAbstractas;
using EntidadesInstanciables;
using Excepciones;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// Prueba de repeticion de alumnos
        /// </summary>
        [TestMethod]
        public void pruebaAlumnoRepetido()
        {
            Gimnasio gimnasio = new Gimnasio();
            Alumno Alumno1 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
            Alumno Alumno2 = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);

            gimnasio += Alumno1;
            try
            {
                gimnasio += Alumno2;
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(AlumnoRepetidoException));
            }
        }

        /// <summary>
        /// Prueba si alumno es null
        /// </summary>
        [TestMethod]
        public void puebaNullAlumno()
        {
            Alumno alumno = new Alumno(5, "Carlos", "Gonzalez", "12236456",EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,Alumno.EEstadoCuenta.AlDia);
            Assert.IsNotNull(alumno.Apellido);
            Assert.IsNotNull(alumno.Nombre);
            Assert.IsNotNull(alumno.Nacionalidad);
            Assert.IsNotNull(alumno.DNI);
        }

        /// <summary>
        /// Prueba si instructor es null
        /// </summary>
        [TestMethod]
        public void puebaNullInstructor()
        {          
            Instructor instructor = new Instructor(2, "Roberto", "Juarez", "32234456", EntidadesAbstractas.Persona.ENacionalidad.Argentino);
            Assert.IsNotNull(instructor.Apellido);
            Assert.IsNotNull(instructor.Nombre);
            Assert.IsNotNull(instructor.Nacionalidad);
            Assert.IsNotNull(instructor.DNI);
        }

        /// <summary>
        /// Prueba si gimnasio es null
        /// </summary>
        [TestMethod]
        public void puebaNullGimnasio()
        {
            Gimnasio gimnasio = new Gimnasio();
            Assert.IsNotNull(gimnasio);
        }

        /// <summary>
        /// Prueba si la nacionalidad es correcta
        /// </summary>
        [TestMethod]
        public void pruebaNacionalidad()
        {
            try
            {
                Alumno alumno = new Alumno(5, "Carlos", "Gonzalez", "80000000", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit,
           Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }

            try
            {
                Alumno alumno = new Alumno(5, "Carlos", "Gonzalez", "99009000", EntidadesAbstractas.Persona.ENacionalidad.Extranjero, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(NacionalidadInvalidaException));
            }
        }
       
        /// <summary>
        /// Prueba el dni 
        /// </summary>
        [TestMethod]
        public void pruebaDni()
        {
            Alumno alumno = new Alumno(5, "Carlos", "Gonzalez", "12236456", EntidadesAbstractas.Persona.ENacionalidad.Argentino, Gimnasio.EClases.CrossFit, Alumno.EEstadoCuenta.AlDia);
            Assert.AreEqual(alumno.DNI, 12236456);
        }

    }
}
