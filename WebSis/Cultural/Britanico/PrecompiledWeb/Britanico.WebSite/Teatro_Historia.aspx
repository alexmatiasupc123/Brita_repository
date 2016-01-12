<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Teatro_Historia, App_Web_yfflyer_" title="CENTRO CULTURAL BRIT�NICO - Historia del Teatro" %>
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
                El Teatro Brit�nico,
            antes el cine Exc�lsior (1921), fue adquirido por la Asociaci�n
                Cultural Peruano
            Brit�nica en 1979, cuando llevaba el nombre de "Corral de Comedias". En aquella
            �poca se pudieron iniciar los trabajos de remodelaci�n, gracias al apoyo de algunas
            empresas y al entusiasmo de los miembros del grupo de teatro The Good Companions.
        Este �ltimo se cre� en 1949, con la
            idea de difundir el teatro
            brit�nico en Lima y de reunir a los interesados no s�lo en la actuaci�n, sino en
            los aspectos que la actividad teatral conlleva.
                <br />
                <br />
                Reci�n en mayo de 1982
            se inaugur� como Teatro Brit�nico con la obra �HMS. Pinafore�. Luego, a partir de
            1983, el Teatro
            comenz� a ser utilizado por distintas compa��as profesionales independientes. Desde
            esa �poca, la actividad art�stica del Teatro Brit�nico no ha cesado, presentando
            no s�lo obras de autores brit�nicos, sino obras de escritores de diversas nacionalidades. La Asociaci�n
            siempre ha mostrado un gran inter�s en fomentar el teatro
            en el Per�. Lo que se confirma con el apoyo a diversas productoras que utilizan
            nuestras instalaciones para presentar grandes montajes teatrales.
                <br />
                <br />
                Desde este momento la
            actividad en el Teatro Brit�nico es incesante no s�lo con funciones teatrales en
            horarios estelares, sino tambi�n con funciones de trasnoche, concursos, festivales
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

