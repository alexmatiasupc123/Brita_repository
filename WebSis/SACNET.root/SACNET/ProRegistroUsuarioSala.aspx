<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="ProRegistroUsuarioSala.aspx.cs" Inherits="ProRegistroUsuarioSala" %>

<%@ MasterType VirtualPath="~/_MasterPage.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register src="Comun/Controles/ucTextBoxFecha.ascx" tagname="ucTextBoxFecha" tagprefix="uc4" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" 
    Text="Nuevo - Registro de Usuarios en Sala"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="panelBotones">
                <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" 
                    runat="server" BotonNuevoEnabled="True" />
            </div>
            <div class="panelleyenda">
            </div>
            <div class="panelGria">
                <table>
                    <tr>
                        <td>
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                        </td>
                    </tr>
                </table>
                <br />
                <fieldset style="width: 870px">
                    <legend>Datos del usuario</legend>
                    <table width="850px">
                        <tr>
                            <td width="200">
                                <asp:Label ID="Label1" runat="server" Text="Código:"></asp:Label>
                            </td>
                            <td width="450">
                                <table>
                                    <tr>
                                        <td  style="vertical-align:bottom">
                                            <asp:TextBox ID="f_txtCodigoUsuarioSAC" runat="server" MaxLength="10"  
                                            onkeypress="return filterInput(1, event)" Width="129px" Font-Bold="False" 
                                            ForeColor="#000066">
                                            </asp:TextBox>
                                        </td>
                                        <td>
                                            <asp:ImageButton ID="ButtonBuscarUsuarioSAC"  runat="server" 
                                            ImageUrl="~/Comun/Imagenes/Botones/RecDatos_A.png" ToolTip="Buscar usuario SAC" 
                                            OnClick="ButtonBuscarUsuarioSAC_Click" Height="29px" Width="103px"/>
                                        </td>
                                    </tr>
                                </table>
                                
                                
                            </td>
                            <td rowspan="9" width="200" valign="top">
                                    <table style="width:200px">
                                        <tr>
                                            <td style="text-align: center;" valign="top" width="180">
                                                
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td align="left">
                                                            &nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                            <td style="text-align: center;" width="170">
                                                
                                                <table style="width:170px; float:right;">
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            <asp:Image ID="f_ImageUsuarioSAC" runat="server" Height="150px" 
                                                                ImageUrl="~/User.png" Width="130px" />
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td style="text-align: center;">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                                
                                            </td>
                                        </tr>
                                    </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                                <asp:Label ID="Label3" runat="server" Text="Nombres:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                <asp:Label ID="f_txtNombres" runat="server" Width="200px" Font-Bold="False"
                                    ForeColor="#000066"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                                <asp:Label ID="Label8" runat="server" Text="Apellidos:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                <asp:Label ID="f_txtApellidos" runat="server" Width="200px" Font-Bold="False"
                                    ForeColor="#000066"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td height="25" width="200">
                                <asp:Label ID="Label13" runat="server" Text="Uso de Sala en SAC:"></asp:Label>
                            </td>
                            <td height="25" width="450">
                                <asp:Label ID="f_labelsCodLocalSACRegistro" runat="server" Font-Bold="False" 
                                    ForeColor="#000066" Width="134px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                               <asp:Label ID="Label6" runat="server" Text="Usuario pertenece al Centro:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                 <asp:Label ID="f_txtSAC" runat="server" Font-Bold="True" 
                                    Width="199px" ForeColor="#000066"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                                <asp:Label ID="Label28" runat="server" Text="Fecha de Inicio:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                <table cellpadding="0" cellspacing="0" width="300">
                                    <tr>
                                        <td width="150">
                                            <uc4:ucTextBoxFecha ID="f_TextBoxFechaInicio" runat="server" Enabled="True" />
                                        </td>
                                        <td width="50">
                                            <asp:Label ID="Label30" runat="server" Text="Hora:"></asp:Label>
                                        </td>
                                        <td width="50">
                                            <asp:DropDownList ID="f_DropDownListHoraInicio" runat="server" Width="40px">
                                                <asp:ListItem Value="00">Hora</asp:ListItem>
                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                <asp:ListItem Value="09">09</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                <asp:ListItem Value="24">24</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="50">
                                            <asp:Label ID="Label33" runat="server" Text="Min:"></asp:Label>
                                        </td>
                                        <td width="50">
                                            <asp:TextBox ID="f_txtMinutoInicio" runat="server" Font-Bold="False" 
                                                ForeColor="#000066" MaxLength="2" onkeypress="return filterInput(1, event)" 
                                                Width="40px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                                <asp:Label ID="Label29" runat="server" Text="Fecha Fin:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                <table cellpadding="0" cellspacing="0" width="300">
                                    <tr>
                                        <td width="150">
                                            <uc4:ucTextBoxFecha ID="f_TextBoxFechaFin" runat="server" Enabled="True" />
                                        </td>
                                        <td width="50">
                                            <asp:Label ID="Label31" runat="server" Text="Hora:"></asp:Label>
                                        </td>
                                        <td width="50">
                                            <asp:DropDownList ID="f_DropDownListHoraFin" runat="server" 
                                                Width="40px">
                                                <asp:ListItem Value="00">Hora</asp:ListItem>
                                                <asp:ListItem Value="01">01</asp:ListItem>
                                                <asp:ListItem Value="02">02</asp:ListItem>
                                                <asp:ListItem Value="03">03</asp:ListItem>
                                                <asp:ListItem Value="04">04</asp:ListItem>
                                                <asp:ListItem Value="05">05</asp:ListItem>
                                                <asp:ListItem Value="06">06</asp:ListItem>
                                                <asp:ListItem Value="07">07</asp:ListItem>
                                                <asp:ListItem Value="08">08</asp:ListItem>
                                                <asp:ListItem Value="09">09</asp:ListItem>
                                                <asp:ListItem Value="10">10</asp:ListItem>
                                                <asp:ListItem Value="11">11</asp:ListItem>
                                                <asp:ListItem Value="12">12</asp:ListItem>
                                                <asp:ListItem Value="13">13</asp:ListItem>
                                                <asp:ListItem Value="14">14</asp:ListItem>
                                                <asp:ListItem Value="15">15</asp:ListItem>
                                                <asp:ListItem Value="16">16</asp:ListItem>
                                                <asp:ListItem Value="17">17</asp:ListItem>
                                                <asp:ListItem Value="18">18</asp:ListItem>
                                                <asp:ListItem Value="19">19</asp:ListItem>
                                                <asp:ListItem Value="20">20</asp:ListItem>
                                                <asp:ListItem Value="21">21</asp:ListItem>
                                                <asp:ListItem Value="22">22</asp:ListItem>
                                                <asp:ListItem Value="23">23</asp:ListItem>
                                                <asp:ListItem Value="24">24</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                        <td width="50">
                                            <asp:Label ID="Label34" runat="server" Text="Min:"></asp:Label>
                                        </td>
                                        <td width="50">
                                            <asp:TextBox ID="f_txtMinutoFin" runat="server" Font-Bold="False" 
                                                ForeColor="#000066" MaxLength="2" onkeypress="return filterInput(1, event)" 
                                                Width="40px"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="200" height="25">
                                <asp:Label ID="Label32" runat="server" Text="Observaciones:"></asp:Label>
                            </td>
                            <td width="450" height="25">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2" width="650">
                                <asp:TextBox ID="f_txtObservaciones" runat="server" Font-Bold="False" 
                                    ForeColor="#000066" Height="80px" MaxLength="2000" 
                                    TextMode="MultiLine" Width="490px"></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </fieldset>
                &nbsp;
                <asp:Label ID="f_labelsCodRegistro" runat="server" Font-Bold="False" 
                    ForeColor="White" Width="134px"></asp:Label>
                <asp:TextBox ID="f_txtSACID" runat="server" Enabled="False" Visible="false" 
                    Width="15px"></asp:TextBox>
                <table>
                    <tr>
                        <td>
                            <uc3:Auditoria ID="Auditoria1" runat="server" />
                            <asp:HiddenField ID="HF_CodRegistro" runat="server" />
                            <asp:HiddenField ID="HF_Evento" runat="server" />
                            <asp:HiddenField ID="HF_Ver" runat="server" />
                            <asp:HiddenField ID="HF_Matricul" runat="server" />
                            <asp:HiddenField ID="HF_Proceso" runat="server" />
                            
                            <asp:HiddenField ID="hfParameters" runat="server" />
                            
                        </td>
                    </tr>
                </table>
            </div>
            
                      <input id="ctl01" name="ctl01"  runat=server type="text" onchange="javascript:setTimeout('__doPostBack(\'ctl00$ContentPlaceHolder1$ctl01\',\'\')', 0)" onkeypress="if (WebForm_TextBoxKeyHandler(event) == false) return false;"  class="cssTextBox" style="visibility:hidden;display:none;" />
            <asp:HiddenField ID="HiddenField1" runat="server" />


            
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>--%>
    
      <script type="text/javascript">


        function ActualizarPanel(parameter) {
   
        document.getElementById("<%=HiddenField1.ClientID%>").value= parameter;
        <%  Session["PameterMntDoc"] = HiddenField1.Value; %>
      
           
            Update('<%=ctl01.ClientID%>', parameter);
        };


        function Update(HiddenBoxID, parameter) {
            var HiddenBox = $get(HiddenBoxID);
            if (typeof (parameter) == "undefined") {
                parameter = "RANDOMPARAM" + Math.random();
            };
            if (HiddenBox.value == parameter) {
                parameter = parameter + "RANDOMPARAM" + Math.random();
           };
            HiddenBox.value = parameter;
            var MyCommand = String(HiddenBox.onchange).replace('function anonymous()\n{\n', '');
         //   MyCommand = MyCommand.replace('\n}', '');
            MyCommand = MyCommand.replace('function onchange(event) {\njavascript:\n', '');
            eval(MyCommand);
        };
         
    </script>

    
</asp:Content>
