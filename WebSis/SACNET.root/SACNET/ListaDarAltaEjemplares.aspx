﻿<%@ Page Title="Lista de ítems - Ejemplares a dar de alta." Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaDarAltaEjemplares.aspx.cs" Inherits="ListaDarBajaEjemplares" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionLista.ascx" TagName="BotonesEdicionLista"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    Lista de ítems - Ejemplares a dar de alta.
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 900px;">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc2:MessageBox ID="MessageBox1" runat="server" />
                    <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
                </div>
                <div class="panelleyenda">
                    <fieldset>
                        <legend>Leyenda</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Image ID="Image4" runat="server" ImageUrl="~/Comun/Imagenes/Icons/arrow_right.png"
                                        Width="16px" />
                                </td>
                                <td>
                                    <asp:Label ID="Label11" runat="server" Text="Visualizar los Ejemplares."></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 870px">
                        <legend>Filtros </legend>
                        <table width="850px">
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Tipo de Ítem :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoArticulo" runat="server" AutoPostBack="True" 
                                        onselectedindexchanged="ddlTipoArticulo_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Código :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodItem" runat="server" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Titulo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtTitulo" runat="server" Width="195px"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblISBN" runat="server" Text="ISBN :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtISBN" runat="server" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAutor" runat="server" Text="Autor :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlAutor" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblISSN" runat="server" Text="ISSN :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtISSN" runat="server" Width="195px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Tema :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTema" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </fieldset>
                </div>
                <div class="panelGria">
                    <asp:GridView ID="gvItems" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gvItems_PageIndexChanging"
                        Width="900px" OnRowDataBound="gvItems_RowDataBound" AllowPaging="True" EmptyDataText="No existen ítems a dar de alta." PageSize='<%# Util.ObtenerPaginacion() %>'>
                        <Columns>
                            <asp:BoundField DataField="sCodSacNombre" HeaderText="SAC" Visible="false" />
                            <asp:BoundField DataField="sCodItem" HeaderText="CÓDIGO" />
                            <asp:BoundField DataField="sTitulo" HeaderText="TITULO" />
                            <asp:BoundField DataField="sNombreAutores" HeaderText="AUTORES" HtmlEncode="False" />
                            <asp:BoundField DataField="sNombreTemas" HeaderText="TEMAS" HtmlEncode="False" />
                            <asp:BoundField DataField="sCodArguNombreEstadoItem" HeaderText="ESTADO" />
                            <asp:BoundField DataField="TotalEjemplares" HeaderText="TOTAL EJEMPLARES" ItemStyle-HorizontalAlign="Center" 
                                HeaderStyle-Width="80px" >
                                <HeaderStyle Width="80px"></HeaderStyle>
                            </asp:BoundField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="btnSelect" runat="server" CommandArgument='<%# Eval("sCodItem") %>'
                                        CommandName="Select" ImageUrl="~/Comun/Imagenes/Icons/arrow_right.png" 
                                        ToolTip="Visualizar los ejemplares." onclick="btnSelect_Click" />
                                </ItemTemplate>
                                <HeaderStyle Width="30px" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                <asp:HiddenField ID="hfCodArguLibroReader" runat="server" />
                <asp:HiddenField ID="hfCodArguLibroGrammar" runat="server" />
                <asp:HiddenField ID="hfCodArguLibroPaper" runat="server" />
                <asp:HiddenField ID="hfCodArguRevista" runat="server" />
                <asp:HiddenField ID="hfCodArguRecursoElectronico" runat="server" />
                <asp:HiddenField ID="hfCodArguAudioVisual" runat="server" />
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
