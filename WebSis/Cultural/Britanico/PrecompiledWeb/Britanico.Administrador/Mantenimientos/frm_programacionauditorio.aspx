<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_programacionauditorio, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="PROGRAMACIÓN DE AUDITORIO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" /><asp:Panel
        ID="pNuevo" runat="server"  Height="1300px"
        SkinID="paneles" Visible="False" >
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Programación Auditorio"
            Width="400px"></asp:Label><br />
        <br />
        <table style="width: 550px">
            <tr>
                <td align="right" style="width: 120px; height: 20px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Sede:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:DropDownList ID="ddlSede" runat="server" AutoPostBack="True" DataSourceID="odsSede"
                        DataTextField="sede_nomb" DataValueField="sede_codi" SkinID="ddlListas" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Título:" EnableViewState="False"></asp:Label>
                </td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:TextBox ID="txtNombre" runat="server" Width="500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                  <FTB:FreeTextBox id="txtDescripcion" runat="server" Width="500px" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll" DownLevelCols="50" ButtonSet="Office2003" AutoParseStyles="True"></FTB:FreeTextBox>
</td>

            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px" valign="top">
                    <asp:Label ID="Label6" runat="server" SkinID="camposNombre" Text="Fechas:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px" valign="top">
                </td>
                <td colspan="2" style="width: 400px; height: 20px" valign="top">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 78%; HEIGHT: 100%"><TR><TD style="WIDTH: 46px; HEIGHT: 182px" vAlign=top align=left><asp:Calendar id="cFechas" runat="server"></asp:Calendar> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Agregar>>"></asp:Button> <asp:Button id="btnRemove" onclick="btnRemove_Click" runat="server" Text="Remover" ValidationGroup="remover"></asp:Button> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:ListBox id="listaFechas" runat="server" Width="120px" ValidationGroup="Guardar" Rows="10"></asp:ListBox></TD></TR></TABLE><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ForeColor Font-Bold="False" SkinID="rfvError" ValidationGroup="remover" ErrorMessage="*Seleccione Fecha a remover" ControlToValidate="listaFechas"></asp:RequiredFieldValidator> <BR /><asp:Label id="lblErrorFecha" runat="server" Font-Bold="False"></asp:Label> <BR />
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px" valign="top">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Detalle Adicional:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px"><FTB:FreeTextBox id="txtTemporada" runat="server" Width="500px" Height="120px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll" DownLevelCols="50" ButtonSet="Office2003" AutoParseStyles="True">
                </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:FileUpload ID="fuImagen" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label11" runat="server" Text="*Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb"
                        Width="449px"></asp:Label><br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px" valign="top">
                    <asp:Label ID="Label10" runat="server" SkinID="camposNombre" Text="Imagen Agenda:"></asp:Label></td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:FileUpload ID="fuArchivoAgenda" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label9" runat="server" Text="*Ingrese Imagenes de 64 x 104 pixeles, peso máximo permitido 200kb"
                        Width="449px"></asp:Label><br />
                    <asp:Image ID="aimg" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px">
                </td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 20px">
                </td>
                <td colspan="1" style="width: 10px; height: 20px">
                </td>
                <td colspan="2" style="width: 400px; height: 20px">
                    &nbsp;<br />
                    <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvProgramacion" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="prog_codi" DataSourceID="odsProgramacion" OnSelectedIndexChanged="gvProgramacion_SelectedIndexChanged"
        SkinID="CGrilla" OnRowDataBound="gvProgramacion_RowDataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("prog_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la Programacion?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="prog_titu" HeaderText="T&#237;tulo" SortExpression="prog_titu" />
            <asp:BoundField DataField="prog_desc" HeaderText="Descripci&#243;n" />
            <asp:BoundField DataField="sede_nomb" HeaderText="Sede" />
        </Columns>
    </asp:GridView>
    &nbsp; &nbsp;
    <asp:ObjectDataSource ID="odsSede" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSedeNTAD">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsProgramacion" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLProgramacionAuditorioNTAD">
    </asp:ObjectDataSource>
</asp:Content>

