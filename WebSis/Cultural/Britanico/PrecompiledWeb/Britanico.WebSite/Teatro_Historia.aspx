<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Teatro_Historia, App_Web_yfflyer_" title="CENTRO CULTURAL BRITÁNICO - Historia del Teatro" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
<asp:UpdatePanel id="UpdatePanel2" runat="server">
        <contenttemplate>
    <table border="0" cellpadding="0" cellspacing="0" style="width: 410px">
        <tr>
            <td style="width: 400px; height: 12px">
                <asp:Label ID="lblTituloSede" runat="server" CssClass="titulo" Text="Historia" Width="100%"></asp:Label><br />
                <br />
                <hr style="width: 100%" />
                <br />
            </td>
        </tr>
        <tr>
            <td style="width: 400px; height: 12px">
            <asp:Image id="imgFoto" runat="server" Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left"></asp:Image>
             <asp:Label id="lblContenido" runat="server">
                El Teatro Británico,
            antes el cine Excélsior (1921), fue adquirido por la Asociación
                Cultural Peruano
            Británica en 1979, cuando llevaba el nombre de "Corral de Comedias". En aquella
            época se pudieron iniciar los trabajos de remodelación, gracias al apoyo de algunas
            empresas y al entusiasmo de los miembros del grupo de teatro The Good Companions.
        Este último se creó en 1949, con la
            idea de difundir el teatro
            británico en Lima y de reunir a los interesados no sólo en la actuación, sino en
            los aspectos que la actividad teatral conlleva.
                <br />
                <br />
                Recién en mayo de 1982
            se inauguró como Teatro Británico con la obra “HMS. Pinafore”. Luego, a partir de
            1983, el Teatro
            comenzó a ser utilizado por distintas compañías profesionales independientes. Desde
            esa época, la actividad artística del Teatro Británico no ha cesado, presentando
            no sólo obras de autores británicos, sino obras de escritores de diversas nacionalidades. La Asociación
            siempre ha mostrado un gran interés en fomentar el teatro
            en el Perú. Lo que se confirma con el apoyo a diversas productoras que utilizan
            nuestras instalaciones para presentar grandes montajes teatrales.
                <br />
                <br />
                Desde este momento la
            actividad en el Teatro Británico es incesante no sólo con funciones teatrales en
            horarios estelares, sino también con funciones de trasnoche, concursos, festivales
            y recitales de piano de gran nivel. En el 2007 nos consolidamos como casa productora,
            motivo por el cual nuestro compromiso es seguir mejorando y hacer de este tradicional
            espacio una alternativa diaria.
            </asp:Label>
            
            </td>
        </tr>
        
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
                 
        <tr>
            <td style="width: 100px; height: 12px">
                <br />
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_themes/Imagenes/producciones_propias.jpg"
                    PostBackUrl="~/Producciones_Teatrales.aspx" /></td>
        </tr>
    </table>
    </contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

