<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaSolicitudCarnetImpresiones.aspx.cs" Inherits="ListaSolicitudCarnetImpresiones" meta:resourcekey="PageResource1" %>
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
        Text="Lista de Impresiones de Carné" 
        meta:resourcekey="lblTituloPaginaResource1"></asp:Literal>
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
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" 
                                        Width="16px" meta:resourcekey="Image6Resource1" />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Ver" 
                                        meta:resourcekey="Label10Resource1"></asp:Label>
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
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde:." 
                                        meta:resourcekey="Label1Resource1"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :" 
                                        meta:resourcekey="Label2Resource1"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                                 <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código de usuario :" 
                                        meta:resourcekey="Label3Resource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodUsuarioSAC" runat="server" MaxLength="20" 
                                        Width="150px" onkeypress="return filterInput(1, event)" 
                                        meta:resourcekey="prm_sCodUsuarioSACResource1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="SAC :" 
                                        meta:resourcekey="Label4Resource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sEstablecimientoCodigo" runat="server" 
                                        AppendDataBoundItems="True" 
                                        meta:resourcekey="prm_sEstablecimientoCodigoResource1">
                                    </asp:DropDownList>
                                </td>
                                 <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Estado :" 
                                        meta:resourcekey="Label5Resource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguEstado1" runat="server" Width="150px" 
                                        meta:resourcekey="prm_sCodArguEstado1Resource1">
                                    </asp:DropDownList>
                                </td>
                                 <td style="width:20px"></td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Nombre de usuario :" 
                                        meta:resourcekey="Label6Resource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sNombresUsuarioSAC" runat="server" MaxLength="30" 
                                        Width="150px" onkeypress="return filterInput(0, event)" 
                                        meta:resourcekey="prm_sNombresUsuarioSACResource1"></asp:TextBox>
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
                                    Width="870px" AutoGenerateColumns="False" 
                                    DataKeyNames="sCodSolicitud,sCodArguEstado,sCodUsuarioSAC"  PageSize='<%# Util.ObtenerPaginacion() %>' 
                                    
                                    EmptyDataText="No existen solicitudes registradas para impresión de carnés." OnPageIndexChanging="gvSolicitudesImpresionCarnet_PageIndexChanging"
                                    OnRowCommand="gvSolicitudesImpresionCarnet_RowCommand" 
                                    OnRowDataBound="gvSolicitudesImpresionCarnet_RowDataBound" 
                                    meta:resourcekey="gvSolicitudesImpresionCarnetResource1">
                                    <Columns>
                                        <asp:BoundField DataField="sCodSolicitud" HeaderText="Nº Solicitud" 
                                            meta:resourcekey="BoundFieldResource1">
                                            <HeaderStyle Width="55px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodLocalSACSolicitaNombre" HeaderText="CENTRO" 
                                            meta:resourcekey="BoundFieldResource2">
                                            <HeaderStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sCodUsuarioSAC" HeaderText="CÓDIGO USUARIO" 
                                            meta:resourcekey="BoundFieldResource3">
                                            <HeaderStyle Width="60px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sApellidosNombresUsuarioSAC" 
                                            HeaderText="NOMBRE DE USUARIO" meta:resourcekey="BoundFieldResource4">
                                            <HeaderStyle Width="150px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sistemaSubsistema" HeaderText="SUBSISTEMA" 
                                            meta:resourcekey="BoundFieldResource5">
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="dFechaProceso" HeaderText="FECHA INICIO" 
                                            meta:resourcekey="BoundFieldResource6" />
                                        <asp:BoundField DataField="sCodArguEstado" HeaderText="CODEST" Visible="False" 
                                            meta:resourcekey="BoundFieldResource7" />
                                        <asp:BoundField DataField="sCodArguEstadoNombre" HeaderText="ESTADO" 
                                            meta:resourcekey="BoundFieldResource8" >
                                            <ItemStyle Width="100px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="FOTO" meta:resourcekey="TemplateFieldResource1">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bFotografia")), "E")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="NUEVO/ DUPLIC." 
                                            meta:resourcekey="TemplateFieldResource2">
                                            <ItemTemplate>
                                                <%# PintarEstado(Eval("sCodSolicitud").ToString(), Convert.ToBoolean(Eval("bDuplicado")), "T")%>
                                            </ItemTemplate>
                                            <HeaderStyle Width="35px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="TipoDocuNumero" HeaderText="DOCumento" 
                                            meta:resourcekey="BoundFieldResource9">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="sNumeroDocumento" HeaderText="Nº de DOC" 
                                            Visible="False" meta:resourcekey="BoundFieldResource10">
                                            <HeaderStyle Width="80px" />
                                        </asp:BoundField>
                                        <asp:TemplateField HeaderText="IMPRESO" 
                                            meta:resourcekey="TemplateFieldResource3">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkImpresoTODOS" runat="server" AutoPostBack="True" 
                                                    OnCheckedChanged="chkImpresoTODOS_CheckedChanged" 
                                                    meta:resourcekey="chkImpresoTODOSResource1" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkImpreso" runat="server" AutoPostBack="True" 
                                                    meta:resourcekey="chkImpresoResource1" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField meta:resourcekey="TemplateFieldResource4">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodSolicitud") %>'
                                                    CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" 
                                                    ToolTip="Ver registro de la solicitud" meta:resourcekey="btnVerResource1" />
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
                                &nbsp;</td>
                        </tr>
                    </table>
                </div>
            </ContentTemplate>
            <Triggers>
            <asp:PostBackTrigger ControlID="BotonesEdicionLista1" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
