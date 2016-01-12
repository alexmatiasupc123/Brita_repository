<%@ Page Title="Transferencia de ejemplares." Language="C#" MasterPageFile="~/_MasterPage.master"
    AutoEventWireup="true" CodeFile="MantTransferenciaEjemplares.aspx.cs" Inherits="MantTransferenciaEjemplares" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="ucAuditoria" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    Transferencia de ejemplares.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <table>
            <tr>
                <td>
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <asp:HiddenField ID="hfEvento" runat="server" />
                    <asp:HiddenField ID="hfCodTransferencia" runat="server" />
                    <asp:HiddenField ID="hfParameters" runat="server" />
                </td>
            </tr>
        </table>
        <fieldset>
            <legend>Registro Transferencia </legend>
            <asp:Panel ID="pnRegistroTransferencia" runat="server">
                <table width="870px">
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="SAC Orígen :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSacOrigen" runat="server" AutoPostBack="True" 
                                onselectedindexchanged="ddlSacOrigen_SelectedIndexChanged">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="SAC Destino :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSacDestino" runat="server" 
                               >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr id="TrTransferenciaPost" runat="server">
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Usuario SAC :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuarioSacOrigen" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label8" runat="server" Text="Usuario SAC :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuarioSacDestino" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Usuario Solicitante :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtUsuarioSolicitante" runat="server" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Fecha Proceso :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaProcesoSolicitud" runat="server" Width="95px" Enabled="False">01/07/2010</asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Estado Solicitud:"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoTransferencia" runat="server" Enabled="False">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Código de Ítem :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigoItem" runat="server" Width="200px" MaxLength="20"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnBuscarEjemplar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/Buscar_A.jpg"
                                ToolTip="Buscar el código de ítem" OnClick="btnBuscarEjemplar_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Código de Ejemplar :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCodigoEjemplar" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:ImageButton ID="btnAgregar" runat="server" ToolTip="Agregar el item a la lista"
                                ImageUrl="~/Comun/Imagenes/Botones/Agregar_A.png" 
                                OnClick="btnAgregar_Click" />
                        </td>
                        <td>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <table>
                <tr>
                    <td colspan="4">
                        <asp:GridView ID="gvEjemplaresATransferir" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="sCodTransferencia" OnRowCommand="gvEjemplaresATransferir_RowCommand"
                            EmptyDataText="No existen ejemplares a transferir." Width="850px" 
                            PageSize='<%# Util.ObtenerPaginacion() %>' 
                            onrowdatabound="gvEjemplaresATransferir_RowDataBound">
                            <Columns>
                                <asp:BoundField DataField="sCodTransferencia" HeaderText="CodTransferencia" Visible="False" />
                                <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC" HeaderStyle-Width="230px">
                                    <HeaderStyle Width="230px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" HeaderStyle-Width="300px">
                                    <HeaderStyle Width="300px"></HeaderStyle>
                                </asp:BoundField>
                                <asp:BoundField DataField="sCodItem" HeaderText="ITEM" />
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:ImageButton ID="btnEliminar" runat="server" CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                            ToolTip="Eliminar." CommandArgument='<%# Eval("sCodEjemplar") +"%"+Eval("sCodTransferencia") %>' />
                                        <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                            ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True"
                                            TargetControlID="btnEliminar">
                                        </cc1:ConfirmButtonExtender>
                                    </ItemTemplate>
                                    <HeaderStyle Width="30px" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                    </td>
                </tr>
            </table>
        </fieldset>
        <uc3:ucAuditoria ID="ucAuditoria1" runat="server" />
    </div>
</asp:Content>
