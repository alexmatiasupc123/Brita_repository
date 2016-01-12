<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Suscripcion_frm_suscripcion, App_Web__o5yl1am" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="Label1" runat="server" SkinID="lblTitulos" Text="LISTA DE SUSCRIPTORES DE ALTA"></asp:Label><br />
    <asp:Panel ID="Panel1" runat="server" Height="200px" SkinID="paneles"
        >
        <br />
        <asp:Label ID="Label4" runat="server" Text="Filtrar por:"></asp:Label><br />
        <br />
        <table style="width: 673px">
            <tr>
                <td style="width: 60px; text-align: right;" valign="top">
                    <asp:Label ID="Label2" runat="server" Text="Del:" SkinID="camposNombre"></asp:Label>
                </td>
                <td style="width: 100px" valign="top">
                    <asp:TextBox ID="txt_fechainicio" runat="server" ValidationGroup="buscar" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvInicio" runat="server" ControlToValidate="txt_fechainicio"
                        ErrorMessage="* Seleccione Fecha" SkinID="rfvError" ValidationGroup="buscar"
                        Width="154px"></asp:RequiredFieldValidator>
                    <ajaxToolkit:CalendarExtender ID="ceInicio" runat="server" TargetControlID="txt_fechainicio">
                    </ajaxToolkit:CalendarExtender>
                </td>
                <td style="width: 60px; text-align: right;" valign="top">
                    <asp:Label ID="Label3" runat="server" Text="Al:" SkinID="camposNombre"></asp:Label>&nbsp;
                </td>
                <td style="width: 100px" valign="top">
                    <asp:TextBox ID="txt_fechafin" runat="server" ValidationGroup="buscar" Width="150px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txt_fechafin"
                        ErrorMessage="* Seleccione Fecha" SkinID="rfvError" ValidationGroup="buscar"
                        Width="147px"></asp:RequiredFieldValidator><ajaxToolkit:CalendarExtender ID="ceFin" runat="server" TargetControlID="txt_fechafin">
                    </ajaxToolkit:CalendarExtender>
                </td>
                <td align="right" style="width: 100px" valign="top">
                    <asp:Label ID="Label5" runat="server" SkinID="camposNombre" Text="Estado:"></asp:Label></td>
                <td style="width: 100px" valign="top">
                    <asp:RadioButtonList ID="rblEstado" runat="server">
                        <asp:ListItem Selected="True" Value="1">Alta</asp:ListItem>
                        <asp:ListItem Value="0">Baja</asp:ListItem>
                    </asp:RadioButtonList></td>
                <td style="width: 100px" valign="top">
                    <asp:ImageButton ID="btnBuscar" runat="server" OnClick="btnBuscar_Click" SkinID="Buscar" ValidationGroup="buscar" /></td>
            </tr>
            <tr>
                <td style="height: 18px; text-align: left;" colspan="4">
                    <asp:CompareValidator ID="cvFechas" runat="server" ControlToCompare="txt_fechafin"
                        ControlToValidate="txt_fechainicio" ErrorMessage="seleccione rango de fecha valida"
                        Operator="LessThan" Type="Date" ValidationGroup="buscar" ForeColor="White" SkinID="cvError"></asp:CompareValidator>
                    <br />
                    </td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
            </tr>
            <tr>
                <td colspan="4" style="height: 18px; text-align: left">
                    <asp:ImageButton ID="btnImprimir" runat="server" SkinID="Imprimir" Visible="False" />
                    <asp:ImageButton ID="btnExportar" runat="server" SkinID="Reporte" Visible="False" AlternateText="Exportar Excel" /></td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
                <td colspan="1" style="height: 18px; text-align: left">
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:GridView ID="gvSuscriptores" runat="server" AutoGenerateColumns="False" Width="660px">
        <Columns>
            <asp:BoundField DataField="susc_mail" HeaderText="Email" />
            <asp:BoundField DataField="susc_fech" HeaderText="Fecha" />
        </Columns>
    </asp:GridView>
</asp:Content>

