using System;
using System.Collections.Generic;
using System.Text;
using ClasesAbstractas;

namespace Clases_Instanciables
{
    public sealed class Profesor : Universitario
    {
        private Queue <Universidad.EClases> clasesDelDia;
        private static Random random;

        static Profesor()
        {
            Profesor.random = new Random();
        }

        public Profesor()
            : base()
        {

        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base (id, nombre, apellido, dni, nacionalidad)
        {
            this.clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.MostrarDatos();
        }

        /// <summary>
        /// 
        /// </summary>
        private void _randomClases()
        {
            while (this.clasesDelDia.Count < 2)
            {
                switch(Profesor.random.Next(1, 4))
                {
                    case 1:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Laboratorio);
                        break;

                    case 2:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Legislacion);
                        break;

                    case 3:
                        this.clasesDelDia.Enqueue(Universidad.EClases.Programacion);
                        break;

                    case 4:
                        this.clasesDelDia.Enqueue(Universidad.EClases.SPD);
                        break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("{0}", base.MostrarDatos());
            sb.AppendLine(this.ParticiparEnClase());

            return sb.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override string ParticiparEnClase()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("CLASES DEL DIA: ");
            foreach(Universidad.EClases itemClase in this.clasesDelDia)
            {
                sb.AppendLine(itemClase.ToString());
            }

            return sb.ToString();
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator ==(Profesor i, Universidad.EClases clase)
        {
            bool retorno = false;

            foreach(Universidad.EClases item in i.clasesDelDia)
            {
                if (item == clase)
                {
                    retorno = true;
                }
            }
            return retorno;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i"></param>
        /// <param name="clase"></param>
        /// <returns></returns>
        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        public override bool Equals(object obj)
        {
            bool retorno = false;

            if(obj is Profesor)
            {
                retorno = true;
            }

            return retorno;
        }
    }
}
