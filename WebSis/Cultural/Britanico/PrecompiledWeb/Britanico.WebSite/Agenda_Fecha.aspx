<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Agenda_Fecha, App_Web_q4xvelen" title="CENTRO CULTURAL BRIT�NICO - Agenda Cultural" %>

<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 410px; text-align:justify">
        <tr>
            <td  style="width: 100%; height: 13px">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
Descubre la opci�n cultural del Brit�nico, todo en un mes de novedades, m�sica, exposiciones, perfomance, poes�a, conferencias, entre otros.<BR /><BR /><TABLE cellSpacing=0 cellPadding=0 width=410 border=0><TBODY><TR><TD style="WIDTH: 200px; HEIGHT: 13px" align=left><asp:Label id="lblCriterio" runat="server" Width="200px" CssClass="titulo"></asp:Label></TD><TD style="WIDTH: 10px; HEIGHT: 13px" align=right></TD><TD style="WIDTH: 25px; HEIGHT: 13px">&nbsp;<asp:LinkButton id="lnkAAnterior" onclick="lnkAAnterior_Click" runat="server" Width="20px" CssClass="barraFechas" Font-Overline="False">| <<</asp:LinkButton></TD><TD style="WIDTH: 50px; HEIGHT: 13px"><asp:LinkButton id="lnkAnterior" onclick="lnkAnterior_Click" runat="server" CssClass="barraFechas" Font-Overline="False"></asp:LinkButton></TD><TD style="WIDTH: 10px; HEIGHT: 13px" align=center><asp:Label id="Label4" runat="server" CssClass="barraFechas" Text="|"></asp:Label></TD><TD style="WIDTH: 50px; HEIGHT: 13px"><asp:LinkButton id="lnkSiguiente" onclick="lnkSiguiente_Click" runat="server" CssClass="barraFechas" Font-Overline="False"></asp:LinkButton> </TD><TD style="WIDTH: 25px; HEIGHT: 13px" align=left><asp:LinkButton id="lnkSSiguiente" onclick="lnkSSiguiente_Click" runat="server" Width="20px" CssClass="barraFechas" Font-Overline="False" __designer:wfdid="w65">>> |</asp:LinkButton></TD></TR></TBODY></TABLE><TABLE style="BACKGROUND-IMAGE: url(App_themes/Imagenes/degradado.jpg); WIDTH: 410px; BACKGROUND-REPEAT: no-repeat; BACKGROUND-COLOR: #f2f3f5" cellSpacing=10 cellPadding=0 border=0><TBODY><TR><TD align=left><TABLE style="WIDTH: 390px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 390px; HEIGHT: 13px" align=right><asp:Label id="lblNombreDia" runat="server" CssClass="titulo"></asp:Label> </TD></TR><TR><TD style="WIDTH: 390px; HEIGHT: 13px" align=center>
<HR style="WIDTH: 100%" />
&nbsp;</TD></TR><TR><TD style="WIDTH: 411px; HEIGHT: 13px"><asp:DataList id="dlAgenda" runat="server" OnSelectedIndexChanged="dlAgenda_SelectedIndexChanged" DataKeyField="even_codi" OnItemDataBound="dlAgenda_ItemDataBound"><ItemTemplate>
<TABLE cellSpacing=0 cellPadding=0 width="100%" border=0><TBODY><TR><TD style="HEIGHT: 13px" colSpan=2><TABLE cellSpacing=0 cellPadding=0 width=390 border=0><TBODY><TR><TD style="WIDTH: 390px; HEIGHT: 13px"><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("even_imag") %>' Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w1" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w2"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTitulo" runat="server" Font-Size="12px" Text='<%# Eval("even_nomb") %>' __designer:wfdid="w3" Font-Bold="True"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("even_desc") %>' __designer:wfdid="w4"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo" Text='<%# Eval("even_temp") %>' __designer:wfdid="w54"></asp:Label></TD></TR></TBODY></TABLE></asp:Panel></TD></TR><TR><TD style="WIDTH: 390px; HEIGHT: 13px" align=right><BR /><asp:LinkButton id="lnkDetalle" runat="server" CssClass="linkDetalle" __designer:wfdid="w6" CommandName="Select" CommandArgument='<%# Eval("even_tipo") %>'>+ DETALLE</asp:LinkButton></TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 13px">
<HR style="WIDTH: 100%" />
&nbsp;</TD></TR></TBODY></TABLE>&nbsp;</TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList></TD></TR></TBODY></TABLE></TD></TR></TBODY></TABLE><TABLE style="WIDTH: 412px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 390px; HEIGHT: 12px; TEXT-ALIGN: right" align=right><asp:LinkButton id="lnkMesAnterior" onclick="lnkMesAnterior_Click" runat="server" Width="100%" CssClass="barraFechas" Font-Overline="False" __designer:wfdid="w64">| << Meses Anteriores</asp:LinkButton></TD></TR></TBODY></TABLE><BR /><BR /><BR /><BR />
</contenttemplate>
    </asp:UpdatePanel></td>
        </tr>
    </table>
</asp:Content>

