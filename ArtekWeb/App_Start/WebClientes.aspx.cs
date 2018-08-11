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
    public partial class WebClientes : System.Web.UI.Page
    {
        private Clientes_Operadora clienteInfo = new Clientes_Operadora();
        private ClienteFinal clientefinalInfo = new ClienteFinal();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    clienteInfo = ClienteFinalLogica.ObtenerClienteOperadoraID(codigo);
                    if (clienteInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = clienteInfo.Id_ClienteOperadora.ToString();
                            txtclientes.Text = clienteInfo.ClienteFinal.Cli_Nombre.ToString();
                            ddloperadora.SelectedValue = clienteInfo.Id_Operadora.ToString();
                            ddlcliprincipal.SelectedValue = clienteInfo.Id_ClienteExterno.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                if (Request["codC"] != null)
                {
                    //btnguardar.Enabled = false;
                    //btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["codC"]);
                    clientefinalInfo = ClienteFinalLogica.ObtenerClienteFinalID(codigo);
                    if (clientefinalInfo != null)
                    {
                        try
                        {
                            lblcodcli.Text = clientefinalInfo.Id_ClienteFinal.ToString();
                            txtclientes.Text = clientefinalInfo.Cli_Nombre.ToString();
                            //txtdireccion.Text = clientefinalInfo.Cli_Direccion.ToString();
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

                CargarOperadora();
                CargarCliente();
                listarClientes();
            }
        }

        private void CargarOperadora()
        {
            List<Operadora> ListaOperadora = new List<Operadora>();
            ListaOperadora = OperadoraLogica.obtenerOperadora();
            ListaOperadora.Insert(0, new Operadora() { Ope_Nombre = "Seleccione Operadora" });
            ddloperadora.DataSource = ListaOperadora;
            ddloperadora.DataTextField = "Ope_Nombre";
            ddloperadora.DataValueField = "Id_Operadora";
            ddloperadora.DataBind();
        }

        private void CargarCliente()
        {
            List<ClienteExterno> ListaCliente = new List<ClienteExterno>();
            ListaCliente = ClienteExternoLogica.obtenerLista();
            ListaCliente.Insert(0, new ClienteExterno() { CExt_Nombre = "Seleccione Cliente" });
            ddlcliprincipal.DataSource = ListaCliente;
            ddlcliprincipal.DataTextField = "CExt_Nombre";
            ddlcliprincipal.DataValueField = "Id_ClienteExterno";
            ddlcliprincipal.DataBind();
        }

        private void listarClientes()
        {
            grdClientesFinal.DataSource = ClienteFinalLogica.obtenerClienteFinal();
            grdClientesFinal.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                clienteInfo = new Clientes_Operadora();
                clienteInfo.Id_ClienteFinal = Convert.ToInt32(lblcodcli.Text);
                clienteInfo.Id_Operadora = Convert.ToInt32(ddloperadora.SelectedValue);
                clienteInfo.Id_ClienteExterno = Convert.ToInt32(ddlcliprincipal.SelectedValue);
                ClienteFinalLogica.SaveCO(clienteInfo);
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
                    //ModificarCliente(clientefinalInfo);
                }
            }
        }

        private void Regresar()
        {
            Response.Redirect("VerClientes.aspx");
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosCliente(Convert.ToInt32(Request["cod"]));
        }

        protected void imgbuscar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerClientes.aspx");
        }

        protected void grdClientesFinal_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "seleccionar")
            {
                Response.Redirect("WebClientes.aspx?codC=" + codigo, true);
            }
        }

        protected void grdClientesFinal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdClientesFinal.PageIndex = e.NewPageIndex;
            listarClientes();
        }
    }
}