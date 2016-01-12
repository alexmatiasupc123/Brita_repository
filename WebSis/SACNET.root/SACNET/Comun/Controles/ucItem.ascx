<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucItem.ascx.cs" Inherits="Comun_Controles_ucItem" %>
<fieldset>
    <legend >Datos del ítem</legend>
    <table>
        <tr>
            <td>
                <asp:Label ID="Label24" runat="server" Text="Código :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="TextBoxCodigoItem" runat="server" Width="140px" 
                    ForeColor="#000066"></asp:Label>
            </td>
            <td>
                &nbsp;<asp:Label ID="Label2" runat="server" Text="Titulo :"></asp:Label>
            &nbsp;</td>
            <td>
                <asp:Label ID="TextBoxTitulo" runat="server" Width="300px" 
                    ForeColor="#000066"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Actores :"></asp:Label>
            </td>
            <td>
                <asp:ListBox ID="ListBoxActores" runat="server" Width="244px" Height="57px" 
                    ForeColor="#000066"></asp:ListBox>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Préstamo en :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelTipoPrestamo" runat="server" Font-Bold="False" 
                    ForeColor="#000066"></asp:Label>
                <asp:Label ID="LabelTipoPrestamoCOD" runat="server" Visible="False"></asp:Label>    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Autores :"></asp:Label>
            </td>
            <td>
                <asp:ListBox ID="ListBoxAutores" runat="server" Width="246px" Height="57px" 
                    ForeColor="#000066"></asp:ListBox>
            </td>
            <td>
                <asp:Label ID="Label25" runat="server" Text="Estado de ejemplar :"></asp:Label>
            </td>
            <td>
                <asp:Label ID="LabelEstadoEjemplar" runat="server" Font-Bold="False" 
                    ForeColor="#000066"></asp:Label>
                <asp:Label ID="LabelEstadoEjemplarCOD" runat="server" Visible="False"></asp:Label>    
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label26" runat="server" Text="Formato Adicional :"></asp:Label>
            </td>
            <td colspan="3">
                                    <asp:TextBox ID="txtNotas" runat="server" Height="60px" 
                    Columns="4" TextMode="MultiLine"
                                        Width="620px" onKeyUp="Count(this,1000)"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                &nbsp;</td>
        </tr>
    </table>
</fieldset>
