<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_cabecera, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="CABECERAS"></asp:Label><br />
<BR />
<asp:Panel id="pNuevo" runat="server" Height="700px"  SkinID="paneles" Visible="True">
    <asp:HiddenField ID="hidCodigo" runat="server" />
    
    <br />
    <TABLE style="WIDTH: 379px"><TBODY>
    
    <TR><TD style="WIDTH: 100px; HEIGHT: 24px" align=right valign="top">
    <asp:Label id="Label2" runat="server" Text="Pagina:" SkinID="camposNombre"></asp:Label></TD>
    <TD style="WIDTH: 480px; HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2>
    
    <asp:DropDownList ID="ddlTitulo" runat="server"  AutoPostBack="true" OnSelectedIndexChanged="ddlTitulo_SelectedIndexChanged">
    <asp:ListItem>Noticias</asp:ListItem>
    <asp:ListItem>Galería de Arte</asp:ListItem>
    <asp:ListItem>Cursos y Talleres</asp:ListItem>
    <asp:ListItem>Producciones del Centro Cultural</asp:ListItem>
    <asp:ListItem>Agenda Cultural</asp:ListItem>
    <asp:ListItem>Teatro Británico</asp:ListItem>
    <asp:ListItem>Historia del Teatro</asp:ListItem>
    <asp:ListItem>Producciones Teatrales</asp:ListItem>
    <asp:ListItem>Auditorios</asp:ListItem>
    <asp:ListItem>Boletin</asp:ListItem>
    <asp:ListItem>Británico en la Radio</asp:ListItem>
    <asp:ListItem>Concursos</asp:ListItem>
    <asp:ListItem>Contáctenos</asp:ListItem>
    <asp:ListItem>Proyectos</asp:ListItem>
    <asp:ListItem>Publicaciones</asp:ListItem>
    <asp:ListItem>Quiénes somos</asp:ListItem>
    </asp:DropDownList>
    </TD></TR>
    
    <TR><TD style="WIDTH: 100px; HEIGHT: 24px" align=right valign="top">
    <asp:Label id="Label5" runat="server" Text="Imagen:" SkinID="camposNombre"></asp:Label></TD>
    <TD style="WIDTH: 480px; HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2>
    <asp:FileUpload id="fuImagen" runat="server" Width="500px"></asp:FileUpload><br />
    <asp:Label ID="Label11" runat="server" Text="*Ingrese Imagenes de 553 x 184 pixeles, peso máximo permitido 200kb"></asp:Label></TD></TR>
    <tr><TD colspan="3" align="left">
    <br/>
    <asp:Image ID="imgCabe" runat="server" />
    </TD></tr>
    <TR><TD style="WIDTH: 100px" align=right>&nbsp;</TD>
    <TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>&nbsp; <asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></TD></TR>
    <TR><TD style="WIDTH: 100px" align=right></TD>
    <TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>
     <asp:ImageButton id="btnGuardar" onclick="btnGuardar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> 
     <asp:ImageButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" SkinID="Cancelar"></asp:ImageButton></TD></TR></TBODY></TABLE>
     </asp:Panel><BR />
    
</asp:Content>

