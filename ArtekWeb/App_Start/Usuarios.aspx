<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true"
    CodeBehind="Usuarios.aspx.cs" Inherits="ArtekWeb.App_Start.Usuarios" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
        }

        .h10 {
            height: 10px;
            width: 257px;
        }

        .h20 {
            height: 34px;
            width: 866px;
            margin-left: 33px;
        }

        .contenido {
            width: 897px;
            height: 484px;
        }

        .contpanel {
            width: 465px;
            height: 451px;
            margin-left: 25px;
        }

        .divfloat {
            float: left;
            height: 407px;
            margin: 0 0 0 44px;
            padding: 0px 3px 0px 0px;
            width: 363px;
        }

        .conten {
            width: 437px;
            height: 49px;
            margin-left: 3px;
            margin-top: 18px;
        }

        .botones {
            width: 720px;
            height: 40px;
            margin-left: 50px;
            margin-top: 54px;
        }
    </style>
    <link href="../Scripts/bootstrap-css.css" rel="stylesheet" id="bootstrap-css" />
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
    <script src="//netdna.bootstrapcdn.com/bootstrap/3.1.0/js/bootstrap.min.js"></script>
    <script src="//code.jquery.com/jquery-1.11.1.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server"></cc1:ToolkitScriptManager>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div class="contenido">
        <div class="cleaner h20">
            <asp:ImageButton ID="ImageButton1" runat="server" Height="35px" ImageUrl="~/Images/contraseña.jpg" Width="35px" OnClick="ImageButton1_Click" />
            <asp:LinkButton ID="lnkcontraseña" runat="server" OnClick="LinkButton1_Click" 
                CommandName="clave" CommandArgument='<%#Eval("Id_Usuario")%>' OnCommand="lnkcontraseña_Command">Crear Contraseña</asp:LinkButton>
        </div>
        <asp:Label ID="lblmensaje" runat="server" Text="" Visible="false"></asp:Label>
        <div class="divfloat">
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblcedula" runat="server" Width="95px">Cedula: </asp:Label>
                <asp:TextBox ID="txtcedula" class="form-control" placeholder="9999999999" runat="server" Width="245px"></asp:TextBox>
                <asp:Label ID="lblcedul" runat="server" Text="Label" Font-Size="Smaller"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvcedula" runat="server" ControlToValidate="txtcedula"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="Filteredtextboxcedula" runat="server"
                    TargetControlID="txtcedula" ValidChars="1234567890" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblapellido" runat="server" Width="95px">Apellidos: </asp:Label>
                <asp:TextBox ID="txtapellido" class="form-control" placeholder="Ingrese apellidos completos" runat="server" Width="245px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvapellido" runat="server" ControlToValidate="txtapellido"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblnombres" runat="server" Width="95px">Nombres: </asp:Label>
                <asp:TextBox ID="txtnombres" class="form-control" placeholder="Ingrese nombres completos" runat="server" Width="245px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvnombres" runat="server" ControlToValidate="txtnombres"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="8"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblcorreo" runat="server" Width="95px">E-mail: </asp:Label>
                <asp:TextBox ID="txtemail" class="form-control" placeholder="example@gmail.com" runat="server" Width="245px"></asp:TextBox>
                <asp:Label ID="lblmail" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                <asp:RequiredFieldValidator ID="rfvemail" runat="server" ControlToValidate="txtemail"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtemail"
                EnableTheming="False" ErrorMessage="Correo Electronico no valido" Font-Names="Tahoma"
                Font-Size="8pt" SetFocusOnError="true" ValidationExpression=".*@.*\.*" ValidationGroup="Group1"
                ForeColor="#CC0000">
            </asp:RegularExpressionValidator>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lbltelefono" runat="server" Width="95px">Telefono: </asp:Label>
                <asp:TextBox ID="txtTelefono" class="form-control" placeholder="0999999999 ó (02) 222 2222" runat="server" Width="245px"></asp:TextBox>
                <asp:Label ID="lbltelf" runat="server" Text=""></asp:Label>
                <asp:RequiredFieldValidator ID="rfvtelefono" runat="server" ControlToValidate="txtTelefono"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
                <cc1:FilteredTextBoxExtender ID="txttelefono_FilteredTextBoxExtender" runat="server"
                    TargetControlID="txttelefono" ValidChars="1234567890" FilterType="Numbers">
                </cc1:FilteredTextBoxExtender>
            </div>
        </div>
        <div class="divfloat">

            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lbldireccion" runat="server" Width="95px">Direccion: </asp:Label>
                <asp:TextBox ID="txtdireccion" class="form-control" placeholder="Ingrese dirección" runat="server" Width="245px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvdireccion" runat="server" ControlToValidate="txtdireccion"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblperfil" runat="server" Width="95px">Perfil: </asp:Label>
                <asp:DropDownList ID="ddlperfil" class="dropdown-header divider form-control" runat="server" Width="270px" Height="16px">
                </asp:DropDownList>
            </div>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="lblfecha" runat="server" Width="115px">Fecha Creacion: </asp:Label>
                <asp:TextBox ID="txtfecha" class="form-control" placeholder="dd/mm/yyyy" runat="server" Width="245px"></asp:TextBox>
                <cc1:CalendarExtender ID="txtfecha_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtfecha"
                    Format="dd/MM/yyyy" DaysModeTitleFormat="dd/MM/yyyy">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfecha"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            </div>

        </div>
        <div class="botones">
            <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 131px" Text="Guardar" Width="158px" OnClick="btnguardar_Click" />
            <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="158px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
            <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="158px" Height="34px" OnClick="btnregresar_Click"  />
        </div>
        <asp:TextBox ID="txtcodigo" runat="server" Visible="false"></asp:TextBox>
    </div>


</asp:Content>
