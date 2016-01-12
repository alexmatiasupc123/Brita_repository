<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaRegistroUsuarioSala.aspx.cs" Inherits="ListaRegistroUsuarioSala" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc3" %>    
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" 
        Text="Lista Registro de Usuarios en Sala"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
              <div style="float: left; width: 270px;">
                <div style="float:left;  width:180px">
                    <%--class="panelBotones" --%>
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <asp:HiddenField ID="hf_CodigoSAC" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div style="float:right">
                </div>
              </div>
                <div class="panelleyenda" style="width:350px">
                    <fieldset>
                        <legend>Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Ver"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Editar/Registrar salida"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                        Width="16px" Visible="False" />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Eliminar" Visible="False"></asp:Label>
                                </td>
                                <td>
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend>Filtros</legend>
                        <table>
                            <tr>
                                <td colspan="5">
                                    Fecha de Registro</td>
                                <td style="width:20px">&nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde:."></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaINI" runat="server" />
                                </td>
                                <td style="width:20px">
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaFIN" runat="server" />
                                </td>
                                <td style="width:20px">
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="SAC :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sEstablecimientoCodigo" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código de usuario :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodUsuarioSAC" runat="server" MaxLength="20" 
                                        onkeypress="return filterInput(1, event)"></asp:TextBox>
                                </td>
                                <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Nombre de usuario :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sNombresUsuarioSAC" runat="server" 
                                        onkeypress="return filterInput(0, event)" MaxLength="30"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <table>
                        
                        <tr>
                            <td>
                                <asp:GridView ID="gvRegistroUsuarioSala" runat="server" Width="900px" 
                                    AllowPaging="True"  PageSize='<%# Util.ObtenerPaginacion() %>' 
                                    AutoGenerateColumns="False" 
                                    
                                    DataKeyNames="sCodRegistro" EmptyDataText="No existen registros de usuarios en sala."
                                    OnPageIndexChanging="gvRegistroUsuarioSala_PageIndexChanging" OnRowCommand="gvRegistroUsuarioSala_RowCommand"
                                    OnRowDataBound="gvRegistroUsuarioSala_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="sCodRegistro" HeaderText="Nº Registro" 
                                            HeaderStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sAbreviaturaSacRegistro" HeaderText="SAC REGISTRO" 
                                            HeaderStyle-Width="50px">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodUsuarioSAC" HeaderText="CÓDIGO USUARIO"
                                            HeaderStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sUsuarioSACNombre" HeaderText="NOMBRE DE USUARIO"
                                            HeaderStyle-Width="170px">
                                            <HeaderStyle Width="170px" />
                                            <ItemStyle HorizontalAlign="Center" Width="170px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sAbreviaturaSacUsuario" HeaderText="SAC USUARIO" 
                                            HeaderStyle-Width="50px">
                                            <HeaderStyle Width="50px" />
                                            <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dFechaInicio" HeaderText="FECHA INICIO" 
                                            HeaderStyle-Width="80px" >
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dFechaFin" HeaderText="FECHA FIN" 
                                            HeaderStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="EN SALA">
                                            <EditItemTemplate>
                                                <asp:CheckBox ID="CheckBox1" runat="server" Checked='<%# Bind("bSala") %>' />
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkEnSala" runat="server" Checked='<%# Bind("bSala") %>' 
                                                    Enabled="false" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="SSIFechaHora_Creacion" HeaderText="FECHA REGISTRO" 
                                            HeaderStyle-Width="80px">
                                            <HeaderStyle Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodRegistro") %>'
                                                    CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodRegistro") %>'
                                                    CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" 
                                                    ToolTip="Editar/Registrar salida" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="false"> 
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("sCodRegistro") %>'
                                                    Visible="true" CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                                    ToolTip="Eliminar" />
                                                <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                                    ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True" TargetControlID="btnEliminar">
                                                </cc1:ConfirmButtonExtender>
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" visible="false">
                                <asp:Button ID="Button2" runat="server" Text="Registrar en el SAC" Visible="false" />
                                <asp:Button ID="Button3" runat="server" Text="Entregar al USUARIO" Visible="false" />
                            </td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
<%--    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>--%>
</asp:Content>
