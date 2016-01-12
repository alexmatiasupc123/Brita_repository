<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Noticia_Detalle.aspx.cs" Inherits="Noticia_Detalle" Title="CENTRO CULTURAL BRITÁNICO - Noticias" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="WIDTH: 100%" align=right>
<asp:DataList id="dlNoticias" runat="server" Width="100%" CaptionAlign="Right" HorizontalAlign="Right" DataKeyField="noti_codi" OnSelectedIndexChanged="dlNoticias_SelectedIndexChanged">
<ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right>
<asp:LinkButton id="lnkNoticia" runat="server" Width="100%" CssClass="linkDetalle" __designer:wfdid="w101" CommandArgument='<%# Eval("noti_codi") %>' CommandName="Select" Text='<%# Eval("noti_titu") %>'></asp:LinkButton></TD></TR></TBODY>
</TABLE>
</ItemTemplate>
</asp:DataList>&nbsp; 
</TD></TR>

<tr>
<td align=right style="WIDTH: 410px;">
<!-- Recomendar Button Begin-->
<asp:Literal ID="litRecomendar" runat="server" ></asp:Literal>
<!-- Recomendar Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 100%" align=left><BR />
<asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR /><BR /> 
<HR style="WIDTH: 100%" />
<BR /><asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></TD></TR>
<TR><TD style="WIDTH: 100%">
<asp:Label id="lblSubtitulo" runat="server" CssClass="subtitulo" SkinID="camposNombre"></asp:Label><BR /><BR /></TD></TR>
<TR><TD style="WIDTH: 100%" align=left>
<asp:Image id="imgFoto" runat="server" Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w4" ImageAlign="Left"></asp:Image>
 <asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR>
<TR><TD style="WIDTH: 100%"><br /></TD></TR>
 
<tr>
<td style="WIDTH: 410px;">
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

 </TBODY></TABLE>
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlNoticias" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

