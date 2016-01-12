using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public enum MessageType
{
    Error = 1,
    Info = 2,
    Success = 3,
    Warning = 4,
    Confirm = 5
}
public partial class Controles_MessageBox : System.Web.UI.UserControl
{

    public event EventHandler OnConfirmClick;
    public bool ShowCloseButton { get; set; }
    private int propHeight;
    private int propWidth;
    protected void Page_Load(object sender, EventArgs e)
    {
        
        propHeight = 160;
        propWidth = 300;
        if (ShowCloseButton)
        {
            CloseButton.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");
            btAceptar.Attributes.Add("onclick", "document.getElementById('" + MessageBox.ClientID + "').style.display = 'none'");
        }

    }
    public void ShowError(string message)
    {
        Show(MessageType.Error, message, propHeight, propWidth);
    }
    public void ShowInfo(string message)
    {
        Show(MessageType.Info, message, propHeight, propWidth);
    }
    public void ShowSuccess(string message)
    {
        Show(MessageType.Success, message, propHeight, propWidth);
    }
    public void ShowWarning(string message)
    {
        Show(MessageType.Warning, message, propHeight, propWidth);
    }
    public void ShowConfirm(string message, string pMetodo)
    {
        Show(MessageType.Confirm, message, propHeight, propWidth);
        hfMetodo.Value = pMetodo;
    }
    public void Show(MessageType messageType, string message, int height, int width)
    {

       
        if (messageType == MessageType.Confirm)
        {
            btAceptar.Visible = true;
            ButtonOK.Text = "Cancel";
        }
        else
        {
            btAceptar.Visible = false;
            ButtonOK.Text = "Aceptar";
        }

        CloseButton.Visible = ShowCloseButton;
        //litMessage.Text = message;
        litMessage.Text = "<div style=\"overflow:auto; height:" + (height - 70).ToString() + "px\"><p>" + message + "</p></div>";
        LabelPopupHeader.Text = "BRITANICO";
        MessageBox.Height = height;
        MessageBox.Width = width;
        MessageBox.CssClass = messageType.ToString().ToLower();
        ModalPopupExtender1.Show();
        this.Visible = true;
    }
    public string Evento()
    {
        return hfMetodo.Value;
    }
  
    protected void btAceptar_Click(object sender, EventArgs e)
    {
        if (e != null)
        {
            
            OnConfirmClick(sender, e);

        }
    }
}

