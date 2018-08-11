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
    public partial class VerTecnologia : System.Web.UI.Page
    {
        private Tecnologia tecnologiaInfo = new Tecnologia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                cargarTecnologia();
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Tecnologia.aspx");
        }

        private void cargarTecnologia()
        {
            grdTecnologia.DataSource = TecnologiaLogica.obtenerTecnologia();
            grdTecnologia.DataBind();
        }

        protected void lnknuevo_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tecnologia.aspx");
        }

        protected void grdTecnologia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Tecnologia.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Tecnologia tecnologiaInfo = new Tecnologia();
                tecnologiaInfo = TecnologiaLogica.ObtenerTecnologiaID(codigo);
                if (tecnologiaInfo != null)
                {
                    TecnologiaLogica.Delete(tecnologiaInfo);
                    cargarTecnologia();
                }
            }
        }

        protected void grdTecnologia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdTecnologia.PageIndex = e.NewPageIndex;
            cargarTecnologia();
        }
    }
}