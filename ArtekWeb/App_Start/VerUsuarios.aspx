<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="ArtekWeb.App_Start.VerUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 40px;
            margin-left: 30px;
        }

        .h10 {
            height: 25px;
            width: 260px;
        }

        .h20 {
            height: 34px;
            width: 866px;
            margin-left: 33px;
        }

        .contenido {
            width: 910px;
            height: 475px;
        }

        .conten {
            width: 805px;
            height: 30px;
            margin-left: 49px;
            margin-top: 10px;
        }

        .botones {
            width: 800px;
            height: 40px;
            margin-left: 50px;
            margin-top: 10px;
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
        <div class="h10"></div>
        <div class="cleaner">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" Width="32px" OnClick="ImageButton1_Click" />
            <asp:LinkButton ID="lnknuevo" runat="server" OnClick="lnknuevo_Click">Nuevo</asp:LinkButton>
        </div>
        <div class="h10">
        </div>
        <div style="width: 760px">
            <asp:Label ID="lblbuscar" runat="server" Text="Buscar:" class="col-sm-1 control-label"></asp:Label>
            <asp:TextBox ID="txtbuscar" runat="server" class="form-control col-sm-2" Width="250px"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buscar.jpg" Width="28px" Height="28px"/>
            
        </div>
        <div>
            <asp:GridView ID="grdUsuario" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-list"
                Height="115px" Width="794px" OnRowCommand="grdUsuario_RowCommand" GridLines="None" OnPageIndexChanging="grdUsuario_PageIndexChanging">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Usuario")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Usuario")%>' 
                                OnClientClick='return confirm("Esta seguro que desea inactivar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cedula">
                        <ItemTemplate>
                            <asp:Label ID="Usu_Cedula" runat="server" Text='<%#Eval("Usu_Cedula")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Apellidos">
                        <ItemTemplate>
                            <asp:Label ID="Usu_Apellidos" runat="server" Text='<%#Eval("Usu_Apellido")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombres">
                        <ItemTemplate>
                            <asp:Label ID="Usu_Nombre" runat="server" Text='<%#Eval("Usu_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Creacion">
                        <ItemTemplate>
                            <asp:Label ID="Usu_FechaCreacion" runat="server" Text='<%#Eval("Usu_FechaCreacion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Perfil">
                        <ItemTemplate>
                            <asp:Label ID="Perfil" runat="server" Text='<%#Eval("Perfil.Per_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Estado">
                        <ItemTemplate>
                            <asp:Label ID="Estado" runat="server" Text='<%#Eval("Usu_Estado")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
