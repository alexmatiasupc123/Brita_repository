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

using System.Reflection;
using Britanico.SacNet.BusinessEntities;

public partial class Comun_Controles_ucAuditoria : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    System.Net.Dns.BeginGetHostByName(Request.UserHostAddress, new AsyncCallback(GetHostNameCallBack), Request.UserHostAddress);

        //}

    }

    public void CargarSeguridadInicio()
    {
        Usuarios oUsuarios = (Usuarios)Session["Usuario"];
        if (oUsuarios != null)
        {
            TextBoxSSIUsuario_Creacion.Text = oUsuarios.LoginUsuario;
            TextBoxSSIUsuario_Modificacion.Text = oUsuarios.LoginUsuario;
            TextBoxSSIFechaHora_Creacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm");
            TextBoxSSIFechaHora_Modificacion.Text = DateTime.Now.ToShortDateString() + " " + DateTime.Now.ToString("HH:mm");
            TextBoxSSIHost.Text = Context.Request.UserHostName;
            //string IP = Request.ServerVariables["HTTP_X_FORWARDED_FOR"]; // se chequea si hay un proxy
            //if(IP =="" )
            //{
            //     IP = Request.ServerVariables["REMOTE_ADDR"];
            //}// si no hay proxy se toma la IP original

            //TextBox1.Text = IP;

            //TextBox2.Text = this.Context.Request.ServerVariables["REMOTE_HOST"];
            //TextBox4.Text = Context.Request.UserHostAddress;
        }
    }



    //public void GetHostNameCallBack(IAsyncResult asyncResult)
    //{
    //    string userHostAddress = (string)asyncResult.AsyncState;
    //    System.Net.IPHostEntry hostEntry = System.Net.Dns.EndGetHostByName(asyncResult);
    //    TextBox3.Text = hostEntry.HostName;
    //    // tenemos el nombre del equipo cliente en hostEntry.HostName
    //}


    public void CargarSeguridad(string SSIUsuario_Creacion, string SSIUsuario_Modificacion, DateTime SSIFechaHora_Creacion, DateTime SSIFechaHora_Modificacion, string SSIHost)
    {
        TextBoxSSIUsuario_Creacion.Text = SSIUsuario_Creacion;
        TextBoxSSIUsuario_Modificacion.Text = SSIUsuario_Modificacion;
        TextBoxSSIFechaHora_Creacion.Text = SSIFechaHora_Creacion.ToShortDateString() + " " + SSIFechaHora_Creacion.ToString("HH:mm");
        TextBoxSSIFechaHora_Modificacion.Text = SSIFechaHora_Modificacion.ToShortDateString() + " " + SSIFechaHora_Modificacion.ToString("HH:mm");
        TextBoxSSIHost.Text = SSIHost;
        //TextBox1.Text = Context.Request.UserHostName;
        //TextBox2.Text = this.Context.Request.ServerVariables["REMOTE_HOST"];
        //TextBox4.Text = Context.Request.UserHostAddress;
    }
}
