<%@ Page Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ProReserva.aspx.cs" Inherits="ProReservaV1" Title="Untitled Page" %>
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
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Reservaciones"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <asp:ImageButton ID="ButtonReservar" runat="server" OnClick="ButtonReservar_Click" ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" ToolTip="Guardar"/>
                    <asp:ImageButton ID="ButtonRegresar" runat="server" PostBackUrl="~/Default.aspx" ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" ToolTip="Regresar"/>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend>Reserva</legend>
                        <table>
                        <tr>
                            <td>
                                    <uc4:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                            </td>
                        </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label1" runat="server" Text="Código de usuario:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBoxCodUsuario" runat="server" OnTextChanged="TextBoxCodUsuario_TextChanged"
                                        AutoPostBack="True" MaxLength="20" onkeypress="return filterInput(1, event)" 
                                        Width="150px"></asp:TextBox>
                                </td>
                                <td style="width:25px">
                                </td>
                                <td>
                                    <asp:Label ID="labelFechaReserva" runat="server" Text="Fecha de reserva:"></asp:Label>
                                </td>
                                <td>
                                    <asp:Label ID="labelFechaReservaDato" runat="server" Font-Bold="False"
                                        ForeColor="#000066"></asp:Label>
                                </td>
                                <td style="width: 200px; text-align: right">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="label2" runat="server" Text="Código de ítem :"></asp:Label>
                                </td>
                                <td style="width: 150px">
                                    <asp:TextBox ID="TextBoxCodItem" runat="server" MaxLength="20" OnTextChanged="TextBoxCodEjemplar_TextChanged"
                                        AutoPostBack="True" Width="150px"></asp:TextBox>
                                </td>
                                <td>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvItems_RowDataBound"
                        Width="900px">
                        <Columns>
                            <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC" HeaderStyle-Width="180px">
                                <HeaderStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO DE EJEMPLAR" HeaderStyle-Width="110px">
                                <HeaderStyle Width="110px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodEjemplarTitulo" HeaderText="TÍTULO" HeaderStyle-Width="180px">
                                <HeaderStyle Width="180px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodArguEstadoEjemplar" Visible="false" />
                            <asp:BoundField DataField="sCodArguNombreEstadoEjemplar" HeaderText="ESTADO" />
                            <asp:TemplateField HeaderText="RESERVADO" HeaderStyle-Width="40px" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <%--Eval("sCodPrestamo").ToString(), <asp:Label ID="LabelReser" runat="server" Text='<%# Convert.ToBoolean(Eval("bReservado"))%>'></asp:Label>--%>
                                    <%# PintarEstado(Convert.ToBoolean(Eval("bReservado")))%>
                                </ItemTemplate>
                                <HeaderStyle Width="40px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="dFechaDevolucionEstimada" HeaderText="FECHA DE DEVOLUCION" />
                            <asp:TemplateField HeaderText="HACER RESERVA" Visible="true" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <asp:CheckBox ID="CheckBoxReserva" runat="server" OnCheckedChanged="CheckBoxReserva_CheckedChanged"
                                        AutoPostBack="True" ValidationGroup="Un" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <div class="panelGria">
                <table  cellpadding="0" cellspacing="0" border="0">
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
                            <asp:HiddenField ID="HF_Contador" runat="server" />
                            <asp:HiddenField ID="HF_PosiSelecc" runat="server" />
                            <asp:HiddenField ID="HF_CodPrestamo" runat="server" />
                            <asp:HiddenField ID="HF_CodPrestamoRSV" runat="server" />
                            <asp:HiddenField ID="HF_CodEjemplar" runat="server" />
                            <asp:HiddenField ID="HF_UsuarioLOCK" runat="server" />
                        </td>
                    </tr>
                </table></div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
