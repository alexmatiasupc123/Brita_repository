<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="SegMantenimientoRoles.aspx.cs" Inherits="Mantenimientos_SegMantenimientoRoles" %>
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
                <div class="panelBotones">
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div class="panelGria">
                    <fieldset style="width: 870px">
                        <legend>Datos del Rol</legend>
                        <table border="0" cellpadding="0" cellspacing="0" width="670px">
                            <tr>
                                <td style="width: 120px">
                                    <asp:Label ID="Label1" runat="server" Text="Código :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 30px">
                                    <asp:TextBox ID="txtCodigoRol" runat="server" Enabled="False"></asp:TextBox>
                                </td>
                                <td style="width: 120px">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Nombre :"></asp:Label>
                                </td>
                                <td colspan="2" style="text-align: left; height: 30px">
                                    <asp:TextBox ID="txtNombre" runat="server" Width="300px" MaxLength="25"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Descripción :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 30px">
                                    <asp:TextBox ID="txtDescripcion" runat="server" Height="50px" TextMode="MultiLine"
                                        Width="300px" MaxLength="50" onKeyUp="Count(this,50)" onChange="Count(this,50)"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td style="text-align: left; height: 30px">
                                    <asp:RadioButtonList ID="rblEstado" runat="server" RepeatDirection="Horizontal" Width="220px">
                                        <asp:ListItem Value="A">Activo</asp:ListItem>
                                        <asp:ListItem Value="I">Inactivo</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">
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
