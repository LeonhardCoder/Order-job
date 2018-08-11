<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="Perfilesweb.aspx.cs" Inherits="ArtekWeb.App_Start.Perfilesweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .cleaner {
            clear: both;
            height: 37px;
        }

        .contenido {
            width: 1017px;
            height: 484px;
        }

        .divfloat {
            float: left;
            height: 223px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 816px;
        }

        .divfloat1 {
            float: left;
            height: 256px;
            margin: 52 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 816px;
        }

        .divfloatver {
            float: left;
            height: 338px;
            margin: 0 0 0 26px;
            padding: 0px 3px 0px 0px;
            width: 397px;
        }

        .conten {
            width: 414px;
            height: 56px;
            margin-left: 43px;
            margin-top: 10px;
        }

        .botones {
            width: 687px;
            height: 47px;
            margin-left: 35px;
            margin-top: 38px;
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
                <asp:Label ID="lblmensaje" runat="server" Text=""></asp:Label>
                <asp:Label ID="lblcodigo" runat="server" Text="" Visible="true"></asp:Label>
            </div>
            <div class="conten">
                <asp:Label ID="lblnombre" runat="server" Width="95px" class="label" ForeColor="Black">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreper" runat="server" class="form-control" placeholder="Ingrese nuevo perfil" Width="245px"></asp:TextBox><br />
            </div>
            <div class="conten">
                <asp:Label ID="lbldescripcion" runat="server" Width="95px" class="label" ForeColor="Black">Descripción: </asp:Label>
                <asp:TextBox ID="txtdescripcion" runat="server" class="form-control" Width="245px" placeholder="Describa el nuevo perfil"></asp:TextBox>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" Style="margin-left: 9px" Text="Guardar" Width="125px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="125px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="125px" Height="34px" OnClick="btnregresar_Click" />
            </div>
        </div>
        <div class="divfloat1">
            <div class="cleaner">
            </div>
            <asp:GridView ID="grdPerfil" runat="server" AutoGenerateColumns="False"
                Height="14px" Width="479px" CaptionAlign="Bottom" AllowPaging="True" CellPadding="0" PageSize="5" Style="margin-left: 66px" OnRowCommand="grdPerfil_RowCommand" OnPageIndexChanging="grdPerfil_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png"
                                CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_Perfil")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_Perfil")%>'
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                            <asp:Label ID="Per_Nombre" runat="server" Text='<%#Eval("Per_Nombre")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Descripción">
                        <ItemTemplate>
                            <asp:Label ID="Per_Descripcion" runat="server" Text='<%#Eval("Per_Descripcion")%>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
        <asp:Label ID="lblcodio" runat="server" Text=""></asp:Label>
    </div>
</asp:Content>
