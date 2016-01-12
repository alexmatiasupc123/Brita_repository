<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaTransferenciaEjemplares.aspx.cs" Inherits="ListaTransferenciaEjemplares" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>
                            <asp:Label ID="Label5" runat="server" Text="Leyenda"></asp:Label></legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Leyd_ImgVer" runat="server" 
                                        ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Leyd_lblVer" runat="server" Text="Ver"></asp:Label>
                                </td>
                                <td>
                                    <asp:Image ID="Leyd_ImgEditar" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Leyd_lblEditar" runat="server" Text="Editar"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Image ID="Leyd_ImgEliminar" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Leyd_lblEliminar" runat="server" Text="Eliminar"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend >Filtros</legend>
                        <table width="800px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Fecha desde :"></asp:Label>
                                </td>
                                <td>
                                <uc3:ucTextBoxFecha ID="txtFechaProcesoDesde" runat="server" />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Fecha hasta :"></asp:Label>
                                </td>
                                <td>
                                 <uc3:ucTextBoxFecha ID="txtFechaProcesoHasta" runat="server" />                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoTransferencia" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Código de transferencia:"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodTransferencia" runat="server" MaxLength="10"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="SAC Origen :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSacOrigen" runat="server">
                                    </asp:DropDownList>
                                    <br />
                                </td>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="SAC Destino :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlSacDestino" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView Width="900px" ID="gvSolicitudTrasnferencia" runat="server" AutoGenerateColumns="False"
                        OnRowCommand="gvSolicitudTrasnferencia_RowCommand" OnRowDataBound="gvSolicitudTrasnferencia_RowDataBound"
                        EmptyDataText="No existen solicitudes de transferencia." 
                        AllowPaging="True" 
                        onpageindexchanging="gvSolicitudTrasnferencia_PageIndexChanging" PageSize='<%# Util.ObtenerPaginacion() %>' >
                        <Columns>
                            <asp:BoundField DataField="sCodTransferencia" HeaderText="CODIGO TRANSFER." />
                            <asp:BoundField DataField="dFechaProcesoSolicitud" HeaderText="FECHA SOLICITUD" 
                                DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="sUsuarioSolicitante" HeaderText="USUARIO SOLIC." />
                            <asp:BoundField DataField="sNombreLocalOrigen" HeaderText="SAC ORIGEN" />
                            <asp:BoundField DataField="sUsuarioSacOrigen" HeaderText="USUARIO ORIGEN" />
                            <asp:BoundField DataField="sNombreLocalDestino" HeaderText="SAC DESTINO" />
                            <asp:BoundField DataField="sUsuarioSacDestino" HeaderText="USUARIO DESTINO" />
                            <asp:BoundField DataField="sCodArguNombreEstadoTransferencia" HeaderText="ESTADO" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodTransferencia") %>'
                                        CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="Ver registro de transferencia" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodTransferencia") %>'
                                        CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" ToolTip="Editar registro de transferencia" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("sCodTransferencia") %>'
                                        CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" ToolTip="Eliminar registro de transferencia" />
                                    <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                        ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True" TargetControlID="btnEliminar">
                                    </cc1:ConfirmButtonExtender>
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="sCodArguEstadoTransferencia" HeaderText="sCodArguEstadoTransferencia"
                                Visible="False" />
                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
