using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Mantenimientos_SegListaUsuarios : System.Web.UI.Page
{
    Usuarios oUsuarios = null;
    UsuariosLogic oUsuariosLogic = null;
    ReturnValor oReturnValor = null;

    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        EstadoBoton(true);
        if (!Page.IsPostBack)
        {
          
            CargarGrid(); 
            
        }
        Seguridad();
        
    }
  
    #endregion

    #region "/--- Eventos de los Controles ---/"
    /**************************************************************************/
   
   
    
    protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (e.Row.Cells[0].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  // || e.Row.Cells[0].Text.Trim() == "0"
            {

                ((ImageButton)e.Row.Cells[2].FindControl("btnAsignaRol")).Enabled = false;
            }

            string IdUsuario = gvUsuarios.DataKeys[e.Row.RowIndex]["LoginUsuario"].ToString();

            if (IdUsuario != "")
            {
                ImageButton btnAsignaRoles = (ImageButton)e.Row.Cells[2].FindControl("btnAsignaRol");
                string Tiempo_url = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                btnAsignaRoles.Attributes.Add("onclick", "OpenPopup('SegAsignarRoles_AUsuarios.aspx?IdUsuario=" + Server.UrlEncode(IdUsuario) + "&x=" + Tiempo_url + "',700,500);");
            }
        }
    }

    protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "Editar":
                Response.Redirect("SegMantenimientoUsuarios.aspx?id=" + e.CommandArgument.ToString());
                break;
            case "Asignar":
                CargarGrid();
                break;
            case "Ver":
                Response.Redirect("SegMantenimientoUsuarios.aspx?id=" + e.CommandArgument.ToString() + "&Vid=1");
                break;
            default:
                break;

        }
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs e, string parameter)
    {
        string[] valor = parameter.Split(new Char[] { '&' });
        CargarGrid();
    }

    #region --Funciones de Menu--->

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Response.Redirect("SegMantenimientoUsuarios.aspx");
    }

    void BotonesEdicionLista1_OnBotonBuscarClick(object sender, EventArgs e)
    {
        CargarGrid();
    }
    void BotonesEdicionLista1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
    #endregion

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonNuevoClick += new EventHandler(BotonesEdicionLista1_OnBotonNuevoClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
    }

    private void EstadoBoton(bool estado)
    {
        BotonesEdicionLista1.BotonBuscarEnabled = estado;
        BotonesEdicionLista1.BotonExportarEnabled = false;
        BotonesEdicionLista1.BotonImprimirEnabled = false;
        BotonesEdicionLista1.BotonNuevo = false;
        BotonesEdicionLista1.BotonRegresarEnabled = estado;
    }

    private void CargarGrid() //string nombres, string origen, string pais
    {
        oUsuarios = new  Usuarios();
        oUsuariosLogic = new  UsuariosLogic();

        List<Usuarios> lista = oUsuariosLogic.Listar(txtSeekNombres.Text, txtSeekApellidos.Text, txtSeekLogin.Text);

        gvUsuarios.DataSource = lista;
        gvUsuarios.DataBind();

        HelpGridView.Caption(ref gvUsuarios, "Lista de usuarios", lista.Count.ToString()); 
    }

    public string PintarEstado(string pCodigoTabla, bool pEstado)
    {
        string estado = string.Empty;

        if (pCodigoTabla.Length != 0)
        {
            if (pEstado)
            {
                estado = "ACTIVO";
            }
            else
            {
                estado = "INACTIVO";
            }
        }

        return estado;
    }


    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("SegListaUsuarios.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            BotonesEdicionLista1.BotonImprimirEnabled = false;
            BotonesEdicionLista1.BotonRegresarEnabled = true;
            BotonesEdicionLista1.BotonBuscarEnabled = oRolesOpciones.Flag_Ver;
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }



    }
    #endregion


    protected void gvUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvUsuarios.PageIndex = e.NewPageIndex;
        CargarGrid();
    }
}
