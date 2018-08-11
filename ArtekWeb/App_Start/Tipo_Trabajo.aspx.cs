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
    public partial class Tipo_Trabajo : System.Web.UI.Page
    {
        private TipoTrabajo tipotrabajolInfo = new TipoTrabajo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    tipotrabajolInfo = TipoTrabajoLogica.ObtenerTipoTrabajoID(codigo);
                    if (tipotrabajolInfo != null)
                    {
                        try
                        {
                            lblcpdogo.Text = tipotrabajolInfo.Id_TipoTrabajo.ToString();
                            txtnombreTrab.Text = tipotrabajolInfo.Ttrab_Nombre.ToString();
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
                cargarTrabajo();
            }
        }
        private void cargarTrabajo()
        {
            grdTrabajo.DataSource = TipoTrabajoLogica.obtenerTipotrabajo();
            grdTrabajo.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                tipotrabajolInfo = new TipoTrabajo();
                tipotrabajolInfo.Ttrab_Nombre = txtnombreTrab.Text;
                TipoTrabajoLogica.Save(tipotrabajolInfo);
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
            Response.Redirect("Tipo_Trabajo.aspx", true);
        }

        private void ModificarTrabajo(TipoTrabajo tipotrabajolInfo)
        {
            try
            {
                lblmensaje.Text = "";
                tipotrabajolInfo.Ttrab_Nombre = txtnombreTrab.Text;
                TipoTrabajoLogica.Save(tipotrabajolInfo);
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

        private void GuardarDatosTrabajo(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                tipotrabajolInfo = TipoTrabajoLogica.ObtenerTipoTrabajoID(id);
                if (tipotrabajolInfo != null)
                {
                    ModificarTrabajo(tipotrabajolInfo);
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosTrabajo(Convert.ToInt32(Request["cod"]));
        }

        protected void grdTrabajo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Tipo_Trabajo.aspx?cod=" + codigo, true);
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosTrabajo(Convert.ToInt32(Request["cod"]));
        }

        protected void bntregresar_Click(object sender, EventArgs e)
        {

        }

        protected void grdTrabajo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdTrabajo.PageIndex = e.NewPageIndex;
            cargarTrabajo();
        }
    }
}