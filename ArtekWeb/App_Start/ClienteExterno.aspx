<%@ Page Title="" Language="C#" MasterPageFile="~/Contenido.Master" AutoEventWireup="true" CodeBehind="ClienteExterno.aspx.cs" Inherits="ArtekWeb.App_Start.WebclienteExterno"%>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="ajax" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .cleaner { clear: both; height: 37px; }
    .contenido{ width: 931px; 
height: 403px; }
    .divfloat{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:365px; }
    .divfloatver{ float:left; height:338px; margin:0 0 0 26px; padding:0px 3px 0px 0px; width:487px; }
    .conten{ width: 342px; 
height: 55px; 
margin-left: 3px; margin-top: 10px; }
    .botones{ width: 625px; 
height: 40px; margin-left: 11px;
            margin-top: 20px;
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
    <ajax:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajax:ToolkitScriptManager>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
     <div class="contenido">
        <div class="divfloat">
            <div class="cleaner"> 
                <asp:ImageButton ID="ImageButton1" runat="server" Height="32px" ImageUrl="~/Images/agregar.png" OnClick="ImageButton1_Click" Width="32px" />
                <asp:LinkButton ID="lnkcliente" runat="server" OnClick="lnkcliente_Click">Agregar Contacto</asp:LinkButton>
            </div>
            <div style="height: 46px">
                <asp:Label ID="lblmensaje" runat="server" Text="" Visible="false"></asp:Label>
                <asp:Label ID="lblmen" runat="server" Text=""></asp:Label>
            </div>
            
            <div class="conten">
                <asp:Label ID="lblnombreCli" runat="server" Width="95px" class="label" ForeColor="Black">Nombre: </asp:Label>
                <asp:TextBox ID="txtnombreCli" runat="server" Width="245px" class="form-control" placeholder="Ingrese nuevo cliente externo"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbldireccion" runat="server" Width="95px" class="label" ForeColor="Black">Direccion: </asp:Label>
                <asp:TextBox ID="txtdireccion" runat="server" Width="245px" class="form-control" placeholder="Ingrese dirección"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lbltelefono" runat="server" Width="95px" class="label" ForeColor="Black">Telefono: </asp:Label>
                <asp:TextBox ID="txttelefono" runat="server" Width="245px" class="form-control" placeholder="0999999999 ó (02) 222 2222"></asp:TextBox><br/>
            </div>
            <div class="conten">
                <asp:Label ID="lblfechacreacion" runat="server" Width="108px" Height="20px" class="label" style="margin-left: 0px" ForeColor="Black">Fecha Creacion: </asp:Label>
                <asp:TextBox ID="txtfechacreacion" runat="server" placeholder="dd/mm/yyyy" Width="245px" style="margin-left: 4px" class="form-control"></asp:TextBox>
                <ajax:CalendarExtender ID="txtfechacreacion_CalendarExtender" runat="server" Enabled="True" 
                    TargetControlID="txtfechacreacion" Format="dd/MM/yyyy">
                </ajax:CalendarExtender>
                <br/>
            </div>
            <div class="botones">
                <asp:Button ID="btnguardar" runat="server" Height="34px" style="margin-left: 7px" Text="Guardar" Width="110px" OnClick="btnguardar_Click" />
                <asp:Button ID="btnactualizar" runat="server" Text="Actualizar" Width="110px" Height="34px" Enabled="false" OnClick="btnactualizar_Click" />
                <asp:Button ID="btnregresar" runat="server" Text="Regresar" Width="110px" Height="34px" OnClick="btnregresar_Click" /> 
            </div>
        </div>
        <div class="divfloatver">
            <div class="cleaner"> </div>
            <asp:GridView ID="grdClienteExterno" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-bordered table-list"
                 Height="14px" Width="479px" CaptionAlign="Bottom" OnRowCommand="grdClienteExterno_RowCommand" AllowPaging="True" CellPadding="0" PageSize="5" OnPageIndexChanging="grdClienteExterno_PageIndexChanging">
                <Columns>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                        <asp:ImageButton ID="ImgEditar" runat="server" ImageUrl="~/Images/editar.png" 
                        CausesValidation="false" CommandName="edit" CommandArgument='<%#Eval("Id_ClienteExterno")%>'  />
                    </ItemTemplate> 
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText=" " ItemStyle-Width="17" HeaderStyle-Width="17">
                        <ItemTemplate>
                            <asp:ImageButton ID="ImgEliminar" runat="server" ImageUrl="~/Images/eliminar.png"
                                CausesValidation="false" CommandName="eliminar" CommandArgument='<%#Eval("Id_ClienteExterno")%>' 
                                OnClientClick='return confirm("Esta seguro que desea eliminar el registro")'/>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Nombre">
                        <ItemTemplate>
                        <asp:Label ID="CExt_Nombre" runat="server" Text='<%#Eval("CExt_Nombre")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Direccion">
                        <ItemTemplate>
                        <asp:Label ID="CExt_Direccion" runat="server" Text='<%#Eval("CExt_Direccion")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Telefono">
                        <ItemTemplate>
                        <asp:Label ID="CExt_Telefono" runat="server" Text='<%#Eval("CExt_Telefono")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Fecha Creacion">
                        <ItemTemplate>
                        <asp:Label ID="CExt_FechaCreacion" runat="server" Text='<%#Eval("CExt_FechaCreacion")%>' />
                    </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
         <asp:Label ID="lblcodigo" runat="server" Text="" Visible="true"></asp:Label>
    </div>
</asp:Content>
