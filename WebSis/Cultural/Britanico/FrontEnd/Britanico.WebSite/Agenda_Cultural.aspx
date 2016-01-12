<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Agenda_Cultural.aspx.cs" Inherits="Agenda_Cultural" Title="CENTRO CULTURAL BRITÁNICO - Agenda Cultural" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY>
<TR><TD style="WIDTH: 100%">
<asp:Image id="imgFoto" runat="server" Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left" Visible="false"></asp:Image>
             <asp:Label id="lblContenido" runat="server">
Descubre la opción cultural del Británico, todo en un mes de novedades, música, exposiciones, perfomance, poesía, conferencias, entre otros.
            </asp:Label>
<BR /><BR />
<asp:Label id="lblCriterio" runat="server" SkinID="camposNombre"></asp:Label> <BR /><BR />
<HR style="WIDTH: 100%" />
</TD></TR>
<TR><TD style="WIDTH: 100%"><BR />
<asp:Label id="lblClave" runat="server" Width="100%" CssClass="subtitulo"></asp:Label><BR /><BR /></TD></TR>
<TR><TD style="WIDTH: 100%">
<asp:DataList id="dlAgenda" runat="server" OnSelectedIndexChanged="dlAgenda_SelectedIndexChanged" DataKeyField="even_codi" OnItemDataBound="dlAgenda_ItemDataBound"><ItemTemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 13px" vAlign=top colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("even_imag") %>' Width="64px" Height="64px" __designer:dtid="281474976710686" CssClass="imagen" __designer:wfdid="w56" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:dtid="281474976710687" __designer:wfdid="w57"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0 __designer:dtid="281474976710688"><TBODY><TR __designer:dtid="281474976710689"><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top __designer:dtid="281474976710690"><asp:Label id="lblTitulo" runat="server" Font-Size="12px" __designer:wfdid="w58" Text='<%# Eval("even_nomb") %>' Font-Bold="True"></asp:Label><BR __designer:dtid="281474976710692" /></TD></TR><TR __designer:dtid="281474976710693"><TD style="WIDTH: 95%; HEIGHT: 29px" __designer:dtid="281474976710694"><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" __designer:wfdid="w59" Text='<%# Eval("even_desc") %>'></asp:Label><BR /></TD></TR><TR __designer:dtid="281474976710697"><TD style="WIDTH: 95%; HEIGHT: 29px" __designer:dtid="281474976710698"><BR __designer:dtid="281474976710699" /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo" __designer:wfdid="w60" Text='<%# Eval("even_temp") %>'></asp:Label></TD></TR></TBODY></TABLE></asp:Panel><BR /></TD></TR><TR><TD style="WIDTH: 71px"></TD><TD style="WIDTH: 390px; HEIGHT: 13px"></TD></TR><TR><TD style="WIDTH: 71px"></TD><TD style="WIDTH: 390px; HEIGHT: 13px; TEXT-ALIGN: right"><asp:LinkButton id="lnkDetalle" runat="server" CssClass="linkDetalle" __designer:wfdid="w61" CommandName="Select" CommandArgument='<%# Eval("even_tipo") %>'>+ DETALLE</asp:LinkButton></TD></TR></TBODY></TABLE>
<HR style="WIDTH: 100%" />
</ItemTemplate>
</asp:DataList></TD></TR><TR><TD style="WIDTH: 100%"></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

