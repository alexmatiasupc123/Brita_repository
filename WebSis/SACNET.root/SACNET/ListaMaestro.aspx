<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"  CodeFile="ListaMaestro.aspx.cs" Inherits="ListaTablasMaestro" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"   TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Tablas Maestras"></asp:Literal>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 850px;">
                <div class="panelBotones">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <br />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>
                            <asp:Label ID="Label3" runat="server" Text="Leyenda"></asp:Label></legend>
                            <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Editar"></asp:Label>
                                </td><td></td>
                                <td>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Eliminar"></asp:Label>
                                </td><td></td>
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Ver"></asp:Label>
                                </td><td></td>
                                <td>
                                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Table.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Ver Registros"></asp:Label>
                                </td>
                             </tr>
                             </table></fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 820px">
                        <legend>
                            <asp:Label ID="Label6" runat="server" Text="Buscar Por:"></asp:Label>
                        </legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <asp:RadioButtonList ID="RadioButtonBuscar" runat="server" Width="300px" 
                                        RepeatDirection="Horizontal">
                                        <asp:ListItem Selected="True">Mostrar Todos</asp:ListItem><asp:ListItem>Código</asp:ListItem><asp:ListItem>Nombre</asp:ListItem></asp:RadioButtonList></td><td>
                                    &nbsp;</td>
                                <td  style="width: 10px">
                                    <asp:TextBox ID="txtBuscar" runat="server" MaxLength="50" Width="213px" />
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td style="width: 250px; text-align:right">
                                    <asp:Label ID="tsNumeroRegistros" runat="server" Text="Nº Registros:"></asp:Label>
                                </td>
                             </tr>
                           
                         </table></fieldset>
                    <br />
                </div>
                <div class="panelGria">
                    <asp:GridView ID="gvTablasMaestras" runat="server" AutoGenerateColumns="false"
                        DataKeyNames="CodTabla,Nivel" Width="850px" 
                        OnRowCommand="gvTablasMaestras_RowCommand" Height="16px" 
                        style="margin-bottom: 0px" PageSize='<%# Util.ObtenerPaginacion() %>' 
                        onpageindexchanging="gvTablasMaestras_PageIndexChanging" 
                        EmptyDataText="No se encontraron registros de tablas maestras.">
                        <Columns>
                            <asp:BoundField DataField="CodTabla" HeaderText="CÓDIGO TABLA" 
                                ItemStyle-Width="85px" >
                                <ItemStyle Width="85px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nivel" HeaderText="NIVEL" ItemStyle-Width="55px">
                                <ItemStyle Width="55px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LongNivel" HeaderText="LONGITUD X NIVEL" 
                                ItemStyle-Width="50px">
                                <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" 
                                ItemStyle-Width="120px">
                                <ItemStyle Width="120px"  />
                            </asp:BoundField>    
                            <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCIÓN"  Visible="false"
                                ItemStyle-Width="120px">
                                <ItemStyle Width="120px" />
                            </asp:BoundField>    
                            <asp:TemplateField HeaderText="ACTIVO"  HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                     <%# Util.PintarEstado(Eval("CodTabla").ToString(), Convert.ToBoolean(Eval("Activo")))%>
                                </ItemTemplate>
                                    <HeaderStyle Width="40px" />
                             </asp:TemplateField>
                            <asp:BoundField DataField="SegFechaModificacion" HeaderText="ULTIMA EDICIÓN" 
                                ItemStyle-Width="130px" >
                                <ItemStyle Width="130px" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("CodTabla")+"&"+ Eval("Nivel") %>'
                                        CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver registro de la tabla" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("CodTabla")+"&"+ Eval("Nivel") %>'
                                        CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" ToolTip="Editar registro de la tabla"/>
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("CodTabla") %>'
                                        CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" ToolTip="Eliminar registro de la tabla" />
                                    <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                        ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True" TargetControlID="btnEliminar">
                                    </cc1:ConfirmButtonExtender>
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnDetalle" runat="server" CommandArgument='<%# Eval("CodTabla")+"&"+ Eval("Nivel") %>'
                                        CommandName="VerDetalle" ImageUrl="~/Comun/Imagenes/Icons/table.png" ToolTip="Registros de la tabla" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
