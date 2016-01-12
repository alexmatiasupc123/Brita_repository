<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="MantMaestro.aspx.cs" Inherits="MantMaestro" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento" TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"   TagPrefix="cc2" %>
<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc3" %>

<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Tabla Maestra"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 850px;">
                <table>
                    <tr>
                        <td>
                            <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                            <asp:HiddenField ID="hfEvento" runat="server" />
                            <asp:HiddenField ID="HF_Nivel" runat="server" />
                            <asp:HiddenField ID="HF_CodTabla" runat="server" />
                            <asp:HiddenField ID="HF_Ver" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <fieldset>
                    <legend style="font-weight: bold">Datos Generales de la Tabla </legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="680px">
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label1" runat="server" Text="Código Tabla :"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="f_txtCodigoTabla" runat="server" Width="100px" 
                                    EnableTheming="True" MaxLength="5" onkeypress="return filterInput(0, event, false ,' ')"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label3" runat="server" Text="Nivel :"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="f_ddlNivel" runat="server" Width="100px">
                                    <asp:ListItem>1</asp:ListItem>
                                    <asp:ListItem>2</asp:ListItem>
                                    <asp:ListItem>3</asp:ListItem>
                                    <asp:ListItem>4</asp:ListItem>
                                    <asp:ListItem Value="5"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <%--<tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label2" runat="server" Text="Longitud por Nivel :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtLongitudNivel" runat="server" EnableTheming="True" Width="100px"></asp:TextBox>
                               
                            </td>
                            
                        </tr>--%>
                        <tr>    
                            <td class="FieldTextbox">
                                <asp:Label ID="lblLongitud" runat="server" Text="Longitud por Nivel :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtLongitudNivel" runat="server" Width="30px" 
                                    EnableTheming="True" Enabled="False" Text="2" ></asp:TextBox>
                                <cc1:NumericUpDownExtender ID="txtLongitud_NumericUpDownExtender" 
                                    runat="server" Enabled="True" Maximum="6" Minimum="1" RefValues="" 
                                    ServiceDownMethod="" ServiceDownPath="" ServiceUpMethod="" Tag="" 
                                    TargetButtonDownID="" TargetButtonUpID="" TargetControlID="f_txtLongitudNivel" 
                                    Width="100">
                                </cc1:NumericUpDownExtender>
                            </td>
                        </tr>
                            
                        
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label4" runat="server" Text="Nombre :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtNombre" Width="447px" runat="server"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label5" runat="server" Text="Descripción :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtDescripcion" runat="server" Height="50"  onKeyUp="Count(this,300)
                                    TextMode="MultiLine" Width="450"></asp:TextBox>
                            </td>
                        </tr>
                        
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label13" runat="server" Text="Activo :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="f_chkActivo" runat="server" Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                     <fieldset style="width: 650px">
                            <legend>
                                <asp:Label ID="Label6" runat="server" Text="Otros Campos Opcionales">
                                </asp:Label></legend>
                                <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label7" runat="server" Text="Activar Ver ValorCadena :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorCadena" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorCadena" runat="server" Width="230px" 
                                             MaxLength="50" Visible="False" ></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label8" runat="server" Text="Activar Ver Valor Cadena Corta :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorCadenaCorta" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorCadenaCorta" runat="server" Width="230px" 
                                             MaxLength="50" Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                 <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label12" runat="server" Text="Activar Ver Valor Cadena Larga :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorCadenaLarga" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorCadenaLarga" runat="server" Width="230px" 
                                             Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label9" runat="server" Text="Activar Ver Valor Decimal :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorDecimal" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorDecimal" runat="server" Width="230px" 
                                             Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label10" runat="server" Text="Activar Ver Valor Entero :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorEntero" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorEntero" runat="server" Width="230px" 
                                             Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="FieldTextbox">
                                        <asp:Label ID="Label11" runat="server" Text="Activar Ver Valor Lógico :"></asp:Label>
                                    </td>
                                    <td>
                                        <asp:CheckBox ID="f_chkVerValorLogico" runat="server" AutoPostBack="True" 
                                            oncheckedchanged="f_chkVerValoresAdicionales_CheckedChanged" />
                                    </td>
                                    <td  style="width: 10px">
                                    </td>
                                     <td>
                                         <asp:TextBox ID="f_txtVerValorLogico" runat="server" Width="230px" 
                                             Visible="False"></asp:TextBox>
                                    </td>
                                </tr>
                               
                                </table>
                     </fieldset>
                        
                </fieldset>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
