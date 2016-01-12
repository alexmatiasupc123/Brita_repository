using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Mantenimientos_SegListaOpciones : System.Web.UI.Page
{
    Opciones oOpciones = null;
    OpcionesLogic oOpcionesLogic = null;
    ReturnValor oReturnValor = null;

    #region "/--- Eventos de la Pagina  ---/"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                txtSeekNombre.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xNO");
                txtSeekDescripcion.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xDE");
            }
            CargarGrid();
        }
        ActivarPermisosAlFormularioActual();
        Page.Title = lblTituloPagina.Text;
    }
   
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
   
    protected void gvOpciones_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[0].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  // || e.Row.Cells[0].Text.Trim() == "0"
            {

                ((ImageButton)e.Row.Cells[5].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = false;
                ((ImageButton)e.Row.Cells[7].FindControl("btnVer")).Enabled = false;
            }
        }
    }

    protected void gvOpciones_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "Eliminar":
                EliminarOpcionesDelSistema(e.CommandArgument.ToString());
                break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + e.CommandArgument.ToString() + ParametrosDelFiltro());
                Response.Redirect("SegMantenimientoOpciones.aspx?pm=" + querystringENCRYP);
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + e.CommandArgument.ToString()+ "&Vid=1" + ParametrosDelFiltro());
                Response.Redirect("SegMantenimientoOpciones.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;
        }
    }
   
    protected void gvOpciones_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvOpciones.PageIndex = e.NewPageIndex;
        CargarGrid();

    }
    
    #region --Funciones de Menu--->

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        String querystringENCRYP = HelpEncrypt.Encriptar(ParametrosDelFiltro());
        Response.Redirect("SegMantenimientoOpciones.aspx?pm=" + querystringENCRYP);
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

    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;

        sParameters = "&xNO=" + txtSeekNombre.Text.Trim();
        sParameters = sParameters + "&xDE=" + txtSeekDescripcion.Text.Trim();
        return sParameters;
    }

    private void EliminarOpcionesDelSistema(string CodigoOpcion)
    {
        try
        {
            this.oOpcionesLogic = new OpcionesLogic();
            oReturnValor = oOpcionesLogic.Eliminar(CodigoOpcion);
            if (oReturnValor.Exitosa)
            {
                MessageBox1.ShowSuccess(oReturnValor.Message);
                CargarGrid();
            }
            else
                MessageBox1.ShowInfo(oReturnValor.Message); 
        }
        catch (Exception ex)
        {
            MessageBox1.ShowError(ex.Message);            
        }

    }

    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonNuevoClick += new EventHandler(BotonesEdicionLista1_OnBotonNuevoClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
    }

    private void CargarGrid()
    {
     
        oOpcionesLogic = new OpcionesLogic();
        List<Opciones> lista = oOpcionesLogic.Listar(txtSeekNombre.Text, txtSeekDescripcion.Text);
        gvOpciones.DataSource = lista; 
        gvOpciones.DataBind();
        HelpGridView.Caption(ref gvOpciones,"Lista de Opciones",lista.Count.ToString());
    }
   
    /// <summary>
    /// Método que pemite darle seguridad al Formulario a traves de los roles del usuario
    /// </summary>
    private void ActivarPermisosAlFormularioActual()
    {
        Usuarios oUsuario = new Usuarios();
        List<RolesOpciones> lstRolesOpciones = new List<RolesOpciones>();
        oUsuario = (Usuarios)Session["Usuario"];
        if (oUsuario != null)
        {
            lstRolesOpciones = oUsuario.RolOpcionesMenus;
            var query = from item in lstRolesOpciones
                        where item.CodigoOpcionEnlace == "SegListaOpciones.aspx"
                        select item;
            if (query.Count() > 0)
            {
                RolesOpciones itemRolesOpciones = new RolesOpciones();
                itemRolesOpciones = query.ToList()[0];
                if (itemRolesOpciones != null)
                {
                    BotonesEdicionLista1.BotonImprimirEnabled = itemRolesOpciones.Flag_Ver;
                    BotonesEdicionLista1.BotonRegresarEnabled = true;
                    BotonesEdicionLista1.BotonNuevo = false;
                    BotonesEdicionLista1.BotonBuscarEnabled = itemRolesOpciones.Flag_Ver;
                    gvOpciones.Columns[5].Visible = itemRolesOpciones.Flag_Editar;
                    gvOpciones.Columns[6].Visible = itemRolesOpciones.Flag_Eliminar;
                    gvOpciones.Columns[7].Visible = itemRolesOpciones.Flag_Ver;
                    Image1.Visible = itemRolesOpciones.Flag_Ver;
                    Label6.Visible = itemRolesOpciones.Flag_Ver;
                    Image4.Visible = itemRolesOpciones.Flag_Editar;
                    Label3.Visible = itemRolesOpciones.Flag_Editar;
                    Image5.Visible = itemRolesOpciones.Flag_Eliminar;
                    Label4.Visible = itemRolesOpciones.Flag_Eliminar;
                    lblTituloPagina.Text = itemRolesOpciones.CodigoOpcionNombre;
                }
            }
            else
                Response.Redirect("Login.aspx");
        }
        else
            Response.Redirect("Login.aspx");
    }   
    
    #endregion



    
}
