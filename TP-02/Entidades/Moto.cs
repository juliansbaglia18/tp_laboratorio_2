﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Moto : Vehiculo
    {
        public Moto(EMarca marca, string chasis, ConsoleColor color) 
            : base(chasis, marca, color)
        {
        }

        /// <summary>
        /// Las motos son chicas
        /// </summary>
        protected override ETamanio Tamanio
        {
            get 
            { 
                return ETamanio.Chico;
            }
        }

        /// <summary>
        /// Muestra los datos de Moto
        /// </summary>
        /// <returns>String con el contenido</returns>
        public override sealed string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("MOTO");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine("TAMAÑO : " + this.Tamanio.ToString());
            sb.AppendLine("---------------------");

            return sb.ToString();
        }
    }
}
