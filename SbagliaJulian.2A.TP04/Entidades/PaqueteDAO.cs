﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Entidades
{
    public static class PaqueteDAO
    {
        private static SqlCommand comando;
        private static SqlConnection conexion;

        static PaqueteDAO()
        {
            PaqueteDAO.comando = new SqlCommand();
            PaqueteDAO.conexion = new SqlConnection(Properties.Settings.Default.Conexion);
            PaqueteDAO.comando.CommandType = CommandType.Text;
            PaqueteDAO.comando.Connection = PaqueteDAO.conexion;
        }
        public static bool Insertar(Paquete p)
        {
            string comando = string.Format("INSERT INTO Paquetes (direccionEntrega,trackingID,alumno)" +
                " VALUES ('{0}','{1}','Sbaglia Julian')", p.DireccionEntrega, p.TrakingID);
            PaqueteDAO.comando.CommandText = comando;
            PaqueteDAO.conexion.Open();
            PaqueteDAO.comando.ExecuteNonQuery();
            PaqueteDAO.conexion.Close();
            return true;
        }
    }
}
