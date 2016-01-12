<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ListaArticulo.aspx.cs" Inherits="ListaArticulo" %>
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
    <div style="width: 900px;">
        <div class="panelBotones">
            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
            <uc1:BotonesEdicionLista ID="BotonesEdicionLista1" runat="server" />
            
        </div>
        <div class="panelleyenda">
            <fieldset>
                <legend>
                    <asp:Label ID="Label10" runat="server" Text="Leyenda"></asp:Label></legend>
                <table>
                    <tr>
                         <td>
                            <asp:Image ID="Ley_ImgVer" runat="server" 
                                 ImageUrl="~/Comun/Imagenes/Icons/Ver.png" Width="16px" />
                        </td>
                        <td>
                            <asp:Label ID="Ley_lblVer" runat="server" Text="Ver"></asp:Label>
                        </td>
                        <td>
                            <asp:Image ID="Ley_ImgEditar" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Edit.png"
                                Width="16px" />
                        </td>
                        <td>
                            <asp:Label ID="Ley_lblEditar" runat="server" Text="Editar"></asp:Label>
                        </td>
                        <td>
                        </td>
                        <td>
                            <asp:Image ID="Ley_ImgEliminar" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Delete.png"
                                Width="16px" />
                        </td>
                        <td>
                            <asp:Label ID="Ley_lblEliminar" runat="server" Text="Eliminar"></asp:Label>
                        </td>
                        <td>
                        </td>
                       
                        
                        
                    </tr>
                </table>
            </fieldset>
        </div>
        <div class="panelBucador">
            <fieldset style="width: 870px">
                <legend style="font-weight: bold">Filtros </legend>
                <table width="800px">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Tipo de Ítem :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoArticulo" runat="server" 
                                onselectedindexchanged="ddlTipoArticulo_SelectedIndexChanged" 
                                AutoPostBack="True">
                            </asp:DropDownList>
                        </td>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="SAC :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlSAC" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Titulo :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtTitulo" runat="server" Width="195px" MaxLength="200" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:Label ID="Label4" runat="server" Text="Código :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodItem" runat="server" MaxLength="20" Width="195px"></asp:TextBox>
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
                            <asp:Label ID="lblISBN" runat="server" Text="ISBN :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtISBN" runat="server" MaxLength="20" Width="195px"></asp:TextBox>
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
                            <asp:Label ID="lblISSN" runat="server" Text="ISSN :"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="txtISSN" runat="server" MaxLength="20" Width="195px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label9" runat="server" Text="Estado :"></asp:Label>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoItem" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td></td>
                        <td>
                                    
                                </td>
                    </tr>
                </table>
            </fieldset>
        </div>
        <%--& " - " & Eval("sCodSac")--%>
        <div class="panelGria">
            <asp:GridView Width="900px" ID="gvItems" runat="server" AutoGenerateColumns="False"
                OnPageIndexChanging="gvItems_PageIndexChanging"  OnRowCommand="gvItems_RowCommand" AllowPaging="True"
                EmptyDataText="No existen ítems a mostrar." PageSize='<%# Util.ObtenerPaginacion() %>' >
                <Columns>
                    
                    <asp:BoundField DataField="sCodItem" HeaderText="CÓDIGO" />
                    <asp:BoundField DataField="sTitulo" HeaderText="TITULO" />
                    <asp:BoundField DataField="sNombreAutores" HeaderText="AUTORES" HtmlEncode="False" />
                    <asp:BoundField DataField="sNombreTemas" HeaderText="TEMAS" HtmlEncode="False" />
                    <asp:BoundField DataField="sCodArguNombreEstadoItem" HeaderText="ESTADO" />
                    <asp:BoundField DataField="TotalEjemplares" HeaderText="TOTAL EJEMPLARES"  ItemStyle-HorizontalAlign="Center" 
                        HeaderStyle-Width="80px" >
                        <HeaderStyle Width="80px"></HeaderStyle>
                    </asp:BoundField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%#Eval("sCodItemsCodSac")%>' 
                                CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" 
                                ToolTip="Ver" />
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodItemsCodSac") %>'
                                CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" 
                                ToolTip="Editar" />
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("sCodItemsCodSac") %>'
                                CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" 
                                ToolTip="Eliminar" />
                            <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                ConfirmText="¿ Confirmar la eliminación completa del registro ?" Enabled="True" TargetControlID="btnEliminar">
                            </cc1:ConfirmButtonExtender>
                        </ItemTemplate>
                        <HeaderStyle Width="30px" />
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:BoundField DataField="sCodItemsCodSac" HeaderText="COD SAC" Visible="false" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:HiddenField ID="hfCodArguLibroReader" runat="server" />
        <asp:HiddenField ID="hfCodArguLibroGrammar" runat="server" />
        <asp:HiddenField ID="hfCodArguLibroPaper" runat="server" />
        <asp:HiddenField ID="hfCodArguRevista" runat="server" />
        <asp:HiddenField ID="hfCodArguRecursoElectronico" runat="server" />
        <asp:HiddenField ID="hfCodArguAudioVisual" runat="server" />
    </div>
</asp:Content>
