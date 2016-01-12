<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_noticias.aspx.cs" Inherits="Mantenimientos_frm_noticias" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false"%>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="NOTICIAS BRITÁNICO"></asp:Label><br />
<BR />&nbsp; <asp:ImageButton id="btnNuevo" onclick="btnNuevo_Click" runat="server" SkinID="Agregar"></asp:ImageButton>&nbsp;<asp:Panel id="pNuevo" runat="server" Height="700px"  SkinID="paneles" Visible="False">
    <asp:Label ID="lblNombreSeccion" runat="server" Text="Agregar Noticia" Width="400px"></asp:Label><br />
    <br />
    <TABLE style="WIDTH: 379px"><TBODY><TR><TD style="WIDTH: 100px; HEIGHT: 18px" align=right><asp:Label id="lblECodigo" runat="server" Text="Código:" SkinID="camposNombre" Visible="False"></asp:Label> </TD><TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2><asp:Label id="lblCodigo" runat="server" SkinID="camposNombre" Visible="False"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 18px" vAlign=top align=right><asp:Label id="Label6" runat="server" Text="Fecha:" SkinID="camposNombre"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2><asp:TextBox id="txtFecha" runat="server" Width="116px" ValidationGroup="Guardar"></asp:TextBox> 
        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtFecha"
            ErrorMessage="*Ingrese Fecha" SkinID="rfvError" ValidationGroup="Guardar"></asp:RequiredFieldValidator>
        <ajaxToolkit:CalendarExtender id="CalendarExtender1" runat="server" TargetControlID="txtFecha"></ajaxToolkit:CalendarExtender></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 18px" vAlign=top align=right><asp:Label id="Label3" runat="server" Text="Título:" SkinID="camposNombre"></asp:Label> </TD><TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2><asp:TextBox id="txtTitulo" runat="server" Width="500px" ValidationGroup="Guardar"></asp:TextBox><BR /><asp:RequiredFieldValidator id="rfvNombre" runat="server" ForeColor SkinID="rfvError" ValidationGroup="Guardar" ControlToValidate="txtTitulo" ErrorMessage="*Ingrese Título"></asp:RequiredFieldValidator> </TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 26px" align=right><asp:Label id="Label4" runat="server" Text="SubTítulo:" SkinID="camposNombre"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 24px; text-align: left;" colSpan=2><asp:TextBox id="txtSubtitulo" runat="server" Width="500px" ValidationGroup="Guardar"></asp:TextBox> </TD></TR><TR><TD style="WIDTH: 100px" vAlign=top align=right><asp:Label id="Label2" runat="server" Text="Contenido:" SkinID="camposNombre"></asp:Label></TD><TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>
        <FTB:FreeTextBox ID="txtContenido" runat="server" AutoParseStyles="True" ButtonSet="Office2003"
            DownLevelCols="50" Height="300px" ToolbarLayout="FontFacesMenu, FontSizesMenu, FontForeColorPicker, &#13;&#10; FontForeColorPicker,Bold,Italic, Underline,JustifyLeft, JustifyRight, JustifyCenter, JustifyFull,bulletedlist,numberedlist| &#13;&#10; Cut, Copy, Paste, Delete, Undo, Redo, StyleMenu, SymbolsMenu, InsertDate, &#13;&#10; InsertTime, InsertImage, InsertTable, EditTable, InsertTableRowBefore, &#13;&#10; InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, &#13;&#10; DeleteTableColumn,Preview, SelectAll"
            Width="500px">
        </FTB:FreeTextBox>
        <asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ForeColor SkinID="rfvError" ValidationGroup="Guardar" ControlToValidate="txtContenido" ErrorMessage="*Ingrese Contenido"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 100px; HEIGHT: 24px" align=right valign="top"><asp:Label id="Label5" runat="server" Text="Imagen:" SkinID="camposNombre"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 24px; TEXT-ALIGN: left" colSpan=2><asp:FileUpload id="fuImagen" runat="server" Width="500px"></asp:FileUpload><br />
    <asp:Label ID="Label11" runat="server" Text="*Ingrese Imagenes de 64 x 64 pixeles, peso máximo permitido 200kb"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px" align=right>&nbsp;</TD><TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2>&nbsp; <asp:Label id="lblError" runat="server" SkinID="tError"></asp:Label></TD></TR><TR><TD style="WIDTH: 100px" align=right></TD><TD style="WIDTH: 480px; TEXT-ALIGN: left; height: 24px;" colSpan=2><asp:ImageButton id="btnAgregar" onclick="btnAgregar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> <asp:ImageButton id="btnGuardar" onclick="btnGuardar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar"></asp:ImageButton> <asp:ImageButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" SkinID="Cancelar"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel><BR /><asp:GridView id="gvNoticias" runat="server" SkinID="CGrilla" DataKeyNames="noti_codi" OnSelectedIndexChanged="gvNoticias_SelectedIndexChanged" AllowPaging="True" DataSourceID="odsNoticias" AutoGenerateColumns="False" PageSize="10" OnRowDataBound="gvNoticias_RowDataBound"><Columns>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:ImageButton id="btnEditar" runat="server" Text="Select" SkinID="Editar" CommandName="Select" CausesValidation="False"></asp:ImageButton> 
<asp:ImageButton id="btnEliminar" onclick="btnEliminar_Click" runat="server" SkinID="Eliminar" CommandArgument='<%# Eval("noti_codi") %>'></asp:ImageButton> <ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" ConfirmText="¿Seguro que desea eliminar la Noticia?" TargetControlID="btnEliminar"></ajaxToolkit:ConfirmButtonExtender> 
</ItemTemplate>
    <ItemStyle Width="80px" />
</asp:TemplateField>
<asp:BoundField DataField="noti_titu" HeaderText="T&#237;tulo" SortExpression="noti_titu"></asp:BoundField>
<asp:BoundField DataField="noti_subt" HeaderText="SubT&#237;tulo" SortExpression="noti_subt"></asp:BoundField>
    <asp:TemplateField HeaderText="Fecha" SortExpression="noti_fech">
        <ItemTemplate>
            <asp:Label ID="Label1" runat="server" Text='<%# Eval("noti_fech").ToString().Substring(0,10) %>'></asp:Label>
        </ItemTemplate>
    </asp:TemplateField>
        <asp:BoundField DataField="noti_desc" HeaderText="Contenido" />
</Columns>
</asp:GridView><asp:ObjectDataSource id="odsNoticias" runat="server" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLNoticiaNTAD" SelectMethod="ListarTodos"></asp:ObjectDataSource> <br />
</asp:Content>

