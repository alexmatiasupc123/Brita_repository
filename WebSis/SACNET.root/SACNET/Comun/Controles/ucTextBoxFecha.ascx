<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTextBoxFecha.ascx.cs" Inherits="ucTextBoxFecha" %>
<asp:TextBox ID="txtFecha" runat="server" Width="90px"></asp:TextBox>
<asp:ImageButton ID="ibtnFecha" runat="server" ImageUrl="~/Comun/Imagenes/Icons/Calendar.png"
    TabIndex="13" />
<div style="display: none">
    <cc1:MaskedEditValidator ID="txtFecha_MaskedEditValidator" runat="server" ControlExtender="txtFecha_MaskedEditExtender"
        ControlToValidate="txtFecha" IsValidEmpty="False" messageempty="" Enabled="True"
        InvalidValueMessage="" Display="Dynamic" ForeColor="" ValidationGroup="buscar"></cc1:MaskedEditValidator>
    <cc1:MaskedEditExtender ID="txtFecha_MaskedEditExtender" runat="server" Enabled="True"
        TargetControlID="txtFecha" Mask="99/99/9999" MaskType="Date" OnInvalidCssClass="cssTextBoxInvalid">
    </cc1:MaskedEditExtender>
    <cc1:CalendarExtender ID="txtFecha_CalendarExtender" runat="server" Enabled="True"
        PopupButtonID="ibtnFecha" TargetControlID="txtFecha">
    </cc1:CalendarExtender>
</div>
