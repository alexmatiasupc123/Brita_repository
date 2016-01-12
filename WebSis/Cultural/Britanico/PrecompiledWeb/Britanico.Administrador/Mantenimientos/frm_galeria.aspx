<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_galeria, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="GALERÍA DE IMAGENES/VIDEOS"></asp:Label><br />
    <table style="width: 800px">
        <tr>
            <td align="left" colspan="4">
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 120px">
                <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Tipo de Galeria:"
                    Width="120px"></asp:Label></td>
            <td align="right" style="width: 5px">
            </td>
            <td colspan="2" style="width: 670px; text-align: left">
                <asp:DropDownList ID="ddlTipoGaleria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoGaleria_SelectedIndexChanged">
                    <asp:ListItem Value="1">Auditorio</asp:ListItem>
                    <asp:ListItem Value="2">Actividades Teatrales</asp:ListItem>
                    <asp:ListItem Value="3">Concursos</asp:ListItem>
                    <asp:ListItem Value="4">Galeria de Arte</asp:ListItem>
                    <asp:ListItem Value="5">Cursos</asp:ListItem>
                    <asp:ListItem Value="6">Historia del Teatro</asp:ListItem>
                    <asp:ListItem Value="7">Producciones Teatrales</asp:ListItem>
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td align="right" style="width: 120px">
                <asp:Label ID="lblGaleria" runat="server" SkinID="camposNombre" Text="Galeria:" Width="43px"></asp:Label></td>
            <td align="right" style="width: 5px">
            </td>
            <td colspan="2" style="width: 670px; text-align: left">
                <asp:DropDownList ID="ddlGaleria" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlGaleria_SelectedIndexChanged">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="ddlGaleria"
                    ErrorMessage="* Seleccione Galeria" SkinID="rfvError" ValidationGroup="guardar"></asp:RequiredFieldValidator></td>
        </tr>
    </table>
    &nbsp;&nbsp;
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" />
    <asp:Panel ID="pNuevo" runat="server" Height="850px" SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 650px">
             <tr>
                <td align="right" style="width: 74px">
                    <asp:Label ID="lblECodigo" runat="server" SkinID="camposNombre" Text="Código:" Visible="False"></asp:Label>
                </td>
                <td colspan="2" style="width: 700px; text-align: left">
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
            </tr>
            
            <tr>
                <td align="left" colspan="4">
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 24px" valign="top">
                    <asp:Label ID="Label6" runat="server" SkinID="camposNombre" Text="Tipo de Archivo:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 24px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; height: 24px; text-align: left" valign="top">
                    <asp:DropDownList ID="ddlTipoArchivo" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoArchivo_SelectedIndexChanged">
                        <asp:ListItem Value="imagen">Imagen</asp:ListItem>
                        <asp:ListItem Value="video">Video</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 26px" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label>
                </td>
                <td align="right" style="width: 5px; height: 26px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; height: 26px; text-align: left" valign="top">
                    <asp:TextBox ID="txtTitulo" runat="server" Width="338px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfTitulo" runat="server" ControlToValidate="txtTitulo"
                        ErrorMessage="*Ingrese Título" SkinID="rfvError" ValidationGroup="guardar"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 40px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Descripción:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 40px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; height: 40px; text-align: left" valign="top">
                    <FTB:FreeTextBox ID="txtDescripcion" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
                        DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
                        Width="500px">
                    </FTB:FreeTextBox>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px" valign="top">
                    &nbsp;<asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Imagen/Portada:"></asp:Label></td>
                <td align="right" style="width: 5px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; text-align: left" valign="top">
                    <asp:FileUpload ID="fuImagen" runat="server" Width="500px" />
                    <asp:RequiredFieldValidator ID="rfvImagen" runat="server" ControlToValidate="fuImagen"
                        ErrorMessage="* Seleccione Imagen/Portada" SkinID="rfvError" ValidationGroup="guardar"></asp:RequiredFieldValidator><br />
                    <asp:Label ID="Label11" runat="server" Text="*Ingrese Imagenes de 400 X 400 pixeles como máximo, perso  permitido 200kb"></asp:Label><br />
                    <asp:Image ID="img" runat="server" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 26px" valign="top">
                    <asp:Label ID="lblVideo" runat="server" SkinID="camposNombre" Text="Link a video:"></asp:Label></td>
                <td align="right" style="width: 5px; height: 26px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; height: 26px; text-align: left" valign="top">
                    <asp:TextBox ID="txtLink" runat="server" Width="500px"></asp:TextBox><br />
                    <asp:Panel ID="pEjemplo" runat="server" Width="500px">
                    ejemplo link a video = http://www.youtube.com/v/93f7E7cy9ng&amp;hl=en&amp;fs=1<br />
                        Extraido de value = http://www.youtube.com/v/93f7E7cy9ng&amp;hl=en&amp;fs=1<br />
                        Embed:<br />
                    <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Height="60px" ReadOnly="True" Rows="5" Width="441px">&lt;object width=&quot;425&quot; height=&quot;344&quot;&gt;&lt;param name=&quot;movie&quot; value=&quot;http://www.youtube.com/v/93f7E7cy9ng&amp;hl=en&amp;fs=1&quot;&gt;&lt;/param&gt;&lt;param name=&quot;allowFullScreen&quot; value=&quot;true&quot;&gt;&lt;/param&gt;&lt;param name=&quot;allowscriptaccess&quot; value=&quot;always&quot;&gt;&lt;/param&gt;&lt;embed src=&quot;http://www.youtube.com/v/93f7E7cy9ng&amp;hl=en&amp;fs=1&quot; type=&quot;application/x-shockwave-flash&quot; allowscriptaccess=&quot;always&quot; allowfullscreen=&quot;true&quot; width=&quot;425&quot; height=&quot;344&quot;&gt;&lt;/embed&gt;&lt;/object&gt;</asp:TextBox></asp:Panel>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 120px; height: 18px" valign="top">
                </td>
                <td align="right" style="width: 5px; height: 18px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; height: 18px; text-align: left" valign="top">
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 120px" valign="top">
                </td>
                <td align="right" style="width: 5px" valign="top">
                </td>
                <td colspan="2" style="width: 670px; text-align: left" valign="top">
                       <asp:ImageButton ID="btnAgregar" runat="server" OnClick="btnAgregar_Click" SkinID="Guardar"
                        ValidationGroup="guardar" />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar"
                        ValidationGroup="guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Label ID="lblTituloGaleria" runat="server" SkinID="lblTitulos"></asp:Label><br />
    <br />
    <asp:GridView ID="gvGaleria" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" CellPadding="6" CellSpacing="2"
        DataSourceID="odsGaleria" GridLines="None" OnRowDataBound="gvGaleria_RowDataBound"
        OnSelectedIndexChanged="gvGaleria_SelectedIndexChanged" PageSize="10" SkinID="CGrilla" DataKeyNames="arch_codi">
        <RowStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEditar" runat="server" CommandName="select" SkinID="Editar" />
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("arch_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                    <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtender1" runat="server" ConfirmText="esta seguro que desea eliminar el archivo?"
                        TargetControlID="btnEliminar">
                    </ajaxToolkit:ConfirmButtonExtender>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="arch_titu" HeaderText="Titulo" />
            <asp:BoundField DataField="arch_tipo" />
            <asp:BoundField DataField="arch_arch" />
            <asp:BoundField DataField="arch_link" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkArchivo" runat="server" CommandArgument='<%# Eval("arch_codi") %>'
                        OnClick="lnkArchivo_Click" SkinID="lnkPrincipal">Ver</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <PagerStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
        <AlternatingRowStyle BorderColor="Red" BorderStyle="Solid" BorderWidth="2px" />
    </asp:GridView>
    <br />
    <ajaxToolkit:ModalPopupExtender ID="mpeVideo" runat="server" BackgroundCssClass="modalBackground"
        OkControlID="lnkCerrarVideo" PopupControlID="pVerVideo" TargetControlID="btnVideoOculto">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Button ID="btnVideoOculto" runat="server" BackColor="Transparent" BorderColor="Transparent"
        BorderStyle="None" />
    <br />
    <asp:Panel ID="pVerVideo" runat="server" CssClass="modalPopup" Height="500px" Width="500px">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 400px">
            <tr>
                <td style="width: 519px; height: 19px">
                    <asp:Label ID="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></td>
                <td align="right" style="width: 100px; height: 19px">
                    <asp:LinkButton ID="lnkCerrarVideo" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 310px; text-align: center">
                    <asp:Literal ID="video" runat="server"></asp:Literal></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 17px">
                    <asp:Label ID="lblTituloVideo" runat="server" CssClass="titulodgaleria"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescripcionVideo" runat="server" CssClass="textosdgaleria"></asp:Label></td>
            </tr>
        </table>
    </asp:Panel><br />
    <ajaxToolkit:ModalPopupExtender ID="mpeImagen" runat="server" BackgroundCssClass="modalBackground"
        OkControlID="lnkCerrarImagen" PopupControlID="pVerImagen" TargetControlID="btnImagenOculto">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Button ID="btnImagenOculto" runat="server" BackColor="Transparent" BorderColor="Transparent"
        BorderStyle="None" />
    <br />
    <asp:Panel ID="pVerImagen" runat="server" CssClass="modalPopup" Height="500px" Width="700px" ScrollBars="Auto">
        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 400px">
            <tr>
                <td style="width: 519px; height: 19px">
                    <asp:Label ID="lblGaleriaImagen" runat="server" CssClass="titulogaleria"></asp:Label></td>
                <td align="right" style="width: 100px; height: 19px">
                    <asp:LinkButton ID="lnkCerrarImagen" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 310px; text-align: center">
                    <asp:Image ID="ArchivoImagen" runat="server" CssClass="imagen" /></td>
            </tr>
            <tr>
                <td colspan="2" style="height: 17px">
                    <asp:Label ID="lblTituloImagen" runat="server" CssClass="titulodgaleria"></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Label ID="lblDescripcionImagen" runat="server" CssClass="textosdgaleria"></asp:Label></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    <br />
    <asp:ObjectDataSource ID="odsGaleria" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListarTodosGaleria" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLGaleriaArchivoNTAD">
        <SelectParameters>
            <asp:ControlParameter ControlID="ddlGaleria" Name="idPadre" PropertyName="SelectedValue"
                Type="Int32" />
            <asp:ControlParameter ControlID="ddlTipoGaleria" Name="tipoevento" PropertyName="SelectedValue"
                Type="Int32" />
        </SelectParameters>
    </asp:ObjectDataSource>
    <br />
</asp:Content>

