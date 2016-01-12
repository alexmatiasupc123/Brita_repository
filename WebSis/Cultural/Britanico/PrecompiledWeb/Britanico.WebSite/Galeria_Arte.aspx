<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" enableeventvalidation="false" inherits="Galeria_Arte, App_Web_q4xvelen" title="CENTRO CULTURAL BRITÁNICO - Galería de Arte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; TEXT-ALIGN: right">
<asp:DataList id="dlGaleria" runat="server" Width="100%" DataKeyField="gale_codi" CaptionAlign="Right" OnSelectedIndexChanged="dlGaleria_SelectedIndexChanged">
<ItemTemplate>
<asp:LinkButton id="lnkGaleria" runat="server" Width="100%" CssClass="linkDetalle" Text='<%# Eval("gale_nomb") %>' CommandName="Select" CommandArgument='<%# Eval("gale_codi") %>' __designer:wfdid="w23"></asp:LinkButton> 
</ItemTemplate>
</asp:DataList> </TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 68px">
<asp:Label id="lblTituloGaleria" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR />
</TD></TR><TR><TD style="WIDTH: 100%;" align=right>
<asp:Label id="lblDireccion" runat="server" Width="100%" CssClass="subtitulomayus"></asp:Label><br /><br /></TD></TR>

<tr>
<td align=right style="WIDTH: 100%" colspan="2"  >
<!-- Recomendar Button Begin-->
<asp:Literal ID="litRecomendar" runat="server" ></asp:Literal>
<!-- Recomendar Button End-->
</td>
</tr>

<TR><TD style="WIDTH: 100px; HEIGHT: 16px; TEXT-ALIGN: left"><asp:Label id="lblDescripcion" runat="server"></asp:Label> </TD></TR>
<TR><TD style="WIDTH: 100px">
<asp:DataList id="dlDetalleGaleria" runat="server" Width="100%" DataKeyField="gade_codi" OnSelectedIndexChanged="dlDetalleGaleria_SelectedIndexChanged" OnItemDataBound="dlDetalleGaleria_ItemDataBound"><ItemTemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 13px" vAlign=top align=left colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("gade_imag") %>' Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w24" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w25"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTituloDetalleGaleria" runat="server" CssClass="TituloDetalle" Text='<%# Eval("gade_nomb") %>' __designer:wfdid="w26"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("gade_desc") %>' __designer:wfdid="w27"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo" Text='<%# Eval("gade_temp") %>' __designer:wfdid="w28"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> &nbsp;&nbsp;</TD></TR>
<TR><TD align=right colSpan=2 rowSpan=2>
<asp:LinkButton id="LinkButton1" runat="server" CssClass="linkDetalle" CommandName="Select" __designer:wfdid="w29" Font-Bold="False">+ DETALLE</asp:LinkButton></TD></TR>
<TR></TR><TR><TD style="WIDTH: 100%; HEIGHT: 16px" colSpan=2>
<HR style="WIDTH: 100%" />
</TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList></TD></TR>

<tr>
<td style="WIDTH: 100%;" colspan="1" >
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

<TR><TD style="WIDTH: 100px; HEIGHT: 13px"><br />
<asp:ImageButton id="btnHistoria" onclick="btnHistoria_Click" runat="server" ImageUrl="~/App_themes/Imagenes/historia_galeria.jpg"></asp:ImageButton> 
<asp:Panel id="pHistoria" runat="server" Width="400px" Height="50px" ScrollBars="Vertical" BorderColor="#E0E0E0">
        <asp:Label ID="lblHistoria" runat="server" CssClass="cuadroTextoContenido" Width="400px"></asp:Label></asp:Panel> 
        <cc1:CollapsiblePanelExtender id="CollapsiblePanelExtender1" runat="server" TargetControlID="pHistoria" ExpandControlID="btnHistoria" Collapsed="true" CollapseControlID="btnHistoria">
    </cc1:CollapsiblePanelExtender> </TD></TR>
<TR><TD style="WIDTH: 100px; HEIGHT: 13px"><BR />
    <asp:ImageButton id="btnMuestras" onclick="btnMuestras_Click" runat="server" ImageUrl="~/App_themes/Imagenes/muestra_galeria.jpg" __designer:wfdid="w2"></asp:ImageButton></TD></TR>
<TR><TD><BR /><BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" __designer:wfdid="w34" RepeatLayout="Flow"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" __designer:wfdid="w23" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" __designer:wfdid="w21" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" __designer:wfdid="w22" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR><TR><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE><BR />
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlGaleria" />
    <asp:AsyncPostBackTrigger ControlID="btnHistoria" />
    <asp:PostBackTrigger ControlID="btnMuestras" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

