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
    public partial class Ciudades : System.Web.UI.Page
    {
        private Ciudad ciudadInfo = new Ciudad ();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardarciu.Enabled = false;
                    btnActualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    ciudadInfo = CiudadesLogica.ObtenerCiudadID(codigo);
                    if (ciudadInfo != null)
                    {
                        try
                        {
                            lblcodio.Text = ciudadInfo.Id_Ciudad.ToString();
                            txtnombreCiu.Text = ciudadInfo.Ciu_Nombre.ToString();
                            ddlprovincia.SelectedValue = ciudadInfo.Id_Provincia.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    else
                    {
                        btnguardarciu.Enabled = true;
                        btnActualizar.Enabled = false;
                    }
                }
                
                this.Form.Attributes.Add("autocomplete", "off");
                cargarCiudades();
                CargarProv();
            }
        }

        //Informacion Ciudades
        private void cargarCiudades()
        {
            grdCiudad.DataSource = CiudadesLogica.obtenerCiudades();
            grdCiudad.DataBind();
        }

        private void CargarProv()
        {
            List<Provincia> ListaProv = new List<Provincia>();
            ListaProv = ProvinciasLogica.obtenerProvincia();
            ListaProv.Insert(0, new Provincia() { Prov_Nombre = "Seleccione Provincia" });
            ddlprovincia.DataSource = ListaProv;
            ddlprovincia.DataTextField = "Prov_Nombre";
            ddlprovincia.DataValueField = "Id_Provincia";
            ddlprovincia.DataBind();
        }

        private void GuardarCiudad()
        {
            try
            {
                lblmensaje.Text = "";
                ciudadInfo = new Ciudad();
                if (txtnombreCiu.Text != null || validarCiudades(txtnombreCiu.Text))
                {
                    lblmen.Text = "Ingrese el nombre de la ciudad </br>";
                }
                else
                {
                    ciudadInfo.Ciu_Nombre = txtnombreCiu.Text;
                }

                ciudadInfo.Id_Provincia = Convert.ToInt32(ddlprovincia.SelectedValue);
                CiudadesLogica.Save(ciudadInfo);
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

        private void ModificarCiudad (Ciudad ciudadInfo)
        {
            try
            {
                lblmensaje.Text = "";
                ciudadInfo.Ciu_Nombre = txtnombreCiu.Text;
                ciudadInfo.Id_Provincia = Convert.ToInt32(ddlprovincia.SelectedValue);
                CiudadesLogica.Modify(ciudadInfo);
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

        private void GuardarDatosCiudad(int id)
        {
            if (id == 0)
            {
                GuardarCiudad();
            }
            else
            {
                ciudadInfo = CiudadesLogica.ObtenerCiudadID(id);
                if (ciudadInfo != null)
                {
                    ModificarCiudad(ciudadInfo);
                }
            }
        }

        private void Regresar()
        {
            Response.Redirect("Ciudades.aspx", true);
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosCiudad(Convert.ToInt32(Request["cod"]));
        }

        protected void grdCiudad_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Ciudades.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Ciudad ciudadInfo = new Ciudad();
                ciudadInfo = CiudadesLogica.ObtenerCiudadID(codigo);
                if (ciudadInfo != null)
                {
                    CiudadesLogica.Delete(ciudadInfo);
                    cargarCiudades();
                }
            }
        }

        protected void lnkprovincia_Click(object sender, EventArgs e)
        {
            Response.Redirect("ProvinciasWeb.aspx");
        }

        protected void grdCiudad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.grdCiudad.PageIndex = e.NewPageIndex;
            cargarCiudades();
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosCiudad(Convert.ToInt32(Request["cod"]));
        }

        private bool validarCiudades(string ciudades)
        {

            if (!CiudadesLogica.validarCiudad(ciudades))
            {
                return true;
            }
            else if (ciudades != null)
            {
                CiudadesLogica.validarCiudad(ciudades);
                lblmen.Visible = true;
                lblmen.Text = "Ciudad ya Existe";
            }

            return false;
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("ProvinciasWeb.aspx");
        }
    }
}