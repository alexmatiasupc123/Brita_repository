<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="SegListaUsuarios.aspx.cs" Inherits="Mantenimientos_SegListaUsuarios" %>
    <%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cphTitulo">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 800px;">
        <asp:UpdatePanel ID="udpListaUsuarios" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panelBotones">
                    <asp:Label ID="lblConfirmacion" runat="server" Visible="False"></asp:Label>
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <br />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Comun/Imagenes/Icons/AsignaRol.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblAsignarRol" runat="server" Text="Asignar roles"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 770px">
                        <legend>Filtros</legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Código/Login:"></asp:Label>
                                    &nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtSeekLogin" runat="server" Width="168px" MaxLength="20" />
                                </td>
                                <td style="width: 15px;">
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Nombres:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSeekNombres" runat="server" Width="168px" MaxLength="40" />
                                </td>
                                <td style="width: 15px;">
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Apellidos:"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:TextBox ID="txtSeekApellidos" runat="server" Width="167px" 
                                        MaxLength="40" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                        DataKeyNames="LoginUsuario" Width="800px" OnRowCommand="gvUsuarios_RowCommand"
                        EmptyDataText="No existen usuarios registrados." OnRowDataBound="gvUsuarios_RowDataBound"
                        PageSize='<%# Util.ObtenerPaginacion() %>' AllowPaging="True" 
                        onpageindexchanging="gvUsuarios_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="LoginUsuario" HeaderText="CÓDIGO">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="ApellidosyNombres" HeaderText="APELLIDOS y NOMBRES">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnAsignaRol" runat="server" ToolTip='<%# lblAsignarRol.Text %>'
                                        CommandArgument='<%# Eval("LoginUsuario") %>' CommandName="Asignar" ImageUrl="~/Comun/Imagenes/Icons/AsignaRol.png"
                                        Width="20px" Height="20px" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                          
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="udpListaUsuarios" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
