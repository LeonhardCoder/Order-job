using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using AccesoDatos;
using LogicaNegocio;
using System.Data.Linq;
using System.Collections.Generic;

namespace ArtekWeb.UseControls
{
    public partial class UcOperador : System.Web.UI.UserControl
    {
        private List<Operadora> _operadora { get; set; }

        public int SelectedIndex
        {
            get { return ddloperador.SelectedIndex; }
            set { ddloperador.SelectedIndex = value; }
        }

        public DropDownList DropDownList
        {
            get { return ddloperador; }
            set { ddloperador = value; }
        }

        public Operadora OperadoraInfo
        {
            get { return _operadora[ddloperador.SelectedIndex]; }
            set { ddloperador.SelectedIndex = _operadora.FindIndex(ope => ope.Id_Operadora == value.Id_Operadora); }
        }

        private void CargarOperador()
        {
            _operadora = OperadoraLogica.obtenerOperadora();
            _operadora.Insert(0, new Operadora() { Ope_Nombre = "Seleccione Tipo" });
            ddloperador.DataSource = _operadora;
            ddloperador.DataTextField = "Ope_Nombre";
            ddloperador.DataValueField = "Id_Operadora";
            ddloperador.DataBind();
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarOperador();
            }
        }

        protected void ddloperador_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblcodope.Text = ddloperador.SelectedValue.ToString();
        }
    }
}