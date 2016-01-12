<%@ Control Language="C#" AutoEventWireup="true" CodeFile="UpdateProgress.ascx.cs"
    Inherits="Comun_Controles_UpdateProgress" %>
<script type="text/javascript" language="javascript">
    var ModalProgress = '<%= ModalProgress.ClientID %>';

    Sys.WebForms.PageRequestManager.getInstance().add_beginRequest(beginReq);
    Sys.WebForms.PageRequestManager.getInstance().add_endRequest(endReq);

    function beginReq(sender, args) {
        // shows the Popup 
        $find(ModalProgress).show();
    }

    function endReq(sender, args) {
        //  shows the Popup 
        $find(ModalProgress).hide();
    } 


</script> 
<asp:LinkButton ID="LinkButtonTargetControl" runat="server" Style="display:none"   ></asp:LinkButton>
<asp:Panel ID="panelUpdateProgress" runat="server" CssClass="updateProgress">
    <asp:UpdateProgress ID="UpdateProg1" DisplayAfter="0" runat="server">
        <ProgressTemplate>
            <div style="position: relative; top: 30%; text-align: center;">
                <img src="loading.gif" style="vertical-align: middle" alt="Procesando" />
                Procesando ...
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Panel>
<cc1:ModalPopupExtender ID="ModalProgress" runat="server" TargetControlID="panelUpdateProgress"
    BackgroundCssClass="messagemodalbackground" PopupControlID="panelUpdateProgress" />
