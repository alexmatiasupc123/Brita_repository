<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="Copy of Reporte_RankingTitulos.aspx.cs" Inherits="Reporte_RankingTitulos" %>

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
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Tipo Material :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoMaterial" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <!--sdfsfs-->
                    <tr>
                        <td>
                            <asp:Label ID="Label11" runat="server" Text="Código Item :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodItem" runat="server" MaxLength="20" Width="195px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label100" runat="server" Text="Código Ejemplar :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodEjemplar" runat="server" MaxLength="20" Width="195px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label20" runat="server" Text="Titulo :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitulo" runat="server" Width="195px" MaxLength="200" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="lblAutor" runat="server" Text="Autor :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlAutor" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Tema :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTema" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Estado Ejemplar:"></asp:Label>
                        </td>
                        <td>
                                    
                            <asp:DropDownList ID="ddlEstadoEjemplar" runat="server">
                            </asp:DropDownList>
                                    
                                </td>
                    </tr>
                    <!--sdfsfsd-->
                    <!--<tr>
                        <td>
                            <asp:Label ID="Label10" runat="server" Text="Tipo de movimiento :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoMovimiento" runat="server">
                                <asp:ListItem Value="P">Prestamo</asp:ListItem>
                                <asp:ListItem Value="R">Reserva</asp:ListItem>
                                <asp:ListItem Value="D">Devolución</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>-->
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Ordenar :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlOrden" runat="server">
                                <asp:ListItem Value="0">Mas Prestados</asp:ListItem>
                                <asp:ListItem Value="1">Menos Prestados</asp:ListItem>
                            </asp:DropDownList>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Cantidad a Mostrar :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCantidad" runat="server" MaxLength="4" onkeypress="return filterInput(1, event)"
                                Width="80px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="panelGria">
            <rsweb:ReportViewer ID="rvEjemplares" runat="server" Width="770px" Height="300mm"
                AsyncRendering="False" 
                SizeToReportContent="True"
                >
            </rsweb:ReportViewer>
        </div>
    </div>
</asp:Content>
