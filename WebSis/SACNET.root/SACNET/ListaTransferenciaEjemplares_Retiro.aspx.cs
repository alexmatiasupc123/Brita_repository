using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Configuration;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using Oxinet.Maestros.Interface;
using Oxinet.Tools;
public partial class ListaTransferenciaEjemplares_Retiro : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        this.InicializarEventos();
        this.EstadoBoton();
        if (!Page.IsPostBack)
        {
            this.CargarCombos();
            this.CargarConfiguraciones();
            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));

                txtFechaProcesoDesde.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFI") == string.Empty ? txtFechaProcesoDesde.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFI");
                txtFechaProcesoHasta.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xFF") == string.Empty ? txtFechaProcesoHasta.Text : HelpEncrypt.QueryString(querystringDESENCRYP, "xFF");
                ddlEstadoTransferencia.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xET");
                txtCodTransferencia.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "xCT");
                ddlSacOrigen.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xSO");
                ddlSacDestino.SelectedValue = HelpEncrypt.QueryString(querystringDESENCRYP, "xSD");
            }
            this.BuscarFiltro();

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
        Response.Redirect("MantTransferenciaEjemplares.aspx?pm=" + HelpEncrypt.Encriptar(ParametrosDelFiltro()));
    }
    protected void gvSolicitudTrasnferencia_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        String querystringENCRYP = string.Empty;
        switch (e.CommandName)
        {
            case "Editar":
                querystringENCRYP = HelpEncrypt.Encriptar("&tId=" + e.CommandArgument.ToString() + ParametrosDelFiltro());
                Response.Redirect("ListaEjemplares_VerificarRetiro.aspx?pm=" + querystringENCRYP, false);
                break;
            default:
                break;
        }
    }
    protected void gvSolicitudTrasnferencia_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {

        }
    }
    protected void gvSolicitudTrasnferencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvSolicitudTrasnferencia.PageIndex = e.NewPageIndex;
        this.BuscarFiltro();
    }
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/
    private string ParametrosDelFiltro()
    {
        string sParameters = string.Empty;
        sParameters = "&xFI=" + txtFechaProcesoDesde.Text.ToString();
        sParameters = sParameters + "&xFF=" + txtFechaProcesoHasta.Text.ToString();
        sParameters = sParameters + "&xET=" + ddlEstadoTransferencia.SelectedValue.ToString();
        sParameters = sParameters + "&xCT=" + txtCodTransferencia.Text;
        sParameters = sParameters + "&xSO=" + ddlSacOrigen.SelectedValue.ToString();
        sParameters = sParameters + "&xSD=" + ddlSacDestino.SelectedValue.ToString();
        return sParameters;
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaTransferenciaEjemplares_Retiro.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaTransferenciaEjemplares_Retiro.aspx");//ELVP:11-10-2011

        if (lstRolesOpciones != null)
        {
            lblTituloPagina.Text = lstRolesOpciones[0].CodigoOpcionNombre;//oRolesOpciones.CodigoOpcionNombre;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }    
    }
    private void CargarConfiguraciones()
    {
        txtFechaProcesoDesde.Text = DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        txtFechaProcesoHasta.Text = DateTime.Today.ToShortDateString();
        txtCodTransferencia.Attributes.Add("onKeyPress", "return filterInput(1, event)");
        if (Master.HelpUsuariosSAC().CodLocalSAC != null)
        {
            if (string.IsNullOrEmpty(Master.HelpUsuariosSAC().CodLocalSAC.Trim()) == false)
            {
                string CodSacUser = Master.HelpUsuariosSAC().CodLocalSAC.Trim();
                if (CodSacUser != null)
                {
                    if (string.IsNullOrEmpty(CodSacUser) == false)
                    {
                        ddlSacOrigen.SelectedValue = CodSacUser;
                        ddlSacOrigen.Enabled = false;
                        ddlEstadoTransferencia.SelectedValue = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoTransferencia_VXDF);
                        ddlEstadoTransferencia.Enabled = false;
                    }
                    else
                    {
                        gvSolicitudTrasnferencia.Columns[8].Visible = false;
                    }
                }
            }
            
        }
        //else
        //{
        //    gvSolicitudTrasnferencia.Columns[8].Visible = false;
        //}
        
        
        
        
    }
    private void EstadoBoton()
    {
        BotonesEdicionLista1.BotonExportarEnabled = false;
        BotonesEdicionLista1.BotonImprimirEnabled = false;
        BotonesEdicionLista1.BotonRegresarEnabled = true;
        BotonesEdicionLista1.BotonNuevo = false;
        BotonesEdicionLista1.BotonBuscarEnabled = true;

    }
    private void BuscarFiltro()
    {
        string date1 = HelpDates.EsFechaValida(txtFechaProcesoDesde.Text);
        string date2 = HelpDates.EsFechaValida(txtFechaProcesoHasta.Text);
        if (date1.Length > 0)
        {
            MessageBox1.ShowInfo(date1);
            return;
        }
        if (date2.Length > 0)
        {
            MessageBox1.ShowInfo(date2);
            return;
        }
        if (Convert.ToDateTime(txtFechaProcesoDesde.Text) > Convert.ToDateTime(txtFechaProcesoHasta.Text))
        {
            MessageBox1.ShowInfo("¡ La fecha de inicio debe de ser menor o igual que la fecha de fin para la búsqueda !");
            return;
        }
        string pFechaProcesoDesde = HelpDates.FormatFechaYMD(Convert.ToDateTime(txtFechaProcesoDesde.Text));
        string pFechaProcesoHasta = HelpDates.FormatFechaYMD(Convert.ToDateTime(txtFechaProcesoHasta.Text));
        string pCodArguEstado = ddlEstadoTransferencia.SelectedIndex == 0 ? "" : ddlEstadoTransferencia.SelectedItem.Value;
        string pCodTransferencia = txtCodTransferencia.Text;
        string pCodSacOrigen = ddlSacOrigen.SelectedIndex == 0 ? "" : ddlSacOrigen.SelectedItem.Value;
        string pCodSacDestino = ddlSacDestino.SelectedIndex == 0 ? "" : ddlSacDestino.SelectedItem.Value;
        ListarTransferencias(pFechaProcesoDesde, pFechaProcesoHasta, pCodArguEstado, pCodTransferencia, pCodSacOrigen, pCodSacDestino);
        
    }
    private void ListarTransferencias(string FechaProcesoDesde, string FechaProcesoHasta, string CodArguEstado, string CodTransferencia, string CodSacOrigen, string CodSacDestino)
    {
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        List<SolicitudTransferencia> lista = oSolicitudTransferenciaLogic.Listar(FechaProcesoDesde, FechaProcesoHasta, CodArguEstado, CodTransferencia, CodSacOrigen, CodSacDestino);
        gvSolicitudTrasnferencia.DataSource = lista;
        gvSolicitudTrasnferencia.DataBind();
         HelpGridView.Caption( ref gvSolicitudTrasnferencia,"Lista de solicitud de transferencia", lista.Count.ToString());

    }
    private void CargarCombos()
    {
        HelpMaestros.CargarListadoGenerico(ref ddlEstadoTransferencia, HelpMaestros.TablasMaestras.EstadosDeTransferencias, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);

        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        ddlSacOrigen.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSacOrigen.DataValueField = "CodLocalSAC";
        ddlSacOrigen.DataTextField = "NombreLocal";
        ddlSacOrigen.DataBind();
        ddlSacOrigen.Items.Insert(0, (new ListItem("-- Todos --", "")));


        ddlSacDestino.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSacDestino.DataValueField = "CodLocalSAC";
        ddlSacDestino.DataTextField = "NombreLocal";
        ddlSacDestino.DataBind();
        ddlSacDestino.Items.Insert(0, (new ListItem("-- Todos --", "")));
    }
    private void EliminarTransferencias(string pCodTransferencia)
    {
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        oSolicitudTransferenciaLogic.Eliminar(pCodTransferencia, Master.HelpUsuario().LoginUsuario);
        this.BuscarFiltro();
    }
    #endregion
    
    
}
