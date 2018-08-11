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
    public partial class Tipo_Material : System.Web.UI.Page
    {
        private TipoMaterial tipoMaterialInfo = new TipoMaterial();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    tipoMaterialInfo = TipoMaterialLogica.ObtenertipoID(codigo);
                    if (tipoMaterialInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = tipoMaterialInfo.Id_TipoMaterial.ToString();
                            txtnombreMat.Text = tipoMaterialInfo.TMat_Nombre.ToString();
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
                cargarTipo();
            }
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                tipoMaterialInfo = new TipoMaterial();
                tipoMaterialInfo.TMat_Nombre = txtnombreMat.Text;
                TipoMaterialLogica.Save(tipoMaterialInfo);
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

        private void Modificar(TipoMaterial tipoMaterialInfo)
        {
            try
            {
                lblmensaje.Text = "";
                tipoMaterialInfo.TMat_Nombre = txtnombreMat.Text;
                TipoMaterialLogica.Modify(tipoMaterialInfo);
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

        private void Regresar()
        {
            Response.Redirect("Tipo_Material.aspx", true);
        }

        private void GuardarDatos(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                tipoMaterialInfo = TipoMaterialLogica.ObtenertipoID(id);
                if (tipoMaterialInfo != null)
                {
                    Modificar(tipoMaterialInfo);
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        private void cargarTipo()
        {
            grdMaterial.DataSource = TipoMaterialLogica.obtenertipo();
            grdMaterial.DataBind();
        }

        protected void grdMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Tipo_Material.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                TipoMaterial tipomaterialInfo = new TipoMaterial();
                tipomaterialInfo = TipoMaterialLogica.ObtenertipoID(codigo);
                if (tipomaterialInfo != null)
                {
                    TipoMaterialLogica.Delete(tipomaterialInfo);
                    cargarTipo();
                }
            }
        }

        protected void grdMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdMaterial.PageIndex = e.NewPageIndex;
            cargarTipo();
        }
    }
}