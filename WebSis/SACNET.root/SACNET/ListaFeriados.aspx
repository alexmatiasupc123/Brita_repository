<%@ Page Title="" Language="C#" MasterPageFile="_MasterPage.master" EnableEventValidation="true"
    AutoEventWireup="true" CodeFile="ListaFeriados.aspx.cs" Inherits="ListaFeriados" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Feriados del Sistema"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
   <div style="width:900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <div style="float: left; width: 360px;">
                <div style="float:left;  width:200px">
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <asp:HiddenField ID="HiddenFieldProceso" runat="server" />
                </div>
                <div style="float:right" visible="false">
                    <asp:ImageButton ID="ButtonBuscar" runat="server" ToolTip="Buscar"
                    ImageUrl="~/Comun/Imagenes/Botones/Buscar_A.jpg" 
                    onclick="ButtonBuscar_Click"/>
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
                    <legend>Registro de feriado</legend>
                    <table>
                        <tr>
                            <td style="width: 200px; text-align: right; padding-right: 10px">
                                <asp:Label ID="Label1" runat="server" Text="Seleccionar fecha:"></asp:Label>
                            </td>
                            <td> 
                                <uc4:ucTextBoxFecha ID="TextBoxNroRegistroFecha" runat="server" />
                                
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxNroRegistro" runat="server" Enabled="true" MaxLength="8"
                                    ToolTip="MM=Nº de mes, DD=Nº de día" Width="63px"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                    <table>
                        <tr>
                            <td style="text-align: right; padding-right: 10px">
                                <asp:Label ID="Label5" runat="server" Text="Feriado fijo :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxbEsFijo" runat="server" />
                            </td>
                            <td style="width: 10px">
                            </td>
                            <td style="width: 200px; text-align: right; padding-right: 10px; height: 23px">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px; text-align: right; padding-right: 10px">
                                <asp:Label ID="Label2" runat="server" Text="Nombre feriado :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxDescripcion" runat="server" Width="290px" 
                                    ToolTip="Nombre del feriado" MaxLength="50"></asp:TextBox>
                                <asp:Label ID="lblIdUsuario" runat="server" Visible="False"></asp:Label>
                            </td>
                            <td style="width: 10px">
                            </td>
                            <td style="width: 200px; text-align: right; padding-right: 10px; height: 23px">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: right; padding-right: 10px">
                                <asp:Label ID="Label12" runat="server" Text="Activo :"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:CheckBox ID="CheckBoxbEstado" runat="server" />
                            </td>
                            <td style="width: 10px">
                            </td>
                            <td style="width: 200px; text-align: right; padding-right: 10px; height: 23px">
                                &nbsp;
                            </td>
                            <td style="text-align: left">
                                &nbsp;
                            </td>
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
                    <fieldset  style="width: 870px">
                    <legend>Búsqueda de registros</legend>
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label9" runat="server" Text="Año :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxprm_prm_sAnio" runat="server" MaxLength="4"></asp:TextBox>
                            </td>
                            <td style="width: 30px">
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Nombre de feriado :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxprm_sDescripcion" runat="server" Width="187px" 
                                    MaxLength="50" onkeypress="return filterInput(0, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                    <asp:Label ID="Label3" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                    
                                        <asp:ListItem Selected="True">-- Todos -</asp:ListItem>
                                        <asp:ListItem Value="1">Activo</asp:ListItem>
                                        <asp:ListItem Value="0">Inactivo</asp:ListItem>
                                    
                                    </asp:DropDownList>
                                </td>
                            <td style="width: 30px">
                            <td>
                                <asp:Label ID="Label11" runat="server" Text="Feriado fijo:"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="CheckBoxprm_TipoFeriado" runat="server" Checked="True" />
                            </td>
                            <td style="width: 30px">
                            <td>
                                    
                            </td>
                        </tr>
                    </table>
                </fieldset></asp:Panel>
            </div>
            <div class="panelGria">
                <asp:Panel ID="pnListadoUsuarios" runat="server">
                    <asp:GridView ID="gvFeriados" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        BorderWidth="1px" DataKeyNames="sCodRegistro" EmptyDataText="No existen feriados definidos."
                        OnRowCommand="gvFeriados_RowCommand" OnPageIndexChanging="gvFeriados_PageIndexChanging"
                        OnRowDataBound="gvFeriados_RowDataBound"  PageSize='<%# Util.ObtenerPaginacion() %>' Width="900px">
                        <Columns>
                            <asp:BoundField DataField="sFeriado" HeaderText="CÓDIGO FECHA" Visible="true">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sDescripcion" HeaderText="NOMBRE DE FERIADO">
                                <HeaderStyle Width="260px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dFechaIndicada" HeaderText="FECHA FERIADO" DataFormatString="{0:dd/MM/yyyy}">
                                <HeaderStyle Width="100px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="FERIADO FIJO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("sCodRegistro").ToString(), Convert.ToBoolean(Eval("bFijo")), "E")%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="ACTIVO" HeaderStyle-Width="80px" HeaderStyle-HorizontalAlign="Center"
                                ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("sCodRegistro").ToString(), Convert.ToBoolean(Eval("bEstado")), "E")%>
                                </ItemTemplate>
                                <HeaderStyle Width="80px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="SSIFechaHora_Modificacion" HeaderText="ULTIMA EDICIÓN">
                                <HeaderStyle HorizontalAlign="Left" Width="130px" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" ToolTip="Editar" CommandName="Editar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Edit.png" CommandArgument='<%# Eval("sCodRegistro") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" ToolTip="Eliminar" CommandName="Eliminar"
                                        ImageUrl="~/Comun/Imagenes/Icons/Delete.png" CommandArgument='<%# Eval("sCodRegistro") %>' />
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
