<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAgregarLista.ascx.cs"
    Inherits="Comun_Controles_ucAgregarLista" %>
<style type="text/css">
    .style1
    {
        width: 38px;
    }
</style>
<fieldset>
    <legend style="font-weight: bold">Agregar Detalles a Lista.</legend>
    <table width="300px">
        <tr>
        <td colspan="3">
            <asp:Label ID="Label1" runat="server" Text="Buscar:"></asp:Label>
            <asp:Label ID="Label2" runat="server" Text="(Presionar enter)" 
                    Font-Italic="True" Font-Size="Smaller"></asp:Label>
        </td>
        </tr>        
        <tr>            
            <td rowspan="2" class="style1">                
                <asp:TextBox ID="txtNombre" runat="server" AutoPostBack="True" OnTextChanged="txtNombre_TextChanged"
                    Width="225px"></asp:TextBox>
                <asp:ListBox ID="ltbItemsCodArgu" runat="server" Rows="20" SelectionMode="Multiple"
                    Width="230px" onprerender="ltbItemsCodArgu_PreRender"></asp:ListBox>
                <asp:HiddenField ID="hfCodTabla" runat="server" OnValueChanged="hfCodTabla_ValueChanged" />
                <asp:HiddenField ID="hfCodItem" runat="server" 
                    OnValueChanged="hfCodTabla_ValueChanged" />
            </td>
            <td>
                <asp:Button ID="btnAdd" runat="server" OnClick="btnAdd_Click" Text="&gt;&gt;" />
            </td>
            <td rowspan="2" class="style1" style="padding-top:25px">                                          
                <asp:ListBox ID="ltbItemsSelect" runat="server" Rows="20" Width="230px" 
                    onprerender="ltbItemsSelect_PreRender"></asp:ListBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnQuitar" runat="server" OnClick="btnQuitar_Click" Text="&lt;&lt;" />
            </td>
        </tr>
    </table>
</fieldset>
