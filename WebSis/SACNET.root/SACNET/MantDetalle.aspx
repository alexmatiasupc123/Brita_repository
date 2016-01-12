<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true"
    CodeFile="MantDetalle.aspx.cs" Inherits="MantMaestro" %>
<%@ MasterType VirtualPath="~/_MasterPage.master" %>

<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<%@ Register Assembly="UpdatePanelJavaScript" Namespace="UpdatePanelJavaScript.UpdatePanelJavaScript"
    TagPrefix="cc2" %>
<%@ Register assembly="System.Web.DynamicData, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.DynamicData" tagprefix="cc3" %>
<%@ Register Src="Comun/Controles/ucAuditoria.ascx" TagName="Auditoria" TagPrefix="uc3" %>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Tabla Maestra"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 900px;">
                <table>
                    <tr>
                        <td>
                            <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                            <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                            <asp:HiddenField ID="hfEvento" runat="server" />
                            <asp:HiddenField ID="HF_Nivel" runat="server" />
                            <asp:HiddenField ID="HF_CodTabla" runat="server" />
                            <asp:HiddenField ID="HF_CodiArgumento" runat="server" />
                            <asp:HiddenField ID="HF_Ver" runat="server" />
                            <asp:HiddenField ID="hfParameters" runat="server" />
                        </td>
                    </tr>
                </table>
                <br />
                <fieldset>
                    <legend style="font-weight: bold">Datos del registro de la tabla </legend>
                    <table border="0" cellpadding="0" cellspacing="0" width="680px">
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label1" runat="server" Text="Código de argumento :"></asp:Label>
                            </td>
                            <td >
                                <asp:TextBox ID="f_txtCodigoArgumento" runat="server" Width="100px" 
                                    EnableTheming="True"></asp:TextBox>
                            </td>
                        </tr>
                        
                         <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="lblNivel1" runat="server" Text="Nivel1:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNivel1" runat="server" Width="200px" 
                                    onselectedindexchanged="ddlNivel1_SelectedIndexChanged" Visible="False" 
                                    AutoPostBack="True" ></asp:DropDownList>
                            </td>
                        </tr>  
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="lblNivel2" runat="server" Text="Nivel2:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNivel2" runat="server" Width="200px" 
                                    onselectedindexchanged="ddlNivel2_SelectedIndexChanged" Visible="False" 
                                    AutoPostBack="True" ></asp:DropDownList>
                            </td>
                        </tr>  
                        <tr>
                            <td class="FieldTextbox"> 
                            <asp:Label ID="lblNivel3" runat="server" Text="Nivel3:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNivel3" runat="server" Width="200px" 
                                    onselectedindexchanged="ddlNivel3_SelectedIndexChanged" Visible="False" 
                                    AutoPostBack="True" ></asp:DropDownList>
                            </td>
                        </tr>      
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="lblNivel4" runat="server" Text="Nivel4:" Visible="False"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlNivel4" runat="server" Width="200px" 
                                    onselectedindexchanged="ddlNivel4_SelectedIndexChanged" Visible="False" 
                                    AutoPostBack="True" ></asp:DropDownList>
                            </td>
                        </tr>  
                        <tr>    
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblNombre" runat="server" Text="Nombre :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtNombre" runat="server" style="margin-bottom: 0px" 
                                    Width="447px" MaxLength="100"></asp:TextBox>
                            </td>
                        </tr>
                            
                        
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorCadena" runat="server" Text="Valor de cadena :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtValorCadena" runat="server" style="margin-bottom: 0px" 
                                    Width="447px" MaxLength="100"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorCadenaCorta" runat="server" Text="Valor cadena corta:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtValorCadenaCorta" runat="server" style="margin-bottom: 0px" 
                                    Width="447px" MaxLength="10"></asp:TextBox>
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorCadenaLarga" runat="server" 
                                    Text="Valor cadena larga :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtValorCadenaLarga" runat="server" Height="50px"  onKeyUp="Count(this,500)
                                    TextMode="MultiLine" Width="450"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorDecimal" runat="server" Text="Valor decimal :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtValorDecimal" runat="server" EnableTheming="True" 
                                    Width="100px" MaxLength="12" onkeypress="return filterInput(1, event, true ,' ')" ></asp:TextBox>
                               
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorEntero" runat="server" Text="Valor entero :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="f_txtValorEntero" runat="server" EnableTheming="True" 
                                    Width="100px" MaxLength="10" onkeypress="return filterInput(1, event)"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="f_lblValorBoolean" runat="server" Text="Valor lógico :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="f_chkValorBoolean" runat="server" EnableTheming="True" />
                            </td>
                        </tr>
                        <tr>
                            <td class="FieldTextbox">
                                <asp:Label ID="Label15" runat="server" Text="Activo :"></asp:Label>
                            </td>
                            <td>
                                <asp:CheckBox ID="f_chkActivo" runat="server" EnableTheming="True" 
                                    Checked="True" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                               
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                       
                </fieldset>
            </div>
            <asp:Panel ID="pnAuditoria" runat="server">
                <uc3:Auditoria ID="Auditoria1" runat="server" />
            </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <cc2:UpdatePanelJavaScriptExtender ID="UpdatePanelJavaScriptExtender1" runat="server"
        TargetControlID="UpdatePanel1" ClientCommand="ActualizarPanel" OnUpdate="UpdatePanelJavaScriptExtender1_Update"
        Enabled="True">
    </cc2:UpdatePanelJavaScriptExtender>
</asp:Content>
