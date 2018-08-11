using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Consultas
    {
        public string conexion1()
        {
            return global::AccesoDatos.Properties.Settings.Default.newpruebasConnectionString;

        }
        private SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-PNE5D04H;Initial Catalog=newpruebas;Persist Security Info=True;User ID=sa;Password=.");
        private DataSet dt;

        public DataTable MostarDatos()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from Tecnologia", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            dt = new DataSet();
            ad.Fill(dt,"tabla");
            conexion.Close();
            return dt.Tables["tabla"];
        }

        public bool InsertarDatos( string Tec_Nombre, string Tec_Descripcion, string Tec_Estado, string Id_TipoCategoria, string Id_Operadora )
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand(string.Format("insert into Operadora values ({0},{1},{2},{3},{4})", new string [] {Tec_Nombre,Tec_Descripcion,Tec_Estado,Id_TipoCategoria,Id_Operadora}), conexion);
            int fila = cmd.ExecuteNonQuery();
            conexion.Close();
            if (fila > 0) return true;
            else return false;
        }

        public DataTable MostarDatosClientes()
        {
            conexion.Open();
            SqlCommand cmd = new SqlCommand("select * from ClienteExterno", conexion);
            SqlDataAdapter ad = new SqlDataAdapter(cmd);
            dt = new DataSet();
            ad.Fill(dt, "tabla");
            conexion.Close();
            return dt.Tables["tabla"];
        }


    }
}
