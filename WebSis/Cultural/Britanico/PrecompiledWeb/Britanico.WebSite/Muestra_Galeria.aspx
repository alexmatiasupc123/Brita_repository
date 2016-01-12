<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Muestra_Galeria, App_Web_xruf4ash" title="CENTRO CULTURAL BRITÁNICO - Galería de Arte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; HEIGHT: 88px; TEXT-ALIGN: right"><asp:DataList id="dlGaleria" runat="server" Width="100%" DataKeyField="gale_codi" CaptionAlign="Right" OnSelectedIndexChanged="dlGaleria_SelectedIndexChanged" __designer:wfdid="w3"><ItemTemplate>
<asp:LinkButton id="lnkGaleria" runat="server" Width="100%" CssClass="linkDetalle" Text='<%# Eval("gale_nomb") %>' CommandName="Select" CommandArgument='<%# Eval("gale_codi") %>' __designer:wfdid="w23"></asp:LinkButton> 
</ItemTemplate>
</asp:DataList>&nbsp;</TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 48px"><asp:Label id="lblTituloGaleria" runat="server" Width="100%" __designer:wfdid="w4" CssClass="titulo"></asp:Label><BR />
<HR />
</TD></TR><TR><TD style="WIDTH: 100%" align=right><asp:Label id="lblDireccion" runat="server" Width="100%" __designer:wfdid="w5" CssClass="subtitulomayus"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 25px; TEXT-ALIGN: left"></TD></TR><TR><TD style="WIDTH: 100px"><asp:DataList id="dlDetalleMuestra" runat="server" Width="100%" DataKeyField="mues_codi" OnSelectedIndexChanged="dlDetalleMuestra_SelectedIndexChanged" OnItemDataBound="dlDetalleMuestra_ItemDataBound"><ItemTemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 13px" vAlign=top align=left colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("mues_imag") %>' Width="64px" Height="64px" __designer:wfdid="w1" CssClass="imagen" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w2"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 17px" vAlign=top><asp:Label id="lblSubtitulo" runat="server" __designer:wfdid="w3" CssClass="TituloDetalle" Text='<%# Eval("mues_nomb") %>'></asp:Label></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" __designer:wfdid="w5" CssClass="cuadroTextoContenido" Text='<%# Eval("mues_desc") %>'></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel> &nbsp;&nbsp;</TD></TR><TR><TD align=right colSpan=2 rowSpan=2><asp:LinkButton id="LinkButton1" runat="server" __designer:wfdid="w6" CssClass="linkDetalle" Font-Bold="False" CommandName="Select">+ DETALLE</asp:LinkButton></TD></TR><TR></TR><TR><TD style="WIDTH: 100%; HEIGHT: 16px" colSpan=2>
<HR style="WIDTH: 100%" />
</TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 13px">&nbsp;</TD></TR><TR><TD><BR /><BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" __designer:wfdid="w34" DataSourceID="odsProximosEventos" RepeatLayout="Flow"><HeaderTemplate>
<asp:Label id="Label5" runat="server" __designer:wfdid="w11" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" __designer:wfdid="w9" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" __designer:wfdid="w10" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> <asp:ObjectDataSource id="odsProximosEventos" runat="server" SelectMethod="ListarTodosXEvento" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLInformacionNTAD">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="even_tipo" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource> </TD></TR><TR><TD style="WIDTH: 100px"></TD></TR></TBODY></TABLE><BR />
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

