<%@ Control Language="C#" AutoEventWireup="true" CodeFile="MessageBox.ascx.cs" Inherits="Controles_MessageBox" %>

<asp:LinkButton ID="LinkButtonTargetControl" runat="server" Style="display:none"   ></asp:LinkButton>
<cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" CancelControlID="CloseButton"
    OkControlID="ButtonOK" PopupControlID="MessageBox" TargetControlID="LinkButtonTargetControl"
   
    BackgroundCssClass="messagemodalbackground" >
</cc1:ModalPopupExtender>
<%-- PopupDragHandleControlID="MessageBoxHeader"--%>
<asp:Panel ID="MessageBox" runat="server" Style="display:none">

    <div id="MessageBoxHeader" class="messageheader">
        <div class="messageheadertext" ><asp:Label ID="LabelPopupHeader"  runat="server" Text="Header Text" /></div>
        <asp:HyperLink runat="server" ID="CloseButton">
            <asp:Image ID="Image1" runat="server" ImageUrl="../Imagenes/Icons/close.png" ToolTip="Haga click aquí para cerrar la ventana." />
        </asp:HyperLink>
       
    </div>
   
    <asp:Literal ID="litMessage" runat="server"></asp:Literal>
    <div class="messagefooter">
        <asp:Button ID="btAceptar" runat="server" Text="Aceptar" 
            onclick="btAceptar_Click" Width="80" />
        <asp:Button ID="ButtonOK" runat="server" Text="Aceptar" Width="80px" />
    </div>
      <asp:HiddenField ID="hfMetodo" runat="server" />
</asp:Panel>





