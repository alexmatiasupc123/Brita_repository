using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oxinet.Tools;
using System.Configuration;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using System.Drawing;
public partial class ListaHistorialMovimientos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        InicializarEventos();
        if (!IsPostBack)
        {
            CargarPagina();
            Buscar();
        }
        Seguridad();
        Page.Title = lblTituloPagina.Text;
        gvHistorialMovimientos.HeaderStyle.CssClass = "cssGridView1";//ELVP: 08-08-2011
    }

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

    #region "/--- Evento de los Controles  ---/"

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

            string FechaEntR = IOK.Row[11].ToString();// DEVOLUCION REAL
            string FechaEntE = IOK.Row[10].ToString();// DEVOLUCION ESTIMADA
            Nullable<DateTime> FechaEntRe = null;
            Nullable<DateTime> FechaEntEs = null;

            if (FechaEntR != string.Empty && FechaEntE != string.Empty)
            {
                FechaEntRe = Convert.ToDateTime(Convert.ToDateTime(FechaEntR).ToShortDateString());
                FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                if (FechaEntRe > FechaEntEs) // SI LA DEVOLUCION REAL ES MAYOR QUE LA DEVOLUCIÓN ESTIMADA
                    e.Row.ForeColor = Color.Red;
            }
            else
            {
                if (FechaEntE != string.Empty)
                {
                    FechaEntEs = Convert.ToDateTime(Convert.ToDateTime(FechaEntE).ToShortDateString());
                    if(DateTime.Today > FechaEntEs)
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

    private void CargarPagina()
    {
        HelpMaestros.CargarListadoGenerico(ref prm_sCodArguTipoMovimi, HelpMaestros.TablasMaestras.EstadosDeMovimientos, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref prm_sCodArguPrestamoEn, HelpMaestros.TablasMaestras.TiposDePrestamos, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        prm_sCodArguPrestamoEn.DataBind();
        
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        
        prm_sEstablecimientoCodigo.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        prm_sEstablecimientoCodigo.DataValueField = "CodLocalSAC";
        prm_sEstablecimientoCodigo.DataTextField = "NombreLocal";
        HelpComboBox.AddItemText(ref prm_sEstablecimientoCodigo, HelpComboBox.Texto.Todos);
        prm_sEstablecimientoCodigo.DataBind();
        vwUsuariosSAC itemvwUsuariosSAC = this.Master.HelpUsuariosSAC();

        if (itemvwUsuariosSAC.CodLocalSAC != null)
            if (itemvwUsuariosSAC.CodLocalSAC.Trim() != string.Empty)
            {
                prm_sEstablecimientoCodigo.SelectedValue = itemvwUsuariosSAC.CodLocalSAC == null ? " " : itemvwUsuariosSAC.CodLocalSAC.Trim();
                prm_sEstablecimientoCodigo.Enabled = false;
            }

        prm_dFechaProcesoINI.Text = DateTime.Now.AddDays(Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES)) * -1).ToShortDateString();
        prm_dFechaProcesoFIN.Text = DateTime.Now.ToShortDateString();


    }

    private void Seguridad()
    {
        //RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaHistorialMovimientos.aspx");
        List<RolesOpciones> lstRolesOpciones = this.Master.HelpOpcion_Permiso_Lista("ListaHistorialMovimientos.aspx");//ELVP:11-10-2011

        vwUsuariosSAC itemvwUsuariosSAC = this.Master.HelpUsuariosSAC();
        if (lstRolesOpciones != null)
        {
            lblTituloPagina.Text = lstRolesOpciones[0].CodigoOpcionNombre;//oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
        }
        if (itemvwUsuariosSAC.CodLocalSAC != null)
        {
            if (itemvwUsuariosSAC.CodLocalSAC.Trim() != string.Empty)
            {
                string pSacNet = itemvwUsuariosSAC.CodLocalSAC.Trim();
                prm_sEstablecimientoCodigo.SelectedValue = pSacNet;
                prm_sEstablecimientoCodigo.Enabled = false;
            }
        }
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
        bool ? CON_CARNE = null;
        //if (CheckBoxConCarnet.Checked && CheckBoxSinCarnet.Checked)
        //    CON_CARNE = null;
        //else if (CheckBoxConCarnet.Checked && !CheckBoxSinCarnet.Checked)
        //    CON_CARNE = true;
        //else if (!CheckBoxConCarnet.Checked && CheckBoxSinCarnet.Checked)
        //    CON_CARNE = false;
        PrestamoLogic oPrestamoLogic = new PrestamoLogic();
        List<Prestamo> lista = new List<Prestamo>();

        PrestamoLogic.TipoDeOperacion xx = new PrestamoLogic.TipoDeOperacion();
        if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == string.Empty)
            xx = PrestamoLogic.TipoDeOperacion.OperTodos;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguMovimientoReservas)) // "TSTDM002" Reservas
            xx = PrestamoLogic.TipoDeOperacion.OperReserva;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguMovimientoPrestamos)) //"TSTDM001" Prestamos
            xx = PrestamoLogic.TipoDeOperacion.OperPrestamo;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguMovimientoDevoluciones)) //"TSTDM003" Devoluciones
            xx = PrestamoLogic.TipoDeOperacion.OperDevolucion;
        else if (prm_sCodArguTipoMovimi.SelectedValue.ToString().Trim() == HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguMovimientoPendientes)) // "TSTDM004" Pendientes
            xx = PrestamoLogic.TipoDeOperacion.OperSinDevolucion;
        lista = oPrestamoLogic.Listar(prm_sEstablecimientoCodigo.SelectedValue.ToString().Trim(), Convert.ToDateTime(prm_dFechaProcesoINI.Text), Convert.ToDateTime(prm_dFechaProcesoFIN.Text), prm_sCodUsuarioSAC.Text, prm_sNombresUsuarioSAC.Text,string.Empty, prm_sCodEjemplarTitulo.Text.Trim(),true, prm_sCodArguPrestamoEn.SelectedValue.ToString().Trim(), CON_CARNE, xx);

        List<Prestamo> listaOrdenada;
        listaOrdenada = lista.OrderByDescending(x => x.dFechaPrestamo).ToList();

        gvHistorialMovimientos.DataSource = HelpConvert<Prestamo>.ConvertList(listaOrdenada);
        gvHistorialMovimientos.DataBind();
        HelpGridView.Caption(ref gvHistorialMovimientos, "LISTA DE MOVIMIENTOS", lista.Count.ToString());
   
    }

    #endregion

}
