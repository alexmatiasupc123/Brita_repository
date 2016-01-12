<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Mantenimientos_frm_agendaCultural, App_Web_sw6d-sie" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" validaterequest="false" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="AGENDA CULTURAL"></asp:Label><br />
<BR />
<asp:Panel id="pNuevo" runat="server" Height="700px"  SkinID="paneles" Visible="True">
    <asp:HiddenField ID="hidCodigo" runat="server" />
    <asp:Label ID="lblNombreSeccion" runat="server" Text="Agenda Cultural" Width="400px"></asp:Label><br />
    <br />
    <TABLE style="WIDTH: 379px"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 18px" align=right>
    <asp:Label id="lblECodigo" runat="server" Text="Código:" SkinID="camposNombre" Visible="False"></asp:Label> </TD>
    <TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2>
    <asp:Label id="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></TD></TR>
    <TR><TD style="WIDTH: 100px; HEIGHT: 18px" vAlign=top align=right>
    <asp:Label id="Label6" runat="server" Text="Fecha:" SkinID="camposNombre"></asp:Label></TD>
    <TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2>
    <asp:TextBox id="txtFecha" runat="server" Width="116px" ValidationGroup="Guardar"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha"
            ErrorMessage="*Ingrese Fecha" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtFecha"></ajaxToolkit:CalendarExtender></TD></TR>
        <TR><TD style="WIDTH: 100px" vAlign=top align=right><asp:Label id="Label2" runat="server" Text="Contenido:" SkinID="camposNombre"></asp:Label></TD>
        <TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>
        <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
            DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
            Width="500px">
        </FTB:FreeTextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server"  SkinID="rfvError" ValidationGroup="Guardar" ControlToValidate="txtContenido" ErrorMessage="*Ingrese Contenido"></asp:RequiredFieldValidator></TD></TR>
        <TR><TD style="WIDTH: 100px; HEIGHT: 24px" align=right valign="top"><asp:Label id="Label5" runat="server" Text="Imagen:" SkinID="camposNombre"></asp:Label></TD>
        <TD style="WIDTH: 480px; HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2><asp:FileUpload id="fuImagen" runat="server" Width="500px"></asp:FileUpload><br />
    <asp:Label ID="Label11" runat="server" Text="*Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb"></asp:Label></TD></TR>
    <TR><TD style="WIDTH: 100px" align=right>&nbsp;</TD>
    <TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>&nbsp; <asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></TD></TR>
    <TR><TD style="WIDTH: 100px" align=right></TD>
    <TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>
     <asp:ImageButton id="btnGuardar" onclick="btnGuardar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> 
     <asp:ImageButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" SkinID="Cancelar"></asp:ImageButton></TD></TR></TBODY></TABLE>
     </asp:Panel><BR />
    
</asp:Content>

