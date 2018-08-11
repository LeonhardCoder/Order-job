<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Tipo_Trabajo.aspx.cs" Inherits="ArtekWeb.App_Start.Tipo_Trabajo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .cleaner { clear: both; height: 37px; }
    .contenido{ width: 880px; height: 352px; }
    .divfloat{ float:left; height:295px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:327px; }
    .divfloatver{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:487px; }
    .divfloatprovincia {float: left; height: 295px; }
    .conten {width: 316px; width: 718px; height: 70px;
            margin-top: 33px;
        }
    .modalbackgraund {background-color: Aqua; filter: alpha(opacity=70); opacity: 0.2; z-index: 1000; }
        .botones {
            height: 47px;
            width: 440px;
            margin-top: 146px;
            margin-left: 6px;
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
                <asp:Label ID="lblcpdogo" runat="server" Text=""></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombre" runat="server" Width="95px"  class="control">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreTrab" class="form-control" runat="server" Width="200px"></asp:TextBox><br/>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" style="margin-left: 2px" Text="Guardar" Width="120px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Height="34px" Text="Actualizar" Width="120px" Enabled="false" OnClick="btnactualizar_Click"/>
                <asp:Button ID="bntregresar" runat="server" Height="34px" Text="Regresar" Width="120px" OnClick="bntregresar_Click"/>
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"> </div>
            <asp:GridView ID="grdTrabajo" runat="server" AutoGenerateColumns="False"
                 Height="16px" Width="238px" CaptionAlign="Bottom" OnRowCommand="grdTrabajo_RowCommand" AllowPaging="True" CellPadding="0" PageSize="6" OnPageIndexChanging="grdTrabajo_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                        <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png" 
                        CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_TipoTrabajo")%>'  />
                    </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                        <asp:Label ID="Ttrab_Nombre" runat="server" Text='<%#Eval("Ttrab_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>

