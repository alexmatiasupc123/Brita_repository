<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Britanico_Radio, App_Web_q4xvelen" title="CENTRO CULTURAL BRITÁNICO - Británico en la Radio" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px; TEXT-ALIGN: justify" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 450px" align=right><asp:DataList id="dlRadio" runat="server" Width="100%" DataKeyField="brad_codi" HorizontalAlign="Right" CaptionAlign="Right" OnSelectedIndexChanged="dlRadio_SelectedIndexChanged"><ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 360px; HEIGHT: 16px" align=right><asp:LinkButton id="lnkRadio" runat="server" Font-Size="11px" Font-Names="Arial" Width="401px" Text='<%# Eval("brad_nomb") %>' CommandArgument='<%# Eval("brad_codi") %>' CommandName="Select" CssClass="linkDetalle"></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR><TR><TD style="WIDTH: 450px; HEIGHT: 25px"><BR /><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label> <BR />
<HR style="WIDTH: 100%" />
</TD></TR><TR><TD style="WIDTH: 100%; TEXT-ALIGN: left"><BR /><asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>   

