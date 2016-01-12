<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CursoTaller_Detalle.aspx.cs" Inherits="CursoTaller_Detalle" Title="CENTRO CULTURAL BRITÁNICO - Cursos y Talleres" StylesheetTheme="SkinBritanico"%>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="HEIGHT: 83px" colSpan=2><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp; <BR /><asp:Label id="lblDireccionSede" runat="server" Width="100%" CssClass="subtitulomayus" Text="Label"></asp:Label><br /><br /></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;" colspan="2">
<!-- Me Gusta Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_megusta); }%>
<!-- Me Gusta Button End-->
</td>
</tr>

<TR><TD style="HEIGHT: 16px" colSpan=2><asp:Label id="lblSubtitulo" runat="server" CssClass="subtitulo"></asp:Label><BR /></TD></TR>
<TR><TD style="HEIGHT: 30px" colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("curs_imag") %>' Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left"></asp:Image> 
<asp:Panel id="pDetalle" runat="server"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="Label3" runat="server" Text="Profesor:" SkinID="camposNombre"></asp:Label> <asp:Label id="lblDirigido" runat="server" SkinID="camposNombre"></asp:Label><BR /><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("curs_desc") %>'></asp:Label><BR /><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR>
<TR>
<TD style="" colSpan=2>
<asp:Panel id="pGaleria" runat="server" Width="100%" Height="111" BackColor="#EEF0EF"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES"></asp:Label><BR /><asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px"><asp:DataList id="dlGaleriaImagenes" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged"><ItemTemplate>
<asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE>
</asp:Panel>
</TD></TR>
<TR>
<TD style="" colSpan=2>
<asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF"><BR />
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria"><asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS"></asp:Label><BR /><asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right><asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle>
<asp:DataList id="dlGaleriaVideo" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged"><ItemTemplate>
<asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
</ItemTemplate>
</asp:DataList></TD><TD style="WIDTH: 11px" vAlign=middle align=left><asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE>
</asp:Panel>
 <cc1:ModalPopupExtender id="mpeImagen" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkOk" PopupControlID="pVerImagen" TargetControlID="btnImagenOculto">
                </cc1:ModalPopupExtender>
                <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button>
                <BR />
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
                </asp:Panel> 
                <cc1:ModalPopupExtender id="mpeVideo" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkCerrarVideo" PopupControlID="pVerVideo" TargetControlID="btnVideoOculto">
                </cc1:ModalPopupExtender> 
                <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> 
                <BR />
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
                </asp:Panel> 
                </TD></TR>
                <TR><TD style="WIDTH: 18%; HEIGHT: 0px" colspan="2" ></TD></TR>
                
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
                <br />
                </td>
                </tr>
                
                <TR><TD style="HEIGHT: 16px" align=right colSpan=2><asp:HyperLink id="HyperLink1" runat="server" NavigateUrl="~/Cursos_Talleres.aspx" SkinID="Links"><< VER TODOS</asp:HyperLink></TD></TR>
                <TR><TD style="WIDTH: 18%"><br /></TD><TD style="WIDTH: 100%"></TD></TR>
                
                
             
                <TR><TD colSpan=2><BR /><asp:DataList id="dlProximosEventos" runat="server" RepeatLayout="Flow" DataKeyField="info_codi"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> </TD></TR></TBODY></TABLE>
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

