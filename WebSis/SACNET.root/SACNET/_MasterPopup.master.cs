using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessEntities;
public partial class _MasterPopup : System.Web.UI.MasterPage
{
    public Usuarios HelpUsuario()
    {
        if (Session["Usuario"] == null)
            Response.Redirect("Login.aspx", true);
        return (Usuarios)Session["Usuario"];
    }
    public List<RolesOpciones> HelpRol_Opcion()
    {
        return (List<RolesOpciones>)HelpUsuario().RolOpcionesMenus;
    }
    public RolesOpciones HelpOpcion_Permiso(string pOpcion)
    {

        RolesOpciones oRol_Opcion = new RolesOpciones();
        foreach (var item in HelpRol_Opcion())
        {
            if (pOpcion == item.CodigoOpcionEnlace)
            {
                oRol_Opcion = item;
                break;
            }
        }
        return oRol_Opcion;
    }
    //ELVP:11-10-2011***************
    public List<RolesOpciones> HelpOpcion_Permiso_Lista(string pOpcion)
    {

        List<RolesOpciones> olstRol_Opcion = new List<RolesOpciones>();
        foreach (var item in HelpRol_Opcion())
        {
            if (pOpcion == item.CodigoOpcionEnlace)
            {
                olstRol_Opcion.Add(item);
            }
        }
        return olstRol_Opcion;
    }
    //******************************
}
