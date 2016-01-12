<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default"  EnableTheming="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>CENTRO CULTURAL BRITANICO - ADMINISTRADOR DE CONTENIDOS</title>
</head>
<body style="BACKGROUND-IMAGE: url(App_Themes/SkinBritanico/Images/fondoAdmin.jpg); background-repeat:repeat; WIDTH: 100%; HEIGHT: 100%; TEXT-ALIGN: center; background-color:#ff0000">
    <form id="form1" runat="server">
        <div >

                    
            <table border="0" cellpadding="0" cellspacing="0" style="left: 150px; position: absolute; top: 200px;">
                <tr>
                    <td align="left" colspan="3" style="height: 19px">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/App_Themes/SkinBritanico/Images/tituloLogin.png" /></td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="width: 122px; height: 19px">
                                    <asp:Label ID="Label2" runat="server" Font-Bold="False" Text="Usuario:" Font-Names="Arial" Font-Size="14px" ForeColor="White"></asp:Label></td>
                    <td align="left" colspan="1" style="width: 404px; height: 19px">
                                    <asp:TextBox ID="txtUsuario" runat="server" SkinID="Textos" Width="195px" Font-Names="Arial" Font-Size="12px" ForeColor="#666666"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right" colspan="2" style="width: 122px; height: 19px">
                                    <asp:Label ID="Label3" runat="server" Font-Bold="False" Text="Contraseña:" Font-Names="Arial" Font-Size="14px" ForeColor="White"></asp:Label></td>
                    <td align="left" colspan="1" style="width: 404px; height: 19px">
                                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"
                                        Width="195px" Font-Names="Arial" Font-Size="12px" ForeColor="#666666"></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="left" colspan="2" style="width: 122px; height: 19px">
                    </td>
                    <td align="left" colspan="1" style="width: 404px; height: 19px">
                                    <asp:ImageButton ID="btnIngresar" runat="server" ImageUrl="~/App_Themes/SkinBritanico/Images/login.jpg"
                                        OnClick="btnIngresar_Click" /></td>
                </tr>
                <tr>
                    <td colspan="3" style="height: 40px; text-align: center">
                        <asp:Label ID="lblState" runat="server" SkinID="tError" Font-Names="Arial" Font-Size="10px" ForeColor="White"></asp:Label></td>
                </tr>
            </table>
                 
                </div>
  
    </form>
</body>
</html>
