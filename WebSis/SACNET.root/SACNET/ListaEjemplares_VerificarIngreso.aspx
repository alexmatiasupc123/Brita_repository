<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaEjemplares_VerificarIngreso.aspx.cs" Inherits="ListaEjemplares_VerificarRetiro" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <div class="panelBotones">
            <asp:ImageButton ID="btnGenerarIngreso" runat="server" 
                            ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" 
                            onclick="btnGenerarIngreso_Click" />
            <asp:ImageButton ID="btnRegresar" runat="server" 
                            ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" 
                            onclick="imgbtnCancelar_Click" />   
            <uc1:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
        </div>
        <div class="panelBucador">
            <fieldset style="width: 870px">
                <legend>Datos de la Transferencia </legend>
                <table width="850px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Código Transferencia :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodTransferencia" runat="server" Width="150px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Solicitado Por :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSolicitadoPor" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label7" runat="server" Text="SAC Orígen :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSacOrigen" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="SAC Destino :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtSacDestino" runat="server" Width="150px" ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label6" runat="server" Text="Fecha Proceso :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaProcesoSolicitud" runat="server" Width="150px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label5" runat="server" Text="Estado Transferencia:"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtEstadoTransferencia" runat="server" Width="150px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Fecha Retiro :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtFechaProcesoRetiro" runat="server" Width="150px" 
                                ReadOnly="True"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <%-- Listado de Ejemplares para Transferencia--%>
        <div class="panelGria">
            <asp:GridView ID="gvItemsTransferencia_Ingreso" runat="server" AutoGenerateColumns="False"
                Width="900px" EmptyDataText="No existen ejemplares a ingresar." AllowPaging="True"
                OnPageIndexChanging="gvItemsTransferencia_Ingreso_PageIndexChanging" PageSize='<%# Util.ObtenerPaginacion() %>'>
                <Columns>
                    <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sCodItem" HeaderText="CÓDIGO ÍTEM">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="sTituloItem" HeaderText="NOMBRE TITULO">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SSIFechaHora_Creacion" HeaderText="FECHA REGISTRO">
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:BoundField>
                    <asp:TemplateField HeaderText="INGRESAR EJEMPLAR">
                        <ItemTemplate>
                            <asp:CheckBox ID="chkIngreso" runat="server" />
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            
        </div>
        <center style="width:850px">
        <br />
                
                <asp:HiddenField ID="HfCodSacDestino" runat="server" />
                <asp:HiddenField ID="hfParameters" runat="server" />
        </center>
       
    </div>
</asp:Content>
