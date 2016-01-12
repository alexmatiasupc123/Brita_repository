<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaHistorialMovimientosUsuarios.aspx.cs" Inherits="ListaHistorialMovimientosUsuarios" %>
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
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Consulta Historial Movimientos - Usuarios"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend>Filtros</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td style=" width:40px"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                                <td style=" width:40px"></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Tipo de movimiento :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguTipoMovimi" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView ID="gvHistorialMovimientos" runat="server" AutoGenerateColumns="False"  PageSize='<%# Util.ObtenerPaginacion() %>' 
                        Width="900px" OnRowDataBound="gvHistorialMovimientos_RowDataBound" OnPageIndexChanging="gvHistorialMovimientos_PageIndexChanging"
                        EmptyDataText="No se encontraron registros de historial de movimientos de usuario SAC." DataKeyNames="sCodPrestamo">
                        <Columns>
                            <asp:BoundField DataField="sCodPrestamo" HeaderText="CÓDIGO DE MOVIMIENTO" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="sCodEjemplarCodigoItem" HeaderText="CÓDIGO ITEM" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="sCodEjemplarNombreTitulo" HeaderText="TÍTULO" />
                            <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" ItemStyle-Width="60px" />
                            <asp:BoundField DataField="dFechaPrestamo" HeaderText="PRÉSTAMO" ItemStyle-Width="55px" />
                            <asp:BoundField DataField="dFechaDevolucionReal" HeaderText="DEVOLUCIÓN REAL" ItemStyle-Width="55px" />
                            <asp:TemplateField HeaderText="A TIEMPO" HeaderStyle-Width="35px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%# PintarEstado(Eval("sCodPrestamo").ToString(), Convert.ToBoolean(Eval("bATiempo")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="35px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="sCodArguPrestamoEnNombre" HeaderText="PRESTAMO EN" ItemStyle-Width="50px" />
                            <asp:BoundField DataField="sCodUsuarioSACNombres" HeaderText="USUARIO SAC" />
                            <asp:BoundField DataField="sCodSacNombre" HeaderText="CENTRO" />
                            <asp:BoundField DataField="sEstadoRegistro" HeaderText="TIPO DE MOVIMIENTO" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
