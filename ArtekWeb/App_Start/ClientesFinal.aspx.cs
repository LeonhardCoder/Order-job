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
    public partial class ClientesFinal : System.Web.UI.Page
    {
        private ClienteFinal clientefinalInfo = new ClienteFinal();
        private List<ClienteFinal> listaclientefinal = new List<ClienteFinal>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    clientefinalInfo = ClienteFinalLogica.ObtenerClienteFinalID(codigo);
                    if (clientefinalInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = clientefinalInfo.Id_ClienteFinal.ToString();
                            txtnombreCli.Text = clientefinalInfo.Cli_Nombre.ToString();
                            txtdireccion.Text = clientefinalInfo.Cli_Direccion.ToString();
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
                CargarClienteFinal();
            }
        }
        private void CargarClienteFinal()
        {
            List<ClienteFinal> listaClienteFinal = new List<ClienteFinal>();
            listaClienteFinal = ClienteFinalLogica.obtenerClienteFinal();
            if (listaClienteFinal != null)
            {
                grdClientesFinal.DataSource = listaClienteFinal;
                grdClientesFinal.DataBind();
            }
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                clientefinalInfo = new ClienteFinal();
                if (validarClienteFinal(txtnombreCli.Text))
                {
                    clientefinalInfo.Cli_Nombre = txtnombreCli.Text;
                }
                else
                {
                    lblmen.Text = "Este cliente ya existe.";
                }
                clientefinalInfo.Cli_Direccion = txtdireccion.Text;
                ClienteFinalLogica.Save(clientefinalInfo);
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

        private void Regresar()
        {
            Response.Redirect("ClientesFinal.aspx", true);
        }

        private void ModificarCliente(ClienteFinal clientefinalInfo)
        {
            try
            {
                lblmensaje.Text = "";
                clientefinalInfo.Cli_Nombre = txtnombreCli.Text;
                clientefinalInfo.Cli_Direccion = txtdireccion.Text;
                ClienteFinalLogica.Modify(clientefinalInfo);
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
                clientefinalInfo = ClienteFinalLogica.ObtenerClienteFinalID(id);
                if (clientefinalInfo != null)
                {
                    ModificarCliente(clientefinalInfo);
                }
            }
        }


        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void grdClientesFinal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("ClientesFinal.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                ClienteFinal listacliente = new ClienteFinal();
                listacliente = ClienteFinalLogica.ObtenerClienteFinalID(codigo);
                if (listacliente != null)
                {
                    ClienteFinalLogica.Delete(listacliente);
                    CargarClienteFinal();
                }
            }
        }

        protected void grdClientesFinal_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.grdClientesFinal.PageIndex = e.NewSelectedIndex;
            CargarClienteFinal();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void bntregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        private bool validarClienteFinal(string clientefinalInfo)
        {

            if (!ClienteFinalLogica.validarClientF(clientefinalInfo))
            {
                return true;
            }
            else if (clientefinalInfo != null)
            {
                ClienteFinalLogica.validarClientF(clientefinalInfo);
                lblmen.Visible = true;
                lblmen.Text = "Nombre del cliente ya Existe";
            }

            return false;
        }
    }
}