using System;
using System.Collections.Generic;
using System.Text;
using System.Web.SessionState;

namespace PaginaBase
{
    public class BaseBase : System.Web.UI.Page, IRequiresSessionState 
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Context.Session == null)
            {
                Response.Redirect("Default.aspx");
            }

        }

        public BaseBase()
        {
            this.EnableViewState = true;
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}
