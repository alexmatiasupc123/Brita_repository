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
using Britanico.Web.BusinessEntities;
using Britanico.BusinessLogic.NoTransaccionales;
using System.Collections.Generic;

public partial class _Default : System.Web.UI.Page
{
    BLUsuarioNTAD oUsuario = new BLUsuarioNTAD();
    protected void Page_Load(object sender, EventArgs e)
    {
//        lblFechaActual.Text = DateTime.Now.ToString("dd/MM/yyyy");
        string estado = Request.QueryString["idstate"];
        if (estado != null)
        {

            if (estado == "0")
                lblState.Text = "** Ud no esta autorizado para acceder a este servicio";
            if (estado == "1")
                lblState.Text = "** Ud ha cerrado sesion!!";
        }
    }
    protected void btnIngresar_Click(object sender, ImageClickEventArgs e)
    {
        BEUsuario rUsuario = oUsuario.ValidaAcceso(txtUsuario.Text, txtPassword.Text);

        if (rUsuario != null)
        {

            string uNombre = rUsuario.usua_nomb + " " + rUsuario.usua_apat + " " + rUsuario.usua_amat;
            Session["ulogin"] = txtUsuario.Text;
            Session["uNombre"] = uNombre;
            Session["uCodigo"] = rUsuario.usua_codi.ToString();
            Response.Redirect("Inicio.aspx");
        }
        else
        {
            Response.Redirect("Default.aspx?idstate=0");
        }
    }
}
