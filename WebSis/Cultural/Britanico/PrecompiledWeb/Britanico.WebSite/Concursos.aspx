<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Concursos, App_Web_q4xvelen" title="CENTRO CULTURAL BRITÁNICO - Concursos" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
   
    
    <table border="0" cellpadding="0" cellspacing="0" style="width: 410px">
        <tr>
            <td align="left" style="width: 100%; height: 12px">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
<TABLE style="WIDTH: 100%; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="WIDTH: 100%" align="justify">
<asp:DataList id="dlConcursos" runat="server" Width="100%" OnSelectedIndexChanged="dlConcursos_SelectedIndexChanged" CaptionAlign="Right" HorizontalAlign="Right" DataKeyField="conc_codi">
<ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right><asp:LinkButton id="lnkConcurso" runat="server" Width="100%" CssClass="linkDetalle" Text='<%# Eval("conc_nomb") %>' CommandName="Select" CommandArgument='<%# Eval("conc_codi") %>'></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList> &nbsp;&nbsp; </TD></TR>
<TR><TD style="WIDTH: 100%" align=left><BR /><BR /><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label> <BR />
<HR style="WIDTH: 100%" />
</TD></TR>
<TR><TD style="WIDTH: 100%" align=right><asp:Label id="lblAnio" runat="server" Width="100%" CssClass="subtitulomayus" Font-Bold="True"></asp:Label><br /><br /></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;">
<!-- Me Gusta Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_megusta_id(Convert.ToString(Session["id"]))); }%>
<!-- Me Gusta Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 100%; HEIGHT: 15px"><br /><br /><asp:Label id="lblSubtitulo" runat="server" Width="100%" CssClass="subtitulo"></asp:Label></TD></TR>
<TR><TD style="WIDTH: 100%;">
<asp:Image id="imgFoto" runat="server" CssClass="imagen" ImageAlign="Left" Visible="false" ></asp:Image> 
<asp:Panel id="pDetalle" runat="server">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD  style="WIDTH: 100%" vAlign=top class="cuadroTextoContenido">
<%=lblContenido%>
</TD></TR>
<TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top>
<asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo"></asp:Label> <BR /><BR />
<asp:Label id="lblPremios" runat="server" CssClass="cuadroTextoRojo"></asp:Label><BR /></TD></TR></TBODY></TABLE>
</asp:Panel>&nbsp;<BR /><BR /> <BR /><BR /><BR /></TD></TR>

<tr>
<td style="WIDTH: 410px;">
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

<TR><TD style="WIDTH: 100%"><BR />
<asp:Panel id="pGaleria" runat="server" Width="100%" BackColor="#EEF0EF">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES"></asp:Label><BR /><asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px"><asp:DataList id="dlGaleriaImagenes" runat="server" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged" RepeatDirection="Horizontal"><ItemTemplate>
<asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <BR /><BR />
<asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS"></asp:Label><BR /><asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle><asp:DataList id="dlGaleriaVideo" runat="server" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged" RepeatDirection="Horizontal"><ItemTemplate>
<asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> <cc1:ModalPopupExtender id="mpeImagen" runat="server" TargetControlID="btnImagenOculto" BackgroundCssClass="modalBackground" PopupControlID="pVerImagen" OkControlID="lnkOk">
    </cc1:ModalPopupExtender> <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR /><asp:Panel id="pVerImagen" runat="server" Width="500px" CssClass="modalPopup"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 519px; HEIGHT: 19px"><asp:Label id="lblDNombreGaleria" runat="server" CssClass="titulogaleria"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px" align=right><asp:LinkButton id="lnkOk" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><asp:Image id="dVerImagen" runat="server" CssClass="imagenGaleriaGrande"></asp:Image></TD></TR><TR><TD colSpan=2><asp:Label id="lbldTitulo" runat="server" CssClass="titulodgaleria"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="lbldDescripcion" runat="server" CssClass="textosdgaleria"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel><cc1:ModalPopupExtender id="mpeVideo" runat="server" TargetControlID="btnVideoOculto" BackgroundCssClass="modalBackground" PopupControlID="pVerVideo" OkControlID="lnkCerrarVideo"></cc1:ModalPopupExtender> <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR /><asp:Panel id="pVerVideo" runat="server" Width="500px" CssClass="modalPopup"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 519px; HEIGHT: 19px"><asp:Label id="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></TD><TD style="WIDTH: 100px; HEIGHT: 19px" align=right><asp:LinkButton id="lnkCerrarVideo" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></TD></TR><TR><TD style="TEXT-ALIGN: center" colSpan=2><BR /><asp:Literal id="video" runat="server" Text="video.innerhtml"></asp:Literal><BR /></TD></TR><TR><TD style="HEIGHT: 17px" colSpan=2><BR /><asp:Label id="lblTituloVideo" runat="server" CssClass="titulodgaleria"></asp:Label></TD></TR><TR><TD colSpan=2><asp:Label id="lblDescripcionVideo" runat="server" CssClass="textosdgaleria"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD style="WIDTH: 100%">
