<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="SegMantenimientoOpciones.aspx.cs" Inherits="Mantenimientos_SegMantenimientoOpciones" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="cphTitulo">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
    <asp:UpdatePanel ID="udpMantenimientoTitular" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div style="width: 870px;">
                <table>
                    <tr>
                        <td>
                            <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                        </td>
                    </tr>
                </table>
                <fieldset style="width: 870px">
                    <legend style="font-weight: bold">Datos de la opción</legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="670px">
                        <tr>
                            <td style="width: 200px; height: 27px">
                                <asp:Label ID="Label1" runat="server" Text="Código :"></asp:Label>
                            </td>
                            <td style="width: 220px; height: 27px">
                                <asp:TextBox ID="txtCodigoOpcion" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                            <td style="width: 120px">
                                &nbsp;
                            </td>
                            <td style="width: 220px">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="height: 27px">
                                <asp:Label ID="Label3" runat="server" Text="Código Padre :"></asp:Label>
                            </td>
                            <td style="height: 30px" colspan="2">
                                <asp:DropDownList ID="ddlCodigoPadre" runat="server" Width="300px">
                                </asp:DropDownList>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Nombre :"></asp:Label>
                            </td>
                            <td style="height: 30px" colspan="2">
                                <asp:TextBox ID="txtNombre" runat="server" Width="300px" MaxLength="40"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label7" runat="server" Text="Descripción :"></asp:Label>
                            </td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtDescripcion" runat="server" Height="50px" TextMode="MultiLine"
                                    Width="300px" onKeyUp="Count(this,50)"></asp:TextBox>
                            </td>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label2" runat="server" Text="Enlace :"></asp:Label>
                            </td>
                            <td style="height: 30px">
                                <asp:TextBox ID="txtEnlace" runat="server" Width="300px" MaxLength="100"></asp:TextBox>
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
                                <asp:Label ID="Label5" runat="server" Text="Es opción de menú :"></asp:Label>
                            </td>
                            <td style="height: 30px" colspan="2">
                                <asp:RadioButtonList ID="rblMenus" runat="server" RepeatDirection="Horizontal" Width="220px">
                                    <asp:ListItem Value="S">Si</asp:ListItem>
                                    <asp:ListItem Value="N">No</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label8" runat="server" Text="Estado :"></asp:Label>
                            </td>
                            <td style="height: 30px">
                                <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="220px">
                                    <asp:ListItem Value="A">Activo</asp:ListItem>
                                    <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                </asp:RadioButtonList>
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
             <asp:Panel ID="pnAuditoria" runat="server">
                <uc3:Auditoria ID="Auditoria1" runat="server" />
                <asp:HiddenField ID="hfParameters" runat="server" />
            </asp:Panel>    
        </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>
