<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_actividadteatro.aspx.cs" Inherits="Mantenimientos_frm_actividadteatro" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="ACTIVIDADES TEATRALES BRITÁNICO"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" /><asp:Panel
        ID="pNuevo" runat="server" Height="1400px"
        SkinID="paneles" Visible="False" >
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Actividad Teatral"
            Width="400px"></asp:Label><br />
        <br />
        <table style="width: 650px">
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Sede:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:DropDownList ID="ddlSede" runat="server" AutoPostBack="True" DataSourceID="odsSede"
                        DataTextField="sede_nomb" DataValueField="sede_codi" SkinID="ddlListas" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Dirigido a:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:DropDownList ID="ddlSegmento" runat="server" AutoPostBack="True" DataSourceID="odsSegmento"
                        DataTextField="segm_nomb" DataValueField="segm_codi" SkinID="ddlListas" Width="250px">
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                    <asp:Label ID="Label5" runat="server" EnableViewState="False" SkinID="camposNombre"
                        Text="Título:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:TextBox ID="txtNombre" runat="server" Width="500px" MaxLength="500"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                    <asp:Label ID="Label9" runat="server" EnableViewState="False" SkinID="camposNombre"
                        Text="Subtítulo:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:TextBox ID="txtSubtitulo" runat="server" MaxLength="500" Width="500px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px;" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px;" valign="top">
                </td>
                <td colspan="2" style="width: 550px; height: 18px;">
                    <FTB:FreeTextBox ID="txtDescripcion" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px" valign="top">
                    <asp:Label ID="Label6" runat="server" SkinID="camposNombre" Text="Fechas:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px" valign="top">
                </td>
                <td colspan="2" style="width: 550px" valign="top">
                    <asp:UpdatePanel id="UpdatePanel2" runat="server">
                        <contenttemplate>
<TABLE style="WIDTH: 78%; HEIGHT: 100%"><TR><TD style="WIDTH: 46px; HEIGHT: 182px" vAlign=top align=left><asp:Calendar id="cFechas" runat="server"></asp:Calendar> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:Button id="btnAdd" onclick="btnAdd_Click" runat="server" Text="Agregar>>"></asp:Button> <asp:Button id="btnRemove" onclick="btnRemove_Click" runat="server" Text="Remover" ValidationGroup="remover"></asp:Button> </TD><TD style="WIDTH: 10px; HEIGHT: 182px" vAlign=top align=left><asp:ListBox id="listaFechas" runat="server" Width="120px" ValidationGroup="Guardar" Rows="10"></asp:ListBox></TD></TR></TABLE><asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" ForeColor Font-Bold="False" SkinID="rfvError" ValidationGroup="remover" ErrorMessage="*Seleccione Fecha a remover" ControlToValidate="listaFechas"></asp:RequiredFieldValidator> <BR /><asp:Label id="lblErrorFecha" runat="server" Font-Bold="False"></asp:Label> <BR />
</contenttemplate>
                    </asp:UpdatePanel></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px" valign="top">
                    <asp:Label ID="Label10" runat="server" SkinID="camposNombre" Text="Detalle Adicional:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px"><FTB:FreeTextBox ID="txtTemporada" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="120px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px" valign="top">
                    <asp:Label ID="Label12" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px;">
                    <asp:FileUpload ID="fuTeatro" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label11" runat="server" Text="* Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb "></asp:Label><br />
                    <asp:Image ID="img" runat="server" />
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px" valign="top">
                    <asp:Label ID="Label15" runat="server" SkinID="camposNombre" Text="Imagen Agenda:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td colspan="2" style="width: 550px; height: 18px">
                    <asp:FileUpload ID="fuArchivoAgenda" runat="server" Width="500px" /><br />
                    <asp:Label ID="Label14" runat="server" Text="*Ingrese Imagenes de 64 x 104 pixeles, peso máximo permitido 200kb"
                        Width="449px"></asp:Label>
                    <br />
                    <asp:Image ID="aimg" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px">
                </td>
                <td align="right" style="width: 5px; height: 18px">
                </td>
                <td align="left" colspan="2" style="width: 550px; height: 18px">
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 80px; height: 18px;">
                </td>
                <td align="right" style="width: 5px; height: 18px;">
                </td>
                <td colspan="2" style="width: 550px; height: 18px;" align="left">
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
    <asp:GridView ID="gvActividades" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" CellPadding="6" CellSpacing="2"
        DataKeyNames="teat_codi" DataSourceID="odsActividad" GridLines="None"
        OnSelectedIndexChanged="gvActividades_SelectedIndexChanged" SkinID="CGrilla" OnRowCreated="gvActividades_RowCreated" OnRowDataBound="gvActividades_RowDataBound">
        <RowStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("teat_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la Actividad?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="teat_titu" HeaderText="T&#237;tulo" SortExpression="teat_titu" />
            <asp:BoundField DataField="teat_desc" HeaderText="Descripci&#243;n" />
        </Columns>
        <PagerStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
        <AlternatingRowStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
    </asp:GridView>
    &nbsp;
    <asp:ObjectDataSource ID="odsSegmento" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSegmentoPublicoNTAD"></asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsSede" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSedeNTAD">
    </asp:ObjectDataSource>
    <asp:ObjectDataSource ID="odsActividad" runat="server" SelectMethod="ListarTodos"
        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLActividadTeatroNTAD"></asp:ObjectDataSource>
    <br />
    <br />
</asp:Content>

