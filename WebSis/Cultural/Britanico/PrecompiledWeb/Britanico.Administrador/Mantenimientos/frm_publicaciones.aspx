<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_publicaciones, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="PUBLICACIONES BRIT�NICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server" Height="650px" SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Publicaci�n" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="C�digo:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="T�tulo:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:TextBox ID="txtTitulo" runat="server" ValidationGroup="Guardar" Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese T�tulo" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="SubT�tulo:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:TextBox ID="txtSubtitulo" runat="server" ValidationGroup="Guardar" Width="500px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Contenido:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator><br />
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; height: 18px">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvPublicacion" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="publ_codi" DataSourceID="odsPublicacion" OnRowDataBound="gvPublicacion_RowDataBound"
        OnSelectedIndexChanged="gvPublicacion_SelectedIndexChanged" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("publ_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="�Seguro que desea eliminar la publicacion?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="publ_nomb" HeaderText="T&#237;tulo" SortExpression="publ_nomb" />
            <asp:BoundField DataField="publ_subt" HeaderText="SubT&#237;tulo" />
            <asp:BoundField DataField="publ_desc" HeaderText="Contenido" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsPublicacion" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLPublicacionesNTAD"></asp:ObjectDataSource>
</asp:Content>
