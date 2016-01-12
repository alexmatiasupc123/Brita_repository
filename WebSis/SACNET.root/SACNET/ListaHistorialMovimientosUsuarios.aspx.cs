using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;
using System.Configuration;
using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using System.Drawing;
public partial class ListaHistorialMovimientosUsuarios : System.Web.UI.Page
{

    #region "/--- Evento de la Página  ---/"
    
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
            Buscar();
        }
        Page.Title = lblTituloPagina.Text;
    }

    #endregion

    #region "/--- Evento de los Controles  ---/"

    private void InicializarEventos()
    {
        this.BotonesEdicionLista1.OnBotonImprimirClick += new EventHandler(BotonesEdicionLista1_OnBotonImprimirClick);
        this.BotonesEdicionLista1.OnBotonBuscarClick += new EventHandler(BotonesEdicionLista1_OnBotonBuscarClick);
        this.BotonesEdicionLista1.OnBotonRegresarClick += new EventHandler(BotonesEdicionLista1_OnBotonRegresarClick);
        BotonesEdicionLista1.BotonNuevo = false;
    }

    void BotonesEdicionLista1_OnBotonImprimirClick(object sender, EventArgs e)
    {
    }

    void BotonesEdicionLista1_OnBotonRegresarClick(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

    void BotonesEdicionLista1_OnBotonBuscarClick(object sender, EventArgs e)
    {
        Buscar();
    }

    protected void UpdatePanelJavaScriptExtender1_Update(object Sender, EventArgs E, string parameter)
    {
        if (parameter.Trim() != "")
        {
            string[] Valores = parameter.Split(new char[] { '&' });
            if (Valores[0].ToString() == "")
            {
            }
        }
    }

    protected void gvHistorialMovimientos_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvHistorialMovimientos.PageIndex = e.NewPageIndex;
        Buscar();
    }

    protected void gvHistorialMovimientos_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DataRowView IOK = (DataRowView)e.Row.DataItem;

            string FechaEntR = IOK.Row[11].ToString();
            string FechaEntE = IOK.Row[10].ToString();
            Nullable<DateTime> FechaEntRe = null;
            Nullable<DateTime> FechaEntEs = null;

            if (FechaEntR != string.Empty && FechaEntE != string.Empty)
            {
                FechaEntRe = Convert.ToDateTime(Convert.ToDateTime(FechaEntR).ToShortDateString());
                FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                if (FechaEntRe > FechaEntEs)
                    e.Row.ForeColor = Color.Red;
            }
            else
            {
                if (FechaEntE != string.Empty)
                {
                    FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                    if (DateTime.Today > FechaEntEs)
                        e.Row.ForeColor = Color.Coral;
                }
            }
        }
    }

    protected void CheckBoxConCarnet_CheckedChanged(object sender, EventArgs e)
    {
        Buscar();
    }

    #endregion

    #region "/--- Metodos del Desarrollador  ---/"

    private void CargarPagina()
    {
        HelpMaestros.CargarListadoGenerico(ref prm_sCodArguTipoMovimi, HelpMaestros.TablasMaestras.EstadosDeMovimientos, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        
        prm_dFechaProcesoINI.Text = DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        prm_dFechaProcesoFIN.Text = DateTime.Now.ToShortDateString();

        Seguridad();
    }

    public string PintarEstado(string pCodigoTabla, bool pEstado)
    {
        string estado = string.Empty;
        if (pCodigoTabla.Length != 0)
        {
            if (pEstado)
                estado = "Si";
            else
                estado = "No";
        }
        return estado;
    }

    private void Buscar()
    {
        string date1 = HelpDates.EsFechaValida(prm_dFechaProcesoINI.Text);
        string date2 = HelpDates.EsFechaValida(prm_dFechaProcesoFIN.Text);
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
        if (Convert.ToDateTime(prm_dFechaProcesoINI.Text) > Convert.ToDateTime(prm_dFechaProcesoFIN.Text))
        {
            MessageBox1.ShowInfo("¡ La fecha de inicio debe de ser menor o igual que la fecha de fin para la búsqueda !");
            return;
        }
        bool? CON_CARNE = null;
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        List<Prestamo> lista = new List<Prestamo>();

        PrestamoLogic.TipoDeOperacion xxTipoOperacion = new PrestamoLogic.TipoDeOperacion();
        if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == string.Empty)
            xxTipoOperacion = PrestamoLogic.TipoDeOperacion.OperTodos;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == "TSTDM002")
            xxTipoOperacion = PrestamoLogic.TipoDeOperacion.OperReserva;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == "TSTDM001")
            xxTipoOperacion = PrestamoLogic.TipoDeOperacion.OperPrestamo;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == "TSTDM003")
            xxTipoOperacion = PrestamoLogic.TipoDeOperacion.OperDevolucion;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == "TSTDM004")
            xxTipoOperacion = PrestamoLogic.TipoDeOperacion.OperSinDevolucion;
        lista = oPrestamoLogic.Listar(null, Convert.ToDateTime(prm_dFechaProcesoINI.Text), Convert.ToDateTime(prm_dFechaProcesoFIN.Text), this.Master.HelpUsuario().LoginUsuario, string.Empty, string.Empty, string.Empty, true, string.Empty, CON_CARNE, xxTipoOperacion);


        List<Prestamo> listaOrdenada;
        listaOrdenada = lista.OrderByDescending(x => x.dFechaPrestamo).ToList();
        gvHistorialMovimientos.DataSource = HelpConvert<Prestamo>.ConvertList(listaOrdenada);

        gvHistorialMovimientos.DataBind();
        HelpGridView.Caption(ref gvHistorialMovimientos, "Lista de movimientos del usuario", lista.Count.ToString());
    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaHistorialMovimientosUsuarios.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaHistorialMovimientosUsuarios.aspx");//ELVP:11-10-2011

        if (lstRolesOpciones != null)
        {
            lblTituloPagina.Text = lstRolesOpciones[0].CodigoOpcionNombre;//oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
        }
    }

    #endregion
    
}
