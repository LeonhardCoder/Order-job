<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="ProvinciasWeb.aspx.cs" Inherits="ArtekWeb.App_Start.ProvinciasWeb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 33px;
            width: 654px;
            margin-top: 18px;
        }

        .contenido {
            width: 880px;
            height: 484px;
        }

        .divfloat {
            float: left;
            height: 480px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 730px;
        }

        .divfloatver {
            float: left;
            height: 338px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 487px;
        }

        .conten {
            width: 657px;
            height: 72px;
            margin-left: 43px;
            margin-top: 10px;
            margin-bottom: 5px;
        }

        .botones {
            width: 357px;
            height: 33px;
            margin-left: 61px;
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
        <div class="divfloat">
            <div class="cleaner">
                <asp:Label ID="lblmensaje" runat="server" Text=" "></asp:Label>
                <asp:LinkButton ID="lnkregresar" runat="server" OnClick="lnkregresar_Click">Regresar</asp:LinkButton>
            </div>
            <div class="conten">
                <asp:Label ID="lbprovincia" runat="server" Style="margin-left: 14px; width: 79px;" Height="25px" class="col-sm-10 control-label">Nombre: </asp:Label>
                <asp:TextBox ID="txtprovincia" runat="server" Width="200px" Height="24px" class="form-control"></asp:TextBox>
                <div class="botones">
                    <asp:Button ID="btnprovincia" runat="server" Height="30px" OnClick="btnprovincia_Click" Style="margin-left: 51px" Text="Guardar" Width="125px" />
                    <asp:Button ID="btnActualizar" runat="server" Height="30px" Text="Actualizar" Width="125px" Enabled="false" />
                </div>
                <br />
            </div>

            <div style="height: 327px; width: 724px; margin-top: 20px;">
                <div class="cleaner">
                    <asp:Label ID="Label1" runat="server" Text="Label" class="col-sm-2 control-label">Buscar: </asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control col-sm-1" Height="25px" Width="250px"></asp:TextBox>
                    <asp:Image ID="imgbuscar" runat="server" ImageUrl="~/Images/buscar.jpg" Height="32px" Width="32px" />
                </div>

                <asp:GridView ID="grdprovincia" runat="server" AutoGenerateColumns="False"
                    Height="16px" Width="479px" CaptionAlign="Bottom" OnRowCommand="grdProvincia_RowCommand" Style="margin-left: 44px; margin-top: 26px;" PageSize="6" AllowPaging="True" CellPadding="0" CellSpacing="-1" OnPageIndexChanging="grdProvincia_PageIndexChanging">
                    <Columns>
                        <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                    CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Provincia")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Provincia")%>' 
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                        <asp:TemplateField HeaderText="Provincia">
                            <ItemTemplate>
                                <asp:Label ID="Prov_Nombre" runat="server" Text='<%#Eval("Prov_Nombre")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Pais">
                            <ItemTemplate>
                                <asp:Label ID="Pai_Nombre" runat="server" Text='<%#Eval("Pais.Pai_Nombre")%>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>

            </div>
            <asp:Label ID="lblcodigop" runat="server" Text=""></asp:Label>
            <asp:Label ID="lblpais" runat="server" Text="1" Visible="false"></asp:Label>
        </div>
    </div>

</asp:Content>
