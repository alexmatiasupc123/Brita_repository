<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_sede.aspx.cs" Inherits="Mantenimientos_frm_sede" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="SEDES BRIT�NICO"></asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:ImageButton id="btnNuevo" onclick="btnNuevo_Click" runat="server" SkinID="Agregar"></asp:ImageButton>&nbsp;<asp:Panel id="pNuevo" runat="server" Height="180px" SkinID="paneles" Visible="False"><asp:Label id="lblNombreSeccion" runat="server" Text="Agregar Sede" Width="400px" __designer:dtid="10414574138294278" __designer:wfdid="w28"></asp:Label><BR /><BR /><TABLE style="WIDTH: 503px"><TBODY><TR><TD style="WIDTH: 70px; HEIGHT: 18px" vAlign=top align=right><asp:Label id="lblECodigo" runat="server" Text="C�digo:" SkinID="camposNombre" Visible="False" __designer:wfdid="w29"></asp:Label> </TD><TD style="WIDTH: 480px; HEIGHT: 18px" vAlign=top colSpan=2><asp:Label id="lblCodigo" runat="server" SkinID="camposNombre" Visible="False" __designer:wfdid="w30"></asp:Label></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 18px" vAlign=top align=right><asp:Label id="Label3" runat="server" Text="Nombre:" SkinID="camposNombre" __designer:wfdid="w31"></asp:Label> </TD><TD style="WIDTH: 480px; HEIGHT: 18px" vAlign=top colSpan=2><asp:TextBox id="txtNombre" runat="server" Width="250px" ValidationGroup="Guardar" __designer:wfdid="w32"></asp:TextBox><asp:RequiredFieldValidator id="rfvNombre" runat="server" ForeColor SkinID="rfvError" ValidationGroup="Guardar" ErrorMessage="*Ingrese Nombre de sede" ControlToValidate="txtNombre" __designer:wfdid="w33"></asp:RequiredFieldValidator>&nbsp; </TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 18px" vAlign=top align=right><asp:Label id="Label4" runat="server" Text="Direcci�n:" SkinID="camposNombre" __designer:wfdid="w34"></asp:Label></TD><TD style="WIDTH: 480px; HEIGHT: 18px" vAlign=top colSpan=2><asp:TextBox id="txtDireccion" runat="server" Width="250px" ValidationGroup="Guardar" __designer:wfdid="w35"></asp:TextBox><asp:RequiredFieldValidator id="rfvDireccion" runat="server" ForeColor SkinID="rfvError" ValidationGroup="Guardar" ErrorMessage="*Ingrese Direcci�n de sede" ControlToValidate="txtDireccion" __designer:wfdid="w36"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 70px; HEIGHT: 18px" align=right></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2>&nbsp; </TD></TR><TR><TD style="WIDTH: 70px"></TD><TD style="WIDTH: 480px; HEIGHT: 18px" colSpan=2><asp:ImageButton id="btnAgregar" onclick="btnAgregar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar" __designer:wfdid="w37"></asp:ImageButton> <asp:ImageButton id="btnGuardar" onclick="btnGuardar_Click" runat="server" SkinID="Guardar" ValidationGroup="Guardar" __designer:wfdid="w38"></asp:ImageButton> <asp:ImageButton id="btnCancelar" onclick="btnCancelar_Click" runat="server" SkinID="Cancelar" __designer:wfdid="w39"></asp:ImageButton></TD></TR></TBODY></TABLE></asp:Panel><BR /><asp:GridView id="gvSede" runat="server" Width="573px" SkinID="CGrilla" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="sede_codi" DataSourceID="odsSede" OnSelectedIndexChanged="gvSede_SelectedIndexChanged" PageSize="10"><Columns>
<asp:TemplateField ShowHeader="False"><ItemTemplate>
<asp:ImageButton id="btnEditar" runat="server" Text="Select" SkinID="Editar" CommandName="Select" CausesValidation="False" __designer:wfdid="w24"></asp:ImageButton> <asp:ImageButton id="btnEliminar" onclick="btnEliminar_Click" runat="server" SkinID="Eliminar" __designer:wfdid="w25" CommandArgument='<%# Eval("sede_codi") %>'></asp:ImageButton> <ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender1" runat="server" __designer:wfdid="w26" ConfirmText="�Seguro que desea eliminar la sede?" TargetControlID="btnEliminar"></ajaxToolkit:ConfirmButtonExtender> 
</ItemTemplate>

<ItemStyle Width="80px"></ItemStyle>
</asp:TemplateField>
<asp:BoundField DataField="sede_nomb" HeaderText="Sede" SortExpression="sede_nomb"></asp:BoundField>
<asp:BoundField DataField="sede_dire" HeaderText="Direcci&#243;n" SortExpression="sede_dire"></asp:BoundField>
</Columns>
</asp:GridView> <asp:ObjectDataSource id="odsSede" runat="server" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLSedeNTAD"></asp:ObjectDataSource> 
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

