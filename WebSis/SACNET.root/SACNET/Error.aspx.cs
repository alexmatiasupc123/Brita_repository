using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Error : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //throw (new System.ArgumentNullException());

    }

    protected void Page_Error(object sender, EventArgs e)
    {
        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "Error Caught in Page_Error event" +
                "\tError in: " + Request.Url.ToString() +
                "\tError Message: " + objErr.Message.ToString();
        //TextBox1.Text = err.ToString();
        //Label1.Text = objErr.Message.ToString();
        //Server.ClearError();
    }

    protected void ButtonRegresar_Click(object sender, ImageClickEventArgs e)
    {
        
    }
}
