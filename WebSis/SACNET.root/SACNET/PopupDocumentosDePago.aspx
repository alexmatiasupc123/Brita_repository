<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true" CodeFile="PopupDocumentosDePago.aspx.cs" Inherits="PopupDocumentosDePago" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" Runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Documentos de pago emitidos"></asp:Literal>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div style="width:730px">    

    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="panelBotones">
             <asp:ImageButton ID="imgbtnAceptar" runat="server" 
                                    ImageUrl="~/Comun/Imagenes/Botones/Confirmar_I.jpg" 
                                    onclick="imgbtnAceptar_Click" />
 
              <asp:ImageButton ID="ImageCancelar" runat="server" 
                                    ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" 
                                    onclick="imgbtnCancelar_Click" />                 
    </div>
    <div class="panelGria">
        <asp:Panel ID="pnDatosDetalle" runat="server">
            <div>
                <fieldset>
                    <legend>Seleccionar Documento</legend>
                    <table width="700px">
                        <tr>
                            <td>
                                <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                                <asp:HiddenField ID="HF_CodUsuarioSAC" runat="server" />
                                <asp:GridView ID="gvPagosUsuarios" runat="server" AutoGenerateColumns="False" 
                                    onrowdatabound="gvPagosUsuarios_RowDataBound" Width="700px" 
                                    PageSize='<%# Util.ObtenerPaginacion() %>' AllowPaging="True" 
                                    onpageindexchanging="gvPagosUsuarios_PageIndexChanging">
                                    <Columns>
                                        <asp:BoundField DataField="CodUsuarioSAC" HeaderText="CODIGO USUARIO SAC" />
                                        <asp:BoundField DataField="TipoDocuNumero" HeaderText="DOCUMENTO" ItemStyle-Width="150px" />
                                        <asp:BoundField DataField="UsuarioRealizoPago" HeaderText="GENERADO POR" />
                                        <asp:BoundField DataField="EstablecimientoCodNom" HeaderText="CENTRO"  
                                            HeaderStyle-Width="120px" >
                                            <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FechaFacturacion" HeaderText="FECHA DE EMISIÓN" ItemStyle-Width="130px" />
                                        <asp:TemplateField HeaderText="SELECCIONAR DOCUMENTO" Visible="true" ItemStyle-HorizontalAlign="Center">
                                            <ItemTemplate>
                                            <asp:CheckBox ID="CheckBoxSelect" runat="server" 
                                                oncheckedchanged="CheckBoxSelect_CheckedChanged" AutoPostBack="True" 
                                                ValidationGroup="Un" />
                                            </ItemTemplate>
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        
                        
                    </table>
                    <table width="700px">
                        <tr>
                               
                                <td align="right" style="width: 350px; margin-right:25px">
                                   
                                    
                                </td>
                                <td align="left" style="width:350px; margin-left:25px" >
                                     
                                </td>
                       </tr>
                    </table>   
                </fieldset>
            </div>
        </asp:Panel>
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </div>
</asp:Content>

