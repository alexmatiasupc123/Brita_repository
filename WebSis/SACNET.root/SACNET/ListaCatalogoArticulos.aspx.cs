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
public partial class ListaCatalogoArticulos : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        
        EstadoBoton();
        this.InicializarEventos();
        if (!Page.IsPostBack)
        {
            
            this.CargarCombos();
           
        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
        Seguridad();
        Page.Title = lblTituloPagina.Text;
    }

    #endregion
    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    protected void rbTipoBusquedas_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (rbTipoBusquedas.Items[0].Selected)
        {            
            pnFiltroSimple.Visible = true;
            pnFiltroAvanzado.Visible = false;
           // BuscarFiltroSimple();
        }
        else
        {
            pnFiltroAvanzado.Visible = true;
            pnFiltroSimple.Visible = false;
            //BuscarFiltroAvanzado();
        }
        gvCatalogoItems.DataSource = null;
        gvCatalogoItems.DataBind();

    }
    protected void gvCatalogoItems_RowCommand(object sender, GridViewCommandEventArgs e)
    {   
    }
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
        if (rbTipoBusquedas.Items[0].Selected)
        {
            if (ddlSac_BSimple.SelectedIndex == 0)
            {
                if (txtBusqueda.Text.Length < 3)
                {
                    MessageBox1.ShowInfo("Para realizar la búsqueda debe ingresar mínimo 3 caracteres.");
                    txtBusqueda.Focus();
                    return;
                }
            }            
            BuscarFiltroSimple();
        }            
        else
            BuscarFiltroAvanzado();
    }

    void BotonesEdicionLista1_OnBotonNuevoClick(object sender, EventArgs e)
    {
        Response.Redirect("MantArticulo.aspx");
    }
    protected void gvCatalogoItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvCatalogoItems.PageIndex = e.NewPageIndex;
        if (rbTipoBusquedas.Items[0].Selected)
            BuscarFiltroSimple();
        else
            BuscarFiltroAvanzado();
    }
    protected void gvCatalogoItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            ImageButton ibtnVer = (ImageButton)e.Row.Cells[5].FindControl("btnVer");
            Item oItem = (Item)e.Row.DataItem;
            string CodSac = string.Empty;
            string CodItem = oItem.sCodItem;
            if (rbTipoBusquedas.Items[0].Selected)
                CodSac = ddlSac_BSimple.SelectedIndex == 0 ? string.Empty : ddlSac_BSimple.SelectedItem.Value;
            else
                CodSac = ddlSAC.SelectedIndex == 0 ? string.Empty : ddlSAC.SelectedItem.Value;            
            string querystringENCRYP = string.Empty;
            querystringENCRYP = HelpEncrypt.Encriptar("&pCodItem=" + CodItem + "&pCodSac=" + CodSac);
            ibtnVer.Attributes.Add("onclick", "OpenPopup('PopupDetalleCatalogoArticulo.aspx?pm=" + querystringENCRYP + "',870,800)");
        }
    }
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaCatalogoArticulos.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaCatalogoArticulos.aspx");//ELVP:11-10-2011
        RolesOpciones oRolesOpciones = new RolesOpciones();

        if (lstRolesOpciones != null)  
        {
            DataTable dt = HelpConvert<RolesOpciones>.ConvertList(lstRolesOpciones);
            DataRow[] drVer = dt.Select("Tipo=2");
            DataTable dtVer = drVer.Length>0? drVer.CopyToDataTable(): new DataTable();

            if (dtVer.Rows.Count > 0)
            {
                lblTituloPagina.Text = dtVer.Rows[0]["CodigoOpcionNombre"].ToString();
                gvCatalogoItems.Columns[5].Visible = Convert.ToBoolean(dtVer.Rows[0]["Flag_Ver"]);
            }
           
            //lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            //gvCatalogoItems.Columns[5].Visible = oRolesOpciones.Flag_Ver;
            dt = null;
            dtVer = null;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }
   
    private void EstadoBoton()
    {
        BotonesEdicionLista1.BotonExportarEnabled = false;
        BotonesEdicionLista1.BotonImprimirEnabled = false;
        BotonesEdicionLista1.BotonRegresarEnabled = true;
        BotonesEdicionLista1.BotonNuevo = false;
        BotonesEdicionLista1.BotonBuscarEnabled = true;
        
    }
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlTipoArticulo, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        //HelpMaestros.CargarListadoGenerico(ref ddlEstadoItem, HelpMaestros.TablasMaestras.EstadosDeLosItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlAutor, HelpMaestros.TablasMaestras.AutoresDeItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlTema, HelpMaestros.TablasMaestras.TiposDeTemas, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        ddlSAC.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSAC.DataValueField = "CodLocalSAC";
        ddlSAC.DataTextField = "NombreLocal";
        ddlSAC.DataBind();
        ddlSAC.Items.Insert(0, (new ListItem("-- Todos --", "")));

        ddlSac_BSimple.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSac_BSimple.DataValueField = "CodLocalSAC";
        ddlSac_BSimple.DataTextField = "NombreLocal";
        ddlSac_BSimple.DataBind();
        ddlSac_BSimple.Items.Insert(0, (new ListItem("-- Todos --", "")));

        //***ELVP:19-09-2011**********************
        hfCodArguLibroReader.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader);
        hfCodArguLibroGrammar.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar);
        hfCodArguLibroPaper.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper);
        //hfCodArguLibro.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro);
        //****************************************
        hfCodArguRevista.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista);
        hfCodArguAudioVisual.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual);
        hfCodArguRecursoElectronico.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico);

        gvCatalogoItems.DataSource = null;
        gvCatalogoItems.DataBind();
    }
    private void BuscarFiltroAvanzado()
    {
        string CodTipoItem = ddlTipoArticulo.SelectedIndex == 0 ? "" : ddlTipoArticulo.SelectedItem.Value;
        string CodAutor = ddlAutor.SelectedIndex == 0 ? "" : ddlAutor.SelectedItem.Value;
        string CodSac = ddlSAC.SelectedIndex == 0 ? "" : ddlSAC.SelectedItem.Value;
        string CodTema = ddlTema.SelectedIndex == 0 ? "" : ddlTema.SelectedItem.Value;
        //string CodEstadoItem = ddlEstadoItem.SelectedIndex == 0 ? "" : ddlEstadoItem.SelectedItem.Value;
        string CodEstadoItem = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnStockItem);
        ListarItems(txtCodItem.Text, CodTipoItem, CodSac, txtTitulo.Text, CodAutor, txtISBN.Text, txtISSN.Text, CodTema, CodEstadoItem);
    }
    private void BuscarFiltroSimple()
    {
        string TextBusqueda = txtBusqueda.Text;
        string CodSac = ddlSac_BSimple.SelectedIndex == 0 ? "" : ddlSac_BSimple.SelectedItem.Value;
        ListarItemsSimple(TextBusqueda, CodSac);
    }
    private void ListarItems(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem)
    {
        ItemLogic oItemLogic = new ItemLogic();
        string CodArguEstadoDisponibleEjemplar = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
        List<Item> ListaItemsAvanzada = new List<Item>();
        ListaItemsAvanzada = oItemLogic.ListarCatalogo_Avanzada(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem, CodArguEstadoDisponibleEjemplar);
        gvCatalogoItems.DataSource = ListaItemsAvanzada;
        gvCatalogoItems.DataBind();
        HelpGridView.Caption(ref gvCatalogoItems, "Lista de ítems - Búsqueda avanzada", ListaItemsAvanzada.Count.ToString());

    }
    private void ListarItemsSimple(string pTextoBusqueda,string pCodSac)
    {
        ItemLogic oItemLogic = new ItemLogic();
        string CodArguEstadoDisponibleEjemplar = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
        List<Item> ListaItemsSimple=new List<Item>();
        ListaItemsSimple = oItemLogic.ListarCatalogo_Simple(pTextoBusqueda, pCodSac, CodArguEstadoDisponibleEjemplar);
        gvCatalogoItems.DataSource = ListaItemsSimple;
        gvCatalogoItems.DataBind();
        HelpGridView.Caption(ref gvCatalogoItems, "Lista de ítems - Búsqueda simple", ListaItemsSimple.Count.ToString());

       
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
        else if (ddlTipoArticulo.SelectedValue == hfCodArguLibroReader.Value ||
            ddlTipoArticulo.SelectedValue == hfCodArguLibroGrammar.Value ||
            ddlTipoArticulo.SelectedValue == hfCodArguLibroPaper.Value)//ELVP:19-09-2011
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
        else if (ddlTipoArticulo.SelectedIndex == 0)
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


    
}
