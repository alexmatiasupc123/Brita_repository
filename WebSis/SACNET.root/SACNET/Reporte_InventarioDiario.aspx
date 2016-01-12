<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="Reporte_InventarioDiario.aspx.cs" Inherits="Reporte_RankingTitulos" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="Comun/Controles/ucTextBoxFecha.ascx" TagName="ucTextBoxFecha" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text=""></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 800px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBucador">
                    <fieldset style="width: 770px">
                        <legend>Filtros</legend>
                        <table width="770px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="SAC :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sEstablecimientoCodigo" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Periodo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodEjemplarTitulo0" runat="server" Width="195px" MaxLength="20"
                                        onkeypress="return filterInput(0, event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Rango Fecha desde :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Tipo Material :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguPrestamoEn0" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Tipo Movimiento :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguPrestamoEn1" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Disponibilidad :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodEjemplarTitulo1" runat="server" MaxLength="20" onkeypress="return filterInput(0, event)"
                                        Width="195px"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
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
                <div class="panelGria">
                    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Width="770px" 
                        Height="300mm"
                AsyncRendering="False" 
                SizeToReportContent="True">
                    </rsweb:ReportViewer>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
