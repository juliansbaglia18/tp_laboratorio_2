using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {

        /// <summary>
        /// Escribe datos en un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="dato">Dato a ingresar.</param>
        /// <returns></returns>
        public bool Guardar(string archivo, string dato)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(archivo))
                {
                    writer.WriteLine(dato);
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Devuelve los datos de un archivo de texto.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Donde se guarda el texto.</param>
        /// <returns></returns>
        public bool Leer(string archivo, out string datos)
        {
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    datos = "";
                    datos = reader.ReadToEnd();
                    return true;
                }
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
