<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Operadora.aspx.cs" Inherits="ArtekWeb.App_Start.webOperadora" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .cleaner { clear: both; height: 37px; }
    .contenido{ width: 1000px; 
height: 525px; }
    .divfloat{ float:left; height:425px; 
margin:0 0 0 16px; 
padding:0px 3px 0px 0px; width:447px; }
    .divfloatver{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:487px; }
    .conten{ width: 402px; 
height: 55px; 
margin-left: 3px; margin-top: 10px; }
        .botones {
            margin-top: 94px;
        }
    </style>
     <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <link href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.4.0/css/font-awesome.min.css" rel='stylesheet' type='text/css'>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></ajax:ToolkitScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="contenido">
        <div class="divfloat">
            <div class="cleaner"> 
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombreope" runat="server" Width="95px">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreope" runat="server" Width="250px" class="form-control" placeholder="Ingrese nombre operadora"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbldireccion" runat="server" Width="95px">Direccion: </asp:Label>
                <asp:TextBox ID="txtdireccion" runat="server" Width="250px" class="form-control" placeholder="Ingrese dirección"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbltelefono" runat="server" Width="95px">Telefono: </asp:Label>
                <asp:TextBox ID="txttelefono" runat="server" Width="250px" class="form-control" placeholder="Ingrese el telefono"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lblfechacreacion" runat="server" Width="114px">Fecha Creacion: </asp:Label>
                <asp:TextBox ID="txtfechacreacion" runat="server" Width="200px" class="form-control" placeholder="dd/mm/yyyy"></asp:TextBox>
                <ajax:CalendarExtender ID="txtfechacreacion_CalendarExtender" runat="server" Enabled="True" 
                    TargetControlID="txtfechacreacion" Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy" >
                </ajax:CalendarExtender>
                <br/>
            </div>
            
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" style="margin-left: 11px" Text="Guardar" Width="110px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="110px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="110px" Height="34px" OnClick="btnregresar_Click" /> 
            </div>
        </div>
        <div style="height: 429px; width: 501px" class="divfloat">
                <fieldset style="width: 480px; height: 390px; margin-left: 6px; margin-top: 11px;">
              
            <legend>Seleccionar Imagen</legend>
            <asp:Label ID="lblseleccion" runat="server" Font-Size="12px">Seleccione Archivo:</asp:Label>
              <asp:FileUpload ID="FileUpload1" runat="server" class="form-horizontal"
                    onprerender="FileUpload1_PreRender" oninit="FileUpload1_Init" Font-Size="12px" Width="361px" Height="30px" />
                    <div style="margin-top: 13px">
                        <asp:Button ID="btnSubir" runat="server" Text="Subir Archivo" 
                onclick="btnSubir_Click" Height="30px" Width="110px" Font-Size="12px" />
                    </div>
            
            <br /><br />
            <asp:Image ID="imgSubida" runat="server" ImageAlign="AbsMiddle" />
            <br /><br />
            <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
            </fieldset>
            </div>
    </div>
    <div class="cleaner">
             <asp:Label ID="url_imagen" runat="server" Text="" Visible="false"></asp:Label>
             <asp:Label ID="lblvalidaimagen" runat="server" Text="" Visible="false"></asp:Label>
             <asp:Label ID="InformationLabel" runat="server" Text="0" Visible="false"></asp:Label>
             <asp:Label ID="unEncryptedLabel" runat="server" Text="0" Visible="false"></asp:Label>
             <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>
         </div>
</asp:Content>
