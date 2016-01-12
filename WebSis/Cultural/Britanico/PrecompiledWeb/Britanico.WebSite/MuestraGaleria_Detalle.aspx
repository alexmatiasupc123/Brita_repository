<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="MuestraGaleria_Detalle, App_Web_q4xvelen" title="CENTRO CULTURAL BRITÁNICO - Galería de Arte" stylesheettheme="SkinBritanico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
<asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; TEXT-ALIGN: left" align=left colSpan=2><asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<HR style="WIDTH: 100%" />
</TD></TR><TR><TD style="WIDTH: 100%; HEIGHT: 30px" align=right colSpan=2><BR /><BR /></TD></TR><TR><TD style="WIDTH: 410px; HEIGHT: 129px; TEXT-ALIGN: left" colSpan=2 rowSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("mues_imag") %>' Width="64px" Height="64px" CssClass="imagen" __designer:wfdid="w11" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server" __designer:wfdid="w12"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTituloDetalle" runat="server" CssClass="TituloDetalle" Text='<%# Eval("gale_nomb") %>' __designer:wfdid="w13"></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("mues_desc") %>' __designer:wfdid="w15"></asp:Label><BR /></TD></TR></TBODY></TABLE></asp:Panel>&nbsp;&nbsp;&nbsp;&nbsp;</TD></TR><TR></TR><TR><TD style="HEIGHT: 14px" align=right colSpan=2><asp:HyperLink id="HyperLink1" runat="server" Width="77px" SkinID="Links" NavigateUrl="~/Muestra_Galeria.aspx"><< VER TODOS</asp:HyperLink></TD></TR><TR><TD style="HEIGHT: 14px; TEXT-ALIGN: justify" colSpan=2><BR /><BR /><asp:DataList id="dlProximosEventos" runat="server" __designer:wfdid="w37" RepeatLayout="Flow" DataSourceID="odsProximosEventos" DataKeyField="info_codi"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" __designer:wfdid="w8" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" __designer:wfdid="w6" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" __designer:wfdid="w7" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList> <asp:ObjectDataSource id="odsProximosEventos" runat="server" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLInformacionNTAD" SelectMethod="ListarTodosXEvento">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="0" Name="even_tipo" Type="Int32" />
                        </SelectParameters>
                    </asp:ObjectDataSource> </TD></TR></TBODY></TABLE>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

