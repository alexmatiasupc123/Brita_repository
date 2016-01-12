<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Cursos_Talleres.aspx.cs" Inherits="Cursos_Talleres" Title="CENTRO CULTURAL BRITÁNICO - Cursos y Talleres" %>
<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 414px" align=right>
<asp:DataList id="dlSedes" runat="server" Width="100%" OnSelectedIndexChanged="dlSedes_SelectedIndexChanged" CaptionAlign="Right" DataKeyField="sede_codi" HorizontalAlign="Right">
<ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right><asp:LinkButton id="lnkSede" runat="server" Width="100%" Text='<%# Eval("sede_nomb") %>' CssClass="linkDetalle" CommandArgument='<%# Eval("sede_codi") %>' CommandName="Select" __designer:wfdid="w1"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList><BR /><BR />&nbsp; </TD></TR>
<TR><TD style="WIDTH: 414px; HEIGHT: 15px"><BR /><BR /><asp:Label id="lblTituloSede" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp;</TD></TR>
<TR><TD style="WIDTH: 414px; HEIGHT: 26px; TEXT-ALIGN: right" align=right>
<asp:Label id="lblDireccionSede" runat="server" Width="100%" CssClass="subtitulomayus"></asp:Label><BR /><BR /></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;" colspan="2">
<!-- Me Gusta Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_megusta_id(Convert.ToString(Session["id"]))); }%>
<!-- Me Gusta Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 414px" vAlign=top><br />
<asp:DataList id="dlCursos" runat="server" OnSelectedIndexChanged="dlCursos_SelectedIndexChanged" DataKeyField="curs_codi" OnItemDataBound="dlCursos_ItemDataBound"><ItemTemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="WIDTH: 410px; HEIGHT: 16px; TEXT-ALIGN: left" colSpan=2>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="HEIGHT: 13px" vAlign=top align=left colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("curs_imag") %>' Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w42" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w43">
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTituloCurso" runat="server" Font-Size="12px" Text='<%# Eval("curs_titu") %>' __designer:wfdid="w44" Font-Bold="True"></asp:Label><BR /><asp:Label id="lblDirige" runat="server" Text='<%# Eval("curs_prof") %>' CssClass="subtituloPlomo" __designer:wfdid="w40" Font-Bold="True"></asp:Label></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblContenido" runat="server" Text='<%# Eval("curs_desc") %>' CssClass="cuadroTextoContenido" __designer:wfdid="w46"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" Text='<%# Eval("curs_hora") %>' CssClass="cuadroTextoRojo" __designer:wfdid="w47"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> &nbsp;&nbsp;</TD></TR>
<TR><TD align=right colSpan=2 rowSpan=2><asp:LinkButton id="lnkDetalle" runat="server" CssClass="linkDetalle" __designer:wfdid="w48" CommandArgument='<%# Eval("curs_codi") %>' CommandName="Select">+ DETALLE</asp:LinkButton></TD></TR><TR></TR>
<TR><TD style="WIDTH: 100%; HEIGHT: 16px" colSpan=2>
<HR style="WIDTH: 100%" />
</TD></TR>
</TBODY></TABLE></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList></TD></TR>

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
<!-- AddThis Button END -->
</td>
</tr>
</table>
</td>
</tr>

<TR><TD style="WIDTH: 414px; HEIGHT: 13px"><BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" RepeatLayout="Flow" __designer:wfdid="w52"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" __designer:wfdid="w26" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" __designer:wfdid="w24" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" __designer:wfdid="w25" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> </TD></TR></TBODY></TABLE>
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlSedes" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

