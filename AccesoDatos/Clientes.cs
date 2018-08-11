using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Clientes
    {
        Seguridad _segur = new Seguridad();
        dbArtekWebDataContext dc = new dbArtekWebDataContext();

        public DataTable sp_clientes_oper()
        {
            SqlDataAdapter da = new SqlDataAdapter("sp_clientes_oper", _segur.conexion());
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
