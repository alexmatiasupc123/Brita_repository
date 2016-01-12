<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_cursotaller, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>


<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
<asp:Label id="Label1" runat="server" Text="CURSOS TALLER BRITÁNICO" SkinID="lblTitulos"></asp:Label><BR /><BR /><asp:ImageButton id="btnNuevo" onclick="btnNuevo_Click" runat="server" SkinID="Agregar"></asp:ImageButton><asp:Panel id="pNuevo" runat="server" Height="1500px"  SkinID="paneles" Visible="False">
    <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Curso Taller" Width="400px"></asp:Label><br />
    <br />
    <TABLE style="WIDTH: 619px"><TBODY><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="lblECodigo" runat="server" Text="Código:" SkinID="camposNombre" Visible="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:Label id="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="Label3" runat="server" Text="Sede:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:DropDownList id="ddlSede" runat="server" SkinID="ddlListas" DataSourceID="odsSede" DataValueField="sede_codi" DataTextField="sede_nomb" AutoPostBack="True" Width="250px">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="Label4" runat="server" Text="Dirigido a:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:DropDownList id="ddlSegmento" runat="server" SkinID="ddlListas" DataSourceID="odsSegmento" DataValueField="segm_codi" DataTextField="segm_nomb" AutoPostBack="True" Width="250px">
                </asp:DropDownList></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="Label11" runat="server" Text="Dirigido por:" SkinID="camposNombre" Visible="False" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:TextBox id="txtDirige" runat="server" Width="400px" Visible="False"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="Label7" runat="server" Text="Profesor:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:TextBox id="txtProfesor" runat="server" Width="400px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right valign="top"><asp:Label id="Label5" runat="server" Text="Título:" SkinID="camposNombre" EnableViewState="False"></asp:Label> </TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2 valign="top"><asp:TextBox id="txtNombre" runat="server" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTitulo" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="Ingrese Titulo" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right><asp:Label id="Label14" runat="server" Text="SubTítulo:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:TextBox id="txtSubtitulo" runat="server" Width="400px"></asp:TextBox></TD></TR><TR><TD style="WIDTH: 93px" vAlign=top align=right><asp:Label id="Label2" runat="server" Text="Descripción:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; height: 18px;" colSpan=2>
                    <FTB:FreeTextBox ID="txtDescripcion" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </TD></TR>
        <tr>
            <td align="right" style="width: 93px" valign="top">
                <asp:Label id="Label6" runat="server" Text="Fechas:" SkinID="camposNombre" EnableViewState="False"></asp:Label></td>
            <td colspan="2" style="width: 480px; height: 18px">
                <asp:UpdatePanel id="UpdatePanel2" runat="server" RenderMode="Inline">
                </asp:UpdatePanel><table style="width: 78%; height: 100%">
                    <tr>
                        <td align="left" style="width: 46px; height: 182px" valign="top">
                            <asp:Calendar ID="cFechas" runat="server"></asp:Calendar>
                        </td>
                        <td align="left" style="width: 10px; height: 182px" valign="top">
                            <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="Agregar>>" />
                            <asp:Button ID="btnRemove" runat="server" OnClick="btnRemove_Click" Text="Remover"
                                ValidationGroup="remover" />
                        </td>
                        <td align="left" style="width: 10px; height: 182px" valign="top">
                            <asp:ListBox ID="listaFechas" runat="server" Rows="10" ValidationGroup="Guardar"
                                Width="120px"></asp:ListBox></td>
                    </tr>
                </table>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="listaFechas"
                    ErrorMessage="*Seleccione Fecha a remover" Font-Bold="False" ForeColor="" SkinID="rfvError"
                    ValidationGroup="remover"></asp:RequiredFieldValidator>
                <br />
                <asp:Label ID="lblErrorFecha" runat="server" Font-Bold="False"></asp:Label>&nbsp;<br />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 93px; height: 18px" valign="top">
                <asp:Label ID="Label9" runat="server" SkinID="camposNombre" Text="Detalle Adicional:" EnableViewState="False"></asp:Label></td>
            <td colspan="2" style="width: 480px; height: 18px">
                <FTB:FreeTextBox ID="txtHorario" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                    DownLevelCols="50" Height="120px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                    Width="500px">
                </FTB:FreeTextBox>
            </td>
        </tr>
        <TR><TD style="WIDTH: 93px; HEIGHT: 18px" align=right valign="top"><asp:Label id="Label12" runat="server" Text="Imagen:" SkinID="camposNombre" EnableViewState="False"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px;" colSpan=2><asp:FileUpload id="fuCurso" runat="server" Width="500px"></asp:FileUpload><br />
                    <asp:Label ID="Label8" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb "></asp:Label>
            <br />
            <asp:Image ID="img" runat="server" /></TD></TR>
        <tr>
            <td align="right" style="width: 93px; height: 18px" valign="top">
                <asp:Label ID="Label17" runat="server" SkinID="camposNombre" Text="Imagen Agenda:" EnableViewState="False"></asp:Label></td>
            <td colspan="2" style="width: 480px; height: 18px">
                <asp:FileUpload ID="fuArchivoAgenda" runat="server" Width="500px" /><br />
                <asp:Label ID="Label16" runat="server" Text="*Ingrese Imagenes de 64 x 104 pixeles, peso máximo permitido 200kb"
                    Width="449px"></asp:Label><br />
                <asp:Image ID="aimg" runat="server" /></td>
        </tr>
        <tr>
            <td align="right" style="width: 93px">
            </td>
            <td colspan="2" style="width: 480px; height: 18px">
            <asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></td>
        </tr>
        <TR><TD style="WIDTH: 93px" align=right></TD><TD style="WIDTH: 480px; height: 18px;" colSpan=2>
            &nbsp;&nbsp;<BR /><asp:ImageButton id="btnAgregar" onclick="btnAgregar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> <asp:ImageButton id="btnGuardar" onclick="btnGuardar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> <asp:ImageButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" SkinID="Cancelar"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <BR /><asp:GridView id="gvCurso" runat="server" SkinID="CGrilla" DataSourceID="odsCursoTaller" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="curs_codi" OnSelectedIndexChanged="gvCurso_SelectedIndexChanged" OnRowDataBound="gvCurso_RowDataBound" Width="880px"><Columns>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:ImageButton id="btnEditar" runat="server" Text="Select" SkinID="Editar" CommandName="Select" CausesValidation="False"></asp:ImageButton> 
