<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaCatalogoArticulos.aspx.cs" Inherits="ListaCatalogoArticulos" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" 
                        BotonNuevoEnabled="False" />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>
                            Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image6" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label13" runat="server" Text="Ver"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend >Filtros </legend>
                        <table>
                            <tr>
                                <td style="width: 150px">
                                    <asp:RadioButtonList ID="rbTipoBusquedas" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rbTipoBusquedas_SelectedIndexChanged">
                                        <asp:ListItem Selected="True">Simple</asp:ListItem>
                                        <asp:ListItem>Avanzada</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td>
                                    <asp:Panel runat="server" ID="pnFiltroSimple">
                                        <table width="700px">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label2" runat="server" Text="Búsqueda :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtBusqueda" runat="server" Width="240px" ></asp:TextBox>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                    
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label1" runat="server" Text="SAC :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSac_BSimple" runat="server" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    <asp:Panel runat="server" ID="pnFiltroAvanzado" Visible="false">
                                        <table width="750px">
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label3" runat="server" Text="Tipo de Ítem :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTipoArticulo" runat="server" Width="240px" 
                                                        AutoPostBack="True" 
                                                        onselectedindexchanged="ddlTipoArticulo_SelectedIndexChanged">
                                                    </asp:DropDownList>
                                                    &nbsp;
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label4" runat="server" Text="SAC :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlSAC" runat="server" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label5" runat="server" Text="Titulo :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtTitulo" runat="server" Width="235px" MaxLength="200"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <asp:Label ID="Label6" runat="server" Text="Código :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtCodItem" runat="server" MaxLength="20" Width="235px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="lblAutor" runat="server" Text="Autor :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlAutor" runat="server" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblISBN" runat="server" Text="ISBN :" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtISBN" runat="server" MaxLength="20" Visible="False" 
                                                        Width="235px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Label ID="Label9" runat="server" Text="Tema :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlTema" runat="server" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                                <td>
                                                    <asp:Label ID="lblISSN" runat="server" Text="ISSN :" Visible="False"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:TextBox ID="txtISSN" runat="server" MaxLength="20" Visible="False" 
                                                        Width="235px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <%--<tr>
                                                <td>
                                                    <asp:Label ID="Label11" runat="server" Text="Estado :"></asp:Label>
                                                </td>
                                                <td>
                                                    <asp:DropDownList ID="ddlEstadoItem" runat="server" Width="240px">
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>--%>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView Width="900px" ID="gvCatalogoItems" runat="server" AutoGenerateColumns="False"
                        OnRowCommand="gvCatalogoItems_RowCommand" OnPageIndexChanging="gvCatalogoItems_PageIndexChanging"
                        OnRowDataBound="gvCatalogoItems_RowDataBound" EmptyDataText="No existen ítems. Ingrese un parametro adicional de búsqueda." AllowPaging="True" PageSize='<%# Util.ObtenerPaginacion() %>'>
                        <Columns>                            
                            <asp:BoundField DataField="sCodItem" HeaderText="CÓDIGO" />
                            <asp:BoundField DataField="sTitulo" HeaderText="TITULO" />
                            <asp:BoundField DataField="sNombreAutores" HeaderText="AUTORES" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sNombreTemas" HeaderText="TEMAS" HtmlEncode="False">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sCantidadDisponibles" HeaderText="CANTIDAD DISPONIBLE">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnVer" runat="server" CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png"
                                        ToolTip="Ver" CommandArgument='<%# Eval("sCodItem") %>' />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
                <asp:HiddenField ID="hfCodArguLibroReader" runat="server" />
                <asp:HiddenField ID="hfCodArguLibroGrammar" runat="server" />
                <asp:HiddenField ID="hfCodArguLibroPaper" runat="server" />
                <asp:HiddenField ID="hfCodArguRevista" runat="server" />
                <asp:HiddenField ID="hfCodArguRecursoElectronico" runat="server" />
                <asp:HiddenField ID="hfCodArguAudioVisual" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
