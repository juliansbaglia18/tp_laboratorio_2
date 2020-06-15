using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Excepciones;

namespace Archivos
{
    public class Xml<T> : IArchivo<T> where T : class
    {
        /// <summary>
        /// Guarda datos tipo T en un archivo .xml.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Datos a guardar.</param>
        /// <returns>Devuelve true si la ruta del archivo es correcta</returns>
        public bool Guardar(string archivo, T datos)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                StreamWriter writer = new StreamWriter(archivo);

                xmlSerializer.Serialize(writer, datos);
                writer.Close();

                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }

        /// <summary>
        /// Lee los datos tipo T del .xml y los guarda.
        /// </summary>
        /// <param name="archivo">Ruta del archivo.</param>
        /// <param name="datos">Donde se guarda el .xml</param>
        /// <returns></returns>
        public bool Leer(string archivo, out T datos)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
                TextReader reader = new StreamReader(archivo);

                datos = (T)xmlSerializer.Deserialize(reader);
                reader.Close();

                return true;
            }
            catch(Exception e)
            {
                throw new ArchivosException(e);
            }
        }
    }
}
