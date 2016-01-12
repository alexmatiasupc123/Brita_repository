<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login"
    Title="BRITANICO - Self Access Centre - SACNET" %>

<%@ Register src="Comun/Controles/UpdateProgress.ascx" tagname="UpdateProgress" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Comun/Styles/Ajax.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        body
        {
            margin: 0px 0 0;
        }
    </style>

   
 
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 600px">
    
        &nbsp;<cc1:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnableScriptGlobalization="True"
            EnableScriptLocalization="true">
        </cc1:ToolkitScriptManager>
        
      <%--  <uc1:UpdateProgress ID="UpdateProgress1" runat="server" />
      --%> 
        
       
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table style="height: 500px" width="713" border="0" align="center" cellpadding="0"
                    cellspacing="0">
                    <tr>
                        <td rowspan="5">
                            <table cellpadding="0" cellspacing="0" border="0" bordercolor="yellow">
                                <tr>
                                    <td style="height: 600px; width: 120px; background: url(Comun/Imagenes/login/britanicoizq.jpg);">
                                    </td>
                                    <td width="16px">
                                    </td>
                                    <td width="48px" style="background: url(Comun/Imagenes/login/Dibujo5.PNG)">
                                    </td>
                                    <td width="17px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="bottom" align="left">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td style="width: 513px; text-align: center">
                                        <img name="home_r1_c1" src="Comun/Imagenes/login/Dibujo4a.PNG" alt="" height="120px">
                                    </td>
                                </tr>
                                <tr>
                                    <td height="4px">
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <img name="home_r1_c1" src="Comun/Imagenes/login/imgSac.jpg" alt="">
                                                </td>
                                                <td>
                                                    <img name="home_r1_c1" src="Comun/Imagenes/login/sac_net.jpg" alt="">
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="4px">
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td rowspan="5">
                            <img src="Comun/Imagenes/login/spacer.gif" width="1" height="585px" alt="">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 513px; height: 136px">
                            <table border="0" cellpadding="0" cellspacing="0" width="513px">
                                <tr>
                                    <td style="width: 100px; height: 38px; background: url(Comun/Imagenes/login/Dibujo9A.png)">
                                    </td>
                                    <td rowspan="2" style="width: 413px; background: url(Comun/Imagenes/login/dibujo10b.png)">
                                        <div style="float: right; margin-right: 50px">
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label2" runat="server" Text="Usuario: " ForeColor="White" Font-Names="Calibri"
                                                            Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td rowspan="4">
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtUsuarioLogin" runat="server" autocomplete="off" AutoPostBack="True"
                                                            OnTextChanged="txtUsuarioLogin_TextChanged" TabIndex="0" Width="160px" Font-Names="Calibri"
                                                            Font-Size="12px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="Label1" runat="server" Text="Contraseña:" ForeColor="White" Font-Names="Calibri"
                                                            Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtPasswordLogin" runat="server" TabIndex="1" TextMode="Password"
                                                            Width="160px" Font-Names="Calibri" Font-Size="12px"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Label ID="lblRol" runat="server" Text="Rol: " Visible="False" ForeColor="White"
                                                            Font-Names="Calibri" Font-Size="12px"></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlRoles" runat="server" Visible="false" Width="162px" 
                                                            Font-Names="Calibri">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td align="right">
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="Comun/Imagenes/login/home_r6_c6.jpg"
                                                            OnClick="btnAceptar_Click" ToolTip="Ingresar" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 100px; height: 98px; background: url(Comun/Imagenes/login/dibujo9b.png)">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 4px">
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 25px; background: url(Comun/Imagenes/login/regis1.jpg); text-align: center;">
                            <asp:Label ID="lblDatosIncorrectos" runat="server" CssClass="cssPanelError" Font-Names="Calibri"
                                Font-Size="12px" ForeColor="White"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="height: 40px;">
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
