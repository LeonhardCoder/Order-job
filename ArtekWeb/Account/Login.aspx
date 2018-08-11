<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ArtekWeb.Account.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .cleaner { clear: both }
    .h10 { height: 10px; width: 257px; }
    .h20 { height:34px; 
width: 866px;
        margin-left: 33px;
    }
    .contenido{ width: 1075px;
        height: 400px;
    }
    .conten{ width: 300px;
        height: 30px;
            margin-left: 15px;
            margin-top: 10px;
        }
    .login1
        {
            width: 233px;
        }
    #login1 {
        width: 435px;
        height: 222px;
            margin-left: 553px;
        }
</style>
    <link href="../App_Themes/stylesheet.css" rel="stylesheet" />
    <script src="../Scripts/js/materialize.min.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="contenido">
        <div class="cleaner"> </div>
        <div class="h20">Ingrese al Sistema</div>
        <div id="login1">
            <div class="conten">
                 <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
            </div>
                <div class="conten">
                    <asp:Label ID="lblusername" runat="server" Text="Usuario"></asp:Label>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="txtusername" runat="server" Text="" placeholder="Username" Width="148px"
                        MaxLength="20"></asp:TextBox>
            </div>
            <div class="conten">
                    <asp:Label ID="lblpassword" runat="server" Text="Password"></asp:Label>
                    &nbsp;
                    <asp:TextBox ID="txtpassword" runat="server" placeholder="Password" Width="150px"
                        TextMode="Password" MaxLength="8" OnTextChanged="btnIngresar_Click"></asp:TextBox>
            </div>
                <div class="conten">
                    <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" Font-Size="Smaller" ForeColor="Black">
                    </asp:Button>
                </div>
            </div>

    </div>
</asp:Content>
