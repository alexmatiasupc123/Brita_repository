<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" ValidateRequest="false" AutoEventWireup="true" CodeFile="frm_banners.aspx.cs" Inherits="Mantenimientos_frm_banners" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="LISTA DE BANNERS" ></asp:Label><br />
    <br />
    <asp:ImageButton ID="btnNuevo" runat="server" OnClick="btnNuevo_Click" SkinID="Agregar" /><br />
    <asp:Panel ID="pNuevo" runat="server" Height="600px"
        SkinID="paneles" Visible="False">
        <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Banner" Width="400px"></asp:Label><br />
        <br />
        <table style="width: 492px">
            <tr>
                <td style="width: 100px; height: 18px" align="right" valign="top">
                    <asp:Label ID="Label2" runat="server" SkinID="camposNombre" Text="Título:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:TextBox ID="txtTituto" runat="server" Width="373px"></asp:TextBox>
                    <asp:CheckBox ID="chkPrincipal" runat="server" Text="Banner Evento Principal" AutoPostBack=true OnCheckedChanged="chkPrincipal_CheckedChanged" Width="186px" /><br />
                    <asp:CheckBox ID="chkRedSocial" runat="server" Text="Enlace a Red Social" AutoPostBack=true OnCheckedChanged="chkRedSocial_CheckedChanged" />
                    <asp:Label ID="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></td>
                <td colspan="1" rowspan="5" style="width: 480px" valign="top">
                    <asp:Image ID="bImagen" runat="server" Visible="False" /></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 18px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Fecha:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 18px">
                    <asp:TextBox ID="txtFecha" runat="server" Width="198px"></asp:TextBox><br />
                    <asp:RegularExpressionValidator ID="revFecha" runat="server" ErrorMessage="**Formato de fecha invalido (dd/mm/yyyy)"  ControlToValidate="txtFecha" ForeColor=black Font-Bold=false  
                    ValidationExpression="^(((((0[1-9])|(1\d)|(2[0-8]))\/((0[1-9])|(1[0-2])))|((31\/((0[13578])|(1[02])))|((29|30)\/((0[1,3-9])|(1[0-2])))))\/((20[0-9][0-9])|(19[0-9][0-9])))|((29\/02\/(19|20)(([02468][048])|([13579][26]))))$  "></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width: 100px; height: 70px;" align="right" valign="top">
                    <asp:Label ID="Label3" runat="server" SkinID="camposNombre" Text="Imagen:"></asp:Label></td>
                <td colspan="2" style="width: 480px; height: 70px;">
                    <asp:FileUpload ID="fuBanner" runat="server" Width="303px" /><br />
                    <asp:Label ID="Label11" runat="server" Text="* Ingrese Imagenes máximo  123 pixeles de ancho para banners simples, y 500 pixeles para banners de eventos destacados" Width="369px"></asp:Label>&nbsp;<br />
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="fuBanner"
                        ErrorMessage="**Seleccione solo imagenes en JPG o GIF, peso maximo permitido 300kb" ValidationExpression="^(([a-zA-Z]:)|(\\{2}\w+)\$?)(\\(\w[\w].*))(.jpg|.JPG|.gif|.GIF)$"
                        ValidationGroup="guardar" ForeColor="" SkinID="revError"></asp:RegularExpressionValidator>&nbsp;<br />
                    <asp:Label ID="lblError" runat="server" SkinID="tError"></asp:Label></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 32px" valign="top">
                    <asp:Label ID="Label4" runat="server" SkinID="camposNombre" Text="Link:"></asp:Label>
                </td>
                <td colspan="2" style="width: 480px; height: 32px" valign="top">
                    <asp:TextBox ID="txtLink" runat="server" Width="340px"></asp:TextBox></td>
            </tr>
            <tr>
                <td align="right" style="width: 100px; height: 36px" valign="top">
                </td>
                <td colspan="2" style="width: 480px; height: 36px">
                    &nbsp;<br />
                    <asp:ImageButton ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" SkinID="Guardar" />
                    <asp:ImageButton ID="btnActualizar" runat="server" OnClick="btnActualizar_Click" SkinID="Guardar" />
                    <asp:ImageButton ID="btnCancelar" runat="server" OnClick="btnCancelar_Click" SkinID="Cancelar" /></td>
            </tr>
        </table>
    </asp:Panel>
    <br />
    &nbsp;&nbsp;
    <asp:DataList ID="dlBanners" runat="server" RepeatColumns="2" Width="734px">
        <ItemTemplate>
            <table border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td style="width: 200px">
            <asp:Label ID="lbltituloInactivo" runat="server" SkinID="camposNombre" Text='<%# Eval("bann_titu") %>'></asp:Label></td>
                </tr>
                <tr>
                    <td align="center" style="width: 200px">
            <asp:Image ID="imgBannerInactivo" runat="server" ImageUrl='<%# Eval("bann_imag") %>' /></td>
                </tr>
                <tr>
                    <td align="right" style="width: 200px">
                        <asp:ImageButton ID="btnEditar" runat="server" CommandArgument='<%# Eval("bann_codi") %>'
                            OnClick="btnEditar_Click" SkinID="Editar" />
                        <asp:ImageButton ID="btnEliminar" runat="server" CommandArgument='<%# Eval("bann_codi") %>'
                            OnClick="btnEliminar_Click" SkinID="Eliminar" /></td>
                </tr>
            </table>
            <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("bann_codi") %>'
                OnClick="lnkEliminar_Click" SkinID="lnkPrincipal" Visible="False">(x) Eliminar</asp:LinkButton>
        </ItemTemplate>
    </asp:DataList><br />
</asp:Content>

