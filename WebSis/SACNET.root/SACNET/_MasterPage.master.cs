using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oxinet.Tools;
using System.Configuration;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;

public partial class _MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Context.Request.Browser.Adapters.Clear();
        if(!IsPostBack)
        {
            if (Session["Usuario"] != null )
            {
                lblUsuarioLogin.Text = HelpUsuario().LoginUsuario;
                lblUsuarioRol.Text = HelpUsuario().CodigoRolNombre;
                lblServidor.Text = NameServidor();
                lblDataBase.Text = NameBaseDeDatos();
                if (HelpUsuariosSAC() != null)
                    lblCodigoLocal.Text = HelpUsuariosSAC().CodLocalSACNombre != null ? HelpUsuariosSAC().CodLocalSACNombre : "BIBLIOTECA CENTRAL";
                //var p = from item in HelpRol_Opcion()
                //        where item.FlagMenu == "S"
                //        && item.Tipo == "1"//URL
                //        select item;

                DataTable dt = HelpConvert<RolesOpciones>.ConvertList(HelpRol_Opcion());
                DataRow[] dr = dt.Select("FlagMenu ='S'" + 
                            " and Tipo=1");
                DataTable dt1 = dr.CopyToDataTable();

                //DataTable dt = HelpConvert<RolesOpciones>.ConvertList(p.ToList<RolesOpciones>());
                Util.CreateMenu(ref Menu1, dt1);

                Usuarios itemUsuarios = new Usuarios();
                itemUsuarios = HelpUsuario();
                //if (itemUsuarios.CodigoRol == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodRolUsuarioSAC))
                if (itemUsuarios.CodigoRol == "27")//ELVP:11-10-2011
                {
                    Image5.Visible = false;
                    Image6.Visible = false;
                    ltlServidor.Visible = false;
                    lblServidor.Visible = false;
                    lblDataBase.Visible = false;
                    ltlDataBase.Visible = false;
                }

                dt = null;
                dt1 = null;
                dr = null;
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
          
        }
        
    }

    public vwUsuariosSAC HelpUsuariosSAC()
    {
        if (Session["UsuarioSAC"] == null)
            Response.Redirect("Login.aspx", true);
        return (vwUsuariosSAC)Session["UsuarioSAC"];
    }
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

    protected void likCerrarSesion_Click(object sender, EventArgs e)
    {
        Session.Remove("Usuario");
        Session["Usuario"] = null ;
        Session.Remove("Rol_Opcion");
        Session["Rol_Opcion"] = null;
        Session.Remove("UsuarioSAC");
        Session["UsuarioSAC"] = null;
        Response.Redirect("Login.aspx");
     
    }

    public string NameServidor()
    {
        string conexionBRITANICO = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        string[] cnxDATOS_SAI = conexionBRITANICO.Split(';');
        string instanciaSQL =cnxDATOS_SAI[0].Substring(cnxDATOS_SAI[0].IndexOf('=') + 1, cnxDATOS_SAI[0].Length - cnxDATOS_SAI[0].IndexOf('=') - 1);
        return instanciaSQL;
    }

    public string NameBaseDeDatos()
    {
        string conexionBRITANICO = ConfigurationManager.ConnectionStrings["cnSacNET"].ConnectionString;
        string[] cnxDATOS_SAI = conexionBRITANICO.Split(';');
        return cnxDATOS_SAI[1].Substring(cnxDATOS_SAI[1].IndexOf('=') + 1, cnxDATOS_SAI[1].Length - cnxDATOS_SAI[1].IndexOf('=') - 1);
        
    }
}
