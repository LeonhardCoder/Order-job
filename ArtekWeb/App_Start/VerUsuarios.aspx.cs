using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using AccesoDatos;
using LogicaNegocio;

namespace ArtekWeb.App_Start
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        private Usuario UsuarioInfo = new Usuario();
        private List<Usuario> listausuarios = new List<Usuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarUsuario();
            }
        }

        private void CargarUsuario()
        {
            List<Usuario> listaUsuario = new List<Usuario>();
            listaUsuario = UsuarioLogica.obtenerUsuario();
            if (listaUsuario != null)
            {
                grdUsuario.DataSource = listaUsuario;
                grdUsuario.DataBind();
            }
        }

        protected void grdUsuario_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Usuarios.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName == "eliminar")
            {
                Usuario usuario = new Usuario();
                usuario = UsuarioLogica.ObtenerUsuarioID(codigo);
                if (usuario != null)
                {
                    UsuarioLogica.Delete(usuario);
                    CargarUsuario();
                }
            }
        }

        protected void lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Usuarios.aspx");
        }

        protected void grdUsuario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdUsuario.PageIndex = e.NewPageIndex;
            CargarUsuario();
        }
    }
}