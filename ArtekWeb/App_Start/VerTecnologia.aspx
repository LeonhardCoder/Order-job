<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="VerTecnologia.aspx.cs" Inherits="ArtekWeb.App_Start.VerTecnologia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            margin-left: 41px;
        }
        .divfloatver {
            height: 491px;
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
        <div class="cleaner">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" Width="32px" OnClick="ImageButton1_Click" />
            <asp:LinkButton ID="lnknuevo" runat="server" OnClick="lnknuevo_Click">Nuevo</asp:LinkButton>
        </div>
        <div class="h10">
        </div>
        <div style="width: 760px; margin-left: 38px;">
            <asp:Label ID="lblbuscar" runat="server" Text="Buscar:" class="col-sm-1 control-label"></asp:Label>
            <asp:TextBox ID="txtbuscar" runat="server" class="form-control col-sm-2" Width="250px"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buscar.jpg" Width="28px" Height="28px"/>
            
        </div>
        <asp:GridView ID="grdTecnologia" runat="server" AutoGenerateColumns="False"
            Height="17px" Width="480px" CaptionAlign="Bottom" PageIndex="5" OnRowCommand="grdTecnologia_RowCommand"
            PageSize="5" Style="margin-left: 39px; margin-top: 21px" OnPageIndexChanging="grdTecnologia_PageIndexChanging">
            <Columns>
                <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                    <ItemTemplate>
                        <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                            CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Tecnologia")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Tecnologia")%>' 
                                OnClientClick='return confirm("Esta seguro que desea inactivar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label ID="Tec_Nombre" runat="server" Text='<%#Eval("Tec_Nombre")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Descripcion">
                    <ItemTemplate>
                        <asp:Label ID="Tec_Descripcion" runat="server" Text='<%#Eval("Tec_Descripcion")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Tipo Categoria">
                    <ItemTemplate>
                        <asp:Label ID="Tip_Numero" runat="server" Text='<%#Eval("Tipo_Categoria.Tip_Numero")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Operadora">
                    <ItemTemplate>
                        <asp:Label ID="Ope_Nombre" runat="server" Text='<%#Eval("Operadora.Ope_Nombre")%>' />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
