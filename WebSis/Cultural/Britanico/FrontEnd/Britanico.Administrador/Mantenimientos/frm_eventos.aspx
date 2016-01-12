<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="frm_eventos.aspx.cs" Inherits="Mantenimientos_frm_eventos" Title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" styleSheetTheme="SkinBritanico" ValidateRequest="false" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit"%>

<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="EVENTOS BRITANICO"></asp:Label><br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
&nbsp;&nbsp;&nbsp;<BR /><asp:GridView id="gvEventos" runat="server" Width="807px" SkinID="CGrilla" AutoGenerateColumns="False" AllowPaging="True" OnSelectedIndexChanged="gvEventos_SelectedIndexChanged" DataKeyNames="even_codi" DataSourceID="odsEventos" PageSize="10">
<PagerSettings PageButtonCount="5"></PagerSettings>
<Columns>
<asp:BoundField DataField="even_codi" HeaderText="Item"></asp:BoundField>
<asp:BoundField DataField="even_nomb" HeaderText="Nombre" SortExpression="even_nomb"></asp:BoundField>
<asp:TemplateField HeaderText="F. Inicio" SortExpression="even_fini"><ItemTemplate>
<asp:Label id="Label1" runat="server" Text='<%# Eval("even_fini").ToString().Substring(0,10) %>' __designer:wfdid="w20"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="F. Fin" SortExpression="even_ffin"><ItemTemplate>
<asp:Label runat="server" Text='<%# Eval("even_ffin").ToString().Substring(0,10) %>' id="Label2"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Contenido" SortExpression="even_desc"><ItemTemplate>
<asp:Label runat="server" Text='<%# Eval("even_desc").ToString().Substring(0,100) %>' id="Label3"></asp:Label>
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Destacado"><ItemTemplate>
<asp:CheckBox id="cbDestacar" runat="server" Enabled="False" __designer:wfdid="w100" Checked='<%# Bind("even_dest") %>'></asp:CheckBox> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="Destacar" ShowHeader="False"><ItemTemplate>
<asp:LinkButton id="lnkDestacar" onclick="lnkDestacar_Click" runat="server" SkinID="lnkPrincipal" __designer:wfdid="w101" CommandArgument='<%# Eval("even_codi") %>'>Destacar</asp:LinkButton> 
</ItemTemplate>
</asp:TemplateField>
<asp:TemplateField HeaderText="No Destacar"><ItemTemplate>
<asp:LinkButton id="lnkNoDestacar" runat="server" SkinID="lnkPrincipal" __designer:wfdid="w102" CommandArgument='<%# Eval("even_codi") %>' OnClick="lnkNoDestacar_Click">No Destacar</asp:LinkButton>
</ItemTemplate>
</asp:TemplateField>
</Columns>

<PagerStyle Font-Bold="True" Font-Names="Arial" Font-Size="12px"></PagerStyle>
</asp:GridView><asp:ObjectDataSource id="odsEventos" runat="server" __designer:wfdid="w19" SelectMethod="ListarTodos" TypeName="Britanico.BusinessLogic.NoTransaccionales.BLEventoNTAD"></asp:ObjectDataSource>  
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>

