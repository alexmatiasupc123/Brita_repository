<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaDetalle.aspx.cs" Inherits="ListaDetalle" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Registros Tabla Maestra"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table>
                <tr>
                    <td valign="top" style="width: 200px; background-color: #EBEBEB;">
                        <asp:TreeView ID="TreeView1" runat="server" Width="200px">
                            <ParentNodeStyle Font-Bold="False" />
                            <HoverNodeStyle Font-Underline="True" ForeColor="#6666AA" />
                            <SelectedNodeStyle BackColor="#B5B5B5" Font-Underline="False" HorizontalPadding="0px"
                                VerticalPadding="0px" />
                            <NodeStyle Font-Names="Tahoma" Font-Size="8pt" ForeColor="Black" HorizontalPadding="5px"
                                NodeSpacing="0px" VerticalPadding="1px" />
                        </asp:TreeView>
                    </td>
                    <td valign="top" style="width: 700px;">
                        <asp:Panel ID="pnlPanelGeneral" runat="server">
                            
                            
                        <div class="panelBotones">
                            <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                            <asp:HiddenField ID="HF_Nivel" runat="server" />
                            <asp:HiddenField ID="HF_CodTabla" runat="server" />
                            <br />
                        </div>
                        <div class="panelleyenda">
                           
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label3" runat="server" Text="Leyenda"></asp:Label>
                                </legend>
                                <table>
                                    <tr>
                                        
                                        <td>
                                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label1" runat="server" Text="Ver"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png"
                                                Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label4" runat="server" Text="Editar"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                                Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label5" runat="server" Text="Eliminar"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                </table>
                            </fieldset>
                        </div>
                        <div class="panelBucador">
                            <fieldset style="width: 674px" id="pnlBusca">
                                <legend>
                                    <asp:Label ID="Label6" runat="server" Text="Buscar Por:"></asp:Label>
                                </legend>
                                <table border="0" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td rowspan="3" style="width: 270px">
                                            <asp:RadioButtonList ID="RadioButtonBuscar" runat="server" Width="260px" 
                                                RepeatDirection="Horizontal" AutoPostBack="True" 
                                                onselectedindexchanged="RadioButtonBuscar_SelectedIndexChanged">
                                                <asp:ListItem Selected="True">Mostrar Todos</asp:ListItem>
                                                <asp:ListItem>Código</asp:ListItem>
                                                <asp:ListItem>Nombre</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Label ID="lblNivel1" runat="server" Text="Nivel1:" Visible="False"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlNivel1" runat="server" OnSelectedIndexChanged="ddlNivel1_SelectedIndexChanged"
                                                Visible="False" Width="200px" AutoPostBack="True">
                                            </asp:DropDownList>
                                        </td>
                                        <tr>
                                            <td>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblNivel2" runat="server" Text="Nivel2:" Visible="False"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:DropDownList ID="ddlNivel2" runat="server" OnSelectedIndexChanged="ddlNivel2_SelectedIndexChanged"
                                                    Visible="False" Width="200px" AutoPostBack="True">
                                                </asp:DropDownList>
                                            </td>
                                            <tr>
                                                <td>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblNivel3" runat="server" Text="Nivel3:" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlNivel3" runat="server" OnSelectedIndexChanged="ddlNivel3_SelectedIndexChanged"
                                                        Visible="False" Width="200px" AutoPostBack="True">
                                                    </asp:DropDownList>
                                                </td>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtBuscar" runat="server" MaxLength="50" Width="177px" 
                                                            Visible="False" />
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNivel4" runat="server" Text="Nivel4:" Visible="False"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlNivel4" runat="server" OnSelectedIndexChanged="ddlNivel4_SelectedIndexChanged"
                                                            Visible="False" Width="200px" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </tr>
                                        </tr>
                                    </tr>
                                </table>
                            </fieldset>
                            <br />
                        </div>
                        <div class="panelGria">
                            
                            <asp:GridView ID="gvTablasDetalle" runat="server" AutoGenerateColumns="false" DataKeyNames="CodTabla,Nivel"
                                Width="700px" OnRowCommand="gvTablasDetalle_RowCommand" Height="16px" Style="margin-bottom: 0px"
                                PageSize='<%# Util.ObtenerPaginacion() %>' OnPageIndexChanging="gvTablasDetalle_PageIndexChanging" AllowPaging="True"
                                EmptyDataText="No se encontraron registros de la tabla maestra seleccionada.">
                                <Columns>
                                    <asp:BoundField DataField="CodTabla" HeaderText="CÓDIGO TABLA" ItemStyle-Width="85px"
                                        Visible="false">
                                        <ItemStyle Width="85px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nivel" HeaderText="NIVEL" ItemStyle-Width="55px" Visible="false">
                                        <ItemStyle Width="55px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CodArgu" HeaderText="CÓDIGO ARGUM." ItemStyle-Width="50px">
                                        <ItemStyle Width="50px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Nombre" HeaderText="NOMBRE" />
                                    <asp:BoundField DataField="ValorCadena" HeaderText="VALOR CADENA" Visible="false" />
                                    <asp:BoundField DataField="ValorCadenaCorta" HeaderText="VALOR CADENA CORTA" Visible="false" />
                                    <asp:BoundField DataField="ValorCadenaLarga" HeaderText="VALOR CADENA LARGA" Visible="false" />
                                    <asp:BoundField DataField="ValorDecimal" HeaderText="VALOR DECIMAL" Visible="false" />
                                    <asp:BoundField DataField="ValorEntero" HeaderText="VALOR ENTERO" Visible="false" />
                                    <asp:BoundField DataField="ValorBoolean" HeaderText="VALOR BOOLEAN" Visible="false" />
                                    <asp:TemplateField HeaderText="ACTIVO" HeaderStyle-Width="40px" HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <%# Util.PintarEstado(Eval("CodTabla").ToString(), Convert.ToBoolean(Eval("Activo")))%>
                                        </ItemTemplate>
                                        <HeaderStyle Width="40px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="SegFechaModificacion" HeaderText="ULTIMA EDICIÓN" ItemStyle-Width="130px">
                                        <ItemStyle Width="130px" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("CodTabla")+"&"+Eval("CodArgu")+"&"+ Eval("Nivel") %>'
                                                CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("CodTabla")+"&"+Eval("CodArgu")+"&"+ Eval("Nivel") %>'
                                                CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" ToolTip="Editar" />
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("CodArgu") %>'
                                                CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" ToolTip="Eliminar" />
                                            <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                                ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True" TargetControlID="btnEliminar">
                                            </cc1:ConfirmButtonExtender>
                                        </ItemTemplate>
                                        <HeaderStyle Width="30px" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                       </asp:Panel> 
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
