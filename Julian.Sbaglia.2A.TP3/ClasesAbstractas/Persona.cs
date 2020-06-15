using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Excepciones;


namespace ClasesAbstractas
{
    abstract public class Persona
    {
        /// <summary>
        /// 
        /// </summary>
        public enum ENacionalidad
        {
            Argentino,
            Extranjero
        }
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;

        /// <summary>
        /// 
        /// </summary>
        public string Nombre
        {
            get { return this.nombre; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    nombre = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Apellido
        {
            get { return this.apellido; }

            set
            {
                if (ValidarNombreApellido(value) != null)
                {
                    this.apellido = value;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int DNI
        {
            get { return this.dni; }

            set
            {
                try
                {
                    dni = ValidarDni(nacionalidad, value);
                }
                catch (DniInvalidoException e)
                {
                    throw e;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get { return this.nacionalidad; }

            set
            {
                try
                {
                    ValidarDni(value, DNI);
                    nacionalidad = value;
                }
                catch (DniInvalidoException)
                {
                    throw new NacionalidadInvalidaException("Nacionalidad no coincidente con numero de DNI.");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string StringToDNI
        {
            set { this.dni = ValidarDni(nacionalidad, value); }
        }

        //constructores
        public Persona()
        {

        }
        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }
        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            ValidarDni(nacionalidad, dni);
            this.DNI = dni;
        }
        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            this.StringToDNI = dni;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("Nombre Completo: {0}, {1}\n", this.Apellido, this.Nacionalidad);
            sb.AppendFormat("Nacionalidad: {0}\n", this.Nacionalidad);

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            int retorno = dato;

            switch (nacionalidad)
            {
                case ENacionalidad.Argentino:
                    if (dato >= 1 && dato <= 89999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new DniInvalidoException("Numero de DNI " + dato.ToString() + " invalido");
                    }
                    break;

                case ENacionalidad.Extranjero:
                    if (dato >= 90000000 && dato <= 99999999)
                    {
                        retorno = dato;
                    }
                    else
                    {
                        throw new DniInvalidoException("Numero de DNI " + dato.ToString() + " invalido");
                    }
                    break;

                default:
                    throw new NacionalidadInvalidaException();
                    break;
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nacionalidad"></param>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            try
            {
                return ValidarDni(nacionalidad, int.Parse(dato));
            }
            catch (FormatException)
            {
                throw new DniInvalidoException("DNI con caracteres no correspondientes.");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dato"></param>
        /// <returns></returns>
        private static string ValidarNombreApellido(string dato)
        {
            string retorno = null;

            if (!string.IsNullOrWhiteSpace(dato))
            {
                Regex rx = new Regex(@"[^A-Za-z\s]");

                if (!rx.IsMatch(dato))
                {
                    retorno = dato;
                }
            }

            return retorno;
        }
    }
}