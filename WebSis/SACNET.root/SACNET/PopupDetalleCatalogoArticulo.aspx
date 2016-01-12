<%@ Page Title="Detalle del Ítem." Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true"
    CodeFile="PopupDetalleCatalogoArticulo.aspx.cs" Inherits="PopupDetalleCatalogoArticulo"
    EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    Detalle del Ítem.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 800px;">
        <div class="panelBotones">
            <asp:ImageButton ID="btnSalir" runat="server" ToolTip="Regresar"
            ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" />   
        </div>
        <div class="panelGria">
            <asp:Panel ID="pnDatosDetalle" runat="server">
                <div style="width: 800px">
                    <fieldset>
                    <legend >Detalle Ítem</legend>
                    <table width="770px">
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Text="Código :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:TextBox ID="txtCodItem" runat="server" ReadOnly="True" Width="250px" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                            <td colspan="2" style="width: 160px">
                                <asp:Label ID="Label8" runat="server" Text="Imagen :"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" Text="Titulo :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:TextBox ID="txtTitulo" runat="server" ReadOnly="True" Width="250px" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                            <td rowspan="4" colspan="2" style="text-align: center; width: 146px; top: 2px;" valign="top" align="center">
                               <div style="position:relative;left:50px; top: 10px; width: 146px;">
                                <asp:Image ID="imgFotografia" runat="server" Height="100px" Width="100px" />
                               </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="lblAutores_Actores" runat="server" Text="Autores /Actores :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                    <div class="cssTextBoxSinBorde" style="width:250px;height:40px;">
                                    <asp:Literal ID="lblDAutores_Actores" runat="server" Text="Label" 
                                            ></asp:Literal>
                                        
                                    </div>
                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="labelPieImp" runat="server" Text="Pié de Imprenta / Audiencia :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:TextBox ID="txtPieImprenta_Audiencia" runat="server" ReadOnly="True" 
                                    Width="250px" BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label5" runat="server" Text="Temas :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <div class="cssTextBoxSinBorde" style="width:250px;height:40px;">
                                    <asp:Literal ID="lblTemas" runat="server" Text="Label" 
                                            ></asp:Literal>
                                        
                                    </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label6" runat="server" Text="Resumen :"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 130px">
                                <asp:TextBox ID="txtResumen" runat="server" Height="60px" TextMode="MultiLine" 
                                    Width="550px" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 146px">
                                <asp:Label ID="Label26" runat="server" Text="Notas :"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 130px">
                                <asp:TextBox ID="txtNotas" runat="server" Height="30px" TextMode="MultiLine" 
                                    Width="550px" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 146px">
                                <asp:Label ID="Label27" runat="server" Text="Formato Adicional :"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 130px">
                                <asp:TextBox ID="txtFormatoAdicional" runat="server" BorderStyle="None" 
                                    Height="30px" ReadOnly="True" TextMode="MultiLine" Width="550px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trReqTenico" runat="server">
                            <td>
                                <asp:Label ID="Label4" runat="server" Text="Requisitos Técnicos :"></asp:Label>
                            </td>
                            <td colspan="3" style="width: 130px">
                                <asp:TextBox ID="txtReqTecnicos" runat="server" Height="40px" TextMode="MultiLine"
                                    Width="550px" ReadOnly="True" BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="trGeneroDuracion" runat="server">
                            <td>
                                <asp:Label ID="lblGenero" runat="server" Text="Género :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:TextBox ID="txtGenero" runat="server" ReadOnly="True" Width="220px" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Label ID="lblDuracion" runat="server" Text="Duración :"></asp:Label>
                            </td>
                            <td style="width: 150px">
                                <asp:TextBox ID="txtDuracion" runat="server" ReadOnly="True" Width="220px" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Text="Cantidad Disponible :"></asp:Label>
                            </td>
                            <td style="width: 238px">
                                <asp:TextBox ID="txtCantidadDisponible" runat="server" ReadOnly="True" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Label ID="Label20" runat="server" Text="Cantidad en Préstamo :"></asp:Label>
                            </td>
                            <td style="width: 230px">
                                <asp:TextBox ID="txtCantidadEnPrestamo" runat="server" BorderStyle="None"></asp:TextBox>
                            </td>
                            <td style="width: 150px">
                                <asp:Label ID="Label22" runat="server" Text="Cantidad en Reserva :"></asp:Label>
                            </td>
                            <td style="width: 240px">
                                <asp:TextBox ID="txtCantidadEnReserva" runat="server" ReadOnly="True" 
                                    BorderStyle="None"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                    <br />
                    <asp:GridView ID="gvEjemplares" runat="server" AutoGenerateColumns="False" 
                        PageSize='<%# Util.ObtenerPaginacion() %>' Width="770px" AllowPaging="true" 
                        onpageindexchanging="gvEjemplares_PageIndexChanging" 
                            onrowdatabound="gvEjemplares_RowDataBound" >
                    <Columns>
                        <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC" />
                        <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" />
                        <asp:BoundField DataField="dFechaPrestamo" HeaderText="FECHA PRESTAMO" />
                        <asp:TemplateField HeaderText="RESERVADO" HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# PintarEstado(Convert.ToBoolean(Eval("bReservado")))%>
                            </ItemTemplate>
                            <HeaderStyle Width="30px" />
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                                    
                        <asp:BoundField DataField="dFechaDevolucionEstimada" HeaderText="FECHA DEVOLUCIÓN" />
                        <asp:BoundField DataField="sNotas" HeaderText="NOTAS" />
                        <asp:BoundField DataField="sCodArguNombreEstadoEjemplar" HeaderText="ESTADO" />
                    </Columns>
                </asp:GridView>
                    <br />
                    </fieldset>
                </div>
            </asp:Panel>
         </div>   
    </div>
</asp:Content>
