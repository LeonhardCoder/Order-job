<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ArtekWeb.App_Start.Tecnico.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        body
        {
            margin: 20pt !important;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function ChangeIFrameLocation(loc) {
            document.getElementById('I1').src = loc;
        }
        function MyVoid() {
            return;
        }
 </script> 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:LoginName ID="LoginName1" runat="server" Font-Bold="true" />
            <asp:LoginStatus ID="LoginStatus1" runat="server" CssClass="btn btn-warning" />
    <div class="container">  
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <div style="height: 622px; width:1023px; margin-top: 0px">
        <iframe frameborder="0" name="I1" id="I1" scrolling="auto" 
         onload="resizeIF('portal')" style="height: 603px; width: 1000px; margin-left: 18px;"></iframe>
    </div>
</asp:Content>
