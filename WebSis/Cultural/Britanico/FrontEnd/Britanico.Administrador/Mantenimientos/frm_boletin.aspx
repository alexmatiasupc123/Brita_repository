<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_boletin.aspx.cs" Inherits="Mantenimientos_frm_boletin" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="LISTA DE BOLETINES"></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" /><br />
    <asp:Panel ID="pNuevo" runat="server" Height="180px"
        SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Boletín" Width="400px"></asp:Label><br />
        <table style="width: 494px">
            <tr>
                <td style="width: 100px; height: 18px" align="right">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 21px; text-align: left;">
                    <asp:TextBox ID="txtTituto" runat="server" Width="300px"></asp:TextBox></td>
            </tr>
            <tr>
                <td style="width: 100px" valign="top" align="right">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Archivo:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 21px; text-align: left;">
                    <asp:FileUpload ID="fuArchivo" runat="server" Width="300px" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuArchivo"
                        ErrorMessage="**Seleccione Boletin" ForeColor="" SetFocusOnError="True" SkinID="rfvError"
                        ValidationGroup="guardar"></asp:RequiredFieldValidator>
                    <br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fuArchivo"
                        ErrorMessage="**Seleccione solo archivos PDF" ForeColor="" SkinID="revError"
                        ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.pdf|.PDF)$"
                        ValidationGroup="guardar"></asp:RegularExpressionValidator><br />
                    <asp:Label ID="Label11" runat="server" Text="* peso máximo permitido 3MB"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px" align="right">
                </td>
                <td colspan="2" style="width: 480px; height: 21px; text-align: left" align="left">
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 100px; height: 21px" align="right">
                </td>
                <td colspan="2" style="width: 480px; height: 21px; text-align: left">
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    &nbsp; &nbsp;&nbsp;
    <br />
    <asp:GridView ID="gvBoletines" runat="server" AllowPaging="True" AutoGenerateColumns="False"
        DataSourceID="odsBoletines" SkinID="CGrilla" Width="565px" PageSize="10">
        <Columns>
            <asp:TemplateField ShowHeader="False" Visible="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" CommandName="Select"
                        SkinID="Editar" Text="Select" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("bole_codi") %>'
                        OnClick="btnEliminar_Click" SkinID="Eliminar" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="bole_titu" HeaderText="Titulo" SortExpression="bole_titu" />
            <asp:TemplateField HeaderText="Fecha" SortExpression="bole_fech">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("bole_fech").ToString().Substring(0,10) %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CheckBoxField DataField="bole_publ" HeaderText="Publicado" SortExpression="bole_publ" />
        </Columns>
    </asp:GridView>
    <asp:ObjectDataSource ID="odsBoletines" runat="server" OldValuesParameterFormatString="original_{0}"
        SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLBoletinNTAD">
    </asp:ObjectDataSource>
</asp:Content>

