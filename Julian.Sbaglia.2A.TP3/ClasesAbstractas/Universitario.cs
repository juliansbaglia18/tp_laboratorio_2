using System;
using System.Collections.Generic;
using System.Text;

namespace ClasesAbstractas
{
    abstract public class Universitario : Persona
    {
        private int legajo;

        //Metodos


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendFormat("Legajo numero: {0}\n", this.legajo);

            return sb.ToString();
        }

        public Universitario()
            : base()
        {

        }

        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            bool retorno = false;

            if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pg1"></param>
        /// <param name="pg2"></param>
        /// <returns></returns>
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            bool retorno = false;
            if (obj is Universitario)
            {
                retorno = (this == (Universitario)obj);
            }

            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        abstract protected string ParticiparEnClase();
    }
}