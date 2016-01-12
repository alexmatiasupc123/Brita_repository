<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MenuSistema.ascx.cs" Inherits="Comun_Controles_MenuSistema" %>
<link href="../Styles/Panels.css" rel="stylesheet" type="text/css" />
<table cellpadding="0" cellspacing="0" class="menu">
    <tr>
        <td class="menu-centerright">
        </td>
        <td class="menu-center">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" DynamicHorizontalOffset="0"
                DynamicVerticalOffset="5" StaticSubMenuIndent="20px" CssClass="menu-center">
             <%--   <StaticSelectedStyle BackColor="#507CD1" />--%>
                <StaticMenuItemStyle Width="200px" />
                <StaticHoverStyle CssClass="menu-hover" />
                <DynamicHoverStyle CssClass="menu-hover" />
                <DynamicMenuStyle ForeColor="Black" BackColor="Black" />
              <%--  <DynamicSelectedStyle  />--%>
              <DynamicMenuItemStyle HorizontalPadding="4px" VerticalPadding="2px" Width="180PX"/>
              
                <Items>
                    <asp:MenuItem NavigateUrl="~/ListaOportunidad.aspx" Text="Oportunidad" 
                        Value="Oportunida"></asp:MenuItem>
                </Items>
                <Items>
                    <asp:MenuItem NavigateUrl="~/AdminUsuario.aspx" Text="Administrar Usuario" 
                        Value="AdmUsuario"></asp:MenuItem>
                </Items>
                <Items>
                    <asp:MenuItem NavigateUrl="~/AdminSocNegocio.aspx" Text="Administrar Socio de Negocio" 
                        Value="AdmUsuario"></asp:MenuItem>
                </Items>
                <Items>
                    <asp:MenuItem NavigateUrl="~/Login.aspx" Text="Login" 
                        Value="Login"></asp:MenuItem>
                </Items>
            </asp:Menu>
        </td>
        <td class="menu-centerleft">
        </td>
    </tr>
</table>
