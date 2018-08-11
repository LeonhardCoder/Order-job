<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Contactos.aspx.cs" Inherits="ArtekWeb.App_Start.Contactos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .cleaner { clear: both; height: 37px; }
    .contenido{ width: 960px; 
height: 484px;
            margin-right: 0px;
        }
    .divfloat{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:414px; }
    .divfloatver{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:487px; }
    .conten{ width: 316px; height: 53px; 
margin-left: 43px; 
margin-top: 10px; }
    .botones{ width: 398px; 
height: 40px; margin-left: 11px; margin-top: 22px
        }
</style>
    <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="contenido">
        <div class="divfloat">
            <div class="cleaner"> 
         <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombreCli" runat="server" Width="95px" class="label" ForeColor="Black">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreCli" runat="server" Width="250px" Height="30px" class="form-control" placeholder="Ingrese el contacto"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lblcliente" runat="server" Width="95px" class="label" ForeColor="Black">Cliente: </asp:Label>
                <asp:DropDownList ID="ddlcliente" runat="server" Height="16px" Width="250px" class="dropdown-header divider form-control">
                </asp:DropDownList>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" style="margin-left: 2px" Text="Guardar" Width="120px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Height="34px" Text="Actualizar" Width="120px" Enabled="false" OnClick="btnactualizar_Click"/>
                <asp:Button ID="bntregresar" runat="server" Height="34px" Text="Regresar" Width="120px" OnClick="bntregresar_Click"/>
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"> </div>
            <asp:GridView ID="grdContacto" runat="server" AutoGenerateColumns="False"
                 Height="14px" Width="479px" CaptionAlign="Bottom" OnRowCommand="grdContacto_RowCommand" AllowPaging="True" CellPadding="0" OnSelectedIndexChanging="grdContacto_SelectedIndexChanging" PageSize="8">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                        <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png" 
                        CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Contacto")%>'  />
                    </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Contacto")%>' 
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                        <asp:Label ID="CExt_Nombre" runat="server" Text='<%#Eval("Cont_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente">
                        <ItemTemplate>
                        <asp:Label ID="CExt_Direccion" runat="server" Text='<%#Eval("ClienteExterno.CExt_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
         <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
