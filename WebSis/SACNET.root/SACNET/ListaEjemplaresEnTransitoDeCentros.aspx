<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaEjemplaresEnTransitoDeCentros.aspx.cs" Inherits="ListaEjemplaresEnTransitoDeCentros" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register Src="Comun/Controles/ucTextBoxFecha.ascx" TagName="ucTextBoxFecha" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Ejemplares en tránsito de devolución"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="float: left; width: 270px;">
                    
                    <div style="float:left;  width:180px">
                        <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                        <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                        <asp:HiddenField ID="HF_Foto" runat="server" />
                        <asp:HiddenField ID="HF_Accion" runat="server" />
                    </div>
                    <div style="float:right">
                        <asp:ImageButton ID="ButtonConfirmaRecepcion" runat="server" OnClick="ButtonConfirmaRecepcion_Click"
                            ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" ToolTip="Confirmar recepción de carné"
                            Visible="true" />
                    </div>
                </div>
                <div class="panelleyenda">
                    
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend>Filtros</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde:"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código de ejemplar:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodEjemplar" runat="server" 
                                        onkeypress="return filterInput(1, event)" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                                <td style="width: 20px">
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="SAC:"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sEstablecimientoCodigo" runat="server" 
                                        AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <table>
                        <tr>
                            <td>
                                <asp:GridView ID="gvEjemplaresEnTransito" runat="server" AllowPaging="True"
                                    PageSize='<%# Util.ObtenerPaginacion() %>' Width="900px" AutoGenerateColumns="False"
                                    DataKeyNames="sCodPrestamo,sCodEjemplar" EmptyDataText="No existen ejemplares en tránsito para en el SAC actual."
                                    OnPageIndexChanging="gvEjemplaresEnTransito_PageIndexChanging" OnRowCommand="gvEjemplaresEnTransito_RowCommand"
                                    OnRowDataBound="gvEjemplaresEnTransito_RowDataBound">
                                    <Columns>
                                        <asp:BoundField DataField="sCodPrestamo" HeaderText="CÓDIGO DE MOVIMIENTO" HeaderStyle-Width="60px"></asp:BoundField>
                                        <asp:BoundField DataField="sCodItem" HeaderText="CÓDIGO DE ÍTEM" HeaderStyle-Width="60px"></asp:BoundField>
                                        <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" HeaderStyle-Width="60px"></asp:BoundField>
                                        <asp:BoundField DataField="sCodSacDevueltoNombre" HeaderText="CENTRO DE DEVOLUCIÓN" ItemStyle-Width="70px"></asp:BoundField>
                                        <asp:BoundField DataField="dFechaDevolucionReal" HeaderText="DEVOLUCIÓN REAL" ItemStyle-Width="90px" ></asp:BoundField>
                                        <asp:BoundField DataField="sCodSacNombre" HeaderText="CENTRO ORIGEN"></asp:BoundField>
                                        <asp:BoundField DataField="dFechaLlegadaSAC" HeaderText="LLEGADA A SAC" HeaderStyle-Width="90px"></asp:BoundField>
                                        <asp:BoundField DataField="SSIUsuario_Creacion" HeaderText="REGISTRADO POR" HeaderStyle-Width="50px"></asp:BoundField>
                                        <asp:BoundField DataField="SSIUsuario_Modificacion" HeaderText="ACTUALIZADO POR" HeaderStyle-Width="50px"></asp:BoundField>
                                        <asp:BoundField DataField="SSIFechaHora_Modificacion" HeaderText="ÚLTIMA ACTUALIZACIÓN" HeaderStyle-Width="50px"></asp:BoundField>
                                        
                                        <asp:TemplateField Visible="true" HeaderText="RECIBIDO SAC">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkRecibidoSACTODOS" runat="server" AutoPostBack="true" OnCheckedChanged="chkRecibidoSACTODOS_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRecibidoSAC" runat="server" AutoPostBack="True" />
                                            </ItemTemplate>
                                            <HeaderStyle Width="20px" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" visible="false">
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
