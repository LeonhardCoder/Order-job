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
    public partial class Contactos : System.Web.UI.Page
    {
        private Contacto contactoInfo = new Contacto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    contactoInfo = ContactosLogica.ObtenerContactoID(codigo);
                    if (contactoInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = contactoInfo.Id_Contacto.ToString();
                            txtnombreCli.Text = contactoInfo.Cont_Nombre.ToString();
                            ddlcliente.Text = contactoInfo.Id_ClienteExterno.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        btnguardar.Enabled = true;
                        btnactualizar.Enabled = false;
                    }
                }
                this.Form.Attributes.Add("autocomplete", "off");
                CargarContacto();
                ListarContacto();
            }
        }

        private void CargarContacto()
        {
            List<Contacto> listaContacto = new List<Contacto>();
            listaContacto = ContactosLogica.obtenerContacto();
            if (listaContacto != null)
            {
                grdContacto.DataSource = listaContacto;
                grdContacto.DataBind();
            }
        }

        private void ListarContacto()
        {
            List<ClienteExterno> ListaContacto = new List<ClienteExterno>();
            ListaContacto = ClienteExternoLogica.obtenerLista();
            ListaContacto.Insert(0, new ClienteExterno() { CExt_Nombre = "Seleccione Contacto" });
            ddlcliente.DataSource = ListaContacto;
            ddlcliente.DataTextField = "CExt_Nombre";
            ddlcliente.DataValueField = "Id_ClienteExterno";
            ddlcliente.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                contactoInfo = new Contacto();
                contactoInfo.Cont_Nombre = txtnombreCli.Text;
                contactoInfo.Id_ClienteExterno = Convert.ToInt32(ddlcliente.SelectedValue);
                ContactosLogica.Save(contactoInfo);
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

        private void Regresar()
        {
            Response.Redirect("Contactos.aspx", true);
        }

        private void ModificarContacto(Contacto contactoInfo)
        {
            try
            {
                lblmensaje.Text = "";
                contactoInfo.Cont_Nombre = txtnombreCli.Text;
                contactoInfo.Id_ClienteExterno = Convert.ToInt32(ddlcliente.SelectedValue);
                ContactosLogica.Modify(contactoInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Modificados </br>";
                Regresar();
            }
            catch (Exception)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Modificados </br>";
            }
        }

        private void GuardarDatosContacto(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                contactoInfo = ContactosLogica.ObtenerContactoID(id);
                if (contactoInfo != null)
                {
                    ModificarContacto(contactoInfo);
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosContacto(Convert.ToInt32(Request["cod"]));
        }

        protected void grdContacto_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Contactos.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Contacto listaContacto = new Contacto();
                listaContacto = ContactosLogica.ObtenerContactoID(codigo);
                if (listaContacto != null)
                {
                    ContactosLogica.Delete(listaContacto);
                    CargarContacto();
                }
            }
        }

        protected void grdContacto_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.grdContacto.PageIndex = e.NewSelectedIndex;
            CargarContacto();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosContacto(Convert.ToInt32(Request["cod"]));
        }

        protected void bntregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

    }
}