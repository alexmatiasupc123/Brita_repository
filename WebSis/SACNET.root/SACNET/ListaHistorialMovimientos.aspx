<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaHistorialMovimientos.aspx.cs" Inherits="ListaHistorialMovimientos" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Historial de Movimientos"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend >Filtros</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoINI" runat="server" />
                                </td>
                                <td style="width:40px"></td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                    <uc3:ucTextBoxFecha ID="prm_dFechaProcesoFIN" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Código de usuario :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodUsuarioSAC" runat="server" Width="195px"  
                                        MaxLength="20"></asp:TextBox>
                                </td>
                                <td style="width:40px"></td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Apellidos y nombres :"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="prm_sNombresUsuarioSAC" runat="server" Width="195px" 
                                        MaxLength="50" onkeypress="return filterInput(0, event)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Título :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="prm_sCodEjemplarTitulo" runat="server" Width="195px" 
                                        MaxLength="20" onkeypress="return filterInput(0, event)"></asp:TextBox>
                                </td>
                                <td style="width:40px"></td>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Tipo de movimiento :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguTipoMovimi" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:CheckBox ID="CheckBoxSinCarnet" runat="server" AutoPostBack="True" Checked="True"
                                        OnCheckedChanged="CheckBoxConCarnet_CheckedChanged" Text="Sin carné :" 
                                        TextAlign="Left" Visible="False" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="SAC :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sEstablecimientoCodigo" runat="server" AppendDataBoundItems="True">
                                    </asp:DropDownList>
                                </td>
                                <td style="width:40px"></td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Préstamo en :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="prm_sCodArguPrestamoEn" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td align="right">
                                    <asp:CheckBox ID="CheckBoxConCarnet" runat="server" Text="Con carné :" TextAlign="Left"
                                        AutoPostBack="True" Checked="True" 
                                        OnCheckedChanged="CheckBoxConCarnet_CheckedChanged" Visible="False">
                                    </asp:CheckBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelHistorial">
                    <asp:GridView Width="900px" ID="gvHistorialMovimientos" runat="server" 
                        AutoGenerateColumns="False" AllowPaging="True" PageSize='<%# Util.ObtenerPaginacion() %>' 
                        OnPageIndexChanging="gvHistorialMovimientos_PageIndexChanging" OnRowDataBound="gvHistorialMovimientos_RowDataBound"
                        EmptyDataText="No se encontraron registros de historial de movimientos." 
                        DataKeyNames="sCodPrestamo" CssClass="cssGridView1" >
                        <Columns>
                            <asp:BoundField DataField="sCodPrestamo" HeaderText="Cod.Mov">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodEjemplar" HeaderText="Ejem.">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodEjemplarNombreTitulo" HeaderText="Título">
                                <ItemStyle Width="7px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sAbreviaturaSac" HeaderText="SAC">
                                <ItemStyle Width="1px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodUsuarioSAC" HeaderText="Cod.Usu">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodUsuarioSACNombres" HeaderText="Usu SAC">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dFechaPrestamo" HeaderText="Préstamo">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                             <asp:BoundField DataField="SSIUSUARIO_CREACION" HeaderText="Usu Préstamo">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dFechaDevolucionEstimada" HeaderText="Dev.Est">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="dFechaDevolucionReal" HeaderText="Dev.Real">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="SSIUSUARIO_MODIFICACION" HeaderText="Usu Devolución">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCodArguPrestamoEnNombre" HeaderText="Prést. en">
                                <ItemStyle Width="5px" Wrap="True" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sEstadoRegistro" HeaderText="Tipo Mov.">
                                <ItemStyle Width="3px" Wrap="True" />
                            </asp:BoundField>
                           
                            
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
        <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
            TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
            Enabled="True">
        </cc2:UpdatePanelJavaScriptExtender>
    </div>
</asp:Content>
