<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="Reporte_CarnetsXSacXPeriodo.aspx.cs" Inherits="Reporte_CarnetsXSacXPeriodo" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
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
                            <asp:Label ID="Label3" runat="server" Text="Estado Carnet :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoCarnet" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
            </fieldset>
        </div>
        <div class="panelGria">
            <rsweb:ReportViewer ID="CarnetsXSacXPeriodo" runat="server" Width="770px" Height="300mm"
                AsyncRendering="False" 
                SizeToReportContent="True">
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
