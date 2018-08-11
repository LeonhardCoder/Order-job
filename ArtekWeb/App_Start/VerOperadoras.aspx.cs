using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using AccesoDatos;
using LogicaNegocio;
using System.IO;
using System.Data;

namespace ArtekWeb.App_Start
{
    public partial class VerOperadoras : System.Web.UI.Page
    {
        private Operadora operadoraInfo = new Operadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarOperadora();
            }
        }

        private void cargarOperadora()
        {
            grdOperadora.DataSource = OperadoraLogica.obtenerOperadora();
            grdOperadora.DataBind();
        }

        protected void grdOperadora_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Operadora.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Operadora operadoraInfo = new Operadora();
                operadoraInfo = OperadoraLogica.ObtenerOperadoraID(codigo);
                if (operadoraInfo != null)
                {
                    OperadoraLogica.Delete(operadoraInfo);
                    cargarOperadora();
                }
            }
        }

        protected void grdOperadora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdOperadora.PageIndex = e.NewPageIndex;
            cargarOperadora();
        }

        protected void lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Operadora.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Operadora.aspx");
        }

        protected void lnkcontacto_Click(object sender, EventArgs e)
        {
            Response.Redirect("Contactos.aspx");
        }

        protected void imgcontacto_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Contactos.aspx");
        }
    }
}