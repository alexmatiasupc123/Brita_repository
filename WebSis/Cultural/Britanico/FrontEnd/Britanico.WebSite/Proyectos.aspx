<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Proyectos.aspx.cs" Inherits="Proyectos" Title="CENTRO CULTURAL BRITÁNICO - Proyectos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%" align=right>
<asp:DataList id="dlProyectos" runat="server" Width="100%" DataKeyField="proy_codi" HorizontalAlign="Right" CaptionAlign="Right" OnSelectedIndexChanged="dlProyectos_SelectedIndexChanged"><ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 16px" align=right><asp:LinkButton id="lnkProyecto" runat="server" Width="100%" CssClass="linkDetalle" __designer:wfdid="w48" CommandName="Select" CommandArgument='<%# Eval("proy_codi") %>' Text='<%# Eval("proy_nomb") %>'></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR>
<TR><TD style="WIDTH: 100%; HEIGHT: 25px"><BR /><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR /> 
 <HR style="WIDTH: 100%" />
 <asp:Label id="lblError" runat="server" CssClass="error" __designer:wfdid="w32"></asp:Label><BR />
 </td>
 </tr>
 
 <tr>
<td align=right style="WIDTH: 410px;">
<!-- Me Gusta Button Begin-->
<%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_megusta_id(Convert.ToString(Session["id"]))); }%>
<!-- Me Gusta Button End-->
</td>
</tr>
 
 <tr>
 <td style="WIDTH: 100%;"><br />
 <asp:Image id="imgFoto" runat="server"  Width="64px" Height="64px" __designer:dtid="5348024557502484" CssClass="imagen" __designer:wfdid="w27" ImageAlign="Left"></asp:Image> 
 <asp:Panel id="pDetalle" runat="server" __designer:dtid="5348024557502485" __designer:wfdid="w28">
 <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0 __designer:dtid="5348024557502486"><TBODY>
 <TR __designer:dtid="5348024557502487"><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top __designer:dtid="5348024557502488"><asp:Label id="lblSubtitulo" runat="server" Font-Size="12px" __designer:dtid="5348024557502489"  __designer:wfdid="w23" Font-Bold="True"></asp:Label></TD></TR><TR __designer:dtid="5348024557502490"><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top __designer:dtid="5348024557502491"><asp:Label id="lblContenido" runat="server" __designer:dtid="5348024557502492" CssClass="cuadroTextoContenido"  __designer:wfdid="w24"></asp:Label><BR __designer:dtid="5348024557502493" /><br /></TD></TR></TBODY></TABLE></asp:Panel></TD></TR>
 
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
    <asp:PostBackTrigger ControlID="dlProyectos" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

