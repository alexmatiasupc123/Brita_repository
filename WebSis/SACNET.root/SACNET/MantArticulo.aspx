<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="MantArticulo.aspx.cs" Inherits="MantArticulo" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div style="width: 900px;">
        <div class="panelBotones">
            <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
        </div>
        <asp:UpdatePanel ID="udpItem" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <uc3:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                <asp:Panel runat="server" ID="pnRegistroItem" CssClass="panelGria">
                    <fieldset style="width: 870px">
                        <legend>Datos del Registro.</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label28" runat="server" Text="Tipo de ítem :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoItem" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoItem_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label27" runat="server" Text="Fotografia :"></asp:Label>
                                </td>
                                <td rowspan="2" style="text-align: center">
                                    <asp:Image ID="imgFoto" runat="server" Height="90px" Width="90px" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Código :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtCodItem" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Titulo :"></asp:Label>
                                </td>
                                <td colspan="2">
                                    <asp:TextBox ID="txtTitulo" runat="server" Width="397px" MaxLength="200"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:FileUpload ID="fuFotografia" runat="server" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblAutores" runat="server" Text="Autores :"></asp:Label>
                                </td>
                                <td rowspan="2">
                                    <asp:ListBox ID="ltbAutores" runat="server" Width="210px"></asp:ListBox>
                                    <asp:ImageButton ID="btnAgregarAutores" runat="server" ImageUrl="~/Comun/Imagenes/Botones/btnAgregar.gif"
                                        OnClick="btnAgregarAutores_Click" />
                                </td>
                                <td>
                                    <asp:Label ID="Label14" runat="server" Text="Estado :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstado" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    <asp:Label ID="Label18" runat="server" Text="Idioma :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlIdioma" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr runat="server" id="trAudioVisualizar1">
                                <td>
                                    <asp:Label ID="lblPieImprenta" runat="server" Text="Pie Imprenta :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPieImprenta" runat="server" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblISBN" runat="server" Text="ISBN :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtISBN" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr runat="server" id="trAudioVisualizar2">
                                <td>
                                    <asp:Label ID="lblNPaginas" runat="server" Text="N° Páginas :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtNroPaginas" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="lblISSN" runat="server" Text="ISSN :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtISSN" runat="server" MaxLength="20"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblEdicion" runat="server" Text="Edición :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtEdicion" runat="server" MaxLength="100"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:Label ID="Label25" runat="server" Text="Préstamo :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlPrestamo" runat="server">
                                        <asp:ListItem>-- Seleccione --</asp:ListItem>
                                        <asp:ListItem Value="0">Sala</asp:ListItem>
                                        <asp:ListItem Value="1">Domicilio</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblTipoAudiencia" runat="server" Text="Tipo Audiencia :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlTipoAudiencia" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label19" runat="server" Text="Precio Unitario :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtPrecioUnitario" runat="server" MaxLength="8"></asp:TextBox>
                                   <%-- <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtPrecioUnitario"
                                        ValidationExpression="^[0-9]{1,5}(\.[0-9]{0,2})?$" 
                                        ErrorMessage="(*)" 
                                        SetFocusOnError="True" ToolTip="Formato incorrecto."  />--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label32" runat="server" Text="Procedencia :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProcedencia" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="lblDuracion" runat="server" Text="Duración :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtDuracion" runat="server" MaxLength="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblGenero" runat="server" Text="Género :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlGenero" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label17" runat="server" Text="Formato Adicional :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtFormatoAdicional" runat="server" MaxLength="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Proveedor :"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlProveedor" runat="server">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label12" runat="server" Text="Temas :"></asp:Label>
                                </td>
                                <td colspan="1">
                                    <asp:ListBox ID="ltbTemas" runat="server" Width="210px"></asp:ListBox>
                                    <asp:ImageButton ID="btnAgregarTemas" runat="server" ImageUrl="~/Comun/Imagenes/Botones/btnAgregar.gif"
                                        OnClick="btnAgregarTemas_Click" />
                                </td>
                                <td>
                                    <asp:Label ID="lblReqTecnico" runat="server" Text="Requer. Técnico :"></asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReqTecnico" runat="server" Height="55px" TextMode="MultiLine"
                                        Width="209px" onKeyUp="Count(this,500)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Resumen :"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtResumen" runat="server" Height="60px" Width="619px" TextMode="MultiLine"
                                        onKeyUp="Count(this,1000)"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label33" runat="server" Text="Notas :"></asp:Label>
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtNotas" runat="server" Height="60px" Columns="4" TextMode="MultiLine"
                                        Width="620px" onKeyUp="Count(this,1000)"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    <asp:Panel ID="pnAutoresInstitucionales" runat="server">
                        <fieldset style="width: 870px">
                            <legend style="font-weight: bold">Autores Institucionales </legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="ltbAutoresInstitucionales" runat="server" Width="250px"></asp:ListBox>
                                    </td>
                                    <td valign="bottom">
                                        <asp:ImageButton ID="btnAgregarAutoresInstitucionales" runat="server" ImageUrl="~/Comun/Imagenes/Botones/btnAgregar.gif"
                                            OnClick="btnAgregarAutoresInstitucionales_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                        &nbsp;</asp:Panel>
                    <asp:Panel ID="pnActores" runat="server">
                        <fieldset style="width: 870px">
                            <legend style="font-weight: bold">Actores</legend>
                            <table>
                                <tr>
                                    <td>
                                        <asp:ListBox ID="ltbActores" runat="server" Width="250px"></asp:ListBox>
                                    </td>
                                    <td valign="bottom">
                                        <asp:ImageButton ID="btnAgregarActores" runat="server" ImageUrl="~/Comun/Imagenes/Botones/btnAgregar.gif"
                                            OnClick="btnAgregarActores_Click" />
                                    </td>
                                </tr>
                            </table>
                        </fieldset>
                    </asp:Panel>
                    <fieldset style="width: 870px">
                        <legend style="font-weight: bold">Ejemplares</legend>
                        <table>
                            <tr>
                                <td>
                                    <asp:GridView ID="gvEjemplares" runat="server" AutoGenerateColumns="False" DataKeyNames="sCodItem"
                                        AllowPaging="true" OnRowCommand="gvEjemplares_RowCommand" OnRowDataBound="gvEjemplares_RowDataBound"
                                        Width="700px" EmptyDataText="No existen ejemplares." PageSize='<%# Util.ObtenerPaginacion() %>'
                                        OnPageIndexChanging="gvEjemplares_PageIndexChanging">
                                        <Columns>
                                            <asp:BoundField DataField="sCodItem" HeaderText="CODIGO ITEM" Visible="False" />
                                            <asp:BoundField DataField="sCodEjemplar" HeaderText="CÓDIGO INGRESO" ItemStyle-Width="80px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sCodSacNombre" HeaderText="CENTRO" ItemStyle-Width="200px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="dFechaAsignaSAC" HeaderText="FECHA DE ASIGNACIÓN" ItemStyle-Width="200px">
                                            </asp:BoundField>
                                            <asp:BoundField DataField="sNotas" HeaderText="NOTAS" ItemStyle-Width="350px"></asp:BoundField>
                                            <asp:BoundField DataField="sCodArguNombreEstadoEjemplar" HeaderText="ESTADO" ItemStyle-Width="100px">
                                            </asp:BoundField>
                                            <asp:TemplateField HeaderText="RESERVADO" HeaderStyle-Width="55px" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%# PintarEstado(Convert.ToBoolean(Eval("bReservado")))%>
                                                </ItemTemplate>
                                                <HeaderStyle Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnVer" runat="server" CommandArgument='<%# Eval("sCodEjemplar") %>'
                                                        CommandName="Ver" ImageUrl="~/Comun/Imagenes/Icons/Ver.png" ToolTip="VER Registro de Tabla" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("sCodEjemplar") %>'
                                                        CommandName="Editar" ImageUrl="~/Comun/Imagenes/Icons/edit.png" ToolTip="EDITAR Registro de Tabla"
                                                        OnClick="btnEditar_Click" />
                                                </ItemTemplate>
                                                <HeaderStyle Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("sCodEjemplar") +"-" + Eval("sCodItem") %>'
                                                        CommandName="Eliminar" ImageUrl="~/Comun/Imagenes/Icons/Delete.png" ToolTip="ELIMINAR Registro de Tabla" />
                                                    <cc1:ConfirmButtonExtender ID="btnEliminar_ConfirmButtonExtender" runat="server"
                                                        ConfirmText="¿Confirmar la Eliminación completa del Registro?" Enabled="True"
                                                        TargetControlID="btnEliminar">
                                                    </cc1:ConfirmButtonExtender>
                                                </ItemTemplate>
                                                <HeaderStyle Width="30px" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                                <td>
                                    <asp:ImageButton ID="ibtnAgregarEjemplar" runat="server" ImageUrl="~/Comun/Imagenes/Botones/btnAgregar.gif"
                                        OnClick="ibtnAgregarEjemplar_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:HiddenField ID="hfCodItem" runat="server" />
                                    <asp:HiddenField ID="hfCodSAC" runat="server" />
                                    <asp:HiddenField ID="hfEvento" runat="server" />
                                    <asp:HiddenField ID="hfCodArguAudioVisual" runat="server" />
                                    <asp:HiddenField ID="hfCodArguLibroReader" runat="server" />
                                    <asp:HiddenField ID="hfCodArguLibroGrammar" runat="server" />
                                    <asp:HiddenField ID="hfCodArguLibroPaper" runat="server" />
                                    <asp:HiddenField ID="hfCodArguRevista" runat="server" />
                                    <asp:HiddenField ID="hfParameters" runat="server" EnableViewState="False" />
                                    <asp:HiddenField ID="hfCodArguRecursoElectronico" runat="server" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                    &nbsp;<uc2:Auditoria ID="Auditoria1" runat="server" />
                </asp:Panel>
            </ContentTemplate>
            <Triggers>
                <asp:PostBackTrigger ControlID="BotonesEdicionMantenimiento1" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>
