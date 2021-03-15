using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using DLL;

using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace CrudUbicaciones
{
    public partial class frmUbicaciones : System.Web.UI.Page
    {
        UbicacionesBLL oUbicacionesBLL;
        UbicacionesDAL oUbicacionesDAL;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ListarUbicaciones();
            }
         
        }

        // metodo que listara los datos en DG
        public void ListarUbicaciones()
        {
            oUbicacionesDAL = new UbicacionesDAL();
            gvUbicaciones.DataSource = oUbicacionesDAL.Listar();
            gvUbicaciones.DataBind();

        }
        public UbicacionesBLL datosUbicacion()
        {

            int ID = 0;
            int.TryParse(txtID.Value, out ID);
            oUbicacionesBLL = new UbicacionesBLL();

            //recolectar datos de pl

            oUbicacionesBLL.ID = ID;
            oUbicacionesBLL.CI = int.Parse(txtCi.Text);
            oUbicacionesBLL.nombre = txtNombre.Text;
            oUbicacionesBLL.Ubicacion = txtUbicacion.Text;
            oUbicacionesBLL.Latitud = txtLat.Text;
            oUbicacionesBLL.Longitud = txtLong.Text;

            return oUbicacionesBLL;

        }

        protected void AgregarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL ();
            oUbicacionesDAL.Agregar(datosUbicacion());
            ListarUbicaciones();

        }

        protected void SeleccionRegistro(object sender, GridViewCommandEventArgs e)
        {
            int FilaSeleccionada = int.Parse(e.CommandArgument.ToString());
            txtCi.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[1].Text;
            txtNombre.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[2].Text;
            txtUbicacion.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[3].Text;
            txtLat.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[4].Text;
            txtLong.Text = gvUbicaciones.Rows[FilaSeleccionada].Cells[5].Text;

            btnEliminar.Enabled = true;
            btnModificar.Enabled = true;
            btnAgregar.Enabled = false;
        }

        protected void EliminarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Eliminar(datosUbicacion());
            ListarUbicaciones();
        }

        protected void ModificarRegistro(object sender, EventArgs e)
        {
            oUbicacionesDAL = new UbicacionesDAL();
            oUbicacionesDAL.Modificar(datosUbicacion());
            ListarUbicaciones();
        }

        public void LimpiarCampos()
        {
            txtID.Value = null;
            txtCi.Text = "";
            txtNombre.Text = "";
            txtUbicacion.Text ="";
            txtLat.Text = "-17.783851";
            txtLong.Text = "-63.182580";

            btnEliminar.Enabled = false;
            btnEliminar.Enabled = false;
            btnAgregar.Enabled = true;

        }

        protected void Limpiar(object sender, EventArgs e)
        {
            LimpiarCampos();
        }




    /*    public void BuscarN()
        {

            using (SqlConnection MyConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString))

            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SpBuscarNom";
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar).Value = txtBuscar.Text.Trim();
                cmd.Connection = MyConnection;
                MyConnection.Open();
                gvUbicaciones.DataSource = cmd.ExecuteReader();
                gvUbicaciones.DataBind();
            }
        }
    */

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            sqlconn.Open();
            SqlCommand cmdcomando = new SqlCommand();
            string sqlquery = "select * from cliente where Nombre like '%'+@Nombre+'%'";
            cmdcomando.CommandText = sqlquery;
            cmdcomando.Connection = sqlconn;
            cmdcomando.Parameters.AddWithValue("Nombre", txtBuscar.Text);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmdcomando);
            sda.Fill(dt);
            gvUbicaciones.DataSource = dt;
            gvUbicaciones.DataBind();
            

        //    BuscarN();
        }
    }
}