<asp:ImageButton id="btnEliminar" onclick="btnEliminar_Click" runat="server" SkinID="Eliminar" CommandArgument='<%# Eval("curs_codi") %>'></asp:ImageButton> <ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" TargetControlID="btnEliminar" ConfirmText="¿Seguro que desea eliminar el curso?">
                    </ajaxToolkit:ConfirmButtonExtender> 
</ItemTemplate>
    <ItemStyle Width="80px" />
</asp:TemplateField>
<asp:BoundField DataField="curs_titu" HeaderText="T&#237;tulo" SortExpression="curs_titu"></asp:BoundField>
                        <asp:BoundField DataField="curs_desc" HeaderText="Descripci&#243;n" />
</Columns>
</asp:GridView> &nbsp; <asp:ObjectDataSource id="odsSegmento" runat="server" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSegmentoPublicoNTAD" SelectMethod="ListarTodos"></asp:ObjectDataSource> <asp:ObjectDataSource id="odsSede" runat="server" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSedeNTAD" SelectMethod="ListarTodos">
    </asp:ObjectDataSource> <asp:ObjectDataSource id="odsCursoTaller" runat="server" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLCursoTallerNTAD" SelectMethod="ListarTodos"></asp:ObjectDataSource> 
    <br />
    <br />
</asp:Content>

