<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Auditorios, App_Web_xruf4ash" title="CENTRO CULTURAL BRITÁNICO - Teatro Británico" stylesheettheme="SkinBritanico" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <table border="0" cellpadding="0" cellspacing="0" style="width: 410px">
        <tr>
            <td style="width: 100%; height: 16px; text-align: left;">
                <asp:Label ID="lblTituloSede" runat="server" CssClass="titulo" Text="Actividades en el Teatro Británico"
                    Width="100%"></asp:Label><br />
                <hr style="width: 100%" />
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 100%; height: 16px; text-align: right;">
                <asp:Label ID="lblDireccion" runat="server" CssClass="subtitulomayus" Text="JR. BELLAVISTA 527 - MIRAFLORES" Width="100%"></asp:Label><br /><br />
            </td>
        </tr>
        
        <tr>
        <td style="WIDTH: 410px;" colspan="3">
        <table>
        <tr>
        <td style="WIDTH: 215px;;">
         <%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_teatro_britanico); } %>
        </td>
        <td align=right style="WIDTH: 195px;">
        <!-- Recomendar Button Begin-->
        <%if (Convert.ToBoolean(Session["tiene_contenido"]) == true) { Response.Write(redes_sociales.btn_recomendar); }%>
        <!-- Recomendar Button End-->
        </td>
        </tr>
        </table>
        </td>
        </tr>
        
        
        <tr>
            <td style="width: 100%; height: 28px; text-align: right;">
            
                </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 16px; text-align: right;" align="left">
                <asp:DataList ID="dlActividad" runat="server" DataKeyField="teat_codi" OnSelectedIndexChanged="dlActividad_SelectedIndexChanged" Width="100%" OnItemDataBound="dlActividad_ItemDataBound">
                    <ItemTemplate>
                        <table border="0" cellpadding="0" cellspacing="0" width="410">
                            <tr>
                                <td align="left" colspan="2" style="height: 13px">
                                    <asp:Image ID="imgFoto" runat="server" CssClass="imagen" Height="64px" ImageAlign="Left"
                                        ImageUrl='<%# Eval("teat_imag") %>' Width="64px" />
                                    <asp:Panel ID="pDetalle" runat="server">
                                        <table border="0" cellpadding="0" cellspacing="0" style="width: 100%">
                                            <tr>
                                                <td style="width: 95%; height: 29px" valign="top">
                                                    <asp:Label ID="lblTituloTeatro" runat="server" Font-Bold="True" Font-Size="12px"
                                        Text='<%# Eval("teat_titu") %>'></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td style="width: 95%; height: 29px" valign="top">
                                    <asp:Label ID="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("teat_desc") %>'></asp:Label><br />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="width: 95%; height: 29px" valign="top">
                                                    <br />
                                                    <asp:Label ID="lblDetalle" runat="server" CssClass="cuadroTextoRojo" Text='<%# Eval("teat_temp") %>'></asp:Label></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                    &nbsp; &nbsp;<br />
                                    <br />
                                    <br />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 70px; height: 13px;">
                                </td>
                                <td style="width: 300px; height: 13px">
                                </td>
                            </tr>
                            <tr>
                                <td style="height: 13px;" colspan="2">
                                    <asp:LinkButton ID="lnkDetalle" runat="server" CommandArgument='<%# Eval("teat_codi") %>' CommandName="Select" CssClass="linkDetalle" Font-Underline="True" Width="59px">+ DETALLE</asp:LinkButton></td>
                            </tr>
                        </table>
                        <hr style="width: 100%" />
                        <br />
                    </ItemTemplate>
                </asp:DataList></td>
        </tr>
        
        <tr>
        <td style="WIDTH: 410px;" colspan="3">
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
        
        
        <tr>
            <td align="left" style="width: 100%; height: 16px; text-align: justify">
                <br />
                <asp:DataList ID="dlProximosEventos" runat="server" DataKeyField="info_codi"
                    RepeatLayout="Flow">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><br />
                        <asp:Label ID="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>'></asp:Label><br />
                        <br />
                    </ItemTemplate>
                    <HeaderTemplate>
                <asp:Label ID="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
                    </HeaderTemplate>
                </asp:DataList><br />
                <br />
              
                    
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 16px; text-align: right;" align="left">
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/App_themes/Imagenes/historia_teatro.jpg"
                    PostBackUrl="~/Teatro_Historia.aspx" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 5px; text-align: right">
            </td>
        </tr>
        <tr>
            <td style="width: 100%; height: 16px; text-align: right;" align="left">
    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/App_themes/Imagenes/producciones_propias.jpg"
        PostBackUrl="~/Producciones_Teatrales.aspx" /></td>
        </tr>
        <tr>
            <td align="left" style="width: 100%; height: 16px; text-align: right">
                <br />
                &nbsp;</td>
        </tr>
    </table>
    <br />
</asp:Content>

