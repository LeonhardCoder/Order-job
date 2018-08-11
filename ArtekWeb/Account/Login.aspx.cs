using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using LogicaNegocio;
using System.Data.Linq;



namespace ArtekWeb.Account
{
    public partial class Login : System.Web.UI.Page
    {
        private Usuario usuarioInfo = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                this.Form.Attributes.Add("autocomplete","off");
            }
        }
    //private void ingresar()
    //{
    //    UsuarioLogica logicaUsuario = new UsuarioLogica();
      
    //    if (txtusername.Text == "")
    //    {
    //        lblmensaje.Visible = true;
    //        lblmensaje.Text = "INGRESE EL NOMBRE DEL USUARIO";
    //    }
    //    if (txtusername.Text == "")
    //    {
    //        lblmensaje.Visible = true;
    //        lblmensaje.Text = "INGRESE EL PASSWORD";
    //        return;
    //    }
    //    bool existe = logicaUsuario.AutentificarUsuario(txtusername.Text, txtpassword.Text);
    //    if (existe)
    //    {
    //        Usuario usuario = new Usuario();
    //        usuario = UsuarioLogica.ObtenerUsuarioLogin(txtusername.Text, txtpassword.Text);
    //        Session["nombreleogeado"] = usuario.Usu_Nombre + "  " + usuario.Usu_Apellido;
    //        Session["usuariologeado"] = usuario.Id_Usuario;
    //        //Response.Redirect("~/Admin/Menu.aspx");
    //        if (usuario.Id_Perfil == 1)
    //        {
    //            Response.Redirect("~/App_Start/Principal.aspx");
    //        }
    //        //else
    //        //{
    //        //    Session["nombreleogeado"] = usuario.Usu_Login + "  " ;
    //        //    if (usuario.camposcompletos == 1)
    //        //    {
    //        //        Response.Redirect("~/html/catalogo.aspx");
    //        //    }
    //        //    else
    //        //    {
    //        //        Response.Redirect("~/html/Datos.aspx", true);
    //        //    }
    //        //}
    //    }
    //    else
    //    {
    //        lblmensaje.Visible = true;
    //        lblmensaje.Text = " USUARIO NO EXISTE ";
    //        return;
    //    }
    //}

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //ingresar();
        }
    }
}