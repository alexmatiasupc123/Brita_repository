using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Oxinet.Tools;
using Britanico.SacNet.BusinessEntities;
using Britanico.SacNet.BusinessLogic;
using Oxinet.Maestros.Interface;
using Oxinet.Maestros.BusinessLogic;
using Oxinet.Maestros.BusinessEntities;
using System.Configuration;
public partial class ListaEjemplares_VerificarRetiro : System.Web.UI.Page
{
    #region "/--- Eventos de la Pagina  ---/"
    /**************************************************************************/
    protected void Page_Load(object sender, EventArgs e)
    {
        this.MessageBox1.OnConfirmClick += new EventHandler(MessageBox1_OnConfirmClick);
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["pm"] != null)
            {
                string querystringDESENCRYP = HelpEncrypt.DesEncriptar(Request.QueryString.Get("pm"));
                hfParameters.Value = querystringDESENCRYP;
                txtCodTransferencia.Text = HelpEncrypt.QueryString(querystringDESENCRYP, "tId");
                this.PintarDatosTransferencia(txtCodTransferencia.Text);
            }
        }
        Seguridad();
    }
    protected void Page_LoadComplete(object sender, EventArgs e)
    {       
        
        Page.Title = lblTituloPagina.Text;
    }
    #endregion
    
    #region "/--- Métodos del Programador  ---/"
    /**************************************************************************/
    /**************************************************************************/
   

    private void Seguridad()
    {
        RolesOpciones oRolesOpciones = this.Master.HelpOpcion_Permiso("ListaEjemplares_VerificarIngreso.aspx");
        if (oRolesOpciones != null)
        {
            lblTituloPagina.Text = oRolesOpciones.CodigoOpcionNombre;
            if (oRolesOpciones.Flag_Editar)
            {
                gvItemsTransferencia_Ingreso.Enabled = true;
                btnGenerarIngreso.Visible = true;
            }
            else
            {
                gvItemsTransferencia_Ingreso.Enabled = false;
                btnGenerarIngreso.Visible = false;
            }

        }
        else
        {
            Response.Redirect("Login.aspx");
        }
        
    }
    private void PintarDatosTransferencia(string pCodTransferencia)
    {
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        SolicitudTransferencia itemSolicitudTransferencia = new SolicitudTransferencia();
        itemSolicitudTransferencia = oSolicitudTransferenciaLogic.Buscar(pCodTransferencia,"I");
        txtSacOrigen.Text = itemSolicitudTransferencia.sNombreLocalOrigen;
        txtSacDestino.Text = itemSolicitudTransferencia.sNombreLocalDestino;
        HfCodSacDestino.Value = itemSolicitudTransferencia.sCodSacDestino;
        txtSolicitadoPor.Text = itemSolicitudTransferencia.sUsuarioSolicitante;
        txtFechaProcesoSolicitud.Text = itemSolicitudTransferencia.dFechaProcesoSolicitud.ToShortDateString();
        txtEstadoTransferencia.Text = itemSolicitudTransferencia.sCodArguNombreEstadoTransferencia;
        txtFechaProcesoRetiro.Text = DateTime.Today.ToShortDateString();
        gvItemsTransferencia_Ingreso.DataSource = itemSolicitudTransferencia.ListaDetalleTransferencia;
        gvItemsTransferencia_Ingreso.DataBind();
        HelpGridView.Caption(ref gvItemsTransferencia_Ingreso, "Lista de ejemplares a ingresar", itemSolicitudTransferencia.ListaDetalleTransferencia.Count.ToString());
        if (gvItemsTransferencia_Ingreso.Rows.Count > 0)
        {
            btnGenerarIngreso.Visible = true;
        }
        else
            btnGenerarIngreso.Visible = false;
    }
    private SolicitudTransferencia GetItemTransferenciaIngreso()
    {
        SolicitudTransferencia oSolicitudTransferencia = new SolicitudTransferencia();
        List<SolicitudTransferenciaDetalle> ListaDetalleTransferencia = new List<SolicitudTransferenciaDetalle>();
        string pEstadoIngresoVerificado = HelpConfiguration.AppSettings(HelpConfiguration.AppSett.CodArguEstadoTransferencia_Ingreso);
        oSolicitudTransferencia.sCodTransferencia = txtCodTransferencia.Text;
        oSolicitudTransferencia.sUsuarioSacDestino = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.dFechaProcesoIngreso = DateTime.Now;
        oSolicitudTransferencia.sCodArguEstadoTransferencia = pEstadoIngresoVerificado;
        oSolicitudTransferencia.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
        oSolicitudTransferencia.sCodSacDestino = HfCodSacDestino.Value;
        for (int i = 0; i < gvItemsTransferencia_Ingreso.Rows.Count; i++)
        {
            CheckBox chkIngreso = (CheckBox)gvItemsTransferencia_Ingreso.Rows[i].Cells[5].FindControl("chkIngreso");
            if (chkIngreso.Checked)
            {
                SolicitudTransferenciaDetalle oItemTransferenciaDetalle = new SolicitudTransferenciaDetalle();
                string CodEjemplar = gvItemsTransferencia_Ingreso.Rows[i].Cells[1].Text;
                oItemTransferenciaDetalle.sCodEjemplar = CodEjemplar;
                oItemTransferenciaDetalle.sCodTransferencia = txtCodTransferencia.Text;
                oItemTransferenciaDetalle.bAprobacionIngreso = true;
                oItemTransferenciaDetalle.SSIUsuario_Modificacion = Master.HelpUsuario().LoginUsuario;
                ListaDetalleTransferencia.Add(oItemTransferenciaDetalle);
            }

        }
        oSolicitudTransferencia.ListaDetalleTransferencia = ListaDetalleTransferencia;
        return oSolicitudTransferencia;
    }
    #endregion

    #region "/--- Eventos de los Controles  ---/"
    /**************************************************************************/

    void MessageBox1_OnConfirmClick(object sender, EventArgs e)
    {
        if (MessageBox1.Evento() == HelpEvento.Guardar.ToString())
        {
            ConfirmaIngreso(); ;
        }
    }

    protected void btnGenerarIngreso_Click(object sender, ImageClickEventArgs e)
    {
       int CantReg = 0;
       string mensaje = string.Empty;
        for (int i = 0; i < gvItemsTransferencia_Ingreso.Rows.Count; i++)
        {
            CheckBox chkIngreso = (CheckBox)gvItemsTransferencia_Ingreso.Rows[i].Cells[5].FindControl("chkIngreso");
            if (chkIngreso.Checked)
            {
                CantReg++;
            }

        }
        if (CantReg == 0)
        {
            mensaje = "¡ Seleccionar ejemplares a retirar. !"; 
        }
        if (mensaje == "")
        {
            MessageBox1.ShowConfirm("¿ Confirma el ingreso del ejemplar ?", HelpEvento.Guardar.ToString());
        }
        else
        {
            MessageBox1.ShowInfo(mensaje);
        }
    }

    private void ConfirmaIngreso()
    {
        ReturnValor oReturnValor = new ReturnValor();
        SolicitudTransferenciaLogic oSolicitudTransferenciaLogic = new SolicitudTransferenciaLogic();
        SolicitudTransferencia itemTransferencia = new SolicitudTransferencia();
        itemTransferencia = GetItemTransferenciaIngreso();
        oReturnValor = oSolicitudTransferenciaLogic.Actualizar_Ingreso(itemTransferencia);
        if (oReturnValor.Exitosa)
        {
            btnGenerarIngreso.Visible = false;
            gvItemsTransferencia_Ingreso.Enabled = false;
            MessageBox1.ShowSuccess(oReturnValor.Message);            
        }
        else
            MessageBox1.ShowWarning(oReturnValor.Message);
    }
    protected void gvItemsTransferencia_Ingreso_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gvItemsTransferencia_Ingreso.PageIndex = e.NewPageIndex;
        this.PintarDatosTransferencia(txtCodTransferencia.Text);
    }
    #endregion

    protected void imgbtnCancelar_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("ListaTransferenciaEjemplares_Ingreso.aspx?pm=" + HelpEncrypt.Encriptar(hfParameters.Value), true);
    }
  
}
