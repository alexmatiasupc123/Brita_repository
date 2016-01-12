﻿using System;
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

public partial class Reporte_RankingTitulos : System.Web.UI.Page
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

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/

    protected void ibtnAceptar_Click(object sender, ImageClickEventArgs e)
    {

        List<Reportes> lista = new List<Reportes>();
        ReportesLogic oReportesLogic = new ReportesLogic();

        string CodSac = ddlSAC.SelectedIndex == 0 ? null : ddlSAC.SelectedItem.Value;
        string CodTipoMaterial = ddlTipoMaterial.SelectedIndex == 0 ? null : ddlTipoMaterial.SelectedItem.Value;
        string FechaInicio;
        string FechaFin;
        if (opFecha.Items[0].Selected)
        {
            FechaInicio = txtPeriodo.Text + "01";
            FechaFin = txtPeriodo.Text + "31";
        }
        else
        {
            FechaInicio = HelpDates.FormatFechaYMD(Convert.ToDateTime(ucFechaDesde.Text));
            FechaFin = HelpDates.FormatFechaYMD(Convert.ToDateTime(ucFechaHasta.Text));
        }

        string CodTipoMovimiento = ddlTipoMovimiento.SelectedItem.Value;
        int Cantidad = Convert.ToInt16(txtCantidad.Text);
        string orden = ddlOrden.SelectedItem.Value;

        lista = oReportesLogic.RankigTitulos(CodSac, CodTipoMaterial, FechaInicio, FechaFin, CodTipoMovimiento, Cantidad, orden);
        ReportDataSource rds = new ReportDataSource("Britanico_SacNet_BusinessEntities_Reportes", lista);

        rvRankingTitulos.LocalReport.DataSources.Clear();
        rvRankingTitulos.LocalReport.DataSources.Add(rds);
        rvRankingTitulos.LocalReport.ReportPath = @"Reportes\RankingTitulos.rdlc";
        rvRankingTitulos.ShowToolBar = true;

        ReportParameter[] Parametros = new ReportParameter[2];
        Parametros[0] = new ReportParameter("prmTitulo", lblTituloPagina.Text);
        Parametros[1] = new ReportParameter("prmUsuario", this.Master.HelpUsuario().LoginUsuario);
        rvRankingTitulos.LocalReport.SetParameters(Parametros);

        rvRankingTitulos.LocalReport.Refresh();
    }

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
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("Reporte_RankingTitulos.aspx");
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
        txtCantidad.Text = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Paginacion);


    }
    #endregion

}
