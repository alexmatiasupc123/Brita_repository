<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="Reporte_MovimientosXPeriodoDetallado.aspx.cs" Inherits="Reporte_MovimientosXPeriodoDetallado" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="Comun/Controles/ucTextBoxFecha.ascx" TagName="ucTextBoxFecha" TagPrefix="uc3" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text=""></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
    <div style="width: 800px">
        <div class="panelBucador">
            <fieldset style="width: 770px">
                <legend>Filtros</legend>
                <table width="770px">
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="SAC :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSAC" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            <asp:ImageButton ID="ibtnAceptar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Aceptar_A.png"
                                OnClick="ibtnAceptar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:RadioButtonList ID="opFecha" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="opFecha_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Selected="True">Periodo</asp:ListItem>
                                <asp:ListItem>Rango de Fechas</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblFechaDesde" runat="server" Text="Desde : " Visible="False"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtPeriodo" runat="server" MaxLength="6" onkeypress="return filterInput(1, event)"
                                Width="80px"></asp:TextBox>
                            <uc3:ucTextBoxFecha ID="ucFechaDesde" runat="server" Visible="False" />
                        </td>
                        <td>
                            <asp:Label ID="lblFechaHasta" runat="server" Text="Hasta : " Visible="False"></asp:Label>
                        </td>
                        <td>
                            <uc3:ucTextBoxFecha ID="ucFechaHasta" runat="server" Visible="False" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Tipo Movimiento :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
                                <asp:ListItem Value="P">Prestamo</asp:ListItem>
                                <asp:ListItem Value="R">Reserva</asp:ListItem>
                                <asp:ListItem Value="D">Devolución</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Tipo Material :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoMaterial" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Tipo Reporte :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoReporte" runat="server">
                                <asp:ListItem Selected="True" Value="0">Listado</asp:ListItem>
                                <asp:ListItem Value="1">Gráfico</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;
                        </td>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
       <div class="panelGria" runat="server" id="divLista">
            <rsweb:ReportViewer ID="rvMovimientosXPeriodoDetallado" runat="server" 
                Width="770px" Height="310mm"  AsyncRendering="False" 
                SizeToReportContent="True" >
            </rsweb:ReportViewer>
        </div>
        
    </div>
</asp:Content>
