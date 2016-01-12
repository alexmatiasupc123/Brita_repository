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
public partial class ListaDarBajaEjemplares : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        this.InicializarEventos();
        this.EstadoBoton();
        if (!Page.IsPostBack)
        {
            CargarCombos();
            BuscarFiltro();

        }
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {   
            Seguridad();
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
        
    }
    protected void gvItems_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItems.PageIndex = e.NewPageIndex;
        BuscarFiltro();
    }

    protected void gvItems_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            String querystringENCRYP = string.Empty;
            ImageButton ibtnSelect = (ImageButton)e.Row.Cells[6].FindControl("btnSelect");
            Item oItem = (Item)e.Row.DataItem;
            string CodItem = oItem.sCodItem;
            string TituloItem = oItem.sTitulo;
            querystringENCRYP = HelpEncrypt.Encriptar("&iId=" + CodItem + "&Tit=" + TituloItem);
            ibtnSelect.Attributes.Add("onclick", "OpenPopup('PopupDarAltaEjemplares.aspx?pm=" + querystringENCRYP + "',800,550)");
        }
    }
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaDarAltaEjemplares.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaDarAltaEjemplares.aspx");//ELVP:11-10-2011

        if (lstRolesOpciones == null)
        {
            Response.Redirect("Login.aspx");

        }              
    }
    private void EstadoBoton()
    {
        BotonesEdicionLista1.BotonNuevo = false;

    }
    private void BuscarFiltro()
    {
        string CodTipoItem = ddlTipoArticulo.SelectedIndex == 0 ? "" : ddlTipoArticulo.SelectedItem.Value;
        string CodAutor = ddlAutor.SelectedIndex == 0 ? "" : ddlAutor.SelectedItem.Value;        
        string CodTema = ddlTema.SelectedIndex == 0 ? "" : ddlTema.SelectedItem.Value;
        string EstadoEnPedido = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoItem_VXDF);
        string EstadoEnStock = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnStockItem);
        ListarItems(txtCodItem.Text, CodTipoItem, string.Empty, txtTitulo.Text, CodAutor, txtISBN.Text, txtISSN.Text, CodTema, EstadoEnPedido, EstadoEnStock);
    }
    private void ListarItems(string pCodItem, string pCodArguTipoItem, string pCodSac, string pTitulo, string pCodArguAutor, string pISBN, string pISSN, string pCodArguTema, string pCodArguEstadoItem1, string pCodArguEstadoItem2)
    {
        ItemLogic oItemLogic = new ItemLogic();
        List<Item> lista = oItemLogic.ListarItem_DarAlta(pCodItem, pCodArguTipoItem, pCodSac, pTitulo, pCodArguAutor, pISBN, pISSN, pCodArguTema, pCodArguEstadoItem1, pCodArguEstadoItem2);
        gvItems.DataSource = lista;
        gvItems.DataBind();
        HelpGridView.Caption(ref gvItems, "Ejemplares pendientes de asignar a un SAC", lista.Count.ToString());

    }
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlTipoArticulo, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);       
        HelpMaestros.CargarListadoGenerico(ref ddlAutor, HelpMaestros.TablasMaestras.AutoresDeItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlTema, HelpMaestros.TablasMaestras.TiposDeTemas, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        //***ELVP: 19-09-2011******************
        hfCodArguLibroReader.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader);
        hfCodArguLibroGrammar.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar);
        hfCodArguLibroPaper.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper);
        //hfCodArguLibro.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro);
        //*************************************
        hfCodArguRevista.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista);
        hfCodArguAudioVisual.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual);
        hfCodArguRecursoElectronico.Value = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico);
    }

    #endregion



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
    protected void btnSelect_Click(object sender, ImageClickEventArgs e)
    {
        this.BuscarFiltro();
    }
}
