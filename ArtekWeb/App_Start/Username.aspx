<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true"
    CodeBehind="Username.aspx.cs" Inherits="ArtekWeb.App_Start.Username" EnableEventValidation="false" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 91px;
            width: 457px;
            margin-left: 28px;
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
            height: 53px;
            margin-left: 22px;
            margin-top: 18px;
        }

        .botones {
            width: 578px;
            height: 40px;
            margin-left: 50px;
            margin-top: 48px;
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
        <div>

            <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>

            <asp:Label ID="lblcodigo" runat="server" Text=""></asp:Label>

        </div>
        <div class="conten" style="font-weight: bold; color: #003300">
            <asp:Label ID="lbluser" runat="server" Width="95px">Usuario: </asp:Label>
            <asp:TextBox ID="txtuser" class="form-control" placeholder="Username" runat="server" Width="245px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvuser" runat="server" ControlToValidate="txtuser"
                EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="rgeuser" runat="server"
                ControlToValidate="txtuser"
                EnableTheming="False" ErrorMessage="minimo 12 caracteres" Font-Names="Tahoma"
                Font-Size="8pt" SetFocusOnError="true" ValidationExpression="^[\w]{12,15}$" ValidationGroup="Group1">
            </asp:RegularExpressionValidator>
        </div>
        <div class="conten" style="font-weight: bold; color: #003300">
            <form method="post" id="passwordForm">
                <asp:Label ID="lblpass" runat="server" Width="95px">Password: </asp:Label>
                <input type="password" class="form-control" name="password1" id="password1" placeholder="New Password" autocomplete="off" />
        </div>
        <div class="cleaner">
            <div class="col-sm-6">
                <span id="8char" class="glyphicon glyphicon-remove" style="color: #FF0004;"></span>8 Characters Long<br />
                <span id="ucase" class="glyphicon glyphicon-remove" style="color: #FF0004;"></span>One Uppercase Letter<br />
                <span id="lcase" class="glyphicon glyphicon-remove" style="color: #FF0004;"></span>One Lowercase Letter<br />
                <span id="num" class="glyphicon glyphicon-remove" style="color: #FF0004;"></span>One Number
            </div>
        </div>
        </form>
            <div class="conten" style="font-weight: bold; color: #003300">
                <asp:Label ID="Label1" runat="server" Width="168px">Confirmar Password: </asp:Label>
                <asp:TextBox ID="txtpass" class="form-control" placeholder="Confirmar Password" runat="server" Width="245px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtpass"
                    EnableTheming="False" ErrorMessage="*" Font-Names="Tahoma" Font-Size="Smaller"
                    ValidationGroup="Group1" ForeColor="#FF3300">* Completa este dato</asp:RequiredFieldValidator>
            </div>
        <div class="botones">
            <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 131px" Text="Guardar" Width="158px" OnClick="btnguardar_Click" />
        </div>
        <script src="../Scripts/js/login.js"></script>
    </div>
</asp:Content>
