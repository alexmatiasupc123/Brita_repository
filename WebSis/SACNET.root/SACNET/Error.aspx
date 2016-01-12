<%@ Page Title="" Language="C#" MasterPageFile="~/_MasterPage.master" AutoEventWireup="true" CodeFile="Error.aspx.cs" Inherits="Error" %>
<%@ Register Src="Comun/Controles/MessageBox.ascx" TagName="MessageBox" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphTitulo" Runat="Server">
    <asp:Literal ID="lblTituloPagina" runat="server" Text="Aviso para soporte técnico"></asp:Literal>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="width: 900px">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="panelBotones">
                    <asp:ImageButton ID="ButtonRegresar" runat="server" 
                        PostBackUrl="~/Default.aspx" ImageUrl="~/Comun/Imagenes/Botones/Regresar_A.jpg" 
                        ToolTip="Regresar" onclick="ButtonRegresar_Click"/>
                </div>
                 <div class="panelGria">
                    <fieldset style="width: 870px">
                    <legend>Datos del mensaje</legend>
                    
                        <table>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        </table>
                    </fieldset>    
                 </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

