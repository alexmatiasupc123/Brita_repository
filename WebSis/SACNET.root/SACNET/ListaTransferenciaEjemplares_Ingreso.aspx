<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaTransferenciaEjemplares_Ingreso.aspx.cs" Inherits="ListaTransferenciaEjemplares_Ingreso" %>
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
                            Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/ver_detalle.jpg"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Ver ejemplares a ingresar."></asp:Label>
                                </td>                               
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend >Filtros</legend>
                        <table width="850px">
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
                    <asp:GridView Width="900px" ID="gvSolicitudTrasnferencia" runat="server" 
                        AutoGenerateColumns="False" AllowPaging="True"
                        OnRowCommand="gvSolicitudTrasnferencia_RowCommand"
                        EmptyDataText="No existen solicitudes de transferencia de ingreso." 
                        onpageindexchanging="gvSolicitudTrasnferencia_PageIndexChanging" 
                        PageSize='<%# Util.ObtenerPaginacion() %>'>
                        <Columns>
                            <asp:BoundField DataField="sCodTransferencia" HeaderText="CÓDIGO TRANSFER." />
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
                                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodTransferencia") %>'
                                        CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/ver_detalle.jpg" 
                                        
                                        ToolTip="Ver ejemplares a ingresar." />
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