<HR style="WIDTH: 100%" />
<asp:ImageButton id="btnBases" onclick="btnBases_Click" runat="server" ImageUrl="~/App_themes/Imagenes/bases_concurso.jpg"></asp:ImageButton> <asp:Panel id="pBases" runat="server" Width="100%" CssClass="panel" ScrollBars="Vertical">
    <br />
    <asp:Label id="lblBase" runat="server"></asp:Label><br />
    <br />
</asp:Panel> <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="pBases" CollapseControlID="btnBases" ExpandControlID="btnBases" Collapsed="true"></cc1:CollapsiblePanelExtender> <asp:ImageButton id="btnResultados" onclick="btnResultados_Click" runat="server" ImageUrl="~/App_themes/Imagenes/result_concurso.jpg"></asp:ImageButton><asp:Panel id="pResultados" runat="server" Width="100%" CssClass="panel" ScrollBars="Vertical">
    <br />
    <asp:Label id="lblResultados" runat="server"></asp:Label><br />
    <br />
</asp:Panel> <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender2" runat="server" TargetControlID="pResultados" CollapseControlID="btnResultados" ExpandControlID="btnResultados" Collapsed="true"></cc1:CollapsiblePanelExtender> <asp:ImageButton id="btnComentarios" runat="server" ImageUrl="~/App_themes/Imagenes/comentarios_concurso.jpg"></asp:ImageButton><asp:Panel id="pComentarios" runat="server" Width="100%" CssClass="panel" ScrollBars="Vertical">
    <br />
    <asp:Label id="lblComentarios" runat="server"></asp:Label><br />
    <br />
</asp:Panel> <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender3" runat="server" TargetControlID="pComentarios" CollapseControlID="btnComentarios" ExpandControlID="btnComentarios" Collapsed="true"></cc1:CollapsiblePanelExtender> </TD></TR></TBODY></TABLE>
</ContentTemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlConcursos" />
    <asp:PostBackTrigger ControlID="btnAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaImagenes" />
    <asp:PostBackTrigger ControlID="btnSiguiente" />
    <asp:PostBackTrigger ControlID="btnvAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaVideo" />
    <asp:PostBackTrigger ControlID="btnvSiguiente" />

    <asp:PostBackTrigger ControlID="lnkOk" />
    <asp:PostBackTrigger ControlID="lnkCerrarVideo" />
    <asp:PostBackTrigger ControlID="btnBases" />
    <asp:PostBackTrigger ControlID="btnResultados" />
    <asp:PostBackTrigger ControlID="btnComentarios" />
    </Triggers>
                </asp:UpdatePanel>
</td>
        </tr>
        <tr>
            <td style="width: 100%" align="left">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 5px">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 13px;">
                    
</td>
        </tr>
    </table>
</asp:Content>

