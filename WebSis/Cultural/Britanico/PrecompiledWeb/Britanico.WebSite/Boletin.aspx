<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Boletin, App_Web_q4xvelen" title="CENTRO CULTURAL BRITÁNICO - BOLETIN" stylesheettheme="SkinBritanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" SkinID="tError"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="variable.aspx?tipoCriterio=5"
        SkinID="Links">Descargar Boletin</asp:HyperLink>
</asp:Content>

