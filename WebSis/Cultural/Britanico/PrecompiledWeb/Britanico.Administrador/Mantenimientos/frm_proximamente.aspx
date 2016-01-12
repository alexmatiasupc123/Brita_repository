<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_proximamente, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="INFORMACION EVENTOS PROXIMOS"></asp:Label><br />
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
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Tipo de Evento:"
                        Visible="False" Width="72px"></asp:Label></td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:DropDownList ID="ddlTipoEvento" runat="server">
                        <asp:ListItem Value="0">Galeria de Arte</asp:ListItem>
                        <asp:ListItem Value="1">Auditorio</asp:ListItem>
                        <asp:ListItem Value="2">Actividad Teatral</asp:ListItem>
                        <asp:ListItem Value="4">Cursos y Talleres</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 74px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Evento:"></asp:Label></td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:TextBox ID="txtNombre" runat="server" ValidationGroup="Guardar" Width="400px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNombre"
                        ErrorMessage="*Ingrese Evento" ForeColor="" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 74px" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <ftb:freetextbox id="txtContenido" runat="server" autoparsestyles="True" buttonset="Office2003"
                        downlevelcols="50" height="300px" toolbarlayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        width="500px">
                    </ftb:freetextbox>
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
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" />&nbsp;
                </td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <asp:GridView ID="gvInformacion" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataKeyNames="info_codi" DataSourceID="odsProximo" OnRowDataBound="gvInformacion_RowDataBound"
        OnSelectedIndexChanged="gvInformacion_SelectedIndexChanged" PageSize="10" SkinID="CGrilla">
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("info_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar el registro?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
                <ItemStyle Width="80px" />
            </asp:TemplateField>
            <asp:BoundField DataField="info_titu" HeaderText="Nombre" />
            <asp:BoundField DataField="info_desc" HeaderText="Descripci&#243;n" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsProximo" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLInformacionNTAD">
    </asp:ObjectDataSource>
                    <asp:ObjectDataSource ID="odsProximosEventos" runat="server" SelectMethod="ListarTodosXEvento"
                        TypeName="Britanico.BusinessLogic.NoTransaccionales.BLInformacionNTAD">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="even_tipo" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource>
</asp:Content>

