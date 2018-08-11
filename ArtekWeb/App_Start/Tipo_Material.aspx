<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Tipo_Material.aspx.cs" Inherits="ArtekWeb.App_Start.Tipo_Material" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 37px;
        }

        .contenido {
            width: 880px;
            height: 352px;
        }

        .divfloat {
            float: left;
            height: 295px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 327px;
        }

        .divfloatver {
            float: left;
            height: 338px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 487px;
        }

        .divfloatprovincia {
            float: left;
            height: 295px;
        }

        .conten {
            width: 316px;
            width: 718px;
            height: 61px;
        }

        .modalbackgraund {
            background-color: Aqua;
            filter: alpha(opacity=70);
            opacity: 0.2;
            z-index: 1000;
        }
        .botones {
            margin-top: 126px;
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
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombreMat" runat="server" Width="95px">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreMat" runat="server" class="form-control" Width="200px"></asp:TextBox><br />
            </div>
            <div class="conten">
                <asp:Label ID="lbldescripcion" runat="server" Width="95px">Descripcion: </asp:Label>
                <asp:TextBox ID="txtdescripcion" runat="server" class="form-control" Width="200px"></asp:TextBox><br />
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 6px" Text="Guardar" Width="125px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="125px" Height="34px" Enabled="false" />
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"></div>
            <asp:GridView ID="grdMaterial" runat="server" AutoGenerateColumns="False"
                Height="17px" Width="380px" CaptionAlign="Bottom" OnRowCommand="grdMaterial_RowCommand" AllowPaging="True" CellPadding="0" PageSize="6" OnPageIndexChanging="grdMaterial_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_TipoMaterial")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_TipoMaterial")%>'
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="Ciu_Nombre" runat="server" Text='<%#Eval("TMat_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
