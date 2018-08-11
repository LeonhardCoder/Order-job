<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="WebClientes.aspx.cs" Inherits="ArtekWeb.App_Start.WebClientes" %>

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
            height: 495px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 713px;
        }

        .conten {
            width: 316px;
            width: 504px;
            height: 49px;
            margin-top: 6px;
        }

        .conten1 {
            width: 316px;
            width: 504px;
            height: 38px;
            margin-top: 6px;
        }

        .botones {
            margin-top: 162px;
        }

        .modalbackgraund {
            background-color: Aqua;
            filter: alpha(opacity=70);
            opacity: 0.2;
            z-index: 1000;
        }
    </style>
    <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <link href="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/css/bootstrap-combined.min.css" rel="stylesheet" id="bootstrap-css">
    <script src="//netdna.bootstrapcdn.com/twitter-bootstrap/2.3.2/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></asp:ToolkitScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contenido">
        <div class="divfloat">
            <div class="cleaner">
            </div>
            <div style="height: 7px">
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblmen" runat="server" Text="" ForeColor="Black"></asp:Label>
            </div>
            <div class="conten1">
                <asp:Label ID="lblbuscarcli" runat="server" class="control-label">Cliente: </asp:Label>

                <div class="input-append">
                    <asp:TextBox type="text" ID="txtclientes" name="" runat="server" Width="200px" Height="30px"></asp:TextBox>
                    <asp:ImageButton ID="imgbuscar" runat="server" ImageUrl="~/Images/buscar.jpg" Width="32px" Height="32px" OnClick="imgbuscar_Click" />
                    <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="buscar"
                        TargetControlID="imgbuscar" Enabled="True" ViewStateMode="Enabled" BackgroundCssClass="modalbackgraund">
                    </asp:ModalPopupExtender>
                </div>
            </div>
            <div class="conten">
                <asp:Label ID="lblprovincia" runat="server" Width="95px" class="control-label" ForeColor="Black">Operadora: </asp:Label>
                <asp:DropDownList ID="ddloperadora" runat="server" Height="30px" class="dropdown-header divider form-control"
                    Width="204px">
                </asp:DropDownList>
            </div>
            <div class="conten">
                <asp:Label ID="lblcliprincipal" runat="server" Width="95px" class="control-label" ForeColor="Black">Cliente Principal: </asp:Label>
                <asp:DropDownList ID="ddlcliprincipal" runat="server" Height="30px" class="dropdown-header divider form-control"
                    Width="204px">
                </asp:DropDownList>
            </div>

            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 76px" Text="Guardar" Width="100px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Height="34px" Width="100px" Enabled="false" OnClick="btnActualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Height="34px" Width="100px" OnClick="btnregresar_Click" />
            </div>
        </div>
        <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
        <asp:Label ID="lblcodcli" runat="server" Text=""></asp:Label>
    </div>
    <div>
        <asp:Panel ID="buscar" runat="server" Width="678px" Height="446px" BackColor="White">
            <div class="divfloatver">
            <div class="cleaner"> </div>
            <asp:GridView ID="grdClientesFinal" runat="server" AutoGenerateColumns="False" Height="14px" Width="479px" CaptionAlign="Bottom" OnRowCommand="grdClientesFinal_RowCommand" AllowPaging="True" CellPadding="0" PageSize="8" OnPageIndexChanging="grdClientesFinal_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                        <asp:LinkButton ID="ImgEditar" runat="server" CommandName="seleccionar" CommandArgument='<%#Eval("Id_ClienteFinal")%>'>Seleccionar </asp:LinkButton>
                    </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                        <asp:Label ID="Cli_Nombre" runat="server" Text='<%#Eval("Cli_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        </asp:Panel>
    </div>
</asp:Content>
