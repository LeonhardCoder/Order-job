<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="VerClientes.aspx.cs" Inherits="ArtekWeb.App_Start.VerClientes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
      <style type="text/css">
          .cleaner {
            clear: both;
            height: 40px;
            margin-left: 30px;
              width: 225px;
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
            height: 528px;
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
        .divfloat {
            float: left;
            height: 36px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 188px;
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
        <div class="divfloat">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" 
                Width="32px" OnClick="ImageButton1_Click1" />
            <asp:LinkButton ID="lnknuevoC" runat="server" OnClick="lnknuevoC_Click" >Nuevo Cliente Final</asp:LinkButton>
        </div>
        <div class="divfloat">
            <asp:ImageButton ID="ImageButton2" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" 
                Width="32px" OnClick="ImageButton2_Click" />
            <asp:LinkButton ID="lnknuevoO" runat="server" OnClick="lnknuevoO_Click" >Nueva Cliente Principal</asp:LinkButton>
        </div>
        <div class="h10">
        </div>
        <div style="width: 833px">
            <asp:Label ID="lblbuscar" runat="server" Text="Buscar:" class="col-sm-1 control-label"></asp:Label>
            <asp:TextBox ID="txtbuscar" runat="server" class="form-control col-sm-2" Width="250px"></asp:TextBox>
            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/buscar.jpg" Width="28px" Height="28px"/>
            
        </div>
        <div>
            <asp:GridView ID="grdVerClientes" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered table-list"
                Height="115px" Width="794px" GridLines="None" OnPageIndexChanging="grdVerClientes_PageIndexChanging" OnRowCommand="grdVerClientes_RowCommand" >
                <Columns>
                    <asp:TemplateField ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkseleccionar" runat="server" CommandName="seleccion" CommandArgument='<%#Eval("Id_ClienteOperadora")%>'>Seleccionar</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Clientes">
                        <ItemTemplate>
                            <asp:Label ID="Cli_Nombre" runat="server" Text='<%#Eval("ClienteFinal.Cli_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Operadora">
                        <ItemTemplate>
                            <asp:Label ID="Ope_Nombre" runat="server" Text='<%#Eval("Operadora.Ope_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Cliente Principal">
                        <ItemTemplate>
                            <asp:Label ID="CExt_Nombre" runat="server" Text='<%#Eval("ClienteExterno.CExt_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Detalle">
                        <ItemTemplate>
                            <asp:LinkButton ID="lnkver" runat="server" CommandName="ver" CommandArgument='<%#Eval("Id_ClienteFinal")%>'>Ver</asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>
