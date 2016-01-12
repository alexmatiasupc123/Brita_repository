<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAuditoria.ascx.cs" Inherits="Comun_Controles_ucAuditoria" %>
<fieldset style="width: 870px">
    <legend>Datos de auditoría</legend>
    <table width="850px">
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Usuario de creación"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Fecha de creación"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Usuario de edición"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label10" runat="server" Text="Fecha de edición"></asp:Label>
            </td>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Maquina PC" Visible="false"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="TextBoxSSIUsuario_Creacion" runat="server" Text=" " Enabled="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxSSIFechaHora_Creacion" runat="server" Text=" " Enabled="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxSSIUsuario_Modificacion" runat="server" Text=" " Enabled="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxSSIFechaHora_Modificacion" runat="server" Text=" " Enabled="False"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxSSIHost" runat="server" Text=" " Enabled="False" Visible="false"></asp:Label>
            </td>
        </tr>
    </table>
</fieldset>
