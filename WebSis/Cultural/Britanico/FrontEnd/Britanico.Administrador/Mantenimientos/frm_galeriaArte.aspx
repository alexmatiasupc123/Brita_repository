<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_galeriaArte.aspx.cs" Inherits="Mantenimientos_frm_galeriaArte" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="GALERÍA DE ARTE BRITÁNICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server"  SkinID="paneles"
        Visible="False" Height="400px">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Galeria"
            Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 18px; text-align: left;">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Nombre:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 18px; text-align: left;">
                    <asp:TextBox ID="txtTitulo" runat="server" SkinID="Textos" ValidationGroup="Guardar"
                        Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese Nombre" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Sede:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 18px; text-align: left;">
                    <asp:DropDownList ID="ddlSede" runat="server" DataSourceID="odsSede" DataTextField="sede_nomb"
                        DataValueField="sede_codi" SkinID="ddlListas" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="camposNombre" Text="Historia:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left; height: 18px;"><FTB:FreeTextBox ID="txtHistoria" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left; height: 18px;">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvGaleria" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="gale_codi" DataSourceID="odsGaleria" OnSelectedIndexChanged="gvGaleria_SelectedIndexChanged"
        SkinID="CGrilla" PageSize="10" OnRowDataBound="gvGaleria_RowDataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("gale_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar el Concurso?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="gale_nomb" HeaderText="Nombre" SortExpression="gale_nomb" />
            <asp:BoundField DataField="sede_nomb" HeaderText="Sede" SortExpression="sede_nomb" >
                <ItemStyle Width="100px" />
            </asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkGaleriaDetalle" runat="server" CommandArgument='<%# Eval("gale_codi") %>'
                        OnClick="lnkGaleriaDetalle_Click" SkinID="lnkPrincipal">Detalle Galeria</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblGaleriaArteDetalle" runat="server" SkinID="lblTitulos"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnCTNuevo" runat="server" OnClick="btnCTNuevo_Click" SkinID="Agregar"
        Visible="False" /><br />
    <asp:Panel ID="pCTNuevo" runat="server" Height="1250px"
        SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccionTemp" runat="server" Text="Agregar Detalle" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="lbleCTCodigo" runat="server" SkinID="camposNombre" Text="Código:"
                        Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;" valign="top" align="left">
                    <asp:Label ID="lblCTCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Nombre:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;" valign="top" align="left">
                    <asp:TextBox ID="txtNombreGaleriaDetalle" runat="server" Width="500px"></asp:TextBox></td>
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
                    <asp:Label ID="Label7" runat="server" SkinID="camposNombre" Text="Fechas:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 78%; HEIGHT: 100%"><TR><TD style="WIDTH: 46px; HEIGHT: 182px" vAlign=top align=left><asp:Calendar id="cFechas" runat="server"></asp:Calendar> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Agregar>>"></asp:Button> <asp:Button id="btnRemove" onclick="btnRemove_Click" runat="server" Text="Remover" ValidationGroup="remover"></asp:Button> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:ListBox id="listaFechas" runat="server" Width="120px" ValidationGroup="Guardar" Rows="10"></asp:ListBox></TD></TR></TABLE><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ForeColor Font-Bold="False" SkinID="rfvError" ValidationGroup="remover" ErrorMessage="*Seleccione Fecha a remover" ControlToValidate="listaFechas"></asp:RequiredFieldValidator> <BR /><asp:Label id="lblErrorFecha" runat="server" Font-Bold="False"></asp:Label> <BR />
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label8" runat="server" SkinID="camposNombre" Text="Detalle Adicional:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <FTB:FreeTextBox ID="txtCTTemporada" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="120px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label9" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left" valign="top" align="left">
                    <asp:FileUpload ID="fuGaleriaArteDetalle" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label6" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb"></asp:Label>
                    <br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label15" runat="server" SkinID="camposNombre" Text="Imagen Agenda:"></asp:Label></td>
                <td align="left" colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:FileUpload ID="fuArchivoAgenda" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label14" runat="server" Text="*Ingrese Imagenes de 64 x 104 pixeles, peso máximo permitido 200kb"
                        Width="449px"></asp:Label><br />
                    <asp:Image ID="aimg" runat="server" /></td>
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
                    <asp:ImageButton ID="btnCTAgregar" runat="server" OnClick="btnCTAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCTGuardar" runat="server" OnClick="btnCTGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCTCancelar" runat="server" OnClick="btnCTCancelar_Click"
                        SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvGaleriaDetalle" runat="server" AutoGenerateColumns="False" DataKeyNames="gade_codi"
        OnSelectedIndexChanged="gvGaleriaDetalle_SelectedIndexChanged" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnCTEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnCTEliminar" runat="server" CommandArgument='<%# Eval("gade_codi") %>'
                        OnClick="btnCTEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la temporada?"
                        TargetControlID="btnCTEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="gade_nomb" HeaderText="Nombre" SortExpression="gade_nomb" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsGaleria" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLGaleriaArteNTAD">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSede" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSedeNTAD">
    </asp:ObjectDataSource>
    <br />
</asp:Content>

