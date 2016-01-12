<%@ Page Title="Dar de baja a ejemplares" Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true"
    CodeFile="PopupDarBajaEjemplares.aspx.cs" Inherits="PopupDarBajaEjemplares" %>
<%@ MasterType VirtualPath="~/_MasterPopup.master" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    Dar de baja a ejemplares
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 730px">
        <div class="panelBotones">
           <uc1:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
            <asp:ImageButton ID="imgbtnAceptar" runat="server" 
                            ImageUrl="~/Comun/Imagenes/Botones/Grabar_A.jpg" 
                            onclick="imgbtnAceptar_Click" />
             <asp:ImageButton ID="ImageCancelar" runat="server" 
                            ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" 
                            onclick="imgbtnCancelar_Click" />                   
        </div>
        <div class="panelBucador">
            <fieldset>
                <legend>Datos del ítem </legend>
                <table width="700px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Código :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodItem" runat="server" Width="180px" Enabled="False"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Título :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitulo" runat="server" Width="265px" Enabled="False"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </fieldset>
            <table width="700px">
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="gvEjemplares" runat="server" AutoGenerateColumns="False" Width="725px"
                            OnRowDataBound="gvEjemplares_RowDataBound" EmptyDataText="No existen ejemplares a dar de baja."
                            PageSize='<%# Util.ObtenerPaginacion() %>' AllowPaging="True" 
                            onpageindexchanging="gvEjemplares_PageIndexChanging">
                            <Columns>
                                <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC" HeaderStyle-Width="150px"/>
                                <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO EJEMPLAR" />
                                <asp:BoundField DataField="sCodArguNombreEstadoEjemplar" HeaderText="ESTADO EJEMPLAR" />
                                <asp:TemplateField HeaderText="DAR DE BAJA">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkDarBaja" runat="server" />
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="2">
                        <asp:HiddenField ID="hfCodItem" runat="server" />
                        <asp:HiddenField ID="hfCodSAC" runat="server" />
                        <%--<asp:Button ID="btnGrabar" runat="server" Text="GRABAR" OnClick="btnGrabar_Click"
                            Enabled="False" />
                        <asp:Button ID="btnSalir" runat="server" Text="SALIR" OnClick="btnSalir_Click" />--%>
                    </td>
                </tr>
            </table>
            <table width="700px">
            <tr>
                   
                    <td colspan="3" align="right" style="width: 350px; margin-right:25px">
                        
                        
                    </td>
                    <td colspan="3" align="left" style="width:350px; margin-left:25px" >
                        
                    </td>
           </tr>
       </table>
        </div>
    </div>
</asp:Content>
