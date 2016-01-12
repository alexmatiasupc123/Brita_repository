<%@ Page Title="Registrar Verificación Transferencia." Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true" CodeFile="PopupVerificarRetiroTransferencia.aspx.cs" Inherits="PopupVerificarRetiroTransferencia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" Runat="Server">
Registrar Verificación Transferencia.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div>
    <fieldset>
            <legend style="font-weight: bold">Registrar Verificación Transferencia</legend>
            <table width="700px">
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Fecha de Proceso Retiro :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitulo0" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="SACS para Ingreso :"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList3" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Fecha de Proceso Ingreso :"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitulo1" runat="server"></asp:TextBox>
                    </td>
                    <td>
                        <asp:Label ID="Label5" runat="server" Text="Estado Solicitud:"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList2" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        &nbsp;</td>
                    <td colspan="2" style="text-align: center">
                        <asp:Button ID="Button1" runat="server" Text="Grabar" />
                        <asp:Button ID="Button2" runat="server" Text="Cancelar" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                </table>
        </fieldset>
    </div>
</asp:Content>

