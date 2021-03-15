using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using DLL;

namespace DAL
{
    public class UbicacionesDAL
    {
        SqlBasedeDatos Oconexion;


        //iniciaar conexion con bd(Construtor)

        public UbicacionesDAL() 
        {
            Oconexion = new SqlBasedeDatos();

        }
        public bool Agregar(UbicacionesBLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "INSERT INTO cliente (Ci, Nombre, Ubicacion, Latitud, Longitud) VALUES (@Ci,@Nombre,@Ubicacion, @Latitud,@Longitud)";
            cmdComando.Parameters.Add("@Ci", SqlDbType.VarChar).Value = OubicacionesBLL.CI;
            cmdComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = OubicacionesBLL.nombre;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return Oconexion.EjecutarComandoSql(cmdComando);
        }
        public bool Eliminar(UbicacionesBLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "DELETE FROM cliente WHERE Ci=@Ci";
            cmdComando.Parameters.Add("@Ci", SqlDbType.Int).Value = OubicacionesBLL.CI;
            return Oconexion.EjecutarComandoSql(cmdComando);

        }
        public bool Modificar(UbicacionesBLL OubicacionesBLL) 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "UPDATE cliente SET Nombre=@Nombre,Ubicacion=@Ubicacion,Latitud=@Latitud,Longitud=@Longitud WHERE Ci=@Ci";
            cmdComando.Parameters.Add("@Ci", SqlDbType.Int).Value = OubicacionesBLL.CI;
            cmdComando.Parameters.Add("@Nombre", SqlDbType.VarChar).Value = OubicacionesBLL.nombre;
            cmdComando.Parameters.Add("@Ubicacion", SqlDbType.VarChar).Value = OubicacionesBLL.Ubicacion;
            cmdComando.Parameters.Add("@Latitud", SqlDbType.VarChar).Value = OubicacionesBLL.Latitud;
            cmdComando.Parameters.Add("@Longitud", SqlDbType.VarChar).Value = OubicacionesBLL.Longitud;

            return Oconexion.EjecutarComandoSql(cmdComando);
        }

    
        //Seleccionar Registros
        public DataTable Listar() 
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "SELECT * FROM cliente ";
            cmdComando.CommandType = CommandType.Text; // tipo de comado (Texto,SP)

            DataTable TablaResultante = Oconexion.EjecutarSentenciaSql(cmdComando);
            return TablaResultante;
        }


        //Metodo para buscar por nombre

      /*  public bool BuscarNombre(UbicacionesBLL OubicacionesBLL)
        {
            SqlCommand cmdComando = new SqlCommand();
            cmdComando.CommandText = "select cliente SET Nombre=@nombre where Nombre Like '%'+@nombre+'%'";
            // cmdComando.CommandText = "select * cliente where Nombre Like '%'+@nombre+'%'";
            //cmdComando.CommandText = "select cliente SET Ci=@Ci,Nombre=@nombre,Ubicacion=@Ubicacion,Latitud=@Latitud,Longitud=@Longitud where Nombre Like '%'+@nombre+'%'";
            // cmdComando.CommandType = CommandType.StoredProcedure;
            cmdComando.CommandType = CommandType.Text; // tipo de comado (Texto,SP)
                                                       //cmdComando.CommandText = "SpBuscarNom";

            cmdComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = OubicacionesBLL.nombre;


            return Oconexion.EjecutarComandoSql(cmdComando);

        }*/

    }
}
