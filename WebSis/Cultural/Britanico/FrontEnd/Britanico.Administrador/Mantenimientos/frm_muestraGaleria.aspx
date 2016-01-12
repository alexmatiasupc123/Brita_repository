<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_muestraGaleria.aspx.cs" Inherits="Mantenimientos_frm_muestraGaleria" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="GALERÍA DE ARTE BRITÁNICO - MUESTRAS ANTERIORES"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" /><br />
    <asp:Panel ID="pNuevo" runat="server" Height="700px"
        SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="lbleCodigo" runat="server" SkinID="camposNombre" Text="Código:"
                        Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;" valign="top" align="left">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Galeria:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:DropDownList ID="ddlGaleria" runat="server" DataSourceID="odsGaleria" DataTextField="gale_nomb"
                        DataValueField="gale_codi">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Año:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:TextBox ID="txtAnio" runat="server" Width="70px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAnio"
                        ErrorMessage="Ingrese el Año" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAnio"
                        ErrorMessage="Ingrese Año valido" SkinID="revError" ValidationExpression="\d{4}"
                        ValidationGroup="Guardar"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Nombre:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;" valign="top" align="left">
                    <asp:TextBox ID="txtNombre" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="Ingrese Nombre" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label9" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left" valign="top" align="left">
                    <asp:FileUpload ID="fuImagen" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label6" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb"></asp:Label>
                    <br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                </td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                </td>
                <td colspan="2" style="width: 480px; text-align: left" valign="top" align="left">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click"
                        SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvMuestraGaleria" runat="server" AutoGenerateColumns="False" DataKeyNames="mues_codi"
        OnSelectedIndexChanged="gvMuestraGaleria_SelectedIndexChanged" SkinID="CGrilla" DataSourceID="odsMuestraGaleria">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnCTEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnCTEliminar" runat="server" CommandArgument='<%# Eval("mues_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la muestra?"
                        TargetControlID="btnCTEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="mues_nomb" HeaderText="Nombre" SortExpression="mues_nomb" />
            <asp:BoundField DataField="gale_nomb" HeaderText="Galeria" SortExpression="gale_nomb" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsGaleria" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLGaleriaArteNTAD">
    </asp:ObjectDataSource>
    <br />
    <asp:ObjectDataSource ID="odsMuestraGaleria" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLMuestraGaleriaNTAD"></asp:ObjectDataSource>
    &nbsp;
    <br />
</asp:Content>

