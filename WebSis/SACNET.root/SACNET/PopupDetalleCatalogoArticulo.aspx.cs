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
public partial class PopupDetalleCatalogoArticulo : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (!Page.IsPostBack)
        {
            Usuarios oUsuario = new Usuarios();            
            oUsuario = (Usuarios)Session["Usuario"];
            if (oUsuario != null)
            {
                CargarConfiguraciones();
                CargarDetalleItem();
            }
            else
                Response.Redirect("Login.aspx");
        }
    }
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    public string PintarEstado(bool pEstado)
    {
        string estado = string.Empty;

            if (pEstado)
                estado = "Si";
            else
                estado = "No";
        return estado;
    }

    private void CargarDetalleItem()
    {
        if (Request.QueryString["pm"] != null)
        {
            string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));

            if (HelpEncrypt.QueryString(querystringDESENCRYP, "pCodItem") != string.Empty)
            {
                string CodItem = HelpEncrypt.QueryString(querystringDESENCRYP, "pCodItem");//pCodSac
                string CodSac = HelpEncrypt.QueryString(querystringDESENCRYP, "pCodSac");
                string CodEjemplarDisponible = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoDisponibleEjemplar);
                string CodEjemplarEnPrestamo = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnPrestamoEjemplar);
                string CodEjemplarEnReserva = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoEnReservaEjemplar);
                Item ItemDetalle = new Item();
                ItemLogic oItemLogic = new ItemLogic();
                ItemDetalle = oItemLogic.BuscarDetalleItem(CodItem, CodSac, CodEjemplarDisponible, CodEjemplarEnPrestamo, CodEjemplarEnReserva);
                MostrarFotografia(ItemDetalle.sFotografia);
                txtCodItem.Text = ItemDetalle.sCodItem;
                txtTitulo.Text = ItemDetalle.sTitulo;
                if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemAudioVisual) == ItemDetalle.sCodArguTipoItem)
                {
                    labelPieImp.Text = "Tipo de audiencia :";
                    lblAutores_Actores.Text = "Actores :";
                    txtPieImprenta_Audiencia.Text = ItemDetalle.sCodArguAudienciaNombre;                    
                    lblDAutores_Actores.Text = string.Empty;
                    foreach (ItemActor item in ItemDetalle.ListaActores)
                    {
                        lblDAutores_Actores.Text += item.sCodArguNombreActor + "</br>";

                    }
                    trGeneroDuracion.Visible = true;
                    trReqTenico.Visible = true;
                }
                //else if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibro) == ItemDetalle.sCodArguTipoItem)
                else if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroReader) == ItemDetalle.sCodArguTipoItem ||
                    HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroGrammar) == ItemDetalle.sCodArguTipoItem ||
                    HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemLibroPaper) == ItemDetalle.sCodArguTipoItem)//ELVP:20-09-2011
                {
                    labelPieImp.Text = "Pie de imprenta :";
                    lblAutores_Actores.Text = "Autores :";
                    txtPieImprenta_Audiencia.Text = ItemDetalle.sPieImprenta;                    
                    lblDAutores_Actores.Text = string.Empty;
                    foreach (ItemAutor item in ItemDetalle.ListaAutores)
                    {
                        lblDAutores_Actores.Text += item.sCodArguNombreAutor + "</br>";
                        
                    }
                    trGeneroDuracion.Visible = false;
                    trReqTenico.Visible = false;
                }
                else if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRecursoElectronico) == ItemDetalle.sCodArguTipoItem)
                {
                    labelPieImp.Text = "Pie de imprenta :";
                    lblAutores_Actores.Text = "Autores :";
                    txtPieImprenta_Audiencia.Text = ItemDetalle.sPieImprenta;
                    lblDAutores_Actores.Text = string.Empty;
                    foreach (ItemAutor item in ItemDetalle.ListaAutores)
                    {
                        lblDAutores_Actores.Text += item.sCodArguNombreAutor + "</br>";

                    }
                    
                    trGeneroDuracion.Visible = true;
                    trReqTenico.Visible = true;
                    lblDuracion.Visible = true;
                    txtDuracion.Visible = true;
                    lblGenero.Visible = false;
                    txtGenero.Visible = false;
                }
                else if (HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguTipoItemRevista) == ItemDetalle.sCodArguTipoItem)
                {
                    labelPieImp.Text = "Pie de Imprenta :";
                    lblAutores_Actores.Text = "Autores :";
                    txtPieImprenta_Audiencia.Text = ItemDetalle.sPieImprenta;
                    lblDAutores_Actores.Text = string.Empty;
                    foreach (ItemAutor item in ItemDetalle.ListaAutores)
                    {
                        lblDAutores_Actores.Text += item.sCodArguNombreAutor + "</br>";

                    }                    
                    trGeneroDuracion.Visible = false;
                    trReqTenico.Visible = false;
                }                
                lblTemas.Text = string.Empty;
                foreach (ItemTema item in ItemDetalle.ListaTemas)
                {
                    lblTemas.Text += item.sCodArguNombreTema + "</br>";

                }
                txtResumen.Text = ItemDetalle.sResumen;
                txtNotas.Text = ItemDetalle.sNotas;
                txtFormatoAdicional.Text = ItemDetalle.sFormatoAdicional;
                txtCantidadDisponible.Text = ItemDetalle.sCantidadDisponibles;
                txtCantidadEnPrestamo.Text = ItemDetalle.sCantidadEnPrestamo;
                txtCantidadEnReserva.Text = ItemDetalle.sCantidadEnReserva;                
                gvEjemplares.DataSource = HelpConvert<ItemEjemplar>.ConvertList(ItemDetalle.ListaEjemplares);
                gvEjemplares.DataBind();
                HelpGridView.Caption(ref gvEjemplares, "Lista de ejemplares.", ItemDetalle.ListaEjemplares.Count.ToString());
                Session["PopupListaEjemplares"] = ItemDetalle.ListaEjemplares;
            }
        }
    }
    private void MostrarFotografia(string NombreFoto)
    {
        NombreFoto = NombreFoto.Replace("/", "@");
        string PathImagenes = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.DirImagenViewItem);// Trabajo en Desarrollo
        imgFotografia.ImageUrl = PathImagenes + NombreFoto;
    }
    private void CargarConfiguraciones()
    {
        this.btnSalir.Attributes.Add("OnClick", "CerrarClose()");
    }
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/
    protected void gvEjemplares_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvEjemplares.PageIndex = e.NewPageIndex;
        gvEjemplares.DataSource = (List<ItemEjemplar>)Session["PopupListaEjemplares"];
        gvEjemplares.DataBind();
    }

    protected void gvEjemplares_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
           
        }
    }

    #endregion
   
}
