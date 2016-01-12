<%@ Page Title="Edición de Ejemplares" Language="C#" MasterPageFile="~/_MasterPopup.master" AutoEventWireup="true"
    CodeFile="PopupAgregarEjemplar.aspx.cs" Inherits="PopupAgregarEjemplar" %>
<%@ MasterType VirtualPath="~/_MasterPopup.master" %>
<%@ Register Src="Comun/Controles/BotonesEdicionMantenimiento.ascx" TagName="BotonesEdicionMantenimiento"
    TagPrefix="uc1" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cphTitulo" runat="Server">
    Edición de Ejemplares.
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div style="width: 600px">
        <asp:UpdatePanel ID="udpRegistroEjemplares" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panelBotones">
                    <uc1:BotonesEdicionMantenimiento ID="BotonesEdicionMantenimiento1" runat="server" />
                    <uc2:MessageBox ID="MessageBox1" runat="server" ShowCloseButton="true" />
                    <asp:HiddenField ID="hfEvento" runat="server" />
                    <asp:HiddenField ID="hfCodEjemplar" runat="server" />
                </div>
                <div class="panelBucador">
                    <fieldset style="width: 570px">
                        <legend>Registro de Ejemplares </legend>
                        <table>
                            <tr>
                                <td style="width:120px">
                                    <asp:Label ID="Label7" runat="server" Text="Código de ejemplar :"></asp:Label>
                                </td>
                                <td style="width:150px">
                                    <asp:TextBox ID="txtCodigoEjemplar" runat="server" MaxLength="8"></asp:TextBox>
                                </td>
                                <td style="width:50px">
                                    <asp:Label ID="Label2" runat="server" Text="SAC  :" Visible="False"></asp:Label>
                                </td>
                                <td style="width:250px">
                                    <asp:DropDownList ID="ddlSac" runat="server" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Estado :" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:DropDownList ID="ddlEstadoEjemplar" runat="server" Visible="False">
                                    </asp:DropDownList>
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Reservado  :" Visible="False"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkReservado" runat="server" Text="Si" Visible="False" />
                                </td>
                                
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Notas :"></asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                
                            </tr>
                            <tr>
                                <td colspan="4">
                                    <asp:TextBox ID="txtNotas" runat="server" TextMode="MultiLine" Width="550px" 
                                        onKeyUp="Count(this,500)" Height="50px"></asp:TextBox>
                                </td>
                                
                            </tr>
                        </table>
                    </fieldset>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>
