<%@ page language="C#" masterpagefile="~/MasterPage.master" autoeventwireup="true" inherits="Seguridad_frm_usuarios, App_Web_0wjpmfv7" title="CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS" stylesheettheme="SkinBritanico" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphPrincipal" Runat="Server">
    <asp:Label ID="lblLocation" runat="server" SkinID="lblTitulos">MANTENIMIENTO DE USUARIOS</asp:Label><br />
    <br />
    <asp:UpdatePanel id="UpdatePanel1" runat="server">
        <contenttemplate>
<asp:ImageButton id="btnNuevo" onclick="btnNuevo_Click" runat="server" SkinID="Agregar" __designer:wfdid="w198"></asp:ImageButton><BR /><asp:Panel id="pNuevo" runat="server" Height="300px" SkinID="paneles" Visible="False" __designer:wfdid="w199"><asp:Label id="lblNombreSeccion" runat="server" Text="Agregar Usuario" Width="400px" __designer:dtid="10414574138294278" SkinID="camposNombre" __designer:wfdid="w228"></asp:Label><BR /><BR /><TABLE style="WIDTH: 684px; HEIGHT: 275px" cellSpacing=0 cellPadding=0 border=0><TBODY><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label3" runat="server" Text="Nombres:" SkinID="camposNombre" __designer:wfdid="w200"></asp:Label> </TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtNombre" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w201"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" ForeColor SkinID="rfvError" __designer:wfdid="w202" ControlToValidate="txtNombre" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label10" runat="server" Text="Apellido Paterno:" Width="101px" SkinID="camposNombre" __designer:wfdid="w203"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtApellidoPat" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w204"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator2" runat="server" SkinID="rfvError" __designer:wfdid="w205" ControlToValidate="txtApellidoPat" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label9" runat="server" Text="Apellido Materno:" Width="101px" SkinID="camposNombre" __designer:wfdid="w206"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtApellidoMat" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w207"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator3" runat="server" SkinID="rfvError" __designer:wfdid="w208" ControlToValidate="txtApellidoMat" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator>&nbsp; </TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" vAlign=top align=right><asp:Label id="Label8" runat="server" Text="Login:" SkinID="camposNombre" __designer:wfdid="w209"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" vAlign=top align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px" vAlign=top><asp:TextBox id="txtLogin" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w210" OnTextChanged="txtLogin_TextChanged" AutoPostBack="True"></asp:TextBox> <asp:RequiredFieldValidator id="RequiredFieldValidator4" runat="server" Width="2px" SkinID="rfvError" __designer:wfdid="w211" ControlToValidate="txtLogin" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator><BR /><asp:Label id="lblVerificaLogin" runat="server" Height="15px" Width="219px" SkinID="tError" __designer:wfdid="w212"></asp:Label></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label7" runat="server" Text="Clave:" SkinID="camposNombre" __designer:wfdid="w213"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtClave" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w214" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator5" runat="server" SkinID="rfvError" __designer:wfdid="w215" ControlToValidate="txtClave" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label5" runat="server" Text="Confirma Clave:" Width="89px" SkinID="camposNombre" __designer:wfdid="w216"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtConfirmaClave" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w217" TextMode="Password"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator6" runat="server" SkinID="rfvError" __designer:wfdid="w218" ControlToValidate="txtConfirmaClave" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator><asp:CompareValidator id="CompareValidator1" runat="server" SkinID="cvError" __designer:wfdid="w219" ControlToValidate="txtConfirmaClave" ErrorMessage="*" ValidationGroup="gUsuario" ControlToCompare="txtClave" ToolTip="Claves deben coincidir"></asp:CompareValidator></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right><asp:Label id="Label4" runat="server" Text="Email:" SkinID="camposNombre" __designer:wfdid="w220"></asp:Label></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:TextBox id="txtEmail" runat="server" Width="250px" SkinID="Textos" __designer:wfdid="w221"></asp:TextBox><asp:RequiredFieldValidator id="RequiredFieldValidator7" runat="server" SkinID="rfvError" __designer:wfdid="w222" ControlToValidate="txtEmail" ErrorMessage="*" ValidationGroup="gUsuario"></asp:RequiredFieldValidator></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px"><asp:ImageButton id="btnAgrega" onclick="btnAgrega_Click" runat="server" SkinID="Guardar" __designer:wfdid="w223" ValidationGroup="gUsuario"></asp:ImageButton> <asp:ImageButton id="btnCancela" onclick="btnCancela_Click" runat="server" SkinID="Cancelar" __designer:wfdid="w224"></asp:ImageButton></TD></TR><TR><TD style="WIDTH: 120px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 5px; HEIGHT: 21px" align=right></TD><TD style="WIDTH: 600px; HEIGHT: 21px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <ajaxToolkit:PasswordStrength id="PasswordStrength1" runat="server" __designer:wfdid="w225" PrefixText="" TargetControlID="txtClave">
                                </ajaxToolkit:PasswordStrength> </TD></TR></TBODY></TABLE></asp:Panel>&nbsp;&nbsp; <BR /><asp:GridView id="gvUsuario" runat="server" SkinID="CGrilla" AutoGenerateColumns="False" AllowPaging="True" __designer:wfdid="w226"><Columns>
<asp:BoundField DataField="usua_nomb" HeaderText="Nombres" SortExpression="usua_nomb"></asp:BoundField>
<asp:BoundField DataField="usua_apat" HeaderText="Apellido Paterno" SortExpression="usua_apat"></asp:BoundField>
<asp:BoundField DataField="usua_amat" HeaderText="Apellido Materno" SortExpression="usua_amat"></asp:BoundField>
<asp:BoundField DataField="usua_mail" HeaderText="Email" SortExpression="usua_mail"></asp:BoundField>
<asp:TemplateField><ItemTemplate>
<asp:ImageButton id="btnBaja" onclick="btnBaja_Click" runat="server" SkinID="Baja" CommandArgument='<%# Eval("usua_codi") %>' __designer:wfdid="w234"></asp:ImageButton><ajaxToolkit:ConfirmButtonExtender id="ConfirmButtonExtender2" runat="server" TargetControlID="btnBaja" ConfirmText="Esta Operacion dara de Baja al Usuario, � Desea dar de Baja este Registro?" __designer:wfdid="w235">
                                    </ajaxToolkit:ConfirmButtonExtender> 
</ItemTemplate>
</asp:TemplateField>
</Columns>
</asp:GridView>
</contenttemplate>
    </asp:UpdatePanel>
</asp:Content>
