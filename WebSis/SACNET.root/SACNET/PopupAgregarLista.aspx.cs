using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;
public partial class PopupAgregarLista : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if (!IsPostBack)
        {
            Usuarios oUsuario = new Usuarios();
            List<RolesOpciones> lstRolesOpciones = new List<RolesOpciones>();
            oUsuario = (Usuarios)Session["Usuario"];
            if (oUsuario != null)
            {
                CargarConfiguraciones();
            }
            else
                Response.Redirect("Login.aspx");
        }
    }
    protected void ibtnAceptar_Click(object sender, ImageClickEventArgs e)
    {

    }
    private void CargarConfiguraciones()
    {
        this.ibtnAceptar.Attributes.Add("OnClick", "CerrarClose()");
    }
}
