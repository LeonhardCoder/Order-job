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
    public partial class webTecnologia : System.Web.UI.Page
    {
       private Tecnologia tecnologiaInfo = new Tecnologia();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled=false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    tecnologiaInfo = TecnologiaLogica.ObtenerTecnologiaID(codigo);
                    if (tecnologiaInfo != null)
                    {
                        try
                        {
                            lblcodigo.Text = tecnologiaInfo.Id_Tecnologia.ToString();
                            txtnombre.Text = tecnologiaInfo.Tec_Nombre.ToString();
                            txtdescripcion.Text = tecnologiaInfo.Tec_Descripcion.ToString();
                            ddlcategoria.SelectedValue = tecnologiaInfo.Id_TipoCategoria.ToString();
                            UcOperador1.DropDownList.SelectedValue = tecnologiaInfo.Id_Operadora.ToString();
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
                CargarTipo();
            }
        }

        private void CargarTipo()
        {
            List<Tipo_Categoria> Lista = new List<Tipo_Categoria>();
            Lista = TipoCategoriaLogica.obtenerTipocategoria();
            Lista.Insert(0, new Tipo_Categoria() { Tip_Numero = "Seleccione Tipo" });
            ddlcategoria.DataSource = Lista;
            ddlcategoria.DataTextField = "Tip_Numero";
            ddlcategoria.DataValueField = "Id_TipoCategoria";
            ddlcategoria.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                tecnologiaInfo = new Tecnologia();
                tecnologiaInfo.Tec_Nombre = txtnombre.Text;
                tecnologiaInfo.Tec_Descripcion = txtdescripcion.Text;
                tecnologiaInfo.Id_TipoCategoria = Convert.ToInt32(ddlcategoria.SelectedValue);
                tecnologiaInfo.Id_Operadora = Convert.ToInt32(UcOperador1.DropDownList.SelectedValue);
                TecnologiaLogica.Save(tecnologiaInfo);
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
            Response.Redirect("Tecnologia.aspx", true);
        }

        private void ModificarTecnologia(Tecnologia tecnologiaInfo)
        {
            try
            {
                tecnologiaInfo = new Tecnologia();
                tecnologiaInfo.Tec_Nombre = txtnombre.Text;
                tecnologiaInfo.Tec_Descripcion = txtdescripcion.Text;
                //tecnologiaInfo.Id_TipoCategoria = Convert.ToInt32(ddlcategoria.SelectedValue);
                //tecnologiaInfo.Id_Operadora = Convert.ToInt32(UcOperador1.DropDownList.SelectedValue);
                //tecnologiaInfo.Id_TipoCategoria = Convert.ToInt32(lblcodcat.Text);
                //dbArtekWebDataContext dc = new dbArtekWebDataContext();
                int cat_id = Convert.ToInt32(ddlcategoria.SelectedValue);
                int ope_id = Convert.ToInt32(UcOperador1.DropDownList.SelectedValue);
                TecnologiaLogica.Modify(tecnologiaInfo, cat_id, ope_id);
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

        private void GuardarDatosTecnologia(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                tecnologiaInfo = TecnologiaLogica.ObtenerTecnologiaID(id);
                if (tecnologiaInfo != null)
                {
                    ModificarTecnologia(tecnologiaInfo);
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatosTecnologia(Convert.ToInt32(Request["cod"]));
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatosTecnologia(Convert.ToInt32(Request["cod"]));
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerTecnologia.aspx");
        }
    }
}