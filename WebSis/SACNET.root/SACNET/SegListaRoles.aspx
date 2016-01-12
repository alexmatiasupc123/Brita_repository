<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="SegListaRoles.aspx.cs" Inherits="Mantenimientos_SegListaRoles" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cphTitulo">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div style="width:900px">
    <asp:UpdatePanel ID="udpTitular" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           
                <div class="panelBotones">
                    <asp:Label ID="lblConfirmacion" runat="server" Visible="False"></asp:Label>
                    <asp:Panel ID="pnBotones" runat="server">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    </asp:Panel>                    
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <br />
                </div>
                 <div class="panelleyenda" style="width:350px">
                    <fieldset>
                        <legend>
                            Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/edit.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Editar"></asp:Label>
                                </td>
                                <td>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                        Width="16px" Height="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Eliminar"></asp:Label>
                                </td>
                                <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Roles.png"
                                        Width="20px" Height="20px" />
                                </td>
                                <td>
                                    <asp:Label ID="lblAsignar" runat="server" Text="Asignar opciones"></asp:Label>
                                </td>
                           
                                <td>
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Ver"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
            <fieldset style="width:870px">
                        <legend>
                            Filtros</legend>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Nombre:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="txtSeekNombre" runat="server" Width="250px" MaxLength="15" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Descripción:"></asp:Label>&nbsp;
                            </td>
                            <td>
                                <asp:TextBox ID="txtSeekDescripcion" runat="server" Width="250px" 
                                    MaxLength="15" />
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                    
                </div>
               
                <div class="panelGria">
                    <asp:GridView ID="gvRoles" runat="server" AutoGenerateColumns="False" BorderWidth="1px"
                        DataKeyNames="CodigoRol" Width="900px" OnRowCommand="gvRoles_RowCommand" EmptyDataText="No existen roles registrados."
                        OnRowDataBound="gvRoles_RowDataBound" 
                        PageSize='<%# Util.ObtenerPaginacion() %>' AllowPaging="True" 
                        onpageindexchanging="gvRoles_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CodigoRol" HeaderText="CÓDIGO">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="NombreRol" HeaderText="NOMBRE">
                                <HeaderStyle Width="100px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="DescripcionRol" HeaderText="DESCRIPCIÓN">
                                <HeaderStyle Width="200px" HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="ULTIMA MODIFICACIÓN" DataField="SegFechaModifica" 
                                DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" ToolTip='<%# Label3.Text %>'
                                        CommandArgument='<%# Eval("CodigoRol") %>' CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnAsignarRoles" runat="server" ToolTip='<%# lblAsignar.Text %>'
                                        CommandArgument='<%# Eval("CodigoRol") %>' CommandName="Asignar" ImageUrl="~/Comun/Imagenes/Icons/Roles.png"
                                        Width="20px" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" ToolTip='<%# Label4.Text %>'
                                        CommandArgument='<%# Eval("CodigoRol") %>' CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnVer" runat="server" ToolTip="Ver"  CommandArgument='<%# Eval("CodigoRol") %>'
                                        CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" Height="16px" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
           
        </ContentTemplate>
    </asp:UpdatePanel>
     </div>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="udpTitular" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
