<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Boletin.aspx.cs" Inherits="Boletin" Title="CENTRO CULTURAL BRIT�NICO - BOLETIN" StylesheetTheme="SkinBritanico"%>
<asp:Content ID="Content1" ContentPlaceHolderID="Contentplaceholder2" Runat="Server">
    <asp:Label ID="lblMsg" runat="server" SkinID="tError"></asp:Label><br />
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="variable.aspx?tipoCriterio=5"
        SkinID="Links">Descargar Boletin</asp:HyperLink>
</asp:Content>

