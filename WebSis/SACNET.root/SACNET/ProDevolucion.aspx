<%@ Page Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ProDevolucion.aspx.cs" Inherits="ProDevolucionV1" Title="Untitled Page" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/ucUsuario.ascx" TagName="ucUsuario" TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/ucItem.ascx" TagName="ucItem" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc4" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" 
        Text="Devolución de ejemplares"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table cellpadding="0" cellspacing="0" width="870">
                    <tr>
                        <td width="90">
                            <asp:ImageButton ID="ButtonDevolucion" runat="server" 
                                ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" 
                                OnClick="ButtonDevolucion_Click" ToolTip="Guardar" />
                        </td>
                        <td width="90">
                            <asp:ImageButton ID="ButtonRegresar" runat="server" 
                                ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" PostBackUrl="~/Default.aspx" 
                                ToolTip="Regresar" />
                        </td>
                        <td align="right" width="690">
                            <asp:ImageButton ID="ButtonRenovacion" runat="server" Enabled="False" 
                                ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" 
                                OnClick="ButtonRenovacion_Click" ToolTip="Renovar Préstamo" />
                            <asp:ImageButton ID="ButtonCancelar" runat="server" Enabled="False" 
                                ImageUrl="~/Comun/Imagenes/Botones/Cancelar_A.jpg" 
                                onclick="ButtonCancelar_Click" PostBackUrl="~/Default.aspx" 
                                ToolTip="Cancelar" />
                        </td>
                    </tr>
                </table>
                <div class="panelBotones">
                </div>
                 <div class="panelGria">
                    <fieldset style="width: 870px">
                        <legend>Devolución</legend>
                        <table>
                        <tr>
                            <td>
                                <uc4:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                                <asp:HiddenField ID="HF_Operacion" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="label1" runat="server" Text="Código de ejemplar :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBoxCodigoEjemplar" runat="server" AutoPostBack="True" 
                                    OnTextChanged="TextBoxCodigoEjemplar_TextChanged" MaxLength="8" Width="126px"></asp:TextBox>
                            </td>
                            <td style="width:25px">
                            </td>
                            <td>
                                <asp:Label ID="lblFechaOperacion" runat="server" Text="Fecha de devolución :"></asp:Label>
                            </td>
                            <td style="width: 330px; text-align: left">
                                <asp:Label ID="labelFechaDevolucionDato" runat="server" Font-Bold="False" ForeColor="#000066"></asp:Label>
                                <asp:Label ID="labelFechaPrestamoDato" runat="server" Font-Bold="False" 
                                    ForeColor="#000066" meta:resourcekey="labelFechaPrestamoDatoResource1" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="width: 120px; text-align: right">
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                            <td style="width:25px">
                            </td>
                            <td>
                                <asp:Label ID="lblFechaDevolucionEstimada" runat="server" 
                                    Text="Devolución estimada:"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="labelFechaDevEstimada" runat="server" Font-Bold="False" 
                                    ForeColor="#000066"></asp:Label>
                                <asp:Label ID="labelDevolucionDato" runat="server" Font-Bold="False" 
                                    ForeColor="#000066" meta:resourcekey="labelDevolucionDatoResource1" 
                                    Visible="False"></asp:Label>
                            </td>
                            <td style="width: 120px; text-align: right">
                            </td>
                        </tr>
                    </table>
                    </fieldset>
                    <table cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlUsuario" runat="server" Visible="false">
                            <uc1:ucUsuario ID="ucUsuario1" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Panel ID="pnlItem" runat="server" Visible="false">
                                <uc2:ucItem ID="ucItem1" runat="server" />
                            </asp:Panel>    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <uc3:Auditoria ID="Auditoria1" runat="server" />
                            <asp:HiddenField ID="HF_Accion" runat="server" />
                            <asp:HiddenField ID="HF_FechaDevEstimada" runat="server" />
                            <asp:HiddenField ID="HF_CodPrestamo" runat="server" />
                            <asp:HiddenField ID="HF_CodUsuario" runat="server" />
                            <asp:HiddenField ID="HF_CentroPrestamo" runat="server" />
                            <asp:HiddenField ID="HF_FechaEntrega" runat="server" />
                            <asp:HiddenField ID="HF_FechaFinalClase" runat="server" />
                            <asp:HiddenField ID="HF_FecDevRealPrestamoOrigen" runat="server" />
                            <asp:HiddenField ID="HF_FecDevEstimadaPrestamoOrigen" runat="server" />
                            <asp:HiddenField ID="HF_TipoPrestamoCOD" runat="server" />
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
