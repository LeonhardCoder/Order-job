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
    /* modificamos el nombre de la clase de ClienteExterno a WebclienteExterno 
     confictos en el nombre de las clases.
     * TODO: se sugiere utilizar prefijos de las para las clases.
     */
    public partial class WebclienteExterno : System.Web.UI.Page   
    {
     //private ClienteExterno listacliente = new ClienteExterno();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    ClienteExterno listacliente = new ClienteExterno();
                    listacliente = ClienteExternoLogica.ObtenerClienteExternolID(codigo);
                    if (listacliente != null)
                    {
                        try
                        {
                            lblcodigo.Text = listacliente.Id_ClienteExterno.ToString();
                            txtnombreCli.Text = listacliente.CExt_Nombre.ToString();
                            txtdireccion.Text = listacliente.CExt_Direccion.ToString();
                            txttelefono.Text = listacliente.CExt_Telefono.ToString();
                            txtfechacreacion.Text = listacliente.CExt_FechaCreacion.ToString();
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
                cargarClientes();
            }
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                ClienteExterno listacliente = new ClienteExterno();
                if (txtnombreCli.Text != "")
                {
                    lblmen.Visible = true;
                    lblmen.Text= "Ingrese nuevo cliente.";
                }

                    if (validarCliente(txtnombreCli.Text))
                    {
                        listacliente.CExt_Nombre = txtnombreCli.Text;
                    }
                    else
                    {
                        lblmen.Text = "Este cliente ya existe.";
                    }
                
                listacliente.CExt_Direccion = txtdireccion.Text;
                ClienteExternoLogica.Save(listacliente);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Modificados </br>";
                Regresar();
            }
            catch (Exception)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Guardados </br>";
            }
        }

        private void ModificarCliente(ClienteExterno listacliente)
        {
            try
            {
                lblmensaje.Text = "";
                listacliente.CExt_Nombre = txtnombreCli.Text;
                listacliente.CExt_Direccion = txtdireccion.Text;
                listacliente.CExt_Telefono = txttelefono.Text;
                listacliente.CExt_FechaCreacion = Convert.ToDateTime(txtfechacreacion.Text);
                ClienteExternoLogica.Modify(listacliente);
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

        private void GuardarDatosCliente(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                 ClienteExterno listacliente = new ClienteExterno();
                 listacliente = ClienteExternoLogica.ObtenerClienteExternolID(id);
                if (listacliente != null)
                {
                    ModificarCliente(listacliente);
                }
            }
        }

        private void Regresar()
        {
            Response.Redirect("ClienteExterno.aspx", true);
        }

        private void cargarClientes()
        {
            grdClienteExterno.DataSource = ClienteExternoLogica.obtenerLista();
            grdClienteExterno.DataBind();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void grdClienteExterno_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("ClienteExterno.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                ClienteExterno listacliente = new ClienteExterno();
                listacliente = ClienteExternoLogica.ObtenerClienteExternolID(codigo);
                if (listacliente != null)
                {
                    ClienteExternoLogica.Delete(listacliente);
                    cargarClientes();
                }
            }
        }

        protected void grdClienteExterno_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdClienteExterno.PageIndex = e.NewPageIndex;
            cargarClientes();

        }

        protected void lnkcliente_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contactos.aspx");
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        private bool validarCliente(string listacliente)
        {

            if (!ClienteExternoLogica.validarCliente(listacliente))
            {
                return true;
            }
            else if (listacliente != null)
            {
                ClienteExternoLogica.validarCliente(listacliente);
                lblmen.Visible = true;
                lblmen.Text = "Nombre del cliente ya Existe";
            }

            return false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Contactos.aspx");
        }
    }
}