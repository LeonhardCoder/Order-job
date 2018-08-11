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
    public partial class webOperadora : System.Web.UI.Page
    {  
        private Operadora operadoraInfo = new  Operadora();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = true;
                    btnactualizar.Enabled = false;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    Operadora operadoraInfo = new Operadora();
                    operadoraInfo = OperadoraLogica.ObtenerOperadoraID(codigo);
                    if (operadoraInfo != null)
                    {
                            lblcodigo.Text = operadoraInfo.Id_Operadora.ToString();
                            txtnombreope.Text = operadoraInfo.Ope_Nombre.ToString();
                            txtdireccion.Text = operadoraInfo.Ope_Direccion.ToString();
                            txttelefono.Text = operadoraInfo.Ope_Telefono.ToString();
                            txtfechacreacion.Text = operadoraInfo.Ope_FechaCreacion.ToString();
                            url_imagen.Text = operadoraInfo.Ope_Logo.ToString();
                            imgSubida.Width = 120;
                            imgSubida.Width = 120;
                            imgSubida.ImageUrl = url_imagen.Text;
                    }
                    else
                    {
                        imgSubida.Width = 0;
                        imgSubida.Width = 0;
                        imgSubida.ImageUrl = "";
                        btnguardar.Enabled = false;
                        btnactualizar.Enabled = true;
                    }
                }
                this.Page.Form.Attributes.Add("enctype", "multipart/form-data");
                this.Form.Attributes.Add("autocomplete", "off");
            }
        }

        

        private void ModificarOperadora(Operadora operadoraInfo)
        {
            try
            {
                lblmensaje.Text = "";
                operadoraInfo.Ope_Nombre = txtnombreope.Text;
                operadoraInfo.Ope_Direccion = txtdireccion.Text;
                operadoraInfo.Ope_Telefono = txttelefono.Text;
                operadoraInfo.Ope_FechaCreacion = Convert.ToDateTime(txtfechacreacion.Text);
                operadoraInfo.Ope_Logo = url_imagen.Text;
                OperadoraLogica.Modify(operadoraInfo);
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

        private void GuardarDatos(int id)
        {
            if (id == 0)
            {
                Guardar();
            }
            else
            {
                operadoraInfo = OperadoraLogica.ObtenerOperadoraID(id);
                if (operadoraInfo != null)
                {
                    ModificarOperadora(operadoraInfo);
                }
            }
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                Operadora operadoraInfo = new Operadora();
                operadoraInfo.Ope_Nombre = txtnombreope.Text;
                operadoraInfo.Ope_Direccion = txtdireccion.Text;
                operadoraInfo.Ope_Telefono = txttelefono.Text;
                operadoraInfo.Ope_FechaCreacion = Convert.ToDateTime(txtfechacreacion.Text);
                operadoraInfo.Ope_Logo = url_imagen.Text;
                OperadoraLogica.Save(operadoraInfo);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Modificados </br>";
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
            Response.Redirect("Operadora.aspx", true);
        }

        private Boolean ValidaExtension(string sExtension)
        {
            Boolean rel = false;
            switch (sExtension)
            {
                case ".jpg":
                case ".jpeg":
                case ".png":
                case ".gif":
                case ".bmp":
                    rel = true;
                    break;
                default:
                    rel = false;
                    break;

            }
            return rel;
        }

        private void btnimagen()
        {
            string sExt = string.Empty;
            string sName = string.Empty;

            imgSubida.Width = 0;
            imgSubida.Width = 0;
            imgSubida.ImageUrl = "";

            if (this.FileUpload1.HasFile)
            {
                sName = FileUpload1.FileName;
                sExt = Path.GetExtension(sName);

                if (ValidaExtension(sExt))
                {
                    if (File.Exists("~/DataBind/" + sName))
                    {
                        Label1.Text = "El archivo  duplicado";
                    }
                    else
                    {

                        FileUpload1.SaveAs(MapPath("~/DataBind/" + sName));
                        imgSubida.Width = 120;
                        imgSubida.Width = 120;
                        imgSubida.ImageUrl = "/DataBind/" + sName;
                        url_imagen.Text = "~/DataBind/" + sName;
                        Label1.Text = "Archivo cargado correctamente.";
                    }
                }
                else
                    Label1.Text = "El archivo no es de tipo imagen.";
            }
            else
                Label1.Text = "Seleccione el archivo que desea subir.";
        }

        private bool validari(string imagen)
        {

            if (imagen == "")
            {
                btnimagen();
                lblvalidaimagen.Visible = true;
                lblvalidaimagen.Text = "suba una imagen";
            }
            else if (imagen != null)
            {
                btnimagen();
                lblvalidaimagen.Visible = true;
                lblvalidaimagen.Text = "la imagen fue subida";
                return true;
            }
            return false;
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(InformationLabel.Text));
        }

        protected void btnSubir_Click(object sender, EventArgs e)
        {
            btnimagen();
        }

        protected void FileUpload1_PreRender(object sender, EventArgs e)
        {
            base.OnPreRender(e);
            if (Page.Form != null && Page.Form.Enctype.Length == 0)
            {
                this.Page.Form.Enctype = "multipart/form-data";
            }
        }

        protected void FileUpload1_Init(object sender, EventArgs e)
        {
            base.OnInit(e);
        }

        protected void lnknuevo_Click(object sender, EventArgs e)
        {
            txtnombreope.Text = "";
            txtdireccion.Text= "";
            txttelefono.Text= "";
            txtfechacreacion.Text= "";
            url_imagen.Text= "";
            imgSubida.Visible = false;
            Label1.Text = "";
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(InformationLabel.Text));
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerOperadoras.aspx");
        }
    }
}