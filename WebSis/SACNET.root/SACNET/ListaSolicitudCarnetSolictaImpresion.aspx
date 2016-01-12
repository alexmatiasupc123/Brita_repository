<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaSolicitudCarnetSolictaImpresion.aspx.cs" Inherits="ListaSolicitudCarnetSolictaImpresion" %>
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
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Lista Solicitud Impresión de Carne"></asp:Literal>
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
                    <asp:ImageButton ID="ButtonConfirmaSolicitud" runat="server" OnClick="ButtonConfirmaSolicitud_Click"
                        ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" ToolTip="Confirmar impresión de carné"
                        Visible="true" />
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
                                    <asp:Label ID="Label8" runat="server" Text="Editar/Confirmar impresión"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Image ID="Image5" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Eliminar"></asp:Label>
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
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde:."></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                                <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código de usuario :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodUsuarioSAC" runat="server" 
                                        onkeypress="return filterInput(1, event)" MaxLength="20"></asp:TextBox>
                                </td>
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
                                    <asp:Label ID="Label5" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguEstado1" runat="server">
                                    </asp:DropDownList>
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
                                <asp:GridView ID="gvSolicitudesImpresionCarnet" runat="server" Width="900px" 
                                    AllowPaging="True"  PageSize='<%# Util.ObtenerPaginacion() %>' 
                                    AutoGenerateColumns="False" 
                                    
                                    DataKeyNames="sCodSolicitud,bFotografia,bDuplicado,sNumeroDocumento,sTipoDocumento,sUsuario,sEstablecimientoCodigo,sCodArguEstado" EmptyDataText="No existen solicitudes registradas."
                                    OnPageIndexChanging="gvSolicitudesImpresionCarnet_PageIndexChanging" OnRowCommand="gvSolicitudesImpresionCarnet_RowCommand"
                                    OnRowDataBound="gvSolicitudesImpresionCarnet_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="sCodSolicitud" HeaderText="Nº Solicitud" HeaderStyle-Width="100px">
                                            <HeaderStyle Width="55px" />
                                        </asp:BoundField>
                                        
                                        <asp:BoundField DataField="sCodLocalSACSolicitaNombre" HeaderText="centro" HeaderStyle-Width="100px">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodUsuarioSAC" HeaderText="CÓDIGO USUARIO">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sApellidosNombresUsuarioSAC" HeaderText="NOMBRE DE USUARIO"
                                            HeaderStyle-Width="150px">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sistemaSubsistema" HeaderText="SUBSISTEMA">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dFechaProceso" HeaderText="FECHA INICIO" 
                                            HeaderStyle-Width="100px" >
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodArguEstadoNombre" HeaderText="ESTADO" 
                                            HeaderStyle-Width="100px" >
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="FOTO" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bFotografia")), "E")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NUEVO/ DUPLIC." HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Left">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bDuplicado")), "T")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TipoDocuNumero" HeaderText="DOCumento" HeaderStyle-Width="50px">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sNumeroDocumento" HeaderText="Nº de DOC" HeaderStyle-Width="80px" Visible="false">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkConfirmar" runat="server" AutoPostBack="True" />
                                            </ItemTemplate>
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkConfirmarTODOS" runat="server" AutoPostBack="true" 
                                                    OnCheckedChanged="chkConfirmarTODOS_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemStyle Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
                                                    CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
                                                    CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" ToolTip="Editar/Confirmar impresión" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" Width="20px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
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
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
