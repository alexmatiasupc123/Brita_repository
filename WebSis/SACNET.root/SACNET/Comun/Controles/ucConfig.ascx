<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucConfig.ascx.cs" Inherits="Comun_Controles_ucConfig" %>
<asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
    <HeaderTemplate>
        <table>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td>
                <asp:HiddenField ID="hfCodConfig" runat="server" Value='<%# Eval("CodConfig") %>' />
                <asp:HiddenField ID="hfCodTabla" runat="server" Value='<%# Eval("CodTabla") %>' />
                <asp:HiddenField ID="hfCodArgu" runat="server" Value='<%# Eval("Valor") %>' />
                <asp:HiddenField ID="hfTipoValor" runat="server" Value='<%# Eval("TipoValor") %>' />
            </td>
            <td>
                <asp:Label runat="server" ID="lblNombre" Text='<%# Eval("Nombre") %>' ToolTip='<%# Eval("Descripcion") %>' />
            </td>
            <td>
                <asp:DropDownList ID="ddlCodArgu" runat="server" Width="250px">
                </asp:DropDownList>
                <asp:TextBox ID="txtCodArgu" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td>
                <asp:Label runat="server" ID="lblAuditoria" Text="Modificado por: " />
            </td>
            <td>
                <asp:Label runat="server" ID="lblSSIUsuario" Text='<%# Eval("SSIUsuario_Modificacion") %>' />
            </td>
            <td>
                <asp:Label runat="server" ID="lblSSIFecha" Text='<%# Eval("SSIFechaHora_Modificacion") %>'  />
            </td>
        </tr>
    </ItemTemplate>
    <FooterTemplate>
        </table>
    </FooterTemplate>
</asp:Repeater>
