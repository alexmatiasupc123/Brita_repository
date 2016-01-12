using System;
using System.Collections.Generic;
using System.Text;

namespace PaginaBase
{
    public class Base : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Context.Session == null)
            {
                Response.Redirect("Default.aspx");
            }

        }

        public Base()
        {
            this.EnableViewState = true;
            if (!Context.User.Identity.IsAuthenticated)
            {
                Response.Redirect("Default.aspx");
            }
            else Session["UserName"] = Context.User.Identity.Name;
        }
    }
}
