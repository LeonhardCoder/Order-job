<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Materiales.aspx.cs" Inherits="ArtekWeb.App_Start.webMateriales" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .cleaner { clear: both; height: 37px; }
    .contenido{ width: 880px; height: 352px; }
    .divfloat{ float:left; height:335px; 
margin:0 0 0 26px; padding:0px 3px 0px 0px; width:445px; }
    .divfloatver{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:369px; }
    .divfloatprovincia {float: left; height: 295px; }
    .conten {width: 316px; width: 718px; height: 61px; }
    .modalbackgraund {background-color: Aqua; filter: alpha(opacity=70); opacity: 0.2; z-index: 1000; }
        .botones {
            width: 558px;
            margin-top: 76px;
        }
    </style>
     <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="contenido">
        <div class="divfloat">
            <div class="cleaner"> 
                
                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" OnClick="ImageButton1_Click" Width="32px" />
                
                <asp:LinkButton ID="lnktipomaterial" runat="server" OnClick="lnktipomaterial_Click">Nuevo Tipo Material</asp:LinkButton>
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombreMat" runat="server" Width="95px" class="label" ForeColor="Black">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreMat" runat="server" Width="250px" class="form-control" placeholder="Ingrese el nombre del material"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbldescripcion" runat="server" Width="95px" class="label" ForeColor="Black">Descripcion: </asp:Label>
                <asp:TextBox ID="txtdescripcion" runat="server" Width="250px" class="form-control" placeholder="Ingrese la descripción del material"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbltipo" runat="server" Width="95px" class="label" ForeColor="Black">Tipo Material: </asp:Label>
                <asp:DropDownList ID="ddrtipomaterial" runat="server" Height="18px" Width="204px" class="dropdown-header divider form-control"></asp:DropDownList>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" style="margin-left: 3px" Text="Guardar" Width="120px" OnClick="btnguardar_Click" />
                 <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="120px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="120px" Height="34px" OnClick="btnregresar_Click" />
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"> </div>
            <asp:GridView ID="grdMaterial" runat="server" AutoGenerateColumns="False"
                 Height="17px" Width="340px" CaptionAlign="Bottom" PageIndex="10" OnRowCommand="grdMaterial_RowCommand" OnSelectedIndexChanging="grdMaterial_SelectedIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                        <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png" 
                        CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Materiales")%>'  />
                    </ItemTemplate> 
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Materiales")%>' 
                                OnClientClick='return confirm("Esta seguro que desea inactivar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                        <asp:Label ID="Ciu_Nombre" runat="server" Text='<%#Eval("Mat_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Tipo Material">
                        <ItemTemplate>
                        <asp:Label ID="Prov_Nombre" runat="server" Text='<%#Eval("TipoMaterial.TMat_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
         <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
