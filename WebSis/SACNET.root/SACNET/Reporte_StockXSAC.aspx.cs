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
public partial class Reporte_StockXSAC : System.Web.UI.Page
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
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("Reporte_StockXSAC.aspx");
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
        HelpMaestros.CargarListadoGenerico(ref ddlTipoMaterial, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
       
        
    }   
    #endregion
   
    protected void ibtnAceptar_Click(object sender, ImageClickEventArgs e)
    {
        List<Reportes> lista = new List<Reportes>();
        ReportesLogic oReportesLogic = new ReportesLogic();

        string CodSac = ddlSAC.SelectedIndex == 0 ? null : ddlSAC.SelectedItem.Value;
        string CodTipoMaterial = ddlTipoMaterial.SelectedIndex == 0 ? null : ddlTipoMaterial.SelectedItem.Value;

        rvStockXSAC.Reset();


        if (ddlReporte.Items[0].Selected)
        {
            if (opOrden.Items[0].Selected)
            {
                lista = oReportesLogic.StockXSAC(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSAC", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACCon.rdlc";
            }
            else
            {
                lista = oReportesLogic.StockXSAC(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSAC", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACConXTema.rdlc";
            }

        }
        else
        {
            if (opOrden.Items[0].Selected)
            {
                lista = oReportesLogic.StockXSACDet(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSACDet", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACDet.rdlc";
            }
            else
            {
                lista = oReportesLogic.StockXSACDet(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSACDet", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACDetXTema.rdlc";
            }
        }

        string Titulo = CodTipoMaterial == null ? lblTituloPagina.Text + " " + ddlReporte.SelectedValue + "  (por " + opOrden.SelectedValue + ")" : lblTituloPagina.Text + " " + ddlReporte.SelectedValue + "  (" + ddlTipoMaterial.SelectedItem.Text + " por " + opOrden.SelectedValue + ")";
        ReportParameter[] Parametros = new ReportParameter[2];
        Parametros[0] = new ReportParameter("prmTitulo", Titulo);
        Parametros[1] = new ReportParameter("prmUsuario", this.Master.HelpUsuario().LoginUsuario);
        rvStockXSAC.LocalReport.SetParameters(Parametros);

        rvStockXSAC.LocalReport.Refresh();
    }
    protected void opOrden_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<Reportes> lista = new List<Reportes>();
        ReportesLogic oReportesLogic = new ReportesLogic();

        string CodSac = ddlSAC.SelectedIndex == 0 ? null : ddlSAC.SelectedItem.Value;
        string CodTipoMaterial = ddlTipoMaterial.SelectedIndex == 0 ? null : ddlTipoMaterial.SelectedItem.Value;

        rvStockXSAC.Reset();


        if (ddlReporte.Items[0].Selected)
        {
            if (opOrden.Items[0].Selected)
            {
                lista = oReportesLogic.StockXSAC(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSAC", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACCon.rdlc";
            }
            else
            {
                lista = oReportesLogic.StockXSAC(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSAC", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACConXTema.rdlc";
            }

        }
        else
        {
            if (opOrden.Items[0].Selected)
            {
                lista = oReportesLogic.StockXSACDet(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSACDet", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACDet.rdlc";
            }
            else
            {
                lista = oReportesLogic.StockXSACDet(CodSac, CodTipoMaterial);
                ReportDataSource rds = new ReportDataSource("Inventario_pa_rep_StockXSACDet", lista);
                rvStockXSAC.LocalReport.DataSources.Clear();
                rvStockXSAC.LocalReport.DataSources.Add(rds);
                rvStockXSAC.LocalReport.ReportPath = @"Reportes\StockXSACDetXTema.rdlc";
            }
        }

        string Titulo = CodTipoMaterial == null ? lblTituloPagina.Text + " " + ddlReporte.SelectedValue + "  (por " + opOrden.SelectedValue + ")" : lblTituloPagina.Text + " " + ddlReporte.SelectedValue + "  (" + ddlTipoMaterial.SelectedItem.Text + " por " + opOrden.SelectedValue + ")";
        ReportParameter[] Parametros = new ReportParameter[2];
        Parametros[0] = new ReportParameter("prmTitulo", Titulo);
        Parametros[1] = new ReportParameter("prmUsuario", this.Master.HelpUsuario().LoginUsuario);
        rvStockXSAC.LocalReport.SetParameters(Parametros);

        rvStockXSAC.LocalReport.Refresh();
    }
}
