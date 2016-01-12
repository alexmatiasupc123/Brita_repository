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

public partial class ucTextBoxFecha : System.Web.UI.UserControl
{
    public string Text { get{return txtFecha.Text; } set{ txtFecha.Text = value;} }
    public bool Enabled 
    { 
        get 
        { 
            return txtFecha.Enabled;  
        }
        set 
        {
            ibtnFecha.Enabled = value;
            txtFecha.Enabled = value; 
           
        } 
    }
    public bool IsValid 
    { 
        get 
        {
            txtFecha_MaskedEditValidator.Validate();
            return txtFecha_MaskedEditValidator.IsValid; 
        } 
        private set 
        {
            txtFecha_MaskedEditValidator.IsValid=value;
        } 
    }

}
