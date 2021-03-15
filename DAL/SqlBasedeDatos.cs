using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class SqlBasedeDatos
    {
        DataTable Tabla;
        SqlConnection strConexion = new SqlConnection("Data Source=PC-GAMERC ; Initial Catalog=DbUbicaciones; Integrated Security=True");
        SqlCommand cmd = new SqlCommand();

        public bool EjecutarComandoSql(SqlCommand strSQLCommand)
        {

            // Insert, update, delete
            bool Respuesta = true;

            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Respuesta = (cmd.ExecuteNonQuery() <= 0) ? false : true;
            strConexion.Close();
            return Respuesta;
        }
       
        public DataTable EjecutarSentenciaSql(SqlCommand strSQLCommand)
        {
            //Seleccionar datos de bd
            // SELECT
            cmd = strSQLCommand;
            cmd.Connection = strConexion;
            strConexion.Open();
            Tabla = new DataTable();
            Tabla.Load(cmd.ExecuteReader());
            strConexion.Close();
            return Tabla;
        }


    }
}
