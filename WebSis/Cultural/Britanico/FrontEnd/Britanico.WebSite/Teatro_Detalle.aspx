<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Teatro_Detalle.aspx.cs" Inherits="Teatro_Detalle" Title="CENTRO CULTURAL BRITÁNICO - Teatro Británico" StylesheetTheme="SkinBritanico"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="HEIGHT: 25px" colSpan=3><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp;</TD></TR>

<tr>
<td style="WIDTH: 410px;" colspan="3">
<table>
<tr>
<td style="WIDTH: 215px;;">
 <%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_teatro_britanico); } %>
</td>
<td align=right style="WIDTH: 195px;">
<!-- Recomendar Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_recomendar_id(Session["idPadre"].ToString())); }%>
<!-- Recomendar Button End-->
</td>
</tr>
</table>
</td>
</tr>

<TR><TD style="TEXT-ALIGN: left" align=right colSpan=3><br />
<asp:Label id="lblSubtitulo" runat="server" Width="100%" CssClass="subtitulomayus"></asp:Label><BR /><BR /></TD></TR>
<TR><TD style="WIDTH: 75px; HEIGHT: 64px; " colSpan=1 valign=top align=left>
<asp:Image ID="imgFoto" runat="server" CssClass="imagen" Height="64px" ImageAlign="Left" Width="64px"  />
</TD>
<TD style="WIDTH: 335px; " colSpan=2 align=left>
<asp:Panel id="pDetalle" runat="server" Width="335px" BorderColor=transparent  BorderWidth=1    >
<TABLE style="WIDTH: 335px" cellSpacing=0 cellPadding=0 border=0 align=left ><TBODY>
<TR><TD style="WIDTH: 335px; " vAlign=top align="left"><asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR>
<TR><TD style="WIDTH: 335px; "><BR /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo"></asp:Label><BR /><BR /></TD></TR></TBODY></TABLE>
</asp:Panel> </TD></TR>
<TR><TD colSpan=3>
<asp:Panel id="pGaleria" runat="server" Width="100%" BackColor="#EEF0EF">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES"></asp:Label><BR /><asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px"><asp:DataList id="dlGaleriaImagenes" runat="server" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged" RepeatDirection="Horizontal"><ItemTemplate>
<asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <BR /><BR /><asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS"></asp:Label><BR /><asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle><asp:DataList id="dlGaleriaVideo" runat="server" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged" RepeatDirection="Horizontal"><ItemTemplate>
<asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="mpeImagen" runat="server" OkControlID="lnkOk" PopupControlID="pVerImagen" BackgroundCssClass="modalBackground" TargetControlID="btnImagenOculto">
    </cc1:ModalPopupExtender> <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR /><asp:Panel id="pVerImagen" runat="server" Width="500px" CssClass="modalPopup"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 519px; HEIGHT: 19px"><asp:Label id="lblDNombreGaleria" runat="server" CssClass="titulogaleria"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px" align=right><asp:LinkButton id="lnkOk" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><asp:Image id="dVerImagen" runat="server" CssClass="imagenGaleriaGrande"></asp:Image></TD></TR><TR><TD colSpan=2><asp:Label id="lbldTitulo" runat="server" CssClass="titulodgaleria"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="lbldDescripcion" runat="server" CssClass="textosdgaleria"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel><cc1:ModalPopupExtender id="mpeVideo" runat="server" OkControlID="lnkCerrarVideo" PopupControlID="pVerVideo" BackgroundCssClass="modalBackground" TargetControlID="btnVideoOculto"></cc1:ModalPopupExtender> <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR /><asp:Panel id="pVerVideo" runat="server" Width="500px" CssClass="modalPopup"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 519px; HEIGHT: 19px"><asp:Label id="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px" align=right><asp:LinkButton id="lnkCerrarVideo" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><BR /><asp:Literal id="video" runat="server" Text="video.innerhtml"></asp:Literal><BR /></TD></TR><TR><TD style="HEIGHT: 17px" colSpan=2><BR /><asp:Label id="lblTituloVideo" runat="server" CssClass="titulodgaleria"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="lblDescripcionVideo" runat="server" CssClass="textosdgaleria"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></TD></TR>
    <TR><TD style="HEIGHT: 40px; TEXT-ALIGN: right" colSpan=3><asp:HyperLink id="HyperLink1" runat="server" CssClass="linkDetalle" NavigateUrl="~/Teatro_Britanico.aspx" SkinID="Links" Font-Underline="True"><< VER TODOS</asp:HyperLink></TD></TR>
    
     
        <tr>
        <td style="WIDTH: 410px;" colspan="3">
        <table><tr>
        <td>
        <!-- Publicar Button Begin-->
        <%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_publicar(Convert.ToString(Session["url"]),Convert.ToString(Session["title"]))); }%>
        <!-- Publicar Button End-->
        </td>
        <td style="padding-left:15px;">
        <!-- AddThis Button -->
        <%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_compartir); }%>
        
        </div>
        
        
        <!-- AddThis Button END -->
        </td>
        </tr>
        </table>
        </td>
        </tr>
        
    
    <TR><TD style="TEXT-ALIGN: left" colSpan=3><BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" RepeatLayout="Flow"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR>
<TR><TD style="TEXT-ALIGN: left" colSpan=3><asp:ImageButton id="ImageButton2" runat="server" PostBackUrl="~/Teatro_Historia.aspx" ImageUrl="~/App_themes/Imagenes/historia_teatro.jpg"></asp:ImageButton></TD></TR>
<TR><TD style="WIDTH: 109px; HEIGHT: 5px; TEXT-ALIGN: left" colSpan=1></TD><TD style="WIDTH: 534px; HEIGHT: 5px; TEXT-ALIGN: left" colSpan=2></TD></TR>
<TR><TD style="TEXT-ALIGN: left" colSpan=3><asp:ImageButton id="ImageButton1" runat="server" PostBackUrl="~/Producciones_Teatrales.aspx" ImageUrl="~/App_themes/Imagenes/producciones_propias.jpg"></asp:ImageButton></TD></TR></TBODY></TABLE>
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
    <asp:PostBackTrigger ControlID="ImageButton2" />
    <asp:PostBackTrigger ControlID="ImageButton1" />
</Triggers>
    </asp:UpdatePanel>
</asp:Content>

