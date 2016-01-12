using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Oxinet.Tools;
using System.Configuration;
public partial class ListaArticulo : System.Web.UI.Page
{
    
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {

        this.InicializarEventos();
        if (!Page.IsPostBack)
        {
            CargarCombos();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));

                ddlTipoArticulo.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xTA");
                ddlSAC.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xCS");
                txtTitulo.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xTi");
                txtCodItem.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xCi");
                ddlAutor.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xAu");
                ddlTema.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xTm");
                ddlEstadoItem.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xTe");
                txtISBN.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xTB");
                txtISSN.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xTS");

            }
            BuscarFiltro();

        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }
   
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonNuevoClick += new EventHandler(BotonesEdicionLista1_OnBotonNuevoClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
    }

    void BotonesEdicionLista1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    void BotonesEdicionLista1_OnBotonBuscarClick(object sender, EventArgs e)
    {
        this.BuscarFiltro();
    }

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Session["Ejemplares"] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItems)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.ActoresDeObras)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.TiposDeTemas)] = null;
        Session[HelpMaestros.CodigoTabla(HelpMaestros.TablasMaestras.AutoresDeItemsInstitucionales)] = null;
        Response.Redirect("MantArticulo.aspx?pm=" + HelpEncrypt.Encriptar(ParametrosDelFiltro()), false);
    }
    protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItems.PageIndex = e.NewPageIndex;
        BuscarFiltro();
    }
    protected void gvItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String querystringENCRYP = string.Empty;

        string[] sArgums = e.CommandArgument.ToString().Split('&');
        string CodSac = ddlSAC.SelectedIndex == 0 ? string.Empty : ddlSAC.SelectedItem.Value;
        switch (e.CommandName)
        {
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("&iId=" + sArgums[0].ToString() + "&SAC=" + CodSac + ParametrosDelFiltro());
                
                Response.Redirect("MantArticulo.aspx?pm=" + querystringENCRYP,false);
                break;
            case "Eliminar":
                string[] CodItem = e.CommandArgument.ToString().Split('&');
                EliminarItem(CodItem[0]);
                this.BuscarFiltro();
                break;
            case "Ver":
                querystringENCRYP = HelpEncrypt.Encriptar("&iId=" + e.CommandArgument.ToString() + "&SAC=" + CodSac + "&EV=" + HelpEvento.Ver.ToString() + ParametrosDelFiltro());
                Response.Redirect("MantArticulo.aspx?pm=" + querystringENCRYP, false);
                break;
            default:
                break;
        }
    }
    protected void ddlTipoArticulo_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlTipoArticulo.SelectedValue == hfCodArguAudioVisual.Value)
        {
            lblISBN.Visible = true;
            txtISBN.Visible = true;
            lblISSN.Visible = false;
            txtISSN.Visible = false;
            lblAutor.Visible = false;
            ddlAutor.Visible = false;
        }
        //else if (ddlTipoArticulo.SelectedValue == hfCodArguLibro.Value)
        else if (ddlTipoArticulo.SelectedValue == hfCodArguLibroReader.Value ||//ELVP: 19-09-2011
            ddlTipoArticulo.SelectedValue == hfCodArguLibroGrammar.Value ||
            ddlTipoArticulo.SelectedValue == hfCodArguLibroPaper.Value)
        {
            lblISBN.Visible = true;
            txtISBN.Visible = true;
            lblISSN.Visible = false;
            txtISSN.Visible = false;
            lblAutor.Visible = true;
            ddlAutor.Visible = true;
        }
        else if (ddlTipoArticulo.SelectedValue == hfCodArguRecursoElectronico.Value)
        {
            lblISBN.Visible = false;
            txtISBN.Visible = false;
            lblISSN.Visible = false;
            txtISSN.Visible = false;
            lblAutor.Visible = false;
            ddlAutor.Visible = false;
        }
        else if (ddlTipoArticulo.SelectedValue == hfCodArguRevista.Value)
        {
            lblISBN.Visible = false;
            txtISBN.Visible = false;
            lblISSN.Visible = true;
            txtISSN.Visible = true;
            lblAutor.Visible = true;
            ddlAutor.Visible = true;
        }
        else if (ddlTipoArticulo.SelectedIndex==0)
        {
            lblISBN.Visible = true;
            txtISBN.Visible = true;
            lblISSN.Visible = true;
            txtISSN.Visible = true;
            lblAutor.Visible = true;
            ddlAutor.Visible = true;
        }
       
    }
    
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;
        sParameters = "&xTA=" + ddlTipoArticulo.SelectedValue.ToString();
        sParameters = sParameters + "&xCS=" + ddlSAC.SelectedValue.ToString();
        sParameters = sParameters + "&xTi=" + txtTitulo.Text.Trim();
        sParameters = sParameters + "&xCi=" + txtCodItem.Text.Trim();
        sParameters = sParameters + "&xAu=" + ddlAutor.SelectedValue.ToString();
        sParameters = sParameters + "&xTm=" + ddlTema.SelectedValue.ToString();
        sParameters = sParameters + "&xTe=" + ddlEstadoItem.SelectedValue.ToString();
        sParameters = sParameters + "&xTB=" + txtISBN.Text.Trim();
        sParameters = sParameters + "&xTS=" + txtISSN.Text.Trim();
        return sParameters;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaArticulo.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaArticulo.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)  
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drVer = dt.Select("Tipo=2");
            DataTable dtVer = drVer.Length>0? drVer.CopyToDataTable(): new DataTable();

            DataRow[] drEliminar = dt.Select("Tipo=3");
            DataTable dtEliminar = drEliminar.Length>0? drEliminar.CopyToDataTable(): new DataTable();

            DataRow[] drEditar = dt.Select("Tipo=4");
            DataTable dtEditar = drEditar.Length>0? drEditar.CopyToDataTable(): new DataTable();

            DataRow[] drNuevo = dt.Select("Tipo=5");
            DataTable dtNuevo = drNuevo.Length>0? drNuevo.CopyToDataTable(): new DataTable();

            if (dtVer.Rows.Count > 0)
            {
                gvItems.Columns[6].Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
                Ley_ImgVer.Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
                Ley_lblVer.Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
                lblTituloPagina.Text = dtVer.Rows[0]["CodigoOpcionNombre"].ToString();
            }
            if (dtEliminar.Rows.Count > 0)
            {
                gvItems.Columns[8].Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
                Ley_ImgEliminar.Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
                Ley_lblEliminar.Visible = Convert.ToBoolean(dtEliminar.Rows[0]["Flag_Eliminar"]);
                lblTituloPagina.Text = dtEliminar.Rows[0]["CodigoOpcionNombre"].ToString();
            }
            if (dtEditar.Rows.Count > 0)
            {
                gvItems.Columns[7].Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                Ley_ImgEditar.Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                Ley_lblEditar.Visible = Convert.ToBoolean(dtEditar.Rows[0]["Flag_Editar"]);
                lblTituloPagina.Text = dtEditar.Rows[0]["CodigoOpcionNombre"].ToString();
            }
            if (dtNuevo.Rows.Count > 0)
            {
                BotonesEdicionLista1.BotonNuevo = Convert.ToBoolean(dtNuevo.Rows[0]["Flag_Nuevo"]);
                lblTituloPagina.Text = dtNuevo.Rows[0]["CodigoOpcionNombre"].ToString();
            }
            BotonesEdicionLista1.LoadComplete();


            //gvItems.Columns[6].Visible = oRolesOpciones.Flag_Ver;
            //gvItems.Columns[7].Visible = oRolesOpciones.Flag_Editar;
            //gvItems.Columns[8].Visible = oRolesOpciones.Flag_Eliminar;
            //Ley_ImgEditar.Visible = oRolesOpciones.Flag_Editar;
            //Ley_lblEditar.Visible = oRolesOpciones.Flag_Editar;
            //Ley_ImgVer.Visible = oRolesOpciones.Flag_Ver;
            //Ley_lblVer.Visible = oRolesOpciones.Flag_Ver;
            //Ley_ImgEliminar.Visible = oRolesOpciones.Flag_Eliminar;
            //Ley_lblEliminar.Visible = oRolesOpciones.Flag_Eliminar;
            //BotonesEdicionLista1.BotonNuevo = oRolesOpciones.Flag_Nuevo;
            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //BotonesEdicionLista1.LoadComplete();

            dt = null;
            dtVer = null;
            dtEliminar = null;
            dtEditar = null;
            dtNuevo = null;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
    private void BuscarFiltro()
    {
        string CodTipoItem = ddlTipoArticulo.SelectedIndex == 0 ? "" : ddlTipoArticulo.SelectedItem.Value;
        string CodAutor = ddlAutor.SelectedIndex == 0 ? "" : ddlAutor.SelectedItem.Value;
        string CodSac = ddlSAC.SelectedIndex == 0 ? "" : ddlSAC.SelectedItem.Value;
        string CodTema = ddlTema.SelectedIndex == 0 ? "" : ddlTema.SelectedItem.Value;
        string CodEstadoItem = ddlEstadoItem.SelectedIndex == 0 ? "" : ddlEstadoItem.SelectedItem.Value;
        ListarItems(txtCodItem.Text, CodTipoItem, CodSac, txtTitulo.Text, CodAutor, txtISBN.Text, txtISSN.Text, CodTema, CodEstadoItem);
    }
    private void ListarItems(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem)
    {
        ItemLogic oItemLogic = new ItemLogic();
        List<Item> lista = oItemLogic.Listar(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, string.Empty);
        if (string.IsNullOrEmpty(pCodSac.Trim()) == false)
            lista = lista.Where(x => x.TotalEjemplares > 0).ToList<Item>();
        gvItems.DataSource = lista; 
        gvItems.DataBind();
        HelpGridView.Caption(ref gvItems,"Lista de ítems",lista.Count.ToString());
       

    }
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlTipoArticulo, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlEstadoItem, HelpMaestros.TablasMaestras.EstadosDeLosItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlAutor, HelpMaestros.TablasMaestras.AutoresDeItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlTema, HelpMaestros.TablasMaestras.TiposDeTemas, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        ddlSAC.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSAC.DataValueField = "CodLocalSAC";
        ddlSAC.DataTextField = "NombreLocal";
        ddlSAC.DataBind();
        ddlSAC.Items.Insert(0,(new ListItem("-- Todos --", "")));
        //***ELVP: 19-09-2011**************
        hfCodArguLibroReader.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader);
        hfCodArguLibroGrammar.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar);
        hfCodArguLibroPaper.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper);
        //hfCodArguLibro.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro);
        //*********************************
        hfCodArguRevista.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista);
        hfCodArguAudioVisual.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual);
        hfCodArguRecursoElectronico.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico);
    }
    private void EliminarItem(string pCodItem)
    {
        ItemLogic oItemLogic = new ItemLogic();
        ReturnValor oReturnValor = new ReturnValor();

        if (oItemLogic.BuscarItem_ExisteMovimiento(pCodItem))
        {
            string pEstadoAActualizar = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDescartadoItem);
            oReturnValor = oItemLogic.ActualizarEstadoItem(pCodItem, pEstadoAActualizar, Master.HelpUsuario().LoginUsuario);
            MessageBox1.ShowSuccess(oReturnValor.Message);

        }
        else
        {
            oReturnValor = oItemLogic.Eliminar(pCodItem);
            MessageBox1.ShowSuccess(oReturnValor.Message);
        }
    }
    #endregion  
    
}
