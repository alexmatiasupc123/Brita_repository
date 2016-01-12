<%@ Page Title="" Language="C#" MasterPageFile="_MasterPage.master" EnableEventValidation="true"
    AutoEventWireup="true" CodeFile="ListaAsignarEmailUsuarios.aspx.cs" Inherits="ListaAsignarEmailUsuarios" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Usuarios para envio de Correos Electrónicos"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width:900px">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <%--<div class="panelBotones">--%>
            <div style="float: left; width: 361px;">
                <div style="float:left;  width:200px">
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <%--<div class="panelleyenda">--%>
                <div style="float:right">
                    <asp:ImageButton ID="ButtonBuscar" runat="server" ToolTip="Buscar" OnClick="ButtonBuscar_Click"
                                    ImageUrl="~/Comun/Imagenes/Botones/Buscar_A.jpg"  />
                </div>
            </div>
            
            <div class="panelleyenda">
                <asp:Panel ID="pnLeyenda" runat="server">
                            <fieldset>
                                <legend>
                                    <asp:Label ID="Label8" runat="server" Text="Leyenda"></asp:Label>
                                </legend>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png"
                                                Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label15" runat="server" Text="Editar"></asp:Label>
                                        </td>
                                        <td>
                                        </td>
                                        <td>
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                                Width="16px" />
                                        </td>
                                        <td>
                                            <asp:Label ID="Label16" runat="server" Text="Eliminar"></asp:Label>
                                        </td>
                                        
                                    </tr>
                                </table>
                            </fieldset></asp:Panel>     
           </div>
                
            
            <div class="panelGria">
                <asp:Panel ID="pnRegistro" runat="server">
                    <fieldset style="width: 870px">
                        <legend >
                            Registro de usuario</legend>
                        <table border="0" cellpadding="0" cellspacing="0" width="800px">
                            <tr>
                                <td class="style1">
                                    <asp:Label ID="Label1" runat="server" Text="Nº de registro :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNroRegistro" runat="server" Enabled="False" ReadOnly="True"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                        <table border="0" cellpadding="0" cellspacing="0" width="800px">
                            <tr>
                                <td> 
                                    <asp:Label ID="Label2" runat="server" Text="Nombres :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxNombre" runat="server" Width="200px" 
                                        onkeypress="return filterInput(0, event)" MaxLength="50"></asp:TextBox>
                                    <asp:Label ID="lblIdUsuario" runat="server" Visible="False"></asp:Label>
                                </td>
                                <td style="width:30px">
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Apellidos :"></asp:Label>
                                </td>
                                <td> 
                                    <asp:TextBox ID="TextBoxApellido" runat="server" Width="200px" 
                                        onkeypress="return filterInput(0, event)" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Correo electrónico 1 :"></asp:Label>
                                </td>
                                <td > 
                                    <asp:TextBox ID="TextBoxEmail1" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                                <td style="width: 10px">
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Correo electrónico 2 :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxEmail2" runat="server" Width="200px" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Cargo :"></asp:Label>
                                </td>
                                <td> 
                                    <asp:DropDownList ID="DropDownListCargosUsuarios" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Motivo de envio :"></asp:Label>
                                </td>
                                <td> 
                                    <asp:DropDownList ID="DropDownListMotivoDeEnvio" runat="server" Width="200px">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td> 
                                    <asp:Label ID="Label13" runat="server" Text="Activo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkEstado" runat="server" />
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td style="text-align: right; padding-right: 10px">
                                    &nbsp;</td>
                                <td style="text-align: left">
                                    &nbsp;</td>
                            </tr>
                        </table>
                        
                    </fieldset></asp:Panel>
            </div>
            <div class="panelGria">
                <asp:Panel ID="pnAuditoria" runat="server">
                    <uc3:Auditoria ID="Auditoria1" runat="server" />
                </asp:Panel>
            </div>
            <div class="panelBucador">
                <asp:Panel ID="pnBusqueda" runat="server">
                <fieldset style="width: 870px">
                        <legend>Búsqueda de registros</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Apellidos :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxprm_sApellidos" runat="server" 
                                        onkeypress="return filterInput(0, event)" Width="200px"></asp:TextBox>
                                </td>
                                <td style="width: 30px">
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Cargo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListprm_sCodArguCargo" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Motivo de Envio :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="DropDownListprm_sCodArguAccionMotivo" runat="server" 
                                        Width="200px">
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 30px">
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                    
                                        <asp:ListItem Selected="True">-- Todos -</asp:ListItem>
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </td>
                                <td style="width: 30px">
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                   </fieldset></asp:Panel>      
            </div>            
            <div class="panelGria">
                <asp:Panel ID="pnListadoUsuarios" runat="server">
                        <asp:GridView ID="gvUsuariosCorreos" runat="server" AllowPaging="True" AutoGenerateColumns="false"
                            BorderWidth="1px" DataKeyNames="sCodUsuario" Width="900px" EmptyDataText="No existen correos electrónicos de usuarios."
                            OnRowCommand="gvUsuariosCorreos_RowCommand" OnPageIndexChanging="gvUsuariosCorreos_PageIndexChanging"
                            OnRowDataBound="gvUsuariosCorreos_RowDataBound"  PageSize='<%# Util.ObtenerPaginacion() %>'>
                            <Columns>
                                <asp:BoundField DataField="sCodUsuario" HeaderText="USUARIO" Visible="false">
                                    <HeaderStyle Width="100px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sNombre" HeaderText="NOMBRES">
                                    <HeaderStyle Width="150px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sApellidos" HeaderText="APELLIDOS">
                                    <HeaderStyle Width="150px" HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sCorreoElectronico1" HeaderText="CORREO 1">
                                    <HeaderStyle Width="150px" HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sCorreoElectronico2" HeaderText="CORREO 2">
                                    <HeaderStyle Width="150px" HorizontalAlign="Left" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="sCodArguAccionMotivoNombre" HeaderText="MOTIVO DE ENVIO">
                                    <HeaderStyle HorizontalAlign="Left" Width="200px" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar" CommandName="Editar"
                                            ImageUrl="~/Comun/Imagenes/Icons/Edit.png" CommandArgument='<%# Eval("sCodUsuario") %>' />
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Eliminar" CommandName="Eliminar"
                                            ImageUrl="~/Comun/Imagenes/Icons/Delete.png" CommandArgument='<%# Eval("sCodUsuario") %>' />
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
<asp:Content ID="Content3" runat="server" contentplaceholderid="head">

    <style type="text/css">
        .style1
        {
            width: 138px;
        }
    </style>

</asp:Content>

