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
    public partial class Perfilesweb : System.Web.UI.Page
    {
        private Perfil perfilInfo = new Perfil();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    perfilInfo = PerfilLogica.ObtenerPerfilID(codigo);
                    if (perfilInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = perfilInfo.Id_Perfil.ToString();
                            txtnombreper.Text = perfilInfo.Per_Nombre.ToString();
                            txtdescripcion.Text = perfilInfo.Per_Descripcion.ToString();
                        }
                        catch (Exception)
                        {
                            
                            throw;
                        }
                    }
                }
                this.Form.Attributes.Add("autocomplete", "off");
                cargarPerfiles();
            }
        }

        private void cargarPerfiles()
        {
            grdPerfil.DataSource = PerfilLogica.obtenerPerfil();
            grdPerfil.DataBind();
        }

        protected void lnkroles_Click(object sender, EventArgs e)
        {
            Response.Redirect("Rolesweb.aspx");
        }

        protected void grdPerfil_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Perfilesweb.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Perfil perfilInfo = new Perfil();
                perfilInfo = PerfilLogica.ObtenerPerfilID(codigo);
                if (perfilInfo != null)
                {
                    PerfilLogica.Delete(perfilInfo);
                    cargarPerfiles();
                }
            }
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                perfilInfo = new Perfil();
                if (validarPerfil(txtnombreper.Text))
                {
                    perfilInfo.Per_Nombre = txtnombreper.Text;
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "";
                }
                else
                {
                    lblmensaje.Visible = true;
                    lblmensaje.Text = "Perfil ya existe registrado";
                    throw new ArgumentException("Perfil ya existe registrado </br>");
                }
                perfilInfo.Per_Descripcion = txtdescripcion.Text;
                PerfilLogica.Save(perfilInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Guardados </br>";
                Regresar();
            }
            catch (Exception)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Guardados </br>";
            }
        }

        private void Modificar(Perfil perfilInfo)
        {
            try
            {
                lblmensaje.Text = "";
                //if (validarPerfil(txtnombreper.Text))
                //{
                    perfilInfo.Per_Nombre = txtnombreper.Text;
                    perfilInfo.Per_Descripcion = txtdescripcion.Text;
                //    lblmensaje.Visible = true;
                //    lblmensaje.Text = "";
                //}
                //else
                //{
                //    lblmensaje.Visible = true;
                //    lblmensaje.Text = "Perfil ya existe registrado";
                //    throw new ArgumentException("Perfil ya existe registrado </br>");
                //}
                PerfilLogica.Modify(perfilInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Actualizados </br>";
                Regresar();
            }
            catch (Exception)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Actualizados </br>";
            }
        }
        
        private void GuardarDatos(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                perfilInfo = PerfilLogica.ObtenerPerfilID(id);
                if (perfilInfo != null)
                {
                    Modificar(perfilInfo);
                }
            }
        }
        private void Regresar()
        {
            Response.Redirect("VerUsuarios.aspx", true);
        }


        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerUsuarios.aspx");
        }

        protected void grdPerfil_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdPerfil.PageIndex = e.NewPageIndex;
            cargarPerfiles();
        }

        private bool validarPerfil(string perfiles)
        {
            if (!PerfilLogica.validarPerfil(perfiles))
            {
                return true;
            }
            else if (perfiles != null)
            {
                PerfilLogica.validarPerfil(perfiles);
                lblmensaje.Visible = true;
                lblmensaje.Text = "El nombre de perfil ya existe";
            }
            return false;
        }
    }
}