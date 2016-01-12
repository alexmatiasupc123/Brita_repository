<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_proyectos.aspx.cs" Inherits="Mantenimientos_frm_proyectos" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>


<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="PROYECTOS BRITÁNICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server" Height="780px" SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Proyecto" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 41px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 41px; text-align: left">
                    <asp:TextBox ID="txtTitulo" runat="server" ValidationGroup="Guardar" Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese Título" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="SubTítulo:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:TextBox ID="txtSubtitulo" runat="server" ValidationGroup="Guardar" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Contenido:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 93px; height: 18px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:FileUpload ID="fuImagen" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label8" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb "></asp:Label>
                    <br />
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label>
                    <br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
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
    <asp:GridView ID="gvProyecto" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="proy_codi" DataSourceID="odsProyecto" OnRowDataBound="gvProyecto_RowDataBound"
        OnSelectedIndexChanged="gvProyecto_SelectedIndexChanged" PageSize="10" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("proy_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la Proyecto?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="proy_nomb" HeaderText="T&#237;tulo" SortExpression="proy_nomb" />
            <asp:BoundField DataField="proy_subt" HeaderText="SubT&#237;tulo" SortExpression="proy_subt" />
            <asp:BoundField DataField="proy_desc" HeaderText="Contenido" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsProyecto" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLProyectoNTAD"></asp:ObjectDataSource>
</asp:Content>

