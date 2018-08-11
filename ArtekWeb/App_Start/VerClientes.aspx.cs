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
    public partial class VerClientes : System.Web.UI.Page
    {
        private ClienteFinal clientesInfo = new ClienteFinal();
        ClienteFinalLogica logicaClientes = new ClienteFinalLogica();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarclientes();   
           }
        }

        private void cargarclientes()
        {
            grdVerClientes.DataSource = ClienteFinalLogica.obtenerClienteOperadora();
            grdVerClientes.DataBind();
        }

        protected void grdVerClientes_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "seleccion")
            {
                Response.Redirect("WebClientes.aspx?cod=" + codigo, true);
            }
            else if (e.CommandName == "ver")
            {
                Response.Redirect("ListarTrabajos.aspx?codv=" + codigo, true);
            }
        }

        protected void grdVerClientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdVerClientes.PageIndex = e.NewPageIndex;
            cargarclientes();
        }

        protected void lnknuevoC_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebClientes.aspx");
        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClientesFinal.aspx");
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ClienteExterno.aspx");
        }

        protected void lnknuevoO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ClienteExterno.aspx");
        }
    }
}