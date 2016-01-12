<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaSolicitudCarnetRecibidoUsuarioSAC.aspx.cs" Inherits="ListaSolicitudCarnetRecibidoUsuarioSAC" %>
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
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Lista de Entrega de Carnés a Usuarios"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <asp:HiddenField ID="HF_Foto" runat="server" />
                    <asp:HiddenField ID="HF_Accion" runat="server" />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>Leyenda</legend>
                        <table>
                            <tr>
                               
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/SelecDocument.png" ToolTip="Entregar carné a usuario" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Entregar carné a usuario"></asp:Label>
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
                                <asp:GridView ID="gvSolicitudesImpresionCarnet" runat="server" AllowPaging="True"
                                    AutoGenerateColumns="False" Width="900px" DataKeyNames="sCodSolicitud,sCodArguEstado,sCodUsuarioSAC"
                                    EmptyDataText="No existen solicitudes registradas de carnés para entrega a usuario SAC."  PageSize='<%# Util.ObtenerPaginacion() %>' 
                                    OnPageIndexChanging="gvSolicitudesImpresionCarnet_PageIndexChanging" OnRowCommand="gvSolicitudesImpresionCarnet_RowCommand"
                                    OnRowDataBound="gvSolicitudesImpresionCarnet_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="sCodSolicitud" HeaderText="Nº Solicitud" HeaderStyle-Width="60px">
                                            <HeaderStyle Width="60px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodLocalSACSolicitaNombre" HeaderText="CENTRO" 
                                            HeaderStyle-Width="100px">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodUsuarioSAC" HeaderText="CÓDIGO USUARIO"
                                            HeaderStyle-Width="60px">
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sApellidosNombresUsuarioSAC" HeaderText="NOMBRE DE USUARIO"
                                            HeaderStyle-Width="150px">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sistemaSubsistema" HeaderText="SUBSISTEMA">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dFechaProceso" HeaderText="FECHA INICIO" />
                                        <asp:BoundField DataField="sCodArguEstado" HeaderText="CODEST" Visible="false" />
                                        <asp:BoundField DataField="sCodArguEstadoNombre" HeaderText="ESTADO" />
                                        <asp:TemplateField HeaderText="FOTO" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bFotografia")), "E")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NUEVO/ DUPLIC." HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bDuplicado")), "T")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TipoDocuNumero" HeaderText="DOCumento" HeaderStyle-Width="50px">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sNumeroDocumento" HeaderText="Nº de DOC" HeaderStyle-Width="80px" Visible="false">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField Visible="true" HeaderText="RECIBIDO USUARIO" >
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkRecibidoUsuarioSACTODOS" runat="server" AutoPostBack="true" Visible="false"
                                                    OnCheckedChanged="chkRecibidoUsuarioTODOS_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRecibidoUsuarioSAC" runat="server" AutoPostBack="True" Visible="false" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnEntrega" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
                                                    CommandName="Entrega" ImageUrl="~/Comun/Imagenes/Icons/SelecDocument.png" ToolTip="Entregar carné a usuario" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField Visible="true">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
                                                    CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver registro de la solicitud" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="30px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" visible="false">
                                <asp:Button ID="ButtonConfirmaEntregaUsuario" runat="server" Text="Confirmar Entrega de Carné a Usuario"
                                    OnClick="ButtonConfirmaEntregaUsuario_Click" Height="40px" 
                                    Visible="False" />
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
