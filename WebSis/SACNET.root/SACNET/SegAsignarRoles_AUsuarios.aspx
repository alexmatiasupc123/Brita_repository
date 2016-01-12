<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPopup.master" EnableEventValidation="true"
    AutoEventWireup="true" CodeFile="SegAsignarRoles_AUsuarios.aspx.cs" Inherits="Mantenimientos_SegAsignarRoles_AUsuarios" %>
<%@ MasterType VirtualPath="~/_MasterPopup.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 570px">
                        <legend>Datos del Usuario </legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="4">
                                    <asp:Label ID="Label4" runat="server" Visible="false" Text="Mostrar Todos :"></asp:Label>
                                    <asp:CheckBox ID="chkSeekTodos" Visible="false" runat="server" AutoPostBack="True"
                                        OnCheckedChanged="chkSeekTodos_CheckedChanged"></asp:CheckBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Código /Login :"></asp:Label>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="txtCodigoRol" runat="server" Font-Bold="True" Width="150px"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Nombre Usuario :"></asp:Label>&nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="txtNombreRol" runat="server" Font-Bold="True" Width="190px"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria" >
                <asp:Panel ID="pnRegistro" runat="server">
                    <fieldset style="width: 570px">
                        <legend>Registro de Usuario</legend>
                        <table border="0" cellpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    Roles de Usuario:&nbsp;
                                </td>
                                <td colspan="3">
                                    <asp:DropDownList ID="ddlRolesDeUsuario" runat="server" Width="250px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Estado :&nbsp;
                                </td>
                                <td>
                                    <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="200px">
                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </fieldset></asp:Panel>
                </div>
                <div class="panelGria" >
                <asp:Panel ID="pnListadoUsuarios" runat="server">
                    <asp:GridView ID="gvUsuariosRoles" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                        BorderWidth="1px" DataKeyNames="CodigoRol,CodigoUsuario" Width="600px" EmptyDataText="No existen roles asignados al actual usuario."
                        OnRowDataBound="gvUsuariosRoles_RowDataBound" OnRowCommand="gvUsuariosRoles_RowCommand"
                        PageSize="8" OnPageIndexChanging="gvUsuariosRoles_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="CodigoRol" HeaderText="ROL" Visible="false">
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoUsuario" HeaderText="USUARIO" Visible="false">
                                <HeaderStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoUsuarioNombre" HeaderText="USUARIO" Visible="true">
                                <HeaderStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CodigoRolNombre" HeaderText="ROL" Visible="true">
                                <HeaderStyle Width="250px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="ESTADO" HeaderStyle-Width="70px">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("CodigoRol").ToString(), Convert.ToBoolean(Eval("Estado")))%></ItemTemplate>
                                <HeaderStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="ULTIMA MODIFICACION" DataField="SegFechaModifica">
                                <HeaderStyle Width="70px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar" CommandName="Editar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Edit.png" CommandArgument='<%# Eval("CodigoRol") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Eliminar" CommandName="Eliminar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Delete.png" CommandArgument='<%# Eval("CodigoRol") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
