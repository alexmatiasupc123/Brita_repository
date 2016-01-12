<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" EnableEventValidation="false"  CodeFile="Galeria_Arte.aspx.cs" Inherits="Galeria_Arte" Title="CENTRO CULTURAL BRITÁNICO - Galería de Arte" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
<script type="text/jscript" language="javascript">
function fcGaleria1()
{

    var url = "http://www.centrocultural.britanico.edu.pe/recorridos_virtuales/MundoHombre/index.html";
    window.open(url);
    return false;
}
function fcGaleria2()
{
    var url = "http://centrocultural.britanico.edu.pe/recorridos_virtuales/YoNoSoloCoso/index.html";
    window.open(url);
    return false;
}
function fcGaleria3()
{
    var url = "http://centrocultural.britanico.edu.pe/recorridos_virtuales/100ADC/index.html";
    window.open(url);
    return false;
}
function fcGaleria4()
{
    var url = "http://centrocultural.britanico.edu.pe/recorridos_virtuales/MundoImaginado/index.html";
    window.open(url);
    return false;
}
function fcGaleria5()
{
    var url = "http://centrocultural.britanico.edu.pe/recorridos_virtuales/Gestofuertegestosuave/index.html";
    window.open(url);
    return false;
}
//TOUR 360 - MODIFICAR CUANDO LLEGUE EL CD Y CAMBIAR A "INDEX"
function fcGaleria6()
{
    var url = "http://centrocultural.britanico.edu.pe/recorridos_virtuales/Tour_cartografico/imgZoom.html?img=01.jpg";
    window.open(url);
    return false;
}

</script>

    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 100%; TEXT-ALIGN: right">
<asp:DataList id="dlGaleria" runat="server" Width="100%" DataKeyField="gale_codi" CaptionAlign="Right" OnSelectedIndexChanged="dlGaleria_SelectedIndexChanged">
<ItemTemplate>
<asp:LinkButton id="lnkGaleria" runat="server" Width="100%" CssClass="linkDetalle" Text='<%# Eval("gale_nomb") %>' CommandName="Select" CommandArgument='<%# Eval("gale_codi") %>'></asp:LinkButton> 
</ItemTemplate>
</asp:DataList> </TD></TR>
<TR><TD style="WIDTH: 100%; HEIGHT: 68px">
<asp:Label id="lblTituloGaleria" runat="server" Width="100%" CssClass="titulo"></asp:Label><BR />
<asp:Label ID="lblIdGaleria" runat="server" Visible="false"></asp:Label>
<HR />
</TD></TR>



<%  

    if (lblIdGaleria.Text.Equals("10"))
        
   {
       %>
       <table>
       <tr>
        <td>
            <asp:Label ID="lblText" runat="server" Width="100%" CssClass="subtitulomayus"></asp:Label>
            <br /><br />
        </td>
       </tr>
       <tr>
        <td>
        <img id="idbutton"  onclick="javascript:return fcGaleria1();" alt="" src="App_themes/Imagenes/mundo_hombre.jpg" style="cursor:pointer" />             
        </td>
       </tr>
       <tr>
        <td>
        <img id="idbutton2" onclick="javascript:return fcGaleria2();" alt="" src="App_themes/Imagenes/yo_no_coso2.jpg" style="cursor:pointer" />
        </td>
       </tr>
       <tr>
        <td>
        <img id="idbutton3" onclick="javascript:return fcGaleria3();" alt="" src="App_themes/Imagenes/100ADC.jpg" style="cursor:pointer" />
        </td>
       </tr>
       <tr>
        <td>
            <img id="idbutton4" onclick="javascript:return fcGaleria4();" alt="" src="App_themes/Imagenes/mundo_imaginado.jpg" style="cursor:pointer" />
        </td>
       </tr>
       <tr>
        <td>
            <img id="idbutton5" onclick="javascript:return fcGaleria5();" alt="" src="App_themes/Imagenes/GestoFuerteGestoSuave.jpg" style="cursor:pointer" />
        </td>
       </tr>
       <tr>
       
       <!--TOUR 360-->
        <td>
            <img id="idbutton6" onclick="javascript:return fcGaleria6();" alt="" src="App_themes/Imagenes/Tour_cartografico.jpg" style="cursor:pointer" />
        </td>
       </tr>
       </table>
       
       <table>
        <tr>
            <td>
                &nbsp<br />&nbsp<br />&nbsp<br />&nbsp<br />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp<br />&nbsp<br />&nbsp<br />&nbsp<br />
            </td>
        </tr>
       </table>
       
   <% }
   else
   {
        %>

<TR><TD style="WIDTH: 100%;" align=right>
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
<TABLE style="WIDTH: 410px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="HEIGHT: 13px" vAlign=top align=left colSpan=2><asp:Image id="imgFoto" runat="server" ImageUrl='<%# Eval("gade_imag") %>' Width="64px" Height="64px" CssClass="imagen" ImageAlign="Left"></asp:Image> <asp:Panel id="pDetalle" runat="server"><TABLE style="WIDTH: 100%" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 95%; HEIGHT: 29px" vAlign=top><asp:Label id="lblTituloDetalleGaleria" runat="server" CssClass="TituloDetalle" Text='<%# Eval("gade_nomb") %>'></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><asp:Label id="lblContenido" runat="server" CssClass="cuadroTextoContenido" Text='<%# Eval("gade_desc") %>'></asp:Label><BR /></TD></TR><TR><TD style="WIDTH: 95%; HEIGHT: 29px"><BR /><asp:Label id="lblDetalle" runat="server" CssClass="cuadroTextoRojo" Text='<%# Eval("gade_temp") %>'></asp:Label></TD></TR></TBODY></TABLE></asp:Panel> &nbsp;&nbsp;</TD></TR>
<TR><TD align=right colSpan=2 rowSpan=2>
<asp:LinkButton id="LinkButton1" runat="server" CssClass="linkDetalle" CommandName="Select" Font-Bold="False">+ DETALLE</asp:LinkButton></TD></TR>
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
    <asp:ImageButton  id="btnMuestras" onclick="btnMuestras_Click" runat="server" ImageUrl="~/App_themes/Imagenes/muestra_galeria.jpg"></asp:ImageButton></TD></TR>
<TR><TD><BR /><BR /><asp:DataList id="dlProximosEventos" runat="server" DataKeyField="info_codi" RepeatLayout="Flow"><HeaderTemplate>
<asp:Label id="Label5" runat="server" CssClass="TituloDetalle" Text="Próximamente"></asp:Label>
</HeaderTemplate>
<ItemTemplate>
<asp:Label id="Label3" runat="server" CssClass="linkDetalle" Text='<%# Eval("info_titu") %>'></asp:Label><BR /><asp:Label id="even_tempLabel" runat="server" Text='<%# Eval("info_desc") %>'></asp:Label><BR /><BR />
</ItemTemplate>
</asp:DataList>&nbsp; </TD></TR><TR><TD style="WIDTH: 100px"></TD></TR></TBODY>

</TABLE><BR />
<%} %>
</contenttemplate>
    <Triggers>
    <asp:PostBackTrigger ControlID="dlGaleria" />
    <asp:AsyncPostBackTrigger ControlID="btnHistoria" />
    <asp:PostBackTrigger ControlID="btnMuestras" />
    </Triggers>
    </asp:UpdatePanel>
</asp:Content>

