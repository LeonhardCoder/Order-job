using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccesoDatos;
using LogicaNegocio;
using System.Data.Linq;

namespace ArtekWeb.App_Start
{
    public partial class Username : System.Web.UI.Page
    {
        private Usuario usuarioInfo = new Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usuarioInfo = UsuarioLogica.ObtenerUsuarioID(codigo);
                    if (usuarioInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = usuarioInfo.Id_Usuario.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                this.Form.Attributes.Add("autocomplete", "off");
            }
        }

        private void ActualizarClave(Usuario usuarioInfo)
        {
            try
            {
                lblmensaje.Text = "";
                usuarioInfo.Usu_Cedula = txtuser.Text;
                usuarioInfo.Usu_Apellido = txtuser.Text;
                UsuarioLogica.actualizarClave(usuarioInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Modificados </br>";
                Regresar();
            }
            catch (Exception ex)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Modificados </br> " + ex.Message;
            }
        }


        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        private void GuardarDatos(int id)
        {
            if (id != 0)
            {
                usuarioInfo = UsuarioLogica.ObtenerUsuarioID(id);
                if (usuarioInfo != null)
                {
                    ActualizarClave(usuarioInfo);
                }
            }
        }

        private void Regresar()
        {
            Response.Redirect("VerUsuarios.aspx", true);
        }
    }
}