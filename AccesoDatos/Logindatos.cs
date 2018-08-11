using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class Logindatos
    {
        //Consultas _consul = new Consultas();
        //private SqlConnection conexion = new SqlConnection("Data Source=LAPTOP-PNE5D04H;Initial Catalog=newpruebas;Persist Security Info=True;User ID=sa;Password=.");
        //private DataSet dt;
        //public static DataSet ValidarLogin(string sUsuario, string sPassword)
        //{
        //    SqlParameter[] dbParams = new SqlParameter[]
        //        {
        //            FDBHelper.MakeParam("@Usuario", SqlDbType.VarChar, 0, sUsuario),
        //            FDBHelper.MakeParam("@Password", SqlDbType.VarChar, 0, sPassword),
                   
        //        };
        //    return FDBHelper.ExecuteDataSet("usp_Data_FLogin_ValidarLogin", dbParams);

        //}

        //public static DataSet ValidarLogin(string sUsuario, string sPassword)
        //{
        //    SqlDataAdapter da = new SqlDataAdapter("usp_Data_FLogin_ValidarLogin");
        //    da.SelectCommand.CommandType = CommandType.StoredProcedure;
        //    da.SelectCommand.Parameters.Add("@sUsuario", SqlDbType.VarChar).Value = sUsuario;
        //    da.SelectCommand.Parameters.Add("@sPassword", SqlDbType.VarChar).Value = sPassword;
        //    DataSet dt = new DataSet();
        //    da.Fill(dt);
        //    return dt;
        //}
    }
}
