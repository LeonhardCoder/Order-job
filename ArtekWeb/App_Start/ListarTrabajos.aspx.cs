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
    public partial class ListarTrabajos : System.Web.UI.Page
    {
        private List<sucursal_clientes> clientefinalInfo = new List<sucursal_clientes>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                if (Request["codv"] != null)
                {
                    int codigo = Convert.ToInt32(Request["codv"]);
                    clientefinalInfo = ClienteFinalLogica.ObtenerClientesCiudadID(codigo);
                    if (clientefinalInfo != null)
                    {
                        listarClientes(codigo);
                    }
                }
                
            }
        }

        private void listarClientes(int codigosucursal)
        {
            grdVerSucursal.DataSource = ClienteFinalLogica.ObtenerClientesCiudadID(codigosucursal);
            grdVerSucursal.DataBind();
        }

        protected void grdVerSucursal_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdVerSucursal.PageIndex = e.NewPageIndex;
            //listarClientes();
        }

        protected void grdVerSucursal_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void lnknuevoC_Click(object sender, EventArgs e)
        {

        }

        protected void ImageButton1_Click1(object sender, ImageClickEventArgs e)
        {

        }
    }
}