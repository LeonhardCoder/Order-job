<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Ciudades.aspx.cs" Inherits="ArtekWeb.App_Start.Ciudades" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 24px;
            width: 588px;
            margin-top: 10px;
        }

        .contenido {
            width: 1007px;
            height: 500px;
        }

        .divfloat {
            float: left;
            height: 362px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 353px;
        }

        .divfloatver {
            float: left;
            height: 376px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 587px;
        }

        .divfloatprovincia {
            float: left;
            height: 434px;
            width: 722px;
        }

        .conten {
            width: 316px;
            width: 374px;
            height: 54px;
            margin-top: 20px;
        }

        .botones {
            margin-top: 36px;
        }
    </style>
    <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contenido">
        <div class="divfloat">
            <div class="cleaner">
                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" OnClick="ImageButton1_Click" Width="32px" />
                <asp:LinkButton ID="lnkprovincia" runat="server" OnClick="lnkprovincia_Click">Agregar Provincia</asp:LinkButton>
            </div>
            <div style="height: 7px">
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblmen" runat="server" Text="" ForeColor="Black"></asp:Label>
            </div>
            <div class="conten">
                <br />
                <asp:Label ID="lblnombreCiu" runat="server" Width="95px">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreCiu" runat="server" class="form-control" Width="200px" placeholder="Ciudad"></asp:TextBox><br />
            </div>
            <div class="conten">
                <asp:Label ID="lblprovincia" runat="server" Width="95px">Provincia: </asp:Label>
                <asp:DropDownList ID="ddlprovincia" runat="server" Height="21px" class="dropdown-header divider form-control" Width="204px"></asp:DropDownList>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardarciu" runat="server" Height="34px" Style="margin-left: 76px" Text="Guardar" Width="100px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" Height="34px" Width="100px" Enabled="false" OnClick="btnActualizar_Click" />
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"></div>
            <div class="cleaner">
                <asp:Label ID="lblbuscar" runat="server" Style="margin-left: 20px; width: 101px;" class="col-md-1 control-label">Buscar: </asp:Label>
                <asp:TextBox ID="txtbuscar" runat="server" class="form-control col-sm-1" Width="250px" Height="27px" placeholder="Buscar..."></asp:TextBox>
                <asp:Image ID="imgbuscar" runat="server" ImageUrl="~/Images/buscar.jpg" Width="32px" Height="32px" />
            </div>
            <asp:GridView ID="grdCiudad" runat="server" AutoGenerateColumns="False"
                Height="16px" Width="347px" CaptionAlign="Bottom" OnRowCommand="grdCiudad_RowCommand" PageSize="8" AllowPaging="True" CellPadding="0" Font-Size="Small" OnPageIndexChanging="grdCiudad_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Ciudad")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Ciudad")%>' 
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Ciudad">
                        <ItemTemplate>
                            <asp:Label ID="Ciu_Nombre" runat="server" Text='<%#Eval("Ciu_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Provincia">
                        <ItemTemplate>
                            <asp:Label ID="Prov_Nombre" runat="server" Text='<%#Eval("Provincia.Prov_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle Font-Size="Smaller" />
            </asp:GridView>
        </div>
        <asp:Label ID="lblcodio" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
