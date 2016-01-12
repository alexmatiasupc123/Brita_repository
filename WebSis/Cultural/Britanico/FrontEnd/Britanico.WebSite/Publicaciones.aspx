<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Publicaciones.aspx.cs" Inherits="Publicaciones" Title="CENTRO CULTURAL BRITÁNICO - Publicaciones" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD align=right><asp:DataList id="dlPublicaciones" runat="server" Width="100%" OnSelectedIndexChanged="dlPublicaciones_SelectedIndexChanged" CaptionAlign="Right" HorizontalAlign="Right" DataKeyField="publ_codi"><ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right><asp:LinkButton id="lnkPublicacion" runat="server" Width="100%" CssClass="linkDetalle" __designer:wfdid="w49" CommandName="Select" CommandArgument='<%# Eval("publ_codi") %>' Text='<%# Eval("publ_nomb") %>'></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR>
<TR><TD style="WIDTH: 100%; HEIGHT: 25px"><BR /><asp:Label id="lblTitulo" runat="server" width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
&nbsp;<BR /><asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;">
<!-- Me Gusta Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_megusta_id(Convert.ToString(Session["id"]))); }%>
<!-- Me Gusta Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 100%; TEXT-ALIGN: left"><br /><asp:Label id="lblSubtitulo" runat="server" CssClass="subtitulo" SkinID="camposNombre"></asp:Label><BR /><BR /></TD></TR><TR><TD style="WIDTH: 100%"><asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR>
<TR><TD style="WIDTH: 100%"><br /><br /></TD></TR>

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

<TR><TD style="WIDTH: 100%"></TD></TR></TBODY></TABLE>
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlPublicaciones" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

