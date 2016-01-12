<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_producciones.aspx.cs" Inherits="Mantenimientos_frm_producciones" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="PRODUCCIONES BRITÁNICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server" Height="600px" SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Producción" Width="400px"></asp:Label><br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 140px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="1" style="width: 239px; height: 18px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 140px" valign="top">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Año:"></asp:Label>&nbsp;
                </td>
                <td colspan="1" style="width: 239px; height: 18px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:TextBox ID="txtAnio" runat="server" SkinID="Textos" ValidationGroup="Guardar"
                        Width="53px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAnio"
                        ErrorMessage="*Ingrese Año" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAnio"
                        ErrorMessage="Ingrese Año Valido" ForeColor="" SkinID="revError" ValidationExpression="\d{4}"
                        ValidationGroup="Guardar"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 140px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label></td>
                <td colspan="1" style="width: 239px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:TextBox ID="txtTitulo" runat="server" SkinID="Textos" ValidationGroup="Guardar"
                        Width="500px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese Título" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 140px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Contenido:"></asp:Label></td>
                <td colspan="1" style="width: 239px; text-align: left">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 140px">
                </td>
                <td colspan="1" style="width: 239px; text-align: right">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvProducciones" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="prod_codi" DataSourceID="odsProducciones" OnRowDataBound="gvProducciones_RowDataBound"
        OnSelectedIndexChanged="gvProducciones_SelectedIndexChanged" PageSize="10" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("prod_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la Produccion?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="prod_nomb" HeaderText="Nombre" SortExpression="prod_nomb" />
            <asp:BoundField DataField="prod_anio" HeaderText="A&#241;o" SortExpression="prod_anio" />
            <asp:BoundField DataField="prod_desc" HeaderText="Contenido" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsProducciones" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLProduccionesNTAD"></asp:ObjectDataSource>
</asp:Content>

