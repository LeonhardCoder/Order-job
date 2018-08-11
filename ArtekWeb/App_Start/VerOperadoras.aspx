<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="VerOperadoras.aspx.cs" Inherits="ArtekWeb.App_Start.VerOperadoras" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .divfloatver {
            height: 550px;
        }

        .divfloat {
            float: left;
            height: 36px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 188px;
        }

        .cleaner {
            height: 42px;
        }

        .h10 {
            margin-top: 2px;
            height: 27px;
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
    <div class="divfloatver">
        <div class="h10"></div>
        <div class="divfloat">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png"
                Width="32px" OnClick="ImageButton1_Click" Style="margin-left: 44px" />
            <asp:LinkButton ID="lnknuevo" runat="server" OnClick="lnknuevo_Click">Nuevo</asp:LinkButton>
        </div>
        <div class="divfloat">
            <asp:ImageButton ID="imgcontacto" runat="server" Height="32px" ImageUrl="~/Images/agregar.png"
                Width="32px" Style="margin-left: 44px" OnClick="imgcontacto_Click" />
            <asp:LinkButton ID="lnkcontacto" runat="server" OnClick="lnkcontacto_Click">Nuevo Contacto</asp:LinkButton>
        </div>
        <div class="h10">
        </div>
        <div style="margin-top: 35px">
            <asp:GridView ID="grdOperadora" runat="server" AutoGenerateColumns="False"
                Height="14px" Width="479px" CaptionAlign="Bottom" OnRowCommand="grdOperadora_RowCommand" AllowPaging="True" CellPadding="0" Style="margin-left: 44px; margin-top: 28px;" OnPageIndexChanging="grdOperadora_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Operadora")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Operadora")%>'
                                OnClientClick='return confirm("Esta seguro que desea inactivar el registro")' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="CExt_Nombre" runat="server" Text='<%#Eval("Ope_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                            <asp:Label ID="CExt_Direccion" runat="server" Text='<%#Eval("Ope_Direccion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Creacion">
                        <ItemTemplate>
                            <asp:Label ID="CExt_FechaCreacion" runat="server" Text='<%#Eval("Ope_FechaCreacion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </div>
</asp:Content>
