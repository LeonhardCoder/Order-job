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
    public partial class webMateriales : System.Web.UI.Page
    {
        private Materiales materialInfo = new Materiales();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    materialInfo = MaterialesLogica.ObtenerMaterialesID(codigo);
                    if (materialInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = materialInfo.Id_Materiales.ToString();
                            txtnombreMat.Text = materialInfo.Mat_Nombre.ToString();
                            txtdescripcion.Text = materialInfo.Mat_Descripcion.ToString();
                            ddrtipomaterial.Text = materialInfo.Id_TipoMaterial.ToString();
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
                cargarMaterial();
                ListarTipo();
            }
        }

        private void cargarMaterial()
        {
            grdMaterial.DataSource =  MaterialesLogica.obtenerMateriales();
            grdMaterial.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                materialInfo = new Materiales();
                materialInfo.Mat_Nombre = txtnombreMat.Text;
                materialInfo.Mat_Descripcion = txtdescripcion.Text;
                materialInfo.Id_TipoMaterial = Convert.ToInt32(ddrtipomaterial.SelectedValue);
                MaterialesLogica.Save(materialInfo);
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
            Response.Redirect("Materiales.aspx", true);
        }

        private void ModificarMateriales(Materiales materialesInfo)
        {
            try
            {
                lblmensaje.Text = "";
                materialInfo.Mat_Nombre = txtnombreMat.Text;
                materialInfo.Mat_Descripcion = txtdescripcion.Text;
                materialInfo.Id_TipoMaterial = Convert.ToInt32(ddrtipomaterial.SelectedValue);
                MaterialesLogica.Modify(materialInfo);
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

        private void GuardarDatosMateriales(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                materialInfo = MaterialesLogica.ObtenerMaterialesID(id);
                if (materialInfo != null)
                {
                    ModificarMateriales(materialInfo);
                }
            }
        }

        private void ListarTipo()
        {
            List<TipoMaterial> Lista = new List<TipoMaterial>();
            Lista = TipoMaterialLogica.obtenertipo();
            Lista.Insert(0, new TipoMaterial() { TMat_Nombre = "Seleccione Tipo" });
            ddrtipomaterial.DataSource = Lista;
            ddrtipomaterial.DataTextField = "TMat_Nombre";
            ddrtipomaterial.DataValueField = "Id_TipoMaterial";
            ddrtipomaterial.DataBind();
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosMateriales(Convert.ToInt32(Request["cod"]));
        }

        protected void grdMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "edit")
            {
                Response.Redirect("Materiales.aspx?cod=" + codigo, true);
            }
            if (e.CommandName == "eliminar")
            {
                Materiales materialInfo = new Materiales();
                materialInfo = MaterialesLogica.ObtenerMaterialesID(codigo);
                if (materialInfo != null)
                {
                    MaterialesLogica.Delete(materialInfo);
                    cargarMaterial();
                }
            }
        }

        protected void grdMaterial_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            this.grdMaterial.PageIndex = e.NewSelectedIndex;
            cargarMaterial();
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosMateriales(Convert.ToInt32(Request["cod"]));
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("");
        }

        protected void lnktipomaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("Tipo_Material.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Tipo_Material.aspx");
        }
    }
}