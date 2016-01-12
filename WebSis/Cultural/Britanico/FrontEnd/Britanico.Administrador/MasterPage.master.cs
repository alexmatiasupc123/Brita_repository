using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

            
        if (Session["ulogin"] != null)
            {
                lblLogin.Text = Session["ulogin"].ToString();
                lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");

            }
            else
            {
                string strPath = System.Configuration.ConfigurationSettings.AppSettings["urlRedirect"];
                Response.Redirect(strPath);
            }

    }
}
