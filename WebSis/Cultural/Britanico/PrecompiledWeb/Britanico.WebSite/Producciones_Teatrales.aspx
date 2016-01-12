<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Producciones_Teatrales, App_Web_xruf4ash" title="CENTRO CULTURAL BRIT�NICO - Producciones Teatrales" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 450px" align=right>
<asp:DataList id="dlProducciones" runat="server" Width="100%" OnSelectedIndexChanged="dlProducciones_SelectedIndexChanged" CaptionAlign="Right" HorizontalAlign="Right" DataKeyField="prod_codi"><ItemTemplate>
<TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%" align=right>
<asp:LinkButton id="lnkProduccion" runat="server" Width="100%" CssClass="linkDetalle" CommandArgument='<%# Eval("prod_codi") %>' CommandName="Select" Text='<%# Eval("prod_nomb") %>'></asp:LinkButton></TD></TR></TBODY></TABLE>
</ItemTemplate>
</asp:DataList>
&nbsp; </TD></TR><TR><TD style="WIDTH: 450px; HEIGHT: 25px"><BR />
<asp:Label id="lblTitulo" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR /><BR /> 
<HR style="WIDTH: 100%" />
<BR /></TD></TR>
<TR><TD style="WIDTH: 450px; HEIGHT: 13px; TEXT-ALIGN: left">
<asp:Label id="lblContenido" runat="server"></asp:Label></TD></TR>

<TR><TD ><br /><br />
                <asp:Panel id="pGaleria" runat="server" Width="100%" BackColor="#EEF0EF">
                <TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; HEIGHT: 24px; TEXT-ALIGN: center" class="capaGaleria">
                <asp:Label id="Label1" runat="server" CssClass="titulogaleria" Text="IMAGENES"></asp:Label><BR />
                <asp:Label id="lblNombreGaleriaImagen" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right>
                <asp:ImageButton id="btnAnterior" onclick="btnAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px">
                <asp:DataList id="dlGaleriaImagenes" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaImagenes_SelectedIndexChanged"><ItemTemplate>
                <asp:ImageButton id="btnImagen" onclick="btnImagen_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton> 
                </ItemTemplate>
                </asp:DataList>
                </TD><TD style="WIDTH: 11px" vAlign=middle align=left>
                <asp:ImageButton id="btnSiguiente" onclick="btnSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel> </TD></TR><TR><TD colSpan=2><BR /><BR />
                <asp:Panel id="pVideo" runat="server" Width="100%" BackColor="#EEF0EF"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 114px" vAlign=middle><BR /><DIV style="WIDTH: 105px; TEXT-ALIGN: center" class="capaGaleria">
                <asp:Label id="Label2" runat="server" CssClass="titulogaleria" Text="VIDEOS"></asp:Label><BR />
                <asp:Label id="lblNombreGaleriaVideo" runat="server" CssClass="titulogaleria" Visible="False"></asp:Label></DIV></TD><TD style="WIDTH: 11px" vAlign=middle align=right>
                <asp:ImageButton id="btnvAnterior" onclick="btnvAnterior_Click" runat="server" ImageUrl="~/App_themes/Imagenes/anterior.jpg" AlternateText="<< Anterior"></asp:ImageButton></TD><TD style="WIDTH: 274px" vAlign=middle>
                <asp:DataList id="dlGaleriaVideo" runat="server" RepeatDirection="Horizontal" OnSelectedIndexChanged="dlGaleriaVideo_SelectedIndexChanged"><ItemTemplate>
                <asp:ImageButton id="btnVideo" onclick="btnVideo_Click" runat="server" ImageUrl='<%# Eval("arch_arch") %>' Width="64px" Height="64px" CssClass="imagenGaleria" CommandArgument='<%# Eval("arch_codi") %>'></asp:ImageButton>
                </ItemTemplate>
                </asp:DataList>
                </TD><TD style="WIDTH: 11px" vAlign=middle align=left>
                <asp:ImageButton id="btnvSiguiente" onclick="btnvSiguiente_Click" runat="server" ImageUrl="~/App_themes/Imagenes/siguiente.jpg" AlternateText="Siguiente >>"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel>
                <cc1:ModalPopupExtender id="mpeImagen" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkOk" PopupControlID="pVerImagen" TargetControlID="btnImagenOculto">
                </cc1:ModalPopupExtender> 
                <asp:Button id="btnImagenOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR />
                <asp:Panel id="pVerImagen" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblDNombreGaleria" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkOk" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <asp:Image ID="dVerImagen" runat="server" CssClass="imagenGaleriaGrande" /></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbldTitulo" runat="server" CssClass="titulodgaleria"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lbldDescripcion" runat="server" CssClass="textosdgaleria"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel> 
                <cc1:ModalPopupExtender id="mpeVideo" runat="server" BackgroundCssClass="modalBackground" OkControlID="lnkCerrarVideo" PopupControlID="pVerVideo" TargetControlID="btnVideoOculto">
                </cc1:ModalPopupExtender>
                 <asp:Button id="btnVideoOculto" runat="server" BackColor="White" BorderColor="White" BorderStyle="None"></asp:Button> <BR />
                 <asp:Panel id="pVerVideo" runat="server" Width="500px" CssClass="modalPopup">
                    <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                        <tr>
                            <td style="width: 519px; height: 19px">
                                <asp:Label ID="lblGaleriaVideo" runat="server" CssClass="titulogaleria"></asp:Label></td>
                            <td align="right" style="width: 100px; height: 19px">
                                <asp:LinkButton ID="lnkCerrarVideo" runat="server" CssClass="linkDetalle" Font-Bold="True">Cerrar (x)</asp:LinkButton></td>
                        </tr>
                        <tr>
                            <td colspan="2" style="text-align: center">
                                <br />
                                <asp:Literal ID="video" runat="server" Text="video.innerhtml"></asp:Literal><br />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="height: 17px">
                                <br />
                                <asp:Label ID="lblTituloVideo" runat="server" CssClass="titulodgaleria"></asp:Label></td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="lblDescripcionVideo" runat="server" CssClass="textosdgaleria"></asp:Label></td>
                        </tr>
                    </table>
                </asp:Panel>
                 </TD></TR>

<TR><TD style="WIDTH: 450px"></TD></TR>
<TR><TD style="WIDTH: 450px"><BR />
<asp:ImageButton id="ImageButton2" runat="server" PostBackUrl="~/Teatro_Historia.aspx" ImageUrl="~/App_themes/Imagenes/historia_teatro.jpg"></asp:ImageButton></TD></TR></TBODY></TABLE>
</contenttemplate>
 <Triggers>
    <asp:PostBackTrigger ControlID="dlProducciones" />
    <asp:PostBackTrigger ControlID="btnAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaImagenes" />
    <asp:PostBackTrigger ControlID="btnSiguiente" />
    <asp:PostBackTrigger ControlID="btnvAnterior" />
    <asp:PostBackTrigger ControlID="dlGaleriaVideo" />
    <asp:PostBackTrigger ControlID="btnvSiguiente" />
    
    <asp:PostBackTrigger ControlID="lnkOk" />
    <asp:PostBackTrigger ControlID="lnkCerrarVideo" />
    <asp:PostBackTrigger  ControlID="ImageButton2" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

