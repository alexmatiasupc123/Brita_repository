<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Auditorio_Detalle.aspx.cs" Inherits="Auditorio_Detalle" Title="CENTRO CULTURAL BRITÁNICO - Auditorios" StylesheetTheme="SkinBritanico"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="HEIGHT: 10px; TEXT-ALIGN: left" colSpan=2>
<asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp;<BR />
<asp:Label id="lblDireccionSede" runat="server" Width="100%" CssClass="subtitulomayus" Text="Label"></asp:Label><BR/><BR/></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;" colspan="2">
<!-- Recomendar Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_recomendar); }%>
<!-- Recomendar Button End-->
</td>
</tr>

<TR>
<TD style="HEIGHT: 12px; TEXT-ALIGN: left" colSpan=2>
<asp:Label id="lblSubtitulo" runat="server" CssClass="subtitulo"></asp:Label><BR /></TD></TR><TR><TD style="HEIGHT: 12px; TEXT-ALIGN: left" colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("prog_imag") %>' Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left"></asp:Image> 
<asp:Panel id="pDetalle" runat="server"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="HEIGHT: 12px" colSpan=2>
<asp:Panel id="pGaleria" runat="server" Width="100%" BackColor="#EEF0EF" __designer:wfdid="w21">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES" __designer:wfdid="w22"></asp:Label><BR /><asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" __designer:wfdid="w23" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" __designer:wfdid="w24" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px">
<asp:DataList id="dlGaleriaImagenes" runat="server" __designer:wfdid="w25" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged"><ItemTemplate>
<asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" __designer:wfdid="w2" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" __designer:wfdid="w26" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR>
<TD style="HEIGHT: 12px" colSpan=2><BR /><BR />
<asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF" __designer:wfdid="w15">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS" __designer:wfdid="w16"></asp:Label><BR /><asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" __designer:wfdid="w17" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" __designer:wfdid="w18" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle><asp:DataList id="dlGaleriaVideo" runat="server" __designer:wfdid="w19" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged"><ItemTemplate>
<asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" __designer:wfdid="w1" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" __designer:wfdid="w20" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <cc1:modalpopupextender id="mpeImagen" runat="server" targetcontrolid="btnImagenOculto" popupcontrolid="pVerImagen" okcontrolid="lnkOk" backgroundcssclass="modalBackground">
    </cc1:modalpopupextender> <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderStyle="None" BorderColor="White"></asp:Button> <BR />
    <asp:Panel id="pVerImagen" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblDNombreGaleria" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkOk" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
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
                </asp:Panel> <cc1:modalpopupextender id="mpeVideo" runat="server" targetcontrolid="btnVideoOculto" popupcontrolid="pVerVideo" okcontrolid="lnkCerrarVideo" backgroundcssclass="modalBackground"></cc1:modalpopupextender> <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderStyle="None" BorderColor="White"></asp:Button> <BR />
                <asp:Panel id="pVerVideo" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkCerrarVideo" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
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
                </asp:Panel> </TD></TR><TR><TD style="HEIGHT: 12px; TEXT-ALIGN: right" colSpan=2><BR /><asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/Auditorios.aspx" SkinID="Links"><< VER TODOS</asp:HyperLink> </TD></TR><TR><TD style="WIDTH: 20%; HEIGHT: 12px; TEXT-ALIGN: left"></TD><TD style="WIDTH: 100%; HEIGHT: 12px; TEXT-ALIGN: left"></TD></TR><TR><TD style="HEIGHT: 12px; TEXT-ALIGN: left" colSpan=2></TD></TR><TR><TD style="HEIGHT: 12px; TEXT-ALIGN: left" colSpan=2><BR />
                <asp:DataList id="dlProximosEventos" runat="server" __designer:wfdid="w40" RepeatLayout="Flow" DataKeyField="info_codi">
                <HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente" __designer:wfdid="w29"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>' __designer:wfdid="w27"></asp:Label><BR />
<asp:Label id="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>' __designer:wfdid="w28"></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> 
</TD>
</TR>

<tr>
<td style="WIDTH: 410px;" colspan="2">
<table><tr>
<td>
<!-- Publicar Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_publicar(Convert.ToString(Session["url"]),Convert.ToString(Session["title"]))); }%>
<!-- Publicar Button End-->
</td>
<td style="padding-left:15px;">
<!-- AddThis Button -->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_compartir); }%>
<!-- AddThis Button END -->
</td>
</tr>
</table>
</td>
</tr>

</TBODY></TABLE>
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="btnAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaImagenes" />
    <asp:PostBackTrigger ControlID="btnSiguiente" />
    <asp:PostBackTrigger ControlID="btnvAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaVideo" />
    <asp:PostBackTrigger ControlID="btnvSiguiente" />
    
    <asp:PostBackTrigger ControlID="lnkOk" />
    <asp:PostBackTrigger ControlID="lnkCerrarVideo" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

