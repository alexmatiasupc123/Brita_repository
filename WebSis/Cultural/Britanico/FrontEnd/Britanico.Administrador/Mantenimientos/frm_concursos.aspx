<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_concursos.aspx.cs" Inherits="Mantenimientos_frm_concursos" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"  %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="CONCURSOS BRITÁNICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />&nbsp;<asp:Panel
        ID="pNuevo" runat="server" Height="600px" SkinID="paneles"
        Visible="False" >
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Concurso" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
        <tr>
                <td align="right" style="width: 100px; height: 18px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <asp:TextBox ID="txtTitulo" runat="server" ValidationGroup="Guardar" Width="500px"></asp:TextBox><br />
                    <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese Título" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="SubTítulo:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;">
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
                    <br />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtContenido"
                        ErrorMessage="*Ingrese Contenido" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left" align="left">
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="gvConcurso" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="conc_codi" DataSourceID="odsConcurso" OnSelectedIndexChanged="gvConcurso_SelectedIndexChanged"
        SkinID="CGrilla" PageSize="10" OnRowDataBound="gvConcurso_RowDataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("conc_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar el Concurso?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="conc_nomb" HeaderText="T&#237;tulo" SortExpression="conc_nomb" >
                <ItemStyle Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="conc_subt" HeaderText="SubT&#237;tulo" SortExpression="conc_subt" />
            <asp:BoundField DataField="conc_desc" HeaderText="Contenido" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkTemporada" runat="server" CommandArgument='<%# Eval("conc_codi") %>'
                        OnClick="lnkTemporada_Click" SkinID="lnkPrincipal">Ver Temporadas</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle Width="100px" />
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <br />
    <asp:Label ID="lblConcursoTemporada" runat="server" SkinID="lblTitulos"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnCTNuevo" runat="server" OnClick="btnCTNuevo_Click" SkinID="Agregar"
        Visible="False" /><br />
    <asp:Panel ID="pCTNuevo" runat="server" Height="1800px"
        SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccionTemp" runat="server" Text="Agregar Temporada" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 379px">
            <tr>
                <td align="right" style="width: 100px; height: 18px">
                    <asp:Label ID="lbleCTCodigo" runat="server" SkinID="camposNombre" Text="Código:"
                        Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <asp:Label ID="lblCTCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label14" runat="server" SkinID="camposNombre" Text="Sede:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <asp:DropDownList ID="ddlSede" runat="server" Width="250px">
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Año:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <asp:TextBox ID="txtAnio" runat="server" ValidationGroup="Guardar" Width="53px"></asp:TextBox><asp:RequiredFieldValidator
                        ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtAnio" ErrorMessage="*Ingrese Año"
                        ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtAnio"
                        ErrorMessage="Ingrese Año Valido" ForeColor="" SkinID="revError" ValidationExpression="\d{4}"
                        ValidationGroup="Guardar"></asp:RegularExpressionValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label7" runat="server" SkinID="camposNombre" Text="Fechas:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left" valign="top">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 78%; HEIGHT: 100%"><TR><TD style="WIDTH: 46px; HEIGHT: 182px" vAlign=top align=left><asp:Calendar id="cFechas" runat="server"></asp:Calendar> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Agregar>>"></asp:Button> <asp:Button id="btnRemove" onclick="btnRemove_Click" runat="server" Text="Remover" ValidationGroup="remover"></asp:Button> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:ListBox id="listaFechas" runat="server" Width="120px" ValidationGroup="Guardar" Rows="10"></asp:ListBox></TD></TR></TABLE><asp:RequiredFieldValidator id="rfv4" runat="server" ForeColor Font-Bold="False" SkinID="rfvError" ValidationGroup="remover" ErrorMessage="*Seleccione Fecha a remover" ControlToValidate="listaFechas"></asp:RequiredFieldValidator> <BR /><asp:Label id="lblErrorFecha" runat="server" Font-Bold="False"></asp:Label> <BR />
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label6" runat="server" SkinID="camposNombre" Text="Bases:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <FTB:FreeTextBox ID="txtCTBases" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 40px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="camposNombre" Text="Premios:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <FTB:FreeTextBox ID="txtPremios" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="100px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 40px" valign="top">
                    <asp:Label ID="Label13" runat="server" SkinID="camposNombre" Text="Detalle Adicional:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <FTB:FreeTextBox ID="txtCTTemporada" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="100px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 40px" valign="top">
                    <asp:Label ID="Label8" runat="server" SkinID="camposNombre" Text="Resultados:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left;">
                    <FTB:FreeTextBox ID="txtResultados" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="100px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                    &nbsp;
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="lblJurado" runat="server" SkinID="camposNombre" Text="Jurado:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <FTB:FreeTextBox ID="txtJurado" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="100px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label9" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:FileUpload ID="fuConcursoTemporada" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label16" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb "></asp:Label><br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                    <asp:Label ID="Label18" runat="server" SkinID="camposNombre" Text="Imagen Agenda:"></asp:Label></td>
                <td colspan="2" style="width: 480px; text-align: left">
                    <asp:FileUpload ID="fuArchivoAgenda" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label17" runat="server" Text="*Ingrese Imagenes de 64 x 104 pixeles, peso máximo permitido 200kb"
                        Width="449px"></asp:Label><br />
                    <asp:Image ID="aimg" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left">
                    &nbsp;
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px">
                </td>
                <td colspan="2" style="width: 480px; text-align: left" align="left">
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
    <asp:GridView ID="gvConcursoTemporada" runat="server" AutoGenerateColumns="False"
        DataKeyNames="ctem_codi" OnSelectedIndexChanged="gvConcursoTemporada_SelectedIndexChanged"
        SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnCTEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnCTEliminar" runat="server" CommandArgument='<%# Eval("ctem_codi") %>'
                        OnClick="btnCTEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la temporada?"
                        TargetControlID="btnCTEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="ctem_anio" HeaderText="A&#241;o" SortExpression="ctem_anio" />
        </Columns>
    </asp:GridView>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsConcurso" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLConcursoNTAD"></asp:ObjectDataSource>
    <br />
</asp:Content>

