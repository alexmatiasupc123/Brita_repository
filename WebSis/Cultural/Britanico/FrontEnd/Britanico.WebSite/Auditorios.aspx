<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Auditorios.aspx.cs" Inherits="Auditorios" Title="CENTRO CULTURAL BRITÁNICO - Auditorios" StylesheetTheme="SkinBritanico" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%" align=right>
<asp:DataList id="dlSedes" runat="server" Width="100%" OnSelectedIndexChanged="dlSedes_SelectedIndexChanged" CaptionAlign="Right" HorizontalAlign="Right" DataKeyField="sede_codi">
<ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right>
<asp:LinkButton id="lnkSede" runat="server" Width="100%" Text='<%# Eval("sede_nomb") %>' CssClass="linkDetalle" CommandName="Select" CommandArgument='<%# Eval("sede_codi") %>'></asp:LinkButton></TD></TR></TBODY>
</TABLE>
</ItemTemplate>
</asp:DataList>&nbsp; 
</TD></TR>
<TR><TD style="WIDTH: 100%"><BR /><asp:Label id="lblTituloSede" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
</TD></TR><TR><TD style="WIDTH: 100%" align=right><asp:Label id="lblDireccionSede" runat="server" Width="100%" CssClass="subtitulomayus"></asp:Label><BR /><BR/></TD></TR>

<tr>
<td align=right style="WIDTH: 410px;" colspan="2">
<!-- Recomendar Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_recomendar_id(Convert.ToString(Session["id"]))); }%>
<!-- Recomendar Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 100%" vAlign=top><br /><asp:DataList id="dlAuditorio" runat="server" OnSelectedIndexChanged="dlAuditorio_SelectedIndexChanged" DataKeyField="prog_codi" OnItemDataBound="dlAuditorio_ItemDataBound"><ItemTemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 13px" colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("prog_imag") %>' Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w62" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w63"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTituloAuditorio" runat="server" Text='<%# Eval("prog_titu") %>' CssClass="TituloDetalle" __designer:wfdid="w64" Font-Bold="True"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" Text='<%# Eval("prog_desc") %>' __designer:wfdid="w65"></asp:Label></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" Text='<%# Eval("prog_temp") %>' CssClass="cuadroTextoRojo" __designer:wfdid="w67"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> <BR /></TD></TR><TR><TD style="WIDTH: 100px"></TD><TD style="WIDTH: 390px; HEIGHT: 13px"></TD></TR>
<TR><TD align=right colSpan=2>
<asp:LinkButton id="lnkDetalle" runat="server" CssClass="linkDetalle" __designer:wfdid="w68" CommandName="Select" CommandArgument='<%# Eval("prog_codi") %>' Font-Underline="True">+ DETALLE</asp:LinkButton></TD></TR></TBODY></TABLE>
<HR style="WIDTH: 100%" />
</ItemTemplate>
</asp:DataList></TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 12px"><BR /></TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 12px" vAlign=top>&nbsp;<BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" RepeatLayout="Flow" __designer:wfdid="w43"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" __designer:wfdid="w32" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" __designer:wfdid="w30" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" __designer:wfdid="w31" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> </TD></TR>

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
    <asp:PostBackTrigger ControlID="dlSedes" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

