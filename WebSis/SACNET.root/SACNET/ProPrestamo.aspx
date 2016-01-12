<%@ Page Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ProPrestamo.aspx.cs" Inherits="ProPrestamo" Title="Untitled Page" meta:resourcekey="PageResource1" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/ucUsuario.ascx" TagName="ucUsuario" TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/ucItem.ascx" TagName="ucItemMostrar" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc4" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"  TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Préstamos de Ejemplares" 
        meta:resourcekey="lblTituloPaginaResource1"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <asp:ImageButton ID="ButtonPrestamo" runat="server" OnClick="ButtonPrestamo_Click"
                        Enabled="False" ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" 
                        ToolTip="Guardar" meta:resourcekey="ButtonPrestamoResource1" />
                    <asp:ImageButton ID="ButtonRegresar" runat="server" PostBackUrl="~/Default.aspx"
                        ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" ToolTip="Regresar" 
                        meta:resourcekey="ButtonRegresarResource1" />
                </div>
                <div class="panelGria">
                    <fieldset style="width: 870px">
                        <legend>Préstamo</legend>
                        <table>
                            <tr>
                                <td>
                                    <uc4:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="labelCodUsuario" runat="server" Text="Código de usuario :" 
                                        meta:resourcekey="labelCodUsuarioResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCodigoUsuarioSAC" runat="server" Width="128px" 
                                        OnTextChanged="TextBoxCodigoUsuarioSAC_TextChanged" AutoPostBack="True" 
                                        MaxLength="20" meta:resourcekey="TextBoxCodigoUsuarioSACResource1"></asp:TextBox>
                                </td>
                                <td style="width: 25px">
                                </td>
                                <td>
                                    <asp:Label ID="labelCodEjemplar" runat="server" Text="Código de ejemplar :" 
                                        meta:resourcekey="labelCodEjemplarResource1"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCodigoEjemplar" runat="server" OnTextChanged="TextBoxCodigoEjemplar_TextChanged"
                                        AutoPostBack="True" MaxLength="8" Enabled="False" 
                                        meta:resourcekey="TextBoxCodigoEjemplarResource1"></asp:TextBox>
                                </td>
                                <td style="width: 25px">
                                </td>
                                <td style="width: 200px;">
                                    <asp:CheckBox ID="CheckBoxConCarne" runat="server" Font-Bold="False" Text="Préstamo con carné :"
                                        TextAlign="Left" Visible="False" 
                                        meta:resourcekey="CheckBoxConCarneResource1" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="labelFechaPrestamo" runat="server" Text="Fecha de préstamo :" 
                                        meta:resourcekey="labelFechaPrestamoResource1"></asp:Label>
                                </td>
                                <td colspan="1" class="style1">
                                    <asp:Label ID="labelFechaPrestamoDato" runat="server" Font-Bold="False" 
                                        ForeColor="#000066" meta:resourcekey="labelFechaPrestamoDatoResource1"></asp:Label>
                                </td>
                                <td style="width: 25px">
                                </td>
                                <td>
                                    <asp:Label ID="labelDevolucion" runat="server" Text="Fecha de devolución :" 
                                        meta:resourcekey="labelDevolucionResource1"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:Label ID="labelDevolucionDato" runat="server" Font-Bold="False" 
                                        ForeColor="#000066" meta:resourcekey="labelDevolucionDatoResource1"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <table cellpadding="0" cellspacing="0" border="0">
                        <tr>
                            <td>
                                <asp:Panel ID="pnlUsuario" runat="server" Visible="False" 
                                    meta:resourcekey="pnlUsuarioResource1">
                                    <uc1:ucUsuario ID="ucUsuario1" runat="server" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Panel ID="pnlItem" runat="server" Visible="False" 
                                    meta:resourcekey="pnlItemResource1">
                                    <uc2:ucItemMostrar ID="ucItem1" runat="server" />
                                </asp:Panel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <uc3:Auditoria ID="Auditoria1" runat="server" />
                                <asp:HiddenField ID="HF_Accion" runat="server" />
                                <asp:HiddenField ID="HF_FechaEntrega" runat="server" />
                                <asp:HiddenField ID="HF_CodPrestamo" runat="server" />
                                <asp:HiddenField ID="HF_CodPrestamoRSV" runat="server" />
                                <asp:HiddenField ID="HF_EjemplarRESV" runat="server" />
                                <asp:HiddenField ID="HF_EsUsuarioAL" runat="server" />
                                <asp:HiddenField ID="HF_UsuarioLOCK" runat="server" />
                                <asp:HiddenField ID="HF_CodArguDestPre" runat="server" />
                                <asp:HiddenField ID="HF_FechaFinalClase" runat="server" />
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
