using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Britanico.SacNet.BusinessLogic;
using Britanico.SacNet.BusinessEntities;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Tools;
using Microsoft.Reporting.WebForms;
public partial class Reporte_MovimientosXPeriodoDetallado : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CargarPage();
        }
        Seguridad();
    }
    #endregion
    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("Reporte_MovimientosXPeriodoDetallado.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            Page.Title = lblTituloPagina.Text;
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    private void CargarPage()
    {
        vwDatosVistaLogic ovwDatosVistaLogic = new vwDatosVistaLogic();
        ddlSAC.DataSource = ovwDatosVistaLogic.ListarvwLocalesSAC();
        ddlSAC.DataValueField = "CodLocalSAC";
        ddlSAC.DataTextField = "NombreLocal";
        ddlSAC.DataBind();
        HelpComboBox.AddItemText(ref ddlSAC, HelpComboBox.Texto.Todos);
        string Month = DateTime.Now.Month.ToString();
        if (Month.Length == 1) Month = "0" + Month;
        txtPeriodo.Text = DateTime.Now.Year.ToString() + Month;
        ucFechaDesde.Text = DateTime.Today.AddDays(-Convert.ToDouble(HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Default_DIAS_ANTES))).ToShortDateString();
        ucFechaHasta.Text = DateTime.Today.ToShortDateString();
        HelpMaestros.CargarListadoGenerico(ref ddlTipoMaterial, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
       
        
    }   
    #endregion
    protected void opFecha_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (opFecha.Items[0].Selected)
        {
            lblFechaDesde.Visible = false;
            ucFechaDesde.Visible = false;
            lblFechaHasta.Visible = false;
            ucFechaHasta.Visible = false;
            txtPeriodo.Visible = true;
        }
        else
        {
            lblFechaDesde.Visible = true;
            ucFechaDesde.Visible = true;
            lblFechaHasta.Visible = true;
            ucFechaHasta.Visible = true;
            txtPeriodo.Visible = false;
        }
    }
    protected void ibtnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        List<Reportes> lista = new List<Reportes>();
        ReportesLogic oReportesLogic = new ReportesLogic();

        string CodSac = ddlSAC.SelectedIndex == 0 ? null : ddlSAC.SelectedItem.Value;
        string CodTipoMaterial = ddlTipoMaterial.SelectedIndex == 0 ? null : ddlTipoMaterial.SelectedItem.Value;
        string FechaInicio=string.Empty;
        string FechaFin = string.Empty;
        if (opFecha.Items[0].Selected)
        {
            if (txtPeriodo.Text.Length == 6)
            {
                if (Convert.ToInt32(txtPeriodo.Text.Substring(4, 2)) > 0 && Convert.ToInt32(txtPeriodo.Text.Substring(4, 2)) <= 12)
                {
                    FechaInicio = txtPeriodo.Text + "01";
                    FechaFin = txtPeriodo.Text + "31";
                }
                else
                {
                    MessageBox1.ShowInfo("El formato del periodo es invalido.");
                    return;
                }
            }
            else
            {
                MessageBox1.ShowInfo("El formato del periodo es invalido.");
                return;
            }
            
        }
        else
        {
            FechaInicio = HelpDates.FormatFechaYMD(Convert.ToDateTime(ucFechaDesde.Text));
            FechaFin = HelpDates.FormatFechaYMD(Convert.ToDateTime(ucFechaHasta.Text));
        }

        string CodTipoMovimiento = ddlTipoMovimiento.SelectedItem.Value;
        string TipoMovimiento = ddlTipoMovimiento.SelectedItem.Text;

        lista = oReportesLogic.MovimientoXPeriodoDetallado(CodSac,FechaInicio, FechaFin, CodTipoMovimiento, CodTipoMaterial);
        rvMovimientosXPeriodoDetallado.Reset();
        ReportDataSource rds = new ReportDataSource("Britanico_SacNet_BusinessEntities_Reportes", lista);
        rvMovimientosXPeriodoDetallado.LocalReport.DataSources.Clear();
        rvMovimientosXPeriodoDetallado.LocalReport.DataSources.Add(rds);

        if (ddlTipoReporte.SelectedItem.Value == "0")
        {
            rvMovimientosXPeriodoDetallado.LocalReport.ReportPath = @"Reportes\MovimientosXPeriodoDetallado.rdlc";
        }
        else
        {
            rvMovimientosXPeriodoDetallado.LocalReport.ReportPath = @"Reportes\MovimientosXPeriodoDetallado_Grafico.rdlc";
      
        }

        ReportParameter[] Parametros = new ReportParameter[2];
        Parametros[0] = new ReportParameter("prmTitulo", lblTituloPagina.Text + " (" + TipoMovimiento + ") ");
        Parametros[1] = new ReportParameter("prmUsuario", this.Master.HelpUsuario().LoginUsuario);
        rvMovimientosXPeriodoDetallado.LocalReport.SetParameters(Parametros);

        rvMovimientosXPeriodoDetallado.LocalReport.Refresh();
        
    }
}
