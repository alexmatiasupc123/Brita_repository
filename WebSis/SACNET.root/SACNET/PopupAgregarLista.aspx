<%@ Page Title="Agregar Datos." Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true"
    CodeFile="PopupAgregarLista.aspx.cs" Inherits="PopupAgregarLista" %>
<%@ OutputCache Location="None" VaryByParam="None" %>
<%@ Register Src="Comun/Controles/ucAgregarLista.ascx" TagName="ucAgregarLista" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
Agregar Datos.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table>
        <tr>
            <td>
            <uc1:ucAgregarLista ID="ucAgregarLista1" runat="server" />
            </td>
        </tr>
        <tr>
            <td align="right">
            <asp:ImageButton ID="ibtnAceptar" runat="server" 
                    ImageUrl="~/Comun/Imagenes/Botones/btnAceptar.gif" 
                    onclick="ibtnAceptar_Click" />
            </td>
        </tr>
    </table>
    
    
</asp:Content>
