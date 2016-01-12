<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPopup.master" EnableEventValidation="true"
    AutoEventWireup="true" CodeFile="SegAsignarOpcionesA_Roles.aspx.cs" Inherits="Mantenimientos_SegAsignarOpcionesA_Roles" %>
<%@ MasterType VirtualPath="~/_MasterPopup.master" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px; height: 450px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                        </td>
                    </tr>
                </table>
                <fieldset style="width: 570px">
                    <legend >Datos del Rol</legend>
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td style="width: 75px; text-align: right">
                                <asp:Label ID="Label1" runat="server" Text="Código :"></asp:Label>
                                &nbsp;
                            </td>
                            <td style="width: 100px; text-align: left">
                                <asp:Label ID="txtCodigoRol" runat="server" Font-Bold="True" ></asp:Label>
                            </td>
                            <td style="width: 75px; text-align: right">
                                &nbsp;
                                <asp:Label ID="Label6" runat="server" Text="Nombre :"></asp:Label>
                            </td>
                            <td >
                                &nbsp;
                                <asp:Label ID="txtNombreRol" runat="server" Font-Bold="True" ></asp:Label>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                <asp:Panel ID="pnRegistro" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" width="600px">
                        <tr>
                            <td style="text-align: right; padding-right: 10px">
                                <asp:Label ID="Label5" runat="server" Text="Opción del Sistema :"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 30px" colspan="2">
                                <asp:DropDownList ID="ddlOpcionesDelsistema" runat="server" Width="250px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px">
                                <asp:Label ID="Label3" runat="server" Text="Ver :"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 30px">
                                <asp:CheckBox ID="CheckBox_Ver" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px">
                                <asp:Label ID="Label4" runat="server" Text="Eliminar :"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 30px">
                                <asp:CheckBox ID="CheckBox_Eliminar" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 220px; text-align: right; padding-right: 10px">
                                <asp:Label ID="Label2" runat="server" Text="Editar :"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 30px">
                                <asp:CheckBox ID="CheckBox_Editar" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 220px; text-align: right; padding-right: 10px">
                                <asp:Label ID="Label7" runat="server" Text="Nuevo :"></asp:Label>
                            </td>
                            <td style="text-align: left; height: 30px">
                                <asp:CheckBox ID="CheckBox_Nuevo" runat="server" />
                            </td>
                            <td style="text-align: right; height: 30px">
                                &nbsp;
                            </td>
                            <td style="text-align: right; height: 30px">
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <asp:Panel ID="pnListadoUsuarios" runat="server">
                    <asp:GridView ID="gvOpcionesDelSistema" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        BorderWidth="1px" DataKeyNames="CodigoOpcion" Width="600px" EmptyDataText="No existen opciones del sistema asignados al rol."
                        OnRowDataBound="gvOpcionesDelSistema_RowDataBound" OnRowCommand="gvOpcionesDelSistema_RowCommand"
                        PageSize="10" OnPageIndexChanging="gvOpcionesDelSistema_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CodigoOpcion" HeaderText="CODIGO OPCION" Visible="false">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoOpcionNombre" HeaderText="OPCION" Visible="true">
                                <HeaderStyle Width="150px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="VER" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("CodigoOpcion").ToString(), Convert.ToBoolean(Eval("Flag_Ver")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ELIMINAR" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("CodigoOpcion").ToString(), Convert.ToBoolean(Eval("Flag_Eliminar")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="EDICIONES" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("CodigoOpcion").ToString(), Convert.ToBoolean(Eval("Flag_Editar")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="NUEVO" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("CodigoOpcion").ToString(), Convert.ToBoolean(Eval("Flag_Nuevo")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar" CommandName="Editar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Edit.png" CommandArgument='<%# Eval("CodigoOpcion") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Eliminar" CommandName="Eliminar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Delete.png" CommandArgument='<%# Eval("CodigoOpcion") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
