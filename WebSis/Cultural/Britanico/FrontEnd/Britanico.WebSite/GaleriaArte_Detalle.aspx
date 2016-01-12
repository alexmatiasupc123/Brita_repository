<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="GaleriaArte_Detalle.aspx.cs" Inherits="GaleriaArte_Detalle" Title="CENTRO CULTURAL BRITÁNICO - Galería de Arte" StylesheetTheme="SkinBritanico"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
<asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; TEXT-ALIGN: left" align=left colSpan=2>
<asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp;</TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 30px" align=right colSpan=2>
<asp:Label id="lblDireccionSede" runat="server" Width="100%" CssClass="subtitulomayus" Text="Label"></asp:Label><BR /></TD></TR>

<tr>
<td align=right style="WIDTH: 100%" colspan="2">
<!-- Recomendar Button Begin-->
<asp:Literal ID="litRecomendar" runat="server" ></asp:Literal>
<!-- Recomendar Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 410px; HEIGHT: 129px; TEXT-ALIGN: left" colSpan=2 rowSpan=2>
<BR />
<asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("gade_imag") %>' Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left"></asp:Image> 
<asp:Panel id="pDetalle" runat="server">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 95%; height: 29px">
                                <asp:Label ID="lblGaleria" runat="server" CssClass="subtituloPlomo" Font-Bold="True"></asp:Label><br />
                                <br />
                                <asp:Label ID="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("gade_desc") %>'></asp:Label><br />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 95%; height: 29px">
                                <br />
                                <asp:Label ID="lblDetalle" runat="server" CssClass="cuadroTextoRojo" Text='<%# Eval("gade_temp") %>'></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel> &nbsp;&nbsp;</TD></TR><TR></TR>
                <TR><TD colSpan=2>
                <asp:Panel id="pGaleria" runat="server" Width="100%" BackColor="#EEF0EF">
                <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria">
                <asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES"></asp:Label><BR />
                <asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right>
                <asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px">
                <asp:DataList id="dlGaleriaImagenes" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged"><ItemTemplate>
                <asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
                </ItemTemplate>
                </asp:DataList>
</TD><TD style="WIDTH: 11px" vAlign=middle align=left>
<asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD colSpan=2><BR /><BR />
<asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria">
<asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS"></asp:Label><BR />
<asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right>
<asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle>
<asp:DataList id="dlGaleriaVideo" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged"><ItemTemplate>
<asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
</ItemTemplate>
</asp:DataList>
</TD><TD style="WIDTH: 11px" vAlign=middle align=left>
<asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel>
 <cc1:ModalPopupExtender id="mpeImagen" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkOk" PopupControlID="pVerImagen" TargetControlID="btnImagenOculto">
                </cc1:ModalPopupExtender> 
                <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR />
                <asp:Panel id="pVerImagen" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblDNombreGaleria" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkOk" runat="server" OnClick="btnCerrar_Click" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Image ID="dVerImagen" runat="server" CssClass="imagenGaleriaGrande" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbldTitulo" runat="server" CssClass="titulodgaleria"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbldDescripcion" runat="server" CssClass="textosdgaleria"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel> 
                <cc1:ModalPopupExtender id="mpeVideo" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkCerrarVideo" PopupControlID="pVerVideo" TargetControlID="btnVideoOculto">
                </cc1:ModalPopupExtender>
                 <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR />
                 <asp:Panel id="pVerVideo" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkCerrarVideo" runat="server" OnClick="btnCerrar_Click" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <br />
                                <asp:Literal ID="video" runat="server" Text="video.innerhtml"></asp:Literal><br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 17px">
                                <br />
                                <asp:Label ID="lblTituloVideo" runat="server" CssClass="titulodgaleria"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblDescripcionVideo" runat="server" CssClass="textosdgaleria"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                </TD></TR>
                
                <tr>
                <td style="WIDTH: 100%;" colspan="1">
                <table><tr>
                <td>
                <!-- Publicar Button Begin-->
                <asp:Literal ID="litPublicar" runat="server" ></asp:Literal>
                <!-- Publicar Button End-->
                </td>
                <td style="padding-left:15px;">
                <!-- AddThis Button -->
                <asp:Literal ID="litCompartir" runat="server" ></asp:Literal>
                <!-- AddThis Button END -->
                </td>
                </tr>
                </table>
                </td>
                </tr>
                 
                 <TR><TD style="HEIGHT: 14px" align=right colSpan=2><br />
                 <asp:HyperLink id="HyperLink1" runat="server" Width="77px" NavigateUrl="~/Galeria_Arte.aspx" SkinID="Links"><< VER TODOS</asp:HyperLink>
                 </TD></TR>
                 <TR><TD style="WIDTH: 100px; HEIGHT: 14px; TEXT-ALIGN: left"></TD><TD style="WIDTH: 300px; HEIGHT: 14px; TEXT-ALIGN: left">
                 </TD></TR>
                              
                 <TR><TD style="HEIGHT: 14px; TEXT-ALIGN: justify" colSpan=2>
                 <asp:UpdatePanel id="UpdatePanel1" runat="server">
                    <ContentTemplate>
<asp:ImageButton id="btnHistoria" onclick="btnHistoria_Click" runat="server" ImageUrl="~/App_themes/Imagenes/historia_galeria.jpg"></asp:ImageButton>
 <asp:Panel id="pHistoria" runat="server" Width="400px" Height="50px" BorderColor="#E0E0E0" ScrollBars="Vertical">
 <asp:Label id="lblHistoria" runat="server" Width="400px" CssClass="cuadroTextoContenido"></asp:Label>
 </asp:Panel>
  <cc1:collapsiblepanelextender id="CollapsiblePanelExtender1" runat="server" targetcontrolid="pHistoria" expandcontrolid="btnHistoria" collapsed="true" collapsecontrolid="btnHistoria"></cc1:collapsiblepanelextender> 
</ContentTemplate>
                </asp:UpdatePanel>
                 &nbsp;</TD></TR>
                 <TR><TD style="HEIGHT: 14px; TEXT-ALIGN: justify" colSpan=2></TD></TR><TR><TD style="HEIGHT: 14px; TEXT-ALIGN: justify" colSpan=2><BR /><BR />
                <asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" RepeatLayout="Flow">
                <HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><BR />
<asp:Label id="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR></TBODY></TABLE>
</contenttemplate>
    <Triggers>
    <asp:AsyncPostBackTrigger ControlID="btnAnterior" />
    <asp:AsyncPostBackTrigger ControlID="dlGaleriaImagenes" />
    <asp:AsyncPostBackTrigger ControlID="btnSiguiente" />
    <asp:AsyncPostBackTrigger ControlID="btnvAnterior" />
    <asp:AsyncPostBackTrigger ControlID="dlGaleriaVideo" />
    <asp:AsyncPostBackTrigger ControlID="btnvSiguiente" />
    <asp:AsyncPostBackTrigger ControlID="lnkOk" />
    <asp:AsyncPostBackTrigger ControlID="lnkCerrarVideo" />
    <asp:AsyncPostBackTrigger ControlID="btnHistoria" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

