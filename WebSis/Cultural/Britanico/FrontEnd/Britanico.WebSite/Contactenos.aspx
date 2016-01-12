<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contactenos.aspx.cs" Inherits="Contactenos" Title="CENTRO CULTURAL BRITÁNICO - Contáctenos" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content2" runat="server" ContentPlaceHolderID="Contentplaceholder2">
    <table style="width: 410px; height: 362px; text-align: left" border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td colspan="3" style="height: 93px">
                <asp:Label ID="lblTitulo" runat="server" CssClass="titulo" Text="Contáctenos" Width="411px"></asp:Label>
                <hr style="width: 100%" />
                <br />
                <asp:Label ID="Label10" runat="server" Font-Bold="True" SkinID="campoNombre" Text="Indique a que área desea enviar su mensaje" Width="338px"></asp:Label><br />
                <br />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 50px; height: 22px; text-align: right;" valign="middle">
                <asp:Label ID="Label8" runat="server" Text="Area de Envío:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px; height: 22px" valign="top">
            </td>
            <td style="width: 360px; height: 22px" valign="top">
                <asp:DropDownList ID="ddlAreaEnvio" runat="server" SkinID="ddlListas" CssClass="textos" Width="200px" ValidationGroup="enviar">
                    <asp:ListItem Selected="True" Value="0">--Seleccione--</asp:ListItem>
                    <asp:ListItem Value="1">Centro Cultural</asp:ListItem>
                    <asp:ListItem Value="2">Biblioteca</asp:ListItem>
                    <asp:ListItem Value="3">Examenes Internacionales</asp:ListItem>
                    <asp:ListItem Value="4">Informacion General</asp:ListItem>
                    <asp:ListItem Value="5">Centros de Ense&#241;anza</asp:ListItem>
                    <asp:ListItem Value="6">Atencion a Empresas</asp:ListItem>
                    <asp:ListItem Value="7">RRHH</asp:ListItem>
                    <asp:ListItem Value="8">Logistica</asp:ListItem>
                </asp:DropDownList>
                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="ddlAreaEnvio"
                    Display="None" ErrorMessage="Seleccione el Area" MaximumValue="8" MinimumValue="1"
                    Type="Integer" ValidationGroup="enviar"></asp:RangeValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" align="right" valign="middle">
                <asp:Label ID="Label6" runat="server" Text="Nombres:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strNombre" runat="server" SkinID="Textos" CssClass="textos" Width="200px" ValidationGroup="enviar"></asp:TextBox>
                &nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="strNombre"
                    Display="None" ErrorMessage="Ingrese su Nombre" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" align="right" valign="middle">
                <asp:Label ID="Label3" runat="server" Text="Apellidos:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strApellidos" runat="server" SkinID="Textos" CssClass="textos" Width="200px" ValidationGroup="enviar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="strApellidos"
                    Display="None" ErrorMessage="Ingrese su Apellido" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" align="right" valign="middle">
                <asp:Label ID="Label5" runat="server" Text="Dirección:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strDireccion" runat="server" SkinID="Textos" CssClass="textos" Width="200px" ValidationGroup="enviar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="strDireccion"
                    Display="None" ErrorMessage="Ingrese su Dirección" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" align="right" valign="middle">
                <asp:Label ID="Label7" runat="server" Text="Teléfono:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strTelefono" runat="server" SkinID="Textos" CssClass="textos" Width="200px" ValidationGroup="enviar"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="strTelefono"
                    Display="None" ErrorMessage="Ingrese su Teléfono" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" align="right" valign="middle">
                <asp:Label ID="Label9" runat="server" Text="Correo Electrónico:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strMail" runat="server" SkinID="Textos" CssClass="textos" Width="200px" ValidationGroup="enviar"></asp:TextBox>&nbsp;
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="strMail"
                    Display="None" ErrorMessage="Ingrese un mail valido" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ValidationGroup="enviar"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="strMail"
                    Display="None" ErrorMessage="Ingrese su email" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" valign="middle" align="right">
                <asp:Label ID="Label4" runat="server" Text="Alumno:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px;" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:RadioButtonList ID="rblAlumno" runat="server" RepeatDirection="Horizontal"
                    Width="100px">
                    <asp:ListItem Selected="True" Value="1">Si</asp:ListItem>
                    <asp:ListItem Value="0">No</asp:ListItem>
                </asp:RadioButtonList></td>
        </tr>
        <tr>
            <td style="width: 50px; height: 22px; text-align: right;" valign="top" align="right">
                <asp:Label ID="Label2" runat="server" Text="Asunto:" SkinID="camposNombre" Width="111px"></asp:Label></td>
            <td style="width: 10px; height: 22px" valign="top">
            </td>
            <td style="width: 360px;" valign="top">
                <asp:TextBox ID="strAsunto" runat="server" SkinID="Textos" TextMode="MultiLine" Height="83px" Width="243px" ValidationGroup="enviar" CssClass="textos"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="strAsunto"
                    Display="None" ErrorMessage="Ingrese el asunto" ValidationGroup="enviar"></asp:RequiredFieldValidator></td>
        </tr>
        <tr>
            <td align="center" style="height: 30px" valign="top" colspan="3">
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender1" runat="server" TargetControlID="RequiredFieldValidator1">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender2" runat="server" TargetControlID="RequiredFieldValidator2">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender3" runat="server" TargetControlID="RequiredFieldValidator3">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender4" runat="server" TargetControlID="RequiredFieldValidator4">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender5" runat="server" TargetControlID="RequiredFieldValidator5">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender6" runat="server" TargetControlID="RequiredFieldValidator6">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender7" runat="server" TargetControlID="RangeValidator1">
                </cc1:ValidatorCalloutExtender>
                <cc1:ValidatorCalloutExtender ID="ValidatorCalloutExtender8" runat="server" TargetControlID="RegularExpressionValidator1">
                </cc1:ValidatorCalloutExtender>
                <br />
                <asp:Label ID="_message" runat="server" ForeColor="Red" Visible="False"></asp:Label></td>
        </tr>
        <tr>
            <td style="width: 126px; height: 30px;" align="right" valign="top">
            </td>
            <td align="left" style="width: 10px; height: 22px" valign="top">
            </td>
            <td style="width: 160px; height: 30px;" align="left" valign="top">
                &nbsp;<asp:ImageButton ID="btnEnviar" runat="server" ImageUrl="~/App_themes/SkinBritanico/Images/enviar.jpg" OnClick="btnEnviar_Click" ValidationGroup="enviar" />
                <asp:ImageButton ID="btnLimpiar" runat="server" ImageUrl="~/App_themes/SkinBritanico/Images/limpiar.jpg" /></td>
        </tr>
    </table>
</asp:Content>

