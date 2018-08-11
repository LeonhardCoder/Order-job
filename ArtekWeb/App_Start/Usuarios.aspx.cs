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
    public partial class Usuarios : System.Web.UI.Page
    {
        private Usuario usuarioInfo = new Usuario();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request["cod"] != null)
                {
                    btnguardar.Enabled = false;
                    btnactualizar.Enabled = true;
                    int codigo = Convert.ToInt32(Request["cod"]);
                    usuarioInfo = UsuarioLogica.ObtenerUsuarioID(codigo);
                    if (usuarioInfo != null)
                    {
                        try
                        {
                            txtcodigo.Text = usuarioInfo.Id_Usuario.ToString();
                            txtcedula.Text = usuarioInfo.Usu_Cedula.ToString();
                            txtnombres.Text = usuarioInfo.Usu_Nombre.ToString();
                            txtapellido.Text = usuarioInfo.Usu_Apellido.ToString();
                            txtdireccion.Text = usuarioInfo.Usu_Direccion.ToString();
                            txtemail.Text = usuarioInfo.Usu_Correo.ToString();
                            txtTelefono.Text = usuarioInfo.Usu_Telefono.ToString();
                            txtfecha.Text = usuarioInfo.Usu_FechaCreacion.ToString();
                            ddlperfil.SelectedValue = usuarioInfo.Id_Perfil.ToString();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                }

                this.Form.Attributes.Add("autocomplete", "off");
                CargarPerfil();
            }
        }

        private void CargarPerfil()
        {
            List<Perfil> ListaPerfil = new List<Perfil>();
            ListaPerfil = PerfilLogica.obtenerPerfil();
            ListaPerfil.Insert(0, new Perfil() { Per_Nombre = "Seleccione Perfil" });
            ddlperfil.DataSource = ListaPerfil;
            ddlperfil.DataTextField = "Per_Nombre";
            ddlperfil.DataValueField = "Id_Perfil";
            ddlperfil.DataBind();
        }

        private void Guardar()
        {
            try
            {
                lblmensaje.Text = "";
                usuarioInfo = new Usuario();
                if (validaCedula(txtcedula.Text) && validarced(txtcedula.Text))
                {
                    usuarioInfo.Usu_Cedula = txtcedula.Text;
                    lblcedul.Visible = true;
                    lblcedul.Text = "";
                }
                else
                {
                    lblcedul.Visible = true;
                    lblcedul.Text = "Cedula Incorrecta ó Cedula existe";
                    throw new ArgumentException("Cedula Incorrecta ó Cedula existe </br>");
                }
                usuarioInfo.Usu_Apellido = txtapellido.Text;
                usuarioInfo.Usu_Nombre = txtnombres.Text;
                usuarioInfo.Usu_Direccion = txtdireccion.Text;
                if (validarmail(txtemail.Text))
                {
                    usuarioInfo.Usu_Correo = txtemail.Text;
                }
                else
                {
                    lblmail.Visible = true;
                    lblmail.Text = "";
                    throw new ArgumentException("Correo Incorrecto </br>");
                }
                if (validartelefono(txtTelefono.Text))
                {
                    usuarioInfo.Usu_Telefono = txtTelefono.Text;
                }
                else
                {
                    lbltelf.Visible = true;
                    lbltelf.Text = "";
                    throw new ArgumentException("Telefono Incorrecto </br>");
                }
                
                usuarioInfo.Usu_FechaCreacion = Convert.ToDateTime(txtfecha.Text);
                usuarioInfo.Usu_Username = txtcedula.Text;
                usuarioInfo.Usu_Clave = txtcedula.Text;
               
                usuarioInfo.Id_Perfil = Convert.ToInt32(ddlperfil.SelectedValue);
                UsuarioLogica.Save(usuarioInfo);
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
            Response.Redirect("VerUsuarios.aspx", true);
        }

        private void Modificar(Usuario usuarioInfo)
        {
            try
            {
                lblmensaje.Text = "";
                if (validaCedula(txtcedula.Text))
                {
                    usuarioInfo.Usu_Cedula = txtcedula.Text;
                    lblcedul.Visible = true;
                    lblcedul.Text = "cedula correcta";
                }
                else
                {
                    lblcedul.Visible = true;
                    lblcedul.Text = "Cedula Incorrecta ó Cedula existente";
                    throw new ArgumentException("Cedula Incorrecta ó Cedula existente </br>");
                }
                usuarioInfo.Usu_Apellido = txtapellido.Text;
                usuarioInfo.Usu_Nombre = txtnombres.Text;
                usuarioInfo.Usu_Direccion = txtdireccion.Text;
                //if (validarmail(txtemail.Text))
                //{
                    usuarioInfo.Usu_Correo = txtemail.Text;
                //}
                //else
                //{
                //    lblmail.Visible = true;
                //    lblmail.Text = "";
                //    throw new ArgumentException("Correo Incorrecto </br>");
                //}
                //if (validartelefono(txtTelefono.Text))
                //{
                    usuarioInfo.Usu_Telefono = txtTelefono.Text;
                //}
                //else
                //{
                //    lbltelf.Visible = true;
                //    lbltelf.Text = "";
                //    throw new ArgumentException("Telefono Incorrecto </br>");
                //}
                usuarioInfo.Usu_FechaCreacion = Convert.ToDateTime(txtfecha.Text);                
                //bArtekWebDataContext dc = new dbArtekWebDataContext();
                int perfil_id = Convert.ToInt32(ddlperfil.SelectedValue);
                //usuarioInfo.Id_Perfil = perfil.Id_Perfil;
                //el fk_id_perfil sera actualizado en el siguiente metodo.
                UsuarioLogica.Modify(usuarioInfo, perfil_id);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos Modificados </br>";
                Regresar();
            }
            catch (Exception ex)
            {
                lblmensaje.Visible = true;
                lblmensaje.Text = "Datos no Modificados </br> " + ex.Message;
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
                usuarioInfo = UsuarioLogica.ObtenerUsuarioID(id);
                if (usuarioInfo != null)
                {
                    Modificar(usuarioInfo);
                }
            }
        }

        private void link(int id)
        {
            if (id != 0)
            {
                usuarioInfo = UsuarioLogica.ObtenerUsuarioID(id);
                if (usuarioInfo != null)
                {
                    //Modificar(usuarioInfo);
                    Response.Redirect("Username.aspx");
                }
            }
        }

        protected void btnguardar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("Username.aspx");
           link(Convert.ToInt32(Request["cod"]));
        }

        protected void lnkcontraseña_Command(object sender, CommandEventArgs e)
        {
            int codigo = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "clave")
            {
                Response.Redirect("Username.aspx?cod=" + codigo, true);
            }
        }

        protected void btnactualizar_Click(object sender, EventArgs e)
        {
            GuardarDatos(Convert.ToInt32(Request["cod"]));
        }

        //Validaciones de datos

        private bool validarced(string cedula)
        {

            if (!UsuarioLogica.validarced(cedula))
            {
                return true;
            }
            else if (cedula != null)
            {
                UsuarioLogica.validarced(cedula);
                lblcedul.Visible = true;
                lblcedul.Text = "Cedula ya Existe";
            }

            return false;
        }

        private bool validartelefono(string telefono)
        {
            if (!UsuarioLogica.validartelefono(telefono))
            {
                return true;
            }
            else if (telefono != null)
            {
                UsuarioLogica.validartelefono(telefono);
                lblmensaje.Visible = true;
                lblmensaje.Text = "Telefono ya esta en existencia";
            }
            return false;
        }

        private bool validarmail(string correo)
        {
            if (!UsuarioLogica.validarmail(correo))
            {
                return true;
            }
            else if (correo != null)
            {
                UsuarioLogica.validarmail(correo);
                lblmail.Visible = true;
                lblmail.Text = "Correo ya esta en existencia";
            }
            return false;
        }

        public bool validaCedula(string campo)
        {
            string numero = campo; //este no se con cual cambiarle
            int suma;
            int d1;
            int d2;
            int d3;
            int d4;
            int d5;
            int d6;
            int d7;
            int d8;
            int d9;
            int d10;
            int p1 = 0;
            int p2 = 0;
            int p3 = 0;
            int p4 = 0;
            int p5 = 0;
            int p6 = 0;
            int p7 = 0;
            int p8 = 0;
            int p9 = 0;

            int residuo;
            bool pri = false;
            bool pub = false;
            bool nat = false;
            int digitoVerificador;
            int modulo = 11;
            // Verifico que el campo no contenga letras
            //bool ok = true;

            /* Aqui almacenamos los digitos de la cedula en variables. */


            d1 = Convert.ToInt32(numero.Substring(0, 1));
            d2 = Convert.ToInt32(numero.Substring(1, 1));
            d3 = Convert.ToInt32(numero.Substring(2, 1));
            d4 = Convert.ToInt32(numero.Substring(3, 1));
            d5 = Convert.ToInt32(numero.Substring(4, 1));
            d6 = Convert.ToInt32(numero.Substring(5, 1));
            d7 = Convert.ToInt32(numero.Substring(6, 1));
            d8 = Convert.ToInt32(numero.Substring(7, 1));
            d9 = Convert.ToInt32(numero.Substring(8, 1));
            d10 = Convert.ToInt32(numero.Substring(9, 1));

            // El tercer digito es: 
            // 9 para sociedades privadas y extranjeros 
            // 6 para sociedades publicas 
            // menor que 6 (0,1,2,3,4,5) para personas naturales  
            if (d3 == 7 || d3 == 8)
            {
                // msgError.Mensaje("X", "El tercer dígito ingresado es inválido");
                return false;
            }
            // Solo para personas naturales (modulo 10) 
            if (d3 < 6)
            {
                nat = true;
                p1 = d1 * 2;
                if (p1 >= 10)
                    p1 -= 9;
                p2 = d2 * 1;
                if (p2 >= 10)
                    p2 -= 9;
                p3 = d3 * 2;
                if (p3 >= 10)
                    p3 -= 9;
                p4 = d4 * 1;
                if (p4 >= 10)
                    p4 -= 9;
                p5 = d5 * 2;
                if (p5 >= 10)
                    p5 -= 9;
                p6 = d6 * 1;
                if (p6 >= 10)
                    p6 -= 9;
                p7 = d7 * 2;
                if (p7 >= 10)
                    p7 -= 9;
                p8 = d8 * 1;
                if (p8 >= 10)
                    p8 -= 9;
                p9 = d9 * 2;
                if (p9 >= 10)
                    p9 -= 9;
                modulo = 10;
            }
            // Solo para sociedades publicas (modulo 11) 
            // Aqui el digito verficador esta en la posicion 9, en las otras 2 en la pos. 10 //
            else if (d3 == 6)
            {
                pub = true;
                p1 = d1 * 3;
                p2 = d2 * 2;
                p3 = d3 * 7;
                p4 = d4 * 6;
                p5 = d5 * 5;
                p6 = d6 * 4;
                p7 = d7 * 3;
                p8 = d8 * 2;
                p9 = 0;
            }
            // Solo para entidades privadas (modulo 11) */
            else if (d3 == 9)
            {
                pri = true;
                p1 = d1 * 4;
                p2 = d2 * 3;
                p3 = d3 * 2;
                p4 = d4 * 7;
                p5 = d5 * 6;
                p6 = d6 * 5;
                p7 = d7 * 4;
                p8 = d8 * 3;
                p9 = d9 * 2;
            }
            suma = p1 + p2 + p3 + p4 + p5 + p6 + p7 + p8 + p9;
            residuo = suma % modulo;
            // Si residuo=0, dig.ver.=0, caso contrario 10 - residuo
            digitoVerificador = residuo == 0 ? 0 : modulo - residuo;
            // ahora comparamos el elemento de la posicion 10 con el dig. ver.
            if (pub)
            {
                if (digitoVerificador != d9)
                {
                    // msgError.Mensaje("X", "El ruc de la empresa del sector público es incorrecto");
                    return false;
                }
                // El ruc de las empresas del sector publico terminan con 0001
                if (numero.Substring(9, 4) != "0001")
                {
                    // msgError.Mensaje("X", "El ruc de la empresa del sector público debe terminar con 0001");
                    return false;
                }
            }
            else if (pri)
            {
                if (digitoVerificador != d10)
                {
                    // msgError.Mensaje("X", "El ruc de la empresa del sector privado es incorrecto.");
                    return false;
                }
                if (numero.Substring(10, 3) != "001")
                {
                    //msgError.Mensaje("X", "El ruc de la empresa del sector privado debe terminar con 001");
                    return false;
                }
            }
            else if (nat)
            {
                if (digitoVerificador != d10)
                {
                    // msgError.Mensaje("X", "El número de cédula de la persona natural es incorrecto.");
                    return false;
                }
                if (numero.Length > 10 && numero.Substring(10, 3) != "001")
                {
                    //msgError.Mensaje("X", "El ruc de la persona natural debe terminar con 001");
                    return false;
                }
            }
            return true;
        }

        protected void btnregresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("VerUsuarios.aspx");
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Username.aspx");
        }
    }
}