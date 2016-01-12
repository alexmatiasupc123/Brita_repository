<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="Reporte_StockXSAC.aspx.cs" Inherits="Reporte_StockXSAC" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register Src="Comun/Controles/ucTextBoxFecha.ascx" TagName="ucTextBoxFecha" TagPrefix="uc3" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style1
        {
            width: 122px;
        }
        .style2
        {
            width: 142px;
        }
        .style3
        {
            width: 122px;
        }
        .style4
        {
            width: 200px;
        }
    </style>
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
                        <td class="style1">
                            <asp:Label ID="Label6" runat="server" Text="SAC :"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="ddlSAC" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="style3">
                            &nbsp;
                            <asp:Label ID="Label11" runat="server" Text="Tipo Reporte :"></asp:Label>
                        </td>
                        <td class="style4">
                           <asp:DropDownList ID="ddlReporte" runat="server">
                               <asp:ListItem>Consolidado</asp:ListItem>
                               <asp:ListItem>Detallado</asp:ListItem>
                            </asp:DropDownList>
                            </td>
                        <td>
                            <asp:ImageButton ID="ibtnAceptar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Aceptar_A.png"
                                OnClick="ibtnAceptar_Click" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Label ID="Label10" runat="server" Text="Tipo Material :"></asp:Label>
                        </td>
                        <td class="style2">
                            <asp:DropDownList ID="ddlTipoMaterial" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td class="style3">
                            &nbsp;
                            <asp:Label ID="Label12" runat="server" Text="Ordenado por :"></asp:Label>
                            &nbsp;</td>
                        <td class="style4">
                            <asp:RadioButtonList ID="opOrden" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="opOrden_SelectedIndexChanged"
                                AutoPostBack="True">
                                <asp:ListItem Selected="True">Item</asp:ListItem>
                                <asp:ListItem>Tema</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                        <td>
                            &nbsp;</td>
                        
                    </tr>
                    <tr>
                        <td class="style1">
                            &nbsp;</td>
                        <td class="style2">
                            &nbsp;</td>
                        <td class="style3">
                            &nbsp;</td>
                        <td class="style4">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    </table>
            </fieldset>
        </div>
       <div class="panelGria" runat="server" id="divLista">
            <rsweb:ReportViewer ID="rvStockXSAC" runat="server" 
                Width="770px" Height="310mm"  AsyncRendering="False" 
                SizeToReportContent="True" >
            </rsweb:ReportViewer>
        </div>
        
    </div>
</asp:Content>
