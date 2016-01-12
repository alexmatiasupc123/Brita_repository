using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Tools;

public partial class Mantenimientos_SegListaRoles : System.Web.UI.Page
{
    Roles oRoles = null;
    RolesLogic oRolesLogic = null;
    ReturnValor oReturnValor = null;

    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!Page.IsPostBack)
        {
            txtSeekNombre.Focus();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                txtSeekNombre.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xNO");
                txtSeekDescripcion.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xDE");
            }
            CargarGrid(); //null, null, null
            lblTituloPagina.Text = "Lista de roles.";
            ActivarPermisosAlFormularioActual();
        }
        Page.Title = lblTituloPagina.Text;
    }
    
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/

    protected void gvRoles_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton btnEliminar = (ImageButton)e.Row.Cells[6].FindControl("btnEliminar");
            btnEliminar.Attributes.Add("onclick", "return confirm('¿ Esta seguro de eliminar este registro ?');");
            if (e.Row.Cells[0].Text.Trim().Length == 0 || e.Row.Cells[0].Text.Trim() == "&nbsp;")  // || e.Row.Cells[0].Text.Trim() == "0"
            {
                ((ImageButton)e.Row.Cells[4].FindControl("btnEditar")).Enabled = false;
                ((ImageButton)e.Row.Cells[5].FindControl("btnAsignarRoles")).Visible = false;
                ((ImageButton)e.Row.Cells[6].FindControl("btnEliminar")).Enabled = false;
                ((ImageButton)e.Row.Cells[7].FindControl("btnVer")).Enabled = false;
            }

            string IdRoles = gvRoles.DataKeys[e.Row.RowIndex]["CodigoRol"].ToString();
            if (IdRoles != "")
            {
                ImageButton btnComentario = (ImageButton)e.Row.Cells[5].FindControl("btnAsignarRoles");
                string Tiempo_url = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();
                btnComentario.Attributes.Add("onclick", "OpenPopup('SegAsignarOpcionesA_Roles.aspx?IdRoles=" + IdRoles + "&x=" + Tiempo_url + "',700,500);");
            }
        }
    }

    protected void gvRoles_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "Eliminar":
                EliminarRolDeUsuario(e.CommandArgument.ToString());
                break;
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + e.CommandArgument.ToString() + ParametrosDelFiltro());
                Response.Redirect("SegMantenimientoRoles.aspx?pm=" + querystringENCRYP);
                break;
            case "Asignar":
                CargarGrid();
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("id=" + e.CommandArgument.ToString() + "&Vid=1" + ParametrosDelFiltro());
                Response.Redirect("SegMantenimientoRoles.aspx?pm=" + querystringENCRYP);
                break;
            default:
                break;

        }
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs e, string parameter)
    {
        RolesLogic oRolesLogic = new RolesLogic();
        string[] valor = parameter.Split(new Char[] { '&' });
        if (parameter == "AsignaOpciones")
        {
            CargarGrid();
        }
        else
        {
            CargarGrid();
        }
    }

    #region --Funciones de Menu--->

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        String querystringENCRYP = HelpEncrypt.Encriptar(ParametrosDelFiltro());
        Response.Redirect("SegMantenimientoRoles.aspx?pm=" + querystringENCRYP, false);
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

    private void EliminarRolDeUsuario(string CodigoRol)
    {
        try
        {
            this.oRolesLogic = new RolesLogic();
            oReturnValor = oRolesLogic.Eliminar(CodigoRol);
            if (oReturnValor.Exitosa)
            {
                MessageBox1.ShowSuccess(oReturnValor.Message);
                CargarGrid(); //null, null, null
            }
            else
                MessageBox1.ShowInfo(oReturnValor.Message);
        }
        catch (Exception ex)
        {
            MessageBox1.ShowError(oReturnValor.Message);    
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
        oRoles = new  Roles();
        oRolesLogic = new  RolesLogic();
        List<Roles> lista = oRolesLogic.Listar(txtSeekNombre.Text, txtSeekDescripcion.Text);
        gvRoles.DataSource = lista;
        gvRoles.DataBind();
        HelpGridView.Caption(ref gvRoles,"Lista de roles",lista.Count.ToString());
    }

    #endregion

    private void ActivarPermisosAlFormularioActual()
    {
        Usuarios oUsuario = new Usuarios();
        List<RolesOpciones> lstRolesOpciones = new List<RolesOpciones>();
        oUsuario = (Usuarios)Session["Usuario"];
        if (oUsuario != null)
        {
            lstRolesOpciones = oUsuario.RolOpcionesMenus;
            var queryVer = from item in lstRolesOpciones
                        where item.CodigoOpcionEnlace == "SegListaRoles.aspx"
                        && (item.Tipo == "2")
                        select item;
            var queryEliminar = from item in lstRolesOpciones
                             where item.CodigoOpcionEnlace == "SegListaRoles.aspx"
                             && (item.Tipo == "3")
                             select item;
            var queryEditar = from item in lstRolesOpciones
                           where item.CodigoOpcionEnlace == "SegListaRoles.aspx"
                           && (item.Tipo == "4")
                           select item;
            var queryNuevo = from item in lstRolesOpciones
                              where item.CodigoOpcionEnlace == "SegListaRoles.aspx"
                              && (item.Tipo == "5")
                              select item;

            RolesOpciones itemRolesOpciones = new RolesOpciones();

            if(queryVer.Count()==0 && queryEliminar.Count()==0 && queryEditar.Count()==0 && queryNuevo.Count()==0)
                Response.Redirect("Login.aspx");

            if (queryVer.Count() > 0)
            {
                itemRolesOpciones = queryVer.ToList()[0];
                if (itemRolesOpciones != null)
                {
                    BotonesEdicionLista1.BotonImprimirEnabled = itemRolesOpciones.Flag_Ver;
                    BotonesEdicionLista1.BotonRegresarEnabled = true;
                    gvRoles.Columns[5].Visible = true;
                    Image1.Visible = true;
                    lblAsignar.Visible = true;
                    Image2.Visible = itemRolesOpciones.Flag_Ver;
                    Label6.Visible = itemRolesOpciones.Flag_Ver;
                    lblTituloPagina.Text = itemRolesOpciones.CodigoOpcionNombre;
                }
                //RolesOpciones itemRolesOpciones = new RolesOpciones();
                //itemRolesOpciones = query.ToList()[0];
                //if (itemRolesOpciones != null)
                //{
                //    BotonesEdicionLista1.BotonImprimirEnabled = itemRolesOpciones.Flag_Ver;
                //    BotonesEdicionLista1.BotonRegresarEnabled = true;
                //    BotonesEdicionLista1.BotonNuevoEnabled = itemRolesOpciones.Flag_Nuevo;                    
                //    gvRoles.Columns[4].Visible = itemRolesOpciones.Flag_Editar;
                //    gvRoles.Columns[5].Visible = true;
                //    gvRoles.Columns[6].Visible = itemRolesOpciones.Flag_Eliminar;
                //    gvRoles.Columns[7].Visible = itemRolesOpciones.Flag_Ver;
                //    Image1.Visible = true;
                //    lblAsignar.Visible = true;
                //    Image2.Visible = itemRolesOpciones.Flag_Ver;
                //    Image4.Visible = itemRolesOpciones.Flag_Editar;
                //    Image5.Visible = itemRolesOpciones.Flag_Eliminar;
                //    Label6.Visible = itemRolesOpciones.Flag_Ver;
                //    Label3.Visible = itemRolesOpciones.Flag_Editar;
                //    Label4.Visible = itemRolesOpciones.Flag_Eliminar;
                //    lblTituloPagina.Text = itemRolesOpciones.CodigoOpcionNombre;
                //}
            }
            if (queryEliminar.Count() > 0)
            {
                itemRolesOpciones = queryEliminar.ToList()[0];
                if (itemRolesOpciones != null)
                {
                    gvRoles.Columns[6].Visible = itemRolesOpciones.Flag_Eliminar;
                    Image5.Visible = itemRolesOpciones.Flag_Eliminar;
                    Label4.Visible = itemRolesOpciones.Flag_Eliminar;
                }
            }
            if (queryEditar.Count() > 0)
            {
                itemRolesOpciones = queryEditar.ToList()[0];
                if (itemRolesOpciones != null)
                {
                    gvRoles.Columns[4].Visible = itemRolesOpciones.Flag_Editar;
                    Image4.Visible = itemRolesOpciones.Flag_Editar;
                    Label3.Visible = itemRolesOpciones.Flag_Editar;
                }
            }
            if (queryNuevo.Count() > 0)
            {
                itemRolesOpciones = queryNuevo.ToList()[0];
                if (itemRolesOpciones != null)
                {
                    BotonesEdicionLista1.BotonNuevoEnabled = itemRolesOpciones.Flag_Nuevo;
                }
            }



        }
        else
            Response.Redirect("Login.aspx");
    }

    protected void gvRoles_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvRoles.PageIndex = e.NewPageIndex;
        CargarGrid();
    }
    protected void txtSeekNombre_TextChanged(object sender, EventArgs e)
    {
        CargarGrid();
    }
}
