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
    public partial class ProvinciasWeb : System.Web.UI.Page
    {
        private Provincia provinciaInfo = new Provincia();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    int codigo = Convert.ToInt32(Request["cod"]);
                    provinciaInfo = ProvinciasLogica.ObtenerProvinciaID(codigo);
                    if (provinciaInfo != null)
                    {
                        try
                        {
                            lblcodigop.Text = provinciaInfo.Id_Provincia.ToString();
                            txtprovincia.Text = provinciaInfo.Prov_Nombre.ToString();
                            lblpais.Text = provinciaInfo.Id_Pais.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }
                this.Form.Attributes.Add("autocomplete", "off");
                cargarProvincias();
            }
        }

        private void cargarProvincias()
        {
            grdprovincia.DataSource = ProvinciasLogica.obtenerProvincia();
            grdprovincia.DataBind();
        }

        private void GuardarPronvincia()
        {
            try
            {
                lblmensaje.Text = "";
                provinciaInfo = new Provincia();
                provinciaInfo.Prov_Nombre = txtprovincia.Text;
                provinciaInfo.Id_Pais = Convert.ToInt32(lblpais.Text);
                ProvinciasLogica.SaveProv(provinciaInfo);
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

        private void ModificarProvincia(Provincia provinciaInfo)
        {
            try
            {
                lblmensaje.Text = "";
                provinciaInfo = new Provincia();
                provinciaInfo.Prov_Nombre = txtprovincia.Text;
                provinciaInfo.Id_Pais = Convert.ToInt32(lblpais.Text);
                ProvinciasLogica.ModifyProv(provinciaInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Guardados </br>";
                Regresar();
            }
            catch (Exception)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Modificados </br>";
            }
        }

        private void GuardarDatosProvincia(int id)
        {
            if (id == 0)
            {
                GuardarPronvincia();
            }
            else
            {
                provinciaInfo = ProvinciasLogica.ObtenerProvinciaID(id);
                if (provinciaInfo != null)
                {
                    ModificarProvincia(provinciaInfo);
                }
            }
        }

        private void Regresar()
        {
            Response.Redirect("ProvinciasWeb.aspx", true);
        }

        protected void btnprovincia_Click(object sender, EventArgs e)
        {
            GuardarDatosProvincia(Convert.ToInt32(Request["cod"]));
        }

        protected void grdProvincia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdprovincia.PageIndex = e.NewPageIndex;
            cargarProvincias();
        }

        protected void grdProvincia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("ProvinciasWeb.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Provincia provinciaInfo = new Provincia();
                provinciaInfo = ProvinciasLogica.ObtenerProvinciaID(codigo);
                if (provinciaInfo != null)
                {
                    ProvinciasLogica.DeleteProv(provinciaInfo);
                    cargarProvincias();
                }
            }
        }

        protected void lnkregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Ciudades.aspx");
        }
    }
}