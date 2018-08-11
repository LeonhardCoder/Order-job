<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Tecnologia.aspx.cs" Inherits="ArtekWeb.App_Start.webTecnologia" %>

<%@ Register Src="../UseControls/UcOperador.ascx" TagName="UcOperador" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 33px;
            font-weight: 700;
            width: 531px;
            margin-left: 35px;
        }

        .contenido {
            height: 417px;
        }

        .divfloat {
            float: left;
            height: 338px;
            margin: 0 0 0 17px;
            padding: 0px 3px 0px 0px;
            width: 574px;
        }

        .divfloatver {
            float: left;
            height: 338px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 569px;
        }

        .conten {
            width: 358px;
            height: 56px;
            margin-left: 3px;
            margin-top: 10px;
        }

        .botones {
            width: 650px;
            height: 40px;
            margin-left: 11px;
            margin-top: 79px;
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
                <asp:Label ID="lblmensaje" runat="server" Text="" Visible="false"></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombre" runat="server" Width="95px" class="label" ForeColor="Black">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombre" runat="server" Width="200px" Style="margin-left: 12px" class="form-control"></asp:TextBox><br />
            </div>
            <div class="conten">
                <asp:Label ID="lbldescripcion" runat="server" Width="95px" class="label" ForeColor="Black">Descripcion: </asp:Label>
                <asp:TextBox ID="txtdescripcion" runat="server" Width="200px" Style="margin-left: 10px" class="form-control"></asp:TextBox><br />
            </div>
            <div class="conten">
                <asp:Label ID="lblcategoria" runat="server" Width="105px" class="label" ForeColor="Black">Tipo Categoria: </asp:Label>
                <asp:DropDownList ID="ddlcategoria" runat="server" Height="17px" Width="178px" class="dropdown-header divider form-control">
                </asp:DropDownList>
                <asp:Label ID="lblcodcat" runat="server" Text=""></asp:Label>
                <br />
            </div>
            <div class="conten">
                <asp:Label ID="lbloperador" runat="server" Width="102px" class="label" ForeColor="Black">Operadora: </asp:Label>
                <uc1:UcOperador ID="UcOperador1" runat="server" />
                <br />
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 9px" Text="Guardar" Width="120px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="120px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="120px" Height="34px" OnClick="btnregresar_Click" />
            </div>
        </div>
        <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
