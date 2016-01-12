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

public partial class ReporteEjemplares : System.Web.UI.Page
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

        List<ItemEjemplar1> lista = new List<ItemEjemplar1>();
        ItemLogic oReportesLogic = new ItemLogic();

        string CodSac = ddlSAC.SelectedIndex == 0 ? null : ddlSAC.SelectedItem.Value;
        string CodTipoItem = ddlTipoMaterial.SelectedIndex == 0 ? null : ddlTipoMaterial.SelectedItem.Value;
        string CodAutor = ddlAutor.SelectedIndex == 0 ? "" : ddlAutor.SelectedItem.Value;
        string CodTipoMovimiento = ddlTipoMovimiento.SelectedItem.Value;
        //int Cantidad = Convert.ToInt16(txtCantidad.Text);
        //string orden = ddlOrden.SelectedItem.Value;
        string CodTema = ddlTema.SelectedIndex == 0 ? "" : ddlTema.SelectedItem.Value;
        string CodEstadoEjemplar = ddlEstadoEjemplar.SelectedIndex == 0 ? "" : ddlEstadoEjemplar.SelectedItem.Value;

        lista = oReportesLogic.ListarEjemplar(txtCodItem.Text, CodTipoItem, CodSac, txtTitulo.Text, CodAutor, string.Empty, string.Empty, CodTema, CodEstadoEjemplar, txtCodEjemplar.Text);
        ReportDataSource rds = new ReportDataSource("Britanico_SacNet_BusinessEntities_ItemEjemplar1", lista);

        rvEjemplares.LocalReport.DataSources.Clear();
        rvEjemplares.LocalReport.DataSources.Add(rds);
        rvEjemplares.LocalReport.ReportPath = @"Reportes\ListaEjemplares.rdlc";
        rvEjemplares.ShowToolBar = true;

        ReportParameter[] Parametros = new ReportParameter[2];
        Parametros[0] = new ReportParameter("prmTitulo", lblTituloPagina.Text);
        Parametros[1] = new ReportParameter("prmUsuario", this.Master.HelpUsuario().LoginUsuario);
        rvEjemplares.LocalReport.SetParameters(Parametros);
        
        rvEjemplares.LocalReport.Refresh();
    }

    /*protected void opFecha_SelectedIndexChanged(object sender, EventArgs e)
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
    }*/
    #endregion

    #region "/--- Metodos del Desarrollador  ---/"
    /**************************************************************************/

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ReporteEjemplares.aspx");
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
        HelpMaestros.CargarListadoGenerico(ref ddlTipoMaterial, HelpMaestros.TablasMaestras.TiposDeItem, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        txtCantidad.Text = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.Paginacion);

        
        HelpMaestros.CargarListadoGenerico(ref ddlEstadoEjemplar, HelpMaestros.TablasMaestras.EstadosDeEjemplares, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlAutor, HelpMaestros.TablasMaestras.AutoresDeItems, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        HelpMaestros.CargarListadoGenerico(ref ddlTema, HelpMaestros.TablasMaestras.TiposDeTemas, "", MaestroLogic.EstadoDetalle.Habilitado, HelpComboBox.Texto.Todos);
        
    }
    #endregion

}
