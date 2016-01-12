<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_britanicoRadio.aspx.cs" Inherits="Mantenimientos_frm_britanicoRadio" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="BRITÁNICO EN LA RADIO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server" Height="900px" SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 850px">
            <tr>
                <td align="right" style="width: 74px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 74px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Nombre:"></asp:Label></td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="Guardar" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="*Ingrese Nombre" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 74px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 74px">
                </td>
                <td colspan="2" style="width: 700px; text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 74px">
                </td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvBritanicoRadio" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="brad_codi" DataSourceID="odsBritanicoRadio" OnRowDataBound="gvBritanicoRadio_RowDataBound"
        OnSelectedIndexChanged="gvBritanicoRadio_SelectedIndexChanged" PageSize="10" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("brad_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar el registro?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="brad_nomb" HeaderText="Nombre" SortExpression="brad_nomb" />
            <asp:BoundField DataField="brad_desc" HeaderText="Descripci&#243;n" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsBritanicoRadio" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLBritanicoRadioNTAD"></asp:ObjectDataSource>
</asp:Content>

